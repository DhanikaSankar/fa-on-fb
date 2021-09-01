using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for clustermgr
/// </summary>
public class clustermgr
{
	public clustermgr()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    dbop con = new dbop();
    public void insertcluster(int clusterid, object msgid, string center)
    {
        string qry = "insert into clusters values('" + clusterid + "','" + msgid + "','" + center + "')";
        con.nonret(qry);
    }

    public void insertelements(int cluster_id, string cmt_id, float dist)
    {
        string qry = "insert into cluster_elements values('" + cluster_id + "','" + cmt_id + "','" + dist + "')";
        con.nonret(qry);
    }
    public int getclstrid()
    {
        string qry = "select max(cluster_id) from clusters";
        int mxid = 1;
        try
        {
            mxid = Convert.ToInt32(con.ret(qry).Rows[0][0]) + 1;
        }
        catch { }
        return mxid;
    }

    public void updatecluster(int clusterid, string center)
    {
        string qry = "update clusters set cluster_center='" + center + "' where cluster_id='" + clusterid + "'";
        con.nonret(qry);
    }
    public void updatecluster(int id1, int id2, string center)
    {
        string qry = "update cluster_elements set cluster_id='" + id1 + "' where cluster_id='" + id2 + "'";
        con.nonret(qry);
        qry = "delete from clusters where cluster_id='" + id2 + "'";
        con.nonret(qry);
        updatecluster(id1, center);


    }

    public DataTable clusters(string msg)
    {
        string qry = "select * from cluster_elements inner join clusters on clusters.cluster_id=cluster_elements.cluster_id where msg_id='" + msg + "'";
        DataTable dt = con.ret(qry);
        return dt;
    }
    public DataTable clusters(object msg)
    {
        con.nonret("delete from cluster_elements where cluster_id in (select cluster_id from clusters where msg_id='" + msg + "')");
        string qry = "delete from  clusters where msg_id='" + msg + "'"; ;
        con.nonret(qry);
        ; return new DataTable();

    }
    public void removeelement(string clusterid)
    {
        string qry = "delete from cluster_elements where cluster_id='" + clusterid + "'";
        con.nonret(qry);
    }

}