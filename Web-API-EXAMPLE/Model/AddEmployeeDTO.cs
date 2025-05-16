namespace Web_API_EXAMPLE.Model
{
    public class AddEmployeeDTO
    {
        public required string EmpName { get; set; }
        public string? EmpEmail { get; set; }
        public string? Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
