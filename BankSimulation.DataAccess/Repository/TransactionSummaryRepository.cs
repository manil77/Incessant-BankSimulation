using BankSimulation.DataAccess.Data;
using BankSimulation.DataAccess.Repository.IRepository;
using BankSimulation.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.DataAccess.Repository
{
    public class TransactionSummaryRepository : Repository<TransactionSummary>/*, ITransactionSummaryRepository*/
    {
        private readonly ApplicationDbContext _transactionSummaryRepository;
        private readonly UnitOfWork _unitOfWork;
        public TransactionSummaryRepository(ApplicationDbContext db) : base(db)
        {
            _transactionSummaryRepository = db;
        }
        /*public List<TransactionSummary> GetTransactionSummary()
        {
            return _unitOfWork._db.Database.ExecuteSqlRaw("GetTransactionSummary");
        }*/
    }
}
