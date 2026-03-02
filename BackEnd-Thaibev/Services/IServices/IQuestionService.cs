using BackEnd_Thaibev.Models.Dto;

namespace BackEnd_Thaibev.Services.IServices
{
    public interface IQuestionService
    {
        Task<ResponseDto> getAllQuestion();
        Task<ResponseDto> createQuestion(QuestionListDto questionDto);
        Task<ResponseDto> deleteQuestion(QuestionIdDto request);
    }
}
