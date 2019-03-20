using System;
using System.Collections.Generic;
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

            Console.ReadLine();
        }

        private static void TestThreadCulture(DateTime dateNow)
        {

            //CurrentCulture - Culture: encargada de traducir formatos de fechas, monedas, etc : Los dejamos en español Argentina
            //CurrentUICulture - UiCulture: Encarga de traducir nombres, dataAnnotations etc : Dejamos que se seteen en runtime segun preferencia del usuario
            var currentCultureName = Thread.CurrentThread.CurrentCulture.Name;
            //Cambia al cambiar el formato original desde windows


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
