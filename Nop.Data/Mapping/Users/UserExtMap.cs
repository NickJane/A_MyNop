using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data.Mapping.Users
{
    public class UserExtMap : EntityTypeConfiguration<Nop.Core.Domain.UserExt>
    {
        public UserExtMap()
        {
            this.ToTable("UserExt");
            this.HasKey(p => p.UserID);

            this.Property(p => p.ExtInfo);
            //忽略某个列
            this.Ignore(x => x.ID);

            //UserExtMap依赖于UserAccount, 而且是不能独立于UserAccount存在的, 因此用hasRequire+WithOptional来处理
            //推荐这种写法
            this.HasRequired(x => x.UserAccount).WithOptional(x => x.UserExt);
        }


    }
}
