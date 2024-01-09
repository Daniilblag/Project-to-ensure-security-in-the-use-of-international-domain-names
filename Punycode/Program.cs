using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using test;
namespace Punycode
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IdnMappings idn = new IdnMappings();
            
            while(true)
            {
                Console.WriteLine("Введите доменное имя для преобразования или введите :stop для завершения работы программы.");
                string a = Console.ReadLine();
                try
                {
                    if (a == ":stop")
                        break;
                    string punyCode = idn.GetAscii(a);
                    string name2 = idn.GetUnicode(punyCode);
                    Console.WriteLine("{0} --> {1} --> {2}", a, punyCode, name2);
                    Console.WriteLine("Оригинал: {0}", ShowCodePoints(a));
                    Console.WriteLine("Преобразованный: {0}", ShowCodePoints(name2));
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("{0} is not a valid domain name.", a);
                }
            }
           
           
        }

        private static string ShowCodePoints(string str1)
        {
            string output = "";
            foreach (var ch in str1)
                output += String.Format("U+{0} ", Convert.ToUInt16(ch).ToString("X4"));

            return output;
        }
    }
    }

