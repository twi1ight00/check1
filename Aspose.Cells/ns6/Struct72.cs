using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using ns19;
using ns22;
using ns5;

namespace ns6;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct72
{
	internal static Font font_0 = new Font("Arial", 8f);

	internal static Pen smethod_0(Class906 class906_0)
	{
		if (class906_0.method_0())
		{
			return new Pen(Color.Empty);
		}
		Pen pen = null;
		if (class906_0.Pattern != 0)
		{
			pen = new Pen(class906_0.ForeColor, class906_0.Weight);
		}
		else
		{
			pen = new Pen(class906_0.ForeColor, class906_0.Weight);
			switch (class906_0.DashStyle)
			{
			case Enum116.const_0:
				pen.DashStyle = DashStyle.Custom;
				pen.DashPattern = new float[2] { 4f, 4f };
				break;
			case Enum116.const_1:
				pen.DashStyle = DashStyle.Custom;
				pen.DashPattern = new float[4] { 4f, 3f, 1f, 3f };
				break;
			case Enum116.const_2:
				pen.DashStyle = DashStyle.Dot;
				break;
			case Enum116.const_3:
				pen.DashStyle = DashStyle.Dot;
				break;
			case Enum116.const_4:
				pen.DashStyle = DashStyle.Dot;
				break;
			case Enum116.const_5:
				pen.DashStyle = DashStyle.Dot;
				pen.DashCap = DashCap.Round;
				break;
			case Enum116.const_6:
				pen.DashStyle = DashStyle.Solid;
				break;
			case Enum116.const_7:
				pen.DashStyle = DashStyle.Dot;
				break;
			}
		}
		switch (class906_0.Style)
		{
		case Enum118.const_1:
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
		case Enum118.const_2:
			pen.CompoundArray = new float[4] { 0f, 0.2f, 0.4f, 1f };
			break;
		case Enum118.const_3:
			pen.CompoundArray = new float[4] { 0f, 0.6f, 0.8f, 1f };
			break;
		case Enum118.const_4:
			pen.CompoundArray = new float[4]
			{
				0f,
				1f / 3f,
				2f / 3f,
				1f
			};
			break;
		}
		smethod_1(pen, class906_0);
		return pen;
	}

	private static void smethod_1(Pen pen_0, Class906 class906_0)
	{
		if (class906_0.method_2() != 0)
		{
			smethod_2(pen_0, class906_0.method_2(), class906_0.method_4(), class906_0.method_6(), bool_0: true, class906_0);
		}
		if (class906_0.method_8() != 0)
		{
			smethod_2(pen_0, class906_0.method_8(), class906_0.method_10(), class906_0.method_12(), bool_0: false, class906_0);
		}
	}

