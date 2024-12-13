using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food_Menu
{
    public partial class Restraunt : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFood();
                BindGridview();
                ddlcat.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        public void BindFood()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblfood", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlft.DataValueField = "fid";
            ddlft.DataTextField = "fname";
            ddlft.DataSource = dt;
            ddlft.DataBind();
            ddlft.Items.Insert(0, new ListItem("--Select--", "0"));


        }
        public void BindCategory()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from tblfoodtype where fid='" + ddlft.SelectedValue + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcat.DataValueField = "ftid";
            ddlcat.DataTextField = "ftname";
            ddlcat.DataSource = dt;
            ddlcat.DataBind();
            ddlcat.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        public void Clear()
        {
            textname.Text = "";
            ddlft.SelectedValue = "0";
            ddlcat.SelectedValue = "0";
        }

        protected void ddlft_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCategory();
        }

        public void BindGridview()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from tblresturant join tblfood on tblresturant.fid=tblfood.fid join tblfoodtype on tblresturant.ftid=tblfoodtype.ftid", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvresturant.DataSource = dt;
            gvresturant.DataBind();
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            if (btninsert.Text == "INSERT")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into tblresturant(name,fid,ftid)values('" + textname.Text + "','" + ddlft.SelectedValue + "','" + ddlcat.SelectedValue + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                BindGridview();
            }
            else if (btninsert.Text == "UPDATE")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update  tblresturant set name='" + textname.Text + "',fid='" + ddlft.SelectedValue + "',ftid='" + ddlcat.SelectedValue + "' where rid='" + ViewState["pp"] +"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                BindGridview();
            }

        }

        protected void gvresturant_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "dlt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblresturant where rid='" + e.CommandArgument + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGridview();

            }
            else if (e.CommandName == "edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select* from tblresturant where rid='" + e.CommandArgument + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                textname.Text = dt.Rows[0]["name"].ToString();
                BindFood();
                ddlft.SelectedValue = dt.Rows[0]["fid"].ToString();
                BindCategory();
                ddlcat.SelectedValue = dt.Rows[0]["ftid"].ToString();
                btninsert.Text = "UPDATE";
                ViewState["pp"] = e.CommandArgument;
            }
        }
    }
}