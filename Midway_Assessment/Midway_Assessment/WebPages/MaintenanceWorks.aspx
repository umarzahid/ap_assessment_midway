<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintenanceWorks.aspx.cs" Inherits="Midway_Assessment.WebPages.MaintenanceWorks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta charset="utf-8">
  <title>Equipment Maintenance</title>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css">
  <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.1/jquery-ui.js"></script>
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script>
      $(function () {
          $("[id$=txtDate]").datepicker({
              showOn: 'button',
              showsTime: true,
              dateFormat:"dd/mm/yy"
         
          });
      });
  </script>
</head>
<body>
 
    <form runat="server">
 <asp:TextBox ID="txtDate" runat="server" ReadOnly = "true"></asp:TextBox>
        </form>
</body>
</html>
