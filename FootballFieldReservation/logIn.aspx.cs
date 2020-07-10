using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FootballFieldReservation
{
    public partial class Login : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
        //      SqlCommand command = new SqlCommand("select * from **** where [Email/User Name]='" +userNameTxt.Text+ "' and Password='" +passwordTxt.Text+ "'", GlobalVar.connection);
        //    try
        //    {
        //        command.Connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        if (reader.HasRows)
        //        {
                   
        //            //go to home page 
        //        }
        //        else
        //        {
        //            GlobalVar.showMessage("your password or username is incorrect !", WarningType.Danger, Master);
        //            return;
        //        }

        //    }
        //    catch (SqlException ex)
        //    {
        //        GlobalVar.showMessage("Sorry the server could not be contacted\n" + ex.Message, WarningType.Danger, Master);
        //    }
        //    catch (Exception ex)
        //    {
        //        GlobalVar.showMessage("Unknown error ... \n" + ex.Message, WarningType.Danger, Master);
        //    }

        //    command.Connection.Close();
        }

        protected void ForgotPassCode_Click(object sender, EventArgs e)
        {
            if (userNameTxt.Text.Equals(""))
            {
                GlobalVar.showMessage("Enter your user name ", WarningType.Danger, Master);
                return;
            }
            GlobalVar.showMessage("Find the instruction on how to reset your password sent to your E-mail", WarningType.Success, Master);
        }

    }
}