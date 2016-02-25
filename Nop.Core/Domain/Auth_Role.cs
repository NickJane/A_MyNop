using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain
{
    public class Auth_Role : Nop.Core.BaseEntity
    {
        public bool Active { get; set; }
        public bool IsDelete { get; set; }
        public bool IsSuperRole { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserAccount> UserAcconts { get; set; }

        public virtual ICollection<Auth_Resource> Auth_Resources { get; set; }
    }
}
