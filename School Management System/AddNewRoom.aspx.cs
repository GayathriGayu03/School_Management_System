using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace School_Management_System
{
    public partial class AddNewRoom : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new OleDbCommand("Select Roomno from Roomdetails where Roomno='"+roomno_txtbx.Text+"'", con);
            ds.Clear();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                con.Open();
                da.InsertCommand = new OleDbCommand("insert into Roomdetails(Roomno,RoomPrice,RoomType,Status) values('" + roomno_txtbx.Text + "','" + roomrate_btn.Text + "','" + type_dpdown.Text + "','Available')", con);
                sts_lbl.Visible = true;
                sts_lbl.ForeColor = System.Drawing.Color.Green;
                sts_lbl.Text = "Values Are Stored Into Database";
                da.InsertCommand.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                sts_lbl.Visible = true;
                sts_lbl.ForeColor = System.Drawing.Color.Red;
                sts_lbl.Text = "Enter Different Room No";
            }
        }

        protected void clr_btn_Click(object sender, EventArgs e)
        {
            roomno_txtbx.Text = "";
            roomrate_btn.Text = "";
            sts_lbl.Visible = false;
        }

       
    }
}