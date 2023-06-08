using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ns224;
using ns235;
using ns271;
using ns277;
using ns284;
using ns290;
using ns301;

namespace ns278;

internal class Class6761 : Class6759, IDisposable
{
	private readonly Size size_0;

	private readonly IList<Bitmap> ilist_0;

	private Bitmap bitmap_0;

	private bool bool_0;

	public Class6761(Size pageSize)
	{
		float num = Class6969.smethod_15(pageSize.Width);
		float num2 = Class6969.smethod_15(pageSize.Height);
		size_0 = new Size((int)num, (int)num2);
		ilist_0 = new List<Bitmap>();
	}

	public override object vmethod_4()
	{
		method_1();
		return ilist_0;
	}

	public override void vmethod_3()
	{
		method_1();
	}

	public override void vmethod_0(Class6844 box, PointF boxLocation, bool isAps, ref Hashtable pageSet)
	{
		PointF location = new PointF(boxLocation.X + box.BorderBound.X, boxLocation.Y + box.BorderBound.Y);
		RectangleF box2 = new RectangleF(location, box.BorderBound.Size);
		if (!box.Style.BackgroundColor.IsEmpty)
		{
			using Graphics graphics = Graphics.FromImage(bitmap_0);
			using (new SolidBrush(box.Style.BackgroundColor))
			{
				graphics.PageUnit = GraphicsUnit.Point;
				smethod_6(ref pageSet, box2.X, box2.Y, box2.X + box2.Width, box2.Y + box2.Height, 0f, Color.Empty, box.Style.BackgroundColor);
			}
		}
		if (box.Style.BorderWidthLeft.Value > 0f && box.Style.BorderStyleLeft != 0)
		{
			Color color = Class6759.smethod_2(box.Style.BorderColorLeft, box.Style, Enum934.const_0, string.Empty);
			float num = Class6969.smethod_10(box.Style.BorderWidthLeft) / 2f;
			float x = num;
			float y = 0f;
			float height = box.BorderBound.Height;
			float width = Class6969.smethod_10(box.Style.BorderWidthLeft);
			method_0(num, y, x, height, width, color, box2, ref pageSet);
		}
		if (box.Style.BorderWidthTop.Value > 0f && box.Style.BorderStyleTop != 0)
		{
			Color color2 = Class6759.smethod_2(box.Style.BorderColorTop, box.Style, Enum934.const_1, string.Empty);
			float x2 = 0f;
			float width2 = box.BorderBound.Width;
			float num2 = box.BorderBound.Height - Class6969.smethod_10(box.Style.BorderWidthTop) / 2f;
			float y2 = num2;
			float width3 = Class6969.smethod_10(box.Style.BorderWidthTop);
			method_0(x2, num2, width2, y2, width3, color2, box2, ref pageSet);
		}
		if (box.Style.BorderWidthRight.Value > 0f && box.Style.BorderStyleRight != 0)
		{
			Color color3 = Class6759.smethod_2(box.Style.BorderColorRight, box.Style, Enum934.const_2, string.Empty);
			float num3 = box.BorderBound.Width - Class6969.smethod_10(box.Style.BorderWidthRight) / 2f;
			float x3 = num3;
			float y3 = 0f;
			float height2 = box.BorderBound.Height;
			float width4 = Class6969.smethod_10(box.Style.BorderWidthRight);
			method_0(num3, y3, x3, height2, width4, color3, box2, ref pageSet);
		}
		if (box.Style.BorderWidthBottom.Value > 0f && box.Style.BorderStyleBottom != 0)
		{
			Color color4 = Class6759.smethod_2(box.Style.BorderColorBottom, box.Style, Enum934.const_3, string.Empty);
			float x4 = 0f;
			float width5 = box.BorderBound.Width;
			float num4 = Class6969.smethod_10(box.Style.BorderWidthBottom) / 2f;
			float y4 = num4;
			float width6 = Class6969.smethod_10(box.Style.BorderWidthBottom);
			method_0(x4, num4, width5, y4, width6, color4, box2, ref pageSet);
		}
		if (box.Style.BorderTableWidthLeft != null && box.Style.BorderTableWidthLeft.Value > 0f && box.Style.BorderTableStyleLeft != 0)
		{
			Color color5 = Class6759.smethod_2(box.Style.BorderTableColorLeft, box.Style, Enum934.const_0, "table");
			float num5 = Class6969.smethod_10(box.Style.BorderTableWidthLeft) / 2f;
			float x5 = num5;
			float y5 = 0f;
			float height3 = box.BorderBound.Height;
			float width7 = Class6969.smethod_10(box.Style.BorderTableWidthLeft);
			method_0(num5, y5, x5, height3, width7, color5, box2, ref pageSet);
		}
		if (box.Style.BorderTableWidthTop != null && box.Style.BorderTableWidthTop.Value > 0f && box.Style.BorderTableStyleTop != 0)
		{
			Color color6 = Class6759.smethod_2(box.Style.BorderTableColorTop, box.Style, Enum934.const_1, "table");
			float x6 = 0f;
			float width8 = box.BorderBound.Width;
			float num6 = box.BorderBound.Height - Class6969.smethod_10(box.Style.BorderTableWidthTop) / 2f;
			float y6 = num6;
			float width9 = Class6969.smethod_10(box.Style.BorderTableWidthTop);
			method_0(x6, num6, width8, y6, width9, color6, box2, ref pageSet);
		}
		if (box.Style.BorderTableWidthRight != null && box.Style.BorderTableWidthRight.Value > 0f && box.Style.BorderTableStyleRight != 0)
		{
			Color color7 = Class6759.smethod_2(box.Style.BorderTableColorRight, box.Style, Enum934.const_2, "table");
			float num7 = box.BorderBound.Width - Class6969.smethod_10(box.Style.BorderTableWidthRight) / 2f;
			float x7 = num7;
			float y7 = 0f;
			float height4 = box.BorderBound.Height;
			float width10 = Class6969.smethod_10(box.Style.BorderTableWidthRight);
			method_0(num7, y7, x7, height4, width10, color7, box2, ref pageSet);
		}
		if (box.Style.BorderTableWidthBottom != null && box.Style.BorderTableWidthBottom.Value > 0f && box.Style.BorderTableStyleBottom != 0)
		{
			Color color8 = Class6759.smethod_2(box.Style.BorderTableColorBottom, box.Style, Enum934.const_3, "table");
			float x8 = 0f;
			float width11 = box.BorderBound.Width;
			float num8 = Class6969.smethod_10(box.Style.BorderTableWidthBottom) / 2f;
			float y8 = num8;
			float width12 = Class6969.smethod_10(box.Style.BorderTableWidthBottom);
			method_0(x8, num8, width11, y8, width12, color8, box2, ref pageSet);
		}
	}

