<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeLocation.aspx.cs" Inherits="ChangeLocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change the location of a staff member</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <nav>
            <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="False" Orientation="Horizontal" StaticItemFormatString="&amp;nbsp &amp;nbsp {0}" BackColor="#E3EAEB" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#666666" StaticSubMenuIndent="10px">
                <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
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


        <h1>Change the location of a staff member</h1>

        <p>
            <br />
            <br />
            Staff Member:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList class="DropDownList" ID="TeacherDropDownList" runat="server" DataSourceID="SqlDataSource1" DataTextField="FirstNameLastName" DataValueField="UserName">
            </asp:DropDownList>
        </p>
        <p>
            Updated Location:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox class="TextBox" ID="LocationTextBox" runat="server"></asp:TextBox>   
        </p>
        <p>
            <br />
            <asp:Button class="Button" ID="Button" runat="server" OnClick="Button_Click" Text="Update" />
        </p>
        <p>
            <br />
            <asp:Label class="Label" ID="Label" runat="server" Text="Label"></asp:Label>
        </p>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:rde_509489ConnectionString %>" SelectCommand="SELECT [ID], [UserName], [FirstName], [LastName],FirstName+LastName AS [FirstNameLastName] FROM [Teacher]"></asp:SqlDataSource>

    </form>
</body>
</html>
