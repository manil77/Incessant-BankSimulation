using BankSimulation.DataAccess.Repository;
using BankSimulation.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Transactions;
using BankSimulation.Models;
using Transaction = BankSimulation.Models.Transaction;
using BankSimulation.Utility;

namespace BankSimulation.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private Models.Transaction Transaction;
        public TransactionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Transact(string transactionType, int amount)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var result = _unitOfWork.User.GetByFirstOrDefault(x => x.Id == userId);

                if (transactionType == "deposit")
                {
                    TempData["success"] = "The amount has been deposited.";
                    result.CurrentBalance += amount;
                }
                else if (transactionType == "withdraw")
                {
                    if(amount> result.CurrentBalance)
                    {
                        TempData["error"]= "The amount exceeds the current balance."; //For Toastr

                        return RedirectToAction("Index");
                    }
                    TempData["success"] = "The amount has been withdrawn."; //For Toastr
                    result.CurrentBalance -= amount;
                }

                Transaction transaction = new Transaction();
                transaction.TransactionType = transactionType;
                transaction.UserId = result.Id;
                transaction.Amount = amount;
                transaction.TransactedDate = DateTime.Now;


                _unitOfWork.User.Update(result);

                _unitOfWork.Transaction.Add(transaction);
                _unitOfWork.Transaction.Save();

                _unitOfWork.User.Save();

                //Email Sender
                var transactionTypeMsg = transaction.TransactionType == "deposit" ? "Deposited" : "Withdrawn";
                var message = $"Rs. {transaction.Amount}  has been  {transactionTypeMsg}";
                 EmailSender.SendEmail(result.Email, message);
                return RedirectToAction("Index","Home");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}
