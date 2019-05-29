using System;
namespace MainMovieManager.Interfaces
{
    public interface IValidate
    {
        bool Check_Passwords_Match(string p1, string p2);
        bool see_if_null_or_empty(string input);
        string CheckField(string input);
        string CheckPasswords(string p1, string p2);
        bool Check_MID(string MID);
        bool Check_PID(string PID);
        bool Check_PID_and_MID_Together(string MID, string PID);
    }
}
