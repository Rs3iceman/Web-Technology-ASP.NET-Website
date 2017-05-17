<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Index Page for Web Technology</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <nav>
            <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="False" Orientation="Horizontal" StaticItemFormatString="&amp;nbsp &amp;nbsp {0}" BackColor="#E3EAEB" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#666666" StaticSubMenuIndent="10px">
                <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                <DynamicMenuItemStyle BorderColor="White" BorderStyle="Solid" HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#E3EAEB" />
                <DynamicSelectedStyle BackColor="#1C5E55" />
                <Items>
                    <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Index" />
                    <asp:MenuItem NavigateUrl="~/CurrentLocation.aspx" Text="Current Location" />
                    <asp:MenuItem NavigateUrl="~/ChangeLocation.aspx" Text="Change Location" />
                    <asp:MenuItem NavigateUrl="~/EditDetails.aspx" Text="Edit Staff Details" />
                    <asp:MenuItem NavigateUrl="~/StaffSearch.aspx" Text="Search Staff" />
                    <asp:MenuItem NavigateUrl="~/SelectedLocation.aspx" Text="Search by selected Location" />
                </Items>
                <StaticHoverStyle BackColor="#666666" ForeColor="White" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticSelectedStyle BackColor="#1C5E55" />
            </asp:Menu>
        </nav>

        <h1>Index page</h1>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:rde_509489ConnectionString %>" SelectCommand="SELECT * FROM [Locations]"></asp:SqlDataSource>
        <asp:LinkButton class="Button" ID="LinkButton1" runat="server" href="CurrentLocation.aspx" >Click here to query a user’s current location</asp:LinkButton><br /><br />
        <asp:LinkButton class="Button" ID="LinkButton2" runat="server" href="ChangeLocation.aspx" >Click here to change a user’s current location</asp:LinkButton><br /><br />
        <asp:LinkButton class="Button" ID="LinkButton3" runat="server" href="EditDetails.aspx" >Click here to edit a user’s details</asp:LinkButton><br /><br />
        <asp:LinkButton class="Button" ID="LinkButton5" runat="server" href="StaffSearch.aspx" >Click here to query a user’s past locations</asp:LinkButton><br /><br />
        <asp:LinkButton class="Button" ID="LinkButton4" runat="server" href="SelectedLocation.aspx" >Click here to query a location</asp:LinkButton><br /><br />
    </form>
    
</body>
</html>
