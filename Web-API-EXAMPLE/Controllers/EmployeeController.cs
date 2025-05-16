using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_EXAMPLE.Data;
using Web_API_EXAMPLE.Model;
using Web_API_EXAMPLE.Model.Entities;

namespace Web_API_EXAMPLE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDBContext DBContext;

        public EmployeeController(ApplicationDBContext context)
        {
            this.DBContext = context;
        }

        [HttpGet]
        public IActionResult GetAllAction()
        {
            var allEmployees = DBContext.Employees.ToList();
            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("{ID:Guid}")]
        public IActionResult GetEmployeeByID(Guid ID)
        {
            var employee = DBContext.Employees.Find(ID);

            if (employee == null)
            {
                return NotFound();
            }
            
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDTO addEmp)
        {
            var employeeentitiy = new Employee()
            {
                EmpName=addEmp.EmpName,
                Phone=addEmp.Phone,
                EmpEmail=addEmp.EmpEmail,
                Salary=addEmp.Salary
            };
            DBContext.Employees.Add(employeeentitiy);
            DBContext.SaveChanges();
            return Ok(employeeentitiy);

        }

        [HttpPut]
        [Route("{ID:Guid}")]
        public IActionResult UpdateEmployee(AddEmployeeDTO addEmp, Guid ID)
        {
            var employee = DBContext.Employees.Find(ID);

            if (employee == null)
            {
                return NotFound();
            }
            employee.EmpName = addEmp.EmpName;
            employee.Phone = addEmp.Phone;
            employee.EmpEmail = addEmp.EmpEmail;
            employee.Salary = addEmp.Salary;
           
            DBContext.SaveChanges();
            return Ok(employee);

        }

        [HttpDelete]
        [Route("{ID:Guid}")]

        public IActionResult DeleteEmplyee(Guid ID)
        {
            var employee = DBContext.Employees.Find(ID);

            if (employee == null)
            {
                return NotFound();
            }

            DBContext.Employees.Remove(employee);
            DBContext.SaveChanges();
            return Ok(employee);
        }
    }
}