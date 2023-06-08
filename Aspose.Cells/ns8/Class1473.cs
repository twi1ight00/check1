using System;
using System.Collections;
using System.Drawing;
using Aspose.Cells;
using ns47;

namespace ns8;

internal class Class1473
{
	private Graphics graphics_0;

	private System.Drawing.Font font_0;

	private int int_0 = 96;

	private Hashtable hashtable_0 = new Hashtable();

	private Hashtable hashtable_1 = new Hashtable();

	internal Class1473(Workbook workbook_0)
	{
		Bitmap image = new Bitmap(10, 10);
		graphics_0 = Graphics.FromImage(image);
		font_0 = method_5(workbook_0.Worksheets.DefaultFont);
		int_0 = workbook_0.Worksheets.method_75();
	}

	internal int method_0(Style style_0, string string_0)
	{
		Aspose.Cells.Font font = null;
		if (style_0 != null)
		{
			font = style_0.method_40();
			if (font != null && font.method_21() == 0)
			{
				font = null;
			}
		}
		return method_1(font, string_0);
	}

	internal int method_1(Aspose.Cells.Font font_1, string string_0)
	{
		if (string_0 != null && string_0.Length != 0)
		{
			Class1474 key = new Class1474(font_1, string_0);
			object obj = hashtable_0[key];
			if (obj != null)
			{
				return (int)obj;
			}
			System.Drawing.Font font = font_0;
			if (font_1 != null)
			{
				font = method_5(font_1);
			}
			CharacterRange[] measurableCharacterRanges = new CharacterRange[1]
			{
				new CharacterRange(0, string_0.Length)
			};
			StringFormat stringFormat = new StringFormat();
			stringFormat.SetMeasurableCharacterRanges(measurableCharacterRanges);
			Class1460 @class = Class1462.smethod_3(font.Name, font.Style, bool_0: false);
			float num = @class.method_43(string_0, font.Size);
			return Class1486.smethod_25(int_0, num);
		}
		return 0;
	}

	internal int method_2(Style style_0, string string_0, int int_1)
	{
		Aspose.Cells.Font font = null;
		if (style_0 != null)
		{
			font = style_0.method_40();
			if (font != null && font.method_21() == 0)
			{
				font = null;
			}
		}
		return method_4(font, string_0, int_1);
	}

	internal int method_3(Aspose.Cells.Font font_1, string string_0, int int_1, int int_2)
	{
		string string_ = string_0.Substring(0, int_2);
		int num = method_1(font_1, string_);
		return int_1 - num - 4;
	}

	internal int method_4(Aspose.Cells.Font font_1, string string_0, int int_1)
	{
		Class1474 key = new Class1474(font_1, string_0, int_1);
		object obj = hashtable_1[key];
		if (obj != null)
		{
			return (int)obj;
		}
		int num = method_1(font_1, string_0);
		int num2;
		if (num < int_1)
		{
			num2 = -1;
		}
		else if (num == int_1)
		{
			num2 = 0;
		}
		else
		{
			int length = string_0.Length;
			float num3 = (float)num / (float)length;
			if (num > 1600)
			{
				num3 = method_1(font_1, "A");
			}
			num2 = (int)((float)int_1 / num3);
			if (num2 > length)
			{
				num2 = length;
			}
			int num4 = method_3(font_1, string_0, int_1, num2);
			if ((float)Math.Abs(num4) > num3)
			{
				if (num4 > 0)
				{
					while (num4 > 0)
					{
						num2++;
						num4 = method_3(font_1, string_0, int_1, num2);
					}
					if (num4 <= 0)
					{
						num2--;
					}
				}
				else
				{
					while (num4 < 0)
					{
						num2--;
						num4 = method_3(font_1, string_0, int_1, num2);
					}
				}
			}
		}
		hashtable_1[key] = num2;
		return num2;
	}

	private System.Drawing.Font method_5(Aspose.Cells.Font font_1)
	{
		string familyName = "Arial";
		int num = 10;
		FontStyle fontStyle = FontStyle.Regular;
		if (font_1 != null)
		{
			familyName = font_1.Name;
			num = font_1.Size;
			if (font_1.IsBold)
			{
				fontStyle |= FontStyle.Bold;
			}
			if (font_1.IsItalic)
			{
				fontStyle |= FontStyle.Italic;
			}
			if (font_1.IsStrikeout)
			{
				fontStyle |= FontStyle.Strikeout;
			}
			if (font_1.Underline != 0)
			{
				fontStyle |= FontStyle.Underline;
			}
		}
		return new System.Drawing.Font(familyName, num, fontStyle, GraphicsUnit.Point);
	}

	internal int method_6(double double_0)
	{
		double num = double_0 * (double)int_0 / 72.0;
		return (int)num;
	}

	internal double method_7(int int_1)
	{
		return (double)int_1 * 72.0 / (double)int_0;
	}
}
