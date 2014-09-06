using Midway_Assessment.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Midway_Assessment.WebPages
{
    public partial class MaintenanceWorks : System.Web.UI.Page
    {
        string maintenanceWorksFilePath = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            maintenanceWorksFilePath = Request.MapPath(@"~\Database\MaintenanceWorks.csv");
        }
        void fillEquipmentCombo()
        {
            try
            {
                EquipmentMaintenanceBL objEquipmentMaintenance = new EquipmentMaintenanceBL(maintenanceWorksFilePath);
            }
            catch (Exception ex)
            { 
            
            }
        }
        void throwException(string exception)
        {

            Response.Write("<h2>Error</h2>\n");
            Response.Write("<p>" + exception + "</p>\n");
            Response.Write("==========================================");

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}