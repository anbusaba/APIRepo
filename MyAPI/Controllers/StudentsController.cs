using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private List<Student> students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Name="NEo",
                Age=25,
                City="Chennai"
            },
            new Student()
            {
                Id = 2,
                Name="Trinity",
                Age=25,
                City="Mumbai"

            }
        };

        [HttpGet]
        [Route("getStudents")]
        public async Task< ActionResult<Student>> GetStudents()
        {
            return Ok(students); 
        }
        [HttpGet]
        [Route("getStudent")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {

            var student = students.Find(x => x.Id == id);
            if (student == null)
                return BadRequest("No Student Found");
            return Ok(student);
        }

        [HttpPost]
        [Route("addStudent")]
        public async Task<ActionResult<Student>> AddStudent(Student request)
        {

            students.Add(request);
            return Ok(students);
        }
        [HttpPut]
        [Route("updateStudent")]
        public async Task<ActionResult<Student>> UpdateStudent(Student request)
        {

            var student = students.Find(x => x.Id == request.Id);
            if (student == null)
                return BadRequest("No Student Found");
            student.Name = request.Name;
            student.Age = request.Age;
            student.City = request.City;
            return Ok(students);


        }
        [HttpDelete]
        [Route("deleteStudent")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {

            var student = students.Find(x => x.Id == id);
            if (student == null)
                return BadRequest("No Student Found");
            students.Remove(student);
            return Ok(students);


        }
    }
}

