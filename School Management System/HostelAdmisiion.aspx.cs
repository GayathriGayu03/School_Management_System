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
    
    public partial class HostelAdmisiion : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\School.mdb;");
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
       string fee;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void reg_btn_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new OleDbCommand("select regno from hosteladmission where regno='" + regno_txtbx.Text + "'", con);
            ds.Clear();
            da.Fill(ds);
           if(ds.Tables[0].Rows.Count>0)
            {
                sts_lbl.Visible = true;
               sts_lbl.ForeColor = System.Drawing.Color.Red;
                sts_lbl.Text = "Already Registered...";
            }
           else
            {
                if(roomtype_dpdown.Text!="Select Anyone")
                {
                    con.Open();
                    GridViewRow gr = room_view.SelectedRow;
                    fee = (gr.Cells[2].Text);
                    string roomno = (gr.Cells[1].Text);
                    da.InsertCommand = new OleDbCommand("insert into hosteladmission(regno,sname,dob,address,roomtype,phoneno,email,fee,bg,roomno,status) values('" + regno_txtbx.Text + "','" + name_txtbx.Text + "','" + dob_txtbx.Text + "','" + address_txtbx.Text + "','" + roomtype_dpdown.Text + "','" + pn_txtbx.Text + "','" + em_txtbx.Text + "','" + fee + "','" + bgroup_txtbx.Text + "','" + roomno + "','NotPaid')", con);
                    sts_lbl.Visible = true;
                    sts_lbl.ForeColor = System.Drawing.Color.Green;
                    sts_lbl.Text = "Values Are Stored Into Database";
                    da.InsertCommand.ExecuteNonQuery();
                    da.UpdateCommand = new OleDbCommand("update Roomdetails set Status='N/A' where Roomno='" + gr.Cells[1].Text+"'", con);
                    da.UpdateCommand.ExecuteNonQuery();
                    con.Close();
                }
                  else
                {
                    sts_lbl.Visible = true;
                    sts_lbl.ForeColor = System.Drawing.Color.Red;
                    sts_lbl.Text = "Select Room Type And Room ";
                }
               
                
            }
            
        }

     

      

        protected void ok_btn_Click(object sender, EventArgs e)
        {
            
                da.SelectCommand = new OleDbCommand("select * from Roomdetails where Roomtype='" + roomtype_dpdown.Text + "' AND Status='Available'", con);
                ds.Clear();
                da.Fill(ds);
                room_view.DataSource = ds;
                room_view.DataBind();
               
                
        }

        protected void sub_btn_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new OleDbCommand("select sname,dob,bgroup,address,contactno,email from schooladmission where regno='" + regno_txtbx.Text + "'", con);
            ds.Clear();
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count>0)
            {
                
                
                Label13.Visible = false;
                name_txtbx.Text = ds.Tables[0].Rows[0][0].ToString();
                dob_txtbx.Text = ds.Tables[0].Rows[0][1].ToString();
                bgroup_txtbx.Text = ds.Tables[0].Rows[0][2].ToString();
                address_txtbx.Text = ds.Tables[0].Rows[0][3].ToString();
                pn_txtbx.Text = ds.Tables[0].Rows[0][4].ToString();
                em_txtbx.Text = ds.Tables[0].Rows[0][5].ToString();
            }
            else
            {
                
                Label13.ForeColor = System.Drawing.Color.Red;
                Label13.Visible = true;
                Label13.Text = "Enter Valid Register Number";
               

            }
           
        }

        protected void clr_btn_Click(object sender, EventArgs e)
        {
           
            name_txtbx.Text = "";
            dob_txtbx.Text = "";
            bgroup_txtbx.Text = "";
            address_txtbx.Text = "";
            pn_txtbx.Text = "";
            em_txtbx.Text = "";
            regno_txtbx.Text = "";
            Label13.Visible = false;
            sts_lbl.Visible = false;
        }

        protected void room_view_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}