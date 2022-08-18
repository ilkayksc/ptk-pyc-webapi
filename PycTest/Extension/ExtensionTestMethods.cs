using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycTest.Extension
{
    public static class ExtensionTestMethods
    {
        public static bool IsGreaterThen(this int i, int value)
        {
            return i > value;
        }
        public static string ToFormattedPrice(this decimal amount)
        {
            return amount.ToString("#,##0.00");
        }
        public static string GetFirstThreeCharacters(this String str)
        {
            if (str.Length < 3)
            {
                return str;
            }
            else
            {
                return str.Substring(0, 3);
            }
        }
    }
}
