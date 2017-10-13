using System;
using System.IO;

namespace books
{
    class Program
    {
        static string dest = @"C:\book_temp\";
        static void Main(string[] args)
        {
            var source = @"D:\Other - Samsung Drive\kindle books";

            DoDirectoryRecurse(source);

            Console.WriteLine("Done!");
            Console.ReadLine();
        }

        private static void DoDirectoryRecurse(string sourcedir)
        {
            var files = Directory.GetFiles(sourcedir);
            foreach (string fileposs in files)
            {
                var extension = Path.GetExtension(fileposs);
                if (extension.Contains("mobi"))
                {
                    var filename = Path.GetFileName(fileposs);

                    File.Copy(fileposs, dest + filename);
                }
            }

            foreach (var direct in Directory.GetDirectories(sourcedir))
            {
                DoDirectoryRecurse(direct);
            }
        }
    }
}