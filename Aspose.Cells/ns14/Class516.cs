using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells;
using ns2;
using ns22;

namespace ns14;

internal class Class516
{
	private CountryCode countryCode_0;

	private bool bool_0;

	private Interface2 interface2_0;

	private short short_0;

	private CultureInfo cultureInfo_0;

	private Class528 class528_0;

	private Class529 class529_0;

	private Class512 class512_0;

	private Class513 class513_0;

	private string[] string_0;

	private Hashtable hashtable_0;

	private Class504 class504_0;

	private Class515 class515_0 = new Class515();

	private int int_0 = 11;

	public CultureInfo CultureInfo
	{
		get
		{
			return cultureInfo_0;
		}
		set
		{
			if (value == null)
			{
				if (cultureInfo_0 == null || countryCode_0 != 0)
				{
					cultureInfo_0 = CultureInfo.CurrentCulture;
					countryCode_0 = CountryCode.Default;
					short_0 = Class519.smethod_6(CultureInfo.CurrentCulture);
					method_0();
				}
			}
			else if (!value.Equals(cultureInfo_0))
			{
				cultureInfo_0 = value;
				short_0 = Class519.smethod_6(value);
				countryCode_0 = Class519.smethod_4(short_0);
				method_0();
			}
		}
	}

	public CountryCode Region
	{
		get
		{
			return countryCode_0;
		}
		set
		{
			if (countryCode_0 != value)
			{
				countryCode_0 = value;
				if (value == CountryCode.Default)
				{
					cultureInfo_0 = CultureInfo.CurrentCulture;
					short_0 = Class519.smethod_6(cultureInfo_0);
				}
				else
				{
					short_0 = Class519.smethod_3(value);
					cultureInfo_0 = Class1023.smethod_0(value);
				}
				method_0();
			}
		}
	}

	public bool Date1904
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Class516()
	{
		CultureInfo = null;
	}

	public Class516(CountryCode countryCode_1)
	{
		if (countryCode_1 == CountryCode.Default)
		{
			CultureInfo = null;
		}
		else
		{
			Region = countryCode_1;
		}
	}

	internal void Copy(Class516 class516_0)
	{
		bool_0 = class516_0.bool_0;
		countryCode_0 = class516_0.countryCode_0;
		cultureInfo_0 = class516_0.cultureInfo_0;
		short_0 = class516_0.short_0;
		class529_0 = class516_0.class529_0;
		class528_0 = class516_0.class528_0;
		int_0 = class516_0.int_0;
		class513_0 = null;
		class512_0 = null;
		string_0 = null;
		hashtable_0 = null;
		class504_0 = null;
	}

	private void method_0()
	{
		class529_0 = new Class529(cultureInfo_0);
		class528_0 = null;
		class513_0 = null;
		class512_0 = null;
		string_0 = null;
		hashtable_0 = null;
		class504_0 = null;
	}

	[SpecialName]
	internal Interface2 method_1()
	{
		return interface2_0;
	}

	[SpecialName]
	internal void method_2(Interface2 interface2_1)
	{
		interface2_0 = interface2_1;
	}

	[SpecialName]
	internal short method_3()
	{
		return short_0;
	}

	[SpecialName]
	internal Class529 method_4()
	{
		return class529_0;
	}

	[SpecialName]
	internal Class528 method_5()
	{
		if (class528_0 == null)
		{
			class528_0 = new Class528(cultureInfo_0, method_4());
		}
		return class528_0;
	}

	[SpecialName]
	internal Class512 method_6()
	{
		if (class512_0 == null)
		{
			Class520 @class = new Class520();
			@class.method_2(method_5());
			@class.CultureInfo = cultureInfo_0;
			class512_0 = new Class512(@class.CultureInfo, method_4(), @class);
		}
		return class512_0;
	}

	[SpecialName]
	internal Class513 method_7()
	{
		if (class513_0 == null)
		{
			Class520 @class = new Class520();
			@class.method_2(method_5());
			@class.CultureInfo = cultureInfo_0;
			class513_0 = new Class513(@class.CultureInfo, method_4(), @class);
		}
		return class513_0;
	}

