using System;
using System.Net;
using Newtonsoft.Json;
using MainMovieManager.Database_Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace MainMovieManager.Classes
{
    public class Wishlist
    {
        public string PID { get; set; }
        public string MID { get; set; }
        public string WishlistMovieItem { get; set; }
        public List<Wishlist_Model> data { get; set; }
        public List<Movie_Model> movies { get;  set;}

        public string AddItemWishlist()
        {
            Wishlist_Model w1 = new Wishlist_Model();
            Requests r1 = new Requests();
            w1.PID = PID;
            w1.MID = MID;

            string json = JsonConvert.SerializeObject(w1);
            Debug.WriteLine(json);

            return r1.PostWishlistItem(json, w1);
        }

        public string DisplayWishlist()
        {
            data = new List<Wishlist_Model>();
            WishlistMovieItem = "";

            using (WebClient wc = new WebClient())
            {
                string url = $"http://localhost:5000/api/wishlist/";
                string json = wc.DownloadString(url);
                data = JsonConvert.DeserializeObject<List<Wishlist_Model>>(json);
            }

            string output = "";

            foreach(Wishlist_Model i in data)
            {
                if(i.PID == PID)
                {
                    MID = i.MID;
                    output = GetMovieTitle();
                }
            }
            return output;
        }

        public string GetMovieTitle()
        {
            using (WebClient wc = new WebClient())
            {
                string url = $"http://localhost:5000/api/movies/";
                string json = wc.DownloadString(url);
                movies = JsonConvert.DeserializeObject<List<Movie_Model>>(json);

                foreach(Movie_Model i in movies)
                {
                    if(i.Id == MID)
                    {
                        WishlistMovieItem += $"{i.Title}\n\n";
                    }
                }
                return WishlistMovieItem;
            }
        }

        public string RemoveItemFromWishlist()
        {

            data = new List<Wishlist_Model>();
            WishlistMovieItem = "";
            string json = "";

            using (WebClient wc = new WebClient())
            {
                string url = $"http://localhost:5000/api/wishlist/";
                json = wc.DownloadString(url);
                data = JsonConvert.DeserializeObject<List<Wishlist_Model>>(json);
            }

            string output = "";

            foreach (Wishlist_Model i in data)
            {
                if (i.PID == PID)
                {
                    //output = $"{ data.Count}";
                    string index = "2";
                    Requests r1 = new Requests();
                    Wishlist_Model w1 = new Wishlist_Model();
                    output = r1.RemoveWishlistItem(json, index, w1);
                }
            }
            return output;
        }
    }
}
