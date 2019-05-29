using System;
using System.Net;
using Newtonsoft.Json;
using MainMovieManager.Database_Models;
using System.Collections.Generic;
using System.Diagnostics;
using MainMovieManager.Interfaces;

namespace MainMovieManager.Classes
{
    public class Wishlist : IWishlist
    {
        public string PID { get; set; }
        public string MID { get; set; }
        public string WishlistMovieItem { get; set; }
        public List<Wishlist_Model> data { get; set; }
        public List<Movie_Model> movies { get;  set;}
        public List<Wishlist_Model_With_ID> data_with_id { get; set; }

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

        public void DeserilizeWishlistData()
        {
            using (WebClient wc = new WebClient())
            {
                string url = $"http://localhost:5000/api/wishlist/";
                string json = wc.DownloadString(url);
                data = JsonConvert.DeserializeObject<List<Wishlist_Model>>(json);
            }
        }

        public void DeserilizeMovieData()
        {
            using (WebClient wc = new WebClient())
            {
                string url = $"http://localhost:5000/api/movies/";
                string json = wc.DownloadString(url);
                movies = JsonConvert.DeserializeObject<List<Movie_Model>>(json);
            }
        }

        public void Deserlize_Wishlist_With_ID()
        {
            using (WebClient wc = new WebClient())
            {
                string url = $"http://localhost:5000/api/wishlist/";
                string json = wc.DownloadString(url);
                data_with_id = JsonConvert.DeserializeObject<List<Wishlist_Model_With_ID>>(json);
            }
        }

        public string DisplayWishlist()
        {
            DeserilizeWishlistData();
            WishlistMovieItem = "";

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
            DeserilizeMovieData();
            foreach(Movie_Model i in movies)
            {
                if(i.Id == MID)
                {
                    WishlistMovieItem += $"{i.Title}\n\n";
                }
            }
            return WishlistMovieItem;
        }

        public bool Check_if_PID_Exists()
        {
            bool decision = false;
            foreach (Wishlist_Model x in data)
            {
                if (!x.PID.Contains(PID))
                {
                    decision = true;
                    break;
                }
                else
                {
                    decision = false;
                    break;
                }
            }
            return decision;
        }

        public string Check_MID_isnot_in_List(Wishlist w1)
        {
            string output = "";
            bool check = false;
            Validate v1 = new Validate();

            foreach (Wishlist_Model i in data)
            {

                if (i.PID == PID && i.MID == MID)
                {
                    output = "Movie already Added";
                    check = false;
                    break;
                }
                else if (v1.Check_PID_and_MID_Together(MID, PID) == false)
                {
                    output = $"You are not signed in\nOr you haven't selected a Movie";
                    break;
                }
                else
                {
                    check = true;
                }
            
            }

            if(check == true)
            {
                output = AddItemWishlist();
            }

            return output;
        }

        public string Remove_Movie_From_Wishlist(string input)
        {
            string output = "";
            string json = "";
            Deserlize_Wishlist_With_ID();

            if(input == null || input == " " || input == "")
            {
                output = "Please Enter a Movie Title";
            } else if (input.ToLower() == "the")
            {
                output = $"Don't enter 'THE'";
            }
            else
            {
                foreach (Wishlist_Model_With_ID i in data_with_id)
                {
                    Debug.WriteLine(i);
                    if (i.PID == PID)
                    {
                        if (i.PID.Contains(PID))
                        {
                            DeserilizeMovieData();
                            foreach (Movie_Model m in movies)
                            {
                                var lowerInput = input.ToLower();
                                if (m.Title.ToLower().Contains(lowerInput))
                                {
                                    MID = m.Id;
                                    if (i.PID.Contains(PID) && i.MID.Contains(MID))
                                    {
                                        Requests r1 = new Requests();
                                        Wishlist_Model w1 = new Wishlist_Model();
                                        output = r1.RemoveWishlistItem(json, i.ID, w1);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return output;
        }
    }
}
