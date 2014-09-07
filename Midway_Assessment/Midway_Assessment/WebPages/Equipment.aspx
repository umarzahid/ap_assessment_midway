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
    <link  href="../Style/Site.css" rel="stylesheet" type="text/css" />
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Equipment</h2>
    <form id="form1" runat="server">
    <div>
    
        <table >
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">
                    &nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblEquipName" CssClass="label-style" runat="server" Font-Bold="True" Font-Overline="False" Font-Strikeout="False">Name</asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtEquipName" CssClass="textbox-style" runat="server" Height="25px" Width="336px" OnTextChanged="txtEquipName_TextChanged" ValidationGroup="DataValidator"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:CustomValidator ID="validatorAdd" runat="server" CssClass="validator-style" ErrorMessage="Error Message" ForeColor="Red" OnServerValidate="validatorAdd_ServerValidate" Display="Dynamic" ValidationGroup="Add">Error Message</asp:CustomValidator>
                    <asp:CustomValidator ID="validatorUpdate" runat="server" CssClass="validator-style" ErrorMessage="Error Message" ForeColor="Red" OnServerValidate="validatorUpdate_ServerValidate" Display="Dynamic" ValidationGroup="Update">Error Message</asp:CustomValidator>
                    <asp:CustomValidator ID="validatorDelete" runat="server" CssClass="validator-style" ErrorMessage="Error Message" ForeColor="Red" OnServerValidate="validatorDelete_ServerValidate" Display="Dynamic" ValidationGroup="Delete">Error Message</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style8">
                    <asp:Button ID="btnAdd" runat="server" CssClass="button-style" Text="Add" OnClick="btnAdd_Click" ValidationGroup="Add" />
&nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button-style"   ValidationGroup="Update" OnClick="btnUpdate_Click" />
&nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete"  OnClick="btnDelete_Click" CssClass="button-style" ValidationGroup="Delete" OnClientClick="return ConfirmDelete()" />
&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
        <asp:GridView ID="gvEquipment" AutoGenerateColumns="False" DataKeyNames="EquipmentId" AllowPaging="True" CellPadding="5" CellSpacing="5" HeaderStyle-BackColor="Brown" HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="Gainsboro" runat="server" HorizontalAlign="Left"  Width="100%" PageSize="15" OnPageIndexChanging="gvEquipment_PageIndexChanging" OnSelectedIndexChanged="gvEquipment_SelectedIndexChanged" AutoGenerateSelectButton="True">
         <PagerStyle HorizontalAlign="Center" />
               <AlternatingRowStyle BackColor="Gainsboro" />
            <Columns>
                <asp:BoundField DataField="EquipmentId" Visible="False" />
                <asp:BoundField AccessibleHeaderText="Name" DataField="name" HeaderText="Name" SortExpression="name" />
            
            </Columns>
            <HeaderStyle BackColor="Brown" ForeColor="White" />
            
        </asp:GridView>
    </form>
</asp:Content>
    