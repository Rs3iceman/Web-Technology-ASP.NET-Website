using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class StaffSearch : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(@"Data Source = sql2008.net.dcs.hull.ac.uk; Initial Catalog = rde_509489; Integrated Security = True");
    protected void Page_Load(object sender, EventArgs e)
    {
        Label.Text = "";
    }
    protected void teacherButton_Click(object sender, EventArgs e)
    {
        //Gets the string out of the Drop down list
        string tempString = TeacherDropDownList.SelectedValue;
        tempString = string.Join("", tempString.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

        try
        {
            //Select from the Past Locations table using the Username
            using (SqlCommand selectPastLocations = new SqlCommand())
            {
                selectPastLocations.CommandText = "SELECT Location FROM PastLocations WHERE [TimeandDate]>= getdate()-1 AND [Username]='" + tempString + "'";
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
            Label.Text = "Failed to search Teacher: " + exception;
        }
    }
}