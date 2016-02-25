using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Nop.Data.Mapping.Users
{
    public class Auth_RoleMap : EntityTypeConfiguration<Nop.Core.Domain.Auth_Role>
    {
        public Auth_RoleMap() {
            this.ToTable("Auth_Role");
            this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasKey<int>(x => x.ID);
            this.Property(x => x.IsDelete);
            this.Property(x => x.IsSuperRole);
        }
    }
}
