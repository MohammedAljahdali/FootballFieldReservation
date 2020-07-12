using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            GlobalVar.display(resvTable, Master, "select * from [Resv]");
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            if (startTextBox.Text == "" || endTextBox.Text == "")
            {
                dateVaildationLabel.Text = "Select a Time Please!";
                return;
            }
            DateTime startDate = startCalendar.SelectedDate.AddHours(Double.Parse(startTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(startTextBox.Text.Substring(3, 2)));
            System.Diagnostics.Debug.WriteLine(startDate.ToString("yyyy-MM-dd H:mm:ss"));
            string startDateString = startDate.ToString();
            System.Diagnostics.Debug.WriteLine(startDateString);
            DateTime endDate = endCalendar.SelectedDate.AddHours(Double.Parse(endTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(endTextBox.Text.Substring(3, 2)));
            string endDateString = endDate.ToString("yyyy-MM-dd H:mm:ss");
            if (!GlobalVar.vaildateEnteredDates(startDate, endDate, dateVaildationLabel))
            {
                return;
            }
            
            string register = "insert into Resv (resv_id, resv_user_id, resv_field_id, resv_startDate, resv_endDate) values (@id,@idu,@idf,@start,@end)";
            SqlCommand cmd = new SqlCommand(register, GlobalVar.connection);
            cmd.Parameters.AddWithValue("@id", resvIDTextBox.Text);
            cmd.Parameters.AddWithValue("@idu", resvUserIDTextBox.Text);
            cmd.Parameters.AddWithValue("@idf", resvFieldIDTextBox.Text);
            cmd.Parameters.AddWithValue("@start", startDateString);
            cmd.Parameters.AddWithValue("@end", endDateString);
            GlobalVar.add(cmd, "Reservation added Successfully", "Reservation is Not Added, Try Again Please", Master);
            GlobalVar.display(resvTable, Master, "select * from [Resv]");
            GlobalVar.clearFields(new TextBox[] { resvFieldIDTextBox, resvIDTextBox, resvUserIDTextBox, startTextBox, endTextBox });




        }
    }
}