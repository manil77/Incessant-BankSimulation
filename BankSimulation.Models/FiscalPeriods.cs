using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.Models
{
    public class FiscalPeriods
    {
        [Key]
        public int Id { get; set; }
        public string FiscalYear { get; set; }
        public string FiscalPeriodName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PeriodType { get; set; }
    }
}
