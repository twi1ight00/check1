using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using ns19;

namespace ns5;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct69
{
	internal static Font font_0 = new Font("Arial", 8f);

	internal static Brush smethod_0(Class884 class884_0, GraphicsPath graphicsPath_0)
	{
		if (class884_0.method_0())
		{
			return new SolidBrush(Color.Empty);
		}
		Brush brush = null;
		if (class884_0.method_5())
		{
			return class884_0.FillFormat.method_3(graphicsPath_0, null, bool_0: false, 1f);
		}
		return new SolidBrush(class884_0.method_2());
	}

	internal static Brush smethod_1(Class884 class884_0, GraphicsPath graphicsPath_0, float float_0, float float_1)
	{
		if (class884_0.method_0())
		{
			return new SolidBrush(Color.Empty);
		}
		Brush brush = null;
		if (class884_0.method_5())
		{
			return class884_0.FillFormat.method_4(class884_0, graphicsPath_0, float_0, float_1);
		}
		return new SolidBrush(class884_0.method_2());
	}

	internal static Brush smethod_2(Class884 class884_0, RectangleF rectangleF_0)
	{
		if (class884_0.method_0())
		{
			return new SolidBrush(Color.Empty);
		}
		Brush brush = null;
		if (class884_0.method_5())
		{
			return class884_0.FillFormat.method_5(rectangleF_0);
		}
		return new SolidBrush(class884_0.method_2());
	}

	internal static Brush smethod_3(Class884 class884_0, RectangleF rectangleF_0, float float_0, float float_1)
	{
		if (class884_0.method_0())
		{
			return new SolidBrush(Color.Empty);
		}
		Brush brush = null;
		if (class884_0.method_5())
		{
			return class884_0.FillFormat.method_5(rectangleF_0);
		}
		return new SolidBrush(smethod_18(class884_0, float_0, float_1));
	}

	internal static Pen smethod_4(Class889 class889_0)
	{
		if (class889_0.method_0())
		{
			return new Pen(Color.Empty);
		}
		Pen pen = null;
		if (class889_0.Pattern != 0)
		{
			pen = new Pen(class889_0.ForeColor, class889_0.Weight);
		}
		else
		{
			pen = new Pen(class889_0.ForeColor, class889_0.Weight);
			switch (class889_0.DashStyle)
			{
			case Enum97.const_0:
				pen.DashStyle = DashStyle.Custom;
				pen.DashPattern = new float[2] { 4f, 4f };
				break;
			case Enum97.const_1:
				pen.DashStyle = DashStyle.Custom;
				pen.DashPattern = new float[4] { 4f, 3f, 1f, 3f };
				break;
			case Enum97.const_2:
				pen.DashStyle = DashStyle.Dot;
				break;
			case Enum97.const_3:
				pen.DashStyle = DashStyle.Dot;
				break;
			case Enum97.const_4:
				pen.DashStyle = DashStyle.Dot;
				break;
			case Enum97.const_5:
				pen.DashStyle = DashStyle.Dot;
				pen.DashCap = DashCap.Round;
				break;
			case Enum97.const_6:
				pen.DashStyle = DashStyle.Solid;
				break;
			case Enum97.const_7:
				pen.DashStyle = DashStyle.Dot;
				break;
			}
		}
		switch (class889_0.Style)
		{
		case Enum99.const_1:
			pen.CompoundArray = new float[6]
			{
				0f,
				1f / 6f,
				1f / 3f,
				2f / 3f,
				5f / 6f,
				1f
			};
			break;
		case Enum99.const_2:
			pen.CompoundArray = new float[4] { 0f, 0.2f, 0.4f, 1f };
			break;
		case Enum99.const_3:
			pen.CompoundArray = new float[4] { 0f, 0.6f, 0.8f, 1f };
			break;
		case Enum99.const_4:
			pen.CompoundArray = new float[4]
			{
				0f,
				1f / 3f,
				2f / 3f,
				1f
			};
			break;
		}
		smethod_5(pen, class889_0);
		return pen;
	}

	private static void smethod_5(Pen pen_0, Class889 class889_0)
	{
		if (class889_0.method_2() != 0)
		{
			smethod_19(pen_0, class889_0.method_2(), class889_0.method_4(), class889_0.method_6(), bool_0: true, class889_0);
		}
		if (class889_0.method_8() != 0)
		{
			smethod_19(pen_0, class889_0.method_8(), class889_0.method_10(), class889_0.method_12(), bool_0: false, class889_0);
		}
	}

	internal static void smethod_6(Interface42 interface42_0, Class898 class898_0, RectangleF rectangleF_0, string string_0, Enum107 enum107_0, Font font_1, Color color_0, Enum104 enum104_0, Enum104 enum104_1)
	{
		if (class898_0.method_10().Count > 0)
		{
			smethod_7(interface42_0, class898_0, rectangleF_0);
		}
		else if (string_0 != null && !(string_0 == ""))
		{
			int num = 0;
			smethod_8(interface42_0, class898_0, rectangleF_0, string_0, enum107_0 switch
			{
				Enum107.const_0 => -90, 
				Enum107.const_1 => 90, 
				Enum107.const_2 => 0, 
				Enum107.const_3 => 0, 
				_ => 0, 
			}, font_1, color_0, enum104_0, enum104_1);
		}
	}

