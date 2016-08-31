using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCForms_WEB.Models;

namespace MVCForms_WEB.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult TaskIndex()
        {

            return View();
        }


        [HttpPost] 
        public ActionResult CreateTask(Task newTask)
        { 

 
            List<Task> taskList = new List<Task>(); 
 
            taskList = (List<Task>)Session["taskList"]; 

 
            taskList.Add(newTask); 

 
            Session["taskList"] = taskList; 

 
            return View("TaskIndex"); 
     
        } 

    }
}
