using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Nop.Data.Mapping.Users
{
    public class UserAddressMap: EntityTypeConfiguration<Nop.Core.Domain.UserAddress>
    {
        public UserAddressMap()
        {
            this.ToTable("UserAddress");
            this.HasKey(p => p.ID);
            this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.AddressInfo);

            //用户和地址, 1:n, 用户有很多
            //UserAccout类包含多个（HasMany）UserAddress类实例的集合，
            //Lodging类包含前者一个不为null（WithRequired）的实例。.
            //那么直接把WithRequired换成WithOptional即可。
            this.HasRequired<Nop.Core.Domain.UserAccount>(s => s.UserAccout)
                    .WithMany(s => s.UserAddresses)
                    .HasForeignKey(s => s.UserID);
        }


    }
}
