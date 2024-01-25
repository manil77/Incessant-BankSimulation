using BankSimulation.DataAccess.Data;
using BankSimulation.DataAccess.Repository.IRepository;
using BankSimulation.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext _db;
        internal DbSet<T> _dbSet;   

        public Repository(ApplicationDbContext db)
        {
            _db= db;
            this._dbSet = db.Set<T>(); //Setting particular instance of our class to this.dbSet
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query= _dbSet;
            return query.ToList();
        }

        public T GetByFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _db.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }
    }
}
