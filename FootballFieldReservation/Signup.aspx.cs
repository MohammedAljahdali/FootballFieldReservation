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
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitClicked(object sender, EventArgs e)
        {


            int success = 0;
            if (passwordInputField.Text != confirmPasswordInputField.Text)
            {
                confirmPasswordValidation.Text = "Passwords does not match";
                confirmPasswordValidation.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string register = "insert into [User] (user_id, user_name, user_password, user_role) values (@user_id,@user_name,@user_password,@user_role)";
            SqlCommand registerUser = new SqlCommand(register, GlobalVar.connection);
            registerUser.Parameters.AddWithValue("@user_id", idInputField.Text);
            registerUser.Parameters.AddWithValue("@user_name", nameInputField.Text);
            registerUser.Parameters.AddWithValue("@user_password", passwordInputField.Text);
            registerUser.Parameters.AddWithValue("@user_role", "user");
            try
            {
                registerUser.Connection.Open();
                //executing the method of command object
                // ExecuteNonQuery() method of command object is used for insert the record
                success = registerUser.ExecuteNonQuery();

                if (success == 1)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    GlobalVar.showMessage("Signing Up Failed Try Again Please", WarningType.Warning, Master);
                }

            } // end of try
            catch (Exception ex)
            {
                GlobalVar.showMessage(ex.Message, WarningType.Danger, Master);
            }
            finally
            {
                registerUser.Connection.Close();
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GlobalVar.showMessage("test", WarningType.Danger, Master);
        }
    }
}
