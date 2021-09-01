using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    dbop db = new dbop();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        String s = "Select Max(id) from registration";
        int id = db.maxid(s);
        s = "insert into registration values("+id+",'"+TextBox1.Text+"','"+TextBox2.Text+"',"+TextBox4.Text+",'"+TextBox3.Text+"')";
        db.nonret(s);
        s = "insert into login values('"+TextBox3.Text+"','"+TextBox5.Text+"')";
        db.nonret(s);
        Response.Redirect("REGISTRATION.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text= "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";



    }
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {

    }
}