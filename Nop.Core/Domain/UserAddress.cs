using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain
{
    public class UserAddress : BaseEntity
    {
        public int UserID { get; set; }
        public string AddressInfo { get; set; }

        public virtual UserAccount UserAccout { get; set; }
    }
}
