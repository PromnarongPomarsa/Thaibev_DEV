using AutoMapper;
using BackEnd_Thaibev.Models;
using BackEnd_Thaibev.Models.Dto;

namespace BackEnd_Thaibev.Mappings
{
    public class TbMMsgMapping : Profile
    {
        public TbMMsgMapping()
        {
            CreateMap<TbMMsg, TbMMsgDto>()
                .ForMember(d => d.id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.msgCode, o => o.MapFrom(s => s.msg_code))
                .ForMember(d => d.msgDesc, o => o.MapFrom(s => s.msg_desc))
                .ForMember(d => d.createDate, o => o.MapFrom(s => s.create_date));

            CreateMap<TbMMsgDto, TbMMsg>()
                .ForMember(d => d.id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.msg_code, o => o.MapFrom(s => s.msgCode))
                .ForMember(d => d.msg_desc, o => o.MapFrom(s => s.msgDesc))
                .ForMember(d => d.create_date, o => o.MapFrom(s => s.createDate));
        }

    }
}
