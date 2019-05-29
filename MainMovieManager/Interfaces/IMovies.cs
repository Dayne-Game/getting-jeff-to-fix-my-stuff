using System;
using System.Collections.Generic;
using MainMovieManager.Database_Models;

namespace MainMovieManager.Interfaces
{
    public interface IMovies
    {
        string GetMovieID { get; set; }
        string MovieImageUrl { get; set; }
        bool isImage { get; set; }
        bool isDescription { get; set; }
        List<string> description { get; set; }

        string SearchMovies(string searchinput, List<Movie_Model> data);
        string GetMovieDescription();
        string DisplayMovieDescription();
        bool CheckMovieImage();
    }
}
