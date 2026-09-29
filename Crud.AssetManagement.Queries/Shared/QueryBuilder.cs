using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Transform;

namespace Crud.AssetManagement.Queries.Shared
{
    // Raw-SQL query builder over NHibernate, same role as the org's QueryBuilder
    // (SetParameter / AppendLineIf / SetConditionalParameter). Runs the SQL through
    // ISession.CreateSQLQuery and maps each row onto T by column alias.
    //
    // Parameters use NHibernate's ":Name" convention.
    public class QueryBuilder
    {
        private readonly StringBuilder _sql;
        private readonly Dictionary<string, object> _parameters = new Dictionary<string, object>();

        public QueryBuilder(string sql)
        {
            _sql = new StringBuilder(sql);
        }

        public string Sql => _sql.ToString();

        public QueryBuilder AppendLine(string sql)
        {
            _sql.AppendLine(sql);
            return this;
        }

        public QueryBuilder AppendLineIf(bool condition, string sql)
        {
            if (condition)
            {
                _sql.AppendLine(sql);
            }

            return this;
        }

        public QueryBuilder SetParameter(string name, object value)
        {
            _parameters[name] = value;
            return this;
        }

        // Only binds the parameter when a value is present. NHibernate throws if a
        // parameter is bound that the SQL does not contain, so this must stay in step
        // with the matching AppendLineIf condition.
        public QueryBuilder SetConditionalParameter(string name, object value)
        {
            var hasValue = value switch
            {
                null => false,
                string s => !string.IsNullOrEmpty(s),
                int i => i > 0,
                _ => true
            };

            if (hasValue)
            {
                _parameters[name] = value;
            }

            return this;
        }

        public async Task<IList<T>> ExecuteListAsync<T>(ISession session)
        {
            return await BuildQuery<T>(session).ListAsync<T>();
        }

        public async Task<T> ExecuteSingleAsync<T>(ISession session)
        {
            var result = await BuildQuery<T>(session).ListAsync<T>();
            return result.FirstOrDefault();
        }

        private IQuery BuildQuery<T>(ISession session)
        {
            var query = session.CreateSQLQuery(Sql)
                .SetResultTransformer(Transformers.AliasToBean<T>());

            foreach (var parameter in _parameters)
            {
                query.SetParameter(parameter.Key, parameter.Value);
            }

            return query;
        }
    }
}
