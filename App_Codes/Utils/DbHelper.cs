using System;
using System.Data;
using System.Configuration;

using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections;
using System.Collections.Specialized;
using Gnt.Data;
using System.Data.SqlClient;
using Gnt.Configuration;
using System.Text;
using BusinessObjects;
//using Gnt.Utils.FastCsv;

namespace Man.Utils
{
    public class DbHelper
    {
        enum JoinType
        {
            InnerJoin = 1,
            LeftJoin = 2
        }

        #region "Common"

        public static DataTable GetDataTable(string sql)
        {
            SqlDatabase db = new SqlDatabase();
            return db.ExecuteDataTable(sql);
        }

        public static DataTable GetDataTable(string sql,string connectionString)
        {
            SqlDatabase db = new SqlDatabase(connectionString);
            return db.ExecuteDataTable(sql);
        }


        public static string GetScalar(string sql)
        {
            SqlDatabase db = new SqlDatabase();
            return Func.ParseString(db.ExecuteScalar(sql));
        }

        public static string GetScalar(string sql,string connectionString)
        {
            SqlDatabase db = new SqlDatabase(connectionString);
            return Func.ParseString(db.ExecuteScalar(sql));
        }

        public static int GetCount(string sql)
        {
            SqlDatabase db = new SqlDatabase();
            return db.ExecuteCount(sql);
        }

        public static int GetCount(string sql,string connectionString)
        {
            SqlDatabase db = new SqlDatabase(connectionString);
            return db.ExecuteCount(sql);
        }

        //public static int ExecuteNonQuery(string sql)
        //{
        //    SqlDatabase db = new SqlDatabase();
        //    int count = 0;
        //    try
        //    {
        //        count = db.ExecuteNonQuery(sql);
        //        //ApplicationLog.WriteError("SQL: " + sql + " Count: " + count);
        //    }
        //    catch (Exception ex)
        //    {
        //        ApplicationLog.WriteError(ex);
        //        count = 0;
        //    }
        //    return count;
        //}

        public static int ExecuteNonQuery(string sql,string connectionString)
        {
            SqlDatabase db = new SqlDatabase(connectionString);
            int count = 0;
            try
            {
                count = db.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
                count = 0;
            }
            return count;
        }
       
        public static void FillListSearch(System.Web.UI.WebControls.ListControl list, string sql, string text, string value)
        {
            SqlDatabase db = new SqlDatabase();
            SqlCommand cm = db.CreateCommand(sql);
            list.DataSource = cm.ExecuteReader();
            list.DataTextField = text;
            list.DataValueField = value;
            list.DataBind();
            db.Close();
            list.Items.Insert(0, new ListItem("", ""));
        }

        public static void FillListSearch(System.Web.UI.WebControls.ListBox list, string sql, string text, string value)
        {            
            DataTable table = DbHelper.GetDataTable(sql);
            list.DataSource = table;
            list.DataTextField = text;
            list.DataValueField = value;
            list.DataBind();
        }

        public static void FillList(System.Web.UI.WebControls.ListControl list, string sql, string text, string value)
        {
            SqlDatabase db = new SqlDatabase();
            SqlCommand cm = db.CreateCommand(sql);
            list.DataSource = cm.ExecuteReader();
            list.DataTextField = text;
            list.DataValueField = value;
            list.DataBind();
            db.Close();
        }

        #endregion

        #region "Select from a DataTable"
                
