using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using ns19;
using ns3;

namespace ns34;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct61
{
	public static void smethod_0(Interface42 interface42_0, Rectangle rectangle_0, string string_0, int int_0, Font font_0, Color color_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		RectangleF rectangleF_ = new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		smethod_1(interface42_0, rectangleF_, string_0, int_0, font_0, color_0, enum82_0, enum82_1);
	}

	public static void smethod_1(Interface42 interface42_0, RectangleF rectangleF_0, string string_0, int int_0, Font font_0, Color color_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = smethod_13(enum82_0);
		stringFormat.LineAlignment = smethod_13(enum82_1);
		switch (Math.Abs(int_0))
		{
		default:
		{
			double num = Math.Sqrt(Math.Pow(rectangleF_0.Width, 2.0) + Math.Pow(rectangleF_0.Height, 2.0));
			stringFormat.FormatFlags = StringFormatFlags.NoWrap;
			SizeF sizeF = interface42_0.imethod_43(string_0, font_0, (int)num, stringFormat);
			interface42_0.imethod_49(rectangleF_0.Left + rectangleF_0.Width / 2f, rectangleF_0.Top + rectangleF_0.Height / 2f);
			interface42_0.imethod_45(-int_0);
			interface42_0.imethod_27(rectangleF_0: new RectangleF((0f - sizeF.Width) / 2f, (0f - sizeF.Height) / 2f, sizeF.Width, sizeF.Height), string_0: string_0, font_0: font_0, brush_0: new SolidBrush(color_0), stringFormat_0: stringFormat);
			interface42_0.ResetTransform();
			break;
		}
		case 90:
			interface42_0.imethod_49(rectangleF_0.Left + rectangleF_0.Width / 2f, rectangleF_0.Top + rectangleF_0.Height / 2f);
			interface42_0.imethod_45(-int_0);
			rectangleF_0 = new RectangleF((0f - rectangleF_0.Height) / 2f, (0f - rectangleF_0.Width) / 2f, rectangleF_0.Height, rectangleF_0.Width);
			interface42_0.imethod_27(string_0, font_0, new SolidBrush(color_0), rectangleF_0, stringFormat);
			interface42_0.ResetTransform();
			break;
		case 0:
			interface42_0.imethod_27(string_0, font_0, new SolidBrush(color_0), rectangleF_0, stringFormat);
			break;
		}
	}

	public static Size smethod_2(Interface42 interface42_0, string string_0, int int_0, Font font_0, Size size_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		SizeF sizeF_ = new SizeF(size_0.Width, size_0.Height);
		return smethod_3(interface42_0, string_0, int_0, font_0, sizeF_, enum82_0, enum82_1);
	}

	public static Size smethod_3(Interface42 interface42_0, string string_0, int int_0, Font font_0, SizeF sizeF_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		if (string_0.EndsWith("\n"))
		{
			string_0 += " ";
		}
		Size result = smethod_4(interface42_0, string_0, font_0, sizeF_0, enum82_0, enum82_1);
		switch (Math.Abs(int_0))
		{
		default:
		{
			SizeF sizeF_ = interface42_0.imethod_41(string_0, font_0, new PointF(0f, 0f), new StringFormat(StringFormat.GenericTypographic));
			return smethod_5(sizeF_, sizeF_0, Math.Abs(int_0));
		}
		case 90:
		{
			Size size = smethod_4(interface42_0, string_0, font_0, new SizeF((int)sizeF_0.Height, (int)sizeF_0.Width), enum82_0, enum82_1);
			return new Size(size.Height, size.Width);
		}
		case 0:
			return result;
		}
	}

	private static Size smethod_4(Interface42 interface42_0, string string_0, Font font_0, SizeF sizeF_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = smethod_13(enum82_0);
		stringFormat.LineAlignment = smethod_13(enum82_1);
		SizeF sizeF = interface42_0.imethod_42(string_0, font_0, sizeF_0, stringFormat);
		int width = Struct63.smethod_3(sizeF.Width);
		int height = Struct63.smethod_3(sizeF.Height);
		return new Size(width, height);
	}

