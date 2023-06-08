using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using ns1;
using ns19;
using ns3;

namespace ns32;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct37
{
	public static Size smethod_0(Interface42 interface42_0, string string_0, int int_0, Font font_0, SizeF sizeF_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		Size result = smethod_1(interface42_0, string_0, font_0, sizeF_0, enum82_0, enum82_1);
		switch (Math.Abs(int_0))
		{
		default:
		{
			SizeF sizeF_ = interface42_0.imethod_41(string_0, font_0, new PointF(0f, 0f), new StringFormat(StringFormat.GenericTypographic));
			return smethod_2(sizeF_, sizeF_0, Math.Abs(int_0));
		}
		case 255:
		{
			Size result2 = smethod_3(interface42_0, "a", font_0);
			result2.Height = string_0.Length * result2.Height;
			return result2;
		}
		case 90:
		{
			Size size = smethod_1(interface42_0, string_0, font_0, new SizeF((int)sizeF_0.Height, (int)sizeF_0.Width), enum82_0, enum82_1);
			return new Size(size.Height, size.Width);
		}
		case 0:
			return result;
		}
	}

	private static Size smethod_1(Interface42 interface42_0, string string_0, Font font_0, SizeF sizeF_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = smethod_8(enum82_0);
		stringFormat.LineAlignment = smethod_8(enum82_1);
		stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
		SizeF sizeF = interface42_0.imethod_42(string_0, font_0, sizeF_0, stringFormat);
		int width = Struct40.smethod_3(sizeF.Width);
		int height = Struct40.smethod_3(sizeF.Height);
		return new Size(width, height);
	}

	private static Size smethod_2(SizeF sizeF_0, SizeF sizeF_1, int int_0)
	{
		double num = (double)Math.Abs(int_0 % 90) / 180.0 * Math.PI;
		double num2 = (double)sizeF_0.Width * Math.Cos(num) + (double)sizeF_0.Height * Math.Sin(num);
		double num3 = (double)sizeF_0.Width * Math.Sin(num) + (double)sizeF_0.Height * Math.Cos(num);
		if (num2 > (double)sizeF_1.Width)
		{
			num3 = (double)sizeF_1.Width * num3 / num2;
			num2 = sizeF_1.Width;
		}
		if (num3 > (double)sizeF_1.Height)
		{
			num2 = (double)sizeF_1.Height * num2 / num3;
			num3 = sizeF_1.Height;
		}
		return new Size(Struct40.smethod_3(num2), Struct40.smethod_3(num3));
	}

	internal static Size smethod_3(Interface42 interface42_0, string string_0, Font font_0)
	{
		SizeF sizeF = interface42_0.imethod_39(string_0, font_0);
		int width = Struct40.smethod_3(sizeF.Width);
		int height = Struct40.smethod_3(sizeF.Height);
		return new Size(width, height);
	}

	public static Size smethod_4(Interface42 interface42_0, string string_0, int int_0, Font font_0, SizeF sizeF_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		switch (Math.Abs(int_0))
		{
		default:
		{
			SizeF sizeF_ = interface42_0.imethod_41(string_0, font_0, new PointF(0f, 0f), new StringFormat(StringFormat.GenericTypographic));
			return smethod_2(sizeF_, sizeF_0, Math.Abs(int_0));
		}
		case 90:
		{
			Size size = smethod_13(interface42_0, string_0, font_0, new Size((int)sizeF_0.Height, (int)sizeF_0.Width), enum82_0, enum82_1);
			return new Size(size.Height, size.Width);
		}
		case 0:
			return smethod_5(interface42_0, string_0, font_0, sizeF_0, enum82_0, enum82_1);
		}
	}

	private static Size smethod_5(Interface42 interface42_0, string string_0, Font font_0, SizeF sizeF_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
		stringFormat.Alignment = smethod_8(enum82_0);
		stringFormat.LineAlignment = smethod_8(enum82_1);
		SizeF sizeF = interface42_0.imethod_42(string_0, font_0, sizeF_0, stringFormat);
		int width = Struct40.smethod_3(sizeF.Width);
		int height = Struct40.smethod_3(sizeF.Height);
		return new Size(width, height);
	}

