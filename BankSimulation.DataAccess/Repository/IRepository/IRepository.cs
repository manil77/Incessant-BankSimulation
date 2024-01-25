using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetByFirstOrDefault(Expression<Func<T, bool>> filter); //LINQ queries on Data Source

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);

        
    }
}
