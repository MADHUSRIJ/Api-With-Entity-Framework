﻿using System.ComponentModel.DataAnnotations;

namespace ApiWithEntityFramework.Models
{
    public class StudentModel
    {
        [Key]
        [Required]
        public int StudentId { get; set; }

        [Required]
        public string? StudentName { get; set; }

        [Required]
        public string? RollNo { get; set; }

        [Required]
        public string? Dept { get; set; }

        [Required]
        public DateTime Dob { get; set; }

        [Required]
        public string? Class { get; set; }
    }
}
