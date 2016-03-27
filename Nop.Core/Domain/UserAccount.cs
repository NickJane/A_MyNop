using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain
{
    public class UserAccount : Nop.Core.BaseEntity
    {
        /// <summary>
        /// 当前对象所属站点ID
        /// </summary>
        public int SiteID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public bool Active { get; set; }
        public bool IsDelete { get; set; }
        public virtual byte[] Settings { get; set; }

        
        public virtual ICollection<Auth_Role> Auth_Roles { get; set; }

        public virtual UserExt UserExt { get; set; }

        public virtual ICollection<UserAddress> UserAddresses { get; set; }
    }
}
