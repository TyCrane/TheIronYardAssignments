using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCForms_WEB.Models
{
    public class Task
    {
        public string createdBy { get; set; }
        public string description { get; set; }
        public string status { get; set; }
    }
}