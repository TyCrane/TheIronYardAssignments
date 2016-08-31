/***********************************************************************************************************
Description: Data Controller for Artists
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	7.15.2016
Change History:
	
************************************************************************************************************/
using System.Linq;
using System;
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
using AlbumsAndArtist_WEB_Week4.Models;

namespace AlbumsAndArtist_WEB_Week4.Controllers
{

    public class ArtistDataController
    {

        public static SqlDatabase db;

        public ArtistDataController()
        {
            if (db == null)
            {
                db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["albumsAndArtistConnection"].ToString());
            }
        }
 
        //gets all artists from the db and returns it as a dataset
        public DataSet GetArtists()
        {
            DbCommand dbCommand = db.GetStoredProcCommand("get_Artists");

            DataSet ds = db.ExecuteDataSet(dbCommand);

            return ds;
        }

        //gets an artist by artist id and returns it as an artist
        public ArtistModel getArtist(string artistName)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("get_Artist");
            db.AddInParameter(dbCommand, "artistName", DbType.String, artistName);
            db.AddOutParameter(dbCommand, "artistID", DbType.Int32, sizeof(int));
            db.ExecuteScalar(dbCommand);


            DataSet ds = db.ExecuteDataSet(dbCommand);

            DataRow dr = ds.Tables[0].Rows[0];

            ArtistModel artist = new ArtistModel()
            {
                artistName = dr.Field<string>("artistName"),
                artistID = dr.Field<int>("artistID")
            };

            return artist;
        }

        //inserts an artist into the db
        public int InsertArtist(ArtistModel thisArtist)
        {

            try
            {
                //insert the artist into the db
                DbCommand dbCommand = db.GetStoredProcCommand("ins_Artist");
                db.AddInParameter(dbCommand, "@artistName", DbType.String, thisArtist.artistName);

                db.ExecuteNonQuery(dbCommand);

                return 1;
            }

            catch
            {
                return -1;
            }
        }

        //get artistID
        public int GetArtistID(ArtistModel thisArtist)
        {
            int newArtistID;

            DbCommand get_Artist = db.GetStoredProcCommand("get_Artist");
            db.AddInParameter(get_Artist, "artistName", DbType.String, thisArtist.artistName);
            db.AddOutParameter(get_Artist, "artistID", DbType.Int32, sizeof(int));
            db.ExecuteScalar(get_Artist);
            newArtistID = (Int32)db.GetParameterValue(get_Artist, "@artistID");


            return Convert.ToInt32(newArtistID);
        }

        //updates an artist by artistID
        public bool UpdateArtist(ArtistModel thisArtist)
        {

            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("ins_Artist");

                db.AddInParameter(dbCommand, "artistID", DbType.String, thisArtist.artistID);
                db.AddInParameter(dbCommand, "artistName", DbType.String, thisArtist.artistName);

                db.ExecuteNonQuery(dbCommand);

                return true;
            }

            catch
            {
                return false;
            }
        }

        //deletes an artist from the database

    }
}