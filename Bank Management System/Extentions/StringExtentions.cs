using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Extentions
{
    public static class StringExtentions
    {
        public static bool IsValidNationalID (this string str)
        {
            return str.Length == 14 && str.All(char.IsDigit);
        }
        public static bool IsValidPhone(this string str)
        {
            return str.All(char.IsDigit);
        }
    }
}
