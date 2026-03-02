using AutoMapper;
using BackEnd_Thaibev.Models;
using BackEnd_Thaibev.Models.Dto;

namespace BackEnd_Thaibev.Mappings
{
    public class TbTChoiceMapping : Profile
    {
        public TbTChoiceMapping()
        {
            CreateMap<TbTChoiceItems, TbTChoiceItemsDto>()
                .ForMember(d => d.id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.refQuestionId, o => o.MapFrom(s => s.ref_question_id))
                .ForMember(d => d.choiceText, o => o.MapFrom(s => s.choice_text))
                .ForMember(d => d.isCorrect, o => o.MapFrom(s => s.is_correct))
                .ForMember(d => d.createDate, o => o.MapFrom(s => s.create_date));

            CreateMap<TbTChoiceItemsDto, TbTChoiceItems>()
                .ForMember(d => d.id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.ref_question_id, o => o.MapFrom(s => s.refQuestionId))
                .ForMember(d => d.choice_text, o => o.MapFrom(s => s.choiceText))
                .ForMember(d => d.is_correct, o => o.MapFrom(s => s.isCorrect))
                .ForMember(d => d.create_date, o => o.MapFrom(s => s.createDate));
        }

    }
}
