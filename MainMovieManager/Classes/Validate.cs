using System;
namespace MainMovieManager.Classes
{
    public class Validate
    {
        public int Counter = 0;

        public bool Check_Passwords_Match(string p1, string p2)
        {
            if (p1 == p2)
                return true;
            else
                return false;
        }

        public bool see_if_null_or_empty(string input)
        {
            if (input == "" || input == " ")
                return false;
            else
                return true;
        }

        public string CheckField(string input)
        {
            if (see_if_null_or_empty(input))
            {
                Counter++;
                return "Input OK";
            }
            else
            {
                Counter = 0;
                return "Enter something into the Text Field";
            }
        }

        public string CheckPasswords(string p1, string p2)
        {
            if (Check_Passwords_Match(p1, p2))
            {
                Counter++;
                return "Passwords Match";
            }
            else
            {
                Counter = 0;
                return "Passwords Don't Match";
            }
        } 
    }
}
