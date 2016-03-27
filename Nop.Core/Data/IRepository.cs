using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Data
{
    public partial interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        void Insert(T entity, bool isSubmit = true);
        void Update(T entity, bool isSubmit = true);
        void Delete(T entity, bool isSubmit = true);

        IQueryable<T> FullTable { get; }
        void Flush();
    }
}
