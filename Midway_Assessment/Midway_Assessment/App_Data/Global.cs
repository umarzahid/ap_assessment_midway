using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Midway_Assessment
{
    public  class Global : System.Web.UI.Page
    {

        public string EquipmentFilePath
        {
            get
            {
                return Request.MapPath(@"~\Database\Equipment.csv");

            }
        }
        public string EquipmentMaintenanceFilePath
        {
            get
            {
                return Request.MapPath(@"~\Database\MaintenanceWorks.csv");
        
            }
        }
    }
}