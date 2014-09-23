<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintenanceWorks.aspx.cs" Inherits="Midway_Assessment.WebPages.MaintenanceWorks" MasterPageFile="~/MidwayAssessment.Master" Title="Maintenance Works" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%-- <link  href="../Style/Site.css" rel="stylesheet" type="text/css" />--%>
    <link  rel="stylesheet" href="../Content/jquery-ui.css" type="text/css" />
   
    <style type="text/css">
        .auto-style1 {
           
        }
        .auto-style2 {
            
        }
        .auto-style3 {

        }
        .auto-style4 {
            width: 115px;
        }
        .auto-style5 {
            height: 27px;
            width: 195px;
        }
        .auto-style6 {
            height: 27px;
            width: 115px;
        }
        .auto-style7 {
            height: 22px;
            width: 431px;
        }
        .auto-style8 {
            width: 431px;
        }
        .auto-style9 {
            height: 27px;
            width: 431px;
        }
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
  <script src="http://code.jquery.com/ui/1.11.1/jquery-ui.js"></script>
    <script type="text/javascript" src="../Script/bs.pagination.js"></script>
    <%--<link rel="stylesheet" href="/resources/demos/style.css" />--%>
<script>
    $(function () {
        $("[id$=txtDate]").datepicker({
            showOn: 'button',
            showsTime: true,
            dateFormat: "d/mm/yy"

        });
    });
    function ConfirmDelete() {
        if (confirm("Are you sure, you want to delete the record?")) {
            return true;
        }
        return false;
    }
  </script>

     <h2>Equipment Maintenance</h2>
    <form runat="server" class="form-inline">
        <div>
    
        <table class="table borderless" >
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style7">
                    <asp:CustomValidator ID="Update" runat="server" CssClass="validator-style" ErrorMessage="Error Message" ForeColor="Red" OnServerValidate="Update_ServerValidate" Display="Dynamic" ValidationGroup="Update">Error Message</asp:CustomValidator>
                    <asp:CustomValidator ID="Delete" runat="server" CssClass="validator-style" ErrorMessage="Error Message" ForeColor="Red" OnServerValidate="Delete_ServerValidate" Display="Dynamic" ValidationGroup="Delete">Error Message</asp:CustomValidator>
                    <asp:ValidationSummary ID="ValidationSummary_Add" runat="server" CssClass="validator-style" ForeColor="Red" ValidationGroup="Add" />
                    <asp:ValidationSummary ID="ValidationSummary_Update" runat="server" CssClass="validator-style" ForeColor="Red" ValidationGroup="Update" />
                    <div runat="server" id="acknowledgementBox" ></div>
                    
                    </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblEquipName" CssClass="control-label col-xs-10" runat="server" Font-Bold="True" Font-Overline="False" Font-Strikeout="False">Equipment </asp:Label>
                </td>
                <td class="auto-style7">
                  
                    <asp:DropDownList CssClass="form-control" ID="cmbEquipment" Width="300px"  runat="server"  >
                    </asp:DropDownList>
                  
                    <asp:RequiredFieldValidator ID="EquipmentValidator_Add" runat="server" ControlToValidate="cmbEquipment" ErrorMessage="Equipment is required." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Add" InitialValue="-1">*</asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="EquipmentValidator_Update" runat="server" ControlToValidate="cmbEquipment" ErrorMessage="Equipment is required." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Update"  InitialValue="-1">*</asp:RequiredFieldValidator>
                  
                </td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblWorkDate" CssClass="control-label col-xs-10" runat="server" Font-Bold="True" Font-Overline="False" Font-Strikeout="False">Work Date </asp:Label>
                </td>
                <td class="auto-style7">
                  
 <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" Width="300px"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="DateValidator_Add" runat="server" ControlToValidate="txtDate" ErrorMessage="Date is required." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Add">*</asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="DateValidator_Update" runat="server" ControlToValidate="txtDate" ErrorMessage="Date is required." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Update">*</asp:RequiredFieldValidator>
                    </td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblWorkTime" CssClass="control-label col-xs-10"  runat="server" Font-Bold="True" Font-Overline="False" Font-Strikeout="False">Work Time </asp:Label>
                </td>
                <td class="auto-style8" >
                  
                    <asp:DropDownList ID="cmbHour" CssClass="form-control" Width="150px" runat="server" >
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
                  
                    <asp:RequiredFieldValidator ID="HourValidator_Update" runat="server" ControlToValidate="cmbHour" ErrorMessage="Hour part is required." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Update" InitialValue="-1">*</asp:RequiredFieldValidator>
                  
                    <asp:RequiredFieldValidator ID="HourValidator_Add" runat="server" ControlToValidate="cmbHour" ErrorMessage="Hour part is required." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Add" InitialValue="-1">*</asp:RequiredFieldValidator>
                    <asp:DropDownList ID="cmbMinutes" CssClass="form-control" Width="150px" runat="server" >
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
                  
                    <asp:RequiredFieldValidator ID="MinuteValidator_Add" runat="server" ControlToValidate="cmbMinutes" ErrorMessage="Minute part is required." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Add" InitialValue="-1">*</asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="MinuteValidator_Update" runat="server" ControlToValidate="cmbMinutes" ErrorMessage="Minute part is required." ForeColor="Red" SetFocusOnError="True" ValidationGroup="Update" InitialValue="-1">*</asp:RequiredFieldValidator>
                  
                </td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lblTimeTaken" CssClass="control-label col-xs-10"  runat="server" Font-Bold="True" Font-Overline="False" Font-Strikeout="False">Time Taken(min) </asp:Label>
                </td>
                <td class="auto-style9">
                  
 <asp:TextBox ID="txtTimeTaken" runat="server" CssClass="form-control" Width="300px"  ></asp:TextBox>
                    <asp:RegularExpressionValidator ID="TimeTakenValidator_Add" runat="server" ControlToValidate="txtTimeTaken" ErrorMessage="Only numbers can be entered." ForeColor="Red" SetFocusOnError="True" ValidationExpression="[0-9]+" ValidationGroup="Add">*</asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="TimeTakenValidator_Update" runat="server" ControlToValidate="txtTimeTaken" ErrorMessage="Only numbers can be entered." ForeColor="Red" SetFocusOnError="True" ValidationExpression="[0-9]+" ValidationGroup="Update">*</asp:RegularExpressionValidator>
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblDescription" CssClass="control-label col-xs-10"  runat="server" Font-Bold="True" Font-Overline="False" Font-Strikeout="False">Description</asp:Label>
                </td>
                <td class="auto-style7">
                  
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" Width="300px" Height="108px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style8">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary"  Text="Add" OnClick="btnAdd_Click" ValidationGroup="Add" />
&nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary"    ValidationGroup="Update" OnClick="btnUpdate_Click" />
&nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete"  OnClick="btnDelete_Click" CssClass="btn btn-primary"  ValidationGroup="Delete" OnClientClick="return ConfirmDelete()" />
&nbsp;</td>
                <td>
                    &nbsp;</td>
        &nbsp;</td>
        &nbsp;</td>
            </tr>
        </table>
    
    </div>
        <asp:GridView ID="gvEquipmentMaintenance" PagerStyle-CssClass="bs-pagination" CssClass="table"   RowStyle-Wrap="True" AutoGenerateColumns="False" DataKeyNames="MaintenanceWorkId" AllowPaging="True" CellPadding="5" CellSpacing="5" HeaderStyle-BackColor="Brown" HeaderStyle-ForeColor="White" AlternatingRowStyle-BackColor="Gainsboro" runat="server" HorizontalAlign="Left"  Width="100%" PageSize="15" OnPageIndexChanging="gvEquipMaintenance_PageIndexChanging" OnSelectedIndexChanged="gvEquipMaintenace_SelectedIndexChanged" AutoGenerateSelectButton="True">
         <PagerStyle HorizontalAlign="Center"  />
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="First" NextPageText="Next" LastPageText="Last"  PreviousPageText="Previous" />
               <AlternatingRowStyle BackColor="Gainsboro" />
            <Columns>
                <asp:BoundField DataField="MaintenanceWorkId" Visible="False" />
                <asp:BoundField DataField="ID" Visible="False" />
                <%--<asp:BoundField AccessibleHeaderText="Name" DataField="name" HeaderText="Name" SortExpression="name" />--%>
                <asp:templatefield headertext="Equipment Name">
				<itemtemplate >
					<%# ((Midway_Assessment.ClassProperties.EquipmentMaintenance)Container.DataItem).ObjEquip.Name %>
				</itemtemplate>
			</asp:templatefield>


                <asp:BoundField AccessibleHeaderText="Work Date" DataFormatString="{0:d/MM/yyyy}" DataField="Date" HeaderText="Work Date" SortExpression="name" />
                <asp:BoundField AccessibleHeaderText="Work Time" DataField="Time" HeaderText="Work Time" SortExpression="name" />
                <asp:BoundField AccessibleHeaderText="Time Taken (min)" DataField="TimeTaken" HeaderText="Time Taken(min)" SortExpression="name" />
                   <asp:BoundField AccessibleHeaderText="Description" DataField="WorksDescription" HeaderText="Description" SortExpression="name" />
         
                
                <asp:TemplateField Visible="false">
         <ItemTemplate>
             <asp:Label id="lblEquipmentID" runat ="server" text='<%# ((Midway_Assessment.ClassProperties.EquipmentMaintenance)Container.DataItem).ObjEquip.ID  %>'/>
         </ItemTemplate>
      </asp:TemplateField>

            </Columns>
            <HeaderStyle BackColor="Maroon" ForeColor="White" />
            
<RowStyle Wrap="True"></RowStyle>
            
        </asp:GridView>
        </form>
</asp:Content>