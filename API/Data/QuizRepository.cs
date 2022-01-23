using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Entities.Uploads;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class QuizRepository : IQuizRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public QuizRepository(DataContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }
        public async Task<bool> SubmitQuiz(QuizSubmit submit)
        {
            //validate the quiz submit
            // var result = this.context.QuizSubmit.;

            // result.Entity.FinalGrade = GetFinalGrade(result.Entity.Answears);
            // return await this.context.SaveChangesAsync() > 0;
            return true;

        }

        public async Task<QuizSubmitDto> OpenQuiz(int id_quiz, int id_student)
        {
            var query = this.context.Quiz.AsQueryable();
            var quiz = query.SingleOrDefault(q => q.Id == id_quiz);
            if (DateTime.Compare(DateTime.Today, quiz.CloseQuiz) > 0)
            {
                throw new Exception("The quiz is closed");
            }
            if (DateTime.Compare(DateTime.Today, quiz.OpenQuiz) < 0)
            {
                throw new Exception("Too early");
            }
            var quizSumbit = this.context.QuizSubmit
                            .SingleOrDefault(q => q.StudentId == id_student && q.QuizId == id_quiz);

            if (quizSumbit == null)
            {
                var submit = this.context.QuizSubmit.Add(new QuizSubmit
                {
                    DateOpened = DateTime.Today,
                    IndexCurrentQuestion = 0,
                    QuizId = id_quiz,
                    StudentId = id_student,
                    Answears = this.ShuffleQuestions(quizSumbit.Quiz.Questions.ToList())
                });
                await this.context.SaveChangesAsync();
                return this.mapper.Map<QuizSubmitDto>(submit.Entity);

            }
            else return this.mapper.Map<QuizSubmitDto>(quizSumbit);

        }

        public async Task Answear(QuestionAnswear question_answear)
        {
            var quiz_submit = await this.context.QuizSubmit
                            .SingleOrDefaultAsync(q => q.Id == question_answear.QuizSubmitId);
            if (quiz_submit.DateOpened.CalculateTimeLeft(quiz_submit.Quiz.TimeLimit) == 0)
            {
                throw new Exception("Time expired");
            }
            var answear = quiz_submit
                    .Answears.SingleOrDefault(a => a.QuestionId == question_answear.QuestionId);
            answear = question_answear;
            await this.context.SaveChangesAsync();

        }

        public async Task<QuestionDto> GetNextQuestion(int id_quiz, int id_student)
        {
            var query = this.context.QuizSubmit.AsQueryable();
            var quiz_submit = query.SingleOrDefault(q => q.StudentId == id_student && q.QuizId == id_quiz);
            if (DateTime.Compare(DateTime.Today, quiz_submit.Quiz.CloseQuiz) > 0)
            {
                throw new Exception("The quiz is closed");
            }
            if (DateTime.Compare(DateTime.Today, quiz_submit.Quiz.OpenQuiz) < 0)
            {
                throw new Exception("Too early");
            }
            if (quiz_submit.IndexCurrentQuestion < quiz_submit.Quiz.Questions.Count() - 1)
            {
                quiz_submit.IndexCurrentQuestion++;
                await this.context.SaveChangesAsync();
                return this.mapper.Map<QuestionDto>(
                            quiz_submit.Answears.ElementAt(quiz_submit.IndexCurrentQuestion).Question
                            );
            }
            else throw new Exception("That was the last question");
        }

        public async Task<QuestionDto> GetPreviousQuestion(int id_quiz, int id_student)
        {
            var query = this.context.QuizSubmit.AsQueryable();
            var quiz_submit = query.SingleOrDefault(q => q.StudentId == id_student && q.QuizId == id_quiz);
            if (DateTime.Compare(DateTime.Today, quiz_submit.Quiz.CloseQuiz) > 0)
            {
                throw new Exception("The quiz is closed");
            }
            if (DateTime.Compare(DateTime.Today, quiz_submit.Quiz.OpenQuiz) < 0)
            {
                throw new Exception("Too early");
            }
            if (!quiz_submit.Quiz.AllowGoingBack)
            {
                throw new Exception("Going back is forbbiden");
            }
            if (quiz_submit.IndexCurrentQuestion > 0)
            {
                quiz_submit.IndexCurrentQuestion--;
                await this.context.SaveChangesAsync();
                return this.mapper.Map<QuestionDto>(
                            quiz_submit.Answears.ElementAt(quiz_submit.IndexCurrentQuestion).Question
                            );
            }
            else throw new Exception("This is the first question");
        }


        private double GetFinalGrade(ICollection<QuestionAnswear> questionAnswears)
        {
            double finalGrade = 0;
            foreach (var quest in questionAnswears)
            {
                double question_grade;
                if (quest.Question.shortAnswear != null)
                {
                    finalGrade += quest.ShortAnswear.Equals(quest.Question.shortAnswear) ? quest.Question.Mark : 0;
                    continue;
                }

                int nr_correct_answears = quest.Answears.Count(a => a.Choice.isCorrect);
                int nr_wrong_answears = quest.Answears.Count(a => !a.Choice.isCorrect);
                int total_correct_answears = quest.Question.Choices.Count(a => a.isCorrect);
                question_grade = quest.Question.Mark * nr_correct_answears / total_correct_answears
                                       - quest.Question.WrongAnswearSanction * nr_wrong_answears;
                question_grade = question_grade > 0 ? question_grade : 0;
                finalGrade += question_grade;

            }
            return finalGrade;
        }
        private ICollection<QuestionAnswear> ShuffleQuestions(List<Question> questions)
        {
            int n = questions.Count;
            Random rng = new Random();
            var answears = new QuestionAnswear[n];
            for (int i = 0; i < n; i++)
            {
                answears[i].Question = questions[i];
            }
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = answears[k];
                answears[k] = answears[n];
                answears[n] = value;
            }
            return answears;
        }


    }
}