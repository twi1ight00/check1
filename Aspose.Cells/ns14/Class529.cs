using System.Globalization;
using System.Runtime.CompilerServices;

namespace ns14;

internal class Class529
{
	private readonly CultureInfo cultureInfo_0;

	private readonly char char_0;

	private readonly char char_1;

	private readonly Enum23 enum23_0;

	private readonly char char_2;

	private readonly char char_3;

	private readonly string string_0;

	private readonly string string_1;

	private readonly string string_2;

	private readonly string string_3;

	private readonly string string_4;

	private readonly string string_5;

	private readonly bool bool_0;

	internal Class529(CultureInfo cultureInfo_1)
	{
		cultureInfo_0 = cultureInfo_1;
		char_0 = method_0(cultureInfo_1.NumberFormat.NumberDecimalSeparator, '.');
		char_1 = method_0(cultureInfo_1.NumberFormat.NumberGroupSeparator, ',');
		bool_0 = char_0 == '.' && char_1 == ',';
		char_2 = method_0(cultureInfo_1.DateTimeFormat.DateSeparator, '/');
		char_3 = method_0(cultureInfo_1.DateTimeFormat.TimeSeparator, ':');
		Enum23 @enum = Enum23.const_2;
		string text = "yyyy";
		string text2 = "M";
		string text3 = "d";
		string[] array = method_1(cultureInfo_1.DateTimeFormat.ShortDatePattern, cultureInfo_1.DateTimeFormat.DateSeparator);
		char c = 'N';
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].Length < 1)
			{
				continue;
			}
			switch (array[i][0])
			{
			case 'Y':
			case 'y':
				text = array[i];
				switch (c)
				{
				case 'd':
					@enum = Enum23.const_5;
					c = 'Y';
					break;
				case 'M':
					@enum = Enum23.const_4;
					c = 'Y';
					break;
				case 'N':
					c = 'y';
					break;
				}
				break;
			case 'M':
			case 'm':
				text2 = array[i];
				switch (c)
				{
				case 'y':
					@enum = Enum23.const_0;
					c = 'Y';
					break;
				case 'd':
					@enum = Enum23.const_1;
					c = 'Y';
					break;
				case 'N':
					c = 'M';
					break;
				}
				break;
			case 'D':
			case 'd':
				text3 = array[i];
				switch (c)
				{
				case 'y':
					@enum = Enum23.const_3;
					c = 'Y';
					break;
				case 'M':
					@enum = Enum23.const_2;
					c = 'Y';
					break;
				case 'N':
					c = 'd';
					break;
				}
				break;
			}
		}
		enum23_0 = @enum;
		string_0 = text;
		string_1 = text2;
		string_2 = text3;
		string text4 = "H";
		string text5 = "mm";
		string text6 = "ss";
		array = method_1(cultureInfo_1.DateTimeFormat.ShortTimePattern, cultureInfo_1.DateTimeFormat.TimeSeparator);
		for (int j = 0; j < array.Length; j++)
		{
			if (array[j].Length >= 1)
			{
				switch (array[j][0])
				{
				case 'S':
				case 's':
					text6 = array[j];
					break;
				case 'M':
				case 'm':
					text5 = array[j];
					break;
				case 'H':
				case 'h':
					text4 = array[j];
					break;
				}
			}
		}
		string_3 = text4;
		string_4 = text5;
		string_5 = text6;
	}

	private char method_0(string string_6, char char_4)
	{
		if (string_6 != null && string_6.Length > 0)
		{
			return string_6[0];
		}
		return char_4;
	}

	private string[] method_1(string string_6, string string_7)
	{
		if (string_6 != null && string_6.Length >= 1 && string_7 != null && string_7.Length >= 1)
		{
			return string_6.Split(string_7.ToCharArray());
		}
		return new string[0];
	}

	[SpecialName]
	public char method_2()
	{
		return char_0;
	}

	[SpecialName]
	public char method_3()
	{
		return char_1;
	}

	[SpecialName]
	public Enum23 method_4()
	{
		return enum23_0;
	}

	[SpecialName]
	public char method_5()
	{
		return char_2;
	}

	[SpecialName]
	public char method_6()
	{
		return char_3;
	}

	[SpecialName]
	public string method_7()
	{
		return string_1;
	}

	[SpecialName]
	public string method_8()
	{
		return string_2;
	}

	[SpecialName]
	public string method_9()
	{
		return string_3;
	}

	[SpecialName]
	public string method_10()
	{
		return string_4;
	}

	[SpecialName]
	public string method_11()
	{
		return string_5;
	}

	[SpecialName]
	public bool method_12()
	{
		return bool_0;
	}
}
