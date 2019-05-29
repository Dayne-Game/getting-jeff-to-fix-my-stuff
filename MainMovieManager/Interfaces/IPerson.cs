using System;
using System.Collections.Generic;
using MainMovieManager.Database_Models;

namespace MainMovieManager.Interfaces
{
    public interface IPerson
    {
        string PersonIndex { get; set; }
        bool GotPerson { get; set; }
        string PersonDetails { get; set; }
        string Uname { get; set; }
        List<User_Model> data { get; set; }

        void GetUserData();
        string GetPerson();
        string UpdatePerson(string f, string l, string p, string e);
    }
}
