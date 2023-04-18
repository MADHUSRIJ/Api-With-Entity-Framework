using ApiWithEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWithEntityFramework.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<StudentModel> StudentDetails { get; set; }
    }
}
