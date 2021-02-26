using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace AryuwatSystem.DerClass
{
    class PivotTable2
    {
        private DataTable _SourceTable = new DataTable();
        private IEnumerable<DataRow> _Source = new List<DataRow>();
       public Dictionary<string, bool> dicColumn = new Dictionary<string, bool>();
        public PivotTable2(DataTable SourceTable)
        {
            _SourceTable = SourceTable;
            _Source = SourceTable.Rows.Cast<DataRow>();
        }

        /// <summary>
        /// Pivots the DataTable based on provided RowField, DataField, Aggregate Function and ColumnFields.//
        /// </summary>
        /// <param name="rowField">The column name of the Source Table which you want to spread into rows</param>
        /// <param name="dataField">The column name of the Source Table which you want to spread into Data Part</param>
        /// <param name="aggregate">The Aggregate function which you want to apply in case matching data found more than once</param>
        /// <param name="columnFields">The List of column names which you want to spread as columns</param>
        /// <returns>A DataTable containing the Pivoted Data</returns>
        public DataTable PivotData(string rowField, string dataField, AggregateFunction aggregate, params string[] columnFields)
        {
            DataTable dt = new DataTable();
            string Separator = ".";
            List<string> rowList = _Source.Select(x => x[rowField].ToString()).Distinct().ToList();
     
            // Gets the list of columns .(dot) separated.
            var colList = _Source.Select(x => (columnFields.Select(n => x[n]).Aggregate((a, b) => a += Separator + b.ToString())).ToString()).Distinct().OrderBy(m => m);

            dt.Columns.Add(rowField);
            dicColumn.Add(rowField, false);
            foreach (var colName in colList)
            {
                if(colName=="")
                    dt.Columns.Add("Empty");  // Cretes the result columns.//
                else dt.Columns.Add(colName);  // Cretes the result columns.//
               
            }
         
            foreach (string rowName in rowList)
            {
                DataRow row = dt.NewRow();
                row[rowField] = rowName;
                foreach (string colName in colList)
                {
                    if (!dicColumn.ContainsKey(colName))
                    {
                        if (colName == "")
                        {
                            if (!dicColumn.ContainsKey("Empty"))
                                dicColumn.Add("Empty", false);
                        }
                        else
                            dicColumn.Add(colName, false);
                    }
                    string strFilter = rowField + " = '" + rowName + "'";
                    string[] strColValues = colName.Split(Separator.ToCharArray(), StringSplitOptions.None);
                    for (int i = 0; i < columnFields.Length; i++)
                    {
                        if (strColValues[i] + "" == "") continue;
                        strFilter += " and " + columnFields[i] + " = '" + strColValues[i] + "'";
                        object xx = GetData(strFilter, dataField, aggregate);
                        if (IsNumeric(xx + ""))
                        {
                            row[colName] =  Convert.ToDecimal(xx).ToString("###,###,###");
                            dicColumn[colName] = true;
                        }
                        else
                        {
                            row[colName] = xx;
                            //dicColumn[colName] = false;
                        }
                    }
                }
                dt.Rows.Add(row);
            }
                //=================Sum Row========================
                    DataRow rowSum = dt.NewRow();
                    decimal sum = 0;
            
                    for (int c = 1; c < dt.Columns.Count; c++)
                    {
                        for (int r = 0; r < dt.Rows.Count; r++)
                        {
                           if( dt.Rows[r][c]+""=="")continue;
                         sum +=Convert.ToDecimal( dt.Rows[r][c] + "");
                        }
                        rowSum[0] = "Total";
                        rowSum[c] = sum.ToString("###,###,###");
                        sum = 0;
                     }
                    dt.Rows.Add(rowSum);
               //=================Sum Row========================
               //=================Sum Column========================
                    dt.Columns.Add("Total", typeof(String));        
                     sum = 0;
                  
                        for (int r = 0; r < dt.Rows.Count; r++)
                        {
                            for (int c = 1; c < dt.Columns.Count; c++)
                            {
                                if (dt.Rows[r][c] + "" == "") continue;
                                sum += Convert.ToDecimal(dt.Rows[r][c] + "");
                            }
                            dt.Rows[r]["Total"] = sum.ToString("###,###,###");
                            sum = 0;
                     }
                    //dt.Rows.Add(rowSum);
                    //=================Sum Column========================
            //DataRow totalsRow = dt.NewRow();
            //foreach (DataColumn col in dt.Columns)
            //{
            //    int colTotal = 0;
               
            //    foreach (DataRow row in col.Table.Rows)
            //    {
            //        if (colTotal == 0) continue;
            //        colTotal += Int32.Parse(row[col].ToString());
            //    }
            //    totalsRow[col.ColumnName] = colTotal;
            //}
            //dt.Rows.Add(totalsRow);
            //DataTable dtCloned = new DataTable();
            //foreach (DataColumn  item in dt.Columns)
            //{
            //    if(dicColumn[item.ColumnName])
            //        dtCloned.Columns.Add(item.ColumnName, typeof(Int32));
            //    else dtCloned.Columns.Add(item.ColumnName, typeof(String)); 
            //}
           
            //foreach (DataRow row in dt.Rows)
            //{
            //    foreach (string colName in colList)
            //    { 
            //        dtCloned.Rows[][colName]=
            //    }
            //    dtCloned.ImportRow(row);
            //}

         

            return dt;
        }
        public bool IsNumeric(string s)
        {
            float output;
            return float.TryParse(s, out output);
        }
        public DataTable PivotData(string rowField, string dataField, AggregateFunction aggregate, bool showSubTotal, params string[] columnFields)
        {
            DataTable dt = new DataTable();
            string Separator = ".";
            List<string> rowList = _Source.Select(x => x[rowField].ToString()).Distinct().ToList();
            // Gets the list of columns .(dot) separated.
            List<string> colList = _Source.Select(x => columnFields.Aggregate((a, b) => x[a].ToString() + Separator + x[b].ToString())).Distinct().OrderBy(m => m).ToList();

            if (showSubTotal && columnFields.Length > 1)
            {
                string totalField = string.Empty;
                for (int i = 0; i < columnFields.Length - 1; i++)
                    totalField += columnFields[i] + "(Total)" + Separator;
                List<string> totalList = _Source.Select(x => totalField + x[columnFields.Last()].ToString()).Distinct().OrderBy(m => m).ToList();
                colList.InsertRange(0, totalList);
            }

            dt.Columns.Add(rowField);
            colList.ForEach(x => dt.Columns.Add(x));

            foreach (string rowName in rowList)
            {
                DataRow row = dt.NewRow();
                row[rowField] = rowName;
                foreach (string colName in colList)
                {
                    string filter = rowField + " = '" + rowName + "'";
                    string[] colValues = colName.Split(Separator.ToCharArray(), StringSplitOptions.None);
                    for (int i = 0; i < columnFields.Length; i++)
                        if (!colValues[i].Contains("(Total)"))
                            filter += " and " + columnFields[i] + " = '" + colValues[i] + "'";
                    row[colName] = GetData(filter, dataField, colName.Contains("(Total)") ? AggregateFunction.Sum : aggregate);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable PivotData(string DataField, AggregateFunction Aggregate, string[] RowFields, string[] ColumnFields)
        {
            DataTable dt = new DataTable();
            string Separator = ".";
            var RowList = _SourceTable.DefaultView.ToTable(true, RowFields).AsEnumerable().ToList();
            for (int index = RowFields.Count() - 1; index >= 0; index--)
                RowList = RowList.OrderBy(x => x.Field<object>(RowFields[index])).ToList();
            // Gets the list of columns .(dot) separated.
            var ColList = (from x in _SourceTable.AsEnumerable()
                           select new
                           {
                               Name = ColumnFields.Select(n => x.Field<object>(n))
                                   .Aggregate((a, b) => a += Separator + b.ToString())
                           })
                               .Distinct()
                               .OrderBy(m => m.Name);

            //dt.Columns.Add(RowFields);
            foreach (string s in RowFields)
                dt.Columns.Add(s);

            foreach (var col in ColList)
                dt.Columns.Add(col.Name.ToString(), System.Type.GetType("System.Decimal"));  // Cretes the result columns.//

            foreach (var RowName in RowList)
            {
                DataRow row = dt.NewRow();
                string strFilter = string.Empty;

                foreach (string Field in RowFields)
                {
                    row[Field] = RowName[Field];
                    strFilter += " and " + Field + " = '" + RowName[Field].ToString() + "'";
                }
                strFilter = strFilter.Substring(5);

                foreach (var col in ColList)
                {
                    string filter = strFilter;
                    string[] strColValues = col.Name.ToString().Split(Separator.ToCharArray(), StringSplitOptions.None);
                    for (int i = 0; i < ColumnFields.Length; i++)
                        filter += " and " + ColumnFields[i] + " = '" + strColValues[i] + "'";
                    row[col.Name.ToString()] = GetData(filter, DataField, Aggregate);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// Retrives the data for matching RowField value and ColumnFields values with Aggregate function applied on them.
        /// </summary>
        /// <param name="Filter">DataTable Filter condition as a string</param>
        /// <param name="DataField">The column name which needs to spread out in Data Part of the Pivoted table</param>
        /// <param name="Aggregate">Enumeration to determine which function to apply to aggregate the data</param>
        /// <returns></returns>
        private object GetData(string Filter, string DataField, AggregateFunction Aggregate)
        {
            try
            {
                DataRow[] FilteredRows = _SourceTable.Select(Filter);
                object[] objList = FilteredRows.Select(x => x.Field<object>(DataField)).ToArray();

                switch (Aggregate)
                {
                    case AggregateFunction.Average:
                        return GetAverage(objList);
                    case AggregateFunction.Count:
                        return objList.Count();
                    case AggregateFunction.Exists:
                        return (objList.Count() == 0) ? "False" : "True";
                    case AggregateFunction.First:
                        return GetFirst(objList);
                    case AggregateFunction.Last:
                        return GetLast(objList);
                    case AggregateFunction.Max:
                        return GetMax(objList);
                    case AggregateFunction.Min:
                        return GetMin(objList);
                    case AggregateFunction.Sum:
                        return GetSum(objList);
                    default:
                        return null;
                }
            }
            catch (Exception ex)
            {
                return "?";//"#Error" + ex.Message;
            }
        }

        private object GetAverage(object[] objList)
        {
            object b;
            if(objList.Count()==0 ||GetSum(objList)+""=="0")
                b=null;
            else 
                //b=(object)Convert.ToDecimal((Convert.ToDecimal(GetSum(objList)) / objList.Count())).ToString("###,###,###.##");
                b = (object)(Convert.ToDecimal(GetSum(objList)) / objList.Count());
            return b;
        }
        private object GetSum(object[] objList)
        {
            return objList.Count() == 0 ? null : (object)(objList.Aggregate(new decimal(), (x, y) => x += Convert.ToDecimal(y)));
        }
        private object GetFirst(object[] objList)
        {
            return (objList.Count() == 0) ? null : objList.First();
        }
        private object GetLast(object[] objList)
        {
            return (objList.Count() == 0) ? null :objList.Last();
        }
        private object GetMax(object[] objList)
        {
            return (objList.Count() == 0) ? null : objList.Max();
        }
        private object GetMin(object[] objList)
        {
            return (objList.Count() == 0) ? null : objList.Min();
        }
    }

    public enum AggregateFunction
    {
        Count = 1,
        Sum = 2,
        First = 3,
        Last = 4,
        Average = 5,
        Max = 6,
        Min = 7,
        Exists = 8
    }
}
