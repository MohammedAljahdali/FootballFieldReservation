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
            string endDateString = endCalendar.SelectedDate.AddHours(Double.Parse(endTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(endTextBox.Text.Substring(3, 2))).ToString("yyyy-MM-dd HH:mm:ss");
            TimeSpan timeSpan = endDate - startDate;
            TimeSpan startTimeSpan = startDate - DateTime.Now;
            if (startTimeSpan.TotalHours < 0)
            {
                System.Diagnostics.Debug.WriteLine("hey");
            }
            switch (DateTime.Compare(endDate, startDate))
            {
                case 1:
                    dateVaildationLabel.Text = "1";
                    break;
                case 0:
                    dateVaildationLabel.Text = "0";
                    break;
                case -1:
                    dateVaildationLabel.Text = "-1";
                    break;
            }
            dateVaildationLabel.Text = dateVaildationLabel.Text + ": " + timeSpan.TotalHours.ToString()+": "+startTimeSpan.TotalHours.ToString();
            // check the is the resv time is at least 1 hour
            if (timeSpan.TotalHours < 1)
            {
                return;
            }

        }
    }
}