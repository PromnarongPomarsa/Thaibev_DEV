namespace BackEnd_Thaibev.Models.Dto
{
    public class TbTChoiceItemsDto
    {
        public int? id { get; set; }
        public int? refQuestionId { get; set; }
        public string? choiceText { get; set; }
        public string? isCorrect { get; set; }
        public DateTime? createDate { get; set; }

    }
}
