<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipment.aspx.cs" Inherits="Midway_Assessment.WebPages.Equipment" Title="Equipment" MasterPageFile="~/MidwayAssessment.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript">
         function ConfirmDelete() {
             if (confirm("Are you sure you want to delete the record?")) {
                 return true;
             }
             return false;
         }
 </script>
     <style type="text/css">
         .auto-style1 {
             width: 343px;
         }
         .auto-style2 {
             width: 54px;
         }
     </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../Script/bs.pagination.js"></script>
   
     <h2>Equipment</h2>
    <form id="form1" runat="server" class="form-horizontal">
    <div>
    
        <table class="table borderless" >
            <tr>
                <td class="auto-style2" >&nbsp;</td>
                <td class="auto-style1" >
                    &nbsp;</td>
                <td >&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" >
                    <asp:Label ID="lblEquipName" CssClass="label-style" runat="server" Font-Bold="True" Font-Overline="False" Font-Strikeout="False">Name</asp:Label>
                </td>
                <td class="auto-style1" >
                    <asp:TextBox ID="txtEquipName" CssClass="textbox-style" runat="server" Height="25px" Width="336px" OnTextChanged="txtEquipName_TextChanged" ValidationGroup="DataValidator"></asp:TextBox>
                </td>
                <td >
                    <asp:CustomValidator ID="validatorAdd" runat="server" CssClass="validator-style" ErrorMessage="Error Message" ForeColor="Red" OnServerValidate="validatorAdd_ServerValidate" Display="Dynamic" ValidationGroup="Add">Error Message</asp:CustomValidator>
                    <asp:CustomValidator ID="validatorUpdate" runat="server" CssClass="validator-style" ErrorMessage="Error Message" ForeColor="Red" OnServerValidate="validatorUpdate_ServerValidate" Display="Dynamic" ValidationGroup="Update">Error Message</asp:CustomValidator>
                    <asp:CustomValidator ID="validatorDelete" runat="server" CssClass="validator-style" ErrorMessage="Error Message" ForeColor="Red" OnServerValidate="validatorDelete_ServerValidate" Display="Dynamic" ValidationGroup="Delete">Error Message</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" >&nbsp;</td>
                <td class="auto-style1" >
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add" OnClick="btnAdd_Click" ValidationGroup="Add" />
&nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary"   ValidationGroup="Update" OnClick="btnUpdate_Click" />
&nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete"  OnClick="btnDelete_Click" CssClass="btn btn-primary" ValidationGroup="Delete" OnClientClick="return ConfirmDelete()" />
&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>


    
         
    </div>
      <asp:GridView ID="gvEquipment" style="margin-bottom:10%" PagerStyle-CssClass="bs-pagination" CssClass="table" AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="True" CellPadding="5" CellSpacing="5" HeaderStyle-BackColor="Brown" HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="Gainsboro" runat="server" HorizontalAlign="Left"  PageSize="15" OnPageIndexChanging="gvEquipment_PageIndexChanging" OnSelectedIndexChanged="gvEquipment_SelectedIndexChanged" AutoGenerateSelectButton="True">
          <PagerSettings Mode="NumericFirstLast" FirstPageText="First" NextPageText="Next" LastPageText="Last"  PreviousPageText="Previous" />
         <PagerStyle HorizontalAlign="Center" />
               <AlternatingRowStyle BackColor="Gainsboro" />
            <Columns>
                <asp:BoundField DataField="ID" Visible="False" />
                <asp:BoundField AccessibleHeaderText="Name" DataField="name" HeaderText="Name" SortExpression="name" />
            
            </Columns>
            <HeaderStyle BackColor="Brown" ForeColor="White" />
            
        </asp:GridView>
    </form>

</asp:Content>
    