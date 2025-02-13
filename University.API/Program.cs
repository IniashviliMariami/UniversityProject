
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniversityRepository.Data;



namespace University.API
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllers();
            
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=DESKTOP-M3C3ROO\\SQLEXPRESS02;Database=University;Trusted_Connection=true;TrustServerCertificate=true"));
               
               
            var app = builder.Build();

            
            app.MapOpenApi();
            
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        
    }
}
