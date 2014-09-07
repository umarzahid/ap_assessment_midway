﻿using Midway_Assessment.BusinessLogicLayer;
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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                maintenanceWorksFilePath = Request.MapPath(@"~\Database\MaintenanceWorks.csv");
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

            DataTable dtEquipmentMaintenace = objEquipmentMaintenance.SelectAllData();
            gvEquipmentMaintenance.DataSource = dtEquipmentMaintenace;
            gvEquipmentMaintenance.DataBind();
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
                lblEquipName.Text = "OK";
            }
            else
            {
                lblEquipName.Text = "Not OK";
            }
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

        protected void gvEquipMaintenance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvEquipmentMaintenance.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvEquipMaintenace_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void UpdateDelete_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }

        protected void validatorEquipment_ServerValidate(object source, ServerValidateEventArgs args)
        {
         
        }

        protected void EquipmentValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cmbEquipment.SelectedIndex > 0)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void HourValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (this.cmbHour.SelectedIndex > 0)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            ;
        }
    }
}