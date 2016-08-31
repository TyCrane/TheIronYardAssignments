using System.Linq;
using System.Web;
using System;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Xml;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ViewsAndModels_WEB.Models;
using System.Collections.Generic;
using System.Web.Services;

namespace ViewsAndModels_WEB.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            

            return View();
        }


        public SelectList GetStudentDropDownList()
        {
            SelectList studentsSelectList;
            StudentsDataController dataController = new StudentsDataController();

            studentsSelectList = dataController.GetStudentsList();

            return new SelectList(studentsSelectList, "Value", "Text", new StudentModel().studentsID);
        }


        public ActionResult GetAllStudents()
        {
            List<StudentModel> students = new List<StudentModel>();

            StudentsDataController dc = new StudentsDataController();

            students = dc.GetStudents();

            System.Web.HttpContext.Current.Session["studentsList"] = students;

            string newString = String.Concat(students);

            ViewBag.studentsList = GetStudentDropDownList();

            return Content(newString);
        }

        public ActionResult InsertNewStudent(StudentModel newStudent)
        {

            StudentsDataController dc = new StudentsDataController();

            string studentSuccessCode = dc.InsertStudent(newStudent);

            return Content(studentSuccessCode);
        }


        [HttpPost]
        [ActionName("GetAjaxStudent")]
        [WebMethod(EnableSession = true)]
        public ActionResult GetStudent(int studentID)
        {
            StudentModel student = new StudentModel();

            StudentsDataController dataController = new StudentsDataController();
            student = dataController.GetStudent(studentID);
            // staffMember = dataController.getStudentModelMember(Convert.ToInt32(staffMember.staffID));
            System.Web.HttpContext.Current.Session["thisStudent"] = student;

            //ViewBag.statusList = GetStatusList();

            return View("UpdateStudentView");
        }

    }
}