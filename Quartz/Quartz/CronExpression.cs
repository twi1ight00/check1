using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Quartz.Collection;
using Quartz.Util;

namespace Quartz;

/// <summary>
/// Provides a parser and evaluator for unix-like cron expressions. Cron 
/// expressions provide the ability to specify complex time combinations such as
/// "At 8:00am every Monday through Friday" or "At 1:30am every 
/// last Friday of the month". 
/// </summary>
/// <remarks>
/// <para>
/// Cron expressions are comprised of 6 required fields and one optional field
/// separated by white space. The fields respectively are described as follows:
/// </para>
/// <table cellspacing="8">
/// <tr>
/// <th align="left">Field Name</th>
/// <th align="left"> </th>
/// <th align="left">Allowed Values</th>
/// <th align="left"> </th>
/// <th align="left">Allowed Special Characters</th>
/// </tr>
/// <tr>
/// <td align="left">Seconds</td>
/// <td align="left"> </td>
/// <td align="left">0-59</td>
/// <td align="left"> </td>
/// <td align="left">, - /// /</td>
/// </tr>
/// <tr>
/// <td align="left">Minutes</td>
/// <td align="left"> </td>
/// <td align="left">0-59</td>
/// <td align="left"> </td>
/// <td align="left">, - /// /</td>
/// </tr>
/// <tr>
/// <td align="left">Hours</td>
/// <td align="left"> </td>
/// <td align="left">0-23</td>
/// <td align="left"> </td>
/// <td align="left">, - /// /</td>
/// </tr>
/// <tr>
/// <td align="left">Day-of-month</td>
/// <td align="left"> </td>
/// <td align="left">1-31</td>
/// <td align="left"> </td>
/// <td align="left">, - /// ? / L W C</td>
/// </tr>
/// <tr>
/// <td align="left">Month</td>
/// <td align="left"> </td>
/// <td align="left">1-12 or JAN-DEC</td>
/// <td align="left"> </td>
/// <td align="left">, - /// /</td>
/// </tr>
/// <tr>
/// <td align="left">Day-of-Week</td>
/// <td align="left"> </td>
/// <td align="left">1-7 or SUN-SAT</td>
/// <td align="left"> </td>
/// <td align="left">, - /// ? / L #</td>
/// </tr>
/// <tr>
/// <td align="left">Year (Optional)</td>
/// <td align="left"> </td>
/// <td align="left">empty, 1970-2199</td>
/// <td align="left"> </td>
/// <td align="left">, - /// /</td>
/// </tr>
/// </table>
/// <para>
/// The '*' character is used to specify all values. For example, "*" 
/// in the minute field means "every minute".
/// </para>
/// <para>
/// The '?' character is allowed for the day-of-month and day-of-week fields. It
/// is used to specify 'no specific value'. This is useful when you need to
/// specify something in one of the two fields, but not the other.
/// </para>
/// <para>
/// The '-' character is used to specify ranges For example "10-12" in
/// the hour field means "the hours 10, 11 and 12".
/// </para>
/// <para>
/// The ',' character is used to specify additional values. For example
/// "MON,WED,FRI" in the day-of-week field means "the days Monday,
/// Wednesday, and Friday".
/// </para>
/// <para>
/// The '/' character is used to specify increments. For example "0/15"
/// in the seconds field means "the seconds 0, 15, 30, and 45". And 
/// "5/15" in the seconds field means "the seconds 5, 20, 35, and
/// 50".  Specifying '*' before the  '/' is equivalent to specifying 0 is
/// the value to start with. Essentially, for each field in the expression, there
/// is a set of numbers that can be turned on or off. For seconds and minutes, 
/// the numbers range from 0 to 59. For hours 0 to 23, for days of the month 0 to
/// 31, and for months 1 to 12. The "/" character simply helps you turn
/// on every "nth" value in the given set. Thus "7/6" in the
/// month field only turns on month "7", it does NOT mean every 6th 
/// month, please note that subtlety.  
/// </para>
/// <para>
/// The 'L' character is allowed for the day-of-month and day-of-week fields.
/// This character is short-hand for "last", but it has different 
/// meaning in each of the two fields. For example, the value "L" in 
/// the day-of-month field means "the last day of the month" - day 31 
/// for January, day 28 for February on non-leap years. If used in the 
/// day-of-week field by itself, it simply means "7" or 
/// "SAT". But if used in the day-of-week field after another value, it
/// means "the last xxx day of the month" - for example "6L"
/// means "the last friday of the month". You can also specify an offset 
/// from the last day of the month, such as "L-3" which would mean the third-to-last 
/// day of the calendar month. <i>When using the 'L' option, it is important not to 
/// specify lists, or ranges of values, as you'll get confusing/unexpected results.</i>
/// </para>
/// <para>
/// The 'W' character is allowed for the day-of-month field.  This character 
/// is used to specify the weekday (Monday-Friday) nearest the given day.  As an 
/// example, if you were to specify "15W" as the value for the 
/// day-of-month field, the meaning is: "the nearest weekday to the 15th of
/// the month". So if the 15th is a Saturday, the trigger will fire on 
/// Friday the 14th. If the 15th is a Sunday, the trigger will fire on Monday the
/// 16th. If the 15th is a Tuesday, then it will fire on Tuesday the 15th. 
/// However if you specify "1W" as the value for day-of-month, and the
/// 1st is a Saturday, the trigger will fire on Monday the 3rd, as it will not 
/// 'jump' over the boundary of a month's days.  The 'W' character can only be 
/// specified when the day-of-month is a single day, not a range or list of days.
/// </para>
/// <para>
/// The 'L' and 'W' characters can also be combined for the day-of-month 
/// expression to yield 'LW', which translates to "last weekday of the 
/// month".
/// </para>
/// <para>
/// The '#' character is allowed for the day-of-week field. This character is
/// used to specify "the nth" XXX day of the month. For example, the 
/// value of "6#3" in the day-of-week field means the third Friday of 
/// the month (day 6 = Friday and "#3" = the 3rd one in the month). 
/// Other examples: "2#1" = the first Monday of the month and 
/// "4#5" = the fifth Wednesday of the month. Note that if you specify
/// "#5" and there is not 5 of the given day-of-week in the month, then
/// no firing will occur that month. If the '#' character is used, there can
/// only be one expression in the day-of-week field ("3#1,6#3" is 
/// not valid, since there are two expressions).
/// </para>
/// <para>
/// <!--The 'C' character is allowed for the day-of-month and day-of-week fields.
/// This character is short-hand for "calendar". This means values are
/// calculated against the associated calendar, if any. If no calendar is
/// associated, then it is equivalent to having an all-inclusive calendar. A
/// value of "5C" in the day-of-month field means "the first day included by the
/// calendar on or after the 5th". A value of "1C" in the day-of-week field
/// means "the first day included by the calendar on or after Sunday". -->
/// </para>
/// <para>
/// The legal characters and the names of months and days of the week are not
/// case sensitive.
/// </para>
/// <para>
/// <b>NOTES:</b>
/// <ul>
/// <li>Support for specifying both a day-of-week and a day-of-month value is
/// not complete (you'll need to use the '?' character in one of these fields).
/// </li>
/// <li>Overflowing ranges is supported - that is, having a larger number on 
/// the left hand side than the right. You might do 22-2 to catch 10 o'clock 
/// at night until 2 o'clock in the morning, or you might have NOV-FEB. It is 
/// very important to note that overuse of overflowing ranges creates ranges 
/// that don't make sense and no effort has been made to determine which 
/// interpretation CronExpression chooses. An example would be 
/// "0 0 14-6 ? * FRI-MON". </li>
/// </ul>
/// </para>
/// </remarks>
/// <author>Sharada Jambula</author>
/// <author>James House</author>
/// <author>Contributions from Mads Henderson</author>
/// <author>Refactoring from CronTrigger to CronExpression by Aaron Craven</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class CronExpression : ICloneable, IDeserializationCallback
{
	/// <summary>
	/// Field specification for second.
	/// </summary>
	protected const int Second = 0;

	/// <summary>
	/// Field specification for minute.
	/// </summary>
	protected const int Minute = 1;

	/// <summary>
	/// Field specification for hour.
	/// </summary>
	protected const int Hour = 2;

	/// <summary>
	/// Field specification for day of month.
	/// </summary>
	protected const int DayOfMonth = 3;

	/// <summary>
	/// Field specification for month.
	/// </summary>
	protected const int Month = 4;

	/// <summary>
	/// Field specification for day of week.
	/// </summary>
	protected const int DayOfWeek = 5;

	/// <summary>
	/// Field specification for year.
	/// </summary>
	protected const int Year = 6;

	/// <summary>
	/// Field specification for all wildcard value '*'.
	/// </summary>
	protected const int AllSpecInt = 99;

	/// <summary>
	/// Field specification for not specified value '?'.
	/// </summary>
	protected const int NoSpecInt = 98;

	/// <summary>
	/// Field specification for wildcard '*'.
	/// </summary>
	protected const int AllSpec = 99;

	/// <summary>
	/// Field specification for no specification at all '?'.
	/// </summary>
	protected const int NoSpec = 98;

	private static readonly Dictionary<string, int> monthMap;

	private static readonly Dictionary<string, int> dayMap;

	private readonly string cronExpressionString;

	private TimeZoneInfo timeZone;

	/// <summary>
	/// Seconds.
	/// </summary>
	[NonSerialized]
	protected TreeSet<int> seconds;

	/// <summary>
	/// minutes.
	/// </summary>
	[NonSerialized]
	protected TreeSet<int> minutes;

	/// <summary>
	/// Hours.
	/// </summary>
	[NonSerialized]
	protected TreeSet<int> hours;

	/// <summary>
	/// Days of month.
	/// </summary>
	[NonSerialized]
	protected TreeSet<int> daysOfMonth;

	/// <summary>
	/// Months.
	/// </summary>
	[NonSerialized]
	protected TreeSet<int> months;

	/// <summary>
	/// Days of week.
	/// </summary>
	[NonSerialized]
	protected TreeSet<int> daysOfWeek;

	/// <summary>
	/// Years.
	/// </summary>
	[NonSerialized]
	protected TreeSet<int> years;

	/// <summary>
	/// Last day of week.
	/// </summary>
	[NonSerialized]
	protected bool lastdayOfWeek;

	/// <summary>
	/// Nth day of week.
	/// </summary>
	[NonSerialized]
	protected int nthdayOfWeek;

	/// <summary>
	/// Last day of month.
	/// </summary>
	[NonSerialized]
	protected bool lastdayOfMonth;

	/// <summary>
	/// Nearest weekday.
	/// </summary>
	[NonSerialized]
	protected bool nearestWeekday;

	[NonSerialized]
	protected int lastdayOffset;

	/// <summary>
	/// Calendar day of week.
	/// </summary>
	[NonSerialized]
	protected bool calendardayOfWeek;

	/// <summary>
	/// Calendar day of month.
	/// </summary>
	[NonSerialized]
	protected bool calendardayOfMonth;

	/// <summary>
	/// Expression parsed.
	/// </summary>
	[NonSerialized]
	protected bool expressionParsed;

	public static readonly int MaxYear;

	/// <summary>
	/// Sets or gets the time zone for which the <see cref="T:Quartz.CronExpression" /> of this
	/// <see cref="T:Quartz.ICronTrigger" /> will be resolved.
	/// </summary>
	public virtual TimeZoneInfo TimeZone
	{
		get
		{
			if (timeZone == null)
			{
				timeZone = TimeZoneInfo.Local;
			}
			return timeZone;
		}
		set
		{
			timeZone = value;
		}
	}

	/// <summary>
	/// Gets the cron expression string.
	/// </summary>
	/// <value>The cron expression string.</value>
	public string CronExpressionString => cronExpressionString;

	static CronExpression()
	{
		monthMap = new Dictionary<string, int>(20);
		dayMap = new Dictionary<string, int>(60);
		MaxYear = DateTime.Now.Year + 100;
		monthMap.Add("JAN", 0);
		monthMap.Add("FEB", 1);
		monthMap.Add("MAR", 2);
		monthMap.Add("APR", 3);
		monthMap.Add("MAY", 4);
		monthMap.Add("JUN", 5);
		monthMap.Add("JUL", 6);
		monthMap.Add("AUG", 7);
		monthMap.Add("SEP", 8);
		monthMap.Add("OCT", 9);
		monthMap.Add("NOV", 10);
		monthMap.Add("DEC", 11);
		dayMap.Add("SUN", 1);
		dayMap.Add("MON", 2);
		dayMap.Add("TUE", 3);
		dayMap.Add("WED", 4);
		dayMap.Add("THU", 5);
		dayMap.Add("FRI", 6);
		dayMap.Add("SAT", 7);
	}

	/// <summary>
	///  Constructs a new <see cref="P:Quartz.CronExpression.CronExpressionString" /> based on the specified 
	///  parameter.
	///  </summary>
	///  <param name="cronExpression">
	///  String representation of the cron expression the new object should represent
	///  </param>
	///  <see cref="P:Quartz.CronExpression.CronExpressionString" />
	public CronExpression(string cronExpression)
	{
		if (cronExpression == null)
		{
			throw new ArgumentException("cronExpression cannot be null");
		}
		cronExpressionString = cronExpression.ToUpper(CultureInfo.InvariantCulture);
		BuildExpression(cronExpression);
	}

	/// <summary>
	/// Indicates whether the given date satisfies the cron expression. 
	/// </summary>
	/// <remarks>
	/// Note that  milliseconds are ignored, so two Dates falling on different milliseconds
	/// of the same second will always have the same result here.
	/// </remarks>
	/// <param name="dateUtc">The date to evaluate.</param>
	/// <returns>a boolean indicating whether the given date satisfies the cron expression</returns>
	public virtual bool IsSatisfiedBy(DateTimeOffset dateUtc)
	{
		DateTimeOffset test = new DateTimeOffset(dateUtc.Year, dateUtc.Month, dateUtc.Day, dateUtc.Hour, dateUtc.Minute, dateUtc.Second, dateUtc.Offset).AddSeconds(-1.0);
		DateTimeOffset? timeAfter = GetTimeAfter(test);
		if (timeAfter.HasValue && timeAfter.Value.Equals(dateUtc))
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// Returns the next date/time <i>after</i> the given date/time which
	/// satisfies the cron expression.
	/// </summary>
	/// <param name="date">the date/time at which to begin the search for the next valid date/time</param>
	/// <returns>the next valid date/time</returns>
	public virtual DateTimeOffset? GetNextValidTimeAfter(DateTimeOffset date)
	{
		return GetTimeAfter(date);
	}

	/// <summary>
	/// Returns the next date/time <i>after</i> the given date/time which does
	/// <i>not</i> satisfy the expression.
	/// </summary>
	/// <param name="date">the date/time at which to begin the search for the next invalid date/time</param>
	/// <returns>the next valid date/time</returns>
	public virtual DateTimeOffset? GetNextInvalidTimeAfter(DateTimeOffset date)
	{
		long difference = 1000L;
		DateTimeOffset lastDate = new DateTimeOffset(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Offset).AddSeconds(-1.0);
		while (difference == 1000)
		{
			DateTimeOffset? newDate = GetTimeAfter(lastDate);
			if (!newDate.HasValue)
			{
				break;
			}
			difference = (long)(newDate.Value - lastDate).TotalMilliseconds;
			if (difference == 1000)
			{
				lastDate = newDate.Value;
			}
		}
		return lastDate.AddSeconds(1.0);
	}

	/// <summary>
	/// Returns the string representation of the <see cref="T:Quartz.CronExpression" />
	/// </summary>
	/// <returns>The string representation of the <see cref="T:Quartz.CronExpression" /></returns>
	public override string ToString()
	{
		return cronExpressionString;
	}

	/// <summary>
	/// Indicates whether the specified cron expression can be parsed into a 
	/// valid cron expression
	/// </summary>
	/// <param name="cronExpression">the expression to evaluate</param>
	/// <returns>a boolean indicating whether the given expression is a valid cron
	///         expression</returns>
	public static bool IsValidExpression(string cronExpression)
	{
		try
		{
			new CronExpression(cronExpression);
		}
		catch (FormatException)
		{
			return false;
		}
		return true;
	}

	public static void ValidateExpression(string cronExpression)
	{
		new CronExpression(cronExpression);
	}

	/// <summary>
	/// Builds the expression.
	/// </summary>
	/// <param name="expression">The expression.</param>
	protected void BuildExpression(string expression)
	{
		expressionParsed = true;
		try
		{
			if (seconds == null)
			{
				seconds = new TreeSet<int>();
			}
			if (minutes == null)
			{
				minutes = new TreeSet<int>();
			}
			if (hours == null)
			{
				hours = new TreeSet<int>();
			}
			if (daysOfMonth == null)
			{
				daysOfMonth = new TreeSet<int>();
			}
			if (months == null)
			{
				months = new TreeSet<int>();
			}
			if (daysOfWeek == null)
			{
				daysOfWeek = new TreeSet<int>();
			}
			if (years == null)
			{
				years = new TreeSet<int>();
			}
			int exprOn = 0;
			string[] exprsTok = expression.Trim().Split(new char[4] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
			string[] array = exprsTok;
			foreach (string exprTok in array)
			{
				string expr = exprTok.Trim();
				if (expr.Length != 0)
				{
					if (exprOn > 6)
					{
						break;
					}
					if (exprOn == 3 && expr.IndexOf('L') != -1 && expr.Length > 1 && expr.IndexOf(",") >= 0)
					{
						throw new FormatException("Support for specifying 'L' and 'LW' with other days of the month is not implemented");
					}
					if (exprOn == 5 && expr.IndexOf('L') != -1 && expr.Length > 1 && expr.IndexOf(",") >= 0)
					{
						throw new FormatException("Support for specifying 'L' with other days of the week is not implemented");
					}
					if (exprOn == 5 && expr.IndexOf('#') != -1 && expr.IndexOf('#', expr.IndexOf('#') + 1) != -1)
					{
						throw new FormatException("Support for specifying multiple \"nth\" days is not imlemented.");
					}
					string[] vTok = expr.Split(',');
					string[] array2 = vTok;
					foreach (string v in array2)
					{
						StoreExpressionVals(0, v, exprOn);
					}
					exprOn++;
				}
			}
			if (exprOn <= 5)
			{
				throw new FormatException("Unexpected end of expression.");
			}
			if (exprOn <= 6)
			{
				StoreExpressionVals(0, "*", 6);
			}
			ISortedSet<int> dow = GetSet(5);
			ISortedSet<int> dom = GetSet(3);
			bool dayOfMSpec = !dom.Contains(98);
			bool dayOfWSpec = !dow.Contains(98);
			if ((!dayOfMSpec || dayOfWSpec) && (!dayOfWSpec || dayOfMSpec))
			{
				throw new FormatException("Support for specifying both a day-of-week AND a day-of-month parameter is not implemented.");
			}
		}
		catch (FormatException)
		{
			throw;
		}
		catch (Exception e)
		{
			throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Illegal cron expression format ({0})", new object[1] { e }));
		}
	}

	/// <summary>
	/// Stores the expression values.
	/// </summary>
	/// <param name="pos">The position.</param>
	/// <param name="s">The string to traverse.</param>
	/// <param name="type">The type of value.</param>
	/// <returns></returns>
	protected virtual int StoreExpressionVals(int pos, string s, int type)
	{
		int incr = 0;
		int i = SkipWhiteSpace(pos, s);
		if (i >= s.Length)
		{
			return i;
		}
		char c = s[i];
		if (c >= 'A' && c <= 'Z' && !s.Equals("L") && !s.Equals("LW") && !Regex.IsMatch(s, "^L-[0-9]*[W]?"))
		{
			string sub = s.Substring(i, 3);
			int eval = -1;
			int sval;
			switch (type)
			{
			case 4:
				sval = GetMonthNumber(sub) + 1;
				if (sval <= 0)
				{
					throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Invalid Month value: '{0}'", new object[1] { sub }));
				}
				if (s.Length <= i + 3)
				{
					break;
				}
				c = s[i + 3];
				if (c == '-')
				{
					i += 4;
					sub = s.Substring(i, 3);
					eval = GetMonthNumber(sub) + 1;
					if (eval <= 0)
					{
						throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Invalid Month value: '{0}'", new object[1] { sub }));
					}
				}
				break;
			case 5:
				sval = GetDayOfWeekNumber(sub);
				if (sval < 0)
				{
					throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Invalid Day-of-Week value: '{0}'", new object[1] { sub }));
				}
				if (s.Length <= i + 3)
				{
					break;
				}
				switch (s[i + 3])
				{
				case '-':
					i += 4;
					sub = s.Substring(i, 3);
					eval = GetDayOfWeekNumber(sub);
					if (eval < 0)
					{
						throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Invalid Day-of-Week value: '{0}'", new object[1] { sub }));
					}
					break;
				case '#':
					try
					{
						i += 4;
						nthdayOfWeek = Convert.ToInt32(s.Substring(i), CultureInfo.InvariantCulture);
						if (nthdayOfWeek < 1 || nthdayOfWeek > 5)
						{
							throw new Exception();
						}
					}
					catch (Exception)
					{
						throw new FormatException("A numeric value between 1 and 5 must follow the '#' option");
					}
					break;
				case 'L':
					lastdayOfWeek = true;
					i++;
					break;
				}
				break;
			default:
				throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Illegal characters for this position: '{0}'", new object[1] { sub }));
			}
			if (eval != -1)
			{
				incr = 1;
			}
			AddToSet(sval, eval, incr, type);
			return i + 3;
		}
		switch (c)
		{
		case '?':
			i++;
			if (i + 1 < s.Length && s[i] != ' ' && s[i + 1] != '\t')
			{
				throw new FormatException("Illegal character after '?': " + s[i]);
			}
			if (type != 5 && type != 3)
			{
				throw new FormatException("'?' can only be specified for Day-of-Month or Day-of-Week.");
			}
			if (type == 5 && !lastdayOfMonth)
			{
				int val2 = daysOfMonth[daysOfMonth.Count - 1];
				if (val2 == 98)
				{
					throw new FormatException("'?' can only be specified for Day-of-Month -OR- Day-of-Week.");
				}
			}
			AddToSet(98, -1, 0, type);
			return i;
		case '*':
		case '/':
			if (c == '*' && i + 1 >= s.Length)
			{
				AddToSet(99, -1, incr, type);
				return i + 1;
			}
			if (c == '/' && (i + 1 >= s.Length || s[i + 1] == ' ' || s[i + 1] == '\t'))
			{
				throw new FormatException("'/' must be followed by an integer.");
			}
			if (c == '*')
			{
				i++;
			}
			c = s[i];
			if (c == '/')
			{
				i++;
				if (i >= s.Length)
				{
					throw new FormatException("Unexpected end of string.");
				}
				incr = GetNumericValue(s, i);
				i++;
				if (incr > 10)
				{
					i++;
				}
				if (incr > 59 && (type == 0 || type == 1))
				{
					throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Increment > 60 : {0}", new object[1] { incr }));
				}
				if (incr > 23 && type == 2)
				{
					throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Increment > 24 : {0}", new object[1] { incr }));
				}
				if (incr > 31 && type == 3)
				{
					throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Increment > 31 : {0}", new object[1] { incr }));
				}
				if (incr > 7 && type == 5)
				{
					throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Increment > 7 : {0}", new object[1] { incr }));
				}
				if (incr > 12 && type == 4)
				{
					throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Increment > 12 : {0}", new object[1] { incr }));
				}
			}
			else
			{
				incr = 1;
			}
			AddToSet(99, -1, incr, type);
			return i;
		case 'L':
			i++;
			if (type == 3)
			{
				lastdayOfMonth = true;
			}
			if (type == 5)
			{
				AddToSet(7, 7, 0, type);
			}
			if (type == 3 && s.Length > i)
			{
				c = s[i];
				if (c == '-')
				{
					ValueSet vs2 = GetValue(0, s, i + 1);
					lastdayOffset = vs2.theValue;
					if (lastdayOffset > 30)
					{
						throw new FormatException("Offset from last day must be <= 30");
					}
					i = vs2.pos;
				}
				if (s.Length > i)
				{
					c = s[i];
					if (c == 'W')
					{
						nearestWeekday = true;
						i++;
					}
				}
			}
			return i;
		case '0':
		case '1':
		case '2':
		case '3':
		case '4':
		case '5':
		case '6':
		case '7':
		case '8':
		case '9':
		{
			int val = Convert.ToInt32(c.ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
			i++;
			if (i >= s.Length)
			{
				AddToSet(val, -1, -1, type);
				return i;
			}
			c = s[i];
			if (c >= '0' && c <= '9')
			{
				ValueSet vs = GetValue(val, s, i);
				val = vs.theValue;
				i = vs.pos;
			}
			return CheckNext(i, s, val, type);
		}
		default:
			throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Unexpected character: {0}", new object[1] { c }));
		}
	}

	/// <summary>
	/// Checks the next value.
	/// </summary>
	/// <param name="pos">The position.</param>
	/// <param name="s">The string to check.</param>
	/// <param name="val">The value.</param>
	/// <param name="type">The type to search.</param>
	/// <returns></returns>
	protected virtual int CheckNext(int pos, string s, int val, int type)
	{
		int end = -1;
		int i = pos;
		if (i >= s.Length)
		{
			AddToSet(val, end, -1, type);
			return i;
		}
		switch (s[pos])
		{
		case 'L':
			if (type == 5)
			{
				if (val < 1 || val > 7)
				{
					throw new FormatException("Day-of-Week values must be between 1 and 7");
				}
				lastdayOfWeek = true;
				ISortedSet<int> data3 = GetSet(type);
				data3.Add(val);
				return i + 1;
			}
			throw new FormatException(string.Format(CultureInfo.InvariantCulture, "'L' option is not valid here. (pos={0})", new object[1] { i }));
		case 'W':
			if (type == 3)
			{
				nearestWeekday = true;
				if (val > 31)
				{
					throw new FormatException("The 'W' option does not make sense with values larger than 31 (max number of days in a month)");
				}
				ISortedSet<int> data4 = GetSet(type);
				data4.Add(val);
				return i + 1;
			}
			throw new FormatException(string.Format(CultureInfo.InvariantCulture, "'W' option is not valid here. (pos={0})", new object[1] { i }));
		case '#':
		{
			if (type != 5)
			{
				throw new FormatException(string.Format(CultureInfo.InvariantCulture, "'#' option is not valid here. (pos={0})", new object[1] { i }));
			}
			i++;
			try
			{
				nthdayOfWeek = Convert.ToInt32(s.Substring(i), CultureInfo.InvariantCulture);
				if (nthdayOfWeek < 1 || nthdayOfWeek > 5)
				{
					throw new Exception();
				}
			}
			catch (Exception)
			{
				throw new FormatException("A numeric value between 1 and 5 must follow the '#' option");
			}
			ISortedSet<int> data2 = GetSet(type);
			data2.Add(val);
			return i + 1;
		}
		case 'C':
		{
			switch (type)
			{
			case 5:
				calendardayOfWeek = true;
				break;
			case 3:
				calendardayOfMonth = true;
				break;
			default:
				throw new FormatException(string.Format(CultureInfo.InvariantCulture, "'C' option is not valid here. (pos={0})", new object[1] { i }));
			}
			ISortedSet<int> data = GetSet(type);
			data.Add(val);
			return i + 1;
		}
		case '-':
		{
			i++;
			int v = Convert.ToInt32(s[i].ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
			end = v;
			i++;
			if (i >= s.Length)
			{
				AddToSet(val, end, 1, type);
				return i;
			}
			char c = s[i];
			if (c >= '0' && c <= '9')
			{
				ValueSet vs3 = GetValue(v, s, i);
				int v2 = vs3.theValue;
				end = v2;
				i = vs3.pos;
			}
			if (i < s.Length && (c = s[i]) == '/')
			{
				i++;
				int v4 = Convert.ToInt32(s[i].ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
				i++;
				if (i >= s.Length)
				{
					AddToSet(val, end, v4, type);
					return i;
				}
				c = s[i];
				if (c >= '0' && c <= '9')
				{
					ValueSet vs2 = GetValue(v4, s, i);
					int v6 = vs2.theValue;
					AddToSet(val, end, v6, type);
					return vs2.pos;
				}
				AddToSet(val, end, v4, type);
				return i;
			}
			AddToSet(val, end, 1, type);
			return i;
		}
		case '/':
		{
			i++;
			int v3 = Convert.ToInt32(s[i].ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
			i++;
			if (i >= s.Length)
			{
				AddToSet(val, end, v3, type);
				return i;
			}
			char c = s[i];
			if (c >= '0' && c <= '9')
			{
				ValueSet vs = GetValue(v3, s, i);
				int v5 = vs.theValue;
				AddToSet(val, end, v5, type);
				return vs.pos;
			}
			throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Unexpected character '{0}' after '/'", new object[1] { c }));
		}
		default:
			AddToSet(val, end, 0, type);
			return i + 1;
		}
	}

	/// <summary>
	/// Gets the expression summary.
	/// </summary>
	/// <returns></returns>
	public virtual string GetExpressionSummary()
	{
		StringBuilder buf = new StringBuilder();
		buf.Append("seconds: ");
		buf.Append(GetExpressionSetSummary(seconds));
		buf.Append("\n");
		buf.Append("minutes: ");
		buf.Append(GetExpressionSetSummary(minutes));
		buf.Append("\n");
		buf.Append("hours: ");
		buf.Append(GetExpressionSetSummary(hours));
		buf.Append("\n");
		buf.Append("daysOfMonth: ");
		buf.Append(GetExpressionSetSummary(daysOfMonth));
		buf.Append("\n");
		buf.Append("months: ");
		buf.Append(GetExpressionSetSummary(months));
		buf.Append("\n");
		buf.Append("daysOfWeek: ");
		buf.Append(GetExpressionSetSummary(daysOfWeek));
		buf.Append("\n");
		buf.Append("lastdayOfWeek: ");
		buf.Append(lastdayOfWeek);
		buf.Append("\n");
		buf.Append("nearestWeekday: ");
		buf.Append(nearestWeekday);
		buf.Append("\n");
		buf.Append("NthDayOfWeek: ");
		buf.Append(nthdayOfWeek);
		buf.Append("\n");
		buf.Append("lastdayOfMonth: ");
		buf.Append(lastdayOfMonth);
		buf.Append("\n");
		buf.Append("calendardayOfWeek: ");
		buf.Append(calendardayOfWeek);
		buf.Append("\n");
		buf.Append("calendardayOfMonth: ");
		buf.Append(calendardayOfMonth);
		buf.Append("\n");
		buf.Append("years: ");
		buf.Append(GetExpressionSetSummary(years));
		buf.Append("\n");
		return buf.ToString();
	}

	/// <summary>
	/// Gets the expression set summary.
	/// </summary>
	/// <param name="data">The data.</param>
	/// <returns></returns>
	protected virtual string GetExpressionSetSummary(Quartz.Collection.ISet<int> data)
	{
		if (data.Contains(98))
		{
			return "?";
		}
		if (data.Contains(99))
		{
			return "*";
		}
		StringBuilder buf = new StringBuilder();
		bool first = true;
		foreach (int datum in data)
		{
			string val = datum.ToString(CultureInfo.InvariantCulture);
			if (!first)
			{
				buf.Append(",");
			}
			buf.Append(val);
			first = false;
		}
		return buf.ToString();
	}

	/// <summary>
	/// Skips the white space.
	/// </summary>
	/// <param name="i">The i.</param>
	/// <param name="s">The s.</param>
	/// <returns></returns>
	protected virtual int SkipWhiteSpace(int i, string s)
	{
		while (i < s.Length && (s[i] == ' ' || s[i] == '\t'))
		{
			i++;
		}
		return i;
	}

	/// <summary>
	/// Finds the next white space.
	/// </summary>
	/// <param name="i">The i.</param>
	/// <param name="s">The s.</param>
	/// <returns></returns>
	protected virtual int FindNextWhiteSpace(int i, string s)
	{
		while (i < s.Length && (s[i] != ' ' || s[i] != '\t'))
		{
			i++;
		}
		return i;
	}

	/// <summary>
	/// Adds to set.
	/// </summary>
	/// <param name="val">The val.</param>
	/// <param name="end">The end.</param>
	/// <param name="incr">The incr.</param>
	/// <param name="type">The type.</param>
	protected virtual void AddToSet(int val, int end, int incr, int type)
	{
		ISortedSet<int> data = GetSet(type);
		switch (type)
		{
		case 0:
		case 1:
			if ((val < 0 || val > 59 || end > 59) && val != 99)
			{
				throw new FormatException("Minute and Second values must be between 0 and 59");
			}
			break;
		case 2:
			if ((val < 0 || val > 23 || end > 23) && val != 99)
			{
				throw new FormatException("Hour values must be between 0 and 23");
			}
			break;
		case 3:
			if ((val < 1 || val > 31 || end > 31) && val != 99 && val != 98)
			{
				throw new FormatException("Day of month values must be between 1 and 31");
			}
			break;
		case 4:
			if ((val < 1 || val > 12 || end > 12) && val != 99)
			{
				throw new FormatException("Month values must be between 1 and 12");
			}
			break;
		case 5:
			if ((val == 0 || val > 7 || end > 7) && val != 99 && val != 98)
			{
				throw new FormatException("Day-of-Week values must be between 1 and 7");
			}
			break;
		}
		if (incr == 0 || incr == -1)
		{
			switch (val)
			{
			default:
				data.Add(val);
				return;
			case -1:
				data.Add(98);
				return;
			case 99:
				break;
			}
		}
		int startAt = val;
		int stopAt = end;
		if (val == 99 && incr <= 0)
		{
			incr = 1;
			data.Add(99);
		}
		switch (type)
		{
		case 0:
		case 1:
			if (stopAt == -1)
			{
				stopAt = 59;
			}
			if (startAt == -1 || startAt == 99)
			{
				startAt = 0;
			}
			break;
		case 2:
			if (stopAt == -1)
			{
				stopAt = 23;
			}
			if (startAt == -1 || startAt == 99)
			{
				startAt = 0;
			}
			break;
		case 3:
			if (stopAt == -1)
			{
				stopAt = 31;
			}
			if (startAt == -1 || startAt == 99)
			{
				startAt = 1;
			}
			break;
		case 4:
			if (stopAt == -1)
			{
				stopAt = 12;
			}
			if (startAt == -1 || startAt == 99)
			{
				startAt = 1;
			}
			break;
		case 5:
			if (stopAt == -1)
			{
				stopAt = 7;
			}
			if (startAt == -1 || startAt == 99)
			{
				startAt = 1;
			}
			break;
		case 6:
			if (stopAt == -1)
			{
				stopAt = MaxYear;
			}
			if (startAt == -1 || startAt == 99)
			{
				startAt = 1970;
			}
			break;
		}
		int max = -1;
		if (stopAt < startAt)
		{
			max = type switch
			{
				0 => 60, 
				1 => 60, 
				2 => 24, 
				4 => 12, 
				5 => 7, 
				3 => 31, 
				6 => throw new ArgumentException("Start year must be less than stop year"), 
				_ => throw new ArgumentException("Unexpected type encountered"), 
			};
			stopAt += max;
		}
		for (int i = startAt; i <= stopAt; i += incr)
		{
			if (max == -1)
			{
				data.Add(i);
				continue;
			}
			int i2 = i % max;
			if (i2 == 0 && (type == 4 || type == 5 || type == 3))
			{
				i2 = max;
			}
			data.Add(i2);
		}
	}

	/// <summary>
	/// Gets the set of given type.
	/// </summary>
	/// <param name="type">The type of set to get.</param>
	/// <returns></returns>
	protected virtual ISortedSet<int> GetSet(int type)
	{
		return type switch
		{
			0 => seconds, 
			1 => minutes, 
			2 => hours, 
			3 => daysOfMonth, 
			4 => months, 
			5 => daysOfWeek, 
			6 => years, 
			_ => null, 
		};
	}

	/// <summary>
	/// Gets the value.
	/// </summary>
	/// <param name="v">The v.</param>
	/// <param name="s">The s.</param>
	/// <param name="i">The i.</param>
	/// <returns></returns>
	protected virtual ValueSet GetValue(int v, string s, int i)
	{
		char c = s[i];
		StringBuilder s2 = new StringBuilder(v.ToString(CultureInfo.InvariantCulture));
		while (c >= '0' && c <= '9')
		{
			s2.Append(c);
			i++;
			if (i >= s.Length)
			{
				break;
			}
			c = s[i];
		}
		ValueSet val = new ValueSet();
		if (i < s.Length)
		{
			val.pos = i;
		}
		else
		{
			val.pos = i + 1;
		}
		val.theValue = Convert.ToInt32(s2.ToString(), CultureInfo.InvariantCulture);
		return val;
	}

	/// <summary>
	/// Gets the numeric value from string.
	/// </summary>
	/// <param name="s">The string to parse from.</param>
	/// <param name="i">The i.</param>
	/// <returns></returns>
	protected virtual int GetNumericValue(string s, int i)
	{
		int endOfVal = FindNextWhiteSpace(i, s);
		string val = s.Substring(i, endOfVal - i);
		return Convert.ToInt32(val, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// Gets the month number.
	/// </summary>
	/// <param name="s">The string to map with.</param>
	/// <returns></returns>
	protected virtual int GetMonthNumber(string s)
	{
		if (monthMap.ContainsKey(s))
		{
			return monthMap[s];
		}
		return -1;
	}

	/// <summary>
	/// Gets the day of week number.
	/// </summary>
	/// <param name="s">The s.</param>
	/// <returns></returns>
	protected virtual int GetDayOfWeekNumber(string s)
	{
		if (dayMap.ContainsKey(s))
		{
			return dayMap[s];
		}
		return -1;
	}

	/// <summary>
	/// Gets the time from given time parts.
	/// </summary>
	/// <param name="sc">The seconds.</param>
	/// <param name="mn">The minutes.</param>
	/// <param name="hr">The hours.</param>
	/// <param name="dayofmn">The day of month.</param>
	/// <param name="mon">The month.</param>
	/// <returns></returns>
	protected virtual DateTimeOffset? GetTime(int sc, int mn, int hr, int dayofmn, int mon)
	{
		try
		{
			if (sc == -1)
			{
				sc = 0;
			}
			if (mn == -1)
			{
				mn = 0;
			}
			if (hr == -1)
			{
				hr = 0;
			}
			if (dayofmn == -1)
			{
				dayofmn = 0;
			}
			if (mon == -1)
			{
				mon = 0;
			}
			return new DateTimeOffset(SystemTime.UtcNow().Year, mon, dayofmn, hr, mn, sc, TimeSpan.Zero);
		}
		catch (Exception)
		{
			return null;
		}
	}

	/// <summary>
	/// Gets the next fire time after the given time.
	/// </summary>
	/// <param name="afterTimeUtc">The UTC time to start searching from.</param>
	/// <returns></returns>
	public virtual DateTimeOffset? GetTimeAfter(DateTimeOffset afterTimeUtc)
	{
		afterTimeUtc = afterTimeUtc.AddSeconds(1.0);
		DateTimeOffset d = CreateDateTimeWithoutMillis(afterTimeUtc);
		d = TimeZoneUtil.ConvertTime(d, TimeZone);
		bool gotOne = false;
		while (!gotOne)
		{
			int sec = d.Second;
			ISortedSet<int> st = seconds.TailSet(sec);
			if (st != null && st.Count != 0)
			{
				sec = st.First();
			}
			else
			{
				sec = seconds.First();
				d = d.AddMinutes(1.0);
			}
			d = new DateTimeOffset(d.Year, d.Month, d.Day, d.Hour, d.Minute, sec, d.Millisecond, d.Offset);
			int min = d.Minute;
			int hr = d.Hour;
			int t = -1;
			st = minutes.TailSet(min);
			if (st != null && st.Count != 0)
			{
				t = min;
				min = st.First();
			}
			else
			{
				min = minutes.First();
				hr++;
			}
			if (min != t)
			{
				d = new DateTimeOffset(d.Year, d.Month, d.Day, d.Hour, min, 0, d.Millisecond, d.Offset);
				d = SetCalendarHour(d, hr);
				continue;
			}
			d = new DateTimeOffset(d.Year, d.Month, d.Day, d.Hour, min, d.Second, d.Millisecond, d.Offset);
			hr = d.Hour;
			int day = d.Day;
			t = -1;
			st = hours.TailSet(hr);
			if (st != null && st.Count != 0)
			{
				t = hr;
				hr = st.First();
			}
			else
			{
				hr = hours.First();
				day++;
			}
			if (hr != t)
			{
				int daysInMonth = DateTime.DaysInMonth(d.Year, d.Month);
				d = ((day <= daysInMonth) ? new DateTimeOffset(d.Year, d.Month, day, d.Hour, 0, 0, d.Millisecond, d.Offset) : new DateTimeOffset(d.Year, d.Month, daysInMonth, d.Hour, 0, 0, d.Millisecond, d.Offset).AddDays(day - daysInMonth));
				d = SetCalendarHour(d, hr);
				continue;
			}
			d = new DateTimeOffset(d.Year, d.Month, d.Day, hr, d.Minute, d.Second, d.Millisecond, d.Offset);
			day = d.Day;
			int mon = d.Month;
			t = -1;
			int tmon = mon;
			bool dayOfMSpec = !daysOfMonth.Contains(98);
			bool dayOfWSpec = !daysOfWeek.Contains(98);
			if (dayOfMSpec && !dayOfWSpec)
			{
				st = daysOfMonth.TailSet(day);
				if (lastdayOfMonth)
				{
					if (!nearestWeekday)
					{
						t = day;
						day = GetLastDayOfMonth(mon, d.Year);
						day -= lastdayOffset;
						if (t > day)
						{
							mon++;
							if (mon > 12)
							{
								mon = 1;
								tmon = 3333;
								d = d.AddYears(1);
							}
							day = 1;
						}
					}
					else
					{
						t = day;
						day = GetLastDayOfMonth(mon, d.Year);
						day -= lastdayOffset;
						DateTimeOffset tcal2 = new DateTimeOffset(d.Year, mon, day, 0, 0, 0, d.Offset);
						int ldom2 = GetLastDayOfMonth(mon, d.Year);
						DayOfWeek dow5 = tcal2.DayOfWeek;
						if (dow5 == System.DayOfWeek.Saturday && day == 1)
						{
							day += 2;
						}
						else if (dow5 == System.DayOfWeek.Saturday)
						{
							day--;
						}
						else if (dow5 == System.DayOfWeek.Sunday && day == ldom2)
						{
							day -= 2;
						}
						else if (dow5 == System.DayOfWeek.Sunday)
						{
							day++;
						}
						if (new DateTimeOffset(tcal2.Year, mon, day, hr, min, sec, d.Millisecond, d.Offset).ToUniversalTime() < afterTimeUtc)
						{
							day = 1;
							mon++;
						}
					}
				}
				else if (nearestWeekday)
				{
					t = day;
					day = daysOfMonth.First();
					DateTimeOffset tcal = new DateTimeOffset(d.Year, mon, day, 0, 0, 0, d.Offset);
					int ldom = GetLastDayOfMonth(mon, d.Year);
					DayOfWeek dow4 = tcal.DayOfWeek;
					if (dow4 == System.DayOfWeek.Saturday && day == 1)
					{
						day += 2;
					}
					else if (dow4 == System.DayOfWeek.Saturday)
					{
						day--;
					}
					else if (dow4 == System.DayOfWeek.Sunday && day == ldom)
					{
						day -= 2;
					}
					else if (dow4 == System.DayOfWeek.Sunday)
					{
						day++;
					}
					if (new DateTimeOffset(tcal.Year, mon, day, hr, min, sec, d.Offset).ToUniversalTime() < afterTimeUtc)
					{
						day = daysOfMonth.First();
						mon++;
					}
				}
				else if (st != null && st.Count != 0)
				{
					t = day;
					day = st.First();
					int lastDay = GetLastDayOfMonth(mon, d.Year);
					if (day > lastDay)
					{
						day = daysOfMonth.First();
						mon++;
					}
				}
				else
				{
					day = daysOfMonth.First();
					mon++;
				}
				if (day != t || mon != tmon)
				{
					if (mon > 12)
					{
						d = new DateTimeOffset(d.Year, 12, day, 0, 0, 0, d.Offset).AddMonths(mon - 12);
						continue;
					}
					int lDay3 = DateTime.DaysInMonth(d.Year, mon);
					d = ((day > lDay3) ? new DateTimeOffset(d.Year, mon, lDay3, 0, 0, 0, d.Offset).AddDays(day - lDay3) : new DateTimeOffset(d.Year, mon, day, 0, 0, 0, d.Offset));
					continue;
				}
			}
			else
			{
				if (!dayOfWSpec || dayOfMSpec)
				{
					throw new Exception("Support for specifying both a day-of-week AND a day-of-month parameter is not implemented.");
				}
				if (lastdayOfWeek)
				{
					int dow3 = daysOfWeek.First();
					int cDow3 = (int)(d.DayOfWeek + 1);
					int daysToAdd3 = 0;
					if (cDow3 < dow3)
					{
						daysToAdd3 = dow3 - cDow3;
					}
					if (cDow3 > dow3)
					{
						daysToAdd3 = dow3 + (7 - cDow3);
					}
					int lDay2 = GetLastDayOfMonth(mon, d.Year);
					if (day + daysToAdd3 > lDay2)
					{
						d = ((mon != 12) ? new DateTimeOffset(d.Year, mon + 1, 1, 0, 0, 0, d.Offset) : new DateTimeOffset(d.Year, mon - 11, 1, 0, 0, 0, d.Offset).AddYears(1));
						continue;
					}
					for (; day + daysToAdd3 + 7 <= lDay2; daysToAdd3 += 7)
					{
					}
					day += daysToAdd3;
					if (daysToAdd3 > 0)
					{
						d = new DateTimeOffset(d.Year, mon, day, 0, 0, 0, d.Offset);
						continue;
					}
				}
				else if (nthdayOfWeek != 0)
				{
					int dow2 = daysOfWeek.First();
					int cDow2 = (int)(d.DayOfWeek + 1);
					int daysToAdd2 = 0;
					if (cDow2 < dow2)
					{
						daysToAdd2 = dow2 - cDow2;
					}
					else if (cDow2 > dow2)
					{
						daysToAdd2 = dow2 + (7 - cDow2);
					}
					bool dayShifted = daysToAdd2 > 0;
					day += daysToAdd2;
					int weekOfMonth = day / 7;
					if (day % 7 > 0)
					{
						weekOfMonth++;
					}
					daysToAdd2 = (nthdayOfWeek - weekOfMonth) * 7;
					day += daysToAdd2;
					if (daysToAdd2 < 0 || day > GetLastDayOfMonth(mon, d.Year))
					{
						d = ((mon != 12) ? new DateTimeOffset(d.Year, mon + 1, 1, 0, 0, 0, d.Offset) : new DateTimeOffset(d.Year, mon - 11, 1, 0, 0, 0, d.Offset).AddYears(1));
						continue;
					}
					if (daysToAdd2 > 0 || dayShifted)
					{
						d = new DateTimeOffset(d.Year, mon, day, 0, 0, 0, d.Offset);
						continue;
					}
				}
				else
				{
					int cDow = (int)(d.DayOfWeek + 1);
					int dow = daysOfWeek.First();
					st = daysOfWeek.TailSet(cDow);
					if (st != null && st.Count > 0)
					{
						dow = st.First();
					}
					int daysToAdd = 0;
					if (cDow < dow)
					{
						daysToAdd = dow - cDow;
					}
					if (cDow > dow)
					{
						daysToAdd = dow + (7 - cDow);
					}
					int lDay = GetLastDayOfMonth(mon, d.Year);
					if (day + daysToAdd > lDay)
					{
						d = ((mon != 12) ? new DateTimeOffset(d.Year, mon + 1, 1, 0, 0, 0, d.Offset) : new DateTimeOffset(d.Year, mon - 11, 1, 0, 0, 0, d.Offset).AddYears(1));
						continue;
					}
					if (daysToAdd > 0)
					{
						d = new DateTimeOffset(d.Year, mon, day + daysToAdd, 0, 0, 0, d.Offset);
						continue;
					}
				}
			}
			d = new DateTimeOffset(d.Year, d.Month, day, d.Hour, d.Minute, d.Second, d.Offset);
			mon = d.Month;
			int year = d.Year;
			t = -1;
			if (year > MaxYear)
			{
				return null;
			}
			st = months.TailSet(mon);
			if (st != null && st.Count != 0)
			{
				t = mon;
				mon = st.First();
			}
			else
			{
				mon = months.First();
				year++;
			}
			if (mon != t)
			{
				d = new DateTimeOffset(year, mon, 1, 0, 0, 0, d.Offset);
				continue;
			}
			d = new DateTimeOffset(d.Year, mon, d.Day, d.Hour, d.Minute, d.Second, d.Offset);
			year = d.Year;
			t = -1;
			st = years.TailSet(year);
			if (st != null && st.Count != 0)
			{
				t = year;
				year = st.First();
				if (year != t)
				{
					d = new DateTimeOffset(year, 1, 1, 0, 0, 0, d.Offset);
					continue;
				}
				d = new DateTimeOffset(year, d.Month, d.Day, d.Hour, d.Minute, d.Second, d.Offset);
				d = new DateTimeOffset(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second, TimeZone.GetUtcOffset(d.DateTime));
				gotOne = true;
				continue;
			}
			return null;
		}
		return d.ToUniversalTime();
	}

	/// <summary>
	/// Creates the date time without milliseconds.
	/// </summary>
	/// <param name="time">The time.</param>
	/// <returns></returns>
	protected static DateTimeOffset CreateDateTimeWithoutMillis(DateTimeOffset time)
	{
		return new DateTimeOffset(time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.Offset);
	}

	/// <summary>
	/// Advance the calendar to the particular hour paying particular attention
	/// to daylight saving problems.
	/// </summary>
	/// <param name="date">The date.</param>
	/// <param name="hour">The hour.</param>
	/// <returns></returns>
	protected static DateTimeOffset SetCalendarHour(DateTimeOffset date, int hour)
	{
		int hourToSet = hour;
		if (hourToSet == 24)
		{
			hourToSet = 0;
		}
		DateTimeOffset d = new DateTimeOffset(date.Year, date.Month, date.Day, hourToSet, date.Minute, date.Second, date.Millisecond, date.Offset);
		if (hour == 24)
		{
			return d.AddDays(1.0);
		}
		return d;
	}

	/// <summary>
	/// Gets the time before.
	/// </summary>
	/// <param name="endTime">The end time.</param>
	/// <returns></returns>
	public virtual DateTimeOffset? GetTimeBefore(DateTimeOffset? endTime)
	{
		return null;
	}

	/// <summary>
	/// NOT YET IMPLEMENTED: Returns the final time that the 
	/// <see cref="T:Quartz.CronExpression" /> will match.
	/// </summary>
	/// <returns></returns>
	public virtual DateTimeOffset? GetFinalFireTime()
	{
		return null;
	}

	/// <summary>
	/// Determines whether given year is a leap year.
	/// </summary>
	/// <param name="year">The year.</param>
	/// <returns>
	/// 	<c>true</c> if the specified year is a leap year; otherwise, <c>false</c>.
	/// </returns>
	protected virtual bool IsLeapYear(int year)
	{
		return DateTime.IsLeapYear(year);
	}

	/// <summary>
	/// Gets the last day of month.
	/// </summary>
	/// <param name="monthNum">The month num.</param>
	/// <param name="year">The year.</param>
	/// <returns></returns>
	protected virtual int GetLastDayOfMonth(int monthNum, int year)
	{
		return DateTime.DaysInMonth(year, monthNum);
	}

	/// <summary>
	/// Creates a new object that is a copy of the current instance.
	/// </summary>
	/// <returns>
	/// A new object that is a copy of this instance.
	/// </returns>
	public object Clone()
	{
		try
		{
			CronExpression copy = new CronExpression(CronExpressionString);
			copy.TimeZone = TimeZone;
			return copy;
		}
		catch (FormatException)
		{
			throw new Exception("Not Cloneable.");
		}
	}

	public void OnDeserialization(object sender)
	{
		BuildExpression(cronExpressionString);
	}

	/// <summary>
	/// Determines whether the specified <see cref="T:Quartz.CronExpression" /> is equal to the current <see cref="T:Quartz.CronExpression" />.
	/// </summary>
	/// <returns>
	/// true if the specified <see cref="T:Quartz.CronExpression" /> is equal to the current <see cref="T:Quartz.CronExpression" />; otherwise, false.
	/// </returns>
	/// <param name="other">The <see cref="T:Quartz.CronExpression" /> to compare with the current <see cref="T:Quartz.CronExpression" />. </param>
	public bool Equals(CronExpression other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		if (object.Equals(other.cronExpressionString, cronExpressionString))
		{
			return object.Equals(other.timeZone, timeZone);
		}
		return false;
	}

	/// <summary>
	/// Determines whether the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />.
	/// </summary>
	/// <returns>
	/// true if the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />; otherwise, false.
	/// </returns>
	/// <param name="obj">The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />. </param>
	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != typeof(CronExpression))
		{
			return false;
		}
		return Equals((CronExpression)obj);
	}

	/// <summary>
	/// Serves as a hash function for a particular type. 
	/// </summary>
	/// <returns>
	/// A hash code for the current <see cref="T:System.Object" />.
	/// </returns>
	/// <filterpriority>2</filterpriority>
	public override int GetHashCode()
	{
		return (((cronExpressionString != null) ? cronExpressionString.GetHashCode() : 0) * 397) ^ ((timeZone != null) ? timeZone.GetHashCode() : 0);
	}
}
