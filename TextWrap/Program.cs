using System;
using static System.String;

namespace TextWrap
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Text Wrap Algorithm");
            Console.WriteLine("========================");

            Console.WriteLine("Please input data to wrap");
            var listOfData = new[] { Console.ReadLine() };
            Console.WriteLine("========================");

            while (listOfData[0] == Empty)
            {
                Console.WriteLine("Please input valid data");
                listOfData = new[] { Console.ReadLine() };
                Console.WriteLine("========================");

            }

            int fixedLength;
            Console.WriteLine("Please input a number for limit");
            Console.WriteLine("========================");


            //Validate limit input
            while (!int.TryParse(Console.ReadLine(), out fixedLength))
            {
                Console.WriteLine("Please input a Valid number for limit");
                Console.WriteLine("========================");

            }


            foreach (var s in listOfData)
            {
                var data = WrapClass.DataWrap(s, fixedLength);
                Console.WriteLine("================ Result from console: ========================");
                foreach (var t in data)
                {
                    Console.WriteLine(t);
                }
            }

            //Read from file
            var data2 = WrapClass.DataWrapReadFromFile();
            Console.WriteLine("==================== Result from file: ========================");
            foreach (var t in data2)
            {
                Console.WriteLine(t);
            }

        }
    }
}
