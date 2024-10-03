using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AnyType
{
    internal class TypeConverter
    {
        public enum Types
        {
            T_CHAR,
            T_STRING,
            T_BYTE,
            T_INT,
            T_FLOAT,
            T_DOUBLE,
            T_DECIMAL,
            T_BOOL,
            T_OBJECT
        }

        //static string[] types = {"char", "string", "byte", "int", "float", "double", "decimal", "bool", "object"};

        public static dynamic ExplicitConvert(string str, Types from, Types to)
        {
            

            //switch (Types)
            //{
            //    case Types.T_CHAR:

            //}

            return 0;
        }
    }
}
