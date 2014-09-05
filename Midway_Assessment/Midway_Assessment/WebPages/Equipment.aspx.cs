using Midway_Assessment.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Midway_Assessment.WebPages
{
    public partial class Equipment : System.Web.UI.Page
    {
        string equipmentFilePath = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                equipmentFilePath= Request.MapPath(@"~\Database\Equipment.csv");
                BindGrid();
            }
            catch (Exception ex)
            {
                ThrowException(ex.Message);
            }
        }

        private void BindGrid()
        {
            EquipmentBL objEquipBL = new EquipmentBL();
            gvEquipment.DataSource = objEquipBL.ReadAllData(equipmentFilePath);
            gvEquipment.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        void ThrowException(string exception)
        {

            Response.Write("<h2>Error Page</h2>\n");
            Response.Write("<p>"+exception+"</p>\n");
            Response.Write("==========================================");
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
           
        }

        protected void txtEquipName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void gvEquipment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEquipment.PageIndex = e.NewPageIndex;
            BindGrid();
            
        }

        
        protected void uniqueValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            EquipmentBL objEquipmentBL = new EquipmentBL();
            if (objEquipmentBL.AlreadyExists_NewRecord(equipmentFilePath, txtEquipName.Text.Trim()))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void uniqueValidator_Update_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //EquipmentBL objEquipmentBL = new EquipmentBL();
            //if (objEquipmentBL.AlreadyExists_Update(equipmentFilePath, txtEquipName.Text.Trim(),1))
            //{
            //    args.IsValid = false;
            //}
            //else
            //{
            //    args.IsValid = true;
            //}

        }

        protected void gvEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateControls();
        }

        void PopulateControls()
        { 
           GridViewRow gridRow = gvEquipment.SelectedRow;
           this.txtEquipName.Text = gridRow.Cells[1].Text;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblEquipName.Text = gvEquipment.SelectedIndex.ToString();
        }
    }
}