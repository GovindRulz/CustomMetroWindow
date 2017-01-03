using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;

namespace CustomMetroWindow
{
    public static class HorizonMainClass
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public static string ConString = "";
        public static bool WebClient = true;
        public static string URL = "http://localhost:4652/api/";
        public static DataStructs.SoftwareInfo SftInfo = new DataStructs.SoftwareInfo();
        public static DataStructs.Company CompanyInfo = new DataStructs.Company();
        public static DataStructs.CompanyConf CompanyConfig = new DataStructs.CompanyConf();
        public static DataStructs.UserSplRights UserSplRights = new DataStructs.UserSplRights();
        public static DataStructs.CurrentUser UserInfo = new DataStructs.CurrentUser();

        public static void sendShiftTab()
        {
            keybd_event(0x10, 0, 0, 0); //SHIFT KEY DOWN
            keybd_event(0x09, 0, 0, 0); //TAB KEY DOWN
            keybd_event(0x09, 0, 2, 0); //TAB KEY UP
            keybd_event(0x10, 0, 2, 0); //SHIFT KEY UP 
        }
    }
}