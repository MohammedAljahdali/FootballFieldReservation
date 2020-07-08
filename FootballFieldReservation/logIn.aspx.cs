using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FootballFieldReservation
{
    public partial class logIn : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
           
            if (!(userNameTxt.Text.Equals("admin") && passwordTxt.Text.Equals("admin")))
            {
                GlobalVar.showMessage("your password or username is incorrect !", WarningType.Danger, Master);
                return;
            }
            //go to home page .. 
               
        }
    }
}