        public static DataTable Select(DataTable fromTable, string where,string orderBy)
        {
            DataTable retTable = new DataTable(fromTable.TableName);
            DataRow[] dataRows = null;
            try
            {
                if (String.IsNullOrEmpty(orderBy))
                {
                    dataRows = fromTable.Select(where);
                }else
                {
                    dataRows = fromTable.Select(where, orderBy);
                }  
              
                for (int i = 0; i < fromTable.Columns.Count; i++)
                {
                    retTable.Columns.Add(new DataColumn(fromTable.Columns[i].ColumnName, fromTable.Columns[i].DataType));
                }
                retTable.BeginLoadData();
                foreach (DataRow row in dataRows)
                {
                    object[] srcArray = row.ItemArray;
                    object[] retArray = new object[srcArray.Length];
                    Array.Copy(srcArray, 0, retArray, 0, srcArray.Length);
                    retTable.LoadDataRow(retArray, true);
                }
                retTable.EndLoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retTable;
        }       

        public static DataTable Select(DataTable fromTable, string where)
        {
            return Select(fromTable, where, null);
        }

        public static DataTable Select(string[] columns,DataTable fromTable, string where,string orderBy)
        {
            DataTable retTable = Select(fromTable, where, orderBy);
            return Project(retTable, fromTable.TableName, columns);
        }

        public static DataTable Select( string[] columns,DataTable fromTable, string where)
        {
            DataTable retTable = Select(fromTable, where);
            return Project(retTable, fromTable.TableName, columns);
        }

        public static DataTable Select(DataTable srcTable, int fromRowIndex, int toRowIndex)
        {
            int rowCount = srcTable.Rows.Count;
            DataTable table = new DataTable();
            //object[] srcArray = null;
            //object[] dstArray = null;          
            
            if (fromRowIndex >= rowCount) return table;

            for (int i = 0; i < srcTable.Columns.Count; i++)
            {
                table.Columns.Add(new DataColumn(srcTable.Columns[i].ColumnName, srcTable.Columns[i].DataType));
            }

            table.BeginLoadData();

            do
            {
                if (fromRowIndex > toRowIndex) break;

                //srcArray = srcTable.Rows[fromRowIndex].ItemArray;
                //dstArray = new object[srcArray.Length];
                //Array.Copy(srcArray, 0, dstArray, 0, srcArray.Length);

                table.LoadDataRow(srcTable.Rows[fromRowIndex].ItemArray, true);

                fromRowIndex += 1;

            } while (fromRowIndex < rowCount);
            
            table.EndLoadData();
            return table;
        }

        #endregion

        #region "Union 2 DataTables"
        /// <summary>
        /// Union 2 DataTable
        /// </summary>
        /// <param name="firstTable"></param>
        /// <param name="secondTable"></param>
        /// <returns></returns>
        public static DataTable Union(DataTable firstTable, DataTable secondTable, string unionTableName)
        {
            //Result table
            DataTable retDataTable = new DataTable(unionTableName);

            //Build new columns
            DataColumn[] newColumns = new DataColumn[firstTable.Columns.Count];

            for (int i = 0; i < firstTable.Columns.Count; i++)
            {
                newColumns[i] = new DataColumn(firstTable.Columns[i].ColumnName, firstTable.Columns[i].DataType);
            }

            //add new columns to result table
            retDataTable.Columns.AddRange(newColumns);
            retDataTable.BeginLoadData();

            //Load data from first table
            foreach (DataRow row in firstTable.Rows)
            {
                retDataTable.LoadDataRow(row.ItemArray, true);
            }

            //Load data from second table
            foreach (DataRow row in secondTable.Rows)
            {
                retDataTable.LoadDataRow(row.ItemArray, true);
            }

            retDataTable.EndLoadData();

            return retDataTable;
        }
        #endregion

        #region "Project a DataTable"

        public static DataTable Project(DataTable table, DataColumn[] Columns, bool include, string projectTableName)
        {

            DataTable retTable = table.Copy();

            try
            {

                retTable.TableName = projectTableName;

                int columns_to_remove = include ? (table.Columns.Count - Columns.Length) : Columns.Length;

                string[] columns = new String[columns_to_remove];

                int z = 0;

                for (int i = 0; i < table.Columns.Count; i++)
                {

                    string column_name = retTable.Columns[i].ColumnName;

                    bool is_in_list = false;

                    for (int x = 0; x < Columns.Length; x++)
                    {

                        if (column_name == Columns[x].ColumnName)
                        {

                            is_in_list = true;

                            break;

                        }

                    }

                    if (is_in_list ^ include)

                        columns[z++] = column_name;

                }

                foreach (string s in columns)
                {

                    retTable.Columns.Remove(s);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retTable;
        }

        public static DataTable Project(DataTable table, DataColumn[] Columns, string projectTableName)
        {
            return Project(table, Columns, true, projectTableName);
        }

        public static DataTable Project(DataTable table, string projectTableName, params string[] Columns)
        {

            DataColumn[] columns = new DataColumn[Columns.Length];

            for (int i = 0; i < Columns.Length; i++)
            {

                columns[i] = table.Columns[Columns[i]];

            }

            return Project(table, columns, true, projectTableName);

        }

        public static DataTable Project(DataTable table, bool include, string projectTableName, params string[] Columns)
        {

            DataColumn[] columns = new DataColumn[Columns.Length];

            for (int i = 0; i < Columns.Length; i++)
            {

                columns[i] = table.Columns[Columns[i]];

            }

            return Project(table, columns, include, projectTableName);

        }

        #endregion

        #region "Join 2 DataTables"
        /// <summary>
        /// Join 2 DataTable
        /// </summary>
        /// <param name="joinType"></param>
        /// <param name="leftTable"></param>
        /// <param name="rightTable"></param>
        /// <param name="leftKeys"></param>
        /// <param name="rightKeys"></param>
        /// <param name="leftColumns"></param>
        /// <param name="rightColumns"></param>
        /// <param name="joinTableName"></param>
        /// <returns></returns>
        private static DataTable JoinTable(int joinType, DataTable leftTable, DataTable rightTable, string[] leftKeys, string[] rightKeys, string[] leftColumns, string[] rightColumns, string joinTableName)
        {
            string name = string.Empty;
            string columnName = string.Empty;
            string aliasName = string.Empty;
            string[] array = null;
            DataTable retDataTable = null;
            DataColumn retDataColumn = null;
            DataRow retDataRow = null;
            DataRow tempDataRow = null;
            DataRow[] relatedRows = null;
            DataSet ds = new DataSet(joinTableName);
            DataColumn[] lKeys = new DataColumn[leftKeys.Length];
            DataColumn[] rKeys = new DataColumn[rightKeys.Length];
            NameValueCollection leftMapColumns = new NameValueCollection();
            NameValueCollection rightMapColumns = new NameValueCollection();

            try
            {
                DataTable leftDataTable = leftTable.Copy();
                DataTable rightDataTable = rightTable.Copy();
                leftDataTable.TableName = "LeftTable";
                rightDataTable.TableName = "RightTable";
                ds.Tables.Add(leftDataTable);
                ds.Tables.Add(rightDataTable);
                //Left keys 
                for (int i = 0; i < leftKeys.Length; i++)
                {
                    lKeys[i] = ds.Tables[leftDataTable.TableName].Columns[leftKeys[i]];
                }
                //Right keys
                for (int i = 0; i < rightKeys.Length; i++)
                {
                    rKeys[i] = ds.Tables[rightDataTable.TableName].Columns[rightKeys[i]];
                }

                ds.Relations.Add(new DataRelation("R", rKeys, lKeys, false));

                //Create join table
                retDataTable = new DataTable(joinTableName);

                //Parse column name from left table
                for (int i = 0; i < leftColumns.Length; i++)
                {
                    name = leftColumns[i];
                    name = name.Trim();
                    array = name.Split(" ".ToCharArray());
                    if (array.Length == 1)
                    {
                        columnName = name;
                        aliasName = name;
                    }
                    else if (array.Length == 2)
                    {
                        columnName = array[0];
                        aliasName = array[1];
                    }
                    leftMapColumns.Add(aliasName, columnName);
                    retDataColumn = new DataColumn(aliasName, leftDataTable.Columns[columnName].DataType);
                    retDataTable.Columns.Add(retDataColumn);
                }

                //Parse column name from right table
                for (int i = 0; i < rightColumns.Length; i++)
                {
                    name = rightColumns[i];
                    name = name.Trim();
                    array = name.Split(" ".ToCharArray());
                    if (array.Length == 1)
                    {
                        columnName = name;
                        aliasName = name;
                    }
                    else if (array.Length == 2)
                    {
                        columnName = array[0];
                        aliasName = array[1];
                    }
                    rightMapColumns.Add(aliasName, columnName);
                    retDataColumn = new DataColumn(aliasName, rightDataTable.Columns[columnName].DataType);
                    retDataTable.Columns.Add(retDataColumn);
                }

                //Do inner Join
                if (joinType == (int)JoinType.InnerJoin)
                {
                    foreach (DataRow leftRow in ds.Tables[leftDataTable.TableName].Rows)
                    {
                        foreach (DataRow rightRow in leftRow.GetParentRows(ds.Relations["R"]))
                        {
                            retDataRow = retDataTable.NewRow();
                            //Copy data from left table
                            foreach (string key in leftMapColumns.AllKeys)
                            {
                                retDataRow[key] = leftRow[leftMapColumns.Get(key)];
                            }
                            //Get related data
                            foreach (string key in rightMapColumns.AllKeys)
                            {
                                retDataRow[key] = rightRow[rightMapColumns.Get(key)];
                            }
                            retDataTable.Rows.Add(retDataRow);
                        }
                    }
                }//Do left Join
                else if (joinType == (int)JoinType.LeftJoin)
                {
                    foreach (DataRow leftRow in ds.Tables[leftDataTable.TableName].Rows)
                    {
                        retDataRow = retDataTable.NewRow();
                        //Copy data from left table
                        foreach (string key in leftMapColumns.AllKeys)
                        {
                            retDataRow[key] = leftRow[leftMapColumns.Get(key)];
                        }

                        //Get related data
                        relatedRows = leftRow.GetParentRows(ds.Relations["R"]);

                        switch (relatedRows.Length)
                        {
                            case 0:
                                retDataTable.Rows.Add(retDataRow);
                                break;
                            case 1:
                                foreach (string key in rightMapColumns.AllKeys)
                                {
                                    retDataRow[key] = relatedRows[0][rightMapColumns.Get(key)];
                                }
                                retDataTable.Rows.Add(retDataRow);
                                break;
                            default:
                                tempDataRow.ItemArray = retDataRow.ItemArray;
                                foreach (DataRow rightRow in relatedRows)
                                {
                                    retDataRow = retDataTable.NewRow();
                                    retDataRow.ItemArray = tempDataRow.ItemArray;
                                    //Copy data from right table
                                    foreach (string key in rightMapColumns.AllKeys)
                                    {
                                        retDataRow[key] = rightRow[rightMapColumns.Get(key)];
                                    }
                                    retDataTable.Rows.Add(retDataRow);
                                }
                                break;
                        }

                    }
                }

                ds.Relations.Remove("R");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retDataTable;
        }

        /// <summary>
        /// Left Join 2 DataTable
        /// </summary>
        /// <param name="leftTable"></param>
        /// <param name="rightTable"></param>
        /// <param name="leftKeys"></param>
        /// <param name="rightKeys"></param>
        /// <param name="leftColumns"></param>
        /// <param name="rightColumns"></param>
        /// <param name="joinTableName"></param>
        /// <returns></returns>
        public static DataTable LeftJoin(DataTable leftTable, DataTable rightTable, string[] leftKeys, string[] rightKeys, string[] leftColumns, string[] rightColumns, string joinTableName)
        {
            return JoinTable((int)JoinType.LeftJoin, leftTable, rightTable, leftKeys, rightKeys, leftColumns, rightColumns, joinTableName);
        }

        /// <summary>
        /// Inner Join 2 DataTable
        /// </summary>
        /// <param name="leftTable"></param>
        /// <param name="rightTable"></param>
        /// <param name="leftKeys"></param>
        /// <param name="rightKeys"></param>
        /// <param name="leftColumns"></param>
        /// <param name="rightColumns"></param>
        /// <param name="joinTableName"></param>
        /// <returns></returns>
        public static DataTable InnerJoin(DataTable leftTable, DataTable rightTable, string[] leftKeys, string[] rightKeys, string[] leftColumns, string[] rightColumns, string joinTableName)
        {
            return JoinTable((int)JoinType.InnerJoin, leftTable, rightTable, leftKeys, rightKeys, leftColumns, rightColumns, joinTableName);
        }

        #endregion

        #region "Group by"

        /// <summary>
        /// Group by 
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="Grouping"></param>
        /// <param name="AggregateExpressions"></param>
        /// <param name="ExpressionNames"></param>
        /// <param name="Types"></param>
        /// <returns></returns>
        public static DataTable GroupBy(DataTable table, string[] groupColumns, string[] aggregateExpressions, string[] expressionNames, Type[] dataTypes, string groupByName)
        {

            if (table.Rows.Count == 0)
                return table;

            DataTable retDataTable = Project(table, groupByName, groupColumns);

            for (int i = 0; i < expressionNames.Length; i++)
            {
                retDataTable.Columns.Add(expressionNames[i], dataTypes[i]);
            }

            foreach (DataRow row in retDataTable.Rows)
            {
                string filter = string.Empty;
                for (int i = 0; i < groupColumns.Length; i++)
                {
                    //Determine Data Type    
                    string columnName = groupColumns[i];
                    object o = row[columnName];
                    if (o is string)//if (o is string || DBNull.Value == o)
                    {

                        filter += columnName + "='" + o.ToString() + "' AND ";

                    }
                    else if (o is DateTime)
                    {

                        filter += columnName + "=#" + ((DateTime)o).ToLongDateString()

                              + " " + ((DateTime)o).ToLongTimeString() + "# AND ";
                    }
                    else if (DBNull.Value == o)
                    {
                        filter += "IsNull(" + columnName + ",0)=0 AND ";
                    }
                    else
                        filter += columnName + "=" + o.ToString() + " AND ";
                }

                filter = filter.Substring(0, filter.Length - 5);
                for (int i = 0; i < aggregateExpressions.Length; i++)
                {
                    object computed = table.Compute(aggregateExpressions[i], filter);
                    row[expressionNames[i]] = computed;
                }
            }
            retDataTable = Distinct(retDataTable);
            return retDataTable;

        }

        #endregion

        #region "Distinct"

        /// <summary>
        /// Compare 2 rows
        /// </summary>
        /// <param name="values"></param>
        /// <param name="otherValues"></param>
        /// <returns></returns>
        private static bool RowEqual(object[] values, object[] otherValues)
        {

            if (values == null)
                return false;
            for (int i = 0; i < values.Length; i++)
            {
                if (!values[i].Equals(otherValues[i]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Select distinct from a DataTable
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static DataTable Distinct(DataTable table, DataColumn[] columns)
        {
            //Empty table
            DataTable retDataTable = new DataTable("Distinct");
            //Sort variable
            string sort = String.Empty;
            //Add Columns & Build Sort expression
            for (int i = 0; i < columns.Length; i++)
            {
                retDataTable.Columns.Add(columns[i].ColumnName, columns[i].DataType);
                sort += columns[i].ColumnName + ",";
            }
            //Select all rows and sort
            DataRow[] sortedRows = table.Select(String.Empty, sort.Substring(0, sort.Length - 1));
            object[] currentRow = null;
            object[] previousRow = null;

            retDataTable.BeginLoadData();
            foreach (DataRow row in sortedRows)
            {
                //Current row
                currentRow = new object[columns.Length];
                for (int i = 0; i < columns.Length; i++)
                {
                    currentRow[i] = row[columns[i].ColumnName];
                }
                //Match Current row to previous row
                if (!RowEqual(previousRow, currentRow))
                    retDataTable.LoadDataRow(currentRow, true);

                //Previous row
                previousRow = new object[columns.Length];
                for (int i = 0; i < columns.Length; i++)
                {
                    previousRow[i] = row[columns[i].ColumnName];
                }
            }
            retDataTable.EndLoadData();
            return retDataTable;
        }

        /// <summary>
        /// Distinct
        /// </summary>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static DataTable Distinct(DataTable table, DataColumn column)
        {
            return Distinct(table, new DataColumn[] { column });
        }

        /// <summary>
        /// Distinct
        /// </summary>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static DataTable Distinct(DataTable table, string column)
        {
            return Distinct(table, table.Columns[column]);
        }

        /// <summary>
        /// Distinct
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static DataTable Distinct(DataTable table, params string[] columns)
        {
            DataColumn[] cols = new DataColumn[columns.Length];
            for (int i = 0; i < columns.Length; i++)
            {
                cols[i] = table.Columns[columns[i]];
            }
            return Distinct(table, cols);
        }

        /// <summary>
        /// Distinct
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static DataTable Distinct(DataTable table)
        {
            DataColumn[] cols = new DataColumn[table.Columns.Count];
            for (int i = 0; i < table.Columns.Count; i++)
            {
                cols[i] = table.Columns[i];
            }
            return Distinct(table, cols);

        }

        


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static DataSet GetMstrData(string sql)
        {
            SqlDatabase db = new SqlDatabase();
            StringBuilder sb = new StringBuilder();
            DataSet ds = new DataSet();

            try
            {
                SqlCommand cm = db.CreateCommand(sql);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(ds);
                db.Close();

                return ds;
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static DataSet GetDataByField(string mstTableName, string fieldList, string where)
        {
            SqlDatabase db = new SqlDatabase();
            string whereIds = "";
            string sql = String.Empty;
            StringBuilder sb = new StringBuilder();
            DataSet ds = new DataSet();

            if (!String.IsNullOrEmpty(where))
            {
                whereIds = " AND " + where;
            }

            try
            {
                sql = String.Empty;
                Func.ClearSqlString(sb);
                if ("*".Equals(fieldList))
                {
                    Func.AddSqlString(sb, "SELECT * ");
                }
                else
                {
                    Func.AddSqlString(sb, "SELECT "+ fieldList +" ");
                }
                Func.AddSqlString(sb, " FROM " + mstTableName + " S");
                Func.AddSqlString(sb, " WHERE 1=1");
                Func.AddSqlString(sb, whereIds);

                sql = sb.ToString();
                System.Diagnostics.Debug.WriteLine("sql = " + sql);

                SqlCommand cm = db.CreateCommand(sql);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(ds);
                db.Close();

                return ds;
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static string GetFieldIds(string mstTableName, string fieldName, string condition)
        {
            SqlDatabase db = new SqlDatabase();
            string sql = String.Empty;
            StringBuilder sb = new StringBuilder();
            DataSet ds = new DataSet();
            try
            {
                sql = String.Empty;
                Func.ClearSqlString(sb);
                Func.AddSqlString(sb, "SELECT * ");
                Func.AddSqlString(sb, " FROM " + mstTableName + " S");
                Func.AddSqlString(sb, " WHERE 1=1");
                Func.AddSqlString(sb, condition);

                sql = sb.ToString();
                System.Diagnostics.Debug.WriteLine("sql = " + sql);

                SqlCommand cm = db.CreateCommand(sql);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(ds);
                db.Close();

                string ids = "";
                if (ds.Tables[0] != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];

                        ids += ",'" + dr[fieldName].ToString() + "'";
                    }
                }
                return ids.Substring(1,ids.Length-1);
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static DataSet GetMstrDataInvalid(string mstTableName, string mstrKey, string ids)
        {
            SqlDatabase db = new SqlDatabase();
            string whereIds = "";
            string sql = String.Empty;
            StringBuilder sb = new StringBuilder();
            DataSet ds = new DataSet();

            if (String.IsNullOrEmpty(ids))
            {
                return null;
            }
            else
            {
                whereIds = " AND " + mstrKey + " IN (" + ids.Substring(1, ids.Length - 1) + ") and DelFlag='1'";
            }

            try
            {
                sql = String.Empty;
                Func.ClearSqlString(sb);

                Func.AddSqlString(sb, "SELECT " + mstrKey + " ");
                Func.AddSqlString(sb, " FROM " + mstTableName + " S");
                Func.AddSqlString(sb, " WHERE 1=1");
                Func.AddSqlString(sb, whereIds);

                sql = sb.ToString();
                System.Diagnostics.Debug.WriteLine("sql = " + sql);

                SqlCommand cm = db.CreateCommand(sql);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(ds);
                db.Close();

                return ds;
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static DataSet GetSiteData(string ids, string where)
        {
            SqlDatabase db = new SqlDatabase();
            string whereIds = "";
            string sql = String.Empty;
            StringBuilder sb = new StringBuilder();
            DataSet ds = new DataSet();
            if (String.IsNullOrEmpty(ids))
            {
                whereIds = "";
            }
            else
            {
                whereIds = " AND Id IN (" + ids + ")  and Id <> 0";
            }

            if (!String.IsNullOrEmpty(where))
            {
                whereIds += " AND " + where;
            }

            try
            {
                sql = String.Empty;
                Func.ClearSqlString(sb);
                Func.AddSqlString(sb, "SELECT *");
                Func.AddSqlString(sb, " FROM Site");
                Func.AddSqlString(sb, " WHERE (delFlag = 0)");
                Func.AddSqlString(sb, whereIds);

                sql = sb.ToString();
                SqlCommand cm = db.CreateCommand(sql);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(ds);
                db.Close();

                return ds;
            }
            catch (Exception ex)
            {
                ApplicationLog.WriteError(ex);
                return null;
            }
        }

        
        /// <summary>
        /// Creates primary key in case dataobject is set autoincrement = false
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string CreateKey(DataObject data)
        {
            string prefix = data.ObjectType.Prefix;
            int length = data.KeyAttributeData.MaxLength;
            string tmp = String.Format("", length);

            string sql = "SELECT max(maxid) from (SELECT SUBSTRING(" + data.ObjectKeyColumnName + ", " + (prefix.Length + 1) + ", " + length + ") as maxid FROM " + data.ObjectKeyTableName + ") as tmp WHERE maxid < '100000'";


            int key = 0;
            try
            {
                key = Convert.ToInt32(GetScalar(sql));
                key++;
            }
            catch
            {
                key = 1;
            }

            bool keyFlg = true;
            while (keyFlg)
            {
                string tmpKey = prefix + key.ToString().PadLeft(length - prefix.Length, '0');
                sql = "SELECT count(*) from " + data.ObjectKeyTableName + " WHERE " + data.ObjectKeyColumnName + " = '" + tmpKey + "'";
                if (Convert.ToInt32(GetScalar(sql)) != 1)
                {
                    keyFlg = false;
                }
                else
                {
                    key--;
                }
            }
            return prefix + key.ToString().PadLeft(length - prefix.Length, '0');
        }
        /// <summary>
        /// Creates primary key in case dataobject is set autoincrement = false
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string CreateKey(DataObject data, string prefix)
        {
            int length = data.KeyAttributeData.MaxLength;
            string tmp = String.Format("", length);

            string sql = "SELECT max(maxid) from (SELECT SUBSTRING(" + data.ObjectKeyColumnName + ", " + (prefix.Length + 1) + ", " + length + ") as maxid FROM " + data.ObjectKeyTableName + ") as tmp WHERE maxid < '" + "".PadRight(length - 2, '9') + "'";


            int key = 0;
            try
            {
                key = Convert.ToInt32(GetScalar(sql));
                key++;
            }
            catch
            {
                key = 1;
            }

            bool keyFlg = true;
            while (keyFlg)
            {
                string tmpKey = prefix + key.ToString().PadLeft(length - prefix.Length, '0');
                sql = "SELECT count(*) from " + data.ObjectKeyTableName + " WHERE " + data.ObjectKeyColumnName + " = '" + tmpKey + "'";
                if (Convert.ToInt32(GetScalar(sql)) != 1)
                {
                    keyFlg = false;
                }
                else
                {
                    key--;
                }
            }
            return prefix + key.ToString().PadLeft(length - prefix.Length, '0');
        }
        
        #endregion

        
        public static bool isAdmin(string userName)
        {
            int count = DbHelper.GetCount("Select Count(*) from Mst_UserInRoles Where Username = '" + userName + "' and RoleId = 'Admin'");
            if (count == 0)
                return false;
            return true;
        }
        public static int ExecuteNonQuery(string sql)
        {
            int ret = -1;
            using (SqlConnection con = new SqlConnection(ICJSystem.Instance.ConnectionString1))
            {
                using (SqlCommand cm = new SqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        cm.CommandTimeout = 9999;
                        ret = cm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        ApplicationLog.WriteError(ex.Message);
                    }
                }
            }
            return ret;
        }

        public static int ExecuteDB(string sql)
        {
            int ret = -1;
            using (SqlConnection con = new SqlConnection(ICJSystem.Instance.ConnectionString1))
            {
                using (SqlCommand cm = new SqlCommand(sql, con))
                {
                    try
                    {
                        cm.CommandTimeout = 9999;
                        con.Open();
                        ret = cm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        ApplicationLog.WriteError(ex.Message);
                    }
                }
            }
            return ret;
        }
        public static void exeStoreProcedue(string strStorePro)
        {
            using (SqlConnection con = new SqlConnection(ICJSystem.Instance.ConnectionString1))
            {
                con.Open();
                using (SqlCommand cm = new SqlCommand(strStorePro, con))
                {
                    try
                    {
                        cm.CommandType = System.Data.CommandType.StoredProcedure;
                        cm.CommandTimeout = 9999;
                        cm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        ApplicationLog.WriteError(ex);
                    }
                }
            }
        }
    }
}
