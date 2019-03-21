using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateNow = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Date Test Project!");
            Console.WriteLine($"We work with this datetime: { dateNow.ToString("dd/MM/yyyy HH:mm:ss") }");

            TestDateNow(dateNow);
            TestCulture(dateNow);
            TestThreadCulture(dateNow);
            TestToString();

            Console.ReadLine();
        }

        private static void TestToString()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string value = "20/11/2019 22:09";
            DateTime result;

            //Success
            Console.WriteLine($"Try to parse { value } to { Thread.CurrentThread.CurrentCulture.Name } culture...");
            if (!DateTime.TryParse(value, out result))
                Console.WriteLine($"Parse Error to { Thread.CurrentThread.CurrentCulture.Name } culture!");
            else
                Console.WriteLine("Success!");

            //Failed!
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Console.WriteLine($"Try to parse { value } to { Thread.CurrentThread.CurrentCulture.Name } culture...");

            if (!DateTime.TryParse(value, out result))
                Console.WriteLine($"Parse Error to { Thread.CurrentThread.CurrentCulture.Name } culture!");
            else
                Console.WriteLine("Success!");

            //Failed!
            Console.WriteLine($"Try to parse Exact { value } - Format: dd/MM/yyyy HH:mm:ss...");
            if (!DateTime.TryParseExact(value, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault, out result))
                Console.WriteLine($"Try Parse Exact Error - Format: dd/MM/yyyy HH:mm:ss");
            else
                Console.WriteLine("Success!");

            //Success!
            Console.WriteLine($"Try to parse Exact { value } - Format: dd/MM/yyyy HH:mm...");
            if (!DateTime.TryParseExact(value, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault, out result))
                Console.WriteLine($"Try Parse Exact Error - Format: dd/MM/yyyy HH:mm");
            else
                Console.WriteLine("Success!");

            //Success!
            Console.WriteLine($"Try to parse Exact { value } - Many formats...");
            string[] format = new string[] { "yyyy-MM-dd HH:mm:ss", "dd/MM/yyyy HH:mm", "dd/MM/yyyy HH:mm:ss", "MM/dd/yyyy HH:mm", "dd/MM/yyyy", "MM/dd/yyyy" };

            if (!DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault, out result))
                Console.WriteLine($"Try Parse Exact Error to { Thread.CurrentThread.CurrentCulture.Name } culture!");
            else
                Console.WriteLine("Success!");

        }

        private static void TestThreadCulture(DateTime dateNow)
        {

            //CurrentCulture - Culture: encargada de traducir formatos de fechas, monedas, etc : Los dejamos en español Argentina
            //CurrentUICulture - UiCulture: Encarga de traducir nombres, dataAnnotations etc : Dejamos que se seteen en runtime segun preferencia del usuario
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Current Culture: { Thread.CurrentThread.CurrentCulture.Name }");
            Console.WriteLine($"Date Now - : { dateNow.ToString() }");

            //Change current culture to en-US
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Console.WriteLine($"Current Culture: { Thread.CurrentThread.CurrentCulture.Name }");
            Console.WriteLine($"Date Now - : { dateNow.ToString() }");

            //Change for the original culture
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
        }

        private static void TestCulture(DateTime dateNow)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------TEST CULTURE-----------------");
            Console.WriteLine($"Date Now - Default Format - Culture France [fr-FR]   : {dateNow.ToString(CultureInfo.CreateSpecificCulture("fr-FR"))}");
            Console.WriteLine($"Date Now - Default Format - Culture Argentina [es-AR]: {dateNow.ToString(CultureInfo.CreateSpecificCulture("es-AR"))}");
            Console.WriteLine($"Date Now - Default Format - Culture USA [en-US]      : {dateNow.ToString(CultureInfo.CreateSpecificCulture("en-US"))}");
            Console.WriteLine($"Date Now - Default Format - Culture Chinese [zh-CN]  : {dateNow.ToString(CultureInfo.CreateSpecificCulture("zh-CN"))}");
        }

        private static void TestDateNow(DateTime dateNow)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------TEST DATE NOW-----------------");
            Console.WriteLine($"Date Now (Datetime Operation System - Default): { dateNow.ToString("dd/MM/yyyy HH:mm:ss") }");
        }
    }
}
