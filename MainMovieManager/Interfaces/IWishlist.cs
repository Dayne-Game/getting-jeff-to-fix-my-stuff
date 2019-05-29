using System;
using System.Collections.Generic;
using MainMovieManager.Classes;
using MainMovieManager.Database_Models;

namespace MainMovieManager.Interfaces
{
    public interface IWishlist
    {
        string PID { get; set; }
        string MID { get; set; }
        string WishlistMovieItem { get; set; }
        List<Wishlist_Model> data { get; set; }
        List<Movie_Model> movies { get; set; }
        List<Wishlist_Model_With_ID> data_with_id { get; set; }

        string AddItemWishlist();
        void DeserilizeWishlistData();
        void DeserilizeMovieData();
        void Deserlize_Wishlist_With_ID();
        string DisplayWishlist();
        string GetMovieTitle();
        bool Check_if_PID_Exists();
        string Check_MID_isnot_in_List(Wishlist w1);
        string Remove_Movie_From_Wishlist(string input);
    }
}
