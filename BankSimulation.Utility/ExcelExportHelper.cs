using BankSimulation.Models.ViewModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankSimulation.Utility
{
    public class ExcelExportHelper
    {
        public static byte[] GenerateExcel(List<TransactionSummary> data)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Add headers
                worksheet.Cells["A1"].Value = "Name";
                worksheet.Cells["B1"].Value = "Amount";
                worksheet.Cells["C1"].Value = "Quarter";
                worksheet.Cells["D1"].Value = "TransactionType";

                // Add data
                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = data[i].Name;
                    worksheet.Cells[i + 2, 2].Value = data[i].Amount;
                    worksheet.Cells[i + 2, 3].Value = data[i].Quarter;
                    worksheet.Cells[i + 2, 4].Value = data[i].TransactionType;
                    // Add other properties as needed
                }

                return package.GetAsByteArray();
            }
        }
    }
}
