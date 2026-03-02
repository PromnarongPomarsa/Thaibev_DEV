using BackEnd_Thaibev.Models;
using BackEnd_Thaibev.Repository.IRepository;
using BackEnd_Thaibev.Data;
using Microsoft.EntityFrameworkCore;
using BackEnd_Thaibev.Models.Dto;

namespace BackEnd_Thaibev.Repository
{
    public class MasterRepository : IMasterRepository
    {
        private ResponseDto _response;
        private readonly AppDbContext _db;

        public MasterRepository(AppDbContext db)
        {
            _response = new ResponseDto();
            _db = db;
        }

        public async Task<ResponseDto> getAllMsg()
        {
            try
            {
                List<TbMMsg> listMsg = await _db.tb_m_msg.ToListAsync();
                _response.Result = listMsg;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

    }
}
