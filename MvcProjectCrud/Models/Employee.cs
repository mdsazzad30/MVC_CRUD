using System.ComponentModel.DataAnnotations;

namespace MvcProjectCrud.Models
{
    public class Employee
    {
        [Required]
        [Key]
        [Display(Name = "Id Number")]
        //[Range(0, 8)]
        //[MaxLength(8)]
        public int IdNumber { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Department")]
        public string Department { get; set; } = string.Empty;


        [Required]
        [Display(Name = "Division")]
        public string? Division { get; set; }

        [Required(ErrorMessage = "Date of Birth is Required")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTimeOffset DateOfBirth { get; set; }

        [Required]
        //[DataType(DataType.Upload)]
        [Display(Name = "Resume Upload")]
        public string? ResumeUpload { get; set; }

    }
}
