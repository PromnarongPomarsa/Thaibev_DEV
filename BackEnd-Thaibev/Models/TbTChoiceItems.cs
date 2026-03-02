using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_Thaibev.Models
{
    public class TbTChoiceItems
    {
        [Key]
        public int? id { get; set; }
        public int? ref_question_id { get; set; }
        public string? choice_text { get; set; }
        public string? is_correct { get; set; }
        public DateTime? create_date { get; set; }
    }
}