	internal string method_8(int int_1)
	{
		if (string_0 == null)
		{
			string value = "\"" + cultureInfo_0.NumberFormat.CurrencySymbol + "\"";
			StringBuilder stringBuilder = new StringBuilder(20);
			string_0 = new string[59];
			string_0[0] = "General";
			string_0[1] = "0";
			string_0[2] = "0.00";
			string_0[3] = "#,##0";
			string_0[4] = "#,##0.00";
			if (Class519.smethod_1(short_0))
			{
				stringBuilder.Length = 0;
				string_0[5] = stringBuilder.Append(value).Append("#,##0;").Append(value)
					.Append("-#,##0")
					.ToString();
				stringBuilder.Length = 0;
				string_0[6] = stringBuilder.Append(value).Append("#,##0;[Red]").Append(value)
					.Append("-#,##0")
					.ToString();
				stringBuilder.Length = 0;
				string_0[7] = stringBuilder.Append(value).Append("#,##0.00;").Append(value)
					.Append("-#,##0.00")
					.ToString();
				stringBuilder.Length = 0;
				string_0[8] = stringBuilder.Append(value).Append("#,##0.00;[Red]").Append(value)
					.Append("-#,##0.00")
					.ToString();
				string_0[37] = "#,##0;-#,##0";
				string_0[38] = "#,##0;[Red]-#,##0";
				string_0[39] = "#,##0.00;-#,##0.00";
				string_0[40] = "#,##0.00;[Red]-#,##0.00";
				string_0[41] = "_ * #,##0_ ;_ * -#,##0_ ;_ * \"-\"_ ;_ @_ ";
				stringBuilder.Length = 0;
				string_0[42] = stringBuilder.Append("_ ").Append(value).Append("* #,##0_ ;_ ")
					.Append(value)
					.Append("* -#,##0_ ;_ ")
					.Append(value)
					.Append("* \"-\"_ ;_ @_ ")
					.ToString();
				string_0[43] = "_ * #,##0.00_ ;_ * -#,##0.00_ ;_ * \"-\"??_ ;_ @_ ";
				stringBuilder.Length = 0;
				string_0[44] = stringBuilder.Append("_ ").Append(value).Append("* #,##0.00_ ;_ ")
					.Append(value)
					.Append("* -#,##0.00_ ;_ ")
					.Append(value)
					.Append("* \"-\"??_ ;_ @_ ")
					.ToString();
			}
			else
			{
				stringBuilder.Length = 0;
				string_0[5] = stringBuilder.Append(value).Append("#,##0_);(").Append(value)
					.Append("#,##0)")
					.ToString();
				stringBuilder.Length = 0;
				string_0[6] = stringBuilder.Append(value).Append("#,##0_);[Red](").Append(value)
					.Append("#,##0)")
					.ToString();
				stringBuilder.Length = 0;
				string_0[7] = stringBuilder.Append(value).Append("#,##0.00_);(").Append(value)
					.Append("#,##0.00)")
					.ToString();
				stringBuilder.Length = 0;
				string_0[8] = stringBuilder.Append(value).Append("#,##0.00_);[Red](").Append(value)
					.Append("#,##0.00)")
					.ToString();
				string_0[37] = "#,##0_);(#,##0)";
				string_0[38] = "#,##0_);[Red](#,##0)";
				string_0[39] = "#,##0.00_);(#,##0.00)";
				string_0[40] = "#,##0.00_);[Red](#,##0.00)";
				string_0[41] = "_(* #,##0_);_(* (#,##0);_(* \"-\"_);_(@_)";
				stringBuilder.Length = 0;
				string_0[42] = stringBuilder.Append("_(").Append(value).Append("* #,##0_);_(")
					.Append(value)
					.Append("* (#,##0);_(")
					.Append(value)
					.Append("* \"-\"_);_(@_)")
					.ToString();
				string_0[43] = "_(* #,##0.00_);_(* (#,##0.00);_(* \"-\"??_);_(@_)";
				stringBuilder.Length = 0;
				string_0[44] = stringBuilder.Append("_(").Append(value).Append("* #,##0.00_);_(")
					.Append(value)
					.Append("* (#,##0.00);_(")
					.Append(value)
					.Append("* \"-\"??_);_(@_)")
					.ToString();
			}
			string_0[9] = "0%";
			string_0[10] = "0.00%";
			string_0[11] = "0.00E+00";
			string_0[12] = "# ?/?";
			string_0[13] = "# ??/??";
			stringBuilder.Length = 0;
			string_0[14] = method_15("yyyy", class529_0.method_7(), class529_0.method_8(), stringBuilder).ToString();
			if (Class519.smethod_2(7, short_0))
			{
				stringBuilder.Length = 0;
				string_0[15] = stringBuilder.Append(class529_0.method_8()).Append(".MMM yy").ToString();
				stringBuilder.Length = 0;
				string_0[16] = stringBuilder.Append(class529_0.method_8()).Append(".MMM").ToString();
			}
			else
			{
				stringBuilder.Length = 0;
				string_0[15] = stringBuilder.Append(class529_0.method_8()).Append("-MMM-yy").ToString();
				stringBuilder.Length = 0;
				string_0[16] = stringBuilder.Append(class529_0.method_8()).Append("-MMM").ToString();
			}
			string_0[17] = "MMM-yy";
			string_0[18] = "h:mm AM/PM";
			string_0[19] = "h:mm:ss AM/PM";
			string_0[20] = "h:mm";
			stringBuilder.Length = 0;
			string_0[21] = stringBuilder.Append(class529_0.method_9()).Append(":").Append(class529_0.method_10())
				.Append(":")
				.Append(class529_0.method_11())
				.ToString();
			stringBuilder.Length = 0;
			string_0[22] = stringBuilder.Append(string_0[14]).Append(" h:mm").ToString();
			string_0[23] = "\"$\"#,##0;(\"$\"#,##0)";
			string_0[24] = string_0[23];
			string_0[25] = "\"$\"#,##0.00;(\"$\"#,##0.00)";
			string_0[26] = string_0[25];
			stringBuilder.Length = 0;
			string_0[27] = stringBuilder.Append("yyyy\"").Append('年').Append('"')
				.Append(class529_0.method_7())
				.Append('"')
				.Append('月')
				.Append('"')
				.ToString();
			stringBuilder.Length = 0;
			string_0[28] = stringBuilder.Append(class529_0.method_7()).Append('"').Append('月')
				.Append('"')
				.Append(class529_0.method_8())
				.Append('"')
				.Append('日')
				.Append('"')
				.ToString();
			string_0[29] = string_0[28];
			stringBuilder.Length = 0;
			string_0[30] = stringBuilder.Append(class529_0.method_7()).Append(class529_0.method_5()).Append(class529_0.method_8())
				.Append(class529_0.method_5())
				.Append("yy")
				.ToString();
			stringBuilder.Length = 0;
			string_0[31] = method_16("yyyy", "\"" + '年' + "\"", class529_0.method_7(), "\"" + '月' + "\"", class529_0.method_8(), "\"" + '日' + "\"", stringBuilder).ToString();
			stringBuilder.Length = 0;
			string_0[32] = stringBuilder.Append(class529_0.method_9()).Append('"').Append('时')
				.Append("\"mm\"")
				.Append('分')
				.Append('"')
				.ToString();
			stringBuilder.Length = 0;
			string_0[33] = stringBuilder.Append(string_0[32]).Append("ss\"").Append('秒')
				.Append('"')
				.ToString();
			stringBuilder.Length = 0;
			string_0[34] = stringBuilder.Append(Class1391.char_0).Append('/').Append(Class1391.char_1)
				.Append(string_0[32])
				.ToString();
			stringBuilder.Length = 0;
			string_0[35] = stringBuilder.Append(string_0[34]).Append("ss\"").Append('秒')
				.Append('"')
				.ToString();
			string_0[36] = string_0[27];
			string_0[45] = "mm:ss";
			string_0[46] = "[h]:mm:ss";
			string_0[47] = "mm:ss.0";
			string_0[48] = "##0.0E+0";
			string_0[49] = "@";
			string_0[50] = string_0[27];
			string_0[51] = string_0[28];
			string_0[52] = string_0[27];
			string_0[53] = string_0[28];
			string_0[54] = string_0[28];
			string_0[55] = string_0[34];
			if (Class519.smethod_2(17, short_0))
			{
				stringBuilder.Length = 0;
				string_0[31] = stringBuilder.Append("yyyy\"").Append('年').Append("\"M\"")
					.Append('月')
					.Append("\"D\"")
					.Append('日')
					.ToString();
				stringBuilder.Length = 0;
				string_0[56] = stringBuilder.Append("m\"").Append('月').Append("\"d\"")
					.Append('日')
					.Append('"')
					.ToString();
			}
			else if (Class519.smethod_2(18, short_0))
			{
				stringBuilder.Length = 0;
				string_0[56] = "yyyy-mm-dd";
			}
			else
			{
				string_0[56] = string_0[35];
			}
			string_0[57] = string_0[27];
			string_0[58] = string_0[28];
		}
		if (int_1 >= 0 && int_1 <= string_0.Length)
		{
			return string_0[int_1];
		}
		return null;
	}

