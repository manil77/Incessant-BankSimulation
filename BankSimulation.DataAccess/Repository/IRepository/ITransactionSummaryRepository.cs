using BankSimulation.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.DataAccess.Repository.IRepository
{
    public interface ITransactionSummaryRepository
    {
        List<TransactionSummary> GetTransactionSummary();
    }
}
