namespace BackEnd_Thaibev.Models.Dto
{
    public class QuestionListDto
    {
        public int? id { get; set; }
        public string? question { get; set; }
        public string? answer { get; set; }
        public List<TbTChoiceItemsDto>? choiceItems { get; set; }
        public DateTime? createDate { get; set; }

    }
}