	[SpecialName]
	internal Class515 method_9()
	{
		return class515_0;
	}

	internal Class518 Format(int int_1, object object_0)
	{
		return method_10(int_1).Format(class515_0, object_0);
	}

	internal Class518 Format(string string_1, object object_0, bool bool_1)
	{
		return method_11(string_1, bool_1).Format(class515_0, object_0);
	}

	internal Interface3 method_10(int int_1)
	{
		if (int_1 == 0)
		{
			return method_12();
		}
		string text = method_8(int_1);
		if (text == null)
		{
			return method_12();
		}
		return method_11(text, bool_1: true);
	}

	internal Interface3 method_11(string string_1, bool bool_1)
	{
		if (string_1 != null && !string_1.Equals("General"))
		{
			if (hashtable_0 != null)
			{
				object obj = hashtable_0[string_1];
				if (obj != null)
				{
					return (Interface3)obj;
				}
			}
			else if (bool_1)
			{
				hashtable_0 = new Hashtable(50);
			}
			return new Class486(this).method_0(string_1, bool_1);
		}
		return method_12();
	}

	[SpecialName]
	internal Class504 method_12()
	{
		if (class504_0 == null)
		{
			Class509 @class = new Class509();
			@class.method_1(this);
			class504_0 = new Class504(@class, null, null);
		}
		return class504_0;
	}

