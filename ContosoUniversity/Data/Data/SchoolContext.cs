using Data.Mapping;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CourseMap(modelBuilder);
            // modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            var studentMap = modelBuilder.Entity<Student>().ToTable("Student");

            // Mapeando ValueObjects e mudando nome da propriedade
            // Caso contrário, o atributo no banco ficaria "Email_Address"
            studentMap.OwnsOne(x => x.Email).Property(x => x.Address).HasColumnName("Mail");

            // Ignorar propriedade
            studentMap.OwnsOne(x => x.Email).Ignore(x => x.PropertyIgnore);
        }
    }
}