using System;
using System.Collections.Generic;
using AppKit;
using Foundation;
using MainMovieManager.Database_Models;

namespace MainMovieManager.Classes
{
    public class Movies
    {
        public string GetMovieID { get; set; }
        public string MovieImageUrl { get; set; }
        public bool isImage { get; set; }
        public bool isDescription { get; set; }
        public List<string> description { get; set; }

        public string SearchMovies(string searchinput, List<Movie_Model> data)
        { 
            string output = "";
            var x = Convert.ToString(data);
            var input = searchinput.ToLower();
            description = new List<string>();
            foreach(Movie_Model i in data)
            {
                if(input == "" || input == " ") {
                    isDescription = false;
                    isImage = false;
                    output = "Enter a Movie";
                    break;
                } else if (i.Title.ToLower().Contains(input))
                {
                    isDescription = true;
                    output = $"{i.Title}\n";
                    GetMovieID = i.Id;
                    description.Add(i.Summary);
                    description.Add(i.Genre);
                    description.Add(i.Rating);
                    isImage = true;
                    MovieImageUrl = $"https://m.media-amazon.com/images/M/{i.Picture}.jpg";
                    break;
                }
                else
                {
                    MovieImageUrl = "";
                    isDescription = false;
                    isImage = false;
                    output = "Movie Couldn't be found";
                }
            }
            return output;
        }

        public string GetMovieDescription()
        {
            string output = "";
            foreach(String item in description)
            {
                output += $"{item}\n\n";
            }
            return output;
        }

        public void CheckDescription(NSTextField input)
        {
            if(isDescription == true)
                input.Hidden = false;
            else
            {
                input.StringValue = "Click on the Movie to read the Description, Genre and Rating!";
                input.Hidden = true;
            }

        }

        public string DisplayMovieDescription()
        {
            if (isDescription == true)
                return GetMovieDescription();
            else
                return "Movie Description not found";
        }

        public bool CheckMovieImage()
        {
            if (isImage == true)
                return true;
            else
                return false;
        }
    }
}
