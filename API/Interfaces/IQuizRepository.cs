using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities.Uploads;

namespace API.Interfaces
{
    public interface IQuizRepository
    {
        Task<bool> SubmitQuiz(QuizSubmit submit);
        Task<QuizSubmitDto> OpenQuiz(int id_quiz, int id_student);

    }
}