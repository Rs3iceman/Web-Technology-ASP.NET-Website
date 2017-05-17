using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SelectedLocation : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(@"Data Source = sql2008.net.dcs.hull.ac.uk; Initial Catalog = rde_509489; Integrated Security = True");
    protected void Page_Load(object sender, EventArgs e)
    {
        Label.Text = "";
    }
    protected void locationButton_Click(object sender, EventArgs e)
    {
        try
        {
            //Select from the Teacher table using the current location
            using (SqlCommand selectPastLocations = new SqlCommand())
            {
                selectPastLocations.CommandText = "SELECT UserName FROM Teacher WHERE [CurrentLocation]='" + LocationDropDownList.SelectedValue + "'";
                selectPastLocations.Connection = connection;

                //Create a datatable to add the data to
                DataTable datatable = new DataTable();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectPastLocations))
                {
                    //Fill the datatable using the DataAdapter and Bind the data
                    sqlDataAdapter.Fill(datatable);
                    GridView1.DataSource = datatable;
                    GridView1.DataBind();
                }
            }
        }
        catch (Exception exception)
        {
            //Catches any exception and throws it to the user
            Label.Text = "Failed to Update: " + exception;
        }
    }
}