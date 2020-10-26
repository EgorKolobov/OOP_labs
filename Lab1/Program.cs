using System;
using System.Collections.Generic;
using System.IO;

namespace lab1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var a = new Parser();
                Console.WriteLine("Enter .ini file filename:");
                var file = "text.ini";//Console.ReadLine();
                a.ReadInfo(file);
                Console.WriteLine("Enter section name:");
                var section = Console.ReadLine();
                Console.WriteLine("Enter value's name:");
                var name = Console.ReadLine();
                Console.WriteLine("Enter value's type ( int, double, string ) :");
                var type = Console.ReadLine();
                switch (type)
                {
                    case "int":
                        Console.WriteLine(a.GetValue<int>(section, name, type));
                        break;
                    case "double":
                        Console.WriteLine(a.GetValue<double>(section, name,type));
                        break;
                    case "string":
                        Console.WriteLine(a.GetValue<string>(section, name, type));
                        break;
                    default:
                        throw new Exception("No value with such type: " + type);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}