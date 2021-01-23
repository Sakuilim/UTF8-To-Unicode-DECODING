using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace UNICODE_TO_UTF8_Csharp
{
    public static class Program
    {
        static List<char> txt = new List<char>();
        public static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
            Secnd();
        }
        static void Secnd()
        {

            string duom = @"386intel.txt";
            FileReader.AntraP(duom, txt);
            using (StreamWriter sw = new StreamWriter(@"ATS.txt"))
            {
                foreach (char x in txt)
                {
                    sw.Write(x);
                }

            }

            Console.WriteLine("Atkoduota!");
        }
        static void First()
        {
            int laik = 0;
            string b;
            Console.WriteLine("Irasykite simbolio koda");
            bool good = false;
            while (good != true)
            {
                b = Console.ReadLine();
                int chck = int.Parse(b);
                if (chck <= 0 || chck > 999999999)
                {
                    Console.WriteLine("Bandykite kita koda");
                    good = false;
                }
                else
                {
                    good = true;
                    FileReader.Lines(b,laik);
                }
            }
        }
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Pasirinkite funkcija:");
            Console.WriteLine("1) Suzinoti daugiau apie desimtaini skaiciu");
            Console.WriteLine("2) Atkoduoti 386intel.txt faila naudojant CP437");
            Console.WriteLine("3) Iseiti ");
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    First();
                    return true;
                case "2":
                    Secnd();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }
    }
}
