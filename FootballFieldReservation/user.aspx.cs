using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FootballFieldReservation
{
    public partial class user : System.Web.UI.Page
    {
        static bool once = true;
        protected void Page_Load(object sender, EventArgs e)
        {

            Label1.Text = GlobalVar.userName;

            GlobalVar.display(resvTable, Master, "select [resv_id] , [resv_field_id] , [resv_startDate] , [resv_endDate]" +
                                                  " From Resv Where [resv_user_id]='" + GlobalVar.userID + "'");

            GlobalVar.headerChanger(new string[] { "ID", "Field ID", "Start Date", "End Date" }, resvTable);

        }

        protected void addB_Click(object sender, EventArgs e)
        {
            if (GlobalVar.search(new SqlCommand("select * From Resv Where [resv_user_id]='" + GlobalVar.userID + "' and [resv_field_id]='"
                + fieldIdTextBox.Text + "'", GlobalVar.connection), new TextBox[0], new string[0], new Control[0], Master))
            {
                GlobalVar.showMessage("you already have this reservation", WarningType.Warning, Master);
            }

            checkTime();

        }
        public bool checkTime()
        {
            SqlCommand cmd = new SqlCommand("select * From Resv Where [resv_field_id]='" + fieldIdTextBox.Text + "'", GlobalVar.connection);
            DateTime start = new DateTime();
            DateTime end = new DateTime();
            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    start = (DateTime)reader["resv_startDate"];
                    end = (DateTime)reader["resv_endDate"];
                }
            }
            catch (SqlException ex)
            {
                GlobalVar.showMessage("Sorry the server could not be contacted\n" + ex.Message, WarningType.Danger, Master);
            }
            catch (Exception ex)
            {
                GlobalVar.showMessage("Unknown error ... \n" + ex.Message, WarningType.Danger, Master);
            }
            finally
            {
                cmd.Connection.Close();
            }

            DateTime startDate = Calendar2.SelectedDate.AddHours(Double.Parse(TextBox2.Text.Substring(0, 2))).AddMinutes(Double.Parse(TextBox2.Text.Substring(3, 2)));
            string startDateString = startDate.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime endDate = Calendar1.SelectedDate.AddHours(Double.Parse(TextBox1.Text.Substring(0, 2))).AddMinutes(Double.Parse(TextBox1.Text.Substring(3, 2)));
            string endDateString = endDate.ToString("yyyy-MM-dd HH:mm:ss");
            fieldIdTextBox.Text = startDateString;
            fielNameTextBox.Text = endDateString;
            return false;
        }
    }
}