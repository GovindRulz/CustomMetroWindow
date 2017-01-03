using System;
using System.Data;
using System.ComponentModel;
//using System.Windows.Forms;
//using System.Windows.Forms;
using System.Net;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;

namespace CustomMetroWindow
{
    public abstract class ViewModelClass : INotifyPropertyChanged
    {

        private string _SaveMode = "SAVE";
        private int _UserId = 1;//HorizonMainClass.UserInfo.UserId;
        private string _MachineName = ""; //HorizonMainClass.UserInfo.MachineName;
        private bool _IsDelete = false;
        private bool _EditableFlg = true;
        private bool _DataValidated = false;
        private bool _WebClient = HorizonMainClass.WebClient;
        private string _DbProcName = string.Empty;
       

        public event PropertyChangedEventHandler PropertyChanged;

        [ObjectPropertyAttributes("@SaveMode", SqlDbType.NVarChar)]
        public string SaveMode { get { return _SaveMode; } set { _SaveMode = value; OnPropertyChanged("SaveMode"); } }
        [ObjectPropertyAttributes("@UserId", SqlDbType.Int)]
        public int UserId { get { return _UserId; } set { _UserId = value; OnPropertyChanged("UserId"); } }
        [ObjectPropertyAttributes("@MachineName", SqlDbType.NVarChar)]
        public string MachineName { get { return _MachineName; } set { _MachineName = value; OnPropertyChanged("MachineName"); } }
        //[ScriptIgnore]       
        public bool IsDelete { get { return _IsDelete; } set { _IsDelete = value; OnPropertyChanged("IsDelete"); } }
        //[ScriptIgnore]
        public bool DataValidated { get { return _DataValidated; } set { _DataValidated = value; OnPropertyChanged("DataValidated"); } }
        public bool EditableFlg { get { return _EditableFlg; } set { _EditableFlg = value; OnPropertyChanged("EditableFlg"); } }
        //[ScriptIgnore][ObjectPropertyAttributes("DbProcName")]
        public string DbProcName { get { return _DbProcName; } set { _DbProcName = value; OnPropertyChanged("DbProcName"); } }
        protected string UserAccessLevel = string.Empty;
        protected string ControlerName = string.Empty;

        //protected string DbProcName = "FULLRIGHTS";

        protected FetchData GetData;// = new FetchData(ControlerName);
        protected HUtil Util = new HUtil();
        protected abstract void ValidateData(string PropertyName);
        public bool Save()
        {
            bool retVal = false;
            SaveData Save = new SaveData();
            try
            {
                //ReCalculateSlno();
                if (this.DataValidated == true)
                {
                    if (IsDelete == true) { this.SaveMode = "DELETE"; }
                    if (Util.ValidateRights(UserAccessLevel, this.SaveMode) == true)
                    {
                        if (_WebClient == false)
                        {
                            Save.SaveObjectToDataBase(this);
                            retVal = true;
                        }
                        else
                        {
                            try
                            {
                                retVal = SaveService();
                                //retVal = true;
                            }
                            catch (Exception Ex)
                            {
                                throw;
                            }
                        }
                    }
                    else { throw new Exception("Insufficient Rights"); }
                }
                else { throw new Exception("Please Check Inputed Data");}
            }
            catch (Exception Ex)
            {
                if (Ex.Message.ToString().Substring(0, 2) == "##")
                {
                    throw new Exception(Ex.Message.ToString());
                }
                else
                {
                    Util.ErrLogger(Ex.Message.ToString(), this.GetType().FullName.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return false;
                }
            }
            return retVal;
        }
        protected void OnPropertyChanged(string name)
        {
            
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
            ValidateData(name);
        }
        private bool SaveService()
        {
            bool reulst = false;
            var urii = new Uri(HorizonMainClass.URL + ControlerName +"/" + DbProcName);
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = 2147483644;
            string SerilizeData = js.Serialize(this);
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(urii);
                webRequest.Method = "POST";
                webRequest.Timeout = 500000;
                webRequest.ContentType = "application/json";
                byte[] byteArray = Encoding.UTF8.GetBytes(SerilizeData);
                webRequest.ContentLength = byteArray.Length;
                using (StreamWriter requestWriter2 = new StreamWriter(webRequest.GetRequestStream()))
                {
                    requestWriter2.Write(SerilizeData);
                }
                HttpWebResponse respnse = (HttpWebResponse)webRequest.GetResponse();
                using (StreamReader responseReader = new StreamReader(respnse.GetResponseStream()))
                {
                    string Ret = responseReader.ReadToEnd();
                    reulst = true;
                    //reulst = 
                }
            }
            catch (WebException ex)
            {
                //JavaScriptSerializer js = new JavaScriptSerializer();
                using (StreamReader responseReader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    string data = responseReader.ReadToEnd();
                    Util.ErrLogger(data, this.GetType().FullName.ToString() + ":" + System.Reflection.MethodBase.GetCurrentMethod().Name); //, "frmEmployee.KeyPressHandler");
                }
            }
            return reulst;
        }
    }
}
