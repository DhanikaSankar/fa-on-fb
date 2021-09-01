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
        
        if (!IsPostBack)
        {
            string s = "select * from keyword order by id";
            DataTable dt = db.ret(s);
            DataGrid1.DataSource = dt;
            DataGrid1.DataBind();
            MultiView1.SetActiveView(View1);

            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
        String s = "Select Max(id) from keyword";
        int id = db.maxid(s);
        TextBox1.Text = id.ToString();
        MultiView1.SetActiveView(View2);


    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Button2.Text == "SUBMIT")
        {
            String s = "select max(id)from keyword";
            int id = db.maxid(s);
            s = "insert into keyword values(" + id + ",'" + TextBox2.Text + "'," + TextBox3.Text + ")";
            db.nonret(s);

        }
        else {

            string s = "update keyword set keywrd='"+TextBox2.Text+"',wght="+TextBox3.Text+" where id="+TextBox1.Text+"";
            db.nonret(s);
        }
        Response.Redirect("KEYWORD.aspx");

    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            TextBox1.Text = e.Item.Cells[0].Text;
            TextBox2.Text = e.Item.Cells[1].Text;
            TextBox3.Text = e.Item.Cells[2].Text;
            Button2.Text = "UPDATE";
            MultiView1.SetActiveView(View2);
        }
        if (e.CommandName == "Delete")
        {
            String s = "delete from keyword where id= "+e.Item.Cells[0].Text+"";
            db.nonret(s);
            Response.Redirect("KEYWORD.aspx");
        }
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void DataGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}