using System;
using System.Globalization;

/// Author: Kamal Patel
/// Email: kppatel@yahoo.com
/// Copyright: None (Public Domain)
namespace VFPToolkit
{
	/// <summary>
	/// <b>Visual FoxPro Date/Time Functions</b><br/>
	/// This class contains all the functions that allow us to work with dates, time, datetime, character dates etc. 
	/// Class contains methods that return Date(), DateTime(), Time(), Day(), Month(), Year(), CDOW(), Quarter(),
	/// Sec(), CMonth() etc. It also contains functions such as MDY(), DMY() and GoMonth()
	/// </summary>
	public class dates
	{

		/// <summary>
		/// Receives a date in string format as a parameter and converts it to a DateTime format
		/// <pre>
		/// Example:
		/// string lcDate = "4/12/01";
		/// DateTime MyDate = VFPToolkit.dates.CTOT(lcDate);	//converts the string to a DateTime value
		/// </pre>
		/// </summary>
		/// <returns></returns>
		public static System.DateTime CTOT(string cDateTime)
		{
			return System.DateTime.Parse(cDateTime);
		}

		/// <summary>
		/// Receives a date in string format as a parameter and returns the current day of week as a string
		/// <pre>
		/// Example:
		/// DateTime tDateTime = DateTime.Now;
		/// string lcCurrentDay = VFPToolkit.dates.CDOW(tDateTime);	//returns "Wednesday"
		/// </pre>
		/// </summary>
		/// <param name="dDate"></param>
		/// <returns></returns>
		public static string CDOW(System.DateTime dDate)
		{
			return dDate.DayOfWeek.ToString();
		}

		/// <summary>
		/// Receives a DateTime as a parameter and returns the current month formatted as a string
		/// <pre>
		/// Example:
		/// DateTime tDateTime = DateTime.Now;
		/// string lcDate = VFPToolkit.dates.CMonth(tDateTime);	//returns "May"
		/// </pre>
		/// </summary>
		/// <param name="dDate"></param>
		/// <returns></returns>
		public static string CMonth(System.DateTime dDate)
		{
			return dDate.ToString("MMMM");
		}

		/// <summary>
		/// Receives a date in string format as a parameter and converts it to a DateTime format
		/// <pre>
		/// Example:
		/// string lcDate = "4/12/01";
		/// DateTime MyDate = VFPToolkit.dates.CTOT(lcDate);	//converts the string to a DateTime value
		/// </pre>
		/// </summary>
		/// <param name="cDate"></param>
		/// <returns></returns>
		public static System.DateTime CTOD(string tcDate)
		{
			return System.DateTime.Parse(tcDate);
		}

		/// <summary>
		/// Returns the current Date in System.DateTime format. (Use System.DateTime.Today instead)
		/// </summary>
		/// <returns></returns>
		public static System.DateTime Date()
		{
			return System.DateTime.Today;
		}

		/// <summary>
		/// Returns the current DateTime in System.DateTime format. (Use System.DateTime.Now instead)
		/// </summary>
		/// <returns></returns>
		public static System.DateTime DateTime()
		{
			return System.DateTime.Now;
		}
		
		/// <summary>
		/// Returns the current Day from a DateTime (Use MyDate.Day instead)
		/// </summary>
		/// <returns></returns>
		public static int Day(System.DateTime dDate)
		{
			return dDate.Day;
		}


		/// <summary>
		/// Receives a DateTime as a parameter and returns a string formatted as a DMY
		/// <pre>
		/// Example:
		/// DateTime tDateTime = DateTime.Now;
		/// string cDate = VFPToolkit.dates.CMonth(tDateTime);	//returns "09 May 01"
		/// </pre>
		/// </summary>
		/// <param name="dDate"></param>
		/// <returns></returns>
		public static string DMY(System.DateTime dDate)
		{
			return dDate.ToString("dd MMM yy");
		}

		/// <summary>
		/// Receives a Date as a parameter and returns a string of that date. (Use MyDate.ToShortDateString() instead)
		/// </summary>
		/// <param name="dDate"></param>
		/// <returns></returns>
		public static string DTOC(System.DateTime dDate)
		{
			return dDate.ToShortDateString();
		}

		/// <summary>
		/// Receives a DateTime as a parameter and returns a DTOS formatted string
		/// </summary>
		/// <example>
		/// Example:
		/// DateTime tDateTime = DateTime.Now;
		/// string cDate = VFPToolkit.dates.DTOS(tDateTime);	//returns "20010509"
		/// </example>
		/// <param name="dDate"></param>
		/// <returns></returns>
		public static string DTOS(System.DateTime dDate)
		{
			return dDate.ToString("yyyyMMdd");
		}

		/// <summary>
		/// This is simply a placeholder. VFP had Date and DateTime as separate datatypes. Now there
		/// is no difference here as there is only a single datatype; DateTime.
		/// </summary>
		/// <returns></returns>
		public static System.DateTime DTOT(System.DateTime tDateTime)
		{
			//The date is the same as the datetime. Return the same value back :)
			return tDateTime;
		}

		/// <summary>
		/// Receives a date as a parameter and returns an integer specifying the day of the week for that date
		/// <pre>
		/// Example:
		/// DateTime tDateTime = DateTime.Now;
		/// int nDow = VFPToolkit.dates.DOW(tDateTime);
		/// </pre>
		/// </summary>
		/// <param name="dDate"></param>
		/// <returns></returns>
		public static int DOW(System.DateTime dDate)
		{
			return (int)dDate.DayOfWeek;
		}


