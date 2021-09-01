using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Text;
using System.IO;



public partial class _Default : System.Web.UI.Page
{
    float fvc = 0;
    dbop con = new dbop();
    List<int> cids = new List<int>();
    clustermgr cmgr = new clustermgr();

    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
        {
            MultiView1.SetActiveView(View1);
            DataTable dtt = (DataTable)Session["cmntdt"]; // comments 
            DataTable onegram = (DataTable)Session["dt1gram"];
            List<string> words = (List<string>)Session["words"];
            cmgr.clusters(Session["msg"]);
            int ncomments = dtt.Rows.Count;
            int nwords = words.Count;
            int[,] vect = new int[ncomments, nwords]; // term vectr(2D matrix)
            string str = "";
           
            try
            {
                dtt.Columns.Add("TermVector");
               
                //creating termvector
                for (int i = 0; i < ncomments; i++)
                {
                    str = "";
                    string cmid = dtt.Rows[i][0].ToString(); // cmnt id
                    for (int j = 0; j < nwords; j++)
                    {
                        if (onegram.Select("cmt_id='" + cmid + "' and word='" + words[j] + "'").Length > 0)
                        {
                            vect[i, j] = 1;
                        }
                        str += vect[i, j] + ",";

                    }

                    dtt.Rows[i][7] = str;
                    Session["vect"] = vect;
                }
                DataGrid1.DataSource = dtt;
                DataGrid1.DataBind();

                string q = "select cmt_id from bsts_sum where msg_id='" + Session["msg"] + "' order by cmt_id desc";
                DataTable dtq = db.ret(q);
                StringBuilder sb = new StringBuilder();
                foreach (string s in (List<string>)Session["words"])
                {
                    sb.Append(s.Replace("\r\n", "")).AppendLine(",");
                }
                string wodss = sb.ToString();
                wodss = wodss.Replace("\r", "");
                wodss = wodss.Replace("\n", "");
                if (dtq.Rows.Count > 0)
                {
                    if (dtq.Rows[0][0].ToString() != Session["cmd"].ToString())
                    {
                        Session["cmntsno"] = dtq.Rows[0][0];
                        string qry = "delete from bsts_sum where msg_id='" + Session["msg"] + "';delete from clusters where msg_id='" + Session["msg"] + "'";
                        db.nonret(qry);
                        qry = "insert into bsts_sum values('" + Session["cmd"] + "','" + Session["msg"] + "','" + wodss + "')";
                        db.nonret(qry);
                        Response.Redirect("user_incrests.aspx");
                    }
                }
                else
                {

                    string st = "~/files/" + DateTime.Now.ToFileTime() + ".text";
                    File.WriteAllText(Server.MapPath(st), st);
                   
                    string qry = "insert into bsts_sum values('" + Session["cmd"] + "','" + Session["msg"] + "','" + st + "')";
                   db.nonret(qry);
                }

              
            }

            catch
            {

            }

        }
    }

      int simwords(DataRow[] drc, DataRow[] drz)
    {
        ArrayList al = new ArrayList();
        foreach (DataRow d in drc)
        {
            al.Add(d[1]);
        }
        foreach (DataRow dd in drz)
        {

            if (!al.Contains(dd[1]))
            {
                al.Add(dd[1]);
            }
        }
        return al.Count;
    }

   
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
        int [,] shn=(int[,])Session["vect"];// movs d value in a sesn to nw matrix

        List<string> words = (List<string>)Session["words"];
        int nwords = words.Count;
        int []cluster_center=new int[nwords];
        string  dt1 = Session["dt1gram"].ToString(); 
 
        DataTable dt = new DataTable();
        dt.Columns.Add("comment1");
        dt.Columns.Add("comment2");
        dt.Columns.Add("Similarity Score");

        string j = "select * from comment where msg_id='" + Session["msg"]+"'";
        DataTable dtcomments = con.ret(j); //select commnts of corspndng msgs
        int ncomments = dtcomments.Rows.Count;

        DataTable dtclstr = new DataTable();
        dtclstr.Columns.Add("cluster_id");
        dtclstr.Columns.Add("elements");
    
        int  cluster_id = cmgr.getclstrid();
       
       
        List<int[]> ccs = new List<int[]>();// cluster centers

        if (dtcomments.Rows.Count > 0)
        {
            dtclstr.Rows.Add(cluster_id, dtcomments.Rows[0][0]);// clstr id,cmnt id

            string ccenter = "";
            for (int i = 0; i < nwords; i++)
            {
                cluster_center[i] = shn[0, i];
                ccenter += shn[0, i]+",";
            }
            
            ccs.Add(cluster_center);
            cids.Add(cluster_id);
            cmgr.insertcluster(cluster_id,Session["msg"],ccenter);
                 cmgr.insertelements(cluster_id,dtcomments.Rows[0][0].ToString(),1);                
            for (int i = 1; i < ncomments; i++)
            {
              // cluster_id =clustin;
                int flag = 0;
                List<int[]> templist = ccs.ToList<int[]>();// 
                int index = -1;
                List<float> simlist=new List<float>();
               
                foreach (int[] clust_c in templist)
                {
                    index++;
                    fvc = 0; 
                    float tw = 0, cw= 0;;

                    cluster_id = templist.IndexOf(clust_c);
                    cluster_id = cids[cluster_id];
                    // cluster_id = templist.IndexOf(clust_c);
                    for (int n = 0; n < nwords; n++)
                    {
                        tw += shn[i,n];
                       
                        int temp = shn[i, n] * clust_c[n];
                        cw += temp;
                        
                    }

                    float sima = cw /tw;
                    simlist.Add(sima);
                    }
                    int simmax =simlist.IndexOf(simlist.Max());
                   
                    
                    
                    if (simmax>=.5f)
                    {
                        flag = 1;
                        ccenter="";
                        for (int ii = 0; ii < nwords; ii++)
                        {
                            ccs[simmax][ii] = ccs[simmax][ii] | shn[i, ii];
                             ccenter +=ccs[simmax][ii]+",";
                        }
                       cmgr.insertelements(cids[simmax],dtcomments.Rows[i][0].ToString(),simlist.Max());
                     cmgr.updatecluster(cluster_id,ccenter);
                       dtclstr.Rows.Add(cluster_id,dtcomments.Rows[i][0].ToString());
                     //   ccs.RemoveAt(index);
                       // ccs[index]=clust_c;
                    }
                    
                

                if (flag == 0)
                {
                    cluster_id =cmgr.getclstrid() ; ;
                    cids.Add(cluster_id);
                    int[] newccenter = new int[nwords];
                    ccenter = "";
                    for (int ii = 0; ii < nwords; ii++)
                    {
                        newccenter[ii] = shn[i, ii];
                        ccenter += shn[i, ii] + ",";
                    }
                    cmgr.insertcluster(cluster_id, Session["msg"], ccenter);
                    cmgr.insertelements(cluster_id, dtcomments.Rows[i][0].ToString(), 1);    

                    ccs.Add(newccenter);
                    dtclstr.Rows.Add(cluster_id, dtcomments.Rows[i][0].ToString());
                
            }
            }

            int ind = 1;
            List<int[]> cluscntr = new List<int[]>();
            List<int[]> ccntr = new List<int[]>();

            for (ind = cids[0]; ind < ccs.Count; ind++)
            {

                float tw = 0, cw = 0;
                int flag = 1;

                List<float> simlist = new List<float>();
                for (int ind1 = ind + 1; ind1 < ccs.Count; ind1++)
                {

                    float sima=sim(ccs[ind],ccs[ind1]);

                if (sima > .5f)
                    {
                    flag = 1;
                    ccenter="";
                    for (int ii = 0; ii < nwords; ii++)
                        {
                        ccs[ind][ii] = ccs[ind][ii] | ccs[ind1][ ii];
                        ccenter+=ccs[ind][ii]+",";
                        }
                        cmgr.updatecluster(cids[ind],cids[ind1],ccenter);
                }
            }
            }

         
        //    for (int l = 0; l < dtclstr.Rows.Count; l++)
            //    {

            //        DataRow dr = dtb.Select("comment_id='" + dtclstr.Rows[l][1] + "'")[0];
            //        // int cid = Convert.ToInt32(dr[0]);
            //        int tl = dtb.Rows.IndexOf(dr);
            //        int[] aa = new int[nwords];

            //        for (int k = 0; k < nwords; k++)
            //        {
            //            aa[k] = shn[tl, k];
            //        }
            //        try
            //        {
            //            if (dist(aa, ccs[l]) < 0.1f)
            //            {
            //                dtclstr.Rows.RemoveAt(l);
            //            }
            //        }
            //        catch { }
            //    }
            //}
            words = (List<string>)Session["words"];
            //foreach (DataRow dr in dtclstr.Rows)
            //{
            //    string cnet = "";
            //    int[] a = ccs[cids.IndexOf(Convert.ToInt32(dr[1]))];
            //    for (int li = 0; li < a.Length; li++)
            //    {
            //        cnet = a[li] + ",";
            //    }
            //    cnet = cnet.TrimEnd(',');
            //    string qry = "insert into clusterelmnts values('" + dr[0] + "','" + dr[1] + "','" + cnet + "')";
            //    db.nonret1(qry);


            //}
           // dtclstr=cmgr.clusters(Session["msg"].ToString());

            //foreach (DataRow dr in dtclstr.Rows)
            //{
            //    if (Convert.ToSingle(dr[2]) > words.Count)
            //    {
            //        cmgr.removeelement(dr[0].ToString());
                   
            //    }
            //}
           dtclstr = cmgr.clusters(Session["msg"].ToString());

            

      //   string q = "select * from commnttab where msg_id='" + Session["msg"] + "'";
         //   DataTable dtcomm = db.select(q);
            DataGrid2.DataSource = dtclstr;
            DataGrid2.DataBind();

            Session["clstr"] = dtclstr;
            // Response.Redirect("user_summary.aspx");
        }
    }
    dbop db = new dbop();


    public float sim(int[] a, int[] b)
    {
        float sum = 0,k=0;
        for (int i = 0; i < a.Length; i++)
        {
            k += a[i];
            sum += a[i] * b[i];
        }
        return sum / k;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_bsts.aspx");
    }
}