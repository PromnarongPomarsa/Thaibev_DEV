using AutoMapper;
using Azure.Core;
using BackEnd_Thaibev.Models;
using BackEnd_Thaibev.Models.Dto;
using BackEnd_Thaibev.Repositories.IRepositories;
using BackEnd_Thaibev.Repository.IRepository;
using BackEnd_Thaibev.Services.IServices;

namespace BackEnd_Thaibev.Services
{
    public class QuestionService : IQuestionService
    {
        private ResponseDto _response;
        private readonly IQuestionRepository _questionRepo;
        private readonly IMapper _mapper;
        public QuestionService(IQuestionRepository questionRepo, IMapper mapper)
        {
            _response = new ResponseDto();
            _questionRepo = questionRepo;
            _mapper = mapper;
        }

        public async Task<ResponseDto> createQuestion(QuestionListDto request)
        {
            TbTQuestion entityQuestion = new TbTQuestion();
            entityQuestion.question = request.question;
            entityQuestion.create_date = DateTime.UtcNow;

            ResponseDto response = await _questionRepo.saveQuestion(entityQuestion);

            if (!response.IsSuccess || response.Result == null)
            {
                _response.IsSuccess = false;
                _response.Message = response.Message;
                return _response;
            }

            TbTQuestion dataQuestion = response.Result as TbTQuestion;
            List<TbTChoiceItems> entityListChoice = _mapper.Map<List<TbTChoiceItems>>(request.choiceItems);

            foreach(var item in entityListChoice)
            {
                item.ref_question_id = dataQuestion.id;
                item.create_date = DateTime.UtcNow;
            }
            ResponseDto saveChoiceItems = await _questionRepo.saveChoiceList(entityListChoice);

            if (!saveChoiceItems.IsSuccess)
            {
                _response.IsSuccess = false;
                _response.Message = saveChoiceItems.Message;
            }

            return _response;
        }
        public async Task<ResponseDto> getAllQuestion()
        {
            ResponseDto getAllQuestion = await _questionRepo.getQuestionAll();

            if (!getAllQuestion.IsSuccess)
            {
                _response.IsSuccess = false;
                _response.Message = getAllQuestion.Message;
                return _response;
            }
            List<TbTQuestion> listQuestion = getAllQuestion.Result as List<TbTQuestion>;

            ResponseDto getChoiceItemsAll = await _questionRepo.getChoiceItemsAll();

            if (!getChoiceItemsAll.IsSuccess)
            {
                _response.IsSuccess = false;
                _response.Message = getChoiceItemsAll.Message;
                return _response;
            }
            List<TbTChoiceItems> listChoiceItems = getChoiceItemsAll.Result as List<TbTChoiceItems>;

            List<QuestionListDto> questionList = new List<QuestionListDto>();
            foreach (var item in listQuestion)
            {
                QuestionListDto obj = new QuestionListDto();
                obj.id = item.id;
                obj.question = item.question;
                obj.createDate = item.create_date;
                obj.choiceItems = listChoiceItems.Where(x => x.ref_question_id == item.id).Select(x => new TbTChoiceItemsDto
                {
                    id = x.id,
                    refQuestionId = x.ref_question_id,
                    choiceText = x.choice_text,
                    isCorrect = x.is_correct,
                    createDate = x.create_date
                }).ToList();
                questionList.Add(obj);
            }

            _response.Result = questionList;
            return _response;
        }
        public async Task<ResponseDto> getQuestionById(int question_id)
        {
            ResponseDto response = await _questionRepo.getQuestionById(question_id);

            if (!response.IsSuccess)
            {
                _response.IsSuccess = false;
                _response.Message = response.Message;
                return _response;
            }

            TbTQuestionDto dataDto = _mapper.Map<TbTQuestionDto>(response.Result as TbTQuestion);
            _response.Result = dataDto;

            return _response;
        }
        public async Task<ResponseDto> deleteQuestion(QuestionIdDto request)
        {
            int question_id = request.questionId;

            ResponseDto getQuestion = await _questionRepo.getQuestionById(question_id);

            if (getQuestion.Result == null)
            {
                _response.IsSuccess = false;
                _response.Message = $"Unable to process: This question {question_id} id is doen't exists";
                return _response;
            }

            TbTQuestion questionData = getQuestion.Result as TbTQuestion;

            ResponseDto getChoice = await _questionRepo.getChoiceByQuestionId(question_id);

            if (!getChoice.IsSuccess || getChoice.Result == null)
            {
                _response.IsSuccess = false;
                _response.Message = $"Unable to process: This question {question_id} id is doen't exists";
                return _response;
            }
            List<TbTChoiceItems> choiceData = getQuestion.Result as List<TbTChoiceItems>;

            ResponseDto delChoiceData = await _questionRepo.deleteChoiceList(choiceData);

            if (!delChoiceData.IsSuccess)
            {
                _response.IsSuccess = false;
                _response.Message = delChoiceData.Message;
            }

            ResponseDto delQuestion = await _questionRepo.deleteQuestion(questionData);


            if (!delQuestion.IsSuccess)
            {
                _response.IsSuccess = false;
                _response.Message = delQuestion.Message;
            }

            return _response;
        }
    }
}
