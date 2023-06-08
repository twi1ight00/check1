using System;
using System.Collections.Generic;
using System.Text;
using Aspose.Slides;

namespace ns4;

internal class Class72
{
	private string string_0;

	private Class71[] class71_0;

	private Interface1 interface1_0;

	private string[] string_1;

	private static readonly Dictionary<string, Class72> dictionary_0;

	private static readonly Dictionary<string, int> dictionary_1;

	private static string[] string_2;

	internal Class72(string lang, Class71[] localeCalendars, Interface1 intFormatter, string[] formats)
	{
		string_0 = lang;
		class71_0 = localeCalendars;
		string_1 = formats;
		interface1_0 = intFormatter;
	}

	private void method_0(string format, StringBuilder sb, char marker, int count, DateTime dt, Class71 localeCalendar, Interface1 intFormatter)
	{
		switch (marker)
		{
		case 'd':
			switch (count)
			{
			default:
				throw new FormatException("invalid format: " + new string(marker, count));
			case 1:
				sb.Append(method_1(intFormatter, format, 1, localeCalendar.calendar_0.GetDayOfMonth(dt)));
				break;
			case 2:
				sb.Append(method_1(intFormatter, format, 2, localeCalendar.calendar_0.GetDayOfMonth(dt)));
				break;
			case 3:
				sb.Append(localeCalendar.string_2[(int)localeCalendar.calendar_0.GetDayOfWeek(dt)]);
				break;
			case 4:
				sb.Append(localeCalendar.string_1[(int)localeCalendar.calendar_0.GetDayOfWeek(dt)]);
				break;
			}
			break;
		case 'M':
			switch (count)
			{
			default:
				throw new FormatException("invalid format: " + new string(marker, count));
			case 1:
				sb.Append(method_1(intFormatter, format, 1, localeCalendar.calendar_0.GetMonth(dt)));
				break;
			case 2:
				sb.Append(method_1(intFormatter, format, 2, localeCalendar.calendar_0.GetMonth(dt)));
				break;
			case 3:
				sb.Append(localeCalendar.string_4[localeCalendar.calendar_0.GetMonth(dt) - 1]);
				break;
			case 4:
				sb.Append(localeCalendar.string_3[localeCalendar.calendar_0.GetMonth(dt) - 1]);
				break;
			}
			break;
		case 'G':
			switch (count)
			{
			default:
				throw new FormatException("invalid format: " + new string(marker, count));
			case 3:
				sb.Append(localeCalendar.string_6[localeCalendar.calendar_0.GetMonth(dt) - 1]);
				break;
			case 4:
				sb.Append(localeCalendar.string_5[localeCalendar.calendar_0.GetMonth(dt) - 1]);
				break;
			}
			break;
		case 'H':
			switch (count)
			{
			default:
				throw new FormatException("invalid format: " + new string(marker, count));
			case 1:
				sb.Append(method_1(intFormatter, format, 1, localeCalendar.calendar_0.GetHour(dt)));
				break;
			case 2:
				sb.Append(method_1(intFormatter, format, 2, localeCalendar.calendar_0.GetHour(dt)));
				break;
			}
			break;
		case 'm':
			switch (count)
			{
			default:
				throw new FormatException("invalid format: " + new string(marker, count));
			case 1:
				sb.Append(method_1(intFormatter, format, 1, localeCalendar.calendar_0.GetMinute(dt)));
				break;
			case 2:
				sb.Append(method_1(intFormatter, format, 2, localeCalendar.calendar_0.GetMinute(dt)));
				break;
			}
			break;
		case 'h':
		{
			int num = localeCalendar.calendar_0.GetHour(dt) % 12;
			if (num == 0)
			{
				num = 12;
			}
			switch (count)
			{
			default:
				throw new FormatException("invalid format: " + new string(marker, count));
			case 1:
				sb.Append(method_1(intFormatter, format, 1, num));
				break;
			case 2:
				sb.Append(method_1(intFormatter, format, 2, num));
				break;
			}
			break;
		}
		case 'y':
			switch (count)
			{
			default:
				throw new FormatException("invalid format: " + new string(marker, count));
			case 1:
				sb.Append(method_1(intFormatter, format, 1, localeCalendar.calendar_0.GetYear(dt) % 10));
				break;
			case 2:
				sb.Append(method_1(intFormatter, format, 2, localeCalendar.calendar_0.GetYear(dt) % 100));
				break;
			case 3:
				sb.Append(method_1(intFormatter, format, 3, localeCalendar.calendar_0.GetYear(dt) % 1000));
				break;
			case 4:
				sb.Append(method_1(intFormatter, format, 4, localeCalendar.calendar_0.GetYear(dt)));
				break;
			}
			break;
		case 's':
			switch (count)
			{
			default:
				throw new FormatException("invalid format: " + new string(marker, count));
			case 1:
				sb.Append(method_1(intFormatter, format, 1, localeCalendar.calendar_0.GetSecond(dt)));
				break;
			case 2:
				sb.Append(method_1(intFormatter, format, 2, localeCalendar.calendar_0.GetSecond(dt)));
				break;
			}
			break;
		case 't':
			if (count == 2)
			{
				int hour = localeCalendar.calendar_0.GetHour(dt);
				sb.Append(localeCalendar.string_7[(hour < 1 || hour > 12) ? 1 : 0]);
				break;
			}
			throw new FormatException("invalid format: " + new string(marker, count));
		}
	}

	private string method_1(Interface1 nf, string format, int digitCount, int value)
	{
		if (nf == null)
		{
			return value.ToString(string_2[digitCount]);
		}
		return nf.imethod_0(format, value);
	}