	public static SizeF smethod_6(Interface42 interface42_0, string string_0, Font font_0)
	{
		StringFormat stringFormat_ = new StringFormat(StringFormat.GenericTypographic);
		SizeF sizeF = interface42_0.imethod_43(string_0, font_0, int.MaxValue, stringFormat_);
		int num = Struct40.smethod_3(sizeF.Width);
		int num2 = Struct40.smethod_3(sizeF.Height);
		return new SizeF(num, num2);
	}

	public static SizeF smethod_7(Interface42 interface42_0, string string_0, Font font_0, SizeF sizeF_0)
	{
		sizeF_0 = new SizeF(sizeF_0.Width, sizeF_0.Height);
		int num = Struct40.smethod_3(interface42_0.imethod_0().imethod_2(font_0));
		if (string_0 != null && string_0.Length != 0)
		{
			Regex regex = new Regex("\\n");
			Regex regex2 = new Regex("^\\s{1,}$");
			if (!regex2.IsMatch(string_0) && regex2.IsMatch(string_0.Substring(string_0.Length - 1)))
			{
				string_0 += "|";
			}
			if (!regex.IsMatch(string_0) && regex2.IsMatch(string_0))
			{
				SizeF result = interface42_0.imethod_41(string_0, font_0, new PointF(0f, 0f), new StringFormat(StringFormatFlags.MeasureTrailingSpaces));
				if (result.Height > (float)num * 1.5f)
				{
					return result;
				}
				string text = "aaaaaaaaaa";
				string string_ = text + string_0 + text;
				SizeF sizeF_ = new SizeF(2.1474836E+09f, 2.1474836E+09f);
				SizeF sizeF = smethod_7(interface42_0, text, font_0, sizeF_);
				SizeF sizeF2 = smethod_7(interface42_0, string_, font_0, sizeF_);
				float width = ((sizeF2.Width - 2f * sizeF.Width > 0f) ? (sizeF2.Width - 2f * sizeF.Width) : ((float)num / 5f));
				return new SizeF(width, result.Height);
			}
			StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
			stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
			SizeF result2 = interface42_0.imethod_42(string_0, font_0, sizeF_0, stringFormat);
			bool flag = false;
			if (result2.Height < (float)num * 1.5f)
			{
				string_0 += "|";
				sizeF_0.Width += num;
				result2 = interface42_0.imethod_42(string_0, font_0, sizeF_0, stringFormat);
				flag = true;
			}
			int num2 = Struct40.smethod_3(result2.Height);
			if (num2 >= 1 && result2.Width >= 1f)
			{
				int num3 = (int)((double)result2.Width * 0.1);
				if (num3 < 10)
				{
					num3 = 10;
				}
				Bitmap bitmap = new Bitmap(num3, num2);
				Graphics graphics = Graphics.FromImage(bitmap);
				float num4 = Struct40.smethod_3(result2.Width);
				if (!flag)
				{
					graphics.Clear(Color.White);
					graphics.DrawString(layoutRectangle: new RectangleF((float)num3 - num4, 0f, num4, num2), s: string_0, font: font_0, brush: Brushes.Black, format: stringFormat);
					int num5 = num3 - 1;
					while (num5 >= 0)
					{
						num4 -= 1f;
						int i;
						for (i = 0; i < num2 && bitmap.GetPixel(num5, i).R == byte.MaxValue; i++)
						{
						}
						if (i >= num2)
						{
							num5--;
							continue;
						}
						num4 += 1f;
						break;
					}
				}
				else
				{
					graphics.Clear(Color.White);
					graphics.DrawString(string_0, font_0, Brushes.Black, (float)num3 - num4, 0f, stringFormat);
					for (int num6 = num3 - 1; num6 >= 0; num6--)
					{
						num4 -= 1f;
						if (bitmap.GetPixel(num6, num / 2).R != byte.MaxValue)
						{
							break;
						}
					}
				}
				bitmap?.Dispose();
				graphics?.Dispose();
				return new SizeF(num4, num2);
			}
			return result2;
		}
		return new SizeF(0f, num);
	}

