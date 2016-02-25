using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nop.Core
{
    [Serializable]
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int ID { get; set; }

        


    }
}
