using BackEnd_Thaibev.Models;
using BackEnd_Thaibev.Models.Dto;

namespace BackEnd_Thaibev.Repositories.IRepositories
{
    public interface IQuestionRepository
    {
        Task<ResponseDto> saveQuestion(TbTQuestion entity);
        Task<ResponseDto> saveChoiceList(List<TbTChoiceItems> entity);
        Task<ResponseDto> deleteQuestion(TbTQuestion entity);
        Task<ResponseDto> getQuestionAll();
        Task<ResponseDto> getQuestionById(int question_id);
        Task<ResponseDto> getChoiceItemsAll();
        Task<ResponseDto> getChoiceByQuestionId(int question_id);
        Task<ResponseDto> deleteChoiceList(List<TbTChoiceItems> entity);
    }
}
