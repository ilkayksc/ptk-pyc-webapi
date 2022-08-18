using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PycWebApi.Controllers
{
    public class Employee1
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal HourlySalary { get; set; }
    }
    public class Employee2
    {
        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 10, ErrorMessage = "Name must be range in 10-250")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Email address is not valid")]
        [StringLength(maximumLength: 250, MinimumLength = 10, ErrorMessage = "Email must be range in 10-250")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Phone number is not valid")]
        public string PhoneNumber { get; set; }

        [Range(minimum: 10, maximum: 500, ErrorMessage = "Hourly salary must be range in 10-500")]
        public decimal HourlySalary { get; set; }
    }

    [Route("Pyc/v1.0/api/[controller]")]
    [ApiController]
    public class EmployeeContoller : ControllerBase
    {
        public EmployeeContoller()
        {

        }


        [HttpPost]
        [Route("Register1")]
        public CommonResponse<Employee1> Register1([FromBody] Employee1 request)
        {
            if (request == null)
            {
                return new CommonResponse<Employee1>("Request can not be null !");
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return new CommonResponse<Employee1>("Name can not be null !");
            }
            if (request.Name.Length < 10 || request.Name.Length > 250)
            {
                return new CommonResponse<Employee1>("Name must be range in 10-250 ");
            }
            if (request.HourlySalary < 10 || request.HourlySalary > 500)
            {
                return new CommonResponse<Employee1>("HourlySalary must be range in 10-500 ");
            }

            return new CommonResponse<Employee1>(request);
        }

        [HttpPost]
        [Route("Register2")]
        public CommonResponse<Employee2> Register2([FromBody] Employee2 request)
        {
            if (ModelState.IsValid)
            {

            }
            else
            {

            }

            return new CommonResponse<Employee2>(request);
        }
    }
}
