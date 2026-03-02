using BackEnd_Thaibev.Models.Dto;

namespace BackEnd_Thaibev.Repository.IRepository
{
    public interface IMasterRepository
    {
        Task<ResponseDto> getAllMsg();
    }
}