	private static void smethod_2(Pen pen_0, Enum114 enum114_0, Enum115 enum115_0, Enum113 enum113_0, bool bool_0, Class906 class906_0)
	{
		float num = 0f;
		float num2 = 0f;
		if (!(class906_0.Weight <= 1f))
		{
			num = enum115_0 switch
			{
				Enum115.const_0 => 3f, 
				Enum115.const_1 => 3f, 
				_ => 5f, 
			};
			num2 = enum113_0 switch
			{
				Enum113.const_0 => 3f, 
				Enum113.const_1 => 3f, 
				_ => 5f, 
			};
		}
		else
		{
			switch (enum115_0)
			{
			case Enum115.const_0:
				switch (enum114_0)
				{
				case Enum114.const_1:
					num = 4f;
					break;
				case Enum114.const_2:
					num = 4f;
					break;
				case Enum114.const_3:
					num = 4f;
					break;
				case Enum114.const_4:
					num = 4f;
					break;
				case Enum114.const_5:
					num = 8f;
					break;
				}
				break;
			case Enum115.const_1:
				switch (enum114_0)
				{
				case Enum114.const_1:
					num = 4f;
					break;
				case Enum114.const_2:
					num = 4f;
					break;
				case Enum114.const_3:
					num = 4f;
					break;
				case Enum114.const_4:
					num = 4f;
					break;
				case Enum114.const_5:
					num = 8f;
					break;
				}
				break;
			default:
				switch (enum114_0)
				{
				case Enum114.const_1:
					num = 4f;
					break;
				case Enum114.const_2:
					num = 4f;
					break;
				case Enum114.const_3:
					num = 4f;
					break;
				case Enum114.const_4:
					num = 4f;
					break;
				case Enum114.const_5:
					num = 8f;
					break;
				}
				break;
			}
			switch (enum113_0)
			{
			case Enum113.const_0:
				switch (enum114_0)
				{
				case Enum114.const_1:
					num2 = 4f;
					break;
				case Enum114.const_2:
					num2 = 4f;
					break;
				case Enum114.const_3:
					num2 = 4f;
					break;
				case Enum114.const_4:
					num2 = 4f;
					break;
				case Enum114.const_5:
					num2 = 8f;
					break;
				}
				break;
			case Enum113.const_1:
				switch (enum114_0)
				{
				case Enum114.const_1:
					num2 = 4f;
					break;
				case Enum114.const_2:
					num2 = 4f;
					break;
				case Enum114.const_3:
					num2 = 4f;
					break;
				case Enum114.const_4:
					num2 = 4f;
					break;
				case Enum114.const_5:
					num2 = 10f;
					break;
				}
				break;
			default:
				switch (enum114_0)
				{
				case Enum114.const_1:
					num2 = 6f;
					break;
				case Enum114.const_2:
					num2 = 6f;
					break;
				case Enum114.const_3:
					num2 = 6f;
					break;
				case Enum114.const_4:
					num2 = 6f;
					break;
				case Enum114.const_5:
					num2 = 10f;
					break;
				}
				break;
			}
		}
		switch (enum114_0)
		{
		case Enum114.const_1:
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
		case Enum114.const_2:
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
		case Enum114.const_3:
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
		case Enum114.const_4:
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
		case Enum114.const_5:
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

	internal static void smethod_3(Interface42 interface42_0, Class913 class913_0, RectangleF rectangleF_0, string string_0, Enum107 enum107_0, Font font_1, Color color_0, Enum104 enum104_0, Enum104 enum104_1)
	{
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		if (class913_0.method_13().Count > 0)
		{
			smethod_4(interface42_0, class913_0, rectangleF_0);
		}
		else if (string_0 != null && !(string_0 == ""))
		{
			int num = 0;
			smethod_5(interface42_0, class913_0, rectangleF_0, string_0, enum107_0 switch
			{
				Enum107.const_0 => -90, 
				Enum107.const_1 => 90, 
				Enum107.const_2 => 0, 
				Enum107.const_3 => 0, 
				_ => 0, 
			}, font_1, color_0, enum104_0, enum104_1);
		}
	}

	private static void smethod_4(Interface42 interface42_0, Class913 class913_0, RectangleF rectangleF_0)
	{
		Class908 @class = new Class908();
		@class.TextDirection = class913_0.TextDirection;
		@class.TextHorizontalAlignment = smethod_6(class913_0.TextHorizontalAlignment);
		@class.method_0(class913_0.method_9());
		@class.TextVerticalAlignment = smethod_6(class913_0.TextVerticalAlignment);
		if (class913_0.method_9() == Enum107.const_1)
		{
			SizeF sizeF = Struct69.smethod_11(interface42_0, class913_0.Text, class913_0.Font, new SizeF(2.1474836E+09f, 2.1474836E+09f));
			rectangleF_0 = new RectangleF(rectangleF_0.X, rectangleF_0.Y, sizeF.Width, rectangleF_0.Height);
		}
		Class910 class2 = new Class910(rectangleF_0, @class, class913_0.method_13(), class913_0.Font);
		Enum104 textVerticalAlignment = class913_0.TextVerticalAlignment;
		Enum104 textHorizontalAlignment = class913_0.TextHorizontalAlignment;
		if (class913_0.method_9() == Enum107.const_1 || class913_0.method_9() == Enum107.const_0)
		{
			float angle = -90f;
			if (class913_0.method_9() == Enum107.const_0)
			{
				angle = 90f;
			}
			Point point = new Point((int)(rectangleF_0.Left + rectangleF_0.Width / 2f), (int)(rectangleF_0.Top + rectangleF_0.Height / 2f));
			Matrix matrix = new Matrix();
			matrix.RotateAt(angle, new PointF(point.X, point.Y));
			if (textVerticalAlignment == Enum104.const_1 && textHorizontalAlignment == Enum104.const_1)
			{
				matrix.Translate(0f, 0f - ((float)point.X - class913_0.Width / 2f));
			}
			else if (textVerticalAlignment == Enum104.const_9 && textHorizontalAlignment == Enum104.const_1)
			{
				matrix.Translate(rectangleF_0.Height / 2f - rectangleF_0.Width / 2f, rectangleF_0.Height / 2f - ((float)point.X - class913_0.Width / 2f) - 5f);
			}
			else if (textVerticalAlignment == Enum104.const_9 && textHorizontalAlignment == Enum104.const_7)
			{
				matrix.Translate(rectangleF_0.Height / 2f - rectangleF_0.Width / 4f, rectangleF_0.Height / 2f - (float)point.X - 5f);
			}
			else if (textVerticalAlignment == Enum104.const_9 && textHorizontalAlignment == Enum104.const_8)
			{
				if (class913_0.Width > rectangleF_0.Width)
				{
					matrix.Translate(rectangleF_0.Height / 2f - rectangleF_0.Width / 2f, class913_0.Height / 2f + class913_0.Width / 2f);
				}
				else
				{
					matrix.Translate(rectangleF_0.Height / 2f - rectangleF_0.Width / 2f, class913_0.Height / 2f - class913_0.Width / 2f);
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
				matrix.Translate(0f, 0f - ((float)point.X - class913_0.Width + rectangleF_0.Left));
			}
			else if (textVerticalAlignment == Enum104.const_1 && textHorizontalAlignment == Enum104.const_6)
			{
				matrix.Translate(0f, 0f - ((float)point.X - rectangleF_0.Left));
			}
			else if (textVerticalAlignment == Enum104.const_0 && textHorizontalAlignment == Enum104.const_7)
			{
				if (rectangleF_0.Width > class913_0.Width)
				{
					matrix.Translate(0f - (rectangleF_0.Height / 2f - rectangleF_0.Width / 2f), 0f - (rectangleF_0.Height / 2f + class913_0.Width));
				}
				else
				{
					matrix.Translate(0f - (rectangleF_0.Height / 2f - rectangleF_0.Width / 2f), 0f - (rectangleF_0.Height / 2f + rectangleF_0.Width / 2f - rectangleF_0.Left));
				}
			}
			else if (textVerticalAlignment == Enum104.const_0 && textHorizontalAlignment == Enum104.const_1)
			{
				if (rectangleF_0.Width > class913_0.Width)
				{
					matrix.Translate(0f - (rectangleF_0.Height / 2f - rectangleF_0.Width / 2f), 0f - (rectangleF_0.Height / 2f + class913_0.Width / 2f - rectangleF_0.Left));
				}
				else
				{
					matrix.Translate(0f - (rectangleF_0.Height / 2f - rectangleF_0.Width / 2f), 0f - (rectangleF_0.Height / 2f - (class913_0.Width / 2f - rectangleF_0.Width / 2f) - rectangleF_0.Left));
				}
			}
			else if (textVerticalAlignment == Enum104.const_0 && textHorizontalAlignment == Enum104.const_8)
			{
				if (rectangleF_0.Width > class913_0.Width)
				{
					matrix.Translate(0f - (rectangleF_0.Height / 2f - class913_0.Width), 0f - (rectangleF_0.Height / 2f + class913_0.Width / 2f + rectangleF_0.Left));
				}
				else
				{
					matrix.Translate(0f - (rectangleF_0.Height / 2f - (class913_0.Width - rectangleF_0.Width + 10f)), 0f - (rectangleF_0.Height / 2f - class913_0.Width / 2f - rectangleF_0.Left));
				}
			}
			else if (textVerticalAlignment == Enum104.const_0 && textHorizontalAlignment == Enum104.const_6)
			{
				if (rectangleF_0.Width > class913_0.Width)
				{
					matrix.Translate(0f - (rectangleF_0.Height / 2f - rectangleF_0.Width / 2f), 0f - (rectangleF_0.Height / 2f + class913_0.Width));
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
				if (class913_0.Width < rectangleF_0.Width)
				{
					matrix.Translate((float)point.X - rectangleF_0.Height / 2f, (float)point.Y - class913_0.Width / 2f);
				}
				else
				{
					float num = (class913_0.Width - rectangleF_0.Width) / 4f;
					matrix.Translate((float)point.X - rectangleF_0.Height / 2f - num, (float)point.Y + num);
				}
			}
			else if (textVerticalAlignment == Enum104.const_6 && textHorizontalAlignment == Enum104.const_8)
			{
				if (class913_0.Width < rectangleF_0.Width)
				{
					matrix.Translate((float)point.X - rectangleF_0.Height / 2f, rectangleF_0.Height / 2f - rectangleF_0.Width / 2f + class913_0.Width / 2f);
				}
				else
				{
					float num2 = class913_0.Width - rectangleF_0.Width;
					matrix.Translate((float)point.X - rectangleF_0.Height / 2f - num2, (float)point.Y + class913_0.Width / 2f);
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

	private static void smethod_5(Interface42 interface42_0, Class913 class913_0, RectangleF rectangleF_0, string string_0, int int_0, Font font_1, Color color_0, Enum104 enum104_0, Enum104 enum104_1)
	{
		StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
		stringFormat.FormatFlags |= StringFormatFlags.LineLimit;
		SizeF sizeF = smethod_8(interface42_0, string_0, font_1, new SizeF(2.1474836E+09f, 2.1474836E+09f));
		if (class913_0.method_9() == Enum107.const_3)
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
			stringFormat.Alignment = smethod_6(enum104_0);
			stringFormat.LineAlignment = smethod_6(enum104_1);
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
			interface42_0.imethod_49(rectangleF_0.Left + rectangleF_0.Width / 2f, rectangleF_0.Top + rectangleF_0.Height / 2f);
			interface42_0.imethod_45(-int_0);
			rectangleF_0 = new RectangleF((0f - rectangleF_0.Height) / 2f, (0f - rectangleF_0.Width) / 2f, rectangleF_0.Height, rectangleF_0.Width);
			interface42_0.imethod_27(string_0, font_1, new SolidBrush(color_0), rectangleF_0, stringFormat);
			interface42_0.ResetTransform();
			break;
		case 0:
			interface42_0.imethod_27(string_0, font_1, new SolidBrush(color_0), rectangleF_0, stringFormat);
			break;
		}
	}

	public static StringAlignment smethod_6(Enum104 enum104_0)
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

	internal static int smethod_7(double double_0)
	{
		return (int)Math.Ceiling(double_0);
	}

	public static SizeF smethod_8(Interface42 interface42_0, string string_0, Font font_1, SizeF sizeF_0)
	{
		int num = smethod_7(interface42_0.imethod_0().imethod_2(font_1));
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
				int num2 = smethod_7(result.Height);
				if (num2 >= 1 && result.Width >= 1f)
				{
					int num3 = (int)((double)result.Width * 0.1);
					if (num3 < 10)
					{
						num3 = 10;
					}
					Bitmap bitmap = new Bitmap(num3, num2);
					Graphics graphics = Graphics.FromImage(bitmap);
					float num4 = smethod_7(result.Width);
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
			SizeF sizeF = smethod_8(interface42_0, text, font_1, sizeF_);
			SizeF sizeF2 = smethod_8(interface42_0, string_, font_1, sizeF_);
			float width = ((sizeF2.Width - 2f * sizeF.Width > 0f) ? (sizeF2.Width - 2f * sizeF.Width) : ((float)num / 5f));
			return new SizeF(width, result2.Height);
		}
		return new SizeF(0f, num);
	}

	internal static float smethod_9(Font font_1)
	{
		return font_1.Size / 4f;
	}

	internal static RectangleF smethod_10(Class913 class913_0)
	{
		Class906 line = class913_0.Line;
		ArrayList arrayList = new ArrayList();
		arrayList.Add(new PointF(class913_0.X, class913_0.Y));
		arrayList.Add(new PointF(class913_0.X, class913_0.method_8().Bottom));
		arrayList.Add(new PointF(class913_0.method_8().Right, class913_0.Y));
		arrayList.Add(new PointF(class913_0.method_8().Right, class913_0.method_8().Bottom));
		if (!line.method_0())
		{
			float num = line.Weight;
			float num2 = 0f;
			float num3 = 0f;
			switch (line.method_6())
			{
			case Enum113.const_0:
				num3 = 3f * num;
				break;
			case Enum113.const_1:
				num3 = 4f * num;
				break;
			case Enum113.const_2:
				num3 = 6f * num;
				break;
			}
			switch (line.method_4())
			{
			case Enum115.const_0:
				num2 = 5f * num;
				break;
			case Enum115.const_1:
				num2 = 4f * num;
				break;
			case Enum115.const_2:
				num2 = 6f * num;
				break;
			}
			if (line.method_2() == Enum114.const_5)
			{
				num2 += 2f * num;
				num3 += 2f * num;
			}
			double num4 = Math.Sqrt(Math.Pow(class913_0.Width, 2.0) + Math.Pow(class913_0.Height, 2.0));
			double num5 = 0.0;
			double num6 = 0.0;
			switch (line.method_2())
			{
			case Enum114.const_1:
			case Enum114.const_2:
			case Enum114.const_5:
				num5 = (double)(class913_0.Width * num3) / num4;
				num6 = (double)(class913_0.Height * num3) / num4;
				break;
			}
			double double_ = ((class913_0.int_3 == 1 || class913_0.int_3 == 2) ? ((double)class913_0.X + num5) : ((double)class913_0.method_8().Right - num5));
			double double_2 = ((class913_0.int_3 == 1 || class913_0.int_3 == 4) ? ((double)class913_0.Y + num6) : ((double)class913_0.method_8().Bottom - num6));
			double num7;
			double num8;
			double double_3;
			double double_4;
			switch (class913_0.int_3)
			{
			default:
				num7 = class913_0.method_8().X;
				num8 = class913_0.method_8().Y;
				double_3 = class913_0.method_8().Right;
				double_4 = class913_0.method_8().Bottom;
				break;
			case 1:
				num7 = class913_0.method_8().X;
				num8 = class913_0.method_8().Y;
				double_3 = class913_0.method_8().Right;
				double_4 = class913_0.method_8().Bottom;
				break;
			case 2:
				num7 = class913_0.method_8().X;
				num8 = class913_0.method_8().Bottom;
				double_3 = class913_0.method_8().Right;
				double_4 = class913_0.method_8().Y;
				break;
			case 3:
				num7 = class913_0.method_8().Right;
				num8 = class913_0.method_8().Bottom;
				double_3 = class913_0.method_8().X;
				double_4 = class913_0.method_8().Y;
				break;
			case 4:
				num7 = class913_0.method_8().Right;
				num8 = class913_0.method_8().Y;
				double_3 = class913_0.method_8().X;
				double_4 = class913_0.method_8().Bottom;
				break;
			}
			double double_5 = num2;
			PointF[] c = ((line.method_2() != 0) ? smethod_29(num7, num8, double_, double_2, double_5, double_3, double_4) : smethod_29(num7, num8, num7, num8, num, double_3, double_4));
			arrayList.AddRange(c);
			if (line.method_2() == Enum114.const_3)
			{
				double num9 = num3 / 2f;
				num5 = (double)class913_0.Width * num9 / num4;
				num6 = (double)class913_0.Height * num9 / num4;
				double num10 = ((class913_0.int_3 == 1 || class913_0.int_3 == 2) ? ((double)class913_0.X - num5) : ((double)class913_0.method_8().Right + num5));
				double num11 = ((class913_0.int_3 == 1 || class913_0.int_3 == 4) ? ((double)class913_0.Y - num6) : ((double)class913_0.method_8().Bottom + num6));
				arrayList.Add(new PointF((float)num10, (float)num11));
			}
			else if (line.method_2() == Enum114.const_4)
			{
				double num12 = num3 / 2f;
				num5 = (double)class913_0.Width * num12 / num4;
				num6 = (double)class913_0.Height * num12 / num4;
				double num13 = ((class913_0.int_3 == 1 || class913_0.int_3 == 2) ? ((double)class913_0.X - num5) : ((double)class913_0.method_8().Right + num5));
				double num14 = ((class913_0.int_3 == 1 || class913_0.int_3 == 4) ? ((double)class913_0.Y - num6) : ((double)class913_0.method_8().Bottom + num6));
				arrayList.Add(new PointF((float)num13, (float)num14));
			}
			float num15 = 0f;
			float num16 = 0f;
			switch (line.method_12())
			{
			case Enum113.const_0:
				num16 = 3f * num;
				break;
			case Enum113.const_1:
				num16 = 4f * num;
				break;
			case Enum113.const_2:
				num16 = 6f * num;
				break;
			}
			switch (line.method_10())
			{
			case Enum115.const_0:
				num15 = 3f * num;
				break;
			case Enum115.const_1:
				num15 = 4f * num;
				break;
			case Enum115.const_2:
				num15 = 6f * num;
				break;
			}
			if (line.method_8() == Enum114.const_5)
			{
				num15 += 2f * num;
				num16 += 2f * num;
			}
			double num17 = Math.Sqrt(Math.Pow(class913_0.Width, 2.0) + Math.Pow(class913_0.Height, 2.0));
			double num18 = 0.0;
			double num19 = 0.0;
			switch (line.method_8())
			{
			case Enum114.const_1:
			case Enum114.const_2:
			case Enum114.const_5:
				num18 = (double)(class913_0.Width * num16) / num17;
				num19 = (double)(class913_0.Height * num16) / num17;
				break;
			}
			double double_6 = ((class913_0.int_3 == 3 || class913_0.int_3 == 4) ? ((double)class913_0.X + num18) : ((double)class913_0.method_8().Right - num18));
			double double_7 = ((class913_0.int_3 == 3 || class913_0.int_3 == 2) ? ((double)class913_0.Y + num19) : ((double)class913_0.method_8().Bottom - num19));
			double num20;
			double num21;
			double double_8;
			double double_9;
			switch (class913_0.int_3)
			{
			default:
				num20 = class913_0.X;
				num21 = class913_0.Y;
				double_8 = class913_0.method_8().Right;
				double_9 = class913_0.method_8().Bottom;
				break;
			case 1:
				num20 = class913_0.method_8().Right;
				num21 = class913_0.method_8().Bottom;
				double_8 = class913_0.X;
				double_9 = class913_0.Y;
				break;
			case 2:
				num20 = class913_0.method_8().Right;
				num21 = class913_0.Y;
				double_8 = class913_0.X;
				double_9 = class913_0.method_8().Bottom;
				break;
			case 3:
				num20 = class913_0.X;
				num21 = class913_0.Y;
				double_8 = class913_0.method_8().Right;
				double_9 = class913_0.method_8().Bottom;
				break;
			case 4:
				num20 = class913_0.X;
				num21 = class913_0.method_8().Bottom;
				double_8 = class913_0.method_8().Right;
				double_9 = class913_0.Y;
				break;
			}
			double double_10 = num15;
			PointF[] array = smethod_29(num20, num21, double_6, double_7, double_10, double_8, double_9);
			array = ((line.method_8() != 0) ? smethod_29(num20, num21, double_6, double_7, double_10, double_8, double_9) : smethod_29(num20, num21, num20, num21, num, double_8, double_9));
			arrayList.AddRange(array);
			if (line.method_8() == Enum114.const_3)
			{
				double num22 = num16 / 2f;
				num18 = (double)class913_0.Width * num22 / num17;
				num19 = (double)class913_0.Height * num22 / num17;
				double num23 = ((class913_0.int_3 == 3 || class913_0.int_3 == 4) ? ((double)class913_0.X - num18) : ((double)class913_0.method_8().Right + num18));
				double num24 = ((class913_0.int_3 == 3 || class913_0.int_3 == 2) ? ((double)class913_0.Y - num19) : ((double)class913_0.method_8().Bottom + num19));
				arrayList.Add(new PointF((float)num23, (float)num24));
			}
			else if (line.method_8() == Enum114.const_4)
			{
				double num25 = num16 / 2f;
				num18 = (double)class913_0.Width * num25 / num17;
				num19 = (double)class913_0.Height * num25 / num17;
				double num26 = ((class913_0.int_3 == 3 || class913_0.int_3 == 4) ? ((double)class913_0.X - num18) : ((double)class913_0.method_8().Right + num18));
				double num27 = ((class913_0.int_3 == 3 || class913_0.int_3 == 2) ? ((double)class913_0.Y - num19) : ((double)class913_0.method_8().Bottom + num19));
				arrayList.Add(new PointF((float)num26, (float)num27));
				arrayList.Add(new PointF((float)(num20 - (double)(num16 / 2f)), (float)num21));
				arrayList.Add(new PointF((float)(num20 + (double)(num16 / 2f)), (float)num21));
				arrayList.Add(new PointF((float)num20, (float)(num21 - (double)(num15 / 2f))));
				arrayList.Add(new PointF((float)num20, (float)(num21 + (double)(num15 / 2f))));
			}
		}
		return smethod_30(smethod_31(arrayList));
	}

	internal static RectangleF smethod_11(Class913 class913_0)
	{
		RectangleF result = default(RectangleF);
		bool flag = false;
		bool flag2 = false;
		Enum114 @enum = Enum114.const_0;
		if (class913_0.Line.method_2() != 0)
		{
			@enum = class913_0.Line.method_2();
			flag = true;
		}
		if (class913_0.Line.method_8() != 0)
		{
			@enum = class913_0.Line.method_8();
			flag2 = true;
		}
		switch (@enum)
		{
		default:
			if (class913_0.Line.Weight <= 1f)
			{
				if (class913_0.method_8().Height <= class913_0.Line.Weight)
				{
					float height4 = 2f * class913_0.Line.Weight;
					result = new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + class913_0.Line.Weight / 2f + 1f, height4);
				}
				else if (class913_0.method_8().Width <= class913_0.Line.Weight)
				{
					float width4 = 2f * class913_0.Line.Weight;
					result = new RectangleF(class913_0.X, class913_0.Y, width4, class913_0.method_8().Height);
				}
				else
				{
					result = ((!(class913_0.Width > class913_0.Height)) ? ((!(class913_0.Width < class913_0.Height)) ? new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width, class913_0.method_8().Height) : ((!flag || !flag2) ? new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + 4f * class913_0.Line.Weight, class913_0.method_8().Height) : new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + 2f * (4f * class913_0.Line.Weight), class913_0.method_8().Height))) : ((!flag || !flag2) ? new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width, class913_0.method_8().Height + 4f * class913_0.Line.Weight) : new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width, class913_0.method_8().Height + 2f * (4f * class913_0.Line.Weight))));
				}
			}
			break;
		case Enum114.const_1:
			if (class913_0.Line.Weight <= 1f)
			{
				if (class913_0.method_8().Height <= class913_0.Line.Weight)
				{
					float height5 = 9f * class913_0.Line.Weight;
					result = new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + class913_0.Line.Weight / 2f + 1f, height5);
				}
				else if (class913_0.method_8().Width <= class913_0.Line.Weight)
				{
					float width5 = 9f * class913_0.Line.Weight;
					result = new RectangleF(class913_0.X, class913_0.Y, width5, class913_0.method_8().Height);
				}
				else
				{
					result = ((!(class913_0.Width > class913_0.Height)) ? ((!(class913_0.Width < class913_0.Height)) ? new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width, class913_0.method_8().Height) : ((!flag || !flag2) ? new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + 4f * class913_0.Line.Weight, class913_0.method_8().Height) : new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + 2f * (4f * class913_0.Line.Weight), class913_0.method_8().Height))) : ((!flag || !flag2) ? new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width, class913_0.method_8().Height + 4f * class913_0.Line.Weight) : new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width, class913_0.method_8().Height + 2f * (4f * class913_0.Line.Weight))));
				}
			}
			break;
		case Enum114.const_2:
			if (class913_0.Line.Weight <= 1f)
			{
				if (class913_0.method_8().Height <= class913_0.Line.Weight)
				{
					float height2 = 9f * class913_0.Line.Weight;
					result = new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + class913_0.Line.Weight / 2f + 1f, height2);
				}
				else if (class913_0.method_8().Width <= class913_0.Line.Weight)
				{
					float width2 = 9f * class913_0.Line.Weight;
					result = new RectangleF(class913_0.X, class913_0.Y, width2, class913_0.method_8().Height);
				}
				else
				{
					result = ((!(class913_0.Width > class913_0.Height)) ? ((!(class913_0.Width < class913_0.Height)) ? new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width, class913_0.method_8().Height) : new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + 2f * (4f * class913_0.Line.Weight), class913_0.method_8().Height)) : new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width, class913_0.method_8().Height + 2f * (4f * class913_0.Line.Weight)));
				}
			}
			break;
		case Enum114.const_3:
			if (class913_0.Line.Weight <= 1f)
			{
				if (class913_0.method_8().Height <= class913_0.Line.Weight)
				{
					float height3 = 12f * class913_0.Line.Weight;
					result = ((!flag || !flag2) ? new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + class913_0.Line.Weight * 5f, height3) : new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + class913_0.Line.Weight * 5f * 2f, height3));
				}
				else if (class913_0.method_8().Width <= class913_0.Line.Weight)
				{
					float width3 = 12f * class913_0.Line.Weight;
					result = ((!flag || !flag2) ? new RectangleF(class913_0.X, class913_0.Y, width3, class913_0.method_8().Height + 5f * class913_0.Line.Weight) : new RectangleF(class913_0.X, class913_0.Y, width3, class913_0.method_8().Height + 5f * class913_0.Line.Weight * 2f));
				}
				else
				{
					result = new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + 2f * (4f * class913_0.Line.Weight), class913_0.method_8().Height + 2f * (4f * class913_0.Line.Weight));
				}
			}
			break;
		case Enum114.const_4:
			if (class913_0.Line.Weight <= 1f)
			{
				if (class913_0.method_8().Height <= class913_0.Line.Weight)
				{
					float height6 = 12f * class913_0.Line.Weight;
					result = ((!flag || !flag2) ? new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + class913_0.Line.Weight * 5f, height6) : new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + class913_0.Line.Weight * 5f * 2f, height6));
				}
				else if (class913_0.method_8().Width <= class913_0.Line.Weight)
				{
					float width6 = 12f * class913_0.Line.Weight;
					result = ((!flag || !flag2) ? new RectangleF(class913_0.X, class913_0.Y, width6, class913_0.method_8().Height + 5f * class913_0.Line.Weight) : new RectangleF(class913_0.X, class913_0.Y, width6, class913_0.method_8().Height + 5f * class913_0.Line.Weight * 2f));
				}
				else
				{
					result = new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + 2f * (5f * class913_0.Line.Weight), class913_0.method_8().Height + 2f * (5f * class913_0.Line.Weight));
				}
			}
			break;
		case Enum114.const_5:
			if (class913_0.Line.Weight <= 1f)
			{
				if (class913_0.method_8().Height <= class913_0.Line.Weight)
				{
					float height = 12f * class913_0.Line.Weight;
					result = new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + class913_0.Line.Weight / 2f + 1f, height);
				}
				else if (class913_0.method_8().Width <= class913_0.Line.Weight)
				{
					float width = 12f * class913_0.Line.Weight;
					result = new RectangleF(class913_0.X, class913_0.Y, width, class913_0.method_8().Height + class913_0.Line.Weight / 2f + 1f);
				}
				else
				{
					result = ((!(class913_0.Width > class913_0.Height)) ? ((!(class913_0.Width < class913_0.Height)) ? new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width, class913_0.method_8().Height) : new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + 2f * (4f * class913_0.Line.Weight), class913_0.method_8().Height)) : new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + 10f, class913_0.method_8().Height + 2f + 2f * (4f * class913_0.Line.Weight)));
				}
			}
			break;
		}
		return result;
	}

	internal static RectangleF smethod_12(Class913 class913_0)
	{
		float float_ = 0f;
		float float_2 = 0f;
		float float_3 = 0f;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float weight = class913_0.Line.Weight;
		num3 = ((class913_0.class901_0 == null) ? (((class913_0.Width > class913_0.Height) ? class913_0.Width : class913_0.Height) * 50000f / 100000f) : (((class913_0.Width > class913_0.Height) ? class913_0.Width : class913_0.Height) * (Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) - 50000f) / 100000f));
		if (class913_0.Line.method_2() != 0)
		{
			smethod_13(class913_0.Line.method_2(), class913_0.Line.method_4(), class913_0.Line.method_6(), class913_0.Line, ref float_2, ref float_);
		}
		if (class913_0.Line.method_8() != 0)
		{
			smethod_13(class913_0.Line.method_8(), class913_0.Line.method_10(), class913_0.Line.method_12(), class913_0.Line, ref float_2, ref float_3);
		}
		if (class913_0.Width > class913_0.Height)
		{
			num2 += weight + float_ + float_3;
			num = ((!(Math.Abs(num3) >= class913_0.Width / 2f)) ? (num + 0f) : (num + (weight / 2f + Math.Abs(num3) - class913_0.Width / 2f)));
		}
		else
		{
			num = weight + float_ + float_3;
			if (Math.Abs(num3) >= class913_0.Height / 2f)
			{
				num2 += weight / 2f + Math.Abs(num3) - class913_0.Height / 2f;
			}
		}
		RectangleF result = new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width + num, class913_0.method_8().Height + num2);
		return result;
	}

	private static void smethod_13(Enum114 enum114_0, Enum115 enum115_0, Enum113 enum113_0, Class906 class906_0, ref float float_0, ref float float_1)
	{
		if (class906_0.Weight <= 1f)
		{
			switch (enum115_0)
			{
			case Enum115.const_0:
				switch (enum114_0)
				{
				case Enum114.const_1:
					float_0 = 4f;
					break;
				case Enum114.const_2:
					float_0 = 4f;
					break;
				case Enum114.const_3:
					float_0 = 4f;
					break;
				case Enum114.const_4:
					float_0 = 4f;
					break;
				case Enum114.const_5:
					float_0 = 8f;
					break;
				}
				break;
			case Enum115.const_1:
				switch (enum114_0)
				{
				case Enum114.const_1:
					float_0 = 4f;
					break;
				case Enum114.const_2:
					float_0 = 4f;
					break;
				case Enum114.const_3:
					float_0 = 4f;
					break;
				case Enum114.const_4:
					float_0 = 4f;
					break;
				case Enum114.const_5:
					float_0 = 8f;
					break;
				}
				break;
			default:
				switch (enum114_0)
				{
				case Enum114.const_1:
					float_1 = 4f;
					break;
				case Enum114.const_2:
					float_1 = 4f;
					break;
				case Enum114.const_3:
					float_1 = 4f;
					break;
				case Enum114.const_4:
					float_1 = 4f;
					break;
				case Enum114.const_5:
					float_1 = 8f;
					break;
				}
				break;
			}
			switch (enum113_0)
			{
			case Enum113.const_0:
				switch (enum114_0)
				{
				case Enum114.const_1:
					float_1 = 4f;
					break;
				case Enum114.const_2:
					float_1 = 4f;
					break;
				case Enum114.const_3:
					float_1 = 4f;
					break;
				case Enum114.const_4:
					float_1 = 4f;
					break;
				case Enum114.const_5:
					float_1 = 8f;
					break;
				}
				break;
			case Enum113.const_1:
				switch (enum114_0)
				{
				case Enum114.const_1:
					float_1 = 6f;
					break;
				case Enum114.const_2:
					float_1 = 4f;
					break;
				case Enum114.const_3:
					float_1 = 4f;
					break;
				case Enum114.const_4:
					float_1 = 4f;
					break;
				case Enum114.const_5:
					float_1 = 10f;
					break;
				}
				break;
			default:
				switch (enum114_0)
				{
				case Enum114.const_1:
					float_1 = 6f;
					break;
				case Enum114.const_2:
					float_1 = 6f;
					break;
				case Enum114.const_3:
					float_1 = 6f;
					break;
				case Enum114.const_4:
					float_1 = 6f;
					break;
				case Enum114.const_5:
					float_1 = 10f;
					break;
				}
				break;
			}
		}
		else
		{
			switch (enum115_0)
			{
			case Enum115.const_0:
				float_0 = 3f;
				break;
			case Enum115.const_1:
				float_0 = 3f;
				break;
			default:
				float_0 = 5f;
				break;
			}
			switch (enum113_0)
			{
			case Enum113.const_0:
				float_1 = 3f;
				break;
			case Enum113.const_1:
				float_1 = 3f;
				break;
			default:
				float_1 = 5f;
				break;
			}
		}
	}

	internal static RectangleF smethod_14(Class913 class913_0)
	{
		float num = 0f;
		float num2 = 0f;
		if (class913_0.class901_0 != null)
		{
			num = class913_0.Width / 2f + Math.Abs(class913_0.Width * (Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f));
			num2 = class913_0.Height / 2f + Math.Abs(class913_0.Height * (Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f));
		}
		else
		{
			num = class913_0.Width / 2f + Math.Abs(class913_0.Width * -0.20473f);
			num2 = class913_0.Height / 2f + Math.Abs(class913_0.Height * 0.61957f);
		}
		RectangleF result = default(RectangleF);
		if (num > class913_0.Width && num2 > class913_0.Height)
		{
			result = new RectangleF(class913_0.X, class913_0.Y, num, num2);
		}
		else if (num > class913_0.Width && num2 < class913_0.Height)
		{
			result = new RectangleF(class913_0.X, class913_0.Y, num, class913_0.method_8().Height);
		}
		else if (num < class913_0.Width && num2 > class913_0.Height)
		{
			result = new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width, num2);
		}
		else if (num < class913_0.Width && num2 < class913_0.Height)
		{
			result = new RectangleF(class913_0.X, class913_0.Y, class913_0.method_8().Width, class913_0.method_8().Height);
		}
		result.Inflate(class913_0.Line.Weight / 2f, class913_0.Line.Weight / 2f);
		return result;
	}

	internal static RectangleF smethod_15(Class913 class913_0)
	{
		RectangleF rectangleF = default(RectangleF);
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		double num5 = Struct70.smethod_0(class913_0.Rotation);
		double num6 = Struct70.smethod_0(90 - class913_0.Rotation);
		num = (float)((double)class913_0.Width * Math.Sin(num5));
		num2 = (float)((double)class913_0.Width * Math.Cos(num5));
		num3 = (float)((double)class913_0.Height * Math.Cos(num6));
		num4 = (float)((double)class913_0.Height * Math.Sin(num6));
		float num7 = 0f;
		float num8 = 0f;
		num7 = Math.Abs(num2) + Math.Abs(num3);
		num8 = Math.Abs(num) + Math.Abs(num4);
		rectangleF = new RectangleF(class913_0.X, class913_0.Y, num7, num8);
		rectangleF.Inflate(class913_0.Line.Weight, class913_0.Line.Weight);
		return rectangleF;
	}

	internal static RectangleF smethod_16(Class913 class913_0)
	{
		RectangleF rectangleF = default(RectangleF);
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		double num5 = Struct70.smethod_0(class913_0.Rotation);
		double num6 = Struct70.smethod_0(90 - class913_0.Rotation);
		num = (float)((double)class913_0.Width * Math.Sin(num5));
		num2 = (float)((double)class913_0.Width * Math.Cos(num5));
		num3 = (float)((double)class913_0.Height * Math.Cos(num6));
		num4 = (float)((double)class913_0.Height * Math.Sin(num6));
		float num7 = 0f;
		float num8 = 0f;
		num7 = Math.Abs(num2) + Math.Abs(num3);
		num8 = Math.Abs(num) + Math.Abs(num4);
		rectangleF = new RectangleF(class913_0.X, class913_0.Y, num7, num8);
		rectangleF.Inflate(class913_0.Line.Weight, class913_0.Line.Weight);
		if (class913_0.Line.method_2() != 0 || class913_0.Line.method_8() != 0)
		{
			if (rectangleF.Width < rectangleF.Height)
			{
				rectangleF.Width += 4f;
			}
			else
			{
				rectangleF.Height += 4f;
			}
		}
		return rectangleF;
	}

	internal static RectangleF smethod_17(Class913 class913_0)
	{
		RectangleF rectangleF = default(RectangleF);
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		double num5 = Struct70.smethod_0(class913_0.Rotation);
		double num6 = Struct70.smethod_0(90 - class913_0.Rotation);
		num = (float)((double)class913_0.Width * Math.Sin(num5));
		num2 = (float)((double)class913_0.Width * Math.Cos(num5));
		num3 = (float)((double)class913_0.Height * Math.Cos(num6));
		num4 = (float)((double)class913_0.Height * Math.Sin(num6));
		float num7 = 0f;
		float num8 = 0f;
		num7 = Math.Abs(num2) + Math.Abs(num3);
		num8 = Math.Abs(num) + Math.Abs(num4);
		rectangleF = new RectangleF(class913_0.X, class913_0.Y, num7, num8);
		rectangleF.Inflate(class913_0.Line.Weight, class913_0.Line.Weight);
		return rectangleF;
	}

	private static Color smethod_18(Class900 class900_0, float float_0, float float_1)
	{
		Color color = class900_0.method_2();
		float num = (int)color.A;
		float val = color.R + (int)float_1;
		val = Math.Max(0f, Math.Min(val, 255f)) * float_0;
		float val2 = color.G + (int)float_1;
		val2 = Math.Max(0f, Math.Min(val2, 255f)) * float_0;
		float val3 = color.B + (int)float_1;
		val3 = Math.Max(0f, Math.Min(val3, 255f)) * float_0;
		return Color.FromArgb((int)num, (int)val, (int)val2, (int)val3);
	}

	internal static Brush smethod_19(Class900 class900_0, RectangleF rectangleF_0, float float_0, float float_1)
	{
		if (class900_0.method_0())
		{
			return new SolidBrush(Color.Empty);
		}
		Brush brush = null;
		if (class900_0.method_5())
		{
			return class900_0.FillFormat.method_2(rectangleF_0);
		}
		return new SolidBrush(smethod_18(class900_0, float_0, float_1));
	}

	internal static Brush smethod_20(Class900 class900_0, RectangleF rectangleF_0)
	{
		if (class900_0.method_0())
		{
			return new SolidBrush(Color.Empty);
		}
		Brush brush = null;
		if (class900_0.method_5())
		{
			return class900_0.FillFormat.method_2(rectangleF_0);
		}
		return new SolidBrush(class900_0.method_2());
	}

	internal static Brush smethod_21(Class900 class900_0, GraphicsPath graphicsPath_0)
	{
		if (class900_0.method_0())
		{
			return new SolidBrush(Color.Empty);
		}
		Brush brush = null;
		if (class900_0.method_5())
		{
			return class900_0.FillFormat.method_3(graphicsPath_0, null, bool_0: false, 1f);
		}
		return new SolidBrush(class900_0.method_2());
	}

	internal static RectangleF smethod_22(Class913 class913_0)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		if (class913_0.class901_0 != null)
		{
			num = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f * class913_0.Height;
			num2 = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f * class913_0.Width;
			num3 = Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f * class913_0.Height;
			num4 = Convert.ToSingle(class913_0.class901_0.arrayList_0[3]) / 100000f * class913_0.Width;
		}
		else
		{
			num = 0.1875f * class913_0.Height;
			num2 = -0.08333f * class913_0.Width;
			num3 = 1.125f * class913_0.Height;
			num4 = -0.38333f * class913_0.Width;
		}
		float num5 = 0f;
		float num6 = num2;
		float num7 = num4;
		float num8 = ((num6 > num7) ? num7 : num6);
		float num9 = ((num6 < num7) ? num7 : num6);
		if (num8 < 0f)
		{
			num5 += 0f - num8;
		}
		if (num9 > class913_0.Width)
		{
			num5 += num9 - class913_0.Width;
		}
		float num10 = 0f;
		float num11 = num;
		float num12 = num3;
		float num13 = ((num11 > num12) ? num12 : num11);
		float num14 = ((num11 < num12) ? num12 : num11);
		if (num13 < 0f)
		{
			num10 += 0f - num13;
		}
		if (num14 > class913_0.Height)
		{
			num10 += num14 - class913_0.Height;
		}
		RectangleF result = new RectangleF(class913_0.X, class913_0.Y, class913_0.Width + num5, class913_0.Height + num10);
		result.Inflate(class913_0.Line.Weight / 2f, class913_0.Line.Weight / 2f);
		return result;
	}

	internal static RectangleF smethod_23(Class913 class913_0)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		if (class913_0.class901_0 != null)
		{
			num = Convert.ToSingle(class913_0.class901_0.arrayList_0[5]) / 100000f * class913_0.Width;
			num2 = Convert.ToSingle(class913_0.class901_0.arrayList_0[4]) / 100000f * class913_0.Height;
			num3 = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f * class913_0.Width;
			num4 = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f * class913_0.Height;
			num5 = Convert.ToSingle(class913_0.class901_0.arrayList_0[3]) / 100000f * class913_0.Width;
			num6 = Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f * class913_0.Height;
		}
		else
		{
			num = -0.46667f * class913_0.Width;
			num2 = 1.125f * class913_0.Height;
			num3 = -0.08333f * class913_0.Width;
			num4 = 0.1875f * class913_0.Height;
			num5 = -0.16667f * class913_0.Width;
			num6 = 0.1875f * class913_0.Height;
		}
		float num7 = 0f;
		float num8 = num;
		float num9 = num3;
		float num10 = num5;
		float num11 = ((!(num10 > ((num8 > num9) ? num9 : num8))) ? num10 : ((num8 > num9) ? num9 : num8));
		float num12 = ((!(num10 < ((num8 < num9) ? num9 : num8))) ? num10 : ((num8 < num9) ? num9 : num8));
		if (num11 < 0f)
		{
			num7 += 0f - num11;
		}
		if (num12 > class913_0.Width)
		{
			num7 += num12 - class913_0.Width;
		}
		float num13 = 0f;
		float num14 = num2;
		float num15 = num4;
		float num16 = num6;
		float num17 = ((!(num16 > ((num14 > num15) ? num15 : num14))) ? num16 : ((num14 > num15) ? num15 : num14));
		float num18 = ((!(num16 < ((num14 < num15) ? num15 : num14))) ? num16 : ((num14 < num15) ? num15 : num14));
		if (num17 < 0f)
		{
			num13 += 0f - num17;
		}
		if (num18 > class913_0.Height)
		{
			num13 += num18 - class913_0.Height;
		}
		RectangleF result = new RectangleF(class913_0.X, class913_0.Y, class913_0.Width + num7, class913_0.Height + num13);
		result.Inflate(class913_0.Line.Weight / 2f, class913_0.Line.Weight / 2f);
		return result;
	}

	internal static RectangleF smethod_24(Class913 class913_0)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		if (class913_0.class901_0 != null)
		{
			num = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f * class913_0.Width;
			num2 = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f * class913_0.Height;
			num3 = Convert.ToSingle(class913_0.class901_0.arrayList_0[3]) / 100000f * class913_0.Width;
			num4 = Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f * class913_0.Height;
			num5 = Convert.ToSingle(class913_0.class901_0.arrayList_0[5]) / 100000f * class913_0.Width;
			num6 = Convert.ToSingle(class913_0.class901_0.arrayList_0[4]) / 100000f * class913_0.Height;
			num7 = Convert.ToSingle(class913_0.class901_0.arrayList_0[7]) / 100000f * class913_0.Width;
			num8 = Convert.ToSingle(class913_0.class901_0.arrayList_0[6]) / 100000f * class913_0.Height;
		}
		else
		{
			num = -0.08333f * class913_0.Width;
			num2 = 0.1875f * class913_0.Height;
			num3 = -0.16667f * class913_0.Width;
			num4 = 0.1875f * class913_0.Height;
			num5 = -0.16667f * class913_0.Width;
			num6 = 1f * class913_0.Height;
			num7 = -0.08333f * class913_0.Width;
			num8 = 1.12963f * class913_0.Height;
		}
		float num9 = 0f;
		float num10 = num;
		float num11 = num3;
		float num12 = num5;
		float num13 = num7;
		float num14 = ((!(num12 > ((num10 > num11) ? num11 : num10))) ? num12 : ((num10 > num11) ? num11 : num10));
		num14 = ((num13 > num14) ? num14 : num13);
		float num15 = ((!(num12 < ((num10 < num11) ? num11 : num10))) ? num12 : ((num10 < num11) ? num11 : num10));
		num15 = ((num13 < num15) ? num15 : num13);
		if (num14 < 0f)
		{
			num9 += 0f - num14;
		}
		if (num15 > class913_0.Width)
		{
			num9 += num15 - class913_0.Width;
		}
		float num16 = 0f;
		float num17 = num2;
		float num18 = num4;
		float num19 = num6;
		float num20 = num8;
		float num21 = ((!(num19 > ((num17 > num18) ? num18 : num17))) ? num19 : ((num17 > num18) ? num18 : num17));
		num21 = ((num20 > num21) ? num21 : num20);
		float num22 = ((!(num19 < ((num17 < num18) ? num18 : num17))) ? num19 : ((num17 < num18) ? num18 : num17));
		num22 = ((num20 < num22) ? num22 : num20);
		if (num21 < 0f)
		{
			num16 += 0f - num21;
		}
		if (num22 > class913_0.Height)
		{
			num16 += num22 - class913_0.Height;
		}
		RectangleF result = new RectangleF(class913_0.X, class913_0.Y, class913_0.Width + num9, class913_0.Height + num16);
		result.Inflate(class913_0.Line.Weight / 2f, class913_0.Line.Weight / 2f);
		return result;
	}

	internal static RectangleF smethod_25(Class913 class913_0)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		if (class913_0.class901_0 != null)
		{
			num = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f * class913_0.Width;
			num2 = Convert.ToSingle(class913_0.class901_0.arrayList_0[3]) / 100000f * class913_0.Width;
			num3 = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f * class913_0.Height;
			_ = Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f;
			_ = class913_0.Height;
		}
		else
		{
			num = -0.08333f * class913_0.Width;
			num2 = -0.38333f * class913_0.Width;
			num3 = 0.1875f * class913_0.Height;
			_ = class913_0.Height;
		}
		float num4 = 0f;
		float num5 = num;
		float num6 = num2;
		float num7 = ((num5 > num6) ? num6 : num5);
		float num8 = ((num5 < num6) ? num6 : num5);
		if (num7 < 0f)
		{
			num4 += 0f - num7;
		}
		if (num8 > class913_0.Width)
		{
			num4 += num8 - class913_0.Width;
		}
		float num9 = 0f;
		float num10 = num;
		float num11 = num3;
		float num12 = ((num10 > num11) ? num11 : num10);
		float num13 = ((num10 < num11) ? num11 : num10);
		if (num12 < 0f)
		{
			num9 += 0f - num12;
		}
		if (num13 > class913_0.Height)
		{
			num9 += num13 - class913_0.Height;
		}
		RectangleF result = new RectangleF(class913_0.X, class913_0.Y, class913_0.Width + num4, class913_0.Height + num9);
		result.Inflate(class913_0.Line.Weight / 2f, class913_0.Line.Weight / 2f);
		return result;
	}

	internal static RectangleF smethod_26(Class913 class913_0)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		if (class913_0.class901_0 != null)
		{
			num = Convert.ToSingle(class913_0.class901_0.arrayList_0[5]) / 100000f * class913_0.Width;
			num2 = Convert.ToSingle(class913_0.class901_0.arrayList_0[4]) / 100000f * class913_0.Height;
			num3 = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f * class913_0.Width;
			num4 = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f * class913_0.Height;
			num5 = Convert.ToSingle(class913_0.class901_0.arrayList_0[3]) / 100000f * class913_0.Width;
			num6 = Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f * class913_0.Height;
		}
		else
		{
			num = -0.46667f * class913_0.Width;
			num2 = 1.125f * class913_0.Height;
			num3 = -0.08333f * class913_0.Width;
			num4 = 0.1875f * class913_0.Height;
			num5 = -0.16667f * class913_0.Width;
			num6 = 0.1875f * class913_0.Height;
		}
		float num7 = 0f;
		float num8 = num;
		float num9 = num3;
		float num10 = num5;
		float num11 = ((!(num10 > ((num8 > num9) ? num9 : num8))) ? num10 : ((num8 > num9) ? num9 : num8));
		float num12 = ((!(num10 < ((num8 < num9) ? num9 : num8))) ? num10 : ((num8 < num9) ? num9 : num8));
		if (num11 < 0f)
		{
			num7 += 0f - num11;
		}
		if (num12 > class913_0.Width)
		{
			num7 += num12 - class913_0.Width;
		}
		float num13 = 0f;
		float num14 = num2;
		float num15 = num4;
		float num16 = num6;
		float num17 = ((!(num16 > ((num14 > num15) ? num15 : num14))) ? num16 : ((num14 > num15) ? num15 : num14));
		float num18 = ((!(num16 < ((num14 < num15) ? num15 : num14))) ? num16 : ((num14 < num15) ? num15 : num14));
		if (num17 < 0f)
		{
			num13 += 0f - num17;
		}
		if (num18 > class913_0.Height)
		{
			num13 += num18 - class913_0.Height;
		}
		RectangleF result = new RectangleF(class913_0.X, class913_0.Y, class913_0.Width + num7, class913_0.Height + num13);
		result.Inflate(class913_0.Line.Weight / 2f, class913_0.Line.Weight / 2f);
		return result;
	}

	internal static RectangleF smethod_27(Class913 class913_0)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		if (class913_0.class901_0 != null)
		{
			num = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f * class913_0.Width;
			num2 = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f * class913_0.Height;
			num3 = Convert.ToSingle(class913_0.class901_0.arrayList_0[3]) / 100000f * class913_0.Width;
			num4 = Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f * class913_0.Height;
			num5 = Convert.ToSingle(class913_0.class901_0.arrayList_0[5]) / 100000f * class913_0.Width;
			num6 = Convert.ToSingle(class913_0.class901_0.arrayList_0[4]) / 100000f * class913_0.Height;
			num7 = Convert.ToSingle(class913_0.class901_0.arrayList_0[7]) / 100000f * class913_0.Width;
			num8 = Convert.ToSingle(class913_0.class901_0.arrayList_0[6]) / 100000f * class913_0.Height;
		}
		else
		{
			num = -0.08333f * class913_0.Width;
			num2 = 0.1875f * class913_0.Height;
			num3 = -0.08333f * class913_0.Width;
			num4 = 0.1875f * class913_0.Height;
			num5 = -0.16667f * class913_0.Width;
			num6 = 1f * class913_0.Height;
			num7 = -0.08918f * class913_0.Width;
			num8 = 1.12963f * class913_0.Height;
		}
		float num9 = 0f;
		float num10 = num;
		float num11 = num3;
		float num12 = num5;
		float num13 = num7;
		float num14 = ((!(num12 > ((num10 > num11) ? num11 : num10))) ? num12 : ((num10 > num11) ? num11 : num10));
		num14 = ((num13 > num14) ? num14 : num13);
		float num15 = ((!(num12 < ((num10 < num11) ? num11 : num10))) ? num12 : ((num10 < num11) ? num11 : num10));
		num15 = ((num13 < num15) ? num15 : num13);
		if (num14 < 0f)
		{
			num9 += 0f - num14;
		}
		if (num15 > class913_0.Width)
		{
			num9 += num15 - class913_0.Width;
		}
		float num16 = 0f;
		float num17 = num2;
		float num18 = num4;
		float num19 = num6;
		float num20 = num8;
		float num21 = ((!(num19 > ((num17 > num18) ? num18 : num17))) ? num19 : ((num17 > num18) ? num18 : num17));
		num21 = ((num20 > num21) ? num21 : num20);
		float num22 = ((!(num19 < ((num17 < num18) ? num18 : num17))) ? num19 : ((num17 < num18) ? num18 : num17));
		num22 = ((num20 < num22) ? num22 : num20);
		if (num21 < 0f)
		{
			num16 += 0f - num21;
		}
		if (num22 > class913_0.Height)
		{
			num16 += num22 - class913_0.Height;
		}
		RectangleF result = new RectangleF(class913_0.X, class913_0.Y, class913_0.Width + num9, class913_0.Height + num16);
		result.Inflate(class913_0.Line.Weight / 2f, class913_0.Line.Weight / 2f);
		return result;
	}

	internal static RectangleF smethod_28(Class913 class913_0)
	{
		float width = class913_0.Width;
		float height = class913_0.Height;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		if (class913_0.class901_0 != null)
		{
			num = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f * width;
			num2 = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f * height;
		}
		else
		{
			num = -0.20833f * width;
			num2 = 0.625f * height;
		}
		num3 = ((!(Math.Abs(num) > width / 2f)) ? 0f : (Math.Abs(num) - width / 2f + width / 36f));
		num4 = ((!(Math.Abs(num2) > height / 2f)) ? 0f : (Math.Abs(num2) - height / 2f + height / 36f));
		RectangleF result = new RectangleF(class913_0.X, class913_0.Y, class913_0.Width + num3, class913_0.Height + num4);
		result.Inflate(class913_0.Line.Weight / 2f, class913_0.Line.Weight / 2f);
		return result;
	}

	private static PointF[] smethod_29(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6)
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

	internal static RectangleF smethod_30(PointF[] pointF_0)
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

	internal static PointF[] smethod_31(ArrayList arrayList_0)
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

	internal static RectangleF smethod_32(Class913 class913_0)
	{
		long num = 0L;
		num = ((class913_0.class901_0 == null || class913_0.class901_0.arrayList_0.Count <= 0) ? 50000 : Convert.ToInt64(class913_0.class901_0.arrayList_0[0]));
		Class878 @class = new Class878(new Class875[1]
		{
			new Class875("adj1", num)
		}, new Class879[1]
		{
			new Class879("x1", Enum89.const_0, -27273042329602L, 27273042316901L, 100000L, bool_1: false)
		}, null, new Class873[1]
		{
			new Class873(bool_1: false, 27273042316901L, -2147483647L, 2147483647L, long.MaxValue, long.MaxValue, long.MaxValue, -27273042329612L, -27273042329607L)
		}, new Class881[1]
		{
			new Class881(new Enum91[4]
			{
				Enum91.const_1,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_2
			}, new long[8] { -27273042329608L, -27273042329609L, -27273042329612L, -27273042329609L, -27273042329612L, -27273042329611L, -27273042329610L, -27273042329611L }, 0L, 0L, Enum92.const_0, bool_2: true, bool_3: true)
		}, new Class874(-27273042329608L, -27273042329609L), new Class874(-27273042329610L, -27273042329611L));
		@class.method_0(Enum93.const_1);
		float x = class913_0.X;
		float y = class913_0.Y;
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		RectangleF rectangleF = new RectangleF(x, y, width, height);
		GraphicsPath[] array = @class.method_1(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height);
		return Class1181.smethod_1(array[0]);
	}

	internal static RectangleF smethod_33(Class913 class913_0)
	{
		long num = 0L;
		long num2 = 0L;
		if (class913_0.class901_0 != null)
		{
			num = Convert.ToInt64(class913_0.class901_0.arrayList_0[0]);
			num2 = Convert.ToInt64(class913_0.class901_0.arrayList_0[1]);
		}
		else
		{
			num = 50000L;
			num2 = 50000L;
		}
		Class878 @class = new Class878(new Class875[2]
		{
			new Class875("adj1", num),
			new Class875("adj2", num2)
		}, new Class879[4]
		{
			new Class879("x1", Enum89.const_0, -27273042329602L, 27273042316901L, 100000L, bool_1: false),
			new Class879("x2", Enum89.const_2, -27273042329612L, -27273042329610L, 2L, bool_1: false),
			new Class879("y2", Enum89.const_0, -27273042329603L, 27273042316902L, 100000L, bool_1: false),
			new Class879("y1", Enum89.const_2, -27273042329609L, -27273042329614L, 2L, bool_1: false)
		}, null, new Class873[2]
		{
			new Class873(bool_1: false, 27273042316901L, -2147483647L, 2147483647L, long.MaxValue, long.MaxValue, long.MaxValue, -27273042329612L, -27273042329615L),
			new Class873(bool_1: false, long.MaxValue, long.MaxValue, long.MaxValue, 27273042316902L, -2147483647L, 2147483647L, -27273042329613L, -27273042329614L)
		}, new Class881[1]
		{
			new Class881(new Enum91[5]
			{
				Enum91.const_1,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_2,
				Enum91.const_2
			}, new long[10] { -27273042329608L, -27273042329609L, -27273042329612L, -27273042329609L, -27273042329612L, -27273042329614L, -27273042329610L, -27273042329614L, -27273042329610L, -27273042329611L }, 0L, 0L, Enum92.const_0, bool_2: true, bool_3: true)
		}, new Class874(-27273042329608L, -27273042329609L), new Class874(-27273042329610L, -27273042329611L));
		@class.method_0(Enum93.const_1);
		float x = class913_0.X;
		float y = class913_0.Y;
		float width = class913_0.method_8().Width;
		float height = class913_0.method_8().Height;
		RectangleF rectangleF = new RectangleF(x, y, width, height);
		GraphicsPath[] array = @class.method_1(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height);
		RectangleF rectangleF2 = Class1181.smethod_1(array[0]);
		rectangleF2.Inflate(class913_0.Line.Weight, class913_0.Line.Weight);
		return new RectangleF(rectangleF2.X, rectangleF2.Y, rectangleF2.Width, rectangleF2.Height);
	}
}
