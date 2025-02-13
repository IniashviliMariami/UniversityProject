using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UniversityRepository.Data;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TeachersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public void Get( int id) 
        {
            var teacher = _context.Teachers.ToList();
        }

    }
}
