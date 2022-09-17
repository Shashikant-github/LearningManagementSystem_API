using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoursesAPI.Context
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext(DbContextOptions<CoursesDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        //Table
        public DbSet<CoursesModel> Courses { get; set; }
    }
}
