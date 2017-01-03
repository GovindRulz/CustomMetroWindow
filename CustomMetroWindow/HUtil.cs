using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Input;
//using System.Windows.Controls;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Data;
using System.Reflection;
//using System.Windows.Data;
using System.Globalization;



namespace CustomMetroWindow
{
    public class HUtil
    {
        public bool ValidateInputDate(DateTime InputDate ,DateTime FinYrBegDate)
        {
            bool flg = false;
            DateTime MaxDate = FinYrBegDate.AddYears(1);
            MaxDate = MaxDate.AddDays(-1);
            if ((InputDate.Date <= MaxDate.Date) && (InputDate.Date >= FinYrBegDate.Date))
            {
                flg = true;
            }
            return flg;
        }
        public string TOWORDS(double Nvalue)
        {

            string [] Ara1 = new string [100];
            Ara1[1] = "One";
            Ara1[2] = "Two";
            Ara1[3] = "Three";
            Ara1[4] = "Four";
            Ara1[5] = "Five";
            Ara1[6] = "Six";
            Ara1[7] = "Seven";
            Ara1[8] = "Eight";
            Ara1[9] = "Nine";
            Ara1[10] = "Ten";
    
            Ara1[11] = "Eleven";
            Ara1[12] = "Twelve";
            Ara1[13] = "Thirteen";
            Ara1[14] = "Fourteen";
            Ara1[15] = "Fifteen";
            Ara1[16] = "Sixteen";
            Ara1[17] = "Seventeen";
            Ara1[18] = "Eighteen";
            Ara1[19] = "Ninteen";
            Ara1[20] = "Twenty";
    
            Ara1[30] = "Thirty";
            Ara1[40] = "Fourty";
            Ara1[50] = "Fifty";
            Ara1[60] = "Sixty";
            Ara1[70] = "Seventy";
            Ara1[80] = "Eighty";
            Ara1[90] = "Ninety";

            int StrLen=0;
            string NumStr =string.Empty;
            string NString = string.Empty;
            int TenValue =0; 
            string TenString= string.Empty;
            int  HunValue =0;
            string HunString = string.Empty;
            int ThoValue =0;
            string ThoString= string.Empty;
            int TthValue =0;
            string TthString = string.Empty;
            int LakValue =0;
            string LakString = string.Empty;
            int TlkValue =0;
            string TlkString = string.Empty;
            int CroValue =0;
            string CroString = string.Empty;
            int TcrValue =0; 
            string TcrString = string.Empty;
            int lk =0 ;
            string SbStr = string.Empty;
            int SbVal =0;
            string retStr = string.Empty;

            NString = Nvalue.ToString();
            TenString = ""; TthString = ""; LakString = ""; TlkString = "";
            CroString = ""; TcrString = "";
    
            StrLen = Nvalue.ToString().Length;
            NumStr = string.Empty;
            lk = 1;
    
            while (lk == 1)
            {
                if (NString == "0")
                {
                    StrLen = 0;
                    lk = 2;
                }
                switch (StrLen)
                {
                    case 1:
                        NumStr = NumStr + Ara1[Convert.ToInt32(NString)];
                        lk = 2;
                        break;
                    case 2:
                        if (Convert.ToInt32(NString) <= 20) 
                        {
                            NumStr = NumStr + Ara1[Convert.ToInt32(NString)];
                        }
                        else
                        {
                            TenValue =Convert.ToInt32(NString.Substring(0,1) + "0");
                            TenString = Ara1[TenValue];
                            NumStr = TenString + " " + NumStr + Ara1[Convert.ToInt32(NString.Substring(1, 1))];
                        }
                        lk = 2;
                        break;
                    case 3:
                        HunValue = Convert.ToInt32(NString.Substring(0, 1));
                        HunString = Ara1[HunValue];
                        NString = NString.Substring(1,NString.Length-1);
                        StrLen = NString.Length;
                        if (HunValue > 0)
                        {
                            HunString = HunString + " hundred " + ((Convert.ToInt32(NString) > 0) ? " and " : "");
                        }
                        else
                        {
                            if (Convert.ToInt32(NString) > 0) { HunString = "and"; }
                            else { HunString = ""; }
                        }
                        break;
                    case 4:
                        ThoValue =Convert.ToInt32(NString.Substring(0,1));
                        ThoString = Ara1[ThoValue];
                        NString = NString.Substring(1,NString.Length-1);
                        StrLen = NString.Length;
                        if (ThoValue > 0) 
                        {
                            ThoString = ThoString + " thousand ";
                        }
                        break;
                    case 5:
                        TthValue =Convert.ToInt32(NString.Substring(0, 2));
                        if (TthValue <= 20)
                        {
                            SbStr = Ara1[TthValue];
                        }
                        else
                        {
                            SbVal =Convert.ToInt32(NString.Substring(0, 1) + "0");
                            SbStr = Ara1[SbVal];
                            SbStr = SbStr + " " + Ara1[Convert.ToInt32(NString.Substring(1, 1))];
                        }
                        NString = NString.Substring(2,NString.Length-2);
                        StrLen = NString.Length;
                        if (TthValue > 0)
                        {
                            TthString = SbStr + " thousand ";
                        }
                        break;
                    case 6:
                        LakValue =Convert.ToInt32(NString.Substring(0, 1));
                        LakString = Ara1[LakValue];
                        NString = NString.Substring(1,NString.Length-1);
                        StrLen = NString.Length;
                        if (LakValue > 0)
                        {
                            LakString = LakString + " Lakh ";
                        }
                        break;
                    case 7:
                        TlkValue =Convert.ToInt32(NString.Substring(0, 2));
                        if (TlkValue <= 20)
                        {
                            SbStr = Ara1[TlkValue];
                        }
                        else
                        {
                            SbVal =Convert.ToInt32(NString.Substring(0,1) + "0");
                            SbStr = Ara1[SbVal];
                            SbStr = SbStr + " " + Ara1[Convert.ToInt32(NString.Substring(1, 1))];
                        }
                        NString = NString.Substring(2,NString.Length-2);
                        StrLen = NString.Length;
                        if (TlkValue > 0)
                        {
                            TlkString = SbStr + " lakh ";
                        }
                        break;
                    case 8:
                        CroValue = Convert.ToInt32(NString.Substring(1, 1));
                        CroString = Ara1[CroValue];
                        NString = NString.Substring(2,NString.Length);
                        StrLen = NString.Length;
                        if (CroValue > 0)
                        {
                            CroString = CroString + " crore ";
                        }
                        break;
                    case 9:
                        TcrValue = Convert.ToInt32(NString.Substring(0, 2));
                        if (TcrValue <= 20)
                        {
                            SbStr = Ara1[TcrValue];
                        }
                        else
                        {
                            SbVal =Convert.ToInt32(NString.Substring(0, 1) + "0");
                            SbStr = Ara1[SbVal];
                            SbStr = SbStr + " " + Ara1[Convert.ToInt32(NString.Substring(1,1))];
                        }
                        NString = NString.Substring(2,NString.Length-2);
                        StrLen = NString.Length;
                        if (TcrValue > 0)
                        {
                            TcrString = SbStr + " crore ";
                        }
                        break;
                }
            }
            
            retStr = TcrString + CroString + TlkString + LakString + TthString + ThoString + HunString + " " + NumStr + " Only.";
            return retStr;
        }
        public string Removecomma(string FullName)
        {
            Char str1;
            string listName = string.Empty;
            int i = 0;
            if (FullName != "")
            {
                for (i = 0; i <= FullName.Length - 1; i++)
                {
                    str1 = Convert.ToChar(FullName.Substring(i, 1).ToUpper());
                    if (str1.ToString() != "'")
                    {
                        listName = listName + Convert.ToString(str1);
                    }
                    else
                    {
                        listName = listName + "`";
                    }
                }
            }
            return listName;
        }
        public string Listname(string FullName)
        {
            Char  str1 ;
            string listName = string.Empty;
            int i = 0;
            if (FullName != "")
            {
                for (i = 0; i<= FullName.Length-1; i++)
                {
                    str1 =Convert.ToChar(FullName.Substring(i, 1).ToUpper());
                    if (char.IsLetterOrDigit(str1))
                    {
                        if ((str1.ToString() != "-") && (str1.ToString() != ".") && (str1.ToString() != "+") && (str1.ToString() != ",") && (str1.ToString() != "*"))
                        {
                            listName = listName + Convert.ToString(str1);
                        }
                    }
                }
            }
            return listName; 
        }
        public bool ValidateRights (string UserRight,string Action)
        {
            bool RetVal = false;
            if (UserRight == "FULLRIGHTS" || UserRight == "ADDMODIFY") 
                { RetVal = true; }
            else if (UserRight == "ADDVIEW")
            {
                if (Action.ToUpper() == "UPDATE" || Action.ToUpper() == "DELETE") 
                    { RetVal = false; }
                else 
                    { RetVal = true; }
            }
            else
                { RetVal = false; }
            return RetVal;
        }
        public void readconfig()
        {
            try
            {

                string ApplicationPath = string.Empty;
                string ConfigPath = string.Empty;
                int IndexOffAppName = 0;
                //HorizonMainClass.SftInfo.HalfPageLineCount = 0;
                //HorizonMainClass.SftInfo.FullPageLineCount = 0;
                //HorizonMainClass.SftInfo.AUTOLOADCOMPANY = "";
                ApplicationPath = System.Reflection.Assembly.GetEntryAssembly().Location;
                IndexOffAppName = ApplicationPath.IndexOf("HorizonERP 2013.exe");
                //HorizonMainClass.SftInfo.AppPath = ApplicationPath.Substring(0, ApplicationPath.Length - 19);
                ConfigPath = ApplicationPath.Substring(0, ApplicationPath.Length - 19) + @"Config.ini";
                using (StreamReader sr = File.OpenText(ConfigPath))
                {
                    string str = "";

                    while ((str = sr.ReadLine()) != null)
                    {
                        str = str.ToUpper(); 
                        if (str.IndexOf("SERVERNAME") != -1)
                        {
                            for (int i = 0; i <= str.Length; i++)
                            {
                                if (str.Substring(i, 1) == "=")
                                {
                                    //string a = str.Substring(i + 1, (str.Length - 1)-i);
                                    //HorizonMainClass.SftInfo.ServerName = str.Substring(i + 1, (str.Length - 1) - i);

                                    break;
                                }
                            }
                        }

                        if (str.IndexOf("BACKUPPATH") != -1)
                        {
                            for (int i = 0; i <= str.Length; i++)
                            {
                                if (str.Substring(i, 1) == "=")
                                {
                                    //HorizonMainClass.SftInfo.BackupPath = str.Substring(i + 1, (str.Length - 1) - i);
                                    break;
                                }
                            }
                        }

                        if (str.IndexOf("LOGOPATH") != -1)
                        {
                            for (int i = 0; i <= str.Length; i++)
                            {
                                if (str.Substring(i, 1) == "=")
                                {
                                    //HorizonMainClass.SftInfo.LogoPath = str.Substring(i + 1, (str.Length - 1) - i);
                                    break;
                                }
                            }
                        }

                        if (str.IndexOf("DBNAME") != -1)
                        {
                            for (int i = 0; i <= str.Length; i++)
                            {
                                if (str.Substring(i, 1) == "=")
                                {
                                    //HorizonMainClass.SftInfo.DBName = str.Substring(i + 1, (str.Length - 1) - i);
                                    break;
                                }
                            }
                        }
                        if (str.IndexOf("POS") != -1)
                        {
                            for (int i = 0; i <= str.Length; i++)
                            {
                                if (str.Substring(i, 1) == "=")
                                {
                                    //HorizonMainClass.SftInfo.Pos = str.Substring(i + 1, (str.Length - 1) - i);
                                    break;
                                }
                            }
                        }
                        if (str.IndexOf("HALFPAGELINECOUNT") != -1)
                        {
                            for (int i = 0; i <= str.Length; i++)
                            {
                                if (str.Substring(i, 1) == "=")
                                {
                                    ///HorizonMainClass.SftInfo.HalfPageLineCount =Convert.ToInt32(str.Substring(i + 1, (str.Length - 1) - i));
                                    break;
                                }
                            }
                        }
                        if (str.IndexOf("FULLPAGELINECOUNT") != -1)
                        {
                            for (int i = 0; i <= str.Length; i++)
                            {
                                if (str.Substring(i, 1) == "=")
                                {
                                    //HorizonMainClass.SftInfo.FullPageLineCount =Convert.ToInt32(str.Substring(i + 1, (str.Length - 1) - i));
                                    break;
                                }
                            }
                        }
                        if (str.IndexOf("AUTOLOADCOMPANY") != -1)
                        {
                            for (int i = 0; i <= str.Length; i++)
                            {
                                if (str.Substring(i, 1) == "=")
                                {
                                    //HorizonMainClass.SftInfo.AUTOLOADCOMPANY = str.Substring(i + 1, (str.Length - 1) - i);
                                    break;
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception exc)
            {
                throw;
            }
        }
        public void ErrLogger(string ErrorTxt, string ErrorSource , bool ShowMsg = true)
        {
            //HorizonMainClass.RaiseMsgOnError = ShowMsg;
            string path = @"c:\HErrorLog.txt";
            string ErrStr = string.Empty;
            string SysDate = Convert.ToString( DateTime.Now);
            ErrStr = "Date :" + SysDate  + " || Error Source :" + ErrorSource + " || Error Message :" + ErrorTxt;
            // This text is added only once to the file. 
            if (!File.Exists(path))
            {
                // Create a file to write to. 
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(ErrStr);
                    sw.Close();
                    //if (HorizonMainClass.RaiseMsgOnError == true)
                    //{
                    //    MessageBox.Show("Software Exception Logged");
                    //}
                }
            }
            // This text is always added, making the file longer over time 
            // if it is not deleted. 
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(ErrStr);
                sw.Close();
                //if (HorizonMainClass.RaiseMsgOnError == true)
                //{
                //    MessageBox.Show("Software Exception Logged");
                //}
            }            
        }
        //public List<T> FromDataTableToList(DataTable dataTable)
        //{
        //    //This create a new list with the same type of the generic class
        //    List<T> genericList = new List<T>();
        //    //Obtains the type of the generic class
        //    Type t = typeof(T);

        //    //Obtains the properties definition of the generic class.
        //    //With this, we are going to know the property names of the class
        //    PropertyInfo[] pi = t.GetProperties();

        //    //For each row in the datatable

        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        //Create a new instance of the generic class
        //        object defaultInstance = Activator.CreateInstance(t);
        //        //For each property in the properties of the class
        //        foreach (PropertyInfo prop in pi)
        //        {
        //            try
        //            {
        //                //Get the value of the row according to the field name
        //                //Remember that the classïs members and the tableïs field names
        //                //must be identical
        //                object columnvalue = row[prop.Name];
        //                //Know check if the value is null. 
        //                //If not, it will be added to the instance
        //                if (columnvalue != DBNull.Value)
        //                {
        //                    //Set the value dinamically. Now you need to pass as an argument
        //                    //an instance class of the generic class. This instance has been
        //                    //created with Activator.CreateInstance(t)
        //                    prop.SetValue(defaultInstance, columnvalue, null);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine(prop.Name + ": " + ex.ToString());
        //                return null;
        //            }
        //        }
        //        //Now, create a class of the same type of the generic class. 
        //        //Then a conversion itïs done to set the value
        //        T myclass = (T)defaultInstance;
        //        //Add the generic instance to the generic list
        //        genericList.Add(myclass);
        //    }
        //    //At this moment, the generic list contains all de datatable values
        //    return genericList;
        //}
        public DataTable ToDataTable<T>(List<T> l_oItems)
        {
            DataTable oReturn = new DataTable(typeof(T).Name);
            object[] a_oValues;
            int i;

            //#### Collect the a_oProperties for the passed T
            PropertyInfo[] a_oProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //#### Traverse each oProperty, .Add'ing each .Name/.BaseType into our oReturn value
            //####     NOTE: The call to .BaseType is required as DataTables/DataSets do not support nullable types, so it's non-nullable counterpart Type is required in the .Column definition
            foreach (PropertyInfo oProperty in a_oProperties)
            {
                oReturn.Columns.Add(oProperty.Name, BaseType(oProperty.PropertyType));
            }

            //#### Traverse the l_oItems
            foreach (T oItem in l_oItems)
            {
                //#### Collect the a_oValues for this loop
                a_oValues = new object[a_oProperties.Length];

                //#### Traverse the a_oProperties, populating each a_oValues as we go
                for (i = 0; i < a_oProperties.Length; i++)
                {
                    a_oValues[i] = a_oProperties[i].GetValue(oItem, null);
                }

                //#### .Add the .Row that represents the current a_oValues into our oReturn value
                oReturn.Rows.Add(a_oValues);
            }

            //#### Return the above determined oReturn value to the caller
            return oReturn;

        }
        private Type BaseType(Type oType)
        {
            //#### If the passed oType is valid, .IsValueType and is logicially nullable, .Get(its)UnderlyingType
            if (oType != null && oType.IsValueType &&
                oType.IsGenericType && oType.GetGenericTypeDefinition() == typeof(Nullable<>)
            )
            {
                return Nullable.GetUnderlyingType(oType);
            }
            //#### Else the passed oType was null or was not logicially nullable, so simply return the passed oType
            else
            {
                return oType;
            }
        }
        public DataTable GetStructToDataClmn(object DataStr, DataTable StructToTable) //Generate SqlCommand Parameters From Structure
        {
            FieldInfo[] fields = DataStr.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
            foreach (FieldInfo field in fields)
            {
                //StructToCommand.Parameters.Add(getFldName(field), getFldType(field)).Value = field.GetValue(DataStr);
                StructToTable.Columns.Add(field.Name.ToString().Trim(), field.FieldType); 
            }
            return StructToTable;
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
            return FldType;
        }
        public ADODB.Recordset ConvertToRecordset(DataTable inTable)
        {
            ADODB.Recordset result = new ADODB.Recordset();
            result.CursorLocation = ADODB.CursorLocationEnum.adUseClient;

            ADODB.Fields resultFields = result.Fields;
            System.Data.DataColumnCollection inColumns = inTable.Columns;

            foreach (DataColumn inColumn in inColumns)
            {

                resultFields.Append(inColumn.ColumnName
                    , TranslateType(inColumn.DataType)
                    , inColumn.MaxLength);

                //resultFields.Append(inColumn.ColumnName
                //    , TranslateType(inColumn.DataType)
                //    , inColumn.MaxLength
                //    , inColumn.AllowDBNull ? ADODB.FieldAttributeEnum.adFldIsNullable :
                //                             ADODB.FieldAttributeEnum.adFldUnspecified
                //    , null);
            }

            result.Open(System.Reflection.Missing.Value
                    , System.Reflection.Missing.Value
                    , ADODB.CursorTypeEnum.adOpenStatic
                    , ADODB.LockTypeEnum.adLockOptimistic, 0);

            foreach (DataRow dr in inTable.Rows)
            {
                result.AddNew(System.Reflection.Missing.Value,
                              System.Reflection.Missing.Value);

                for (int columnIndex = 0; columnIndex < inColumns.Count; columnIndex++)
                {
                    resultFields[columnIndex].Value = dr[columnIndex];
                }
            }

            return result;
        }
        private ADODB.DataTypeEnum TranslateType(Type columnType)
        {
            switch (columnType.UnderlyingSystemType.ToString())
            {
                case "System.Boolean":
                    return ADODB.DataTypeEnum.adBoolean;

                case "System.Byte":
                    return ADODB.DataTypeEnum.adUnsignedTinyInt;

                case "System.Char":
                    return ADODB.DataTypeEnum.adChar;

                case "System.DateTime":
                    return ADODB.DataTypeEnum.adDate;

                case "System.Decimal":
                    return ADODB.DataTypeEnum.adCurrency;

                case "System.Double":
                    return ADODB.DataTypeEnum.adDouble;

                case "System.Int16":
                    return ADODB.DataTypeEnum.adSmallInt;

                case "System.Int32":
                    return ADODB.DataTypeEnum.adInteger;

                case "System.Int64":
                    return ADODB.DataTypeEnum.adBigInt;

                case "System.SByte":
                    return ADODB.DataTypeEnum.adTinyInt;

                case "System.Single":
                    return ADODB.DataTypeEnum.adSingle;

                case "System.UInt16":
                    return ADODB.DataTypeEnum.adUnsignedSmallInt;

                case "System.UInt32":
                    return ADODB.DataTypeEnum.adUnsignedInt;

                case "System.UInt64":
                    return ADODB.DataTypeEnum.adUnsignedBigInt;

                case "System.String":
                default:
                    return ADODB.DataTypeEnum.adVarChar;
            }
        }
        public bool AreAllValidNumericChars(string str)
        {
            bool ret = true;
                if (str == System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyGroupSeparator |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.CurrencySymbol |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.NegativeSign |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.NegativeInfinitySymbol |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.PercentDecimalSeparator |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.PercentGroupSeparator |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.PercentSymbol |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.PerMilleSymbol |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.PositiveInfinitySymbol |
                    str == System.Globalization.NumberFormatInfo.CurrentInfo.PositiveSign)
                    return ret;
            int l = str.Length;
            for (int i = 0; i < l; i++)
            {
                char ch = str[i];
                ret &= Char.IsDigit(ch);
            }
            return ret;
        }

    }

}
