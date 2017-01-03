using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CustomMetroWindow
{
    class ObjectPropertyAttributes:System.Attribute
    {
        public readonly string DbProcdName = string.Empty;
        public readonly string DbProcFieldName= string.Empty;
        public readonly SqlDbType  DbProcFieldType;
        public readonly string DbProcFieldTypeName;
        public readonly ParameterDirection DbProcParameterDirection;
        public ObjectPropertyAttributes()
        {
            this.DbProcFieldName = "NA";
        }
        public ObjectPropertyAttributes(string _DbProcdName)
        {
            this.DbProcdName = _DbProcdName;
        }
        public ObjectPropertyAttributes(string _DbProcFieldName, SqlDbType _DbProcFieldType)
        {
            this.DbProcFieldName = _DbProcFieldName;
            this.DbProcFieldType = _DbProcFieldType;
        }
        public ObjectPropertyAttributes(string _DbProcFieldName, SqlDbType _DbProcFieldType
            , string _DbProcFieldTypeName,ParameterDirection _DbProcParameterDirection)
        {
            this.DbProcFieldName = _DbProcFieldName;
            this.DbProcFieldType = _DbProcFieldType;
            this.DbProcFieldTypeName = _DbProcFieldTypeName;
            this.DbProcParameterDirection = _DbProcParameterDirection;
        }

    }
}
