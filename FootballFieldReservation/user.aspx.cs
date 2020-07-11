using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FootballFieldReservation
{
    public partial class user : System.Web.UI.Page
    {
        static bool once = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            userIdTextBox.Text = "1855415";
            try
               // select[resv_id] , resv_field_id , resv_startDate , resv_endDate from Resv Where resv_user_id = '" +
            {
               // select[resv_id] , [resv_field_id] , [resv_startDate] , [resv_endDate] From[Lap - Project].[dbo].[Resv] Where[resv_user_id] = '1855415'
                GlobalVar.connection.Open();
                resvTable.DataSource = new SqlCommand("select[resv_id] , [resv_field_id] , [resv_startDate] , [resv_endDate] From [Resv] Where[resv_user_id] ='" +
                    userIdTextBox.Text + "'", GlobalVar.connection).ExecuteReader();
                resvTable.DataBind();
            }catch(SqlException ex)
            {
                GlobalVar.showMessage("Sorry we are unable to connect you to the reservation table\t d-:" + ex.Message, WarningType.Danger, Master);
            }
            catch(Exception ex)
            {
                GlobalVar.showMessage("Sorry we are unable to connect you to the reservation table\t d-:"+ex.Message, WarningType.Danger, Master);
            }
            userIdTextBox.Enabled = false;
        }

        protected void updateB_Click(object sender, EventArgs e)
        {
            if (!userPasswordText.Text.Equals(userConfiemPasswordTextBox.Text))
            {
                GlobalVar.showMessage("your passwrods does not match , Try again ..", WarningType.Danger, Master);
                return;
            }
            GlobalVar.updateDelete(new SqlCommand("update User set user_name='"
                + userNameTextBox.Text + "' , user_password='" + userPasswordText.Text + "'",GlobalVar.connection),
                new TextBox[] { userPasswordText, userConfiemPasswordTextBox }
                , new Control[] { userNameTextBox}, Master, "update");
        }
       
        protected void deleteB_Click(object sender, EventArgs e)
        {
     GlobalVar.updateDelete(new SqlCommand("delete from User where user_id='" + userIdTextBox.Text + "'", GlobalVar.connection)
    , new TextBox[0], new Control[0], Master, "delete");
        }
    }
}