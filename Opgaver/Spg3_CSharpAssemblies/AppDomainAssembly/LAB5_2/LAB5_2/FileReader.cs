using System;

namespace LAB5_2
{
    public class FileReader
    {
        public static string ReadFile(string filename)
        {
            Console.WriteLine("Attempting to read your info ..!!");

            return System.IO.File.ReadAllText(filename);
        }
    }
}
