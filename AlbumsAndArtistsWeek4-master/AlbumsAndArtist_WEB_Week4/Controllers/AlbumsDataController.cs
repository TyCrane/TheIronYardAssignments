/***********************************************************************************************************
Description: Data Controller for Albums
	 
Author: 
	Tyrell Powers-Crane 
Date: 
	7.15.2016
Change History:
	
************************************************************************************************************/
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
using AlbumsAndArtist_WEB_Week4.Models;
using System.Collections.Generic;

namespace AlbumsAndArtist_WEB_Week4.Controllers
{

    public class AlbumsDataController
    {
        public static SqlDatabase db;

        public AlbumsDataController()
        {
            if (db == null)
            {
                db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["albumsAndArtistConnection"].ToString());
            }
        }

/************************************************************ GET METHODS ********************************************************/

        //gets all albums from a db and returns it as a dataset
        public DataSet GetAlbums()
        {
            DbCommand dbCommand = db.GetStoredProcCommand("get_Albums");

            DataSet ds = db.ExecuteDataSet(dbCommand);

            return ds;
        }

        //gets an album by id and returns it as an album
        public albumsModel GetAlbum(string albumName, string artistName)
        {

            DbCommand dbCommand = db.GetStoredProcCommand("get_Album");
            db.AddInParameter(dbCommand, "albumName", DbType.String, albumName);
            db.AddInParameter(dbCommand, "artistName", DbType.String, artistName);
            // db.AddInParameter(dbCommand, "@parameterName", DbType.TypeName, variableName);

            DataSet ds = db.ExecuteDataSet(dbCommand);

            DataRow dr = ds.Tables[0].Rows[0];

            albumsModel album = new albumsModel();

                album.albumName = dr.Field<string>("albumName");
                album.amountInStock = dr.Field<int>("amountInStock");
                album.normalPrice = dr.Field<decimal>("normalPrice");
                album.salePrice = dr.Field<decimal>("sellPrice");
                album.artistName = dr.Field<string>("artistName");
            

            return album;
        }

/*********************************************************** INSERT METHODS *******************************************************/

        //inserts an Album into the database
        public bool InsertAlbum(albumsModel thisAlbum)
        {

            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("ins_Album");
                db.AddInParameter(dbCommand, "albumName", DbType.String, thisAlbum.albumName);
                db.AddInParameter(dbCommand, "amountInStock", DbType.Int32, thisAlbum.amountInStock);
                db.AddInParameter(dbCommand, "normalPrice", DbType.Decimal, thisAlbum.normalPrice);
                db.AddInParameter(dbCommand, "salePrice", DbType.Decimal, thisAlbum.salePrice);
                db.AddInParameter(dbCommand, "artistID", DbType.Int32, thisAlbum.artistID);

                db.ExecuteNonQuery(dbCommand);

                return true;
            }

            catch
            {
                return false;
            }
        }

/********************************************************** UPDATE METHODS ********************************************************/


        //updates an album by albumID
        public bool UpdateAlbum(albumsModel thisAlbum)
        {

            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("upd_Album");

                db.AddInParameter(dbCommand, "albumID", DbType.String, thisAlbum.albumsID);
                db.AddInParameter(dbCommand, "albumName", DbType.String, thisAlbum.albumName);
                db.AddInParameter(dbCommand, "amountInStock", DbType.Decimal, thisAlbum.amountInStock);
                db.AddInParameter(dbCommand, "normalPrice", DbType.Decimal, thisAlbum.normalPrice);
                db.AddInParameter(dbCommand, "sellPrice", DbType.Decimal, thisAlbum.salePrice);

                db.ExecuteNonQuery(dbCommand);

                return true;
            }

            catch
            {
                return false;
            }
        }

        //sells an album
        public int SellAlbum(string albumName)
        {

            try
            {
                int amount;
                DbCommand dbCommand = db.GetStoredProcCommand("upd_AlbumsInStock");

                db.AddInParameter(dbCommand, "albumName", DbType.String, albumName);
                db.AddOutParameter(dbCommand, "amountInStock", DbType.Int32, sizeof(int));
                db.ExecuteScalar(dbCommand);
                amount = (int)db.GetParameterValue(dbCommand, "@amountInStock");

                db.ExecuteNonQuery(dbCommand);

                return amount;
            }

            catch
            {
                return 0;
            }
        }
        //deletes an album by albumID
    }
}