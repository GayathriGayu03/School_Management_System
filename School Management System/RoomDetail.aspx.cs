using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
namespace Schoolmanagementsystem
{
    public partial class RoomDetail : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void view_btn_Click(object sender, EventArgs e)
        {

            if(type_dpdown.Text=="Silver")
            {
                da.SelectCommand = new OleDbCommand("select * from Roomdetails where Roomtype='"+type_dpdown.Text+"'", con);
                ds.Clear();
                da.Fill(ds);
                room_grid.Visible = true;
                room_grid.DataSource = ds;
                room_grid.DataBind();
            }
            if (type_dpdown.Text == "Gold")
            {
                da.SelectCommand = new OleDbCommand("select * from Roomdetails where Roomtype='" + type_dpdown.Text + "'", con);
                ds.Clear();
                da.Fill(ds);
                room_grid.Visible = true;
                room_grid.DataSource = ds;
                room_grid.DataBind();
            }
            if (type_dpdown.Text == "Platinum")
            {
                da.SelectCommand = new OleDbCommand("select * from Roomdetails where Roomtype='" + type_dpdown.Text + "'", con);
                ds.Clear();
                da.Fill(ds);
                room_grid.Visible = true;
                room_grid.DataSource = ds;
                room_grid.DataBind();
            }
            if (type_dpdown.Text == "All")
            {
                da.SelectCommand = new OleDbCommand("select * from Roomdetails", con);
                ds.Clear();
                da.Fill(ds);
                room_grid.Visible = true;
                room_grid.DataSource = ds;
                room_grid.DataBind();
            }

        }

        protected void reset_btn_Click(object sender, EventArgs e)
        {
            room_grid.Visible = false;
        }

        

        
    }
}
