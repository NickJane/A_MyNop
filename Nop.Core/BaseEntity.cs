using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Nop.Core
{
    
    [Serializable]
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 分页帮助类
        /// </summary>
        [NotMapped]
        public EntityPager EntityPager { get; set; }
        
    }
    [NotMapped]
    public class EntityPager {
        [NotMapped]
        public int PCurrentPageIndex { get; set; }
        [NotMapped]
        public int PPageSize { get; set; }
        [NotMapped]
        public int PRecordCount { get; set; }
        [NotMapped]
        public string POrderField { get; set; }
        [NotMapped]
        public bool PIsAsc { get; set; }
    }
}
