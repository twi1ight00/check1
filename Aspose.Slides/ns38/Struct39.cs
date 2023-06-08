using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using ns35;
using ns36;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct39
{
	public static void smethod_0(Interface32 g, Rectangle rect, string text, int rotation, Font font, Color fontColor, Enum157 horizontalAlignment, Enum157 verticalAlignment)
	{
		RectangleF rect2 = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
		smethod_1(g, rect2, text, rotation, font, fontColor, horizontalAlignment, verticalAlignment);
	}

	public static void smethod_1(Interface32 g, RectangleF rect, string text, int rotation, Font font, Color fontColor, Enum157 horizontalAlignment, Enum157 verticalAlignment)
	{
		StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
		stringFormat.Alignment = smethod_18(horizontalAlignment);
		stringFormat.LineAlignment = smethod_18(verticalAlignment);
		switch (Math.Abs(rotation))
		{
		default:
		{
			double num = Math.Sqrt(Math.Pow(rect.Width, 2.0) + Math.Pow(rect.Height, 2.0));
			stringFormat.FormatFlags = StringFormatFlags.NoWrap;
			SizeF sizeF = g.imethod_110(text, font, (int)num, stringFormat);
			g.imethod_132(rect.Left + rect.Width / 2f, rect.Top + rect.Height / 2f);
			g.imethod_115(-rotation);
			g.imethod_61(layoutRectangle: new RectangleF((0f - sizeF.Width) / 2f, (0f - sizeF.Height) / 2f, sizeF.Width, sizeF.Height), s: text, font: font, brush: new SolidBrush(fontColor), format: stringFormat);
			g.ResetTransform();
			break;
		}
		case 90:
			g.imethod_132(rect.Left + rect.Width / 2f, rect.Top + rect.Height / 2f);
			g.imethod_115(-rotation);
			rect = new RectangleF((0f - rect.Height) / 2f, (0f - rect.Width) / 2f, rect.Height, rect.Width);
			g.imethod_61(text, font, new SolidBrush(fontColor), rect, stringFormat);
			g.ResetTransform();
			break;
		case 0:
			g.imethod_61(text, font, new SolidBrush(fontColor), rect, stringFormat);
			break;
		}
	}

	public static Size smethod_2(Interface32 g, string text, int rotation, Font font, Size layoutArea, Enum157 horizontalAlignment, Enum157 verticalAlignment)
	{
		SizeF layoutArea2 = new SizeF(layoutArea.Width, layoutArea.Height);
		return smethod_3(g, text, rotation, font, layoutArea2, horizontalAlignment, verticalAlignment);
	}

	public static Size smethod_3(Interface32 g, string text, int rotation, Font font, SizeF layoutArea, Enum157 horizontalAlignment, Enum157 verticalAlignment)
	{
		return smethod_4(g, text, rotation, font, layoutArea, horizontalAlignment, verticalAlignment, isTabelShown: false);
	}

	public static Size smethod_4(Interface32 g, string text, int rotation, Font font, SizeF layoutArea, Enum157 horizontalAlignment, Enum157 verticalAlignment, bool isTabelShown)
	{
		if (text.EndsWith("\n"))
		{
			text += " ";
		}
		switch (Math.Abs(rotation))
		{
		default:
		{
			SizeF textSize = g.imethod_108(text, font, new PointF(0f, 0f), new StringFormat(StringFormat.GenericTypographic));
			return smethod_9(textSize, layoutArea, Math.Abs(rotation));
		}
		case 90:
		{
			Size size = smethod_6(g, text, font, new SizeF((int)layoutArea.Height, (int)layoutArea.Width), horizontalAlignment, verticalAlignment);
			return new Size(size.Height, size.Width);
		}
		case 0:
		{
			float num = smethod_19(g, text, font, isExact: true);
			SizeF layoutArea2 = ((num < layoutArea.Width || isTabelShown) ? layoutArea : new SizeF(num, layoutArea.Height));
			return smethod_12(g, text, 0, font, layoutArea2, horizontalAlignment, verticalAlignment);
		}
		}
	}

	public static SizeF smethod_5(Interface32 g, string text, int rotation, Font font, SizeF layoutArea, Enum157 horizontalAlignment, Enum157 verticalAlignment, bool is3DChart)
	{
		if (text.EndsWith("\n"))
		{
			text += " ";
		}
		SizeF result = (is3DChart ? smethod_8(g, text, font, layoutArea, horizontalAlignment, verticalAlignment, StringFormat.GenericDefault) : smethod_7(g, text, font, layoutArea, horizontalAlignment, verticalAlignment));
		switch (Math.Abs(rotation))
		{
		default:
		{
			SizeF textSize = g.imethod_108(text, font, new PointF(0f, 0f), new StringFormat(StringFormat.GenericTypographic));
			return smethod_9(textSize, layoutArea, Math.Abs(rotation));
		}
		case 90:
			return smethod_7(g, text, font, new SizeF((int)layoutArea.Height, (int)layoutArea.Width), horizontalAlignment, verticalAlignment);
		case 0:
			return result;
		}
	}

	private static Size smethod_6(Interface32 g, string text, Font font, SizeF layoutArea, Enum157 horizontalAlignment, Enum157 verticalAlignment)
	{
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = smethod_18(horizontalAlignment);
		stringFormat.LineAlignment = smethod_18(verticalAlignment);
		SizeF sizeF = g.imethod_109(text, font, layoutArea, stringFormat);
		int width = Struct41.smethod_3(sizeF.Width);
		int height = Struct41.smethod_3(sizeF.Height);
		return new Size(width, height);
	}

	private static SizeF smethod_7(Interface32 g, string text, Font font, SizeF layoutArea, Enum157 horizontalAlignment, Enum157 verticalAlignment)
	{
		return smethod_8(g, text, font, layoutArea, horizontalAlignment, verticalAlignment, StringFormat.GenericTypographic);
	}

	private static SizeF smethod_8(Interface32 g, string text, Font font, SizeF layoutArea, Enum157 horizontalAlignment, Enum157 verticalAlignment, StringFormat stringFormat)
	{
		StringFormat stringFormat2 = new StringFormat(stringFormat);
		stringFormat2.Alignment = smethod_18(horizontalAlignment);
		stringFormat2.LineAlignment = smethod_18(verticalAlignment);
		return g.imethod_109(text, font, layoutArea, stringFormat2);
	}

	private static Size smethod_9(SizeF textSize, SizeF layoutArea, int rotation)
	{
		double num = (double)Math.Abs(rotation % 90) / 180.0 * Math.PI;
		double num2 = (double)textSize.Width * Math.Cos(num) + (double)textSize.Height * Math.Sin(num);
		double num3 = (double)textSize.Width * Math.Sin(num) + (double)textSize.Height * Math.Cos(num);
		if (num2 > (double)layoutArea.Width)
		{
			num3 = (double)layoutArea.Width * num3 / num2;
			num2 = layoutArea.Width;
		}
		if (num3 > (double)layoutArea.Height)
		{
			num2 = (double)layoutArea.Height * num2 / num3;
			num3 = layoutArea.Height;
		}
		return new Size(Struct41.smethod_3(num2), Struct41.smethod_3(num3));
	}

	internal static Size smethod_10(Interface32 g, string text, Font font)
	{
		SizeF sizeF = g.imethod_105(text, font);
		int width = Struct41.smethod_3(sizeF.Width);
		int height = Struct41.smethod_3(sizeF.Height);
		return new Size(width, height);
	}

	public static Size smethod_11(Interface32 g, string text, int rotation, Font font, Size layoutArea, Enum157 horizontalAlignment, Enum157 verticalAlignment)
	{
		SizeF layoutArea2 = new SizeF(layoutArea.Width, layoutArea.Height);
		return smethod_12(g, text, rotation, font, layoutArea2, horizontalAlignment, verticalAlignment);
	}

	public static Size smethod_12(Interface32 g, string text, int rotation, Font font, SizeF layoutArea, Enum157 horizontalAlignment, Enum157 verticalAlignment)
	{
		switch (Math.Abs(rotation))
		{
		default:
		{
			SizeF textSize = g.imethod_108(text, font, new PointF(0f, 0f), new StringFormat(StringFormat.GenericTypographic));
			return smethod_9(textSize, layoutArea, Math.Abs(rotation));
		}
		case 90:
		{
			Size size = smethod_13(g, text, font, new SizeF((int)layoutArea.Height, (int)layoutArea.Width), horizontalAlignment, verticalAlignment);
			return new Size(size.Height, size.Width);
		}
		case 0:
			return smethod_13(g, text, font, layoutArea, horizontalAlignment, verticalAlignment);
		}
	}

	private static Size smethod_13(Interface32 g, string text, Font font, SizeF layoutArea, Enum157 horizontalAlignment, Enum157 verticalAlignment)
	{
		StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
		stringFormat.Alignment = smethod_18(horizontalAlignment);
		stringFormat.LineAlignment = smethod_18(verticalAlignment);
		SizeF sizeF = g.imethod_109(text, font, layoutArea, stringFormat);
		int width = Struct41.smethod_3(sizeF.Width);
		int height = Struct41.smethod_3(sizeF.Height);
		return new Size(width, height);
	}

	public static SizeF smethod_14(Interface32 g, string text, Font font)
	{
		StringFormat format = new StringFormat(StringFormat.GenericTypographic);
		SizeF sizeF = g.imethod_110(text, font, int.MaxValue, format);
		int num = Struct41.smethod_3(sizeF.Width);
		int num2 = Struct41.smethod_3(sizeF.Height);
		return new SizeF(num, num2);
	}

	private static SizeF smethod_15(Interface32 g, string text, Font font)
	{
		if (text != null && !(text == ""))
		{
			StringFormat stringFormat = new StringFormat();
			CharacterRange[] measurableCharacterRanges = new CharacterRange[1]
			{
				new CharacterRange(0, text.Length)
			};
			RectangleF layoutRect = new RectangleF(0f, 0f, 2.1474836E+09f, 2.1474836E+09f);
			stringFormat.SetMeasurableCharacterRanges(measurableCharacterRanges);
			Region[] array = g.imethod_104(text, font, layoutRect, stringFormat);
			return g.GraphicsTools.imethod_0(array[0]).Size;
		}
		return new SizeF(0f, 0f);
	}

	public static SizeF smethod_16(Interface32 g, string text, Font font, Size layout)
	{
		SizeF layout2 = new SizeF(layout.Width, layout.Height);
		return smethod_17(g, text, font, layout2);
	}

	public static SizeF smethod_17(Interface32 g, string text, Font font, SizeF layout)
	{
		layout = new SizeF(layout.Width, layout.Height);
		int num = Struct41.smethod_3(g.GraphicsTools.imethod_2(font));
		if (text != null && text.Length != 0)
		{
			Regex regex = new Regex("\\n");
			Regex regex2 = new Regex("^\\s{1,}$");
			if (!regex.IsMatch(text) && (regex2.IsMatch(text) || regex2.IsMatch(text.Substring(text.Length - 1))))
			{
				SizeF result = g.imethod_108(text, font, new PointF(0f, 0f), new StringFormat(StringFormatFlags.MeasureTrailingSpaces));
				if (result.Height > (float)num * 1.5f)
				{
					return result;
				}
				string text2 = "aaaaaaaaaa";
				string text3 = text2 + text + text2;
				SizeF layout2 = new SizeF(2.1474836E+09f, 2.1474836E+09f);
				SizeF sizeF = smethod_17(g, text2, font, layout2);
				SizeF sizeF2 = smethod_17(g, text3, font, layout2);
				float width = ((sizeF2.Width - 2f * sizeF.Width > 0f) ? (sizeF2.Width - 2f * sizeF.Width) : ((float)num / 5f));
				return new SizeF(width, result.Height);
			}
			StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
			stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
			SizeF result2 = g.imethod_109(text, font, layout, stringFormat);
			bool flag = false;
			if (result2.Height < (float)num * 1.5f)
			{
				text += "|";
				layout.Width += num;
				result2 = g.imethod_109(text, font, layout, stringFormat);
				flag = true;
			}
			int num2 = Struct41.smethod_3(result2.Height);
			if (num2 >= 1 && result2.Width >= 1f)
			{
				int num3 = (int)((double)result2.Width * 0.1);
				if (num3 < 10)
				{
					num3 = 10;
				}
				Bitmap bitmap = new Bitmap(num3, num2);
				Graphics graphics = Graphics.FromImage(bitmap);
				float num4 = Struct41.smethod_3(result2.Width);
				if (!flag)
				{
					graphics.Clear(Color.White);
					graphics.DrawString(layoutRectangle: new RectangleF((float)num3 - num4, 0f, num4, num2), s: text, font: font, brush: Brushes.Black, format: stringFormat);
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
					graphics.DrawString(text, font, Brushes.Black, (float)num3 - num4, 0f, stringFormat);
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

	public static StringAlignment smethod_18(Enum157 alignment)
	{
		switch (alignment)
		{
		case Enum157.const_1:
			return StringAlignment.Center;
		default:
			return StringAlignment.Center;
		case Enum157.const_0:
		case Enum157.const_8:
			return StringAlignment.Far;
		case Enum157.const_7:
		case Enum157.const_9:
			return StringAlignment.Near;
		}
	}

	public static float smethod_19(Interface32 g, string text, Font font, bool isExact)
	{
		Regex regex = new Regex("\\s+");
		string[] array = regex.Split(text);
		float num = 0f;
		for (int i = 0; i < array.Length; i++)
		{
			SizeF sizeF = ((!isExact) ? g.imethod_105(array[i], font) : smethod_14(g, array[i], font));
			if (sizeF.Width > num)
			{
				num = sizeF.Width;
			}
		}
		return num;
	}

	public static float smethod_20(Interface32 g, string text, Font font, bool isExact)
	{
		Regex regex = new Regex("\\s+");
		string[] array = regex.Split(text);
		float num = 0f;
		for (int i = 0; i < array.Length; i++)
		{
			SizeF sizeF = ((!isExact) ? g.imethod_105(array[i], font) : smethod_14(g, array[i], font));
			if (sizeF.Width > num)
			{
				num = sizeF.Width;
			}
		}
		return num;
	}

	public static SizeF smethod_21(Interface32 g, string text, Font font)
	{
		Size layout = new Size(int.MaxValue, int.MaxValue);
		Size size = smethod_10(g, text, font);
		SizeF sizeF = smethod_16(g, text, font, layout);
		return new SizeF((float)size.Width - sizeF.Width, (float)size.Height - sizeF.Height);
	}

	public static int smethod_22(Interface32 g, Font textFont)
	{
		return Struct41.smethod_3(g.GraphicsTools.imethod_2(textFont));
	}
}
