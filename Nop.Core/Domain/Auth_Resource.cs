using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain
{
    public class Auth_Resource:BaseEntity
    {
        public string ResourceCode { get; set; }
        public bool IsDelete { get; set; }
        public string ResourceUrl { get; set; }

        public int ResourceType { get; set; }

        public int OrderIndex { get; set; }

        public virtual ICollection<Auth_Role> Auth_Roles { get; set; }
    }
}
