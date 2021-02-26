using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace AryuwatSystem.Forms
{
    /// <summary>
    /// Summary description for Excel2007
    /// </summary>
    public class Excel2007
    {
        public Excel2007()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public byte[] Export(DataSet DsData)
        {
            int i = 1;
            ExcelPackage xlApp = new ExcelPackage();

            foreach (DataTable DtData in DsData.Tables)
            {
                AddSheet(xlApp, DtData, i);
                i++;
            }

            return xlApp.GetAsByteArray();
        }

        public byte[] ExportWithTemplate(DataSet DsData, string templateFile)
        {
            int i = 1;
            ExcelPackage xlApp = new ExcelPackage(new System.IO.FileInfo(templateFile), false);

            foreach (DataTable DtData in DsData.Tables)
            {
                //AddSheet(xlApp, DtData, i);
                ExcelWorksheet xlSheet = xlApp.Workbook.Worksheets.Where(o => o.Name == DtData.TableName).FirstOrDefault();

                if (xlSheet != null)
                {
                    FillData(xlSheet, DtData);
                }
                else
                {
                    AddSheet(xlApp, DtData, i);
                }

                i++;
            }

            return xlApp.GetAsByteArray();
        }

        public byte[] Export(DataTable DtData)
        {
            ExcelPackage xlApp = new ExcelPackage();

            AddSheet(xlApp, DtData);

            return xlApp.GetAsByteArray();
        }

        public byte[] Export(DataSet DsData, string TableName)
        {
            return Export(DsData.Tables[TableName]);
        }

        protected void AddSheet(ExcelPackage xlApp, DataTable DtData)
        {
            AddSheet(xlApp, DtData, 1);
        }

        protected void AddSheet(ExcelPackage xlApp, DataTable DtData, int Index)
        {
            ExcelWorksheet xlSheet = xlApp.Workbook.Worksheets.Add((DtData.TableName != string.Empty) ? DtData.TableName : string.Format("Sheet{0}", Index.ToString()));
            xlSheet.Cells["A1"].LoadFromDataTable(DtData, true);

            int rowCount = DtData.Rows.Count;
            IEnumerable<int> dateColumns = from DataColumn d in DtData.Columns
                                           where d.DataType == typeof(DateTime) || d.ColumnName.Contains("Date")
                                           select d.Ordinal + 1;

            foreach (int dc in dateColumns)
            {
                xlSheet.Cells[2, dc, rowCount + 1, dc].Style.Numberformat.Format = "dd/MM/yyyy";
            }

            IEnumerable<int> numColumns = from DataColumn d in DtData.Columns
                                           where d.DataType == typeof(Decimal) || d.ColumnName.Contains("Price")
                                           select d.Ordinal + 1;

            foreach (int dc in numColumns)
            {
                xlSheet.Cells[2, dc, rowCount + 1, dc].Style.Numberformat.Format = "###,###,###.##";
            }


            (from DataColumn d in DtData.Columns select d.Ordinal + 1).ToList().ForEach(dc =>
            {
                //background color
                xlSheet.Cells[1, 1, 1, dc].Style.Fill.PatternType = ExcelFillStyle.Solid;
                xlSheet.Cells[1, 1, 1, dc].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.SlateGray);

                //border
                xlSheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                xlSheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                xlSheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                xlSheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                xlSheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Top.Color.SetColor(System.Drawing.Color.LightGray);
                xlSheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Right.Color.SetColor(System.Drawing.Color.LightGray);
                xlSheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.LightGray);
                xlSheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Left.Color.SetColor(System.Drawing.Color.LightGray);
            });
        }

        protected void FillData(ExcelWorksheet xlSheet, DataTable DtData)
        {
            xlSheet.Cells["A1"].LoadFromDataTable(DtData, true);

            int rowCount = DtData.Rows.Count;
            IEnumerable<int> dateColumns = from DataColumn d in DtData.Columns
                                           where d.DataType == typeof(DateTime) || d.ColumnName.Contains("Date")
                                           select d.Ordinal + 1;

            foreach (int dc in dateColumns)
            {
                xlSheet.Cells[2, dc, rowCount + 1, dc].Style.Numberformat.Format = "dd/MM/yyyy";
            }

            (from DataColumn d in DtData.Columns select d.Ordinal + 1).ToList().ForEach(dc =>
            {
                //background color
                xlSheet.Cells[1, 1, 1, dc].Style.Fill.PatternType = ExcelFillStyle.Solid;
                xlSheet.Cells[1, 1, 1, dc].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.SlateGray);

                //border
                xlSheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                xlSheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                xlSheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                xlSheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                xlSheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Top.Color.SetColor(System.Drawing.Color.LightGray);
                xlSheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Right.Color.SetColor(System.Drawing.Color.LightGray);
                xlSheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.LightGray);
                xlSheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Left.Color.SetColor(System.Drawing.Color.LightGray);
            });
        }
    }

}