	private static void smethod_7(Interface42 interface42_0, Class898 class898_0, RectangleF rectangleF_0)
	{
		Class891 @class = new Class891();
		@class.TextDirection = class898_0.TextDirection;
		@class.TextHorizontalAlignment = smethod_9(class898_0.TextHorizontalAlignment);
		@class.method_0(class898_0.method_8());
		@class.TextVerticalAlignment = smethod_9(class898_0.TextVerticalAlignment);
		if (class898_0.method_8() == Enum107.const_1)
		{
			SizeF sizeF = smethod_11(interface42_0, class898_0.Text, class898_0.Font, new SizeF(2.1474836E+09f, 2.1474836E+09f));
			rectangleF_0 = new RectangleF(rectangleF_0.X, rectangleF_0.Y, sizeF.Width, rectangleF_0.Height);
		}
		Class893 class2 = new Class893(rectangleF_0, @class, class898_0.method_10(), class898_0.Font);
		Enum104 textVerticalAlignment = class898_0.TextVerticalAlignment;
		Enum104 textHorizontalAlignment = class898_0.TextHorizontalAlignment;
		if (class898_0.method_8() == Enum107.const_1 || class898_0.method_8() == Enum107.const_0)
		{
			float angle = -90f;
			if (class898_0.method_8() == Enum107.const_0)
			{
				angle = 90f;
			}
			Point point = new Point((int)(rectangleF_0.Left + rectangleF_0.Width / 2f), (int)(rectangleF_0.Top + rectangleF_0.Height / 2f));
			Matrix matrix = new Matrix();
			matrix.RotateAt(angle, new PointF(point.X, point.Y));
			if (textVerticalAlignment == Enum104.const_1 && textHorizontalAlignment == Enum104.const_1)
			{
				matrix.Translate(0f, 0f - ((float)point.X - class898_0.Width / 2f));
			}
			else if (textVerticalAlignment == Enum104.const_9 && textHorizontalAlignment == Enum104.const_1)
			{
				matrix.Translate(rectangleF_0.Height / 2f - rectangleF_0.Width / 2f, rectangleF_0.Height / 2f - ((float)point.X - class898_0.Width / 2f) - 5f);
			}
			else if (textVerticalAlignment == Enum104.const_9 && textHorizontalAlignment == Enum104.const_7)
			{
				matrix.Translate(rectangleF_0.Height / 2f - rectangleF_0.Width / 4f, rectangleF_0.Height / 2f - (float)point.X - 5f);
			}
			else if (textVerticalAlignment == Enum104.const_9 && textHorizontalAlignment == Enum104.const_8)
			{
				if (class898_0.Width > rectangleF_0.Width)
				{
					matrix.Translate(rectangleF_0.Height / 2f - rectangleF_0.Width / 2f, class898_0.Height / 2f + class898_0.Width / 2f);
				}
				else
				{
					matrix.Translate(rectangleF_0.Height / 2f - rectangleF_0.Width / 2f, class898_0.Height / 2f - class898_0.Width / 2f);
				}
			}
			else if (textVerticalAlignment == Enum104.const_9 && textHorizontalAlignment == Enum104.const_6)
			{
				matrix.Translate(rectangleF_0.Height / 2f - rectangleF_0.Width / 4f, rectangleF_0.Height / 2f - (float)point.X - 5f);
			}
			else if (textVerticalAlignment == Enum104.const_1 && textHorizontalAlignment == Enum104.const_7)
			{
				matrix.Translate(0f, 0f - ((float)point.X - rectangleF_0.Left));
			}
			else if (textVerticalAlignment == Enum104.const_1 && textHorizontalAlignment == Enum104.const_8)
			{
				matrix.Translate(0f, 0f - ((float)point.X - class898_0.Width + rectangleF_0.Left));
			}
			else if (textVerticalAlignment == Enum104.const_1 && textHorizontalAlignment == Enum104.const_6)
			{
				matrix.Translate(0f, 0f - ((float)point.X - rectangleF_0.Left));
			}
			else if (textVerticalAlignment == Enum104.const_0 && textHorizontalAlignment == Enum104.const_7)
			{
				if (rectangleF_0.Width > class898_0.Width)
				{
					matrix.Translate(0f - (rectangleF_0.Height / 2f - rectangleF_0.Width / 2f), 0f - (rectangleF_0.Height / 2f + class898_0.Width));
				}
				else
				{
					matrix.Translate(0f - (rectangleF_0.Height / 2f - rectangleF_0.Width / 2f), 0f - (rectangleF_0.Height / 2f + rectangleF_0.Width / 2f - rectangleF_0.Left));
				}
			}
			else if (textVerticalAlignment == Enum104.const_0 && textHorizontalAlignment == Enum104.const_1)
			{
				if (rectangleF_0.Width > class898_0.Width)
				{
					matrix.Translate(0f - (rectangleF_0.Height / 2f - rectangleF_0.Width / 2f), 0f - (rectangleF_0.Height / 2f + class898_0.Width / 2f - rectangleF_0.Left));
				}
				else
				{
					matrix.Translate(0f - (rectangleF_0.Height / 2f - rectangleF_0.Width / 2f), 0f - (rectangleF_0.Height / 2f - (class898_0.Width / 2f - rectangleF_0.Width / 2f) - rectangleF_0.Left));
				}
			}
			else if (textVerticalAlignment == Enum104.const_0 && textHorizontalAlignment == Enum104.const_8)
			{
				if (rectangleF_0.Width > class898_0.Width)
				{
					matrix.Translate(0f - (rectangleF_0.Height / 2f - class898_0.Width), 0f - (rectangleF_0.Height / 2f + class898_0.Width / 2f + rectangleF_0.Left));
				}
				else
				{
					matrix.Translate(0f - (rectangleF_0.Height / 2f - (class898_0.Width - rectangleF_0.Width + 10f)), 0f - (rectangleF_0.Height / 2f - class898_0.Width / 2f - rectangleF_0.Left));
				}
			}
			else if (textVerticalAlignment == Enum104.const_0 && textHorizontalAlignment == Enum104.const_6)
			{
				if (rectangleF_0.Width > class898_0.Width)
				{
					matrix.Translate(0f - (rectangleF_0.Height / 2f - rectangleF_0.Width / 2f), 0f - (rectangleF_0.Height / 2f + class898_0.Width));
				}
				else
				{
					matrix.Translate(0f - (rectangleF_0.Height / 2f - rectangleF_0.Width / 2f), 0f - (rectangleF_0.Height / 2f + rectangleF_0.Width / 2f - rectangleF_0.Left));
				}
			}
			else if (textVerticalAlignment == Enum104.const_6 && textHorizontalAlignment == Enum104.const_7)
			{
				matrix.Translate((float)point.X - rectangleF_0.Height / 2f, (float)point.Y - rectangleF_0.Width / 2f);
			}
			else if (textVerticalAlignment == Enum104.const_6 && textHorizontalAlignment == Enum104.const_1)
			{
				if (class898_0.Width < rectangleF_0.Width)
				{
					matrix.Translate((float)point.X - rectangleF_0.Height / 2f, (float)point.Y - class898_0.Width / 2f);
				}
				else
				{
					float num = (class898_0.Width - rectangleF_0.Width) / 4f;
					matrix.Translate((float)point.X - rectangleF_0.Height / 2f - num, (float)point.Y + num);
				}
			}
			else if (textVerticalAlignment == Enum104.const_6 && textHorizontalAlignment == Enum104.const_8)
			{
				if (class898_0.Width < rectangleF_0.Width)
				{
					matrix.Translate((float)point.X - rectangleF_0.Height / 2f, rectangleF_0.Height / 2f - rectangleF_0.Width / 2f + class898_0.Width / 2f);
				}
				else
				{
					float num2 = class898_0.Width - rectangleF_0.Width;
					matrix.Translate((float)point.X - rectangleF_0.Height / 2f - num2, (float)point.Y + class898_0.Width / 2f);
				}
			}
			else if (textVerticalAlignment == Enum104.const_6 && textHorizontalAlignment == Enum104.const_6)
			{
				matrix.Translate((float)point.X - rectangleF_0.Height / 2f, (float)point.Y - rectangleF_0.Width / 2f);
			}
			interface42_0.imethod_58(matrix);
		}
		class2.method_0(interface42_0);
	}

