using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    dbop db = new dbop();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s = "SELECT registration.id FROM registration INNER JOIN login ON registration.email = login.u_name where u_name='"+TextBox1.Text+"' and pwrd='"+TextBox2.Text+"'";
        DataTable dt = db.ret(s);
        if (dt.Rows.Count > 0)
        {
            Session["id"] = dt.Rows[0][0].ToString();
            Response.Redirect("ad_home.aspx");
        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
}