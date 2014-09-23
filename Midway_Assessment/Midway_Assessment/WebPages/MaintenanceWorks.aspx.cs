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
    public partial class MaintenanceWorks : Global
    {
       // string maintenanceWorksFilePath = string.Empty;
       // string equipmentFilePath = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
        //    maintenanceWorksFilePath = Request.MapPath(@"~\Database\MaintenanceWorks.csv");
          //  equipmentFilePath = Request.MapPath(@"~\Database\Equipment.csv");
        
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
            try
            {
                EquipmentMaintenanceBL objEquipmentMaintenaceBL = new EquipmentMaintenanceBL(EquipmentMaintenanceFilePath,EquipmentFilePath);
                gvEquipmentMaintenance.DataSource = objEquipmentMaintenaceBL.SelectAllData();
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
                EquipmentBL objEquipBL = new EquipmentBL(EquipmentFilePath);
                List<ClassProperties.Equipment> objEquipColl = objEquipBL.SelectAllData();

                ClassProperties.Equipment objEquip = new ClassProperties.Equipment();
                objEquip.ID =-1;
                objEquip.Name = "Please Select";

                objEquipColl.Insert(0, objEquip);

                cmbEquipment.DataSource = objEquipColl;
                cmbEquipment.DataTextField = "Name";
                cmbEquipment.DataValueField = "ID";
                cmbEquipment.DataBind();

            }
            catch (Exception ex)
            {
                throwException(ex.Message);
            }
        }
        void throwException(string exception)
        {

            acknowledgementBox.InnerText = "<p class='text-danger'> " + exception + " </p>";

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AckMessage message = new AckMessage();
            message.Clear(acknowledgementBox);
            if (Page.IsValid)
            {
                try
                {
                    EquipmentMaintenanceBL objEquipMaintenanceBL = new EquipmentMaintenanceBL(EquipmentMaintenanceFilePath, EquipmentFilePath);
                
                    ClassProperties.EquipmentMaintenance objEquipMaintenance = getEquipmentMaintenanceObject();
                    if (objEquipMaintenanceBL.AddRecord(objEquipMaintenance))
                    {
                        message.Save("Record", acknowledgementBox);
                        BindGrid();
                        clearControls();
                    }
                    else
                    {
                        message.SaveFailed("Record", acknowledgementBox);
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

            objEquipMaintenance.Date = DateTime.ParseExact(this.txtDate.Text.ToString(), "d/MM/yyyy",null);
            objEquipMaintenance.Time = this.cmbHour.SelectedValue.ToString()+":"+this.cmbMinutes.SelectedValue.ToString();
            objEquipMaintenance.WorksDescription = txtDescription.Text.Trim();

            return objEquipMaintenance;
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            AckMessage message = new AckMessage();
            message.Clear(acknowledgementBox);
            if (Page.IsValid)
            {
                try
                {
                    EquipmentMaintenanceBL objEquipMaintenanceBL = new EquipmentMaintenanceBL(EquipmentMaintenanceFilePath, EquipmentFilePath);
                   
                    ClassProperties.EquipmentMaintenance objEquipMaintenance = getEquipmentMaintenanceObject();
                    objEquipMaintenance.MaintenanceWorkId = int.Parse(Session["MaintenanceWorkID"].ToString());
                    if (objEquipMaintenanceBL.UpdateRecord(objEquipMaintenance))
                    {
                        message.Update("The record", acknowledgementBox);
                        BindGrid();
                        clearControls();
                    }
                    else
                    {
                        message.UpdateFailed("The record", acknowledgementBox);
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
            AckMessage message = new AckMessage();
            message.Clear(acknowledgementBox);
            if (Page.IsValid)
            {
                try
                {

                    EquipmentMaintenanceBL objEquipMaintenanceBL = new EquipmentMaintenanceBL(EquipmentMaintenanceFilePath, EquipmentFilePath);
                 
                    if (objEquipMaintenanceBL.DeleteRecord(int.Parse(Session["MaintenanceWorkID"].ToString())))
                    {
                        message.Delete("The record", acknowledgementBox);
                        BindGrid();
                        clearControls();
                    }
                    else
                    {
                        message.DeleteFailed("The record", acknowledgementBox);
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
            AckMessage message = new AckMessage();
            message.Clear(acknowledgementBox);
            populateControls(gvEquipmentMaintenance.SelectedIndex);
        }
        void populateControls(int selectedRowNumber)
        {
            try
            {
                Session["MaintenanceWorkID"] = this.gvEquipmentMaintenance.DataKeys[selectedRowNumber][0].ToString();
                this.cmbEquipment.SelectedValue = ((Label)this.gvEquipmentMaintenance.Rows[selectedRowNumber].FindControl("lblEquipmentID")).Text;

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