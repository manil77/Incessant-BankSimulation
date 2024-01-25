using BankSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.DataAccess.Repository.IRepository
{
    public interface IUserRepository:IRepository<User>
    {
        void Update(User user);
        void Save();
    }
}
