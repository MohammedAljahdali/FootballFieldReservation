using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FootballFieldReservation
{

    public partial class Site1 : System.Web.UI.MasterPage
    { 

        protected void Page_Load(object sender, EventArgs e)
        {
            changeUserStatus();
        }

        public void changeUserStatus()
        {
            LinkButton[] adminLinkButtons = new LinkButton[] { adminFieldLink, adminUserLink, adminReservationLink };
            switch (GlobalVar.userRole)
            {
                case "":
                    userPageLinkButton.Enabled = false;
                    logoutLinkButton.Enabled = false;
                    foreach (LinkButton link in adminLinkButtons)
                        link.Enabled = false;
                    break;
                case "user":
                    logoutLinkButton.Enabled = true;
                    userPageLinkButton.Enabled = true;
                    adminLoginLink.Enabled = false;
                    loginLinkButton.Enabled = false;
                    foreach (LinkButton link in adminLinkButtons)
                        link.Enabled = false;
                    break;
                case "admin":
                    foreach (LinkButton link in adminLinkButtons)
                        link.Enabled = true;
                    logoutLinkButton.Enabled = true;
                    adminLoginLink.Enabled = false;
                    loginLinkButton.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        protected void logoutLinkButton_Click(object sender, EventArgs e)
        {
            GlobalVar.userID = "";
            GlobalVar.userRole = "";
            Response.Redirect("Login.aspx");
            changeUserStatus();
        }
    }
}