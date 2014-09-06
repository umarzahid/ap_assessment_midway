<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintenanceWorks.aspx.cs" Inherits="Midway_Assessment.WebPages.MaintenanceWorks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta charset="utf-8">
  <title>Equipment Maintenance</title>
    <link  href="../Style/Site.css" rel="stylesheet" type="text/css" />
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
 
     <h1>Equipment Maintenance</h1>
    <form runat="server">
        <div>
    
        <table >
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style6">
                    &nbsp;</td>
        &nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblEquipName" CssClass="label-style" runat="server" Font-Bold="True" Font-Overline="False" Font-Strikeout="False">Equipment </asp:Label>
                </td>
                <td class="auto-style7">
                  
                    <asp:DropDownList CssClass="combobox-style" ID="cmbEquipment"  runat="server" >
                    </asp:DropDownList>
                  
                </td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblWorkDate" CssClass="label-style" runat="server" Font-Bold="True" Font-Overline="False" Font-Strikeout="False">Work Date </asp:Label>
                </td>
                <td class="auto-style7">
                  
 <asp:TextBox ID="txtDate" runat="server" CssClass="textbox-style" ReadOnly = "true" Width="271px"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblWorkTime" CssClass="label-style" runat="server" Font-Bold="True" Font-Overline="False" Font-Strikeout="False">Work Time </asp:Label>
                </td>
                <td >
                  
                    <asp:DropDownList ID="cmbHour" CssClass="combobox-style" runat="server" >
                        <asp:ListItem Value="-1" >Select Hour</asp:ListItem>
                        <asp:ListItem Value="00" >00</asp:ListItem>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                    </asp:DropDownList>
                  
                &nbsp;<asp:DropDownList ID="cmbMinutes" CssClass="combobox-style" runat="server" >
                        <asp:ListItem Value="-1">Select Minute</asp:ListItem>
                        <asp:ListItem Value="00">00</asp:ListItem>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
<asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>31</asp:ListItem>
                    <asp:ListItem>32</asp:ListItem>
                    <asp:ListItem>33</asp:ListItem>
<asp:ListItem>34</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>36</asp:ListItem>
                    <asp:ListItem>37</asp:ListItem>
                    <asp:ListItem>38</asp:ListItem>
                    <asp:ListItem>39</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>41</asp:ListItem>
                    <asp:ListItem>42</asp:ListItem>
                    <asp:ListItem>43</asp:ListItem>
                    <asp:ListItem>44</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>46</asp:ListItem>
                    <asp:ListItem>47</asp:ListItem>
                    <asp:ListItem>48</asp:ListItem>
                    <asp:ListItem>49</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>51</asp:ListItem>
                    <asp:ListItem>52</asp:ListItem>
                    <asp:ListItem>53</asp:ListItem>
                    <asp:ListItem>54</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                    <asp:ListItem>56</asp:ListItem>
                    <asp:ListItem>57</asp:ListItem>
                    <asp:ListItem>58</asp:ListItem>
                    <asp:ListItem>59</asp:ListItem>

                    </asp:DropDownList>
                  
                </td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblTimeTaken" CssClass="label-style" runat="server" Font-Bold="True" Font-Overline="False" Font-Strikeout="False">Time Taken(min) </asp:Label>
                </td>
                <td class="auto-style7">
                  
 <asp:TextBox ID="txtTimeTaken" runat="server" CssClass="textbox-style" Width="274px"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblTimeTaken0" CssClass="label-style" runat="server" Font-Bold="True" Font-Overline="False" Font-Strikeout="False">Description</asp:Label>
                </td>
                <td class="auto-style7">
                  
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox-style" Height="108px" TextMode="MultiLine" Width="271px"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    &nbsp;</td>
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
        </form>
</body>
</html>
