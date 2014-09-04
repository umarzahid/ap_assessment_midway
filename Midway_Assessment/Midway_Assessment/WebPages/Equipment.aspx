﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipment.aspx.cs" Inherits="Midway_Assessment.WebPages.Equipment" %>

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
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblEquipName" runat="server">Name</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEquipName" runat="server" Height="25px" Width="407px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="89px" />
&nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" Width="89px" />
&nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete" Width="89px" />
&nbsp;</td>
            </tr>
        </table>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" Height="175px" Width="643px">
        </asp:GridView>
    </form>
</body>
</html>
