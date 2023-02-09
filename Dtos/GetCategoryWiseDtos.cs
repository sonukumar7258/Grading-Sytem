using System.ComponentModel.DataAnnotations;

namespace GradingModule.Dtos
{
    public class GetCategoryWiseDtos
    {
        [Required]
        [MaxLength(10)]
        public string stud_id { get; set; }

        [Required]
        [MaxLength(10)]
        public string course_id { get; set; }

        [Required]
        [MaxLength(15)]
        public String CategoryName { get; set; }
    }
}