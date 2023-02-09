using GradingModule.Models;
using Microsoft.EntityFrameworkCore;

namespace GradingModule.Data
{
    public class GradingModuleContext : DbContext
    {
        public GradingModuleContext(DbContextOptions<GradingModuleContext> opt) : base(opt)
        {
            
        }
        public DbSet<Course> courses { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Registeration> registerations { get; set; }
        public DbSet<TeacherCourse> teacherCourses { get; set; }
        public DbSet<Category> Categories{get; set;}
        public DbSet<Marks> marks { get; set; }
    
    // Declare Composite Keys
     protected override void OnModelCreating(ModelBuilder builder)
     {
         builder.Entity<Registeration>().HasKey(table => new {
         table.stud_id, table.course_id
         });

         builder.Entity<TeacherCourse>().HasKey(table => new {
         table.teacher_id, table.course_id,table.section
         });

         builder.Entity<Marks>().HasKey(table => new {
         table.stud_id, table.course_id
         });

        builder.Entity<Category>().HasKey(table => new {
         table.stud_id, table.course_id,table.CategoryName,table.CategoryNameSequence
         });
     }

    }


}