using BankSimulation.Models;
using BankSimulation.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.DataAccess.Repository.IRepository
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        void Update(Transaction transaction);
        void Save();

        IEnumerable<TransactionSummary> GetTransactionSummary();
    }
}
