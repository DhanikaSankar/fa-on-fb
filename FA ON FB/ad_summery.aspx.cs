using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

public partial class _Default : System.Web.UI.Page
{
    dbop con = new dbop();
    List<string> summ = new List<string>();
    Stopwords stp = new Stopwords();
    protected void Page_Load(object sender, EventArgs e)
    {

        //DataTable dt = con.select("select distinct cluster_elemnts.cmt_id,cluster_id from  cluster_elements inner join comment on comment.cmt_id=cluster_elements.cmt_id  where msg_id='" + Session["msg"]+"'");
        DataTable dt1gram = (DataTable)Session["dt1gram"];
        DataTable dt2gram = (DataTable)Session["dt2gram"];
        DataTable dt3gram = (DataTable)Session["dt3gram"];



        string qry = "select * from bsts_sum where msg_id='" + Session["msg"] + "'";
        DataTable dt = con.ret(qry);
        string[] wordarray = dt.Rows[0][2].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        qry = "select distinct comment.cmt_id,comment.cmt,cluster_center,clusters.cluster_id from clusters inner join cluster_elements on cluster_elements.cluster_id=clusters.cluster_id inner join comment on comment.msg_id=clusters.msg_id where clusters.msg_id='" + Session["msg"] + "' order by cluster_id";
        DataTable clstrs = con.ret(qry);
        DataTable dtsumm = new DataTable();
        dtsumm.Columns.Add("comments");
        dtsumm.Columns.Add("terms");
        dtsumm.Columns.Add("clid");
        dtsumm.Columns.Add("count", typeof(int));
        DataTable dtsummary = dtsumm.Clone();
        List<string> cid = new List<string>();

        qry = "select distinct cluster_id,cluster_center from clusters where msg_id='" + Session["msg"] + "'";
        DataTable dtcls = con.ret(qry);


        foreach (DataRow dr in dtcls.Rows)
        {



            DataTable ctcm = con.ret("select distinct cmt,comment.cmt_id from comment inner join cluster_elements on comment.cmt_id=cluster_elements.cmt_id where cluster_id='" + dr[0] + "'");
            int count = ctcm.Rows.Count;
            string comm = "", cmnt = ""; int cnt = 3;

            if (ctcm.Rows.Count > 0)
            {
                if (ctcm.Rows.Count < 3)
                    cnt = ctcm.Rows.Count;
                comm += "<ul> ";
                for (int ii = 0; ii < cnt; ii++)
                {
                    cmnt += ctcm.Rows[ii][0] + " ";
                    comm += " <li>" + ctcm.Rows[ii][0] + " </li>";
                }
                comm += " </ul>";
                List<string> wc = new List<string>();
                summ.Clear();

                wc.AddRange(cmnt.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
                DataTable dtone = dt1gram.Clone();
                DataTable dttwo = dt2gram.Clone();
                DataTable dtthree = dt3gram.Clone();
                List<string> sumel = new List<string>();
                foreach (DataRow dtr in ctcm.Rows)
                {
                    sumel.Clear();
                    DataRow[] drc = dt1gram.Select("cmt_id='" + dtr[1] + "'");
                    foreach (DataRow dx in drc)
                    {
                        sumel.Add(dx[1].ToString());
                    }
                    drc = dt2gram.Select("cmt_id='" + dtr[1] + "'");
                    foreach (DataRow dx in drc)
                    {
                        sumel.Add(dx[1].ToString());
                    }
                    drc = dt3gram.Select("cmt_id='" + dtr[1] + "'");
                    foreach (DataRow dx in drc)
                    {
                        sumel.Add(dx[1].ToString());
                    }

                    //summ.Add(drr[1].ToString());

                }

                foreach (string k in sumel)
                {
                    int fl = 0;
                    for (int i = 0; i < summ.Count; i++)
                    {
                        string[] st = summ[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string stx in st)
                        {
                            if (k.ToLower().Contains(stx.ToLower()))
                            {
                                sumel.RemoveAt(i);
                            }

                        }
                        summ.Add(k.ToString());
                    }

                }

                string elm = "";
                List<string> uniq = new List<string>();
                //foreach (string str in summ)
                //{

                //    if(!stp.stpwrd(str))
                //    elm += str + ",";

                //}
                //if (elm != "," && elm != "")

                if (cmnt.Trim().Length > 5)
                {
                    if (elm.Length < 3)
                    {
                        string[] st = cmnt.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        int cntx = 0;
                        cntx = st.Length;
                        //string stpwrd;
                        int ip = 0;
                        for (int ix = 0; ix < cntx; ix++)
                        {
                            if (!elm.ToLower().Contains(st[ix].ToLower()))
                                if (!stp.stpwrd(st[ix]))
                                {
                                    ; if (ip == ix - 1)
                                        elm = elm.TrimEnd(',') + " ";
                                    elm += st[ix].TrimEnd('?') + ",";
                                    ip = ix;

                                }

                        }
                    }

                    dtsummary.Rows.Add(comm.Replace('?', ' '), elm.TrimEnd(','), dr[0], count);
                }
            }
        }

        ArrayList al = new ArrayList();
        ArrayList ax = new ArrayList();
        ArrayList aind = new ArrayList();
        DataView dv = dtsummary.DefaultView;
        dv.Sort = "count desc";
        dv.RowFilter = "count>1";
        dtsummary = dv.ToTable();
        DataGrid1.DataSource = dtsummary;
        DataGrid1.DataBind();
    }


}