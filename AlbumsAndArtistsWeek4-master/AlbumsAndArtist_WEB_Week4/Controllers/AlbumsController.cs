/***********************************************************************************************************
Description: Controller for Albums
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	7.15.2016
Change History:
	
************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Web.Mvc;
using AlbumsAndArtist_WEB_Week4.Models;

namespace AlbumsAndArtist_WEB_Week4.Controllers
{

/****************************************************** RETURN VIEWS (NO LOGIC) ********************************************************/

    public class AlbumsController : Controller
    {
        // GET: Albums
        public ActionResult Index()
        {
            return View();
        }

        /************************************************************ GET METHODS ********************************************************/
        public ActionResult GetAlbums()
        {
            DataSet dsalbum;
            AlbumsDataController dataController = new AlbumsDataController();
            //retrieves album data and stores it in a dataset
            dsalbum = dataController.GetAlbums();
            //stores each album member and their properties to a list of album objects
            var albumsList = (from drRow in dsalbum.Tables[0].AsEnumerable()
                         select new albumsModel()
                         {
                             albumName = drRow.Field<string>("albumName")
                         }).ToList();

            List<string> list = new List<string>();
            foreach (albumsModel value in albumsList)

            {           
                list.Add(value.albumName);
            }
            string Fulllist = string.Join(",", list.ToArray());

            return Content(Fulllist);
        }

        public ActionResult GetAlbum(string albumName, string artistName)
        {

            albumsModel model = new albumsModel();

            AlbumsDataController dataController = new AlbumsDataController();

            model = dataController.GetAlbum(albumName, artistName);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("Album Name :" + model.albumName + "</br/>");

            sb.Append("Normal Price :" + model.normalPrice + "</br/>");

            sb.Append("Sale Price :" + model.salePrice + "</br/>");

            sb.Append("Amount In Stock :" + model.amountInStock + "</br/>");

            sb.Append("Artist Name :" + model.artistName);

            return Content(sb.ToString());

        }

        /*********************************************************** INSERT METHODS *******************************************************/

        //create an album by passing album model to datacontroller
        public ActionResult CreateAlbum(albumsModel newAlbum)
        {
            bool success;

            AlbumsDataController dataController = new AlbumsDataController();

            success = dataController.InsertAlbum(newAlbum);

            return Content(success.ToString());
        }

/********************************************************** UPDATE METHODS ********************************************************/


        //update an album by passing album model to datacontroller
        public ActionResult UpdateAlbum(albumsModel updAlbum)
        {
            bool success;

            AlbumsDataController dataController = new AlbumsDataController();

            success = dataController.UpdateAlbum(updAlbum);

            return Content(success.ToString());
        }

        public ActionResult SellAlbum(string albumName)
        {

            int stock;

            AlbumsDataController dataController = new AlbumsDataController();

            stock = dataController.SellAlbum(albumName);


            return Content(stock.ToString());
        }

/************************************************************ DELETE METHODS ********************************************************/


    }
}