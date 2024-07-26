using System.ComponentModel.DataAnnotations;

namespace WP01.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Display(Name = "Office Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public Dept? Department { get; set; }

    }
    public enum Dept
    {
        HR,
        Payroll,
        IT
    }
}
