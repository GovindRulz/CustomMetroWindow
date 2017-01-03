using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//using System.Threading.Tasks;
using System.Windows;
using System.Reflection;

namespace CustomMetroWindow
{
    public class SaveData
    {
        HUtil Util = new HUtil();
        static string ConString = HorizonMainClass.ConString;//HorizonMainClass.CnString;
        public Int32 SaveObjectToDataBase(object Data)
        {
            Int32 retVal = 0;
            try
            {
                retVal = SaveDataSqlTransactionWithRet(ObjectToSqlCommand(Data));
            }
            catch (Exception Ex)
            {
                throw;
            }
            return retVal;
        }
        private static void SaveDataSqlTransaction(SqlCommand command)
        {
            //string ConString = HorizonMainClass.CnString;
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("SaveData");
                command.Connection = connection;
                command.Transaction = transaction;
                try
                {
                    command.CommandTimeout = 0;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception Ex)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception Ex2)
                    {
                        throw;
                    }
                    throw;
                }
            }
        }
        private static void ExecuteCommand(SqlCommand command)
        {
            //string ConString = HorizonMainClass.CnString;
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                command.Connection = connection;
                try
                {
                    command.CommandTimeout = 0;
                    command.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    HUtil Util = new HUtil();
                    throw;
                }
            }
        }
        private static Int32 SaveDataSqlTransactionWithRet(SqlCommand command)
        {
            Int32 RetId = 0;
            //string ConString = HorizonMainClass.CnString;
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("SaveData");
                command.Connection = connection;
                command.Transaction = transaction;
                try
                {
                    command.CommandTimeout = 0;
                    var RetVal = command.ExecuteScalar();
                    RetId = (RetVal == null) ? 0 : (Int32)RetVal;
                    //RetId = (Int32)command.ExecuteScalar();
                    transaction.Commit();
                }

                catch (Exception Ex)
                {
                    //Util.ErrLogger(Ex.Message.ToString(), this.GetType().FullName.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name); //##SaveData.SaveDataSqlTransaction : Commit Error Msg");
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception Ex2)
                    {
                        //Util.ErrLogger(Ex2.Message.ToString(), "SaveData.SaveDataSqlTransaction : RollBack Error Msg");
                        throw;
                    }
                    throw;
                    //HUtil Util = new HUtil();
                    //if (Ex.Message.ToString().Substring(0, 2) == "##")
                    //{
                    //    MessageBox.Show(Ex.Message.ToString());
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
            }
            return RetId;
        }
        private SqlCommand ObjectToSqlCommand(object Data)
        {
            SqlCommand Ret = new SqlCommand();
            //Ret.CommandText = Data.DbProcName;
            Ret.CommandType = CommandType.StoredProcedure;
            try
            {
                PropertyInfo[] Props = Data.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (PropertyInfo Prop in Props)
                {
                    object[] DtAttrs = Prop.GetCustomAttributes(true);
                    foreach (object _dtAttr in DtAttrs)
                    {
                        ObjectPropertyAttributes DtAttr = _dtAttr as ObjectPropertyAttributes;
                        if (DtAttr != null)
                        {
                            string propName = Prop.Name;
                            //string auth = DtAttr.;
                            if (DtAttr.DbProcdName != string.Empty)
                            {
                                //Ret.CommandText = DtAttr.DbProcdName;
                                Ret.CommandText = Prop.GetValue(Data, null).ToString(); 
                            }
                            if ((DtAttr.DbProcFieldType != SqlDbType.Structured) && (DtAttr.DbProcdName == string.Empty))
                            {
                                Ret.Parameters.Add(DtAttr.DbProcFieldName, DtAttr.DbProcFieldType).Value = Prop.GetValue(Data, null).ToString();
                            }
                            else if (DtAttr.DbProcFieldType == SqlDbType.Structured)
                            {
                                SqlParameter param = new SqlParameter();
                                param.ParameterName = DtAttr.DbProcFieldName;
                                param.SqlDbType = SqlDbType.Structured;
                                param.TypeName = DtAttr.DbProcFieldTypeName;
                                param.Direction = DtAttr.DbProcParameterDirection;
                                param.Value = Prop.GetValue(Data, null);
                                Ret.Parameters.Add(param);
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw;
            }
            return Ret;
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