using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Consolelinq
{
    class Program
    {
        static void Main(string[] args)
        {
            MathHelper mathhelper = new MathHelper();

            while (true)
            {
                Console.WriteLine("x vared konid ");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("y vared konid ");
                int y = Convert.ToInt32(Console.ReadLine());
                var result = mathhelper.jam(x,y);
                Console.WriteLine($"x : {x} + y{y}= {result}");



            }
           

        }

    }
}

