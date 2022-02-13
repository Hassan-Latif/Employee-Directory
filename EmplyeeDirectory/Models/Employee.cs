using System.ComponentModel.DataAnnotations;

namespace EmplyeeDirectory.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; }

        public int EmployeeAge { get; set; }
            
        public string DepartmentName { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }


    }
}
