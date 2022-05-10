using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ExcelServices
{
    class ExcelService
    {
        private void ExportList(DataTable dt)
        {
            string folderPath = @"C:\Download";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Customers");
                wb.Worksheet(1).Cells("A1:C1").Style.Fill.BackgroundColor = XLColor.DarkGreen;
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    string cellRange = string.Format("A{0}:C{0}", i + 1);
                    if (i % 2 != 0)
                        wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = XLColor.GreenYellow;
                    else
                        wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = XLColor.Yellow;
                }
                wb.Worksheet(1).Columns().AdjustToContents();
                wb.SaveAs(folderPath + "DataGridViewExport.xlsx");
            }
        }
    }
}


//https://www.aspsnippets.com/Articles/Export-DataGridView-to-Excel-with-Formatting-using-C-and-VBNet.aspx#:~:text=DataGridView%20cannot%20be%20exported%20directly%20to%20Excel%20file,ClosedXml%20library%20which%20is%20a%20wrapper%20of%20OpenXml.?msclkid=992d5fbdcfc411ec94d3b856cbb63772