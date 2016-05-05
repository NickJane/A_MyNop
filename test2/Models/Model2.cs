using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace test2.Models
{
    public class User
    {
        public int Id { get; set; }
        public int SiteID { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
    public class Role
    {
        public int Id { get; set; }
        public int SiteID { get; set; }

        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }

    public class UrDbContext : DbContext
    {
        public UrDbContext()
            : base("name=DefaultConnection")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Configurations
                .Add(new UserConfiguration())
                .Add(new RoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public class UserConfiguration : EntityTypeConfiguration<User>
        {
            public UserConfiguration()
            {
                HasKey(c => new { c.Id,c.SiteID });
                Property(c => c.Id)
                    .IsRequired()
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                HasMany(t => t.Roles)
                    .WithMany(t => t.Users)
                    .Map(m =>
                    {
                        m.ToTable("UserRole");
                        m.MapLeftKey("UserId");
                        m.MapRightKey("RoleId");
                    });
            }
        }
        public class RoleConfiguration : EntityTypeConfiguration<Role>
        {
            public RoleConfiguration()
            {
                HasKey(c => new { c.Id, c.SiteID });
                Property(c => c.Id)
                    .IsRequired()
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            }
        }
    }
    public class UserRoleDbContext2 : DbContext
    {
        public UserRoleDbContext2()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer<UserRoleDbContext2>(null);
            //this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Configurations
                .Add(new UserConfiguration())
                .Add(new RoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public class UserConfiguration : EntityTypeConfiguration<User>
        {
            public UserConfiguration()
            {
                HasKey(c => c.Id);
                Property(c => c.Id)
                    .IsRequired()
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                HasMany(t => t.Roles)
                    .WithMany(t => t.Users)
                    .Map(m =>
                    {
                        m.ToTable("UserRole2");
                        m.MapLeftKey("UserId");
                        m.MapRightKey("RoleId");
                    });
            }
        }
        public class RoleConfiguration : EntityTypeConfiguration<Role>
        {
            public RoleConfiguration()
            {
                HasKey(c => c.Id);
                Property(c => c.Id)
                    .IsRequired()
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            }
        }
    }
}