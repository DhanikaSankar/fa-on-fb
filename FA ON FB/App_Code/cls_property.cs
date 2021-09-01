using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_property
/// </summary>

namespace test
{
    public class Datum
    {
        public string message { get; set; }
        public string story { get; set; }
        public string created_time { get; set; }
        public string id { get; set; }
    }

    public class Paging
    {
        public string previous { get; set; }
        public string next { get; set; }
    }

    public class RootObject
    {
        public List<Datum> data { get; set; }
        public paging paging { get; set; }
    }
}
