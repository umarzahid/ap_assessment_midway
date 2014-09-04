<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipment.aspx.cs" Inherits="Midway_Assessment.WebPages.Equipment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            height: 23px;
            width: 132px;
        }
        .auto-style3 {
            width: 132px;
        }
    </style>
</head>
<body>
    <h1>Equipment</h1>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:200px; margin-bottom:10px;">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">
                    <asp:ValidationSummary ID="vsEquimentErorMessage" runat="server" ForeColor="Red" ValidationGroup="emptyValidator" />
                </td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblEquipName" runat="server">Name</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEquipName" runat="server" Height="25px" Width="336px" OnTextChanged="txtEquipName_TextChanged"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="valEquipName" runat="server" ControlToValidate="txtEquipName" ErrorMessage="Equipment name is required." ForeColor="Red" ValidationGroup="emptyValidator" Width="206px">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="89px" Height="34px" OnClick="btnAdd_Click" ValidationGroup="emptyValidator" />
&nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" Width="89px" Height="34px" ValidationGroup="emptyValidator" />
&nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete" Width="89px" OnClick="btnDelete_Click" Height="34px" ValidationGroup="emptyValidator" />
&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
        <asp:GridView ID="gvEquipment" AutoGenerateColumns="False" AllowPaging="true" CellPadding="5" CellSpacing="5" HeaderStyle-BackColor="Brown" HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="Gainsboro" runat="server" HorizontalAlign="Left" Width="307px" PageSize="5" OnPageIndexChanging="gvEquipment_PageIndexChanging" >
         <PagerStyle HorizontalAlign="Center" />
               <AlternatingRowStyle BackColor="Gainsboro" />
            <Columns>
                <asp:BoundField AccessibleHeaderText="Name" DataField="name" HeaderText="Name" SortExpression="name" />
            </Columns>
            <HeaderStyle BackColor="Brown" ForeColor="White" />
        </asp:GridView>
    </form>
</body>
</html>
