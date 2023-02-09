using System.ComponentModel.DataAnnotations;

namespace GradingModule.Dtos
{
    public class CreateMarksCalculationDtos
    {
        [Required]
        [MaxLength(10)]
        public String stud_id { get; set; }  
        [Required]
        [MaxLength(10)]
        public string course_id { get; set; } 

    }
}