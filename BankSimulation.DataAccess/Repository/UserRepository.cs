using BankSimulation.DataAccess.Data;
using BankSimulation.DataAccess.Repository.IRepository;
using BankSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.DataAccess.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _userRepository;

        public UserRepository(ApplicationDbContext db):base(db) 
        {
            _userRepository = db;
        }
        public void Save()
        {
            _userRepository.SaveChanges();
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }
    }
}
