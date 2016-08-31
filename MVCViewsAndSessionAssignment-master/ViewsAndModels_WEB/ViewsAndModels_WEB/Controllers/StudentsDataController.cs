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
using ViewsAndModels_WEB.Controllers;

namespace ViewsAndModels_WEB.Controllers
{
    public class StudentsDataController
    {
        public static SqlDatabase db;

        public StudentsDataController()
        {
            if (db == null)
            {
                db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["ViewsAndModelsConnection"].ToString());
            }
        }

        public List<StudentModel> GetStudents()
        {
            DbCommand dbCommand = db.GetStoredProcCommand("get_AllStudents");
            db.ExecuteNonQuery(dbCommand);

            DataSet ds = db.ExecuteDataSet(dbCommand);

            var students = (from dr in ds.Tables[0].AsEnumerable()
                            select new StudentModel()
                            {
                                firstName = dr.Field<string>("firstName"),
                                lastName = dr.Field<string>("lastName"),
                                gender = dr.Field<string>("gender"),
                                age = dr.Field<int>("age")
                            }).ToList();

            return students;
        }

        //get select list for student dropdown list
        public SelectList GetStudentsList()
        {
            DbCommand dbCommand = db.GetStoredProcCommand("get_AllStudents");

            DataSet ds = db.ExecuteDataSet(dbCommand);

            var selectList = (from drRow in ds.Tables[0].AsEnumerable()
                              select new SelectListItem()
                              {
                                  Text = drRow.Field<string>("firstName") + " " + drRow.Field<string>("lastName"),
                                  Value = drRow.Field<int>("studentsID").ToString()
                              }).ToList();

            return new SelectList(selectList, "Value", "Text");
        }


        public string InsertStudent(StudentModel thisStudent)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("ins_Student");
            db.AddInParameter(dbCommand, "@firstName", DbType.String, thisStudent.firstName);
            db.AddInParameter(dbCommand, "@lastName", DbType.String, thisStudent.lastName);
            db.AddInParameter(dbCommand, "@gender", DbType.String, thisStudent.gender);
            db.AddInParameter(dbCommand, "@age", DbType.Int32, thisStudent.age);
            db.ExecuteNonQuery(dbCommand);

            string studentSuccessCode = "success";

            return studentSuccessCode;
        }


        public StudentModel GetStudent(int studentID)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("get_StudentByID");
            db.AddInParameter(dbCommand, "studentID", DbType.Int32, studentID);
            // db.AddInParameter(dbCommand, "@parameterName", DbType.TypeName, variableName);

            DataSet ds = db.ExecuteDataSet(dbCommand);

            DataRow dr = ds.Tables[0].Rows[0];

            StudentModel currentStudent = new StudentModel()
            {

                studentsID = dr.Field<int>("studentID"),
                firstName = dr.Field<string>("firstName"),
                lastName = dr.Field<string>("lastName"),
                gender = dr.Field<string>("gender"),
                age = dr.Field<int>("age"),
            };

            return currentStudent;
        }
    }
}