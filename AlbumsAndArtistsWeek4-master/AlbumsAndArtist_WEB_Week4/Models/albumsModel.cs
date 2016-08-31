using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbumsAndArtist_WEB_Week4.Models
{
    public class albumsModel
    {
        public int albumsID { get; set; }
        public string albumName { get; set; }
        public int amountInStock { get; set; }
        public decimal normalPrice { get; set; }
        public decimal salePrice { get; set; }
        public string artistID { get; set; }
        public string artistName { get; set; }
    }
}