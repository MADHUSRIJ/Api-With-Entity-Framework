using System.ComponentModel.DataAnnotations;

namespace ApiWithEntityFramework.Models
{
    public class TeacherModel
    {
        [Key]
        [Required]
        public int StaffId { get; set; }

        [Required]
        public string? StaffName { get; set; }

        [Required]
        public string? Dept { get; set; }

        [Required]
        public string? Class { get; set; }
    }
}
