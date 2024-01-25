using BankSimulation.DataAccess.Repository;
using BankSimulation.DataAccess.Repository.IRepository;
using BankSimulation.Models;
using BankSimulation.Models.ViewModel;
using BankSimulation.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace BankSimulation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {

            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _unitOfWork.User.GetByFirstOrDefault(x => x.Id == userId);
            ViewBag.CurrentBalance = result.CurrentBalance;

            
            var quarterlyDetail = _unitOfWork.Transaction.GetTransactionSummary().Where(x=>x.Id == userId);
            
            return View(quarterlyDetail);
        }

        public IActionResult ExcelExport()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var quarterlyDetail = _unitOfWork.Transaction.GetTransactionSummary().Where(x => x.Id == userId).ToList();
            byte[] data = ExcelExportHelper.GenerateExcel(quarterlyDetail);

            return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Transaction Summaries.xlsx");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}