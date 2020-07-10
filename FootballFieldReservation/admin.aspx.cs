using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FootballFieldReservation
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Bandar";
        }

        protected void editUsers_Click(object sender, EventArgs e)
        {
        //    editReservations.Enabled = false;

        }
    }
}