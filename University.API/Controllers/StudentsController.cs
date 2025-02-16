using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using University.Models.Entities;

using UniversityRepository.Data;

namespace University.API.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]

        public IActionResult AddStident([FromBody] Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok();
        }


        [HttpGet]
        public IActionResult GetStudent()
        {
            var student = _context.Students.ToList();
            
            return Ok(student);
        }

        [HttpGet("{id}")]

        public IActionResult GetStudent([FromRoute] int id) 
        { 
            var student=_context.Students.FirstOrDefault(x => x.Id == id);
            
            return Ok(student);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent([FromRoute] int id)
        {
            var studentToDelete = _context.Students.FirstOrDefault(s => s.Id == id);
            _context.Students.Remove(studentToDelete);
            _context.SaveChanges();

            return Ok();
        }


        [HttpPut]
        public IActionResult UpdateStudent([FromBody] Student student)
        {
            var studentUpdate = _context.Students.FirstOrDefault(s => s.Id == student.Id);
            studentUpdate.FirstName = student.FirstName;
            studentUpdate.PersonalNumber = student.PersonalNumber;
            studentUpdate.Email = student.Email;
            studentUpdate.BirthDate = student.BirthDate;
            _context.SaveChanges();
            return Ok();
        }
    }



}


