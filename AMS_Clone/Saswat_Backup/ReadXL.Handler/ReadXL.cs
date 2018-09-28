 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Tracking.Entities;
using System.ComponentModel;

namespace ReadXL.Handler
{
    public class ReadXL
    {
        private static Excel.Workbook MyBook = null;
        private static Excel.Application MyApp = null;
        private static Excel.Worksheet MySheet = null;

        /// <summary>
        /// Initializing the excel File
        /// </summary>
        /// <param name="db_path"></param>
        public BindingList<GlcSwipe> ExcelToDb(string db_path)
        {
            MyApp = new Excel.Application();
            MyApp.Visible = false;
            MyBook = MyApp.Workbooks.Open(db_path);
            MySheet = (Excel.Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here
            var lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
            BindingList<GlcSwipe> glcList = new BindingList<GlcSwipe>();
            for(int i = 2; i <= lastRow; i++)
            {

                System.Array MyValues = (System.Array)MySheet.get_Range("A" +
                   i.ToString(), "D" + i.ToString()).Cells.Value;
                if (MyValues.GetValue(1, 1).ToString().Contains("TRIPOD") || MyValues.GetValue(1, 1).ToString().Contains("HANDICAP FLAP BARRIER") || MyValues.GetValue(1, 1).ToString().Contains("BASEMENT") || MyValues.GetValue(1, 1).ToString().Contains("OPPOSITE BASEMENT"))
                {
                    glcList.Add(new GlcSwipe
                    {
                        Location = MyValues.GetValue(1, 1).ToString(),
                        Mid = MyValues.GetValue(1, 2).ToString(),
                        Datetime = DateTime.Parse(MyValues.GetValue(1, 4).ToString())
                    });
                }
            }
            return glcList;
        }
    }
}
