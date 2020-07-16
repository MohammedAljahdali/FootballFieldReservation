using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FootballFieldReservation
{
    public partial class AdminFieldsManagment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalVar.display(fieldsTable, Master, "select * from [Field]");
            GlobalVar.headerChanger(new string[] { "ID", "Name", "Capacity", "Address" }, fieldsTable);
            updateButton.Enabled = false;
            deleteButton.Enabled = false;
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string srchsql = "select * from [Field] where field_id = @id";
            SqlCommand cmd = new SqlCommand(srchsql, GlobalVar.connection);
            // Mapping Parameter
            cmd.Parameters.AddWithValue("@id", int.Parse(fieldIDTextBox.Text));
            // System.Diagnostics.Debug.WriteLine(userIDTextBox.Text);
            GlobalVar.search(
                cmd,
                new TextBox[] { fieldNameTextBox, fieldAddressTextBox, fieldCapacityTextBox },
                new string[] { "field_name", "field_address", "field_capacity" },
                new Control[] { fieldIDTextBox, updateButton, deleteButton },
                Master
                );
            GlobalVar.display(fieldsTable, Master, "select * from [Field]");
            cmd.Connection.Close();
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string register = "insert into Field (field_id, field_name, field_address, field_capacity) values (@id,@name,@address,@capacity)";
            SqlCommand cmd = new SqlCommand(register, GlobalVar.connection);
            cmd.Parameters.AddWithValue("@id", fieldIDTextBox.Text);
            cmd.Parameters.AddWithValue("@name", fieldNameTextBox.Text);
            cmd.Parameters.AddWithValue("@address", fieldAddressTextBox.Text);
            cmd.Parameters.AddWithValue("@capacity", fieldCapacityTextBox.Text);
            GlobalVar.add(cmd, "Field added Successfully", "Field is Not Added, Try Again Please", Master);
            GlobalVar.display(fieldsTable, Master, "select * from [Field]");
            GlobalVar.clearFields(new TextBox[] { fieldNameTextBox, fieldAddressTextBox, fieldCapacityTextBox, fieldIDTextBox });
            
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            string updatesql = "update [Field] set field_name=@name,field_id=@id,field_address=@address, field_capacity=@capacity where field_id=@id";
            SqlCommand cmd = new SqlCommand(updatesql, GlobalVar.connection);
            cmd.Parameters.AddWithValue("@id", fieldIDTextBox.Text);
            cmd.Parameters.AddWithValue("@name", fieldNameTextBox.Text);
            cmd.Parameters.AddWithValue("@address", fieldAddressTextBox.Text);
            cmd.Parameters.AddWithValue("@capacity", fieldCapacityTextBox.Text);
            TextBox[] textBoxesToClear = new TextBox[] { fieldNameTextBox, fieldAddressTextBox, fieldCapacityTextBox, fieldIDTextBox };
            GlobalVar.updateDelete(
                cmd,
                textBoxesToClear,
                new Control[] { updateButton, deleteButton, fieldIDTextBox },
                Master,
                "update"
                );
            GlobalVar.display(fieldsTable, Master, "select * from [Field]");
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            string delsql = "delete from [Field] where field_id=@id";
            SqlCommand cmd = new SqlCommand(delsql, GlobalVar.connection);
            cmd.Parameters.AddWithValue("@id", fieldIDTextBox.Text);
            TextBox[] textBoxesToClear = new TextBox[] { fieldNameTextBox, fieldAddressTextBox, fieldCapacityTextBox, fieldIDTextBox };
            GlobalVar.updateDelete(
                cmd,
                textBoxesToClear,
                new Control[] { updateButton, deleteButton, fieldIDTextBox },
                Master,
                "delete"
                );
            GlobalVar.display(fieldsTable, Master, "select * from [Field]");
        }
    }
}