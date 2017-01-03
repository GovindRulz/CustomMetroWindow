using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Documents;
using System.Reflection; 


namespace CustomMetroWindow
{
    public class FetchData
    {
        private string ControlerName = string.Empty;
        FetchDataWeb FWebGet;
        public FetchData(string _ControlerName = "")
        {
            ControlerName = _ControlerName;
        }
        HUtil Util = new HUtil();
        
        internal void GetData(object query, object tblName)
        {
            throw new NotImplementedException();
        }

        
        public static string ConString = HorizonMainClass.ConString;//HorizonMainClass.CnString;
        public object Con;

        public NameIdListObjList GetInv_Name_Id_List(String ViewName, int CatId = 0, int GrpId = 0, int AreaId = 0, int RouteId = 0)
        {
            NameIdListObjList Ret = new NameIdListObjList();
            try
            {
                if (HorizonMainClass.WebClient == false)
                {
                    string strSql = string.Empty;
                    strSql = "GetInv_Name_Id_List '" + ViewName + "'";
                    DataTable Dt = GetData(strSql, ViewName);
                    Ret = new NameIdListObjList(Dt);
                }
                else
                {
                    FWebGet = new FetchDataWeb(this.ControlerName);
                    Ret = new NameIdListObjList(FWebGet.FetchService<List<NameIdListObj>>("GetInvNameIdList", ViewName));
                }

            }
            catch (Exception Ex)
            {
                throw; // "FetchData.GetInv_Name_Id_List");
            }
            return Ret;
        }



        public CustomerClass GetCustomer(String ViewName, int CatId = 0, int GrpId = 0, int AreaId = 0, int RouteId = 0)
        {
            CustomerClass ItemList = new CustomerClass();
            try
            {
                if (HorizonMainClass.WebClient == false)
                {
                    string strSql = string.Empty;
                    strSql = "GetCustomer '" + ViewName + "'";
                    DataTable Dt = GetData(strSql, ViewName);
                    ItemList = new CustomerClass();
                }
                else
                {
                    FWebGet = new FetchDataWeb(this.ControlerName);
                    ItemList = FWebGet.FetchService<CustomerClass>("GetCustomer", ViewName);
                }

            }
            catch (Exception Ex)
            {
                throw; // "FetchData.GetInv_Name_Id_List");
            }
            return ItemList;
        }



        public Object OpenCon()
        {
            Con = new SqlConnection(ConString);
            return Con;
        }
        public DataTable GetDataWithCmd(SqlCommand command, string tblName)
        {
            DataTable RetTbl = new DataTable(tblName);
            //string ConString = HorizonMainClass.CnString;
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("FetchData");
                command.Connection = connection;
                command.Transaction = transaction;
                try
                {
                    command.CommandTimeout = 0;
                    SqlDataAdapter Dat = new SqlDataAdapter(command);
                    Dat.Fill(RetTbl);
                    //command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception Ex)
                {
                    HUtil Util = new HUtil();
                    Util.ErrLogger(Ex.Message.ToString(), this.GetType().FullName.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name); //##SaveData.SaveDataSqlTransaction : Commit Error Msg");
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception Ex2)
                    {
                        Util.ErrLogger(Ex2.Message.ToString(), "SaveData.SaveDataSqlTransaction : RollBack Error Msg");
                    }
                }
            }
            return RetTbl;
        }
        public DataTable GetData(String Query, String tblName)
        {
            DataTable RetTbl = new DataTable(tblName);
            try
            {
                SqlConnection cn = new SqlConnection(ConString);
                SqlCommand cmd = new SqlCommand(Query, cn);
                cmd.CommandTimeout = 0;
                SqlDataAdapter Dat = new SqlDataAdapter(cmd);
                Dat.Fill(RetTbl);
                cn.Close();
            }
            catch (Exception Ex)
            {
                Util.ErrLogger(Ex.Message.ToString(), this.GetType().FullName.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name); //##FetchData.GetData");
            }
            return RetTbl;
        }
        public DataSet GetDataSet(String Query)
        {
            DataSet RetTbl = new DataSet();
            try
            {
                SqlConnection cn = new SqlConnection(ConString);
                SqlCommand cmd = new SqlCommand(Query, cn);
                cmd.CommandTimeout = 0;
                SqlDataAdapter Dat = new SqlDataAdapter(cmd);
                Dat.Fill(RetTbl);
                cn.Close();
            }
            catch (Exception Ex)
            {
                Util.ErrLogger(Ex.Message.ToString(), this.GetType().FullName.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name); //##FetchData.GetData");
            }
            return RetTbl;
        }
        private SqlCommand GetStructToSqlCommand(object DataStr, SqlCommand StructToCommand) //Generate SqlCommand Parameters From Structure
        {
            FieldInfo[] fields = DataStr.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
            foreach (FieldInfo field in fields)
            {
                StructToCommand.Parameters.Add(getFldName(field), getFldType(field)).Value = field.GetValue(DataStr);
            }
            return StructToCommand;
        }
        private string getFldName(FieldInfo Fld) //Returns Name Of the Field That Is Passed To The DataBase
        {
            string str = "";
            str = Fld.Name.ToString();
            str = "@" + str.Trim();
            return str;
        }
        private SqlDbType getFldType(FieldInfo Fld) //Returns Name Of the Field Type That Is Passed To The DataBase
        {
            SqlDbType FldType = SqlDbType.NVarChar;
            string TypAsStr = "";
            TypAsStr = Fld.FieldType.ToString().Trim();
            if (TypAsStr == "System.String")
            {
                FldType = SqlDbType.NVarChar;
            }
            else if (TypAsStr == "System.Int32")
            {
                FldType = SqlDbType.Int;
            }
            else if (TypAsStr == "System.Double")
            {
                FldType = SqlDbType.Decimal;
            }
            else if (TypAsStr == "System.Boolean")
            {
                FldType = SqlDbType.Bit;
            }
            else if (TypAsStr == "System.DateTime")
            {
                FldType = SqlDbType.DateTime;
            }
            return FldType;
        }
    }
}