/***********************************************************************************************************
Description: Controller for artist
	 
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
using System.Web.Mvc;
using AlbumsAndArtist_WEB_Week4.Models;
using AlbumsAndArtist_WEB_Week4.Controllers;

namespace artistAndArtist_WEB_Week4.Controllers
{

    /****************************************************** RETURN VIEWS (NO LOGIC) ********************************************************/

    public class ArtistController : Controller
    {
        // GET: artist
        public ActionResult Index()
        {
            return View();
        }

        /************************************************************ GET METHODS ********************************************************/

        public ActionResult GetArtist(ArtistModel model)
        {

            int artistID;

            ArtistDataController dataController = new ArtistDataController();

            artistID = dataController.GetArtistID(model);

            System.Web.HttpContext.Current.Session["Artist"] = artistID;

            return Content(artistID.ToString());
        }

        /*********************************************************** INSERT METHODS *******************************************************/

        //create an artist by passing artist model to datacontroller
        public ActionResult Createartist(ArtistModel newartist)
        {
            int artistID;

            ArtistDataController dataController = new ArtistDataController();

            dataController.InsertArtist(newartist);
            artistID = dataController.GetArtistID(newartist);

            return Content(artistID.ToString());
        }

        /********************************************************** UPDATE METHODS ********************************************************/


        //update an artist by passing artist model to datacontroller
        public ActionResult Updateartist(ArtistModel updartist)
        {
            bool success;

            ArtistDataController dataController = new ArtistDataController();

            success = dataController.UpdateArtist(updartist);

            return Content(success.ToString());
        }

        /************************************************************ DELETE METHODS ********************************************************/


    }
}