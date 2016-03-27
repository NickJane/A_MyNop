using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using System.ComponentModel.DataAnnotations.Schema;
using Nop.Core.Domain;
namespace Nop.Data.Mapping.Users
{ 
    public class UserAccountMap : EntityTypeConfiguration<Nop.Core.Domain.UserAccount>
    {
        public UserAccountMap()
        {
            this.ToTable("UserAccount");
            this.Property(c => c.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasKey(p => p.ID);

            this.Property(p => p.UserName).HasMaxLength(20).IsRequired();
            this.Property(p => p.Password).HasMaxLength(64).IsRequired();
            this.Property(p => p.CreateTime);
            this.Property(p=>p.LastLoginTime);
            this.Property(p => p.Active);
            this.Property(p => p.IsDelete);
            this.Property(p => p.Settings);
            this.Ignore(x => x.AllSettings);

            this.HasMany<Auth_Role>(x => x.Auth_Roles)
                .WithMany(x => x.UserAcconts)
                .Map(r =>
                { 
                    r.ToTable("Auth_User_Role");
                    r.MapLeftKey("UserID");
                    r.MapRightKey("RoleID");
                });


        }


    }
}
