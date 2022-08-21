using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace PycWebApi.Controllers
{
    public class CommonResponse<Entity>
    {
        public CommonResponse()
        {

        }
        public CommonResponse(Entity data)
        {
            Data = data;
        }
        public CommonResponse(string error)
        {
            Error = error;
            Success = false;
        }
        public bool Success { get; set; } = true;
        public string Error { get; set; }
        public Entity Data { get; set; }
    }

    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentController()
        {

        }


        private CommonResponse<List<Student>> GetList()
        {
            List<Student> list = new();
            list.Add(new Student { Id = 1, Age = 23, Email = "deny@sellen.com", Lastname = "Sellen", Name = "Deny" });
            list.Add(new Student { Id = 2, Age = 24, Email = "deny@sellen.com", Lastname = "Sellen", Name = "Deny" });
            list.Add(new Student { Id = 3, Age = 25, Email = "deny@sellen.com", Lastname = "Sellen", Name = "Deny" });

            return new CommonResponse<List<Student>>(list);
        }


        [HttpGet]
        [Route("GetAll")]
        public CommonResponse<List<Student>> GetAll()
        {
            return GetList();
        }


        [HttpGet("GetById/{id}")]
        public CommonResponse<Student> GetById([FromRoute] long id)
        {
            CommonResponse<List<Student>> list = GetList();
            Student student = list.Data.Where(x => x.Id == id).FirstOrDefault();
            return new CommonResponse<Student>(student);
        }

        [HttpGet]
        [Route("GetByFilter")]
        public CommonResponse<List<Student>> Get([FromQuery] string name, string lastname)
        {
            List<Student> list = GetList().Data;
            List<Student> students = list.Where(x => x.Name.ToUpper().Contains(name.ToUpper()) || x.Lastname.ToUpper().Contains(lastname.ToUpper())).ToList();
            return new CommonResponse<List<Student>>(students);
        }


        [HttpPost]
        public CommonResponse<List<Student>> Post([FromBody] Student student)
        {
            var list = GetList().Data;
            list.Add(student);
            return new CommonResponse<List<Student>>(list);
        }

        [HttpPut]
        public CommonResponse<List<Student>> Put(int id, [FromBody] Student request)
        {
            List<Student> list = GetList().Data;
            Student student = list.Where(x => x.Id == id).FirstOrDefault();
            list.Remove(student);
            request.Id = id;
            list.Add(request);
            return new CommonResponse<List<Student>>(list.ToList());
        }

        [HttpDelete("{id}")]
        public CommonResponse<List<Student>> Delete ([FromRoute] int id)
        {
            List<Student> list = GetList().Data;
            Student student = list.Where(x => x.Id == id).FirstOrDefault();
            list.Remove(student);
            return new CommonResponse<List<Student>>(list);
        }
    }
}
