using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class ChangeLocation : System.Web.UI.Page
{

    SqlConnection connection = new SqlConnection(@"Data Source = sql2008.net.dcs.hull.ac.uk; Initial Catalog = rde_509489; Integrated Security = True");
    public void Page_Load(object sender, EventArgs e)
    {
        Label.Text = "";
    }
    public void Button_Click(object sender, EventArgs e)
    {
        //Gets the string out of the Drop down list
        string tempString = TeacherDropDownList.SelectedValue;
        tempString = string.Join("", tempString.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

        try
        {
            //Opens the SQL connection
            connection.Open();

            //Validation for the Text box so only letters can be entered
            if (Regex.IsMatch(LocationTextBox.Text, "^[a-zA-Z]+$"))
            {

                //Calls 3 functions to alter the SQL tables
                UpdateTeacher(tempString);
                UpdateLocations(tempString);
                InsertPastLocations(tempString);

                //Updates the Label to respond to the user
                Label.Text = "Updated Staff Location";
            }
            else
            {
                //Updates the Label to respond to the user
                Label.Text = "Invalid Location";
            }

            //Closes the SQL connection
            connection.Close();
        }
        catch (Exception exception)
        {
            //Catches any exception and throws it to the user
            Label.Text = "Failed to Update: " + exception;
        }
    }
    public void UpdateTeacher(string tempString)
    {
        //Updates the Current Location of the User in the Teacher Table
        SqlCommand updateTeacher = connection.CreateCommand();
        updateTeacher.CommandType = CommandType.Text;
        updateTeacher.CommandText = "UPDATE Teacher SET [CurrentLocation]='" + LocationTextBox.Text + "' WHERE UserName='" + tempString + "'";
        updateTeacher.ExecuteNonQuery();
    }
    public void UpdateLocations(string tempString)
    {
        //Updates the Current Location of the User in the Location Table
        SqlCommand updateLocations = connection.CreateCommand();
        updateLocations.CommandType = CommandType.Text;
        updateLocations.CommandText = "UPDATE Locations SET [Location]='" + LocationTextBox.Text + "' WHERE UserName='" + tempString + "'";
        updateLocations.ExecuteNonQuery();
    }
    public void InsertPastLocations(string tempString)
    {
        //Inserts the Current Location of the User in the Past Locations Table
        SqlCommand insertPastLocations = connection.CreateCommand();
        insertPastLocations.CommandType = CommandType.Text;
        insertPastLocations.CommandText = "INSERT INTO[PastLocations]([UserName],[Location]) VALUES('" + tempString + "','" + LocationTextBox.Text + "')";
        insertPastLocations.ExecuteNonQuery();
    }
}
