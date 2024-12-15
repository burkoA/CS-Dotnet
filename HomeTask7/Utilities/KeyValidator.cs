using System.Text.RegularExpressions;

namespace HomeTask7.Utilities
{
    public static class KeyValidator
    {
        public static bool IsValid(string input)
        {
            if(Regex.IsMatch(input, @"^(?:\d{9}[\dX]|\d{13})$"))
            {
                return true;
            }
            if(!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"^[a-zA-Z0-9\-]+$"))
            {
                return true;
            }

            return false;
        }
    }
}
