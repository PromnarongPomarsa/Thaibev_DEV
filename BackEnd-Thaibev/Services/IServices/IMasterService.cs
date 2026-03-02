using BackEnd_Thaibev.Models.Dto;

namespace BackEnd_Thaibev.Services.IServices
{
    public interface IMasterService
    {
        Task<ResponseDto> getAllMsg();  
    }
}
