using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SurfNPaddleBlog_WEB.Controllers;
using SurfNPaddleBlog_WEB.Models;

namespace SurfNPaddleBlog_WEB.Controllers
{
    public class HomeController : Controller
    {

/************************************************************* GET *********************************************/

        //returns view of home page w/ blogs
        public ActionResult Index()
        {
            HomeDataController dataController = new HomeDataController();

            List<Blog> blogList = new List<Blog>();

            blogList = dataController.getAllBlogsList();

            ViewBag.blogs = blogList;

            return View(blogList);
        }
 /************************************************************* INSERT *********************************************/
        //allows insertion of new blogs
        public ActionResult InsertBlog(Blog thisBlog)
        {
            HomeDataController dataController = new HomeDataController();

            dataController.InsertNewBlog(thisBlog);

            return Content("succes");
        }

        public ActionResult InsertBlogView()
        {
            return View("InsertBlog");
        }
/************************************************************* UPDATE *********************************************/
        public SelectList GetBlogSelectList()
        {
            HomeDataController dataController = new HomeDataController();

            SelectList blogSelectList;

            blogSelectList = dataController.getAllBlogsSelectList();

            return new SelectList(blogSelectList, "Value", "Text", new Blog().blogID);
        }
        public ActionResult UpdateBlogView()
        {
            ViewBag.blogsSelectList = GetBlogSelectList();

            return View();
        }
            
        //allows update of blogs
        public ActionResult UpdateBlog(Blog thisBlog)
        {
            HomeDataController dataController = new HomeDataController();

            dataController.UpdateBlog(thisBlog);

            return Content("succesful");
        }

        public ActionResult GetBlog(int blogID)
        {
            HomeDataController dataController = new HomeDataController();

            Blog thisBlog = new Blog();

            thisBlog = dataController.GetBlog(blogID);

            System.Web.HttpContext.Current.Session["thisBlog"] = thisBlog;

            ViewBag.blogsSelectList = GetBlogSelectList();

            return PartialView("UpdateBlogView");
        }

    }
}