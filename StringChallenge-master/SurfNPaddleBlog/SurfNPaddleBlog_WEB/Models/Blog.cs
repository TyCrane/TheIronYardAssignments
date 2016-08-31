using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurfNPaddleBlog_WEB.Models
{
    public class Blog
    {
        public int blogID { get; set; }
        public int blogUserID { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string body { get; set; }
        public string pic { get; set; }

    }
}