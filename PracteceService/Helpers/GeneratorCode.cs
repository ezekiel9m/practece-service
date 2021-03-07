using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracteceService.Helpers
{
    public static class GeneratorCode
    {
        public static string CreatorCode(int length = 10, bool onlyNumbers = false)
        {
            Random random = new Random();

            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";

            var chars = onlyNumbers ? numbers : letters + numbers;

            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string CreatorCode(bool price = false)
        {
            if (price == true)
            {
                var listPrice = new List<string> { "4500", "3400", "7800","1500"};
                var rnd = new Random();
                return listPrice[rnd.Next(listPrice.Count)];
            }
            else
            {
                var list = new List<string> { "iPhone", "Mac book Pro", "Samsung Galax", "Dell", "HP" };
                var rnd = new Random();
                return list[rnd.Next(list.Count)];
            }
        }
    }
}
