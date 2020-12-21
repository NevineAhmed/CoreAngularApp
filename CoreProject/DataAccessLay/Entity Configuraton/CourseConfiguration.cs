using BuisinessLay;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLay.Entity_Configuraton
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> modelBuilder)
        {
            
            modelBuilder.HasKey(c=>c.courseId);
            modelBuilder.HasOne(c => c.author).WithMany(a => a.Courses).IsRequired()
               .HasForeignKey(c => c.authorId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.HasMany(t => t.Tags).WithMany(c => c.Courses)
                .UsingEntity(m =>
                {
                    m.ToTable("CourseTags");
                });

            modelBuilder.Property(t => t.Description)
              .IsRequired();

            //modelBuilder.HasData(
            //    new Author
            //    {
            //        authorId = 1,
            //        author_name = "Nevine",
            //        Courses=new List<Course>() { new Course { courseId=1 } }
            //    }
            //);

            modelBuilder.HasData(
               new Course { title = "courseforauth1", Description = "description", DatePublished = DateTime.UtcNow, courseId = 1, authorId = 1 }
           );
        }
    }
}
