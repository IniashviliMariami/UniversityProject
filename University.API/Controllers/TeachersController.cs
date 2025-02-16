using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using University.Models.Entities;
using UniversityRepository.Data;

namespace University.API.Controllers
{
    [Route("teacher")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
       
        public TeachersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddTeacher([FromBody] Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]

        public IActionResult GetTeachers() 
        {
            var teacher = _context.Teachers.ToList();
            return Ok(teacher);
        }

        [HttpGet("{id}")]

        public IActionResult GetTeacher([FromBody] int id)
        {
            var teacher= _context.Teachers.SingleOrDefault(t => t.Id == id);
            return Ok(teacher);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteTeacher([FromRoute]int id)
        {
            var teacherDelete = _context.Teachers.FirstOrDefault(t => t.Id == id);
            _context.Teachers.Remove(teacherDelete);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult TeacherUpdate([FromBody] Teacher teacher)
        {
            var teacherUpdate=_context.Teachers.FirstOrDefault(t=>t.Id== teacher.Id);
            teacherUpdate.Name= teacher.Name;
            teacherUpdate.Salary= teacher.Salary;
            teacherUpdate.Subject= teacher.Subject;
            teacherUpdate.Age= teacher.Age; 
            _context.SaveChanges();
            return Ok();

        }
        


    }
}