	private static Size smethod_5(SizeF sizeF_0, SizeF sizeF_1, int int_0)
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
		return new Size(Struct63.smethod_3(num2), Struct63.smethod_3(num3));
	}

	internal static Size smethod_6(Interface42 interface42_0, string string_0, Font font_0)
	{
		SizeF sizeF = interface42_0.imethod_39(string_0, font_0);
		int width = Struct63.smethod_3(sizeF.Width);
		int height = Struct63.smethod_3(sizeF.Height);
		return new Size(width, height);
	}

	public static Size smethod_7(Interface42 interface42_0, string string_0, int int_0, Font font_0, Size size_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		SizeF sizeF_ = new SizeF(size_0.Width, size_0.Height);
		return smethod_8(interface42_0, string_0, int_0, font_0, sizeF_, enum82_0, enum82_1);
	}

	public static Size smethod_8(Interface42 interface42_0, string string_0, int int_0, Font font_0, SizeF sizeF_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		switch (Math.Abs(int_0))
		{
		default:
		{
			SizeF sizeF_ = interface42_0.imethod_41(string_0, font_0, new PointF(0f, 0f), new StringFormat(StringFormat.GenericTypographic));
			return smethod_5(sizeF_, sizeF_0, Math.Abs(int_0));
		}
		case 90:
		{
			Size size = smethod_9(interface42_0, string_0, font_0, new SizeF((int)sizeF_0.Height, (int)sizeF_0.Width), enum82_0, enum82_1);
			return new Size(size.Height, size.Width);
		}
		case 0:
			return smethod_9(interface42_0, string_0, font_0, sizeF_0, enum82_0, enum82_1);
		}
	}

	private static Size smethod_9(Interface42 interface42_0, string string_0, Font font_0, SizeF sizeF_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
		stringFormat.Alignment = smethod_13(enum82_0);
		stringFormat.LineAlignment = smethod_13(enum82_1);
		SizeF sizeF = interface42_0.imethod_42(string_0, font_0, sizeF_0, stringFormat);
		int width = Struct63.smethod_3(sizeF.Width);
		int height = Struct63.smethod_3(sizeF.Height);
		return new Size(width, height);
	}

	public static SizeF smethod_10(Interface42 interface42_0, string string_0, Font font_0)
	{
		StringFormat stringFormat_ = new StringFormat(StringFormat.GenericTypographic);
		SizeF sizeF = interface42_0.imethod_43(string_0, font_0, int.MaxValue, stringFormat_);
		int num = Struct63.smethod_3(sizeF.Width);
		int num2 = Struct63.smethod_3(sizeF.Height);
		return new SizeF(num, num2);
	}

	public static SizeF smethod_11(Interface42 interface42_0, string string_0, Font font_0, Size size_0)
	{
		SizeF sizeF_ = new SizeF(size_0.Width, size_0.Height);
		return smethod_12(interface42_0, string_0, font_0, sizeF_);
	}

	public static SizeF smethod_12(Interface42 interface42_0, string string_0, Font font_0, SizeF sizeF_0)
	{
		sizeF_0 = new SizeF(sizeF_0.Width, sizeF_0.Height);
		int num = Struct63.smethod_3(interface42_0.imethod_0().imethod_2(font_0));
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
				SizeF sizeF = smethod_12(interface42_0, text, font_0, sizeF_);
				SizeF sizeF2 = smethod_12(interface42_0, string_, font_0, sizeF_);
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
			int num2 = Struct63.smethod_3(result2.Height);
			if (num2 >= 1 && result2.Width >= 1f)
			{
				int num3 = (int)((double)result2.Width * 0.1);
				if (num3 < 10)
				{
					num3 = 10;
				}
				Bitmap bitmap = new Bitmap(num3, num2);
				Graphics graphics = Graphics.FromImage(bitmap);
				float num4 = Struct63.smethod_3(result2.Width);
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

	public static StringAlignment smethod_13(Enum82 enum82_0)
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

	public static float smethod_14(Interface42 interface42_0, string string_0, Font font_0, bool bool_0)
	{
		Regex regex = new Regex("\\s+");
		string[] array = regex.Split(string_0);
		float num = 0f;
		for (int i = 0; i < array.Length; i++)
		{
			SizeF sizeF = ((!bool_0) ? interface42_0.imethod_39(array[i], font_0) : Struct63.smethod_19(smethod_6(interface42_0, array[i], font_0)));
			if (sizeF.Width > num)
			{
				num = sizeF.Width;
			}
		}
		return num;
	}

	public static SizeF smethod_15(Interface42 interface42_0, string string_0, Font font_0)
	{
		Size size_ = new Size(int.MaxValue, int.MaxValue);
		Size size = smethod_6(interface42_0, string_0, font_0);
		SizeF sizeF = smethod_11(interface42_0, string_0, font_0, size_);
		return new SizeF((float)size.Width - sizeF.Width, (float)size.Height - sizeF.Height);
	}
}
