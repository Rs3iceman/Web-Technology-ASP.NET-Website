using System;

public partial class CurrentLocation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Button_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}