using System.ComponentModel.DataAnnotations;

namespace Web_API_EXAMPLE.Model.Entities
{
    public class Employee
    {
        [Key]
        public Guid EmpID { get; set; }
        public required string EmpName { get; set; }
        public string? EmpEmail { get; set; }
        public string? Phone {  get; set; }
        public decimal Salary { get; set; }
    }
}