	[SpecialName]
	internal int method_13()
	{
		return int_0;
	}

	[SpecialName]
	internal Hashtable method_14()
	{
		return hashtable_0;
	}

	internal StringBuilder method_15(string string_1, string string_2, string string_3, StringBuilder stringBuilder_0)
	{
		if (stringBuilder_0 == null)
		{
			stringBuilder_0 = new StringBuilder();
		}
		switch (class529_0.method_4())
		{
		case Enum23.const_0:
			stringBuilder_0.Append(string_1);
			stringBuilder_0.Append(class529_0.method_5());
			stringBuilder_0.Append(string_2);
			stringBuilder_0.Append(class529_0.method_5());
			stringBuilder_0.Append(string_3);
			break;
		case Enum23.const_1:
			stringBuilder_0.Append(string_3);
			stringBuilder_0.Append(class529_0.method_5());
			stringBuilder_0.Append(string_2);
			stringBuilder_0.Append(class529_0.method_5());
			stringBuilder_0.Append(string_1);
			break;
		case Enum23.const_2:
			stringBuilder_0.Append(string_2);
			stringBuilder_0.Append(class529_0.method_5());
			stringBuilder_0.Append(string_3);
			stringBuilder_0.Append(class529_0.method_5());
			stringBuilder_0.Append(string_1);
			break;
		case Enum23.const_3:
			stringBuilder_0.Append(string_1);
			stringBuilder_0.Append(class529_0.method_5());
			stringBuilder_0.Append(string_3);
			stringBuilder_0.Append(class529_0.method_5());
			stringBuilder_0.Append(string_2);
			break;
		case Enum23.const_4:
			stringBuilder_0.Append(string_2);
			stringBuilder_0.Append(class529_0.method_5());
			stringBuilder_0.Append(string_1);
			stringBuilder_0.Append(class529_0.method_5());
			stringBuilder_0.Append(string_3);
			break;
		case Enum23.const_5:
			stringBuilder_0.Append(string_3);
			stringBuilder_0.Append(class529_0.method_5());
			stringBuilder_0.Append(string_1);
			stringBuilder_0.Append(class529_0.method_5());
			stringBuilder_0.Append(string_2);
			break;
		}
		return stringBuilder_0;
	}

	internal StringBuilder method_16(string string_1, string string_2, string string_3, string string_4, string string_5, string string_6, StringBuilder stringBuilder_0)
	{
		if (stringBuilder_0 == null)
		{
			stringBuilder_0 = new StringBuilder();
		}
		switch (class529_0.method_4())
		{
		case Enum23.const_0:
			stringBuilder_0.Append(string_1);
			stringBuilder_0.Append(string_2);
			stringBuilder_0.Append(string_3);
			stringBuilder_0.Append(string_4);
			stringBuilder_0.Append(string_5);
			stringBuilder_0.Append(string_6);
			break;
		case Enum23.const_1:
			stringBuilder_0.Append(string_5);
			stringBuilder_0.Append(string_6);
			stringBuilder_0.Append(string_3);
			stringBuilder_0.Append(string_4);
			stringBuilder_0.Append(string_1);
			stringBuilder_0.Append(string_2);
			break;
		case Enum23.const_2:
			stringBuilder_0.Append(string_3);
			stringBuilder_0.Append(string_4);
			stringBuilder_0.Append(string_5);
			stringBuilder_0.Append(string_6);
			stringBuilder_0.Append(string_1);
			stringBuilder_0.Append(string_2);
			break;
		case Enum23.const_3:
			stringBuilder_0.Append(string_1);
			stringBuilder_0.Append(string_2);
			stringBuilder_0.Append(string_5);
			stringBuilder_0.Append(string_6);
			stringBuilder_0.Append(string_3);
			stringBuilder_0.Append(string_4);
			break;
		case Enum23.const_4:
			stringBuilder_0.Append(string_3);
			stringBuilder_0.Append(string_4);
			stringBuilder_0.Append(string_1);
			stringBuilder_0.Append(string_2);
			stringBuilder_0.Append(string_5);
			stringBuilder_0.Append(string_6);
			break;
		case Enum23.const_5:
			stringBuilder_0.Append(string_5);
			stringBuilder_0.Append(string_6);
			stringBuilder_0.Append(string_1);
			stringBuilder_0.Append(string_2);
			stringBuilder_0.Append(string_3);
			stringBuilder_0.Append(string_4);
			break;
		}
		return stringBuilder_0;
	}
}
