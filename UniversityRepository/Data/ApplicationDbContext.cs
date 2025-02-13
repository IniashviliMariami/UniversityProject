using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using University.Models.Entities;


namespace UniversityRepository.Data
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

       
    }
}
