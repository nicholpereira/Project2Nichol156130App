using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredApplication.DataLayer.Infrastructure.Helper
{
    public static class Util
    {
        public static string RandomString(int length = 10)
        {
            if (length == 0) length = 10;

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int RandomNum(int min, int max)
        {
            return new Random().Next(min, max); // creates a number between min and max
        }
    }
}
