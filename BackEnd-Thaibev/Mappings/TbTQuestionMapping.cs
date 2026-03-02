using AutoMapper;
using BackEnd_Thaibev.Models;
using BackEnd_Thaibev.Models.Dto;
namespace BackEnd_Thaibev.Mappings
{
    public class TbTQuestionMapping : Profile
    {
        public TbTQuestionMapping()
        {
            CreateMap<TbTQuestion, TbTQuestionDto>()
                .ForMember(d => d.id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.question, o => o.MapFrom(s => s.question))
                .ForMember(d => d.createDate, o => o.MapFrom(s => s.create_date));

            CreateMap<TbTQuestionDto, TbTQuestion>()
                .ForMember(d =>d.id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.question, o => o.MapFrom(s => s.question))
                .ForMember(d => d.create_date, o => o.MapFrom(s => s.createDate));
        }
    }
}
