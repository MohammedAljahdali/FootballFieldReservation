﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FootballFieldReservation
{
    public static class GlobalVar
    {
        public static string userRole = "";
        public static string userID = "";
        public static string userName = "";
        public static string datePattren = "yyyy-MM-dd HH:mm:ss.fff";
        public static SqlConnection connection = new SqlConnection(
                 File.OpenText(
                (AppDomain.CurrentDomain.BaseDirectory.ToString())
                .Substring(0,
                AppDomain.CurrentDomain.BaseDirectory.ToString().Length -
                "FootballFieldReservation".Length - 1) + "ignore/" + "conn.txt").ReadToEnd());
 

        // = new SqlConnection("test");
        /// <summary>
        /// Shows a message based of type and message
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="type">ENUM type of the message</param>

        public static void showMessage(string message, WarningType type, MasterPage master)
        {
            //gets the controls from the page
            Panel panelMessage = master.FindControl("alertMessage") as Panel;
            Label labelAlertMessage = panelMessage.FindControl("labelAlertMessage") as Label;

            //sets the message and the type of alert, than displays the message
            labelAlertMessage.Text = message;
            panelMessage.CssClass = string.Format("alert alert-{0} alert-dismissable", type.ToString().ToLower());
            panelMessage.Attributes.Add("role", "alert");
            panelMessage.Visible = true;

        

        }

        public static void display(GridView gridView, MasterPage master, string sql)
        {
            // Create SQlStatement
            
            //create command object
            SqlCommand cmd = new SqlCommand(sql, connection);
            try
            { // open the connection
                cmd.Connection.Open();
                // cretae data reader obj
                SqlDataReader dr;
                //executing the method of command object
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                { // binding grid view with data source
                    gridView.DataSource = dr;
                    gridView.DataBind();
                }
                else
                    showMessage("sorry something happend", WarningType.Warning, master);
            } // end of try
            catch (Exception ex)
            {
                showMessage("error reading the database: "+ex.Message, WarningType.Danger, master);
            }
            finally
            {
                cmd.Connection.Close();
            }
            cmd.Connection.Close();
        }

        public static bool add(SqlCommand cmd, String successMessage, String failMessage, MasterPage master)
        {
            int success = 0;
            try
            {
                cmd.Connection.Open();
                //executing the method of command object
                // ExecuteNonQuery() method of command object is used for insert the record
                success = cmd.ExecuteNonQuery();

                if (success == 1)
                {
                    GlobalVar.showMessage(successMessage, WarningType.Success, master);
                    cmd.Connection.Close();
                    return true;
                }
                else
                {
                    GlobalVar.showMessage(failMessage, WarningType.Warning, master);
                    cmd.Connection.Close();
                    return false;
                }

            } // end of try
            catch (Exception ex)
            {
                GlobalVar.showMessage(failMessage+": "+ex.Message, WarningType.Danger, master);
                return false;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public static bool addUser(TextBox passwordInputField, TextBox confirmPasswordInputField, TextBox idInputField, TextBox nameInputField, Label confirmPasswordValidation, bool confirmPassword, MasterPage master, string role)
        {
            
            if (confirmPassword)
            {
                if (passwordInputField.Text != confirmPasswordInputField.Text)
                {
                    confirmPasswordValidation.Text = "Passwords does not match";
                    confirmPasswordValidation.ForeColor = System.Drawing.Color.Red;
                    return false;
                }
                
            }


            string register = "insert into [User] (user_id, user_name, user_password, user_role) values (@user_id,@user_name,@user_password,@user_role)";
            SqlCommand cmd = new SqlCommand(register, GlobalVar.connection);
            cmd.Parameters.AddWithValue("@user_id", idInputField.Text);
            cmd.Parameters.AddWithValue("@user_name", nameInputField.Text);
            cmd.Parameters.AddWithValue("@user_password", passwordInputField.Text);
            cmd.Parameters.AddWithValue("@user_role", role);
            if (confirmPassword)
                return add(cmd,"Signing Up Successed", "Signing Up Failed Try Again Please", master);
            else
                return add(cmd, "Adding User Successed", "Adding User Failed Try Again Please", master);
        }

        public static SqlDataReader search(SqlCommand cmd, TextBox[] textBoxes, String[] columns, Control[] controls, MasterPage Master)
        {

            try
            {
                cmd.Connection.Open();
                //executing the method of command object
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int index = 0;
                    foreach (TextBox textBox in textBoxes)
                    {
                        textBox.Text = dr[columns[index]].ToString();
                        index++;
                    }
                    foreach (WebControl control in controls)
                    {
                        if (control is TextBox)
                            control.Enabled = false;
                        else
                            control.Enabled = true;
                    }
                    GlobalVar.showMessage("Record Found", WarningType.Success, Master);
                    
                    return dr;
                }
                else
                    GlobalVar.showMessage("Sorry Record Not Found", WarningType.Danger, Master);
                cmd.Connection.Close();
                return null;
            } // end of try
            catch (Exception ex)
            {
                GlobalVar.showMessage("error reading the database: " + ex.Message, WarningType.Danger, Master);
                cmd.Connection.Close();
                return null;
            }
        }

        public static void updateDelete(SqlCommand cmd, TextBox[] textBoxesToClear, Control[] controls, MasterPage Master, String typeString)
        {
            int success = 0;
            try
            {
                cmd.Connection.Open();
                //executing the method of command object
                success = cmd.ExecuteNonQuery();
                if (success == 1)
                {
                    GlobalVar.showMessage("Record "+ typeString + " Successfully", WarningType.Success, Master);
                    // to make the text box clear
                    GlobalVar.clearFields(textBoxesToClear);
                    foreach (WebControl control in controls)
                    {
                        if (control is TextBox)
                            control.Enabled = true;
                        else
                            control.Enabled = false;
                    }


                }
                else
                {
                    GlobalVar.showMessage("Record " + typeString + " Failed", WarningType.Danger, Master);
                    // to make the text box clear
                    GlobalVar.clearFields(textBoxesToClear);
                    foreach (WebControl control in controls)
                    {
                        if (control is TextBox)
                            control.Enabled = true;
                        else
                            control.Enabled = false;
                    }
                }

            } // end of try
            catch (Exception ex)
            {
                GlobalVar.showMessage("Record " + typeString + " Failed: " + ex.Message, WarningType.Danger, Master);
                // to make the text box clear
                GlobalVar.clearFields(textBoxesToClear);
                foreach (WebControl control in controls)
                {
                    if (control is TextBox)
                        control.Enabled = true;
                    else
                        control.Enabled = false;
                }
            }
            finally
            {
                cmd.Connection.Close();
            }
            cmd.Connection.Close();
        }


        public static void clearFields(TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Text = "";
            }
        }

        public static void headerChanger(string [] colName,GridView grid)
        {
            if (grid.Rows.Count==0)
                return;
            for(int i =0; i < colName.Length; i++)
            {
                grid.HeaderRow.Cells[i].Text = colName[i];
            }
        }

        public static bool vaildateEnteredDates(DateTime startDate, DateTime endDate, Label dateVaildationLabel)
        {
            TimeSpan timeSpan = endDate - startDate;
            TimeSpan startTimeSpan = startDate - DateTime.Now;
            System.Diagnostics.Debug.WriteLine(timeSpan.TotalHours);
            if (startTimeSpan.TotalHours < 0)
            {
                dateVaildationLabel.Text = "Please Enter a Correct Start Date";
                return false;
                //System.Diagnostics.Debug.WriteLine("hey");
            }
            System.Diagnostics.Debug.WriteLine(DateTime.Compare(endDate, startDate));
            switch (DateTime.Compare(endDate, startDate))
            {
                case 1:
                    dateVaildationLabel.Text = "";
                    break;
                case 0:
                    dateVaildationLabel.Text = "Start and End dates can not be the same!";
                    return false;
                case -1:
                    dateVaildationLabel.Text = "Please Enter a Correct End Date";
                    return false;
            }
            // check the is the resv time is at least 1 hour
            if (timeSpan.TotalHours < 1)
            {
                System.Diagnostics.Debug.WriteLine(timeSpan.TotalHours);
                dateVaildationLabel.Text = "The Reservation Duration must be at least 1 hour!";
                return false;
            } else if (timeSpan.TotalHours > 3) {
                dateVaildationLabel.Text = "The Reservation Duration most be at most 3 hour!";
                return false;
            }
            return true;
        }

    }

    public enum WarningType
    {
        Success,
        Info,
        Warning,
        Danger
    }
}