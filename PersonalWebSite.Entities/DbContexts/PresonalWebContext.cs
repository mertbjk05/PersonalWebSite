using Microsoft.EntityFrameworkCore;
using PersonalWebSite.Entities.Models;

namespace PersonalWebSite.Entities.DbContexts
{
    public class PersonalWebContext : DbContext
    {
        public PersonalWebContext(DbContextOptions<PersonalWebContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MERT\\MSSQLSERVER01;Database=PersonalWebDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
