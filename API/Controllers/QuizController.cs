using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class QuizController : BaseApiController
    {
        private readonly IMapper mapper;
        private readonly IStudentRepository studentRepository;
        private readonly IQuizRepository quizRepository;
        public QuizController(IMapper mapper, IStudentRepository studentRepository, IQuizRepository quizRepository)
        {
            this.quizRepository = quizRepository;
            this.studentRepository = studentRepository;
            this.mapper = mapper;

        }
        [HttpGet("{id_quiz}")]
        public async Task<ActionResult<QuizSubmitDto>> OpenQuiz(int id_quiz)
        {
            int id_user = User.GetUserId();
            var student = await this.studentRepository.IsAuthorizedToOpenQuiz(id_user, id_quiz);
            if (student == null)
            {
                return Unauthorized();
            }

            var openedQuiz = this.quizRepository.OpenQuiz(id_quiz,student.Id);


            return Ok(openedQuiz);

        }

       
    }
}