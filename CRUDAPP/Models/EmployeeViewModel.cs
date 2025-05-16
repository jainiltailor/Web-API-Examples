using System.ComponentModel.DataAnnotations;

namespace CRUDAPP.Models
{
    public class EmployeeViewModel
    {

        [Key]
        public Guid EmpID { get; set; }
        public required string EmpName { get; set; }
        public string? EmpEmail { get; set; }
        public string? Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
