using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2App
{
    class Program
    {
        static void Main()
        {
            //Create variables
            DateTime startDate;
            DateTime endDate;
            string choice;

            //Ask the user to enter the oldest of the two dates
            Console.WriteLine("Please enter the oldest of the two dates (mm/dd/yyyy hh:mm:ss)");
            if (DateTime.TryParse(Console.ReadLine(), out startDate) == true)
            {
                //If they entered a date in the right format ask them to enter the second date
                Console.WriteLine("Please enter the most recent of the two dates (mm/dd/yyyy hh:mm:ss)");
                if (DateTime.TryParse(Console.ReadLine(), out endDate) == true)
                {
                    //If that one is in the right format then ask what format they want the result in
                    Console.WriteLine("Do you want to know the total of each unit of time (1 year, 14 months, 62 weeks, etc..) or the combined amount of time (1 years, 2 months, 2 weeks, etc..) [Total/Combined]");
                    choice = Console.ReadLine();
                    //Pass the start date, the end date and the users choice to the Calc function
                    Calc(startDate, endDate, choice);
                }
                else
                {
                    //If the user entered anything but a date in the correct format ask them to fix it and restart
                    Console.WriteLine("Please enter a valid date in the correct format.");
                    Main();
                }
            }
            else
            {
                //If the user entered anything but a date in the correct format ask them to fix it and restart
                Console.WriteLine("Please enter a valid date in the correct format.");
                Main();
            }

            
            //Ask if the user would like to restart the program and try another set of dates
            Console.WriteLine("Do you want to try two more dates? (Yes/No)");
            if (Console.ReadLine() == "Yes")
            {
                //If yes, restart
                Main();
            }
            else
            {
                //If no, or anything but yes, end program
                Environment.Exit(1);
            }
        }

        static void Calc(DateTime sd, DateTime ed, string ch)
        {
            //Create variables
            double workingNum;
            double years;
            double months;
            double weeks;
            double days;
            double hours;
            double minutes;
            double seconds;

            //Set working number to the total amount of seconds between the end date and start date
            workingNum = (ed - sd).TotalSeconds;

            if (ch == "Total")
            {
                //If the user chose "total"

                //In this section days, hours and minutes are calculated using the total amount of seconds
                //That value is then truncated so the user only gets whole numbers in the result
                days = Math.Truncate(workingNum / 86400);
                hours = Math.Truncate(workingNum / 3600);
                minutes = Math.Truncate(workingNum / 60);
                seconds = workingNum;

                //Here I set the workingNum to how many days were calculated above
                workingNum = days;

                //Years, months and weeks are calculated using days and truncated so the user doesn't get decimal answers
                years = Math.Truncate(workingNum / 365);
                months = Math.Truncate(workingNum / 30);
                weeks = Math.Truncate(workingNum / 7);
                days = Math.Truncate(workingNum);
                //Finally all of the units of time are printed out
                Console.WriteLine(years + " year(s)");
                Console.WriteLine(months + " month(s)");
                Console.WriteLine(weeks + " week(s)");
                Console.WriteLine(days + " day(s)");
                Console.WriteLine(hours + " hour(s)");
                Console.WriteLine(minutes + " minute(s)");
                Console.WriteLine(seconds + " second(s)");
            }
            else if (ch == "Combined")
            {
                //In the "combined" section I calculated days and then set the workingNum to the amount of seconds 
                //left after you take out the seconds accounted for in full days (hope that made sense)
                //This continues for hours and minutes
                days = Math.Truncate(workingNum / 86400);
                workingNum = Math.Truncate(workingNum % 86400);
                hours = Math.Truncate(workingNum / 3600);
                workingNum = Math.Truncate(workingNum % 3600);
                minutes = Math.Truncate(workingNum / 60);
                workingNum = Math.Truncate(workingNum % 60);
                seconds = workingNum;

                //Setting workingNum to days calculated above which is the total amount of days between the two dates
                workingNum = days;

                //Calculating years, months and weeks as above using days instead of seconds
                years = Math.Truncate(workingNum / 365);
                workingNum = Math.Truncate(workingNum % 365);
                months = Math.Truncate(workingNum / 30);
                workingNum = Math.Truncate(workingNum % 30);
                weeks = Math.Truncate(workingNum / 7);
                workingNum = Math.Truncate(workingNum % 7);
                days = workingNum;
                //Printing results
                Console.WriteLine(years + " year(s)");
                Console.WriteLine(months + " month(s)");
                Console.WriteLine(weeks + " week(s)");
                Console.WriteLine(days + " day(s)");
                Console.WriteLine(hours + " hour(s)");
                Console.WriteLine(minutes + " minute(s)");
                Console.WriteLine(seconds + " second(s)");
            }
        }
    }
}
//This may not be pretty but it's mine