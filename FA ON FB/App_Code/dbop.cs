using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for dbop
/// </summary>
public class dbop
{
	public dbop()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sys\Desktop\FA ON FB\App_Data\FA_ON_FB.mdf;Integrated Security=True;User Instance=True");

    public void nonret(string s)
    {

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = s;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public DataTable ret(string s)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = s;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        da.SelectCommand = cmd;
        da.Fill(dt);
        return dt;

    }
    public int maxid(String s)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = s;
        con.Open();
        int id = 0;
        try
        {
            id = Convert.ToInt32(cmd.ExecuteScalar().ToString()) + 1;
        }
        catch
        {
            id = 1;
        }
        finally
        {
            con.Close();
        }
        return id;
    } 



}