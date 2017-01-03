using System;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;



namespace CustomMetroWindow
{
    public class FetchDataWeb
    {
        private string ControlerName = string.Empty;

        public FetchDataWeb(string _ControlerName)
        {
            this.ControlerName = _ControlerName;
        }

        public T FetchService<T> (string ActionName,string ParameterString)//Fetch Data From Wcf
        {

            var Ret = Activator.CreateInstance(typeof(T));//= new <T>object();
            try
            {
                var urii = new Uri(HorizonMainClass.URL + ControlerName + "/" + ActionName + "/" + ParameterString);
                JavaScriptSerializer js = new JavaScriptSerializer();
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(urii);
                webRequest.Method = "GET";
                webRequest.Timeout = -1;
                webRequest.ContentType = "application/json";
                HttpWebResponse respnse = (HttpWebResponse)webRequest.GetResponse();
                using (StreamReader responseReader = new StreamReader(respnse.GetResponseStream()))
                {
                    string data = responseReader.ReadToEnd();
                    Ret = js.Deserialize<T>(data);
                }
            }
            catch (WebException Ex)
            {
                HUtil util = new HUtil();
                util.ErrLogger(Ex.Message, "Fetch");
            }
            return (T)Ret;
        }
    }
}
