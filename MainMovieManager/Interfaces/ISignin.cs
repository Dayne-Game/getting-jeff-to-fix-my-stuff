using System;
using System.Collections.Generic;
using MainMovieManager.Database_Models;

namespace MainMovieManager.Interfaces
{
    public interface ISignin
    {
        bool UnameCheck { get; set; }
        bool PasswordCheck { get; set; }
        bool CheckAll { get; set; }
        string GetPerson { get; set; }

        void Check_Username_Password(string username, string password, List<User_Model> data);
        string check_password(string password);
        string check_username(string username);
    }
}
