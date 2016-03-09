using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext _context;
        private DbContextTransaction _transacton;
        private TransactionStatus _transactionStatus;

        public UnitOfWork() { }

        public UnitOfWork(IDbContext context)
        {
            _context = context;
            // _transacton = _context.Database.BeginTransaction();
            _transactionStatus = TransactionStatus.UnActive;
        }
        public void BeginTransaction()
        {
            if (!HasTransactionOpen())
            {
                _transacton = _context.Database.BeginTransaction();
                _transactionStatus = TransactionStatus.IsActive;
            }
        }
        public TransactionStatus TransactionStatus
        {
            get { return _transactionStatus; }
        }
        public IDbContext Context
        {
            get { return _context; }
        }

        public DbContextTransaction Transacton
        {
            get { return _transacton; }
        }
        private bool HasTransactionOpen()
        {
            if (Transacton != null && TransactionStatus != TransactionStatus.WasCommited && TransactionStatus != TransactionStatus.WasRolledBack && TransactionStatus != TransactionStatus.UnActive)
            {
                return true;
            }
            return false;
        }
        public void Flush()
        {
            if (Context != null)
            {
                Context.SaveChanges();
            }
        }
        public void Commit()
        {

            try
            {
                if (Context != null)
                {
                    //Context.SaveChanges();
                    if (HasTransactionOpen())
                    {
                        Transacton.Commit();
                        Transacton.Dispose();
                        _transactionStatus = TransactionStatus.WasCommited;
                    }

                }

            }
            catch (Exception e)
            {
                RollBack();
                throw e;
            }
        }
        public void RollBack()
        {
            if (HasTransactionOpen())
            {
                Transacton.Rollback();
                Transacton.Dispose();
                _transactionStatus = TransactionStatus.WasRolledBack;
            }
        }
        public void Dispose()
        {
            if (Context != null)
            {
                if (Transacton != null)
                {
                    Transacton.Dispose();
                }
                _transacton = null;
                _context.Dispose();
                _context = null;
            }
        }
    }

    public enum TransactionStatus
    {
        UnActive,
        IsActive,
        WasCommited,
        WasRolledBack
    }
}
