using BankSimulation.DataAccess.Data;
using BankSimulation.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _db;
        public IUserRepository User { get; private set; }

        public ITransactionRepository Transaction { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            User = new UserRepository(_db);
            Transaction = new TransactionRepository(_db);
        }

        public void Save()
        {
         _db.SaveChanges();
        }
    }
}