	public override void vmethod_2(string imageFileName, float x, float y, float width, float height, bool isAps, ref Hashtable pageSet)
	{
		if (pageSet[pageSet.Count - 1] is Class6216 @class && @class[@class.Count - 1] is Class6213 class2 && File.Exists(imageFileName))
		{
			byte[] imageBytes = File.ReadAllBytes(imageFileName);
			class2.Add(new Class6220(new PointF(x, y), new SizeF(width, height), imageBytes));
		}
	}

	public override void vmethod_1(Class6855 box, PointF textPos, Interface356 link, bool isAps, ref Hashtable pageSet)
	{
		string wordDecoded = box.WordDecoded;
		float x = textPos.X;
		float y = textPos.Y;
		Color color = ((Color.Empty == box.Style.Color) ? Color.Black : box.Style.Color);
		using Graphics graphics = Graphics.FromImage(bitmap_0);
		using (new SolidBrush(color))
		{
			graphics.PageUnit = GraphicsUnit.Point;
			Font font = new Font(box.Style.FontFamilyName, box.Style.FontSize, box.Style.FontStyle);
			smethod_7(ref pageSet, x, y, color, font, wordDecoded);
		}
	}

	private void method_0(float x1, float y1, float x2, float y2, float width, Color color, RectangleF box1, ref Hashtable pageSet)
	{
		x1 += box1.X;
		x2 += box1.X;
		y1 += box1.Y;
		y2 += box1.Y;
		using Graphics graphics = Graphics.FromImage(bitmap_0);
		using (new Pen(color, width))
		{
			graphics.PageUnit = GraphicsUnit.Point;
			smethod_5(ref pageSet, x1, y1, x2, y2, width, color);
		}
	}

