using Microsoft.EntityFrameworkCore;
using Project_WebApi.Models;

namespace Project_WebApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Batch> Batches { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Role> Roles { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(new Role() { RoleId = 1, RoleName = "admin" },
                 new Role() { RoleId = 2, RoleName = "manager" },
                 new Role() { RoleId = 3, RoleName = "user" }
                );


        }
    }
}
