using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FootballFieldReservation
{
    public partial class AdminReservationManagment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            DateTime startDate = startCalendar.SelectedDate.AddHours(Double.Parse(startTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(startTextBox.Text.Substring(3, 2)));
            string startDateString = startDate.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime endDate = endCalendar.SelectedDate.AddHours(Double.Parse(endTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(endTextBox.Text.Substring(3, 2)));
            string endDateString = endDate.ToString("yyyy-MM-dd HH:mm:ss");

           

        }
    }
}