		/// <summary>
		/// Receives a date and number of months as parameters and adds that many months to the date and returns the new date.
		/// <pre>
		/// Example:
		/// DateTime myNewDate;
		/// myNewDate = VFPToolkit.dates.GoMonth(DateTime.Now, 2);		//returns a date after adding 2 months
		/// </pre>
		/// </summary>
		/// <returns></returns>
		public static System.DateTime GoMonth(System.DateTime dDate, int nMonths)
		{
			return dDate.AddMonths(nMonths);	
		}

		/// <summary>
		/// Returns the current Hour from a DateTime (Use MyDate.Hour instead)
		/// </summary>
		/// <returns></returns>
		public static int Hour(System.DateTime dDate)
		{
			return dDate.Hour ;
		}

		/// <summary>
		/// Receives a DateTime as a parameter and returns a formatted string in MDY format
		/// <pre>
		/// Example:
		/// DateTime tDateTime = DateTime.Now;
		/// string cDate = VFPToolkit.dates.MDY(tDateTime);	//returns "May 09 2001"
		/// </pre>
		/// </summary>
		/// <param name="dDate"></param>
		/// <returns></returns>
		public static string MDY(System.DateTime dDate)
		{
			return dDate.ToString("MMMM dd yyyy");
		}

		/// <summary>
		/// Returns the current Minute from a DateTime (Use MyDate.Minute instead)
		/// </summary>
		/// <returns></returns>
		public static int Minute(System.DateTime dDate)
		{
			return dDate.Minute ;
		}

		/// <summary>
		/// Returns the current Month from a DateTime (Use MyDate.Month instead)
		/// </summary>
		/// <returns></returns>
		public static int Month(System.DateTime dDate)
		{
			return dDate.Month;
		}

		/// <summary>
		/// Receives a date time as a parameter and returns an integer with the quarter the date
		/// falls in
		/// <pre>
		/// Example:
		/// int nCurrentQuarter = VFPToolkit.dates.Quarter(DateTime.Now);		//returns 2
		/// </pre>
		/// </summary>
		/// <param name="dDate"></param>
		/// <returns></returns>
		public static int Quarter(System.DateTime dDate)
		{
			//Get the current month
			int i = dDate.Month;

			//Based on the current month return the quarter
			if (i <= 3)
			{ return 1; }
			else if (i >= 4 && i <= 6)
			{ return 2; }
			else if (i >=7 && i<= 9)
			{ return 3; }
			else if (i >=10 && i <= 12)
			{ return 4; }
			else
				//Something probably is wrong 
				return 0;
		}

		/// <summary>
		/// Returns the current second from a DateTime (Use MyDate.Second instead)
		/// </summary>
		/// <returns></returns>
		public static int Sec(System.DateTime dDate)
		{
			return dDate.Second ;
		}

		/// <summary>
		/// Returns the number of seconds since midnight
		/// <example>
		/// Example:
		/// double nTotalSeconds = VFPToolkit.dates.Seconds();
		/// </example>
		/// </summary>
		/// <returns></returns>
		public static double Seconds()
		{
			//Create the timespan object get the time between the dates
			System.TimeSpan st  = System.DateTime.Now.Subtract(System.DateTime.Today);

			//Return the number of seconds
			return st.Duration().TotalMilliseconds/1000;
		}

		/// <summary>
		/// Returns the current time in string format from a DateTime.
		/// <pre>
		/// Example:
		/// string MyTime = VFPToolkit.dates.Time();	//returns "2:33 AM"
		/// </pre>
		/// </summary>
		/// <returns></returns>
		public static string Time()
		{
			return System.DateTime.Now.ToShortTimeString();
		}

		/// <summary>
		/// Receives a Date as a parameter and returns a string of that date and time. 
		/// (Use MyDate.ToShortDateString() and MyDate.ToShortTimeString() instead)
		/// </summary>
		/// <param name="dDate"></param>
		/// <returns></returns>
		public static string TTOC(System.DateTime dDate)
		{
			return String.Concat(dDate.ToShortDateString(), " ", dDate.ToShortTimeString()) ;
		}

		/// <summary>
		/// Converts a DateTime expression to a short date string
		/// <pre>
		/// Example:
		/// DateTime tDateTime = DateTime.Now;
		/// string cDate = VFPToolkit.dates.TTOD(tDateTime);
		/// </pre>
		/// </summary>
		/// <param name="tDateTime"></param>
		/// <returns></returns>
		public static string TTOD(System.DateTime tDateTime)
		{
			//Call tDateTime.ToShortDateString() which is a string to get this value
			return tDateTime.ToShortDateString();
		}

		/// <summary>
		/// Returns the current Year from a DateTime (Use MyDate.Year instead)
		/// </summary>
		/// <returns></returns>
		public static int Year(System.DateTime dDate)
		{
			return dDate.Year;
		}


		/// <summary>
		/// Receives a DateTime as a parameter and returns the week of the year
		/// </summary>
		/// <example>
		/// int nCurrentWeek = VFPToolkit.dates.Week(DateTime.Now);
		/// </example>
		/// <param name="tdDate"></param>
		public static int Week(System.DateTime tdDate)
		{
			DateTimeFormatInfo d = new DateTimeFormatInfo();

			//Receives the DateTime, Rule to start first day and first starting day (Mon, tue etc)
			return d.Calendar.GetWeekOfYear(System.DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
		}


		///<summary>
		///</summary>
		//End of Dates class
	} 
}
