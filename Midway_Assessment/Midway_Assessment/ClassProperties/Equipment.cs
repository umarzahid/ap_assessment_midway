using System;
using System.Collections.Generic;
using System.Linq;
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
        
    }
}