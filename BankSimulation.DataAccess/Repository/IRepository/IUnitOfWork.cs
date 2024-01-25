using BankSimulation.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        ITransactionRepository Transaction { get; }

        void Save();
    }
}
