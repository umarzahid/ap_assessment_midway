using Midway_Assessment.BusinessLogicLayer;
using Midway_Assessment.UICommonFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Midway_Assessment.WebPages
{
    public partial class Equipment : Global
    {
        //string equipmentFilePath = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
         //   equipmentFilePath = Request.MapPath(@"~\Database\Equipment.csv");
           
            if (!IsPostBack)
            {
                try
                {

                    BindGrid();

                }
                catch (Exception ex)
                {
                    throwException(ex.Message);
                }
            }
        }

        private void BindGrid()
        {
            EquipmentBL objEquipBL = new EquipmentBL(EquipmentFilePath);
            gvEquipment.DataSource = objEquipBL.SelectAllData();
            gvEquipment.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            AckMessage message = new AckMessage();
            message.Clear(acknowledgementBox);
            if (Page.IsValid)
            {
                try
                {
                    if (Session["EquipmentID"] != null)
                    {

                    }
                    else
                    { 
                    
                    }
                    EquipmentBL objEquipBL = new EquipmentBL(EquipmentFilePath);
                    
                    if (objEquipBL.DeleteRecord(int.Parse(Session["EquipmentID"].ToString())))
                    {
                        message.Delete(this.txtEquipName.Text.Trim(), acknowledgementBox);
                        BindGrid();
                        clearControls();
                    }
                    else
                    {
                        message.DeleteFailed(this.txtEquipName.Text.Trim(), acknowledgementBox);
                    }
                }
                catch (Exception ex)
                {
                    throwException(ex.Message);
                }
            }

        }

        void throwException( string exception)
        {

            //Response.Write("<h2>Error</h2>\n");
            //Response.Write("<p>"+exception+"</p>\n");
            //Response.Write("==========================================");

            
            acknowledgementBox.InnerText = "<p class='text-danger'> "+exception+" </p>";
            
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AckMessage message = new AckMessage();
            message.Clear(acknowledgementBox);
            if (Page.IsValid)
            {
                try
                {
                    EquipmentBL objEquipBL = new EquipmentBL(EquipmentFilePath);
                 
                    ClassProperties.Equipment objEquip = getEquipmentObject();
                    if (objEquipBL.AddRecord(objEquip))
                    {
                        message.Save(objEquip.Name,acknowledgementBox);
                        BindGrid();
                        clearControls();
                    }
                    else
                    {
                        message.SaveFailed(objEquip.Name, acknowledgementBox);
                    }
                }
                catch (Exception ex)
                {
                    throwException(ex.Message);
                }
            }
        }

        private ClassProperties.Equipment getEquipmentObject()
        {
            ClassProperties.Equipment objEquip = new  ClassProperties.Equipment();
            objEquip.Name = this.txtEquipName.Text.Trim();
            return objEquip;
        }

        protected void txtEquipName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void gvEquipment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEquipment.PageIndex = e.NewPageIndex;
            BindGrid();
            
        }

        

        protected void uniqueValidator_Update_ServerValidate(object source, ServerValidateEventArgs args)
        {
        }

        protected void gvEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            AckMessage ackMessage = new AckMessage();
            ackMessage.Clear(acknowledgementBox);

            populateControls(this.gvEquipment.SelectedIndex);
        }

        void populateControls(int selectedRowNumber)
        {
           Session["EquipmentID"] = this.gvEquipment.DataKeys[selectedRowNumber].Value.ToString();
           this.txtEquipName.Text = this.gvEquipment.SelectedRow.Cells[2].Text;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            AckMessage message = new AckMessage();
            message.Clear(acknowledgementBox);

            if (Page.IsValid)
            {
                try
                {
                    EquipmentBL objEquipBL = new EquipmentBL(EquipmentFilePath);
                    ClassProperties.Equipment objEquip = getEquipmentObject();
                    objEquip.ID = int.Parse(Session["EquipmentID"].ToString());
                    if (objEquipBL.UpdateRecord(objEquip))
                    {
                        message.Update(objEquip.Name, acknowledgementBox);
                        BindGrid();
                        clearControls();
                    }
                    else
                    {
                        message.UpdateFailed(objEquip.Name, acknowledgementBox);
                    }
                }
                catch (Exception ex)
                {
                    throwException(ex.Message);
                }
            }
        }

        protected void validatorAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(this.txtEquipName.Text.Trim()))
            {
                EquipmentBL objEquipmentBL = new EquipmentBL(EquipmentFilePath);
                if (objEquipmentBL.AlreadyExists_NewRecord(txtEquipName.Text.Trim()))
                {

                    args.IsValid = false;
                    this.validatorAdd.Text = "Please enter a unique name.";
                }
                else
                {

                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = false;
                this.validatorAdd.Text = "Equipment name is mandatory.";
            }
        }

        protected void validatorUpdate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Session["EquipmentID"] != null)
            {
                EquipmentBL objEquipmentBL = new EquipmentBL(EquipmentFilePath);
                int equipmentID = -1;
            
                int.TryParse(Session["EquipmentID"].ToString(), out equipmentID);
                if (objEquipmentBL.AlreadyExists_Update(txtEquipName.Text.Trim(), equipmentID))
                {
                    args.IsValid = false;
                    this.validatorUpdate.Text = "Record already exists. Please choose different name.";
                }
                else
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = false;
                this.validatorUpdate.Text = "Please select a record to update.";
            }

        }

        protected void validatorDelete_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Session["EquipmentID"] != null)
            {

                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
                this.validatorDelete.Text = "Please select a record to delete.";
            }

        }

        void clearControls()
        {
            this.txtEquipName.Text = string.Empty;
            Session.Clear();
        }

    }
}