using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class view_profile : System.Web.UI.Page
{
    dbop db = new dbop();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String s = "select * from registration where id = " + Session["id"] + "";
            DataTable dt = db.ret(s);
            TextBox1.Text = dt.Rows[0][0].ToString();
            TextBox2.Text = dt.Rows[0][1].ToString();
            TextBox3.Text = dt.Rows[0][2].ToString();
            TextBox5.Text = dt.Rows[0][3].ToString();
            TextBox4.Text = dt.Rows[0][4].ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String s = "update registration set name='"+TextBox2.Text+"',place='"+TextBox3.Text+"',ph_no="+TextBox5.Text+", email='"+TextBox4.Text+"' where id="+TextBox1.Text+" ";
        db.nonret(s);
        Response.Redirect("view_profile.aspx");
    }
}