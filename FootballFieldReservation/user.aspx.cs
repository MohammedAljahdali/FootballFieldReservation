using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FootballFieldReservation
{
    public partial class User : System.Web.UI.Page
    {
        static bool isClicked = false;
        protected void Page_Load(object sender, EventArgs e)
        {
        
            
            GlobalVar.display(ReservationTable, Master,
                "select [resv_id] , [resv_field_id] , [resv_startDate] , [resv_endDate] From Resv Where resv_user_id='"+GlobalVar.userID+"'");
            GlobalVar.headerChanger(new string[] { "ID", "Field ID", "Start Date", "End Date" }, ReservationTable);
            
            updateButton.Visible = false;
            deleteButton.Visible = false;
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            if (!vaildateInputDates())
                return;


            DateTime startDate = startCalendar.SelectedDate.AddHours(Double.Parse(startTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(startTextBox.Text.Substring(3, 2)));
            string startDateString = startDate.ToString("yyyy-MM-dd H:mm:ss");
            DateTime endDate = endCalendar.SelectedDate.AddHours(Double.Parse(endTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(endTextBox.Text.Substring(3, 2)));
            string endDateString = endDate.ToString("yyyy-MM-dd H:mm:ss");
            string register = "insert into Resv (resv_id, resv_user_id, resv_field_id, resv_startDate, resv_endDate) values (@id,@idu,@idf,@start,@end)";
            SqlCommand cmd = new SqlCommand(register, GlobalVar.connection);
            cmd.Parameters.AddWithValue("@id", resvIDTextBox.Text);
            cmd.Parameters.AddWithValue("@idu", GlobalVar.userID);
            cmd.Parameters.AddWithValue("@idf", resvFieldIDTextBox.Text);
            cmd.Parameters.AddWithValue("@start", startDateString);
            cmd.Parameters.AddWithValue("@end", endDateString);
            GlobalVar.add(cmd, "Reservation added Successfully", "Reservation is Not Added, Try Again Please", Master);
            GlobalVar.display(ReservationTable, Master, "select [resv_id] , [resv_field_id] , [resv_startDate] , [resv_endDate] From Resv Where resv_user_id='" + GlobalVar.userID + "'");
            GlobalVar.headerChanger(new string[] { "ID", "Field ID", "Start Date", "End Date" }, ReservationTable);
            GlobalVar.clearFields(new TextBox[] { resvFieldIDTextBox, resvIDTextBox,  startTextBox, endTextBox });
            dateVaildationLabel.Text = "";
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (isClicked)
            {
                resvIDTextBox.Enabled = true;
                updateButton.Visible = false;
                deleteButton.Visible = false;
                GlobalVar.clearFields(new TextBox[] { resvIDTextBox, startTextBox, endTextBox ,resvFieldIDTextBox});
                startCalendar.SelectedDates.Clear();
                endCalendar.SelectedDates.Clear();
                isClicked = false;
                return;

            }
            isClicked = true;
            string srchsql = "select * from [Resv] where resv_id = @id and resv_user_id = @user_id";
            SqlCommand cmd = new SqlCommand(srchsql, GlobalVar.connection);
            cmd.Parameters.AddWithValue("@id", int.Parse(resvIDTextBox.Text));
            cmd.Parameters.AddWithValue("@user_id", int.Parse(GlobalVar.userID));
            SqlDataReader dr = GlobalVar.search(
                cmd,
                new TextBox[] { resvFieldIDTextBox },
                new string[] { "resv_field_id", "resv_user_id" },
                new Control[] { resvIDTextBox, updateButton, deleteButton },
                Master
                );
            if (dr is null)
            {
                isClicked = false;
                return;
            }
            deleteButton.Visible = true;
            updateButton.Visible = true;
            
            startCalendar.SelectedDate = DateTime.Parse(((DateTime)dr["resv_startDate"]).ToShortDateString());
            endCalendar.SelectedDate = DateTime.Parse(((DateTime)dr["resv_endDate"]).ToShortDateString());
            startTextBox.Text = DateTime.Parse(dr["resv_startDate"].ToString()).ToString("HH:mm:ss");
            endTextBox.Text = DateTime.Parse(dr["resv_endDate"].ToString()).ToString("HH:mm:ss");
            dateVaildationLabel.Text = "";
            cmd.Connection.Close();
            

        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            if (!vaildateInputDates())
                return;
           
            DateTime startDate = startCalendar.SelectedDate.AddHours(Double.Parse(startTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(startTextBox.Text.Substring(3, 2)));
            System.Diagnostics.Debug.WriteLine(startDate.ToString("yyyy-MM-dd H:mm:ss"));
            string startDateString = startDate.ToString("yyyy-MM-dd H:mm:ss");
            System.Diagnostics.Debug.WriteLine(startDateString);
            DateTime endDate = endCalendar.SelectedDate.AddHours(Double.Parse(endTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(endTextBox.Text.Substring(3, 2)));
            string endDateString = endDate.ToString("yyyy-MM-dd H:mm:ss");
            string updatesql = "update [Resv] set resv_user_id=@idu,resv_field_id=@idf,resv_startDate=@start, resv_endDate=@end where resv_id=@id";
            SqlCommand cmd = new SqlCommand(updatesql, GlobalVar.connection);
            cmd.Parameters.AddWithValue("@id", resvIDTextBox.Text);
            cmd.Parameters.AddWithValue("@idu", GlobalVar.userID);
            cmd.Parameters.AddWithValue("@idf", resvFieldIDTextBox.Text);
            cmd.Parameters.AddWithValue("@start", startDateString);
            cmd.Parameters.AddWithValue("@end", endDateString);
            TextBox[] textBoxesToClear = new TextBox[] { resvFieldIDTextBox, resvIDTextBox, startTextBox, endTextBox };
            GlobalVar.updateDelete(
                cmd,
                textBoxesToClear,
                new Control[] { updateButton, deleteButton, resvIDTextBox },
                Master,
                "update"
                );
            dateVaildationLabel.Text = "";
            GlobalVar.display(ReservationTable, Master, "select [resv_id] , [resv_field_id] , [resv_startDate] , [resv_endDate] From Resv Where resv_user_id='" + GlobalVar.userID + "'");
            GlobalVar.headerChanger(new string[] { "ID", "Field ID", "Start Date", "End Date" }, ReservationTable);
            GlobalVar.clearFields(new TextBox[] { resvFieldIDTextBox, resvIDTextBox, startTextBox, endTextBox });
            if (deleteButton.Visible)
            {
                deleteButton.Visible = false;
                updateButton.Visible = false;
                isClicked = false;
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            string delsql = "delete from [Resv] where resv_id=@id";
            SqlCommand cmd = new SqlCommand(delsql, GlobalVar.connection);
            cmd.Parameters.AddWithValue("@id", int.Parse(resvIDTextBox.Text));
            TextBox[] textBoxesToClear = new TextBox[] { resvFieldIDTextBox, resvIDTextBox,  startTextBox, endTextBox };
            GlobalVar.updateDelete(
                cmd,
                textBoxesToClear,
                new Control[] { updateButton, deleteButton, resvIDTextBox },
                Master,
                "update"
                );
            GlobalVar.display(ReservationTable, Master, "select [resv_id] , [resv_field_id] , [resv_startDate] , [resv_endDate] From Resv Where resv_user_id='" + GlobalVar.userID + "'");
            GlobalVar.headerChanger(new string[] { "ID", "Field ID", "Start Date", "End Date" }, ReservationTable);
            GlobalVar.clearFields(new TextBox[] { resvFieldIDTextBox, resvIDTextBox, startTextBox, endTextBox });
            dateVaildationLabel.Text = "";
            if (deleteButton.Visible)
            {
                deleteButton.Visible = false;
                updateButton.Visible = false;
                isClicked = false;
            }
        }

        protected bool vaildateInputDates()
        {
            if (startTextBox.Text == "" || endTextBox.Text == "")
            {
                GlobalVar.clearFields(new TextBox[] { resvFieldIDTextBox, resvIDTextBox,  startTextBox, endTextBox });
                dateVaildationLabel.Text = "Select a Time Please!";
                resvIDTextBox.Enabled = true;
                return false;
            }
            DateTime startDate = startCalendar.SelectedDate.AddHours(Double.Parse(startTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(startTextBox.Text.Substring(3, 2)));
            System.Diagnostics.Debug.WriteLine(startDate.ToString("yyyy-MM-dd H:mm:ss"));
            string startDateString = startDate.ToString("yyyy-MM-dd H:mm:ss");
            System.Diagnostics.Debug.WriteLine(startDateString);
            DateTime endDate = endCalendar.SelectedDate.AddHours(Double.Parse(endTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(endTextBox.Text.Substring(3, 2)));
            string endDateString = endDate.ToString("yyyy-MM-dd H:mm:ss");
            if (!GlobalVar.vaildateEnteredDates(startDate, endDate, dateVaildationLabel))
            {
                GlobalVar.clearFields(new TextBox[] { resvFieldIDTextBox, resvIDTextBox,  startTextBox, endTextBox });
                resvIDTextBox.Enabled = true;
                return false;
            }
            return isFree();
        }
        public bool isFree()
        {
            DateTime startDay, endDay;
            SqlCommand command = new SqlCommand("select * from Resv where [resv_field_id]='" + resvFieldIDTextBox.Text + "'", GlobalVar.connection);
            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                         startDay =Convert.ToDateTime( reader["resv_startDate"] );
                         endDay =  Convert.ToDateTime( reader["resv_endDate"] );

                    DateTime startDate = startCalendar.SelectedDate.AddHours(Double.Parse(startTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(startTextBox.Text.Substring(3, 2)));
                    DateTime endDate = endCalendar.SelectedDate.AddHours(Double.Parse(endTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(endTextBox.Text.Substring(3, 2)));

                    if (startDate.Day == startDay.Day &&startDate.Month==startDay.Month)
                    {
                        if ((endDate.TimeOfDay < endDay.TimeOfDay && endDate.TimeOfDay > startDay.TimeOfDay)
                            || (startDate.TimeOfDay < endDay.TimeOfDay && startDate.TimeOfDay > startDay.TimeOfDay)
                            || (startDay.TimeOfDay == startDate.TimeOfDay || endDate.TimeOfDay == endDay.TimeOfDay))
                        {
                            GlobalVar.showMessage("The date you have selected is not available .. try selecting diffrenet time or a day", WarningType.Warning, Master);
                            command.Connection.Close();
                            return false;
                        }
                    }
                    }
                }
            catch (SqlException ex)
            {
                GlobalVar.showMessage("Sorry the server could not be contacted\n" + ex.Message, WarningType.Danger, Master);
             
                return false;
            }
            catch (Exception ex)
            {
                GlobalVar.showMessage("Unknown error ... \n" + ex.Message, WarningType.Danger, Master);
                
                return false;
            }
            finally
            {
                command.Connection.Close();
            }
            command.Connection.Close();
            return true;

        }
    }  
}
