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
            
           bool success = GlobalVar.addUser(passwordInputField, confirmPasswordInputField, idInputField, nameInputField, confirmPasswordValidation, true, Master);
            if (success)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GlobalVar.showMessage("test", WarningType.Danger, Master);
        }
    }
}
