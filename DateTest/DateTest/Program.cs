using DateTest.Testers;
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

            UtcTester utcTester = new UtcTester();
            utcTester.InitTest();

            Console.ReadLine();
        }

        private static void TestToString()
        {
            //When we recive a datetime in string format, we'd try convert this string to Datetime Value.
            //In this point is important know the culture because if we try to convert the string value using 
            //a wrong culture, the covnert method will throw a exception.

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

            //Change for the original culture
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
        }

        private static void TestThreadCulture(DateTime dateNow)
        {
            //CurrentCulture - Culture: encargada de traducir formatos de fechas, monedas, etc : Los dejamos en español Argentina
            //CurrentUICulture - UiCulture: Encarga de traducir nombres, dataAnnotations etc : Dejamos que se seteen en runtime segun preferencia del usuario

            //ToString() use the CurrentCulture Thread for cast Datetime to string.
            //If we change the CurrentCulture Thread value, ToString() will use this new value.
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
            //Transform current datetime to others culture formats
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------TEST CULTURE-----------------");
            Console.WriteLine($"Date Now - Default Format - Culture France [fr-FR]   : {dateNow.ToString(CultureInfo.CreateSpecificCulture("fr-FR"))}");
            Console.WriteLine($"Date Now - Default Format - Culture Argentina [es-AR]: {dateNow.ToString(CultureInfo.CreateSpecificCulture("es-AR"))}");
            Console.WriteLine($"Date Now - Default Format - Culture USA [en-US]      : {dateNow.ToString(CultureInfo.CreateSpecificCulture("en-US"))}");
            Console.WriteLine($"Date Now - Default Format - Culture Chinese [zh-CN]  : {dateNow.ToString(CultureInfo.CreateSpecificCulture("zh-CN"))}");
        }

        private static void TestDateNow(DateTime dateNow)
        {
            //Retrive Datetime from SO or Server
            //Using default culture 
            //If we change SO datetime, Datetime noew will return the new value
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------TEST DATE NOW-----------------");
            Console.WriteLine($"Date Now (Datetime Operation System - Default): { dateNow.ToString("dd/MM/yyyy HH:mm:ss") }");
        }
    }
}