	private string method_2(Class71 localeCalendar, string format, int index, DateTime dt)
	{
		int num = 0;
		bool flag = false;
		int num2 = int.MinValue;
		StringBuilder stringBuilder = new StringBuilder();
		bool flag2 = false;
		while (index < format.Length)
		{
			char c = format[index++];
			if (c != '\'' && flag)
			{
				stringBuilder.Append(c);
				continue;
			}
			if (c != num2 && num > 0)
			{
				Interface1 intFormatter = null;
				string format2 = null;
				if (c == '{')
				{
					int num3 = index;
					while (index < format.Length && format[index] != '}')
					{
						index++;
					}
					if (num3 < index)
					{
						format2 = format.Substring(num3, index - num3);
					}
					intFormatter = interface1_0;
					index++;
					c = ((index < format.Length) ? format[index++] : '\0');
				}
				method_0(format2, stringBuilder, (char)num2, num, dt, localeCalendar, intFormatter);
				num = 0;
			}
			if (!flag2)
			{
				switch (c)
				{
				case '\'':
					flag = !flag;
					num2 = int.MinValue;
					num = 0;
					break;
				case '\\':
					flag2 = true;
					break;
				default:
					stringBuilder.Append(c);
					break;
				case 'G':
				case 'H':
				case 'M':
				case 'd':
				case 'h':
				case 'm':
				case 's':
				case 't':
				case 'y':
					if (c == num2)
					{
						num++;
						break;
					}
					num2 = c;
					num = 1;
					break;
				case '\0':
					break;
				}
			}
			else
			{
				stringBuilder.Append(c);
				flag2 = false;
			}
		}
		if (num > 0)
		{
			method_0(null, stringBuilder, (char)num2, num, dt, localeCalendar, null);
		}
		return stringBuilder.ToString();
	}

	public static string smethod_0(DateTime dt, string langCode, IFieldType fieldType)
	{
		if (!dictionary_0.TryGetValue(langCode, out var value))
		{
			value = dictionary_0["en-US"];
		}
		dictionary_1.TryGetValue(fieldType.InternalString, out var value2);
		string text = value.string_1[value2];
		if (text == "")
		{
			value = dictionary_0["en-US"];
			text = value.string_1[value2];
		}
		return smethod_1(value, text, dt);
	}

	private static string smethod_1(Class72 formatter, string format, DateTime dt)
	{
		Class71 localeCalendar = formatter.class71_0[0];
		int num = 0;
		while (num < format.Length && (format[num] == 'c' || format[num] == 'l'))
		{
			int num2 = format.IndexOf(';', num);
			if (num2 < 0)
			{
				break;
			}
			if (format[num] == 'l')
			{
				if (dictionary_0.TryGetValue(format.Substring(num + 1, num2 - num - 1), out var value))
				{
					formatter = value;
					localeCalendar = formatter.class71_0[0];
				}
				num = num2 + 1;
			}
			else
			{
				string text = format.Substring(num + 1, num2 - num - 1);
				for (int i = 0; i < formatter.class71_0.Length; i++)
				{
					if (formatter.class71_0[i].string_0 == text)
					{
						localeCalendar = formatter.class71_0[i];
					}
				}
			}
			num = num2 + 1;
		}
		return formatter.method_2(localeCalendar, format, num, dt);
	}

	static Class72()
	{
		dictionary_0 = new Dictionary<string, Class72>(StringComparer.InvariantCultureIgnoreCase);
		dictionary_1 = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
		string_2 = new string[5] { "d", "d", "d2", "d3", "d4" };
		dictionary_1.Add("datetime", 0);
		dictionary_1.Add("datetime1", 0);
		dictionary_1.Add("datetime2", 1);
		dictionary_1.Add("datetime3", 2);
		dictionary_1.Add("datetime4", 3);
		dictionary_1.Add("datetime5", 4);
		dictionary_1.Add("datetime6", 5);
		dictionary_1.Add("datetime7", 6);
		dictionary_1.Add("datetime8", 7);
		dictionary_1.Add("datetime9", 8);
		dictionary_1.Add("datetime10", 9);
		dictionary_1.Add("datetime11", 10);
		dictionary_1.Add("datetime12", 11);
		dictionary_1.Add("datetime13", 12);
		Class73.smethod_0(dictionary_0);
		Class74.smethod_0(dictionary_0);
		Class75.smethod_0(dictionary_0);
		Class76.smethod_0(dictionary_0);
		Class77.smethod_0(dictionary_0);
		Class78.smethod_0(dictionary_0);
		Class79.smethod_0(dictionary_0);
		Class80.smethod_0(dictionary_0);
		Class81.smethod_0(dictionary_0);
		Class82.smethod_0(dictionary_0);
		Class83.smethod_0(dictionary_0);
		Class84.smethod_0(dictionary_0);
		Class85.smethod_0(dictionary_0);
		Class86.smethod_0(dictionary_0);
		Class87.smethod_0(dictionary_0);
		Class88.smethod_0(dictionary_0);
		Class89.smethod_0(dictionary_0);
		Class90.smethod_0(dictionary_0);
		Class91.smethod_0(dictionary_0);
		Class92.smethod_0(dictionary_0);
		Class93.smethod_0(dictionary_0);
		Class94.smethod_0(dictionary_0);
		Class95.smethod_0(dictionary_0);
		Class96.smethod_0(dictionary_0);
		Class97.smethod_0(dictionary_0);
		Class98.smethod_0(dictionary_0);
	}
}
