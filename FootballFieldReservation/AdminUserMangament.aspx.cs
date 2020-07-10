using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FootballFieldReservation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalVar.displayUsers(usersTable, Master);
            updateButton.Enabled = false;
            deleteButton.Enabled = false;
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            GlobalVar.addUser(userPasswordTextBox, null, userIDTextBox, userNameTextBox, null, false, Master);
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string srchsql = "select * from [User] where user_id=@id";
            SqlCommand cmd = new SqlCommand(srchsql, GlobalVar.connection);
            // Mapping Parameter
            cmd.Parameters.AddWithValue("@id", userIDTextBox.Text);
            try
            {
                cmd.Connection.Open();
                //executing the method of command object
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    userNameTextBox.Text = dr["user_name"].ToString();
                    userPasswordTextBox.Text = dr["user_password"].ToString();
                    userRoleTextBox.Text = dr["user_role"].ToString();

                    //passwordTextBox1.Text = dr["emp_password"].ToString();
                    userIDTextBox.Enabled = false;
                    updateButton.Enabled = true;
                    deleteButton.Enabled = true;
                    GlobalVar.showMessage("Record Found", WarningType.Success, Master);
                }
                else
                    GlobalVar.showMessage("Sorry Record Not Found", WarningType.Danger, Master);
                


            } // end of try
            catch (Exception ex)
            {
                GlobalVar.showMessage("error reading the database" + ex.Message, WarningType.Danger, Master);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}