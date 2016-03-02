using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContext Context { get; }
        DbContextTransaction Transacton { get; }
        void BeginTransaction();
        void Flush();
        void Commit();
        void RollBack();
    }
}
