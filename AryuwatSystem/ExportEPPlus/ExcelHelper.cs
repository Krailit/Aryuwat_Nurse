using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;

namespace AryuwatSystem.Forms
{
    public static class ExcelHelper
    {
        public static void ExportToExcel(DataSet ds, string outputFile, string templateFile) {
            try
            {
                Excel2007 excel = new Excel2007();
                //Splite Datatable=======================
                DataSet dssplit = new DataSet();
                int split = 200000;
                List<DataTable> ListT = SplitTable(ds.Tables[0], split);
                foreach (var dataTable in ListT)
                {
                    dssplit.Tables.Add(dataTable);
                }

                byte[] excelBinary = null;

                if (templateFile.Length > 0 && File.Exists(templateFile))
                {
                    excelBinary = excel.ExportWithTemplate(dssplit, templateFile);
                }
                else
                {
                    excelBinary = excel.Export(dssplit);
                }

                File.WriteAllBytes(outputFile, excelBinary);
                if (File.Exists(outputFile))
                {
                    Process.Start(outputFile);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<DataTable> SplitTable(DataTable originalTable, int batchSize)
        {
            List<DataTable> tables = new List<DataTable>();
            List<DataRow> list = originalTable.AsEnumerable().ToList();
            int i = 0;
            int j = 0;
            int sheet = 1;
            DataTable batchTable = new DataTable();
            foreach (var row in list)
            {
                if (i == 0)
                {
                    batchTable = new DataTable(originalTable.TableName + "(" + sheet + ")");
                    foreach (DataColumn column in originalTable.Columns)
                        batchTable.Columns.Add(column.ColumnName);
                }
                batchTable.ImportRow(row);
                i++;
                j++;

                if (i == batchSize || j >= list.Count)
                {
                    tables.Add(batchTable);
                    i = 0;
                    sheet++;
                }
            }

            return tables;
        }
    }
}
