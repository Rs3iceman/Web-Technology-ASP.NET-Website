using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class EditDetails : System.Web.UI.Page
{

    SqlConnection connection = new SqlConnection(@"Data Source = sql2008.net.dcs.hull.ac.uk; Initial Catalog = rde_509489; Integrated Security = True");
    protected void Page_Load(object sender, EventArgs e)
    {
        Label.Text = "";
    }
    protected void fnameButton_Click(object sender, EventArgs e)
    {
        //Gets the string out of the Drop down list
        string tempString = TeacherDropDownList.SelectedValue;
        tempString = string.Join("", tempString.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

        try
        {
            //Opens the SQL connection
            connection.Open();

            //Validation for the Text box so only letters can be entered
            if (Regex.IsMatch(fnameTextBox.Text, "^[a-zA-Z]+$"))
            {
                //Updates the Teacher table with the new First Name of the user
                SqlCommand updateTeacher = connection.CreateCommand();
                updateTeacher.CommandType = CommandType.Text;
                updateTeacher.CommandText = "UPDATE Teacher SET [FirstName]='" + fnameTextBox.Text + "' WHERE UserName='" + tempString + "'";
                updateTeacher.ExecuteNonQuery();

                //Updates the Label to respond to the user
                Label.Text = "Updated First Name";
            }
            else
            {
                //Updates the Label to respond to the user
                Label.Text = "Invalid First Name";
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
    protected void lnameButton_Click(object sender, EventArgs e)
    {
        //Gets the string out of the Drop down list
        string tempString = TeacherDropDownList.SelectedValue;
        tempString = string.Join("", tempString.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

        try
        {
            //Opens the SQL connection
            connection.Open();

            //Validation for the Text box so only letters can be entered
            if (Regex.IsMatch(lnameTextBox.Text, "^[a-zA-Z]+$"))
            {
                //Updates the Teacher table with the new Last Name of the user
                SqlCommand updateTeacher = connection.CreateCommand();
                updateTeacher.CommandType = CommandType.Text;
                updateTeacher.CommandText = "UPDATE Teacher SET [LastName]='" + lnameTextBox.Text + "' WHERE UserName='" + tempString + "'";
                updateTeacher.ExecuteNonQuery();

                //Updates the Label to respond to the user
                Label.Text = "Updated Last Name";
            }
            else
            {
                //Updates the Label to respond to the user
                Label.Text = "Invalid Last Name";
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
}