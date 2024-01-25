using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.Models.ViewModel
{
    public class TransactionSummary
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public string Quarter { get; set; }

    }
}