	private void method_1()
	{
		if (bitmap_0 != null)
		{
			ilist_0.Add(bitmap_0);
		}
		bitmap_0 = new Bitmap(size_0.Width, size_0.Height);
		using Graphics graphics = Graphics.FromImage(bitmap_0);
		using (new SolidBrush(Color.White))
		{
			graphics.PageUnit = GraphicsUnit.Point;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected void Dispose(bool disposing)
	{
		if (!bool_0)
		{
			if (disposing)
			{
				bitmap_0.Dispose();
			}
			bool_0 = true;
		}
	}

	private static void smethod_5(ref Hashtable pageSet, float x1, float y1, float x2, float y2, float width, Color color)
	{
		if (pageSet[pageSet.Count - 1] is Class6216 @class && @class[@class.Count - 1] is Class6213 class2)
		{
			Class6003 pen = new Class6003(Class5998.smethod_2(color.A, color.R, color.G, color.B), width);
			Class6217 class3 = new Class6217(pen);
			Class6218 class4 = new Class6218();
			float num = x2 - x1;
			float num2 = y2 - y1;
			class4.method_2(new PointF(x1, y1), new PointF(x1 + num, y1 + num2));
			class3.Add(class4);
			class2.Add(class3);
		}
	}

	private static void smethod_6(ref Hashtable pageSet, float x1, float y1, float x2, float y2, float width, Color color, Color fillColor)
	{
		if (pageSet[pageSet.Count - 1] is Class6216 @class && @class[@class.Count - 1] is Class6213 class2)
		{
			Class6003 pen = new Class6003(Class5998.class5998_141, width);
			if (!color.IsEmpty)
			{
				pen = new Class6003(Class5998.smethod_2(color.A, color.R, color.G, color.B), width);
			}
			Class6217 class3 = new Class6217(pen);
			Class6218 class4 = new Class6218();
			class4.method_2(new PointF(x1, y1), new PointF(x2, y1));
			class4.method_2(new PointF(x2, y1), new PointF(x2, y2));
			class4.method_2(new PointF(x2, y2), new PointF(x1, y2));
			class4.method_2(new PointF(x1, y2), new PointF(x1, y1));
			class4.IsClosed = true;
			if (!fillColor.IsEmpty)
			{
				class3.Brush = new Class5997(Class5998.smethod_2(fillColor.A, fillColor.R, fillColor.G, fillColor.B));
			}
			class3.Add(class4);
			class2.Add(class3);
		}
	}

	private static void smethod_7(ref Hashtable pageSet, float x, float y, Color color, Font font, string word)
	{
		if (pageSet[pageSet.Count - 1] is Class6216 @class && @class[@class.Count - 1] is Class6213 class2)
		{
			FontStyle fontStyle = FontStyle.Regular;
			if (font.Italic)
			{
				fontStyle |= FontStyle.Italic;
			}
			if (font.Bold)
			{
				fontStyle |= FontStyle.Bold;
			}
			if (font.Strikeout)
			{
				fontStyle |= FontStyle.Strikeout;
			}
			if (font.Underline)
			{
				fontStyle |= FontStyle.Underline;
			}
			Class5999 font2 = Class6652.Instance.method_1(font.FontFamily.Name, font.Size, fontStyle);
			Class5998 color2 = Class5998.smethod_2(color.A, color.R, color.G, color.B);
			float y2 = y + font.Size;
			Class6219 node = new Class6219(font2, color2, Class5998.class5998_141, new PointF(x, y2), word, new SizeF((float)word.Length * font.Size, font.Size), 0f);
			class2.Add(node);
		}
	}
}
