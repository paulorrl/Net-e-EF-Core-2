using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Mapping
{
    public class CourseMap
    {
        public CourseMap(ModelBuilder builder)
        {
            builder.Entity<Course>().ToTable("Course");
        }
    }
}