	public static StringAlignment smethod_8(Enum82 enum82_0)
	{
		switch (enum82_0)
		{
		case Enum82.const_1:
			return StringAlignment.Center;
		default:
			return StringAlignment.Center;
		case Enum82.const_0:
		case Enum82.const_8:
			return StringAlignment.Far;
		case Enum82.const_7:
		case Enum82.const_9:
			return StringAlignment.Near;
		}
	}

	public static float smethod_9(Interface42 interface42_0, string string_0, Font font_0)
	{
		Regex regex = new Regex("\\s+");
		string[] array = regex.Split(string_0);
		float num = 0f;
		for (int i = 0; i < array.Length; i++)
		{
			Size size = smethod_3(interface42_0, array[i], font_0);
			if ((float)size.Width > num)
			{
				num = size.Width;
			}
		}
		return num;
	}

	public static SizeF smethod_10(Interface42 interface42_0, string string_0, Font font_0)
	{
		Size size_ = new Size(int.MaxValue, int.MaxValue);
		Size size = smethod_3(interface42_0, string_0, font_0);
		SizeF sizeF = smethod_14(interface42_0, string_0, font_0, size_);
		return new SizeF((float)size.Width - sizeF.Width, (float)size.Height - sizeF.Height);
	}

	public static Size smethod_11(Interface42 interface42_0, string string_0, int int_0, Font font_0, Size size_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		SizeF sizeF_ = new SizeF(size_0.Width, size_0.Height);
		return smethod_0(interface42_0, string_0, int_0, font_0, sizeF_, enum82_0, enum82_1);
	}

	public static Size smethod_12(Interface42 interface42_0, string string_0, int int_0, Font font_0, Size size_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		SizeF sizeF_ = new SizeF(size_0.Width, size_0.Height);
		return smethod_4(interface42_0, string_0, int_0, font_0, sizeF_, enum82_0, enum82_1);
	}

	public static Size smethod_13(Interface42 interface42_0, string string_0, Font font_0, Size size_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		SizeF sizeF_ = new SizeF(size_0.Width, size_0.Height);
		return smethod_5(interface42_0, string_0, font_0, sizeF_, enum82_0, enum82_1);
	}

	public static SizeF smethod_14(Interface42 interface42_0, string string_0, Font font_0, Size size_0)
	{
		SizeF sizeF_ = new SizeF(size_0.Width, size_0.Height);
		return smethod_7(interface42_0, string_0, font_0, sizeF_);
	}

	public static void smethod_15(Interface42 interface42_0, string string_0, Font font_0, Color color_0, float float_0, float float_1, float float_2, float float_3)
	{
		SizeF sizeF = interface42_0.imethod_39(string_0.Substring(0, 1), font_0);
		using Brush brush_ = new SolidBrush(color_0);
		for (int i = 0; i < string_0.Length; i++)
		{
			string string_ = string_0.Substring(i, 1);
			SizeF sizeF2 = interface42_0.imethod_39(string_, font_0);
			if (!(sizeF.Height * (float)(i + 1) > float_3))
			{
				if (smethod_16(string_))
				{
					StringFormat stringFormat = new StringFormat();
					stringFormat.FormatFlags |= StringFormatFlags.DirectionVertical;
					interface42_0.imethod_30(string_, font_0, brush_, float_0 - (sizeF2.Height - sizeF.Width) / 2f, float_1, stringFormat);
				}
				else
				{
					interface42_0.imethod_29(string_, font_0, brush_, float_0 - (sizeF2.Width - sizeF.Width) / 2f, float_1);
				}
				float_1 += sizeF.Height;
				continue;
			}
			break;
		}
	}

	private static bool smethod_16(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_30 == null)
			{
				Class1742.dictionary_30 = new Dictionary<string, int>(12)
				{
					{ "(", 0 },
					{ ")", 1 },
					{ "[", 2 },
					{ "]", 3 },
					{ "{", 4 },
					{ "}", 5 },
					{ "<", 6 },
					{ ">", 7 },
					{ "（", 8 },
					{ "）", 9 },
					{ "《", 10 },
					{ "》", 11 }
				};
			}
			if (Class1742.dictionary_30.TryGetValue(key, out var value))
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
					return true;
				}
			}
		}
		return false;
	}
}
