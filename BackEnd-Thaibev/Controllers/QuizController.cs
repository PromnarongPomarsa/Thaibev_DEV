using AspNetCoreGeneratedDocument;
using BackEnd_Thaibev.Models.Dto;
using BackEnd_Thaibev.Repository.IRepository;
using BackEnd_Thaibev.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Thaibev.Controllers
{
    [Route("api/quiz")]

    public class QuizController : Controller
    {
        private ResponseDto _response;
        private readonly IQuestionService _questionService;
        private readonly IMasterService _masterService;
        public QuizController(IMasterRepository masterRepo, IQuestionService questionService, IMasterService masterService)
        {
            _response = new ResponseDto();
            _questionService = questionService;
            _masterService = masterService;
        }

        [HttpGet("get-all-msg")]
        public async Task<ResponseDto> getAllMsg()
        {
            ResponseDto response = await _masterService.getAllMsg();
            return _response = response;
        }

        [HttpPost("save-question")]
        public async Task<ResponseDto> saveQuestion([FromBody] QuestionListDto request)
        {
            ResponseDto response = await _questionService.createQuestion(request);
            return _response = response;
        }

        [HttpGet("get-question")]
        public async Task<ResponseDto> getQuestion()
        {
            ResponseDto response = await _questionService.getAllQuestion();
            return _response = response;
        }

        [HttpPost("delete-question")]
        public async Task<ResponseDto> deleteQuestion([FromBody] QuestionIdDto request)
        {
            ResponseDto response = await _questionService.deleteQuestion(request);
            return _response = response;

        }

    }
}
