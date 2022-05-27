using OfficeOpenXml;
using System.IO;

namespace AnhTesterHRM_xUnit.Utils
{
    public class ExcelReader
    {
        public string filePath;
        public string sheetName;
        public int rows;
        public int columns;
        public ExcelWorksheet worksheet;
        public ExcelPackage package;

        public ExcelReader(string filePath, string sheetName)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            package = new ExcelPackage(fileInfo);
            worksheet = package.Workbook.Worksheets[sheetName];
        }

        public string GetCellData(int colNumber)
        {
            columns = worksheet.Dimension.End.Column;
            string content = null;
            for (int i = 1; i <= columns; i++)
            {
                content = worksheet.Cells[i, colNumber].Value.ToString();
            }
            return content;
        }
    }
}
