using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;

namespace Crud.AssetManagement.Infrastructure.Utils
{
    // NHibernate-backed base repository. Changes are written to the database when the
    // owning unit of work calls FlushAsync.
    public abstract class BaseRepository<TModel> where TModel : class
    {
        protected ISession Session { get; }

        protected BaseRepository(ISession session)
        {
            Session = session;
        }

        protected virtual async Task AddAsync(TModel model)
        {
            await Session.SaveAsync(model);
        }

        protected virtual async Task<TModel> FindByIdAsync(int id)
        {
            return await Session.GetAsync<TModel>(id);
        }

        protected virtual async Task<TModel> FindAsync(Specification<TModel> specification)
        {
            return await Session.Query<TModel>()
                .Where(specification.ToExpression())
                .SingleOrDefaultAsync();
        }

        protected virtual async Task<IList<TModel>> FindListAsync(IQueryable<TModel> query, int perPage, int page)
        {
            return await query
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToListAsync();
        }

        protected virtual async Task SaveChangesAsync()
        {
            await Session.FlushAsync();
        }
    }
}
