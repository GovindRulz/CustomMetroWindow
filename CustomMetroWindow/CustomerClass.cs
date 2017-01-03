using System;
using System.Data;

namespace CustomMetroWindow
{
    public class CustomerClass : ViewModelClass
    {
        private int _CustomerId = 0;
        private string _CustomerName = string.Empty;
        private string _Address1 = string.Empty;
        private string _Address2 = string.Empty;
        private string _Address3 = string.Empty;
        private string _Address4 = string.Empty;
        private string _Phone1 = string.Empty;
        private string _Phone2 = string.Empty;
        private string _Phone3 = string.Empty;
        private int _DistrictId = 1;
        private int _StateId = 1;
        private int _CategoryId = 1;

        private string _District = string.Empty;
        private string _State = string.Empty;
        private string _Category = string.Empty;

        private DateTime _ActivitaionDate = DateTime.Now;
        private int _EnquiryId = 1;
        private string _ListName = string.Empty;

        //[ScriptIgnore][ObjectPropertyAttributes("SaveCustomer")]
        //public string DbProcName { get { return "SaveCustomer"; } }
        [ObjectPropertyAttributes("@CustomerId", SqlDbType.Int)]
        public int CustomerId { get { return _CustomerId; } set { _CustomerId = value; OnPropertyChanged("CustomerId"); } }
        [ObjectPropertyAttributes("@CustomerName", SqlDbType.NVarChar)]
        public string CustomerName { get { return _CustomerName; } set { _CustomerName = value; OnPropertyChanged("CustomerName"); } }
        [ObjectPropertyAttributes("@Address1", SqlDbType.NVarChar)]
        public string Address1 { get { return _Address1; } set { _Address1 = value; OnPropertyChanged("Address1"); } }
        [ObjectPropertyAttributes("@Address2", SqlDbType.NVarChar)]
        public string Address2 { get { return _Address2; } set { _Address2 = value; OnPropertyChanged("Address2"); } }
        [ObjectPropertyAttributes("@Address3", SqlDbType.NVarChar)]
        public string Address3 { get { return _Address3; } set { _Address3 = value; OnPropertyChanged("Address3"); } }
        [ObjectPropertyAttributes("@Address4", SqlDbType.NVarChar)]
        public string Address4 { get { return _Address4; } set { _Address4 = value; OnPropertyChanged("Address4"); } }
        [ObjectPropertyAttributes("@Phone1", SqlDbType.NVarChar)]
        public string Phone1 { get { return _Phone1; } set { _Phone1 = value; OnPropertyChanged("Phone1"); } }
        [ObjectPropertyAttributes("@Phone2", SqlDbType.NVarChar)]
        public string Phone2 { get { return _Phone2; } set { _Phone2 = value; OnPropertyChanged("Phone2"); } }
        [ObjectPropertyAttributes("@Phone3", SqlDbType.NVarChar)]
        public string Phone3 { get { return _Phone3; } set { _Phone3 = value; OnPropertyChanged("Phone3"); } }
        [ObjectPropertyAttributes("@DistrictId", SqlDbType.Int)]
        public int DistrictId { get { return _DistrictId; } set { _DistrictId = value; OnPropertyChanged("DistrictId"); } }
        [ObjectPropertyAttributes("@StateId", SqlDbType.Int)]
        public int StateId { get { return _StateId; } set { _StateId = value; OnPropertyChanged("StateId"); } }
        [ObjectPropertyAttributes("@CategoryId", SqlDbType.Int)]
        public int CategoryId { get { return _CategoryId; } set { _CategoryId = value; OnPropertyChanged("CategoryId"); } }
        [ObjectPropertyAttributes("@ActivitaionDate", SqlDbType.DateTime)]
        public DateTime ActivitaionDate { get { return _ActivitaionDate; } set { _ActivitaionDate = value; OnPropertyChanged("ActivitaionDate"); } }
        [ObjectPropertyAttributes("@EnquiryId", SqlDbType.Int)]
        public int EnquiryId { get { return _EnquiryId; } set { _EnquiryId = value; OnPropertyChanged("EnquiryId"); } }
        [ObjectPropertyAttributes("@ListName", SqlDbType.NVarChar)]
        public string ListName { get { return Util.Listname(CustomerName); }}

        public string District { get { return _District; } set { _District = value; OnPropertyChanged("District"); } }
        public string State { get { return _State; } set { _State = value; OnPropertyChanged("State"); } }
        public string Category { get { return _Category; } set { _Category = value; OnPropertyChanged("Category"); } }

        public CustomerClass()
        {
            DbProcName = "SaveCustomer";
            ControlerName = "Customer";
            UserAccessLevel = "FULLRIGHTS";
            
            GetData = new FetchData(ControlerName);
        }

        protected override void ValidateData(string PropertyName)
        {
            switch (PropertyName)
            {
                case "CustomerName": DataValidated = (CustomerName == string.Empty) ? false : true; break;
                case "EnquiryId": DataValidated = (EnquiryId == 0) ? false : true; break;
            }
        }
        

    }
}