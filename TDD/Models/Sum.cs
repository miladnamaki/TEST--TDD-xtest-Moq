using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDD.Models
{
    public class Sum
    {
        public int Execute(string number)
        {
            if (number==""   )
            {
                return 0;
            }
            if (number.EndsWith(','))
            {
                number = number.Substring(0, number.Length - 1);
            }
            string[] stringnumbers = number.Split(",");
            int[] intnumber = Array.ConvertAll(stringnumbers, s => int.Parse(s));

             return intnumber.Sum();

        }
    }
}
