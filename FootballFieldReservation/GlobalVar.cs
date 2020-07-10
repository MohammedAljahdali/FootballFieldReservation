using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FootballFieldReservation
{
    public static class GlobalVar
    {

        public static SqlConnection connection = new SqlConnection(
            File.OpenText(
                (AppDomain.CurrentDomain.BaseDirectory.ToString())
                .Substring(0,
                AppDomain.CurrentDomain.BaseDirectory.ToString().Length -
                "FootballFieldReservation".Length - 1) + "ignore/" + "conn.txt").ReadToEnd());
 

        // = new SqlConnection("test");
        /// <summary>
        /// Shows a message based of type and message
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="type">ENUM type of the message</param>

        public static void showMessage(string message, WarningType type, MasterPage master)
        {
            //gets the controls from the page
            Panel panelMessage = master.FindControl("alertMessage") as Panel;
            Label labelAlertMessage = panelMessage.FindControl("labelAlertMessage") as Label;

            //sets the message and the type of alert, than displays the message
            labelAlertMessage.Text = message;
            panelMessage.CssClass = string.Format("alert alert-{0} alert-dismissable", type.ToString().ToLower());
            panelMessage.Attributes.Add("role", "alert");
            panelMessage.Visible = true;
        }

        public static void displayUsers(GridView gridView, MasterPage master)
        {
            // Create SQlStatement
            string selsql = "select * from [User]";
            //create command object
            SqlCommand cmd = new SqlCommand(selsql, connection);
            try
            { // open the connection
                cmd.Connection.Open();
                // cretae data reader obj
                SqlDataReader dr;
                //executing the method of command object
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                { // binding grid view with data source
                    gridView.DataSource = dr;
                    gridView.DataBind();
                }
                else
                    showMessage("sorry something happend", WarningType.Warning, master);
            } // end of try
            catch (Exception ex)
            {
                showMessage("error reading the database: "+ex.Message, WarningType.Danger, master);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

    }

    public enum WarningType
    {
        Success,
        Info,
        Warning,
        Danger
    }
}