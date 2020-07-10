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
        //public static SqlConnection connection = new SqlConnection(
        //  "Data Source=DESKTOP-0QMNFDM;Database=FootballFieldReservation;Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
        //"TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
 

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

    }

    public enum WarningType
    {
        Success,
        Info,
        Warning,
        Danger
    }
}