using System;
using System.Collections.Generic;
using System.Diagnostics;
using MainMovieManager.Database_Models;

namespace MainMovieManager.Classes
{
    public class Signin
    {
        public bool UnameCheck { get; set; }
        public bool PasswordCheck { get; set; }
        public bool CheckAll { get; set; }
        public string GetPerson { get; set; }

        public void Check_Username_Password(string username, string password, List<User_Model> data)
        {
            foreach (User_Model i in data)
            {
                Debug.WriteLine($"{i.Id} | {i.Uname} | {i.Passwrd}");
                if (username == i.Uname)
                {
                    UnameCheck = true;
                    if (password == i.Passwrd)
                    {
                        CheckAll = true;
                        PasswordCheck = true;
                        GetPerson = i.Id;
                        break;
                    }
                }
                else
                {
                    CheckAll = false;
                    UnameCheck = false;
                    PasswordCheck = false;
                    GetPerson = "-1";
                }
            }
        }

        public string check_password(string password)
        {
            if (password == "" || password == " ")
            {
                return "Please Enter Password";
            }
            else if (PasswordCheck == false)
            {
                return "Incorrect Password";
            }
            else
            {
                return "";
            }
        }

        public string check_username(string username)
        {
            if (username == "" || username == " ")
            {
                return "Please Enter Username";
            }
            else if (UnameCheck == false)
            {
                return "Incorrect Username";
            }
            else
            {
                return "";
            }
        }
    }
}
