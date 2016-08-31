/***********************************************************************************************************
Description: Data Controller for Home Controller
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	8.03.2016
Change History:
	
************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

using SurfNPaddleBlog_WEB.Models;
using SurfNPaddleBlog_WEB.Controllers;

namespace SurfNPaddleBlog_WEB.Controllers
{
    public class HomeDataController
    {

        public static SqlDatabase db;

        public HomeDataController()
        {
            if (db == null)
            {
                db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["SurfinConnectionString"].ToString());
            }
        }

/************************************************************* GET *********************************************/
        public List<Blog> getAllBlogsList()
        {
            DbCommand dbCommand = db.GetStoredProcCommand("get_AllBlogs");

            DataSet ds = db.ExecuteDataSet(dbCommand);

            var blogList = (from drRow in ds.Tables[0].AsEnumerable()
                            select new Blog()
                            {
                                blogID = drRow.Field<int>("blogID"),
                                title = drRow.Field<string>("title"),
                                author = drRow.Field<string>("author"),
                                body = drRow.Field<string>("body"),
                                pic = drRow.Field<string>("pic")
                            }).ToList();

            return blogList;                 
        }

/************************************************************* Insert *********************************************/
        public void InsertNewBlog(Blog thisBlog)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("ins_NewBlog");

            db.AddInParameter(dbCommand, "@author", DbType.String, thisBlog.author);
            db.AddInParameter(dbCommand, "@title", DbType.String, thisBlog.title);
            db.AddInParameter(dbCommand, "@body", DbType.String, thisBlog.body);
            db.AddInParameter(dbCommand, "@pic", DbType.String, thisBlog.pic);

            db.ExecuteNonQuery(dbCommand);

        }

/************************************************************* Update *********************************************/

        public void UpdateBlog(Blog thisBlog)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("upd_Blog");

            db.AddInParameter(dbCommand, "@blogID", DbType.Int32, thisBlog.blogID);
            db.AddInParameter(dbCommand, "@author", DbType.String, thisBlog.author);
            db.AddInParameter(dbCommand, "@title", DbType.String, thisBlog.title);
            db.AddInParameter(dbCommand, "@body", DbType.String, thisBlog.body);
            db.AddInParameter(dbCommand, "@pic", DbType.String, thisBlog.pic);

            db.ExecuteNonQuery(dbCommand);
        }

        public SelectList getAllBlogsSelectList()
        {
            DbCommand dbCommand = db.GetStoredProcCommand("get_AllBlogs");

             DataSet ds = db.ExecuteDataSet(dbCommand);

            var selectList = (from drRow in ds.Tables[0].AsEnumerable()
                              select new SelectListItem()
                              {
                                  Text = drRow.Field<string>("title"),
                                  Value = drRow.Field<int>("blogID").ToString()

                              }).ToList();

            return new SelectList(selectList, "Value", "Text");
        }

        public Blog GetBlog(int blogID)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("get_BlogByID");
            db.AddInParameter(dbCommand, "blogID", DbType.Int32, blogID);
            // db.AddInParameter(dbCommand, "@parameterName", DbType.TypeName, variableName);

            DataSet ds = db.ExecuteDataSet(dbCommand);

            DataRow dr = ds.Tables[0].Rows[0];

            Blog currentBlog = new Blog()
            {

                author = dr.Field<string>("author"),
                title = dr.Field<string>("title"),
                body = dr.Field<string>("body"),
                pic = dr.Field<string>("pic")
            };
          

            return currentBlog;
        }
    }
}