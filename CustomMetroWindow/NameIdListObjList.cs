using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CustomMetroWindow
{
    public class NameIdListObjList : List<NameIdListObj>
    {
        public NameIdListObjList() { }
        public NameIdListObjList(DataTable Dt)
        {

            //this.Add(new NameIdListObj(1, "NA", "NA", "NA"));
            if (Dt.Rows.Count > 0)
            {
                var LineSum = from b in Dt.AsEnumerable()
                              select new NameIdListObj
                              {
                                  Id = Convert.ToInt32(b.Field<int>("Id")),
                                  Name = b.Field<string>("Name"),
                                  ListName = b.Field<string>("listName"),
                                  Code = b.Field<string>("Code")
                              };
                this.AddRange((List<NameIdListObj>)LineSum.ToList());
            }
        }
        public NameIdListObjList(IEnumerable<NameIdListObj> collection) : base(collection)
        {
            this.Clear();
            this.AddRange(collection);
        }
    }
    public class NameIdListObj : ViewModelClass
    {
        private int _Id = 0;
        private string _Name = string.Empty;
        private string _ListName = string.Empty;
        private string _Code = string.Empty;

        public int Id { get { return _Id; } set { _Id = value; OnPropertyChanged("Id"); } }
        public string Name { get { return _Name; } set { _Name = value; OnPropertyChanged("Name"); } }
        public string ListName { get { return _ListName; } set { _ListName = value; OnPropertyChanged("ListName"); } }
        public string Code { get { return _Code; } set { _Code = value; OnPropertyChanged("Code"); } }
        public NameIdListObj()
        {
        }
        public NameIdListObj(int _id, string _name, string _listname, string _code)
        {
            this._Id = _id;
            this._Name = _name;
            this._ListName = _listname;
            this._Code = _code;
        }

        protected override void ValidateData(string PropertyName)
        {
            switch (PropertyName)
            {
                
            }
        }
    }
}