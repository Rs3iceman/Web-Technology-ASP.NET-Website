<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CurrentLocation.aspx.cs" Inherits="CurrentLocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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


        <h1>Show the Current Locations of all staff</h1>

        <br />
        <br />
        <asp:Button class="Button" ID="Button" runat="server" OnClick="Button_Click" Text="Show Current Locations of all Staff" />

        <br />
        <br />
        <div id="GridView">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Visible="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="ID">
                <Columns>
                    <asp:BoundField DataField="FirstNameLastName" HeaderText="Teacher Name" SortExpression="FirstNameLastName" ReadOnly="True" />
                    <asp:BoundField DataField="CurrentLocation" HeaderText="Current Location" SortExpression="CurrentLocation" />
                </Columns>
            </asp:GridView>
        </div>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:rde_509489ConnectionString %>" SelectCommand="SELECT [ID], [FirstName], [LastName], [CurrentLocation], FirstName+LastName AS [FirstNameLastName] FROM [Teacher]"></asp:SqlDataSource>
    </form>
</body>
</html>
