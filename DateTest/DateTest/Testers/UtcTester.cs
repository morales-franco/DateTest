using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTest.Testers
{
    public class UtcTester
    {
        public void InitTest()
        {
            //Datetime now in current Local Time
            var now = DateTime.Now;

            //Get Local Time Zone
            var localZone = TimeZone.CurrentTimeZone;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine($"Current Datetime: {now} in Local Zone: { localZone.StandardName }");

            //Get UTC Time
            var nowInUtcTime = now.ToUniversalTime();
            Console.WriteLine($"Coordinated Universal Time (UTC): { nowInUtcTime }");

            //Convert UTC Time to LocalTime
            var nowLocalTime = nowInUtcTime.ToLocalTime();
            Console.WriteLine($"Convert UTC datetime to Local : { nowLocalTime }");

            Console.WriteLine();

            //Offset. CurrentTime in a local Zone is UTC Time + Offset
            //time = UTC + offset
            //Always a hour is the UTC (Base time) + offset
            Console.WriteLine("Any time is --> time = UTC (Base time!) + offset ");

            var offset = TimeZone.CurrentTimeZone.GetUtcOffset(now);
            Console.WriteLine($"Offset between UTC (Base time) and now ({ now }) [in Local time Zone] = { offset } "); //Arg has a different of -3 hours with UTC

            Console.WriteLine();
            //Enjoying with time zones

            //Using TimeZoneInfo for converting datetime local to UTC
            Console.WriteLine($"Convert local date now to UTC standard using TimeZoneInfo { TimeZoneInfo.ConvertTimeToUtc(now) }");

            //List of all time zone index values
            //https://support.microsoft.com/en-nz/help/973627/microsoft-time-zone-index-values 


            Console.WriteLine();
            TimeZoneInfo argentinaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
            DateTime nowArgentinaTimeZone = TimeZoneInfo.ConvertTimeFromUtc(nowInUtcTime, argentinaTimeZone);
            Console.WriteLine($"Local Datetime to Argentina TimeZone {nowArgentinaTimeZone} are equals ! We're in Argentina!");

            TimeZoneInfo nzTimeZone = TimeZoneInfo.FindSystemTimeZoneById("New Zealand Standard Time");
            DateTime nowNzTimeZone = TimeZoneInfo.ConvertTimeFromUtc(nowInUtcTime, nzTimeZone);
            Console.WriteLine($"Local Datetime to New Zealand TimeZone {nowNzTimeZone}");

            TimeZoneInfo brazilianTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Brazilian Standard Time");
            DateTime nowBrazilianTimeZone = TimeZoneInfo.ConvertTimeFromUtc(nowInUtcTime, brazilianTimeZone);
            Console.WriteLine($"Local Datetime to Brazilian TimeZone {nowBrazilianTimeZone}");

            //Get UTC especifing a TimeZone
            Console.WriteLine($"Convert NZ date now to UTC specifing a TimeZoneInfo { TimeZoneInfo.ConvertTimeToUtc(nowNzTimeZone, nzTimeZone) }");


            Console.WriteLine();
            //Getting TimeZones in my computer
            ReadOnlyCollection<TimeZoneInfo> zones = TimeZoneInfo.GetSystemTimeZones();
            Console.WriteLine("The local system has the following {0} time zones", zones.Count);
            foreach (TimeZoneInfo zone in zones)
                Console.WriteLine(zone.Id);

            Console.WriteLine();






        }
    }
}
