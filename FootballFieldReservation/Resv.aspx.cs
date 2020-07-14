using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FootballFieldReservation
{
    public partial class Resv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalVar.display(FieldsTable, Master, "select * from [Field]");
            GlobalVar.headerChanger(new string[] { "ID", "Name", "Capacity", "Address" }, FieldsTable);
            GlobalVar.display(ReservationTable, Master, "select [resv_id] , [resv_field_id] , [resv_startDate] , [resv_endDate] From Resv");
            GlobalVar.headerChanger(new string[] { "ID", "Field ID", "Start Date", "End Date" }, ReservationTable);
        }

        protected void RefreshFB_Click(object sender, EventArgs e)
        {
            GlobalVar.display(FieldsTable, Master, "select * from [Field]");
            GlobalVar.headerChanger(new string[] { "ID", "Name", "Capacity", "Address" }, FieldsTable);
        }

        protected void RefreshB_Click(object sender, EventArgs e)
        {
            GlobalVar.display(ReservationTable, Master, "select [resv_id] , [resv_field_id] , [resv_startDate] , [resv_endDate] From Resv");
            GlobalVar.headerChanger(new string[] { "ID", "Field ID", "Start Date", "End Date" }, ReservationTable);
        }
    }
}