using System;
using System.Collections.Generic;
using System.Globalization;
using Aspose.Slides;

namespace ns4;

internal class Class71
{
	internal string string_0;

	internal Calendar calendar_0;

	internal string[] string_1;

	internal string[] string_2;

	internal string[] string_3;

	internal string[] string_4;

	internal string[] string_5;

	internal string[] string_6;

	internal string[] string_7;

	private static string[] string_8;

	private static readonly Dictionary<string, Calendar> dictionary_0;

	static Class71()
	{
		string_8 = new string[2] { "", "" };
		dictionary_0 = new Dictionary<string, Calendar>(StringComparer.InvariantCultureIgnoreCase);
		dictionary_0.Add("gr", new GregorianCalendar());
		dictionary_0.Add("hi", new HijriCalendar());
		dictionary_0.Add("tb", new ThaiBuddhistCalendar());
		dictionary_0.Add("he", new HebrewCalendar());
		dictionary_0.Add("ja", new JapaneseCalendar());
		dictionary_0.Add("ko", new KoreanCalendar());
	}

	internal Class71(string calendar, string[] dayNames, string[] abbrDayNames, string[] monthNames, string[] abbrMonthNames, string[] genitiveMonthNames, string[] abbrGenMonthNames, string[] ampmDesignators)
	{
		string_0 = calendar;
		if (!dictionary_0.TryGetValue(calendar, out calendar_0))
		{
			throw new PptxException("Internal exception: unknown calendar: " + calendar);
		}
		string_1 = dayNames;
		string_2 = ((abbrDayNames != null) ? abbrDayNames : string_1);
		string_3 = monthNames;
		string_4 = ((abbrMonthNames != null) ? abbrMonthNames : string_3);
		string_5 = ((genitiveMonthNames != null) ? genitiveMonthNames : string_3);
		string_6 = ((abbrGenMonthNames != null) ? abbrGenMonthNames : string_5);
		string_7 = ((ampmDesignators != null) ? ampmDesignators : string_8);
	}
}
