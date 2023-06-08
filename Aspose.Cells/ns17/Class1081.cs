using System;
using System.Globalization;
using System.IO;

namespace ns17;

internal class Class1081 : Class1080
{
	public Class1081(Class1087 class1087_1)
	{
		class1087_0 = class1087_1;
	}

	public override Enum170 vmethod_0(ref string string_0)
	{
		if (string_0.Length < 2)
		{
			return Enum170.const_1;
		}
		switch (string_0[1])
		{
		case 'A':
			class1087_0.string_0 += class1087_0.worksheet_0.Name;
			class1087_0.class1080_6 = class1087_0.class1080_0;
			goto IL_02a5;
		case 'D':
		{
			DateTime now2 = DateTime.Now;
			class1087_0.string_0 += class1087_0.worksheet_0.Workbook.Settings.method_3().Format(14, now2).StringValue;
			class1087_0.class1080_6 = class1087_0.class1080_0;
			goto IL_02a5;
		}
		case 'F':
			try
			{
				class1087_0.string_0 += Path.GetFileName(class1087_0.worksheet_0.Workbook.FileName);
			}
			catch
			{
			}
			class1087_0.class1080_6 = class1087_0.class1080_0;
			goto IL_02a5;
		case 'G':
			class1087_0.class1080_6 = class1087_0.class1080_3;
			return Enum170.const_0;
		case '&':
			class1087_0.string_0 += "&";
			class1087_0.class1080_6 = class1087_0.class1080_0;
			goto IL_02a5;
		case ' ':
			class1087_0.class1080_6 = class1087_0.class1080_0;
			goto IL_02a5;
		case 'Z':
			try
			{
				class1087_0.string_0 += Path.GetDirectoryName(class1087_0.worksheet_0.Workbook.FileName);
			}
			catch
			{
			}
			class1087_0.class1080_6 = class1087_0.class1080_0;
			goto IL_02a5;
		case 'T':
		{
			DateTime now = DateTime.Now;
			class1087_0.string_0 += now.ToShortTimeString();
			class1087_0.class1080_6 = class1087_0.class1080_0;
			goto IL_02a5;
		}
		case 'N':
			class1087_0.string_0 += class1087_0.int_1;
			class1087_0.class1080_6 = class1087_0.class1080_0;
			goto IL_02a5;
		default:
			class1087_0.class1080_6 = class1087_0.class1080_4;
			return Enum170.const_0;
		case 'P':
			{
				int num = 0;
				int int_ = class1087_0.int_0;
				int i = 2;
				if (string_0.Length > 2 && ((string_0[i] == '+' && string_0[i + 1] == '+') || (string_0[i] == '-' && string_0[i + 1] == '-')))
				{
					class1087_0.string_0 += int_ + num;
					class1087_0.string_0 += string_0[i];
					class1087_0.class1080_6 = class1087_0.class1080_0;
					string_0 = string_0.Substring(i + 2);
					return Enum170.const_0;
				}
				for (; i < string_0.Length && char.IsDigit(string_0[i]); i++)
				{
				}
				if (i > 2)
				{
					num = int.Parse(string_0.Substring(2, i - 2), NumberStyles.Integer);
				}
				class1087_0.string_0 += int_ + num;
				class1087_0.class1080_6 = class1087_0.class1080_0;
				string_0 = string_0.Substring(i);
				return Enum170.const_0;
			}
			IL_02a5:
			string_0 = string_0.Substring(2);
			return Enum170.const_0;
		}
	}
}
