using AutoMapper;
using BackEnd_Thaibev.Models;
using BackEnd_Thaibev.Models.Dto;
using BackEnd_Thaibev.Repository.IRepository;
using BackEnd_Thaibev.Services.IServices;

namespace BackEnd_Thaibev.Services
{
    public class MasterService : IMasterService
    {
        private ResponseDto _response;
        private readonly IMasterRepository _masterRepo;
        private readonly IMapper _mapper;
        public MasterService(IMasterRepository masterRepo, IMapper mapper)
        {
            _response = new ResponseDto();
            _masterRepo = masterRepo;
            _mapper = mapper;
        }
        public async Task<ResponseDto> getAllMsg()
        {
            ResponseDto response = await _masterRepo.getAllMsg();
            
            if (!response.IsSuccess || response.Result == null)
            {
                _response.IsSuccess = false;
                _response.Message = response.Message;
                return _response;
            }

            List<TbMMsg> dataMsg = response.Result as List<TbMMsg>;
            List<TbMMsgDto> dataMsgDto = _mapper.Map<List<TbMMsgDto>>(dataMsg);
            _response.Result = dataMsgDto;

            return _response;
        }
    }
}