	private static void smethod_8(Interface42 interface42_0, Class898 class898_0, RectangleF rectangleF_0, string string_0, int int_0, Font font_1, Color color_0, Enum104 enum104_0, Enum104 enum104_1)
	{
		StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
		SizeF sizeF = smethod_11(interface42_0, string_0, font_1, new SizeF(2.1474836E+09f, 2.1474836E+09f));
		if (class898_0.method_8() == Enum107.const_3)
		{
			float num = 12f;
			int length = string_0.Length;
			int num2 = length * 2 - 1;
			float num3 = sizeF.Width / (float)length * (float)num2;
			if (enum104_1 == Enum104.const_1 && enum104_0 == Enum104.const_1)
			{
				rectangleF_0 = new RectangleF(rectangleF_0.Width / 2f - num / 2f, rectangleF_0.Y, num, rectangleF_0.Height);
			}
			else if (enum104_1 == Enum104.const_9 && enum104_0 == Enum104.const_7)
			{
				rectangleF_0 = new RectangleF(rectangleF_0.X, rectangleF_0.Y, num, rectangleF_0.Height);
			}
			else if (enum104_1 == Enum104.const_9 && enum104_0 == Enum104.const_1)
			{
				rectangleF_0 = new RectangleF(rectangleF_0.Width / 2f - num / 2f, rectangleF_0.Y, num, rectangleF_0.Height);
			}
			else if (enum104_1 == Enum104.const_9 && enum104_0 == Enum104.const_8)
			{
				rectangleF_0 = new RectangleF(rectangleF_0.Width - num / 2f, rectangleF_0.Y, num, rectangleF_0.Height);
			}
			else if (enum104_1 == Enum104.const_9 && enum104_0 == Enum104.const_6)
			{
				rectangleF_0 = new RectangleF(rectangleF_0.Width - num, rectangleF_0.Y, num, rectangleF_0.Height);
			}
			else if (enum104_1 == Enum104.const_1 && enum104_0 == Enum104.const_7)
			{
				rectangleF_0 = new RectangleF(rectangleF_0.X, rectangleF_0.Height / 2f - num3 / 2f, num, rectangleF_0.Height);
			}
			else if (enum104_1 == Enum104.const_1 && enum104_0 == Enum104.const_8)
			{
				rectangleF_0 = new RectangleF(rectangleF_0.Width - num / 2f, rectangleF_0.Height / 2f - num3 / 2f, num, rectangleF_0.Height);
			}
			else if (enum104_1 == Enum104.const_1 && enum104_0 == Enum104.const_6)
			{
				rectangleF_0 = new RectangleF(rectangleF_0.Width - num, rectangleF_0.Height / 2f - num3 / 2f, num, rectangleF_0.Height);
			}
			else if (enum104_1 == Enum104.const_0 && enum104_0 == Enum104.const_7)
			{
				rectangleF_0 = new RectangleF(rectangleF_0.X, rectangleF_0.Height / 2f, num, rectangleF_0.Height);
			}
			else if (enum104_1 == Enum104.const_0 && enum104_0 == Enum104.const_1)
			{
				rectangleF_0 = new RectangleF(rectangleF_0.Width / 2f - num / 2f, rectangleF_0.Height / 2f, num, rectangleF_0.Height);
			}
			else if (enum104_1 == Enum104.const_0 && enum104_0 == Enum104.const_8)
			{
				rectangleF_0 = new RectangleF(rectangleF_0.Width - num / 2f, rectangleF_0.Height / 2f, num, rectangleF_0.Height);
			}
			else if (enum104_1 == Enum104.const_0 && enum104_0 == Enum104.const_6)
			{
				rectangleF_0 = new RectangleF(rectangleF_0.Width - num, rectangleF_0.Height / 2f, num, rectangleF_0.Height);
			}
			else if (enum104_1 == Enum104.const_6 && enum104_0 == Enum104.const_7)
			{
				rectangleF_0 = new RectangleF(rectangleF_0.X, rectangleF_0.Y, num, rectangleF_0.Height);
			}
			else if (enum104_1 == Enum104.const_6 && enum104_0 == Enum104.const_1)
			{
				rectangleF_0 = new RectangleF(rectangleF_0.Width / 2f - num / 2f, rectangleF_0.Y, num, rectangleF_0.Height);
			}
			else if (enum104_1 == Enum104.const_6 && enum104_0 == Enum104.const_8)
			{
				rectangleF_0 = new RectangleF(rectangleF_0.Width - num / 2f, rectangleF_0.Y, num, rectangleF_0.Height);
			}
			else if (enum104_1 == Enum104.const_6 && enum104_0 == Enum104.const_6)
			{
				rectangleF_0 = new RectangleF(rectangleF_0.Width - num, rectangleF_0.Y, num, rectangleF_0.Height);
			}
		}
		else
		{
			stringFormat.Alignment = smethod_9(enum104_0);
			stringFormat.LineAlignment = smethod_9(enum104_1);
		}
		switch (Math.Abs(int_0))
		{
		default:
		{
			double num4 = Math.Sqrt(Math.Pow(rectangleF_0.Width, 2.0) + Math.Pow(rectangleF_0.Height, 2.0));
			stringFormat.FormatFlags = StringFormatFlags.NoWrap;
			SizeF sizeF2 = interface42_0.imethod_43(string_0, font_1, (int)num4, stringFormat);
			interface42_0.imethod_49(rectangleF_0.Left + rectangleF_0.Width / 2f, rectangleF_0.Top + rectangleF_0.Height / 2f);
			interface42_0.imethod_45(-int_0);
			interface42_0.imethod_27(rectangleF_0: new RectangleF((0f - sizeF2.Width) / 2f, (0f - sizeF2.Height) / 2f, sizeF2.Width, sizeF2.Height), string_0: string_0, font_0: font_1, brush_0: new SolidBrush(color_0), stringFormat_0: stringFormat);
			interface42_0.ResetTransform();
			break;
		}
		case 90:
		{
			Point point = new Point((int)(rectangleF_0.Left + rectangleF_0.Width / 2f), (int)(rectangleF_0.Top + rectangleF_0.Height / 2f));
			interface42_0.imethod_49(point.X, point.Y);
			interface42_0.imethod_45(-int_0);
			switch (enum104_1)
			{
			case Enum104.const_9:
				interface42_0.imethod_49(rectangleF_0.Height - sizeF.Width + 10f, 0f);
				break;
			case Enum104.const_0:
				interface42_0.imethod_49(0f - (rectangleF_0.Height - sizeF.Width + 10f), 0f);
				break;
			}
			rectangleF_0 = new RectangleF(0f - rectangleF_0.Height / 2f, 0f - rectangleF_0.Width / 2f, rectangleF_0.Height, rectangleF_0.Width);
			interface42_0.imethod_27(string_0, font_1, new SolidBrush(color_0), rectangleF_0, stringFormat);
			interface42_0.ResetTransform();
			break;
		}
		case 0:
			interface42_0.imethod_27(string_0, font_1, new SolidBrush(color_0), rectangleF_0, stringFormat);
			break;
		}
	}

	public static StringAlignment smethod_9(Enum104 enum104_0)
	{
		switch (enum104_0)
		{
		case Enum104.const_1:
			return StringAlignment.Center;
		default:
			return StringAlignment.Near;
		case Enum104.const_0:
		case Enum104.const_8:
			return StringAlignment.Far;
		case Enum104.const_7:
		case Enum104.const_9:
			return StringAlignment.Near;
		}
	}

	internal static int smethod_10(double double_0)
	{
		return (int)Math.Ceiling(double_0);
	}

