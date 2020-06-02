using System;
using System.Text.RegularExpressions;

namespace Utils
{
    public static class ApplicationUtils
    {
        public static bool checkDate(string date)
        {
            Regex regex = new Regex( @"^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$" );
            if (regex.Match(date).Success == false) {
                return false;
            }

            return true;
        }
    }
}
