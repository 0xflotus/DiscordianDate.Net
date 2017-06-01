using System;
using System.Collections.Generic;

namespace DiscordianDate
{

	public class DiscordianDate
	{
		private readonly int Year, Season, YearDay, SeasonDay, WeekDay;
		private static bool isLeap;
		private static String noHoliday = "No Holiday";
		private static readonly String[] SeasonNames = { "Chaos", "Discord", "Confusion", "Bureaucracy", "The Aftermath" };
		private static readonly String[] DayNames = { "Sweetmorn", "Boomtime", "Pungenday", "Prickle-Prickle", "Setting Orange" };
		private static readonly String[] Holidays = { "Mungday", "Chaoflux", "St. Tib's Day", "Mojoday", "Discoflux", "Syaday",
			"Confuflux", "Zaraday", "Bureflux", "Maladay", "Afflux" };
		private static DateTime LocalDate;

		private DiscordianDate(DateTime dt)
		{
			Year = dt.Year + 1166;
			YearDay = dt.DayOfYear;
			isLeap = DateTime.IsLeapYear(dt.Year);
			int yd = YearDay - 1;
			if (isLeap && yd > 59)
				yd--;
			Season = (yd / 73) + 1;
			WeekDay = (yd % 5) + 1;
			SeasonDay = (yd % 73) + 1;
		}

		public static String WhichHoliday(DiscordianDate ddate)
		{
			switch (ddate.YearDay)
			{
				case 5:
					return Holidays[0];
				case 50:
					return Holidays[1];
				case 60:
					return isLeap ? Holidays[2] : noHoliday;
				case 78:
					return !isLeap ? Holidays[3] : noHoliday;
				case 79:
					return isLeap ? Holidays[3] : noHoliday;
				case 123:
					return !isLeap ? Holidays[4] : noHoliday;
				case 124:
					return isLeap ? Holidays[4] : noHoliday;
				case 151:
					return !isLeap ? Holidays[5] : noHoliday;
				case 152:
					return isLeap ? Holidays[5] : noHoliday;
				case 196:
					return !isLeap ? Holidays[6] : noHoliday;
				case 197:
					return isLeap ? Holidays[6] : noHoliday;
				case 224:
					return !isLeap ? Holidays[7] : noHoliday;
				case 225:
					return isLeap ? Holidays[7] : noHoliday;
				case 269:
					return !isLeap ? Holidays[8] : noHoliday;
				case 270:
					return isLeap ? Holidays[8] : noHoliday;
				case 297:
					return !isLeap ? Holidays[9] : noHoliday;
				case 298:
					return isLeap ? Holidays[9] : noHoliday;
				case 342:
					return !isLeap ? Holidays[10] : noHoliday;
				case 343:
					return isLeap ? Holidays[10] : noHoliday;
				default:
					return noHoliday;
			}
		}

		public static bool IsHoliday(DiscordianDate ddate) => DiscordianDate.WhichHoliday(ddate) != noHoliday;

		public bool IsHoliday() => DiscordianDate.IsHoliday(this);

		public DiscordianDate AddDays(int days)
		{
			LocalDate = DateTime.Now.AddDays(days);
			return new DiscordianDate(LocalDate);
		}

		public DiscordianDate AddWeeks(int weeks)
		{
			LocalDate = DateTime.Now.AddDays(7 * weeks);
			return new DiscordianDate(LocalDate);
		}

		public DiscordianDate AddMonths(int months)
		{
			LocalDate = DateTime.Now.AddMonths(months);
			return new DiscordianDate(LocalDate);
		}

		public DiscordianDate AddYears(int years)
		{
			LocalDate = DateTime.Now.AddYears(years);
			return new DiscordianDate(LocalDate);
		}

		public static DiscordianDate Now()
		{
			LocalDate = DateTime.Now;
			return new DiscordianDate(LocalDate);
		}

		public static DiscordianDate Of(DateTime dt)
		{
			LocalDate = dt;
			return new DiscordianDate(LocalDate);
		}

		public static DiscordianDate Of(int dayOfMonth)
		{
			LocalDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, dayOfMonth);
			return new DiscordianDate(LocalDate);
		}

		public static DiscordianDate Of(int month, int dayOfMonth)
		{
			LocalDate = new DateTime(DateTime.Now.Year, month, dayOfMonth);
			return new DiscordianDate(LocalDate);
		}

		public static DiscordianDate Of(int year, int month, int dayOfMonth)
		{
			LocalDate = new DateTime(year, month, dayOfMonth);
			return new DiscordianDate(LocalDate);
		}

		public String GetSeasonName() => SeasonNames[Season - 1];

		public String GetDayName() => DayNames[WeekDay - 1];

		public static List<String> GetHolidays() => new List<string>(Holidays);

		public static List<String> GetPossibleDayNames() => new List<string>(DayNames);

		public static List<String> GetPossibleSeasonNames() => new List<string>(SeasonNames);

		public override String ToString() => isLeap && YearDay == 59 ? Holidays[2] + ", " + Year.ToString()
			: DayNames[WeekDay - 1] + ", " + SeasonNames[Season - 1] + " " + SeasonDay.ToString() + ", " + Year.ToString();
	}
}
