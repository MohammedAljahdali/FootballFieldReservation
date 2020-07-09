using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FootballFieldReservation
{
    public static class GlobalVar
    {
        public static SqlConnection connection; // = new SqlConnection("test");
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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitClicked(object sender, EventArgs e)
        {
            
           //int success = 0;
           //if (passwordInputField.Value != confirmPasswordInputField.Value)          
           //    return;
           //
           //string register = " insert into User (user_name, user_id, user_password) values (@user_name,@user_id,@user_password)";
           //SqlCommand registerUser = new SqlCommand(register, GlobalVar.connection);
           //registerUser.Parameters.AddWithValue("@user_id", int.Parse(idInputField.Value));
           //registerUser.Parameters.AddWithValue("@user_name", nameInputField.Value);
           //registerUser.Parameters.AddWithValue("@user_password", passwordInputField.Value);
           //try
           //{
           //    registerUser.Connection.Open();
           //    //executing the method of command object
           //    // ExecuteNonQuery() method of command object is used for insert the record
           //    success = registerUser.ExecuteNonQuery();
           //
           //    if (success == 1)
           //    {
           //        // go to the home page
           //    }
           //    else 
           //    {
           //         GlobalVar.showMessage("Signing Up Failed Try Again Please", WarningType.Warning, Master);
           //     }
           //        
           //} // end of try
           //catch (Exception ex)
           //{
           //     GlobalVar.showMessage(ex.Message, WarningType.Danger, Master);
           // }
           //finally
           //{
           //    registerUser.Connection.Close();
           //}

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GlobalVar.showMessage("test", WarningType.Danger, Master);
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
