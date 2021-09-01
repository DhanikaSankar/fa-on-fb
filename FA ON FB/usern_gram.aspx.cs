using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack )
        {
            DataTable dts = new DataTable();
            dts.Columns.Add("word");
            Session["dts"] = dts; // moves d words into session

            DataTable dt1grm = new DataTable();
            dt1grm.Columns.Add("cmt_id"); // add col to DT 4 dp
            dt1grm.Columns.Add("word");
            Session["dt1gram"] = dt1grm;

            DataTable dt2grm = new DataTable();
            dt2grm.Columns.Add("cmt_id"); 
            dt2grm.Columns.Add("word");
            Session["dt2gram"] = dt2grm;

            DataTable dt3grm = new DataTable();
            dt3grm.Columns.Add("cmt_id"); 
            dt3grm.Columns.Add("word");
            Session["dt3gram"] = dt3grm;
           // MultiView1.SetActiveView(View1);


            DataTable dt = (DataTable)Session["cmntdt"];
            DataTable sm = new DataTable();
            sm.Columns.Add("stemwrd");

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sno = dr[6].ToString();
                    comment_id = dr[0].ToString();
                    string g = dr[3].ToString().ToLower();
                    //creating onegram
                    splitting(g);


                }
                Session["words"] = words; 
                //cl.mywordnet(words); 

                Session["cmd"] = sno;
                DataTable dt1gram = (DataTable)Session["dt1gram"];//type casting
                DataTable dt2gram = (DataTable)Session["dt2gram"];
                DataTable dt3gram = (DataTable)Session["dt3gram"];


                //creating two gram
                foreach (DataRow dr in dt.Rows)
                {

                    DataRow[] drc = dt1gram.Select("cmt_id='" + dr[0] + "'");
                    for (int i = 0; i < drc.Length - 1; i++)
                    {

                        dt2gram.Rows.Add(dr[0], drc[i][1] + "" + " " + drc[i + 1][1]);
                    }
                }

                //creating three gram
                foreach (DataRow dr in dt.Rows)
                {
                    DataRow[] drc = dt1gram.Select("cmt_id='" + dr[0] + "'");
                    for (int i = 0; i < drc.Length - 2; i++)
                    {
                        dt3gram.Rows.Add(dr[0], drc[i][1] + "" + " " + "" + drc[i + 1][1] + "" + " " + "" + drc[i + 2][1]);
                    }

                }

                DataGrid1.DataSource = (DataTable)Session["dt1gram"];
                DataGrid1.DataBind();
                DataGrid2.DataSource = dt2gram;
                DataGrid2.DataBind();
                DataGrid3.DataSource = dt3gram;
                DataGrid3.DataBind();
                MultiView1.SetActiveView(View1);
            }

        }

    }

    //one gram
    Stopwords sws = new Stopwords();
    dbop con = new dbop();
    cls_Stemming cl = new cls_Stemming();
    private void splitting(string h)
    {


        string[] st = new string[] { ".", ",", "?", " ", "!", ":" };

        DataTable dt = (DataTable)Session["dt1gram"];
        string[] stt = cl.StpRmv(h); //h.Split(st, StringSplitOptions.RemoveEmptyEntries);

        foreach (string str in stt)
        {
            string stm = str;

            string h1 = "select * from shrt_text where shrt_txt='" + stm + "'";
            DataTable dtb = con.ret(h1);
            if (dtb.Rows.Count > 0)
            {
                stm = dtb.Rows[0][1].ToString();

            }

            string n = cl.Rmvfrm(stm)[0];
            if (n.Length >= 2)
            {
                if (!cl.cntrs(n))
                {
                    dt.Rows.Add(comment_id, n);
                    if (!words.Contains(n))
                        words.Add(n);
                }
            }

        }

        Session["dt1gram"] = dt;
    }
    List<string> words = new List<string>();
    
    dbop db = new dbop();
    string comment_id, sno;
   


   

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_bsts.aspx");
    }
    protected void DataGrid3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}