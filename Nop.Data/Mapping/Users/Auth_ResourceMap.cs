using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
namespace Nop.Data.Mapping.Users
{
    public class Auth_ResourceMap: EntityTypeConfiguration<Nop.Core.Domain.Auth_Resource>
    {
        public Auth_ResourceMap()
        {
            this.ToTable("Auth_Resource");
            this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasKey<int>(x => x.ID);

            this.Property(x => x.IsDelete).IsRequired();
            this.Property(x => x.ResourceCode).IsRequired();
            this.Property(x => x.ResourceUrl);
            this.Property(x => x.OrderIndex);
            this.Property(x => x.ResourceType).IsRequired();
        }
    }
}
