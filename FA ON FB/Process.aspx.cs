using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using test;




public partial class _Default : System.Web.UI.Page
{
    dbop db = new dbop();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            MultiView1.SetActiveView(View3);



        }
    }
    protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        DataTable dt = new DataTable();
        dt.Columns.Add("ID");
        dt.Columns.Add("link");
        dt.Columns.Add("message");
        dt.Columns.Add("story");
        dt.Columns.Add("time");
        var client = new WebClient();
        msgitems msg = new msgitems();
        var posts = new test.RootObject();
        string accessToken, pageInfo, pagePosts;
        try
        {
            string authurl = "https://graph.facebook.com/v2.10/oauth/access_token?%20client_id=2022838107950486%20&client_secret=e82ae651ba2d37800aefb8d363429d65&grant_type=client_credentials";
            accessToken = client.DownloadString(authurl).Split('\"')[3];
            Session["at"] = accessToken;
            pageInfo = client.DownloadString(string.Format("https://graph.facebook.com/" + TextBox1.Text + "?access_token={0}", accessToken));
            pagePosts = client.DownloadString(string.Format("https://graph.facebook.com/" + TextBox1.Text + "/posts?access_token={0}", accessToken));
            posts = JsonConvert.DeserializeObject<test.RootObject>(pagePosts);
            foreach(test.Datum ro in posts.data)
            {
                dt.Rows.Add(ro.id,"https://www.facebook.com/"+ro.id,ro.message,ro.story,ro.created_time);
                try
                {
                   string[] dat = ro.created_time.Split('T');
                   string s = "";
                }
                catch { }
            }
            if (dt.Rows.Count > 0)
            {
                MultiView1.SetActiveView(View1);
                DataGrid1.DataSource = dt;
                DataGrid1.DataBind();

            }
            else
            {
                Response.Write("<script>alert('No Messages');</script>");
            }
        }

        catch
        {
            Response.Write("<script>alert ('No Internet Connection');</script>");

        }


    }
    cls_Stemming stm = new cls_Stemming();
    protected void Button2_Click(object sender, EventArgs e)
    {
        string s = "select * from post";
        DataTable dt = db.ret(s);
        DataTable wrds = new DataTable();
        wrds.Columns.Add("w");
        wrds.Columns.Add("pid");
        foreach (DataRow dr in dt.Rows)
        {
           string [] wd= stm.StpRmv(dr[2].ToString());
           foreach (string wds in wd)
           {
               DataRow dr1 = wrds.NewRow();
               dr1[0] = wds;
               dr1[1] = dr[0].ToString();
               wrds.Rows.Add(dr1);
           }
        }
        DataGrid2.DataSource = wrds;
        DataGrid2.DataBind();
        Session["wrds"] = wrds;
        MultiView1.SetActiveView(View2);


    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        DataTable wrds =(DataTable) Session["wrds"];
        DataTable wds1 = new DataTable();
        wds1.Columns.Add("w");
        wds1.Columns.Add("pid");
        foreach (DataRow dr in wrds.Rows)
        {
            if (!stm.cntrs(dr[0].ToString()))
            {
                DataRow dr1 = wds1.NewRow();
                dr1[0] = dr[0].ToString();
                dr1[1] = dr[1].ToString();
                wds1.Rows.Add(dr1);
            }
        }
        DataGrid2.DataSource = wds1;
        DataGrid2.DataBind();
        Session["wrds"] = wds1;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        DataTable wrds = (DataTable)Session["wrds"];
        DataTable wds1 = new DataTable();
        wds1.Columns.Add("w");
        wds1.Columns.Add("pid");
        string s = "";
        foreach (DataRow dr in wrds.Rows)
        {
            s = s + dr[0].ToString() + " ";
        }
        string[] ss = stm.Rmvfrm(s);
        int i = 0;
        foreach (DataRow dr in wrds.Rows)
        {
            DataRow dr1 = wds1.NewRow();
            dr1[0] = ss[i];
            dr1[1] = dr[1].ToString();
            wds1.Rows.Add(dr1);
            i++;
        }

        DataGrid2.DataSource = wds1;
        DataGrid2.DataBind();
        Session["wrds"] = wds1;


    }
    List<string> comments = new List<string>();
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        WebClient client = new WebClient();
        string id = e.Item.Cells[0].Text;
        Session["msg"] = id;
        string dd = client.DownloadString(String.Format("https://graph.facebook.com/" + id + "/comments?access_token={0}", Session["at"].ToString())); ;
        var result = JsonConvert.DeserializeObject<msgitems>(dd);
        DataTable dt = new DataTable();
        dt.Columns.Add("comment_id");
        dt.Columns.Add("msg_id");
        dt.Columns.Add("frm_usr");
        dt.Columns.Add("comment");
        dt.Columns.Add("date");
        dt.Columns.Add("time");
        string q = "delete   from comment where msg_id='" + id + "'";
        db.nonret(q);
        foreach (Datum dats in result.data)
        {
            cls_Stemming sl = new cls_Stemming();
            comments.Add(dats.id);
            string[] dat = dats.created_time.Split('T');
            string qry = "insert into comment values('" + dats.id + "','" + id + "','" + dats.from.name.Replace('\'', ' ') + "',N'" + sl.stoprmv(dats.message.Replace('\'', ' ').Replace("?", "")) + "','" + dat[0] + "','" + dat[1] + "')";
            db.nonret(qry);
            Session["cmd"] = dats.id;
        }

        q = "select * from comment where msg_id='" + id + "'";
        dt = db.ret(q);

        DataGrid2.DataSource = dt;
        DataGrid2.DataBind();
        Session["cmntdt"] = dt;
        if (dt.Rows.Count == 0)
        {

            Response.Write("<script>alert('NO comments');window.location='user_spage.aspx';</script>");
        }
        MultiView1.SetActiveView(View2);
    }
    protected void Button3_Click1(object sender, EventArgs e)
    {
        Response.Redirect("usern_gram.aspx");
    }
}