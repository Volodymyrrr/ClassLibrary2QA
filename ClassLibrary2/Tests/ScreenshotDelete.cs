using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary2.Tests
{
        class Program
        {
            static void Main(string[] args)
            {
                string topPath = @"C:\NewDirectory";
                string subPath = @"C:\NewDirectory\NewSubDirectory";

                try
                {
                    Directory.CreateDirectory(subPath);

                    using (StreamWriter writer = File.CreateText(subPath + @"\example.txt"))
                    {
                        writer.WriteLine("content added");
                    }

                    Directory.Delete(topPath, true);

                    bool directoryExists = Directory.Exists(topPath);

                    Console.WriteLine("top-level directory exists: " + directoryExists);
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.Message);
                }
            }
        }
  
}
