using Microsoft.EntityFrameworkCore;
using UserAPI.Models;

namespace UserAPI.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        //Tables
        public DbSet<UserModel> Users { get; set; }
    }
}
