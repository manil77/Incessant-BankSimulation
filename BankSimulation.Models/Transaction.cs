using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BankSimulation.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TransactionType { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        public DateTime TransactedDate { get; set; }
    }
}
