using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for msgitems
/// </summary>
/// 
public class From
{
    public string name { get; set; }
    public string id { get; set; }
}

public class Datum
{
    public string created_time { get; set; }
    public From from { get; set; }
    public string message { get; set; }
    public string id { get; set; }   
}

public class cursors
{
    public string before { get; set; }
    public string after { get; set; }
}

public class paging
{
    public cursors cursors { get; set; }
    public string next { get; set; }
}

public class msgitems
{
    public List<Datum> data { get; set;}
    public paging paging { get; set; }
}
