using System;
using System.IO;
using System.Net;
using AppKit;
using MainMovieManager.Database_Models;

namespace MainMovieManager.Classes
{
    public class Requests
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
            //var httpWebRequest = (HttpWebRequest)WebRequest.Create($"http://localhost:5000/api/wishlist/{index}");
            //httpWebRequest.ContentType = "application/json";
            //httpWebRequest.Method = "DELETE";

            HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create($"http://localhost:5000/api/wishlist/{index}");
            HttpWReq.ContentType = "application/json";
            HttpWReq.Method = "DELETE";

            //HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();

            // Insert code that uses the response object.

            //var alert = new NSAlert()
            //{
            //    AlertStyle = NSAlertStyle.Critical,
            //    InformativeText = "mmmm yup!",
            //    MessageText = $"{HttpWResp}",
            //};
            //alert.RunModal();


            //HttpWResp.Close();

            //httpWebRequest.GetRequest();

            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    streamWriter.Write(json);
            //    streamWriter.Flush();
            //    streamWriter.Close();
            //}


            //using (HttpWebResponse httpResponse = new HttpWebResponse())
            //{

            //}


            //    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //var httpSomething = httpResponse.GetResponseStream();

            ////System.Diagnostics.Debug.WriteLine(httpSomething);

            //using (var streamReader = new StreamReader(httpSomething))
            //{
            //    Result = streamReader.ReadToEnd();
            //}

            return "Movie has been removed from Wishlist";
        }
    }
}
