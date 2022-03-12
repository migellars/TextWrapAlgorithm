using System;
using System.Collections.Generic;
using System.IO;
using static System.IO.File;

namespace TextWrap
{
    public class WrapClass
    {
        public static List<string> DataWrap(string data, int limit)
        {
            int currentIndex;
            var lastWrap = 0;
            var whitespace = new[] { '\r', '\n', '\t' };
            var list = new List<string>();

            do
            {
                currentIndex = lastWrap + limit > data.Length ? data.Length : (data.LastIndexOfAny(new[] { ',', '.', '?', '!', ':', ';', '-', '\n', '\r', '\t' }, Math.Min(data.Length - 1, lastWrap + limit)) + 1);
                if (currentIndex <= lastWrap)
                    currentIndex = Math.Min(lastWrap + limit, data.Length);
                list.Add(data.Substring(lastWrap, currentIndex - lastWrap).Trim(whitespace));
                lastWrap = currentIndex;
            } while (currentIndex < data.Length);
            return list;
        }

        public static List<string> DataWrapReadFromFile()
        {
            //Get value from file
            var docToRead = Path.Combine(Path.Combine(AppContext.BaseDirectory, "doc\\dataRead.txt"));
            var docToWritePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Telesoftas");
            var files = ReadAllText(docToRead);
            using var reader = new StreamReader(OpenRead(docToRead));
            //get limit for data
            int fixedLength;

            //Validate limit input
            Console.WriteLine("input limit for file read");
            while (!int.TryParse(Console.ReadLine(), out fixedLength))
            {
                Console.WriteLine("Please input a Valid number for limit");
                Console.WriteLine("========================");

            }

            var dataResult = DataWrap(files, fixedLength);
            Console.WriteLine("A Doc folder will be created on your desktop for the result");
            const string file = "dataToWrite.txt";
            if (!Directory.Exists(docToWritePath))
                try
                {
                    Directory.CreateDirectory(docToWritePath);
                    var filePath = Path.Combine(docToWritePath, file);
                    if (!Exists(filePath))
                    {
                        using var writer = new StreamWriter(Create(filePath));
                        foreach (var data in dataResult) writer.WriteLine(data);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("IO:" + e);
                    throw;
                }
            else
                try
                {
                    var filePath = Path.Combine(docToWritePath, file);
                    if (!Exists(filePath))
                    {
                        using var writer = new StreamWriter(Create(filePath));
                        foreach (var data in dataResult) writer.WriteLine(data);

                    }
                    else
                    {
                        using var writer = new StreamWriter(Create(filePath));
                        foreach (var data in dataResult) writer.WriteLine(data);

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("IO:" + e);
                    throw;
                }

            return dataResult;
        }
    }
}