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
        .auto-style4 {
            width: 132px;
            height: 42px;
        }
        .auto-style5 {
            height: 42px;
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
                    <asp:ValidationSummary ID="vsEquimentErorMessage" runat="server" ForeColor="Red" ValidationGroup="DataValidator" />
                </td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblEquipName" runat="server" Font-Bold="True" Font-Overline="False" Font-Strikeout="False">Name</asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtEquipName" runat="server" Height="25px" Width="336px" OnTextChanged="txtEquipName_TextChanged" ValidationGroup="DataValidator"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:CustomValidator ID="uniqueValidator_Add" runat="server" ErrorMessage="Please enter unique name only!" ForeColor="Red" OnServerValidate="uniqueValidator_ServerValidate" ValidationGroup="DataValidator">*</asp:CustomValidator>
                    <asp:RequiredFieldValidator ID="valEquipName" runat="server" ControlToValidate="txtEquipName" ErrorMessage="Equipment name is required." ForeColor="Red" ValidationGroup="DataValidator" Width="255px">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="89px" Height="34px" OnClick="btnAdd_Click" ValidationGroup="DataValidator" />
&nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" Width="89px" Height="34px" ValidationGroup="DataValidator" OnClick="btnUpdate_Click" />
&nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete" Width="89px" OnClick="btnDelete_Click" Height="34px" ValidationGroup="emptyValidator" />
&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td colspan="2">
        <asp:GridView ID="gvEquipment" AutoGenerateColumns="False" AllowPaging="True" CellPadding="5" CellSpacing="5" HeaderStyle-BackColor="Brown" HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="Gainsboro" runat="server" HorizontalAlign="Left" Width="100%" PageSize="5" OnPageIndexChanging="gvEquipment_PageIndexChanging" OnSelectedIndexChanged="gvEquipment_SelectedIndexChanged" AutoGenerateSelectButton="True">
         <PagerStyle HorizontalAlign="Center" />
               <AlternatingRowStyle BackColor="Gainsboro" />
            <Columns>
                <asp:BoundField DataField="EquipmentId" Visible="False" />
                <asp:BoundField AccessibleHeaderText="Name" DataField="name" HeaderText="Name" SortExpression="name" />
            
            </Columns>
            <HeaderStyle BackColor="Brown" ForeColor="White" />
            
        </asp:GridView>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
