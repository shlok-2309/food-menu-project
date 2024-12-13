using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food_Menu
{
    public partial class Empolyee : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCource();
                BindGridview();
                ddlbranch.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        public void BindCource()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from tblcource", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcource.DataValueField = "cid";
            ddlcource.DataTextField = "cname";
            ddlcource.DataSource = dt;
            ddlcource.DataBind();
            ddlcource.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        public void BindBranch()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from tblbran where cid='" + ddlcource.SelectedValue + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlbranch.DataValueField = "bid";
            ddlbranch.DataTextField = "bname";

            ddlbranch.DataSource = dt;
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void ddlcource_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBranch();
        }

        public void Clear()
        {
            textname.Text = "";
            ddlcource.SelectedValue = "0";
            ddlbranch.SelectedValue = "0";
        }

        public void BindGridview()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from tbldetails  join tblcource on tbldetails.cid=tblcource.cid join tblbran on tbldetails.bid=tblbran.bid", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvemploye.DataSource = dt;
            gvemploye.DataBind();
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            if (btninsert.Text == "INSERT")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into tbldetails(name,cid,bid)values('" + textname.Text + "','" + ddlcource.SelectedValue + "','" + ddlbranch.SelectedValue + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                BindGridview();
            }
            else if (btninsert.Text == "UPDATE")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update tbldetails set name='" + textname.Text + "',cid='" + ddlcource.SelectedValue + "',bid='" + ddlbranch.SelectedValue + "' where dit = '" + ViewState["pp"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGridview();
                btninsert.Text = "INSERT";
                Clear();
            }
        }

        protected void gvemploye_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "dlt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tbldetails where dit='" + e.CommandArgument + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGridview();


            }
            else if (e.CommandName == "edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select *from tbldetails where dit='" + e.CommandArgument + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                textname.Text = dt.Rows[0]["name"].ToString();
                BindCource();
                ddlcource.SelectedValue = dt.Rows[0]["cid"].ToString();
                BindBranch();
                ddlbranch.SelectedValue = dt.Rows[0]["bid"].ToString();
                btninsert.Text = "UPDATE";
                ViewState["pp"] = e.CommandArgument;
            }
        }
    }
}