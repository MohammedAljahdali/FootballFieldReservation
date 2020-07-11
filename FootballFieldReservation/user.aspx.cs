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
            Label1.Text = GlobalVar.userName;
            SqlCommand cmd = new SqlCommand("select [resv_id] , [resv_field_id] , [resv_startDate] , [resv_endDate] From Resv Where [resv_user_id]='1855415'", GlobalVar.connection);
            try
            {
                cmd.Connection.Close();
                cmd.Connection.Open();
                resvTable.DataSource=cmd.ExecuteReader();

                resvTable.DataBind();
                GlobalVar.headerChanger(new string[] { "ID", "Field ID", "Start Date", "End Date" }, resvTable);
            }
            catch(SqlException ex)
            {
                cmd.Connection.Close();
                GlobalVar.showMessage("Sorry we are unable to connect you to the reservation table\t d-:" + ex.StackTrace, WarningType.Danger, Master);
            }catch(Exception ex)
            {
                GlobalVar.showMessage("Sorry we are unable to connect you to the reservation table :" + ex.StackTrace, WarningType.Danger, Master);
            }
            cmd.Connection.Close();
            userIdTextBox.Enabled = false;
        }

        protected void updateB_Click(object sender, EventArgs e)
        {

        }
       
        protected void deleteB_Click(object sender, EventArgs e)
        {

        }
    }
}