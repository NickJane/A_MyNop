using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace test2.Models
{
    public class Student
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        
        public int SiteID { get; set; }

        public virtual ICollection<Course> Courses{get;set;}
    }

    public class Course{
        public int ID{get;set;}
        public string Name { get; set; }
        
        public int SiteID { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
    public class SCContext : DbContext
    {
        public SCContext()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer<SCContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //dynamically load all configuration
            //System.Type configType = typeof(LanguageMap);   //any of your configuration classes here
            //var typesToRegister = Assembly.GetAssembly(configType).GetTypes()
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Student>().ToTable("Student").HasKey(x => new { x.ID, x.SiteID })
                .Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Course>().ToTable("Course").HasKey(x => new { x.ID, x.SiteID })
                .Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //modelBuilder.Entity<Course>().Property(x => x.Name);

            modelBuilder.Entity<Student>().HasMany<Course>(x => x.Courses)
                .WithMany(x => x.Students)
                .Map(r =>
                {
                    r.ToTable("Student_Course_Mapping");
                    r.MapLeftKey(new string[]{"StudentID", "StudentSiteID"});
                    r.MapRightKey(new string[] { "CourseID", "CourseSiteID" });
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}