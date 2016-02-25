using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain
{
    /// <summary>
    /// 用户扩展类, 主要用来练习ef的一对一
    /// </summary>
    public class UserExt:BaseEntity
    {
        public int UserID { get; set; }

        public string ExtInfo { get; set; }

        /// <summary>
        /// 一对一的标志
        /// </summary>
        public virtual UserAccount UserAccount { get; set; }
    }
}
