using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using AppKit;
using MainMovieManager.Database_Models;
using MainMovieManager.Interfaces;

namespace MainMovieManager.Classes
{
    public class Requests : IRequests
    {

        public string UserPutRequest(string json, User_Model u1)
        {
            string Result = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"http://localhost:5000/api/users/{u1.Id}");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                Result = streamReader.ReadToEnd();
            }
            return Result;
        }

        public string PostWishlistItem(string json, Wishlist_Model w1)
        {
            string Result = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"http://localhost:5000/api/wishlist/");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                Result = streamReader.ReadToEnd();
            }
            return Result;
        }

        public string RemoveWishlistItem(string json, string index, Wishlist_Model w1)
        {
            string Result = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"http://localhost:5000/api/wishlist/{index}");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                Result = streamReader.ReadToEnd();
            }
            return Result;
        }
    }
}
