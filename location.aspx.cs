using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class location : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(@"Data Source = sql2008.net.dcs.hull.ac.uk; Initial Catalog = rde_509489; Integrated Security = True");
    protected void Page_Load(object sender, EventArgs e)
    {
        //Checks the request type and calls the correct function
        if (Request.RequestType == "GET")
        {
            GET();
        }
        if (Request.RequestType == "POST")
        {
            POST();
        }
    }
    protected void GET()
    {
        string incomingRequest;
        string user;

        try
        {
            //Validation to check that the request is not empty
            if (Request.QueryString.HasKeys())
            {
                //Open the SQL connection
                connection.Open();

                //Get the username out of the GET request
                incomingRequest = Request.QueryString.AllKeys[0];
                user = Request.QueryString[incomingRequest];

                //Create a Select command searching for the current location of a user by their username in the teacher table
                string command = "SELECT CurrentLocation FROM Teacher WHERE [UserName]='" + user.Trim() + "'";
                SqlCommand selectLocation = new SqlCommand(command);
                selectLocation.CommandType = CommandType.Text;
                selectLocation.Connection = connection;
                //Only Adds the data if the Username is the same as the one in the database
                selectLocation.Parameters.AddWithValue("UserName", user.Trim());

                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectLocation))
                {
                    //Creates a new datatable to store the data and fills the datatable through a Data Adapter
                    DataTable datatable = new DataTable();
                    sqlDataAdapter.Fill(datatable);

                    //Tries to get the location out of the database, if Username did not match then this will fail and exception will be thrown
                    string location = Convert.ToString(datatable.Rows[0]["CurrentLocation"]);

                    //Writes a response to the request in the correct format
                    Response.Write("HTTP/1.1 200 OK/r/n");
                    Response.Write("Content-Type: text/plain/r/n");
                    Response.Write(location.Trim() + "/r/n");
                    Response.Write("/r/n");
                }
            }
        }
        catch
        {
            //If the program failed to get the datatable row due to the username not matching the function returns 404 not found to the user
            Response.Write("HTTP/1.1 404 Not Found");
            Response.Write("Content-Type: text/plain/r/n");
            Response.Write("/r/n");
        }

        //Closes the SQL connection
        connection.Close();
    }
    protected void POST()
    {

        string incomingRequest;
        string user;
        string location;

        try
        {
            //Open the SQL connection
            connection.Open();

            //Creates a streamReader using the Request Input Stream and reads the input
            //This is used because POST does not always use QueryString and FORM wouldn't respond correctly
            StreamReader sr = new StreamReader(Request.InputStream);
            incomingRequest = sr.ReadToEnd();

            //Splits the incoming request into 2 parts based on the location of equals and sets the parts to 2 strings
            string[] parts = incomingRequest.Split('=');
            user = parts[0];
            location = parts[1];

            //Creates a select command which returns the Current location of a Username searched in the Teacher table
            string command = "SELECT CurrentLocation FROM Teacher WHERE [UserName]='" + user.Trim() + "'";
            SqlCommand selectLocation = new SqlCommand(command);
            selectLocation.CommandType = CommandType.Text;
            selectLocation.Connection = connection;

            //Only Adds the data if the Username is the same as the one in the database
            selectLocation.Parameters.AddWithValue("UserName", user.Trim());

            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectLocation))
            {
                //Creates a new datatable to store the data and fills the datatable through a Data Adapter
                DataTable datatable = new DataTable(); 
                sqlDataAdapter.Fill(datatable);
                try
                {
                    //Tries to get the location out of the database, if Username did not match then this will fail and exception will be thrown
                    string databaseLocation = Convert.ToString(datatable.Rows[0]["CurrentLocation"]);

                    //Updates all the respective tables for the new Location of the User
                    SqlCommand insertPastLocations = connection.CreateCommand();
                    insertPastLocations.CommandType = CommandType.Text;
                    insertPastLocations.CommandText = "INSERT INTO[PastLocations]([UserName],[Location]) VALUES('" + user + "','" + location + "')";
                    insertPastLocations.ExecuteNonQuery();

                    SqlCommand updateLocations = connection.CreateCommand();
                    updateLocations.CommandType = CommandType.Text;
                    updateLocations.CommandText = "UPDATE Locations SET [Location]='" + location + "' WHERE UserName='" + user + "'";
                    updateLocations.ExecuteNonQuery();

                    SqlCommand updateTeacher = connection.CreateCommand();
                    updateTeacher.CommandType = CommandType.Text;
                    updateTeacher.CommandText = "UPDATE Teacher SET [CurrentLocation]='" + location + "' WHERE UserName='" + user + "'";
                    updateTeacher.ExecuteNonQuery();
                }
                catch
                {
                    //If the program failed to get the datatable row due to the username not matching the function
                    //Inserts the New user into the 3 SQL tables
                    SqlCommand insertPastLocations = connection.CreateCommand();
                    insertPastLocations.CommandType = CommandType.Text;
                    insertPastLocations.CommandText = "INSERT INTO[PastLocations]([UserName],[Location]) VALUES('" + user + "','" + location + "')";
                    insertPastLocations.ExecuteNonQuery();

                    SqlCommand insertLocations = connection.CreateCommand();
                    insertLocations.CommandType = CommandType.Text;
                    insertLocations.CommandText = "INSERT INTO[Locations]([UserName],[Location]) VALUES('" + user + "','" + location + "')";
                    insertLocations.ExecuteNonQuery();

                    //First Name and Last Name will be left null in the database until updated another way
                    SqlCommand insertTeacher = connection.CreateCommand();
                    insertTeacher.CommandType = CommandType.Text;
                    insertTeacher.CommandText = "INSERT INTO[Teacher]([UserName],[CurrentLocation]) VALUES('" + user + "','" + location + "')";
                    insertTeacher.ExecuteNonQuery();
                }
            }
        }
        catch (Exception exception)
        {
            //Catches and throws any exceptions thrown to the console
            Console.Write(exception);
        }

        //After any Post request is completed respond to the User
        Response.Write("HTTP/1.1 200 OK/r/n");
        Response.Write("Content-Type: text/plain/r/n");
        Response.Write("/r/n");

        //Close the SQL Connection
        connection.Close();
    }
}