using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns1;

namespace ns16;

internal class Class1545
{
	private string string_0;

	internal string string_1;

	internal string string_2;

	internal string string_3;

	internal bool bool_0 = true;

	internal bool bool_1 = true;

	internal bool bool_2;

	internal bool bool_3;

	internal double double_0 = -1.0;

	internal double double_1 = -1.0;

	internal double double_2 = -1.0;

	internal double double_3 = -1.0;

	internal double double_4 = -1.0;

	internal double double_5 = -1.0;

	[SpecialName]
	internal string method_0()
	{
		return string_0;
	}

	[SpecialName]
	internal void method_1(string string_4)
	{
		string key;
		if ((key = string_4) != null)
		{
			if (Class1742.dictionary_125 == null)
			{
				Class1742.dictionary_125 = new Dictionary<string, int>(18)
				{
					{ "LH", 0 },
					{ "CH", 1 },
					{ "RH", 2 },
					{ "LHEVEN", 3 },
					{ "CHEVEN", 4 },
					{ "RHEVEN", 5 },
					{ "LHFIRST", 6 },
					{ "CHFIRST", 7 },
					{ "RHFIRST", 8 },
					{ "LF", 9 },
					{ "CF", 10 },
					{ "RF", 11 },
					{ "LFEVEN", 12 },
					{ "CFEVEN", 13 },
					{ "RFEVEN", 14 },
					{ "LFFIRST", 15 },
					{ "CFFIRST", 16 },
					{ "RFFIRST", 17 }
				};
			}
			if (Class1742.dictionary_125.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
				case 13:
				case 14:
				case 15:
				case 16:
				case 17:
					string_0 = string_4;
					return;
				}
			}
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid sectionId of Header Footer image");
	}

	internal void method_2(Picture picture_0, int int_0)
	{
		if (string_2 != null)
		{
			smethod_0(string_2, picture_0, int_0);
		}
		if (double_1 > 0.0)
		{
			picture_0.FormatPicture.BottomCrop = double_1;
		}
		if (double_2 > 0.0)
		{
			picture_0.FormatPicture.LeftCrop = double_2;
		}
		if (double_3 > 0.0)
		{
			picture_0.FormatPicture.RightCrop = double_3;
		}
		if (double_0 > 0.0)
		{
			picture_0.FormatPicture.TopCrop = double_0;
		}
	}

	internal static void smethod_0(string string_4, Shape shape_0, int int_0)
	{
		string[] array = string_4.Split(';');
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split(':');
			if (array2.Length == 2)
			{
				switch (array2[0].Trim())
				{
				case "height":
					shape_0.HeightInch = Class1613.smethod_1(array2[1], "in", int_0);
					break;
				case "width":
					shape_0.WidthInch = Class1613.smethod_1(array2[1], "in", int_0);
					break;
				}
			}
		}
	}
}
