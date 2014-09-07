using Midway_Assessment.BusinessLogicLayer;
using Midway_Assessment.UICommonFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Midway_Assessment.WebPages
{
    public partial class MaintenanceWorks : System.Web.UI.Page
    {
        string maintenanceWorksFilePath = string.Empty;
        string equipmentFilePath = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            maintenanceWorksFilePath = Request.MapPath(@"~\Database\MaintenanceWorks.csv");
            equipmentFilePath = Request.MapPath(@"~\Database\Equipment.csv");
        
            if (!IsPostBack)
            {
                fillEquipmentCombo();

                BindGrid();
            }
            
        }
        /// <summary>
        /// Bind grid with data from 'MaintenanceWork' file.
        /// </summary>
        private void BindGrid()
        {
            EquipmentMaintenanceBL objEquipmentMaintenance = new EquipmentMaintenanceBL(maintenanceWorksFilePath, Request.MapPath(@"~\Database\Equipment.csv"));
            try
            {
                DataTable dtEquipmentMaintenace = objEquipmentMaintenance.SelectAllData();
                gvEquipmentMaintenance.DataSource = dtEquipmentMaintenace;
                gvEquipmentMaintenance.DataBind();
            }
            catch(Exception ex)
            {
                throwException(ex.Message);
            }
        }
        /// <summary>
        /// Populate list box with 'Select one' as an entry.
        /// </summary>
        void fillEquipmentCombo()
        {
            try
            {
                EquipmentBL objEquipBL = new EquipmentBL(Request.MapPath(@"~\Database\Equipment.csv"));
                DataTable dtEquipData = objEquipBL.SelectAllData();

                DataTable dtTemp = dtEquipData.Copy();
                dtTemp.Clear();
                DataRow dRow = dtTemp.NewRow();
                dRow[0] = -1;
                dRow[1] = "Please select";

                dtTemp.Rows.Add(dRow);
                dtTemp.Merge(dtEquipData);

                cmbEquipment.DataSource = dtTemp;
                cmbEquipment.DataTextField = "Name";
                cmbEquipment.DataValueField = "EquipmentId";
                cmbEquipment.DataBind();

            }
            catch (Exception ex)
            {
                throwException(ex.Message);
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
            if (Page.IsValid)
            {
                try
                {
                    EquipmentMaintenanceBL objEquipMaintenanceBL = new EquipmentMaintenanceBL(maintenanceWorksFilePath, equipmentFilePath);
                    AckMessage message = new AckMessage();

                    ClassProperties.EquipmentMaintenance objEquipMaintenance = getEquipmentMaintenanceObject();
                    if (objEquipMaintenanceBL.AddRecord(objEquipMaintenance))
                    {
                        message.Save("Record", Response);
                        BindGrid();
                        clearControls();
                    }
                    else
                    {
                        message.SaveFailed("Record", Response);
                    }
                }
                catch (Exception ex)
                {
                    throwException(ex.Message);
                }
            }
        }
        void clearControls()
        {
            Session.Clear();
            this.cmbEquipment.SelectedIndex = 0;
            this.cmbHour.SelectedIndex = 0;
            this.cmbMinutes.SelectedIndex = 0;
            this.txtDate.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtTimeTaken.Text = string.Empty;
        }
        private ClassProperties.EquipmentMaintenance getEquipmentMaintenanceObject()
        {
            ClassProperties.EquipmentMaintenance objEquipMaintenance = new ClassProperties.EquipmentMaintenance();
            objEquipMaintenance.ObjEquip.ID = int.Parse(this.cmbEquipment.SelectedValue.ToString());

            int timeTaken = -1;
            if (int.TryParse(txtTimeTaken.Text, out timeTaken))
            {
                objEquipMaintenance.TimeTaken = timeTaken;
            }
            else
                objEquipMaintenance.TimeTaken = 0;

            objEquipMaintenance.WorkDate = DateTime.ParseExact(this.txtDate.Text.ToString(), "dd/MM/yyyy",null);
            objEquipMaintenance.WorkTime = this.cmbHour.SelectedValue.ToString()+":"+this.cmbMinutes.SelectedValue.ToString();
            objEquipMaintenance.Description = txtDescription.Text.Trim();

            return objEquipMaintenance;
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    EquipmentMaintenanceBL objEquipMaintenanceBL = new EquipmentMaintenanceBL(maintenanceWorksFilePath, equipmentFilePath);
                    AckMessage message = new AckMessage();
                    ClassProperties.EquipmentMaintenance objEquipMaintenance = getEquipmentMaintenanceObject();
                    objEquipMaintenance.ID = int.Parse(Session["MaintenanceWorkID"].ToString());
                    if (objEquipMaintenanceBL.UpdateRecord(objEquipMaintenance))
                    {
                        message.Update("The record", Response);
                        BindGrid();
                        clearControls();
                    }
                    else
                    {
                        message.UpdateFailed("The record", Response);
                    }
                }
                catch (Exception ex)
                {
                    throwException(ex.Message);
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {

                    EquipmentMaintenanceBL objEquipMaintenanceBL = new EquipmentMaintenanceBL(maintenanceWorksFilePath, equipmentFilePath);
                    AckMessage message = new AckMessage();

                    if (objEquipMaintenanceBL.DeleteRecord(int.Parse(Session["MaintenanceWorkID"].ToString())))
                    {
                        message.Delete("The record", Response);
                        BindGrid();
                        clearControls();
                    }
                    else
                    {
                        message.DeleteFailed("The record", Response);
                    }
                }
                catch (Exception ex)
                {
                    throwException(ex.Message);
                }
            }

        }

        protected void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        protected void gvEquipMaintenance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvEquipmentMaintenance.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvEquipMaintenace_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateControls(gvEquipmentMaintenance.SelectedIndex);
        }
        void populateControls(int selectedRowNumber)
        {
            try
            {
                Session["MaintenanceWorkID"] = this.gvEquipmentMaintenance.DataKeys[selectedRowNumber][0].ToString();
                this.cmbEquipment.SelectedValue = this.gvEquipmentMaintenance.DataKeys[selectedRowNumber][1].ToString();

                this.txtDate.Text = this.gvEquipmentMaintenance.Rows[selectedRowNumber].Cells[4].Text;

                string[] time = this.gvEquipmentMaintenance.Rows[selectedRowNumber].Cells[5].Text.Split(':');

                this.cmbHour.SelectedValue = time[0].PadLeft(2,'0');
                this.cmbMinutes.SelectedValue = time[1].PadLeft(2,'0');

                this.txtTimeTaken.Text = this.gvEquipmentMaintenance.Rows[selectedRowNumber].Cells[6].Text;
                this.txtDescription.Text = this.gvEquipmentMaintenance.Rows[selectedRowNumber].Cells[7].Text.Replace("&nbsp;", "");
            }
            catch (Exception ex)
            {
                throwException(ex.Message);
            }
        }

        protected void Update_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Session["MaintenanceWorkID"] != null)
            {

                args.IsValid = true;
                this.ValidationSummary_Update.Visible = true;
            }
            else
            {
                args.IsValid = false;
                this.Update.Text = "Please select a record to update.";
                this.ValidationSummary_Update.Visible = false;
            }
        }

        //protected void EquipmentValidator_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    if (cmbEquipment.SelectedIndex > 0)
        //    {
        //        args.IsValid = true;
        //    }
        //    else
        //    {
        //        args.IsValid = false;
        //    }
        //}

        //protected void HourValidator_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    if (this.cmbHour.SelectedIndex > 0)
        //    {
        //        args.IsValid = true;
        //    }
        //    else
        //    {
        //        args.IsValid = false;
        //    }
        //}

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            ;
        }

        protected void Delete_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Session["MaintenanceWorkID"] != null)
            {

                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
                this.Delete.Text = "Please select a record to delete.";
            }
        }
    }
}