	public static SizeF smethod_11(Interface42 interface42_0, string string_0, Font font_1, SizeF sizeF_0)
	{
		int num = smethod_10(interface42_0.imethod_0().imethod_2(font_1));
		if (string_0 != null && string_0.Length != 0)
		{
			Regex regex = new Regex("^\\s{1,}$");
			if (!regex.IsMatch(string_0) && !regex.IsMatch(string_0.Substring(string_0.Length - 1)))
			{
				StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
				stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
				SizeF result = interface42_0.imethod_42(string_0, font_1, sizeF_0, stringFormat);
				bool flag = false;
				if (result.Height < (float)num * 1.5f)
				{
					string_0 += "|";
					sizeF_0.Width += num;
					result = interface42_0.imethod_42(string_0, font_1, sizeF_0, stringFormat);
					flag = true;
				}
				int num2 = smethod_10(result.Height);
				if (num2 >= 1 && result.Width >= 1f)
				{
					int num3 = (int)((double)result.Width * 0.1);
					if (num3 < 10)
					{
						num3 = 10;
					}
					Bitmap bitmap = new Bitmap(num3, num2);
					Graphics graphics = Graphics.FromImage(bitmap);
					float num4 = smethod_10(result.Width);
					if (!flag)
					{
						graphics.Clear(Color.White);
						graphics.DrawString(layoutRectangle: new RectangleF((float)num3 - num4, 0f, num4, num2), s: string_0, font: font_1, brush: Brushes.Black, format: stringFormat);
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
						graphics.DrawString(string_0, font_1, Brushes.Black, (float)num3 - num4, 0f, stringFormat);
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
				return result;
			}
			SizeF result2 = interface42_0.imethod_41(string_0, font_1, new PointF(0f, 0f), new StringFormat(StringFormatFlags.MeasureTrailingSpaces));
			if (result2.Height > (float)num * 1.5f)
			{
				return result2;
			}
			string text = "aaaaaaaaaa";
			string string_ = text + string_0 + text;
			SizeF sizeF_ = new SizeF(2.1474836E+09f, 2.1474836E+09f);
			SizeF sizeF = smethod_11(interface42_0, text, font_1, sizeF_);
			SizeF sizeF2 = smethod_11(interface42_0, string_, font_1, sizeF_);
			float width = ((sizeF2.Width - 2f * sizeF.Width > 0f) ? (sizeF2.Width - 2f * sizeF.Width) : ((float)num / 5f));
			return new SizeF(width, result2.Height);
		}
		return new SizeF(0f, num);
	}

	internal static float smethod_12(Font font_1)
	{
		return font_1.Size / 4f;
	}

	internal static RectangleF smethod_13(Class898 class898_0)
	{
		Class889 line = class898_0.Line;
		ArrayList arrayList = new ArrayList();
		arrayList.Add(new PointF(class898_0.X, class898_0.Y));
		arrayList.Add(new PointF(class898_0.X, class898_0.method_7().Bottom));
		arrayList.Add(new PointF(class898_0.method_7().Right, class898_0.Y));
		arrayList.Add(new PointF(class898_0.method_7().Right, class898_0.method_7().Bottom));
		if (!line.method_0())
		{
			float num = line.Weight;
			float num2 = 0f;
			float num3 = 0f;
			switch (line.method_6())
			{
			case Enum94.const_0:
				num3 = 2f * num;
				break;
			case Enum94.const_1:
				num3 = 3f * num;
				break;
			case Enum94.const_2:
				num3 = 5f * num;
				break;
			}
			switch (line.method_4())
			{
			case Enum96.const_0:
				num2 = 2f * num;
				break;
			case Enum96.const_1:
				num2 = 3f * num;
				break;
			case Enum96.const_2:
				num2 = 5f * num;
				break;
			}
			if (line.method_2() == Enum95.const_5)
			{
				num2 += 2f * num;
				num3 += 2f * num;
			}
			double num4 = Math.Sqrt(Math.Pow(class898_0.Width, 2.0) + Math.Pow(class898_0.Height, 2.0));
			double num5 = 0.0;
			double num6 = 0.0;
			switch (line.method_2())
			{
			case Enum95.const_1:
			case Enum95.const_2:
			case Enum95.const_5:
				num5 = (double)(class898_0.Width * num3) / num4;
				num6 = (double)(class898_0.Height * num3) / num4;
				break;
			}
			double double_ = ((class898_0.int_2 == 1 || class898_0.int_2 == 2) ? ((double)class898_0.X + num5) : ((double)class898_0.method_7().Right - num5));
			double double_2 = ((class898_0.int_2 == 1 || class898_0.int_2 == 4) ? ((double)class898_0.Y + num6) : ((double)class898_0.method_7().Bottom - num6));
			double num7;
			double num8;
			double double_3;
			double double_4;
			switch (class898_0.int_2)
			{
			default:
				num7 = class898_0.method_7().X;
				num8 = class898_0.method_7().Y;
				double_3 = class898_0.method_7().Right;
				double_4 = class898_0.method_7().Bottom;
				break;
			case 1:
				num7 = class898_0.method_7().X;
				num8 = class898_0.method_7().Y;
				double_3 = class898_0.method_7().Right;
				double_4 = class898_0.method_7().Bottom;
				break;
			case 2:
				num7 = class898_0.method_7().X;
				num8 = class898_0.method_7().Bottom;
				double_3 = class898_0.method_7().Right;
				double_4 = class898_0.method_7().Y;
				break;
			case 3:
				num7 = class898_0.method_7().Right;
				num8 = class898_0.method_7().Bottom;
				double_3 = class898_0.method_7().X;
				double_4 = class898_0.method_7().Y;
				break;
			case 4:
				num7 = class898_0.method_7().Right;
				num8 = class898_0.method_7().Y;
				double_3 = class898_0.method_7().X;
				double_4 = class898_0.method_7().Bottom;
				break;
			}
			double double_5 = num2;
			PointF[] c = ((line.method_2() != 0) ? smethod_14(num7, num8, double_, double_2, double_5, double_3, double_4) : smethod_14(num7, num8, num7, num8, num, double_3, double_4));
			arrayList.AddRange(c);
			if (line.method_2() == Enum95.const_3)
			{
				double num9 = num3 / 2f;
				num5 = (double)class898_0.Width * num9 / num4;
				num6 = (double)class898_0.Height * num9 / num4;
				double num10 = ((class898_0.int_2 == 1 || class898_0.int_2 == 2) ? ((double)class898_0.X - num5) : ((double)class898_0.method_7().Right + num5));
				double num11 = ((class898_0.int_2 == 1 || class898_0.int_2 == 4) ? ((double)class898_0.Y - num6) : ((double)class898_0.method_7().Bottom + num6));
				arrayList.Add(new PointF((float)num10, (float)num11));
			}
			else if (line.method_2() == Enum95.const_4)
			{
				double num12 = num3 / 2f;
				num5 = (double)class898_0.Width * num12 / num4;
				num6 = (double)class898_0.Height * num12 / num4;
				double num13 = ((class898_0.int_2 == 1 || class898_0.int_2 == 2) ? ((double)class898_0.X - num5) : ((double)class898_0.method_7().Right + num5));
				double num14 = ((class898_0.int_2 == 1 || class898_0.int_2 == 4) ? ((double)class898_0.Y - num6) : ((double)class898_0.method_7().Bottom + num6));
				arrayList.Add(new PointF((float)num13, (float)num14));
			}
			float num15 = 0f;
			float num16 = 0f;
			switch (line.method_12())
			{
			case Enum94.const_0:
				num16 = 2f * num;
				break;
			case Enum94.const_1:
				num16 = 3f * num;
				break;
			case Enum94.const_2:
				num16 = 5f * num;
				break;
			}
			switch (line.method_10())
			{
			case Enum96.const_0:
				num15 = 2f * num;
				break;
			case Enum96.const_1:
				num15 = 3f * num;
				break;
			case Enum96.const_2:
				num15 = 5f * num;
				break;
			}
			if (line.method_8() == Enum95.const_5)
			{
				num15 += 2f * num;
				num16 += 2f * num;
			}
			double num17 = Math.Sqrt(Math.Pow(class898_0.Width, 2.0) + Math.Pow(class898_0.Height, 2.0));
			double num18 = 0.0;
			double num19 = 0.0;
			switch (line.method_8())
			{
			case Enum95.const_1:
			case Enum95.const_2:
			case Enum95.const_5:
				num18 = (double)(class898_0.Width * num16) / num17;
				num19 = (double)(class898_0.Height * num16) / num17;
				break;
			}
			double double_6 = ((class898_0.int_2 == 3 || class898_0.int_2 == 4) ? ((double)class898_0.X + num18) : ((double)class898_0.method_7().Right - num18));
			double double_7 = ((class898_0.int_2 == 3 || class898_0.int_2 == 2) ? ((double)class898_0.Y + num19) : ((double)class898_0.method_7().Bottom - num19));
			double num20;
			double num21;
			double double_8;
			double double_9;
			switch (class898_0.int_2)
			{
			default:
				num20 = class898_0.X;
				num21 = class898_0.Y;
				double_8 = class898_0.method_7().Right;
				double_9 = class898_0.method_7().Bottom;
				break;
			case 1:
				num20 = class898_0.method_7().Right;
				num21 = class898_0.method_7().Bottom;
				double_8 = class898_0.X;
				double_9 = class898_0.Y;
				break;
			case 2:
				num20 = class898_0.method_7().Right;
				num21 = class898_0.Y;
				double_8 = class898_0.X;
				double_9 = class898_0.method_7().Bottom;
				break;
			case 3:
				num20 = class898_0.X;
				num21 = class898_0.Y;
				double_8 = class898_0.method_7().Right;
				double_9 = class898_0.method_7().Bottom;
				break;
			case 4:
				num20 = class898_0.X;
				num21 = class898_0.method_7().Bottom;
				double_8 = class898_0.method_7().Right;
				double_9 = class898_0.Y;
				break;
			}
			double double_10 = num15;
			PointF[] array = smethod_14(num20, num21, double_6, double_7, double_10, double_8, double_9);
			array = ((line.method_8() != 0) ? smethod_14(num20, num21, double_6, double_7, double_10, double_8, double_9) : smethod_14(num20, num21, num20, num21, num, double_8, double_9));
			arrayList.AddRange(array);
			if (line.method_8() == Enum95.const_3)
			{
				double num22 = num16 / 2f;
				num18 = (double)class898_0.Width * num22 / num17;
				num19 = (double)class898_0.Height * num22 / num17;
				double num23 = ((class898_0.int_2 == 3 || class898_0.int_2 == 4) ? ((double)class898_0.X - num18) : ((double)class898_0.method_7().Right + num18));
				double num24 = ((class898_0.int_2 == 3 || class898_0.int_2 == 2) ? ((double)class898_0.Y - num19) : ((double)class898_0.method_7().Bottom + num19));
				arrayList.Add(new PointF((float)num23, (float)num24));
			}
			else if (line.method_8() == Enum95.const_4)
			{
				double num25 = num16 / 2f;
				num18 = (double)class898_0.Width * num25 / num17;
				num19 = (double)class898_0.Height * num25 / num17;
				double num26 = ((class898_0.int_2 == 3 || class898_0.int_2 == 4) ? ((double)class898_0.X - num18) : ((double)class898_0.method_7().Right + num18));
				double num27 = ((class898_0.int_2 == 3 || class898_0.int_2 == 2) ? ((double)class898_0.Y - num19) : ((double)class898_0.method_7().Bottom + num19));
				arrayList.Add(new PointF((float)num26, (float)num27));
				arrayList.Add(new PointF((float)(num20 - (double)(num16 / 2f)), (float)num21));
				arrayList.Add(new PointF((float)(num20 + (double)(num16 / 2f)), (float)num21));
				arrayList.Add(new PointF((float)num20, (float)(num21 - (double)(num15 / 2f))));
				arrayList.Add(new PointF((float)num20, (float)(num21 + (double)(num15 / 2f))));
			}
		}
		return smethod_15(smethod_16(arrayList));
	}

	private static PointF[] smethod_14(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6)
	{
		if (double_6 == double_1)
		{
			return new PointF[2]
			{
				new PointF((float)double_2, (float)(double_3 - double_4 / 2.0)),
				new PointF((float)double_2, (float)(double_3 + double_4 / 2.0))
			};
		}
		if (double_5 == double_0)
		{
			return new PointF[2]
			{
				new PointF((float)(double_2 - double_4 / 2.0), (float)double_3),
				new PointF((float)(double_2 + double_4 / 2.0), (float)double_3)
			};
		}
		double num = (double_6 - double_1) / (double_5 - double_0);
		double num2 = -1.0 / num;
		double num3 = double_3 - num2 * double_2;
		double num4 = 1.0 + num2 * num2;
		double num5 = 2.0 * num2 * num3 - 2.0 * double_2 - 2.0 * double_3 * num2;
		double num6 = double_2 * double_2 + double_3 * double_3 + num3 * num3 - double_4 / 2.0 * double_4 / 2.0 - 2.0 * double_3 * num3;
		double num7 = (0.0 - num5 - Math.Sqrt(num5 * num5 - 4.0 * num4 * num6)) / (2.0 * num4);
		double num8 = (0.0 - num5 + Math.Sqrt(num5 * num5 - 4.0 * num4 * num6)) / (2.0 * num4);
		double num9 = num2 * num7 + num3;
		double num10 = num2 * num8 + num3;
		return new PointF[2]
		{
			new PointF((float)num7, (float)num9),
			new PointF((float)num8, (float)num10)
		};
	}

	internal static RectangleF smethod_15(PointF[] pointF_0)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		if (pointF_0.Length > 0)
		{
			num = pointF_0[0].X;
			num2 = pointF_0[0].X;
			num3 = pointF_0[0].Y;
			num4 = pointF_0[0].Y;
		}
		for (int i = 1; i < pointF_0.Length; i++)
		{
			PointF pointF = pointF_0[i];
			if (!(pointF == PointF.Empty))
			{
				if (pointF.X < num)
				{
					num = pointF.X;
				}
				if (pointF.X > num2)
				{
					num2 = pointF.X;
				}
				if (pointF.Y < num3)
				{
					num3 = pointF.Y;
				}
				if (pointF.Y > num4)
				{
					num4 = pointF.Y;
				}
			}
		}
		float num5 = (int)num;
		float num6 = (int)num3;
		float num7 = (int)Math.Ceiling(num2 - num5);
		if (num7 == 0f)
		{
			num7 = 1f;
		}
		float num8 = (int)Math.Ceiling(num4 - num6);
		if (num8 == 0f)
		{
			num8 = 1f;
		}
		return new RectangleF(num5, num6, num7, num8);
	}

	internal static PointF[] smethod_16(ArrayList arrayList_0)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			if (arrayList_0[i] == null)
			{
				arrayList_0.RemoveAt(i);
				i--;
			}
		}
		PointF[] array = new PointF[arrayList_0.Count];
		for (int j = 0; j < arrayList_0.Count; j++)
		{
			ref PointF reference = ref array[j];
			reference = (PointF)arrayList_0[j];
		}
		return array;
	}

	internal static RectangleF smethod_17(Class898 class898_0)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 1111f;
		float num4 = 26041f;
		ArrayList arrayList_ = class898_0.class885_0.arrayList_0;
		if (arrayList_.Count > 0)
		{
			foreach (Class882 item in arrayList_)
			{
				if (item.method_0() == 327)
				{
					num3 = Convert.ToSingle(item.Value);
				}
				if (item.method_0() == 328)
				{
					num4 = Convert.ToSingle(item.Value);
				}
			}
			num = Math.Abs(class898_0.Width * (num3 / 21600f));
			num2 = Math.Abs(class898_0.Height * (num4 / 21600f));
		}
		else
		{
			num3 = 1111f;
			num4 = 26041f;
			num = Math.Abs(class898_0.Width * 0.051435184f);
			num2 = Math.Abs(class898_0.Height * 1.2056018f);
		}
		RectangleF result = default(RectangleF);
		if (!(num3 > 0f) || !(num4 > 0f))
		{
			result = ((num3 < 0f && num4 > 0f) ? ((!(num2 > class898_0.Height)) ? new RectangleF(class898_0.X, class898_0.Y, num + class898_0.method_7().Width + 1f, class898_0.method_7().Height) : new RectangleF(class898_0.X, class898_0.Y, num + class898_0.method_7().Width + 1f, num2)) : ((num3 < 0f && num4 < 0f) ? new RectangleF(class898_0.X, class898_0.Y, num + class898_0.method_7().Width + 1f, num2 + class898_0.method_7().Height) : ((!(num > class898_0.Width)) ? new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width, num2 + class898_0.method_7().Height + 1f) : new RectangleF(class898_0.X, class898_0.Y, num, num2 + class898_0.method_7().Height + 1f))));
		}
		else if (num > class898_0.Width && num2 > class898_0.Height)
		{
			result = new RectangleF(class898_0.X, class898_0.Y, num, num2);
		}
		else if (num > class898_0.Width && num2 < class898_0.Height)
		{
			result = new RectangleF(class898_0.X, class898_0.Y, num, class898_0.method_7().Height);
		}
		else if (num < class898_0.Width && num2 > class898_0.Height)
		{
			result = new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width, num2);
		}
		else if (num < class898_0.Width && num2 < class898_0.Height)
		{
			result = new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width, class898_0.method_7().Height);
		}
		result.Inflate(class898_0.Line.Weight, class898_0.Line.Weight);
		return result;
	}

	private static Color smethod_18(Class884 class884_0, float float_0, float float_1)
	{
		Color color = class884_0.method_2();
		float num = (int)color.A;
		float val = color.R + (int)float_1;
		val = Math.Max(0f, Math.Min(val, 255f)) * float_0;
		float val2 = color.G + (int)float_1;
		val2 = Math.Max(0f, Math.Min(val2, 255f)) * float_0;
		float val3 = color.B + (int)float_1;
		val3 = Math.Max(0f, Math.Min(val3, 255f)) * float_0;
		return Color.FromArgb((int)num, (int)val, (int)val2, (int)val3);
	}

	private static void smethod_19(Pen pen_0, Enum95 enum95_0, Enum96 enum96_0, Enum94 enum94_0, bool bool_0, Class889 class889_0)
	{
		float num = 0f;
		float num2 = 0f;
		if (!(class889_0.Weight <= 1f))
		{
			num = enum96_0 switch
			{
				Enum96.const_0 => 3f, 
				Enum96.const_1 => 3f, 
				_ => 5f, 
			};
			num2 = enum94_0 switch
			{
				Enum94.const_0 => 3f, 
				Enum94.const_1 => 3f, 
				_ => 5f, 
			};
		}
		else
		{
			switch (enum96_0)
			{
			case Enum96.const_0:
				switch (enum95_0)
				{
				case Enum95.const_1:
					num = 4f;
					break;
				case Enum95.const_2:
					num = 4f;
					break;
				case Enum95.const_3:
					num = 4f;
					break;
				case Enum95.const_4:
					num = 4f;
					break;
				case Enum95.const_5:
					num = 8f;
					break;
				}
				break;
			case Enum96.const_1:
				switch (enum95_0)
				{
				case Enum95.const_1:
					num = 4f;
					break;
				case Enum95.const_2:
					num = 4f;
					break;
				case Enum95.const_3:
					num = 4f;
					break;
				case Enum95.const_4:
					num = 4f;
					break;
				case Enum95.const_5:
					num = 8f;
					break;
				}
				break;
			default:
				switch (enum95_0)
				{
				case Enum95.const_1:
					num = 4f;
					break;
				case Enum95.const_2:
					num = 4f;
					break;
				case Enum95.const_3:
					num = 4f;
					break;
				case Enum95.const_4:
					num = 4f;
					break;
				case Enum95.const_5:
					num = 8f;
					break;
				}
				break;
			}
			switch (enum94_0)
			{
			case Enum94.const_0:
				switch (enum95_0)
				{
				case Enum95.const_1:
					num2 = 4f;
					break;
				case Enum95.const_2:
					num2 = 4f;
					break;
				case Enum95.const_3:
					num2 = 4f;
					break;
				case Enum95.const_4:
					num2 = 4f;
					break;
				case Enum95.const_5:
					num2 = 8f;
					break;
				}
				break;
			case Enum94.const_1:
				switch (enum95_0)
				{
				case Enum95.const_1:
					num2 = 6f;
					break;
				case Enum95.const_2:
					num2 = 4f;
					break;
				case Enum95.const_3:
					num2 = 4f;
					break;
				case Enum95.const_4:
					num2 = 4f;
					break;
				case Enum95.const_5:
					num2 = 10f;
					break;
				}
				break;
			default:
				switch (enum95_0)
				{
				case Enum95.const_1:
					num2 = 6f;
					break;
				case Enum95.const_2:
					num2 = 6f;
					break;
				case Enum95.const_3:
					num2 = 6f;
					break;
				case Enum95.const_4:
					num2 = 6f;
					break;
				case Enum95.const_5:
					num2 = 10f;
					break;
				}
				break;
			}
		}
		switch (enum95_0)
		{
		case Enum95.const_1:
		{
			AdjustableArrowCap adjustableArrowCap = new AdjustableArrowCap(num, num2);
			if (bool_0)
			{
				pen_0.CustomStartCap = adjustableArrowCap;
			}
			else
			{
				pen_0.CustomEndCap = adjustableArrowCap;
			}
			break;
		}
		case Enum95.const_2:
		{
			AdjustableArrowCap adjustableArrowCap = new AdjustableArrowCap(num, num2);
			adjustableArrowCap.MiddleInset = 0.9f;
			if (bool_0)
			{
				pen_0.CustomStartCap = adjustableArrowCap;
			}
			else
			{
				pen_0.CustomEndCap = adjustableArrowCap;
			}
			break;
		}
		case Enum95.const_3:
		{
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddPolygon(new PointF[4]
			{
				new PointF((0f - num) / 2f, 0f),
				new PointF(0f, (0f - num2) / 2f),
				new PointF(num / 2f, 0f),
				new PointF(0f, num2 / 2f)
			});
			CustomLineCap customLineCap2 = new CustomLineCap(graphicsPath2, null);
			if (bool_0)
			{
				pen_0.CustomStartCap = customLineCap2;
			}
			else
			{
				pen_0.CustomEndCap = customLineCap2;
			}
			break;
		}
		case Enum95.const_4:
		{
			GraphicsPath graphicsPath3 = new GraphicsPath();
			RectangleF rect = new RectangleF((0f - num) / 2f, (0f - num2) / 2f, num, num2);
			graphicsPath3.AddEllipse(rect);
			CustomLineCap customLineCap3 = new CustomLineCap(graphicsPath3, null);
			if (bool_0)
			{
				pen_0.CustomStartCap = customLineCap3;
			}
			else
			{
				pen_0.CustomEndCap = customLineCap3;
			}
			break;
		}
		case Enum95.const_5:
		{
			num += 0.5f;
			num2 += 0.5f;
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(new PointF(num / 2f, 0f - num2), new PointF(0f, 0f));
			graphicsPath.AddLine(new PointF((0f - num) / 2f, 0f - num2), new PointF(0f, 0f));
			CustomLineCap customLineCap = new CustomLineCap(null, graphicsPath);
			customLineCap.BaseCap = LineCap.Flat;
			customLineCap.StrokeJoin = LineJoin.Round;
			customLineCap.SetStrokeCaps(LineCap.Round, LineCap.Round);
			if (bool_0)
			{
				pen_0.CustomStartCap = customLineCap;
			}
			else
			{
				pen_0.CustomEndCap = customLineCap;
			}
			break;
		}
		}
	}

	internal static RectangleF smethod_20(Class898 class898_0)
	{
		RectangleF result = default(RectangleF);
		bool flag = false;
		bool flag2 = false;
		Enum95 @enum = Enum95.const_1;
		if (class898_0.Line.method_2() != 0)
		{
			@enum = class898_0.Line.method_2();
			flag = true;
		}
		if (class898_0.Line.method_8() != 0)
		{
			@enum = class898_0.Line.method_8();
			flag2 = true;
		}
		switch (@enum)
		{
		default:
			if (class898_0.Line.Weight <= 1f)
			{
				if (class898_0.method_7().Height <= class898_0.Line.Weight)
				{
					float height4 = 9f * class898_0.Line.Weight;
					result = new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + class898_0.Line.Weight / 2f + 1f, height4);
				}
				else if (class898_0.method_7().Width <= class898_0.Line.Weight)
				{
					float width4 = 9f * class898_0.Line.Weight;
					result = new RectangleF(class898_0.X, class898_0.Y, width4, class898_0.method_7().Height);
				}
				else
				{
					result = ((!(class898_0.Width > class898_0.Height)) ? ((!(class898_0.Width < class898_0.Height)) ? new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width, class898_0.method_7().Height) : ((!flag || !flag2) ? new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + 4f * class898_0.Line.Weight, class898_0.method_7().Height) : new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + 2f * (4f * class898_0.Line.Weight), class898_0.method_7().Height))) : ((!flag || !flag2) ? new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width, class898_0.method_7().Height + 4f * class898_0.Line.Weight) : new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width, class898_0.method_7().Height + 2f * (4f * class898_0.Line.Weight))));
				}
			}
			break;
		case Enum95.const_1:
			if (class898_0.Line.Weight <= 1f)
			{
				if (class898_0.method_7().Height <= class898_0.Line.Weight)
				{
					float height5 = 9f * class898_0.Line.Weight;
					result = new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + class898_0.Line.Weight / 2f + 1f, height5);
				}
				else if (class898_0.method_7().Width <= class898_0.Line.Weight)
				{
					float width5 = 9f * class898_0.Line.Weight;
					result = new RectangleF(class898_0.X, class898_0.Y, width5, class898_0.method_7().Height);
				}
				else
				{
					result = ((!(class898_0.Width > class898_0.Height)) ? ((!(class898_0.Width < class898_0.Height)) ? new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width, class898_0.method_7().Height) : ((!flag || !flag2) ? new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + 4f * class898_0.Line.Weight, class898_0.method_7().Height) : new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + 2f * (4f * class898_0.Line.Weight), class898_0.method_7().Height))) : ((!flag || !flag2) ? new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width, class898_0.method_7().Height + 4f * class898_0.Line.Weight) : new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width, class898_0.method_7().Height + 2f * (4f * class898_0.Line.Weight))));
				}
			}
			break;
		case Enum95.const_2:
			if (class898_0.Line.Weight <= 1f)
			{
				if (class898_0.method_7().Height <= class898_0.Line.Weight)
				{
					float height2 = 9f * class898_0.Line.Weight;
					result = new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + class898_0.Line.Weight / 2f + 1f, height2);
				}
				else if (class898_0.method_7().Width <= class898_0.Line.Weight)
				{
					float width2 = 9f * class898_0.Line.Weight;
					result = new RectangleF(class898_0.X, class898_0.Y, width2, class898_0.method_7().Height);
				}
				else
				{
					result = ((!(class898_0.Width > class898_0.Height)) ? ((!(class898_0.Width < class898_0.Height)) ? new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width, class898_0.method_7().Height) : new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + 2f * (4f * class898_0.Line.Weight), class898_0.method_7().Height)) : new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width, class898_0.method_7().Height + 2f * (4f * class898_0.Line.Weight)));
				}
			}
			break;
		case Enum95.const_3:
			if (class898_0.Line.Weight <= 1f)
			{
				if (class898_0.method_7().Height <= class898_0.Line.Weight)
				{
					float height3 = 12f * class898_0.Line.Weight;
					result = ((!flag || !flag2) ? new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + class898_0.Line.Weight * 5f, height3) : new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + class898_0.Line.Weight * 5f * 2f, height3));
				}
				else if (class898_0.method_7().Width <= class898_0.Line.Weight)
				{
					float width3 = 12f * class898_0.Line.Weight;
					result = ((!flag || !flag2) ? new RectangleF(class898_0.X, class898_0.Y, width3, class898_0.method_7().Height + 5f * class898_0.Line.Weight) : new RectangleF(class898_0.X, class898_0.Y, width3, class898_0.method_7().Height + 5f * class898_0.Line.Weight * 2f));
				}
				else
				{
					result = new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + 2f * (4f * class898_0.Line.Weight), class898_0.method_7().Height + 2f * (4f * class898_0.Line.Weight));
				}
			}
			break;
		case Enum95.const_4:
			if (class898_0.Line.Weight <= 1f)
			{
				if (class898_0.method_7().Height <= class898_0.Line.Weight)
				{
					float height6 = 12f * class898_0.Line.Weight;
					result = ((!flag || !flag2) ? new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + class898_0.Line.Weight * 5f, height6) : new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + class898_0.Line.Weight * 5f * 2f, height6));
				}
				else if (class898_0.method_7().Width <= class898_0.Line.Weight)
				{
					float width6 = 12f * class898_0.Line.Weight;
					result = ((!flag || !flag2) ? new RectangleF(class898_0.X, class898_0.Y, width6, class898_0.method_7().Height + 5f * class898_0.Line.Weight) : new RectangleF(class898_0.X, class898_0.Y, width6, class898_0.method_7().Height + 5f * class898_0.Line.Weight * 2f));
				}
				else
				{
					result = new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + 2f * (5f * class898_0.Line.Weight), class898_0.method_7().Height + 2f * (5f * class898_0.Line.Weight));
				}
			}
			break;
		case Enum95.const_5:
			if (class898_0.Line.Weight <= 1f)
			{
				if (class898_0.method_7().Height <= class898_0.Line.Weight)
				{
					float height = 12f * class898_0.Line.Weight;
					result = new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + class898_0.Line.Weight / 2f + 1f, height);
				}
				else if (class898_0.method_7().Width <= class898_0.Line.Weight)
				{
					float width = 12f * class898_0.Line.Weight;
					result = new RectangleF(class898_0.X, class898_0.Y, width, class898_0.method_7().Height + class898_0.Line.Weight / 2f + 1f);
				}
				else
				{
					result = ((!(class898_0.Width > class898_0.Height)) ? ((!(class898_0.Width < class898_0.Height)) ? new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width, class898_0.method_7().Height) : new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + 2f * (4f * class898_0.Line.Weight), class898_0.method_7().Height)) : new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + 10f, class898_0.method_7().Height + 2f + 2f * (4f * class898_0.Line.Weight)));
				}
			}
			break;
		}
		return result;
	}

	internal static RectangleF smethod_21(Class898 class898_0)
	{
		float float_ = 0f;
		float float_2 = 0f;
		float float_3 = 0f;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		num3 = ((class898_0.class885_0.arrayList_0.Count <= 0) ? 0f : ((((Class882)class898_0.class885_0.arrayList_0[0]).method_0() != 327) ? 0f : (((class898_0.Width > class898_0.Height) ? class898_0.Width : class898_0.Height) * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) - 10800f) / 21600f)));
		if (class898_0.Line.method_2() != 0)
		{
			smethod_24(class898_0.Line.method_2(), class898_0.Line.method_4(), class898_0.Line.method_6(), class898_0.Line, ref float_2, ref float_);
		}
		if (class898_0.Line.method_8() != 0)
		{
			smethod_24(class898_0.Line.method_8(), class898_0.Line.method_10(), class898_0.Line.method_12(), class898_0.Line, ref float_2, ref float_3);
		}
		if (class898_0.Width > class898_0.Height)
		{
			float weight = class898_0.Line.Weight;
			num2 = ((class898_0.Height < float_ || !(class898_0.Height >= float_3)) ? (num2 + (weight + 2f * ((float_ > float_3) ? float_ : float_3))) : (num2 + (weight + float_ + float_3 + 1f)));
			if (num3 > class898_0.Width / 2f || num3 < (0f - class898_0.Width) / 2f)
			{
				num += Math.Abs(num3) - class898_0.Width / 2f + weight / 2f;
			}
		}
		else
		{
			float weight2 = class898_0.Line.Weight;
			num += weight2 + float_ + float_3;
			if (num3 > class898_0.Height / 2f || num3 < (0f - class898_0.Height) / 2f)
			{
				num2 += Math.Abs(num3) - class898_0.Height / 2f + weight2 / 2f;
			}
		}
		RectangleF result = new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + num, class898_0.method_7().Height + num2);
		return result;
	}

	internal static RectangleF smethod_22(Class898 class898_0)
	{
		RectangleF rectangleF = default(RectangleF);
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		double num5 = Struct67.smethod_0(class898_0.Rotation);
		double num6 = Struct67.smethod_0(90 - class898_0.Rotation);
		num = (float)((double)class898_0.Width * Math.Sin(num5));
		num2 = (float)((double)class898_0.Width * Math.Cos(num5));
		num3 = (float)((double)class898_0.Height * Math.Cos(num6));
		num4 = (float)((double)class898_0.Height * Math.Sin(num6));
		float num7 = 0f;
		float num8 = 0f;
		num7 = Math.Abs(num2) + Math.Abs(num3);
		num8 = Math.Abs(num) + Math.Abs(num4);
		rectangleF = new RectangleF(class898_0.X, class898_0.Y, num7, num8);
		rectangleF.Inflate(class898_0.Line.Weight, class898_0.Line.Weight);
		return rectangleF;
	}

	internal static RectangleF smethod_23(Class898 class898_0)
	{
		float float_ = 0f;
		float float_2 = 0f;
		float float_3 = 0f;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float weight = class898_0.Line.Weight;
		num3 = ((class898_0.class885_0 == null) ? (((class898_0.Width > class898_0.Height) ? class898_0.Width : class898_0.Height) * 10800f / 21600f) : (((class898_0.Width > class898_0.Height) ? class898_0.Width : class898_0.Height) * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) - 10800f) / 21600f));
		if (class898_0.Line.method_2() != 0)
		{
			smethod_24(class898_0.Line.method_2(), class898_0.Line.method_4(), class898_0.Line.method_6(), class898_0.Line, ref float_2, ref float_);
		}
		if (class898_0.Line.method_8() != 0)
		{
			smethod_24(class898_0.Line.method_8(), class898_0.Line.method_10(), class898_0.Line.method_12(), class898_0.Line, ref float_2, ref float_3);
		}
		if (class898_0.Width > class898_0.Height)
		{
			num2 += weight + float_ + float_3;
			num = ((!(Math.Abs(num3) >= class898_0.Width / 2f)) ? (num + 0f) : (num + (weight / 2f + Math.Abs(num3) - class898_0.Width / 2f)));
		}
		else
		{
			num = weight + float_ + float_3;
			if (Math.Abs(num3) >= class898_0.Height / 2f)
			{
				num2 += weight / 2f + Math.Abs(num3) - class898_0.Height / 2f;
			}
		}
		RectangleF result = new RectangleF(class898_0.X, class898_0.Y, class898_0.method_7().Width + num, class898_0.method_7().Height + num2);
		return result;
	}

	private static void smethod_24(Enum95 enum95_0, Enum96 enum96_0, Enum94 enum94_0, Class889 class889_0, ref float float_0, ref float float_1)
	{
		if (class889_0.Weight <= 1f)
		{
			switch (enum96_0)
			{
			case Enum96.const_0:
				switch (enum95_0)
				{
				case Enum95.const_1:
					float_0 = 4f;
					break;
				case Enum95.const_2:
					float_0 = 4f;
					break;
				case Enum95.const_3:
					float_0 = 4f;
					break;
				case Enum95.const_4:
					float_0 = 4f;
					break;
				case Enum95.const_5:
					float_0 = 8f;
					break;
				}
				break;
			case Enum96.const_1:
				switch (enum95_0)
				{
				case Enum95.const_1:
					float_0 = 4f;
					break;
				case Enum95.const_2:
					float_0 = 4f;
					break;
				case Enum95.const_3:
					float_0 = 4f;
					break;
				case Enum95.const_4:
					float_0 = 4f;
					break;
				case Enum95.const_5:
					float_0 = 8f;
					break;
				}
				break;
			default:
				switch (enum95_0)
				{
				case Enum95.const_1:
					float_1 = 4f;
					break;
				case Enum95.const_2:
					float_1 = 4f;
					break;
				case Enum95.const_3:
					float_1 = 4f;
					break;
				case Enum95.const_4:
					float_1 = 4f;
					break;
				case Enum95.const_5:
					float_1 = 8f;
					break;
				}
				break;
			}
			switch (enum94_0)
			{
			case Enum94.const_0:
				switch (enum95_0)
				{
				case Enum95.const_1:
					float_1 = 4f;
					break;
				case Enum95.const_2:
					float_1 = 4f;
					break;
				case Enum95.const_3:
					float_1 = 4f;
					break;
				case Enum95.const_4:
					float_1 = 4f;
					break;
				case Enum95.const_5:
					float_1 = 8f;
					break;
				}
				break;
			case Enum94.const_1:
				switch (enum95_0)
				{
				case Enum95.const_1:
					float_1 = 6f;
					break;
				case Enum95.const_2:
					float_1 = 4f;
					break;
				case Enum95.const_3:
					float_1 = 4f;
					break;
				case Enum95.const_4:
					float_1 = 4f;
					break;
				case Enum95.const_5:
					float_1 = 10f;
					break;
				}
				break;
			default:
				switch (enum95_0)
				{
				case Enum95.const_1:
					float_1 = 6f;
					break;
				case Enum95.const_2:
					float_1 = 6f;
					break;
				case Enum95.const_3:
					float_1 = 6f;
					break;
				case Enum95.const_4:
					float_1 = 6f;
					break;
				case Enum95.const_5:
					float_1 = 10f;
					break;
				}
				break;
			}
		}
		else
		{
			switch (enum96_0)
			{
			case Enum96.const_0:
				float_0 = 3f;
				break;
			case Enum96.const_1:
				float_0 = 3f;
				break;
			default:
				float_0 = 5f;
				break;
			}
			switch (enum94_0)
			{
			case Enum94.const_0:
				float_1 = 3f;
				break;
			case Enum94.const_1:
				float_1 = 3f;
				break;
			default:
				float_1 = 5f;
				break;
			}
		}
	}

	internal static RectangleF smethod_25(Class898 class898_0)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		_ = class898_0.X;
		_ = class898_0.Y;
		float num5 = class898_0.Width;
		float num6 = class898_0.Height;
		float weight = class898_0.Line.Weight;
		if (class898_0.class885_0.arrayList_0.Count > 0)
		{
			num = (float)((Class882)class898_0.class885_0.arrayList_0[0]).Value / 21600f * num5;
			num2 = (float)((Class882)class898_0.class885_0.arrayList_0[1]).Value / 21600f * num6;
			num3 = (float)((Class882)class898_0.class885_0.arrayList_0[2]).Value / 21600f * num5;
			num4 = (float)((Class882)class898_0.class885_0.arrayList_0[3]).Value / 21600f * num6;
		}
		class898_0.method_20();
		class898_0.method_18();
		if (num > 0f && num2 > 0f && num3 > 0f && num4 > 0f && num2 > num6 && num4 > num6)
		{
			num5 += weight;
			num6 = num2 + weight;
		}
		return new RectangleF(class898_0.X, class898_0.Y, num5, num6);
	}
}
