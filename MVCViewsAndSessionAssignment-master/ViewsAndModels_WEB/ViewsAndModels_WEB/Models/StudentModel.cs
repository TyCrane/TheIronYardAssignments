using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsAndModels_WEB.Models
{
    public class StudentModel
    {
        public int studentsID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
    }
}