using System;
using Newtonsoft.Json;
using MainMovieManager.Database_Models;
using System.Collections.Generic;
using System.Net;
using System.Diagnostics;
using System.IO;
using MainMovieManager.Interfaces;

namespace MainMovieManager.Classes
{
    public class Person : IPerson
    {
        public string PersonIndex { get; set; }
        public bool GotPerson { get; set; }
        public string PersonDetails { get; set; }
        public string Uname { get; set; }
        public List<User_Model> data { get; set; }

        public void GetUserData()
        {
            using (WebClient wc = new WebClient())
            {
                string url = $"http://localhost:5000/api/users/";
                string json = wc.DownloadString(url);
                data = JsonConvert.DeserializeObject<List<User_Model>>(json);
            }
        }

        public string GetPerson()
        {
            GetUserData();
            string output = "";
            foreach(User_Model i in data)
            {
                if (PersonIndex == i.Id) // Check if the User Picked id matches any person ID
                {
                    GotPerson = true;
                    Uname = i.Uname;
                    break;
                }
                else
                    GotPerson = false;
                    output = "You didn't sign in";
            }
            return output;
        }

        public string UpdatePerson(string f, string l, string p, string e)
        {
            User_Model u1 = new User_Model();
            Requests r1 = new Requests();
            u1.Id = SecondController.sign.GetPerson;
            u1.Fname = f;
            u1.Lname = l;
            u1.Uname = Uname;
            u1.Passwrd = p;
            u1.Email = e;

            string json = JsonConvert.SerializeObject(u1);
            Debug.WriteLine(json);

            return r1.UserPutRequest(json, u1);
        }
    }
}
