using System.Threading.Tasks;
using NHibernate;
using Crud.AssetManagement.Infrastructure.Contracts;

namespace Crud.AssetManagement.Infrastructure.Utils
{
    // Opens a transaction on the scoped session when created; FlushAsync commits it.
    // If FlushAsync is never called, disposing the session at the end of the scope
    // rolls the transaction back.
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        protected UnitOfWork(ISession session)
        {
            _session = session;
            _transaction = session.BeginTransaction();
        }

        public virtual async Task FlushAsync()
        {
            await _session.FlushAsync();
            await _transaction.CommitAsync();

            // Keep the unit of work usable if a handler flushes more than once.
            _transaction.Dispose();
            _transaction = _session.BeginTransaction();
        }
    }
}
