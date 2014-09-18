using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Midway_Assessment.ClassProperties
{
    public class Equipment
    {
        int id;
        string name;

        public Equipment()
        {
            id = -1;
            name = string.Empty;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public override string ToString()
        {
            StringBuilder objString = new StringBuilder();
            objString.Append(id);
            objString.Append(",");
            objString.Append(name);
            return objString.ToString();
        }
        
    }
}