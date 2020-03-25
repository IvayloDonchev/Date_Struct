using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date_Struct
{
    class Program
    {
        static void Main(string[] args)
        {
            Date date = new Date(1, 3, 2017);
            Console.WriteLine(date);                // 01.03.2017
            Console.WriteLine(date.Yesterday());    // 28.02.2017
            date = new Date(1, 3, 2012);            // високосна
            Console.WriteLine(date.Yesterday());    // 29.02.2012
            date = new Date(1, 1, 2017);            
            Console.WriteLine(date);                // 01.01.2017
            date = date.Yesterday();                  
            Console.WriteLine(date);                // 31.12.2016
            Console.WriteLine(date.Tomorrow());     // 01.01.2017
            date = new Date(28, 2, 2016);
            date = date.Tomorrow();
            Console.WriteLine(date);                // 29.02.2016
            date = new Date(28, 2, 2017);
            Console.WriteLine(date.Tomorrow());     // 01.03.2017

            Console.WriteLine(++date);              // 01.03.2017
            date--;
            Console.WriteLine(date);                // 28.02.2017

            var (d, m, s) = date; // деконструкция
            Console.WriteLine($"{d.ToString("D2")}.{m.ToString("D2")}.{s}");    // 28.02.2017
            Console.WriteLine("---------------------------------------");
            Date d1 = new Date(13, 4, 2019);
            Date d2 = d1;
            d1 = new Date(1, 1, 2020);
            Console.WriteLine($"d1: {d1}\nd2: {d2}"); // d1: 01.01.2020
                                                      // d2: 13.04.2019
            Console.ReadKey();
        }
    }
}
