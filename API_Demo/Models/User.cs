using System.ComponentModel.DataAnnotations;

namespace API_Demo.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't exceed 100 characters.")]
        public string Name { get; set; }
        public string Occupation { get; set; } 
        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<SalaryHistory> SalaryHistories { get; set; }
        public ICollection<PerformanceReview> PerformanceReviews { get; set; }
    }
}