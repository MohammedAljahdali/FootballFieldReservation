﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FootballFieldReservation
{
    public partial class AdminReservationManagment : System.Web.UI.Page
    {
        static bool isClicked = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            GlobalVar.display(resvTable ,Master, "select * From Resv");
            GlobalVar.headerChanger(new string[] { "ID", "User ID", "Field ID", "Start Date", "End Date" }, resvTable);

            updateButton.Visible = false;
            deleteButton.Visible = false;
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            if (!vaildateInputDates())
                return;
              
            //if (startTextBox.Text == "" || endTextBox.Text == "")
            //{
            //    GlobalVar.clearFields(new TextBox[] { resvFieldIDTextBox, resvIDTextBox, resvUserIDTextBox, startTextBox, endTextBox });
            //    dateVaildationLabel.Text = "Select a Time Please!";
            //    return;
            //}
            DateTime startDate = startCalendar.SelectedDate.AddHours(Double.Parse(startTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(startTextBox.Text.Substring(3, 2)));
            System.Diagnostics.Debug.WriteLine(startDate.ToString("yyyy-MM-dd H:mm:ss"));
            string startDateString = startDate.ToString("yyyy-MM-dd H:mm:ss");
            System.Diagnostics.Debug.WriteLine(startDateString);
            DateTime endDate = endCalendar.SelectedDate.AddHours(Double.Parse(endTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(endTextBox.Text.Substring(3, 2)));
            string endDateString = endDate.ToString("yyyy-MM-dd H:mm:ss");
            //if (!GlobalVar.vaildateEnteredDates(startDate, endDate, dateVaildationLabel))
            //{
            //    GlobalVar.clearFields(new TextBox[] { resvFieldIDTextBox, resvIDTextBox, resvUserIDTextBox, startTextBox, endTextBox });
            //    return;
            //}

            string register = "insert into Resv (resv_id, resv_user_id, resv_field_id, resv_startDate, resv_endDate) values (@id,@idu,@idf,@start,@end)";
            SqlCommand cmd = new SqlCommand(register, GlobalVar.connection);
            cmd.Parameters.AddWithValue("@id", resvIDTextBox.Text);
            cmd.Parameters.AddWithValue("@idu", resvUserIDTextBox.Text);
            cmd.Parameters.AddWithValue("@idf", resvFieldIDTextBox.Text);
            cmd.Parameters.AddWithValue("@start", startDateString);
            cmd.Parameters.AddWithValue("@end", endDateString);
            GlobalVar.add(cmd, "Reservation added Successfully", "Reservation is Not Added, Try Again Please", Master);
            GlobalVar.display(resvTable, Master, "select [resv_id] , [resv_field_id] , [resv_startDate] , [resv_endDate] From Resv");
            GlobalVar.headerChanger(new string[] { "ID", "Field ID", "Start Date", "End Date" }, resvTable);
            GlobalVar.clearFields(new TextBox[] { resvFieldIDTextBox, resvIDTextBox, resvUserIDTextBox, startTextBox, endTextBox });
            dateVaildationLabel.Text = "";
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (isClicked)
            {
                resvIDTextBox.Enabled = true;
                updateButton.Visible = false;
                deleteButton.Visible = false;
                GlobalVar.clearFields(new TextBox[] { resvIDTextBox, startTextBox, endTextBox ,resvFieldIDTextBox,resvUserIDTextBox});
                startCalendar.SelectedDates.Clear();
                endCalendar.SelectedDates.Clear();
                isClicked = false;
                return;

            }
            isClicked = true;
            string srchsql = "select * from [Resv] where resv_id = @id";
            SqlCommand cmd = new SqlCommand(srchsql, GlobalVar.connection);
            // Mapping Parameter
            cmd.Parameters.AddWithValue("@id", int.Parse(resvIDTextBox.Text));
            // System.Diagnostics.Debug.WriteLine(userIDTextBox.Text);
            SqlDataReader dr = GlobalVar.search(
                cmd,
                new TextBox[] { resvFieldIDTextBox, resvUserIDTextBox },
                new string[] { "resv_field_id", "resv_user_id"},
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
            startCalendar.SelectedDate =DateTime.Parse(((DateTime)dr["resv_startDate"]).ToShortDateString());
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
            //if (startTextBox.Text == "" || endTextBox.Text == "")
            //{
            //    GlobalVar.clearFields(new TextBox[] { resvFieldIDTextBox, resvIDTextBox, resvUserIDTextBox, startTextBox, endTextBox });
            //    dateVaildationLabel.Text = "Select a Time Please!";
            //    resvIDTextBox.Enabled = true;
            //    return;
            //}
            DateTime startDate = startCalendar.SelectedDate.AddHours(Double.Parse(startTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(startTextBox.Text.Substring(3, 2)));
            System.Diagnostics.Debug.WriteLine(startDate.ToString("yyyy-MM-dd H:mm:ss"));
            string startDateString = startDate.ToString("yyyy-MM-dd H:mm:ss");
            System.Diagnostics.Debug.WriteLine(startDateString);
            DateTime endDate = endCalendar.SelectedDate.AddHours(Double.Parse(endTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(endTextBox.Text.Substring(3, 2)));
            string endDateString = endDate.ToString("yyyy-MM-dd H:mm:ss");
            //if (!GlobalVar.vaildateEnteredDates(startDate, endDate, dateVaildationLabel))
            //{
            //    GlobalVar.clearFields(new TextBox[] { resvFieldIDTextBox, resvIDTextBox, resvUserIDTextBox, startTextBox, endTextBox });
            //    resvIDTextBox.Enabled = true;
            //    return;
            //}

            string updatesql = "update [Resv] set resv_user_id=@idu,resv_field_id=@idf,resv_startDate=@start, resv_endDate=@end where resv_id=@id";
            SqlCommand cmd = new SqlCommand(updatesql, GlobalVar.connection);
            cmd.Parameters.AddWithValue("@id", resvIDTextBox.Text);
            cmd.Parameters.AddWithValue("@idu", resvUserIDTextBox.Text);
            cmd.Parameters.AddWithValue("@idf", resvFieldIDTextBox.Text);
            cmd.Parameters.AddWithValue("@start", startDateString);
            cmd.Parameters.AddWithValue("@end", endDateString);
            TextBox[] textBoxesToClear = new TextBox[] { resvFieldIDTextBox, resvIDTextBox, resvUserIDTextBox, startTextBox, endTextBox };
            GlobalVar.updateDelete(
                cmd,
                textBoxesToClear,
                new Control[] { updateButton, deleteButton, resvIDTextBox },
                Master,
                "update"
                );
            dateVaildationLabel.Text = "";
            GlobalVar.display(resvTable, Master, "select [resv_id] , [resv_field_id] , [resv_startDate] , [resv_endDate] From Resv");
            GlobalVar.headerChanger(new string[] { "ID", "Field ID", "Start Date", "End Date" }, resvTable);
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
            TextBox[] textBoxesToClear = new TextBox[] { resvFieldIDTextBox, resvIDTextBox, resvUserIDTextBox, startTextBox, endTextBox };
            GlobalVar.updateDelete(
                cmd,
                textBoxesToClear,
                new Control[] { updateButton, deleteButton, resvIDTextBox },
                Master,
                "update"
                );
            GlobalVar.display(resvTable, Master, "select [resv_id] , [resv_field_id] , [resv_startDate] , [resv_endDate] From Resv");
            GlobalVar.headerChanger(new string[] { "ID", "Field ID", "Start Date", "End Date" }, resvTable);
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
                GlobalVar.clearFields(new TextBox[] { resvFieldIDTextBox, resvIDTextBox, resvUserIDTextBox, startTextBox, endTextBox });
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
                GlobalVar.clearFields(new TextBox[] { resvFieldIDTextBox, resvIDTextBox, resvUserIDTextBox, startTextBox, endTextBox });
                resvIDTextBox.Enabled = true;
                return false;
            }
            return isFree();
        }

        public bool isFree()
        {
            DateTime startDateReserved, endDateReserved;
            SqlCommand command = new SqlCommand("select * from Resv where [resv_field_id]='" + resvFieldIDTextBox.Text + "'", GlobalVar.connection);
            DateTime startDate = startCalendar.SelectedDate.AddHours(Double.Parse(startTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(startTextBox.Text.Substring(3, 2)));
            DateTime endDate = endCalendar.SelectedDate.AddHours(Double.Parse(endTextBox.Text.Substring(0, 2))).AddMinutes(Double.Parse(endTextBox.Text.Substring(3, 2)));
            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    startDateReserved = Convert.ToDateTime(reader["resv_startDate"]);
                    endDateReserved = Convert.ToDateTime(reader["resv_endDate"]);

                    if (startDate.Day == startDateReserved.Day&&startDate.Month==startDateReserved.Month)
                    {
                        if ((startDate <= startDateReserved && endDate >= startDateReserved)
                            || (startDate <= endDateReserved && endDate >= endDateReserved))
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