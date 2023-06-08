using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using ns277;
using ns284;
using ns290;
using ns301;

namespace ns279;

internal class Class6762 : Class6759, IDisposable
{
	private readonly Size size_0;

	private readonly Size size_1;

	private readonly List<Bitmap> list_0;

	private Bitmap bitmap_0;

	private bool bool_0;

	public Class6762(Size pageSize)
	{
		size_1 = pageSize;
		float num = Class6969.smethod_15(pageSize.Width);
		float num2 = Class6969.smethod_15(pageSize.Height);
		size_0 = new Size((int)num, (int)num2);
		list_0 = new List<Bitmap>();
	}

	public override object vmethod_4()
	{
		method_1();
		return list_0;
	}

	public override void vmethod_3()
	{
		method_1();
	}

	public override void vmethod_0(Class6844 box, PointF boxLocation, bool isAps, ref Hashtable pageSet)
	{
		PointF location = new PointF(boxLocation.X + box.BorderBound.X, boxLocation.Y + box.BorderBound.Y);
		RectangleF rectangleF = new RectangleF(location, box.BorderBound.Size);
		if (!box.Style.BackgroundColor.IsEmpty)
		{
			using Graphics graphics = Graphics.FromImage(bitmap_0);
			using Brush brush = new SolidBrush(box.Style.BackgroundColor);
			graphics.PageUnit = GraphicsUnit.Point;
			if (!isAps)
			{
				graphics.FillRectangle(brush, rectangleF);
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
			method_0(num, y, x, height, width, color, rectangleF);
		}
		if (box.Style.BorderWidthTop.Value > 0f && box.Style.BorderStyleTop != 0)
		{
			Color color2 = Class6759.smethod_2(box.Style.BorderColorTop, box.Style, Enum934.const_1, string.Empty);
			float x2 = 0f;
			float width2 = box.BorderBound.Width;
			float num2 = box.BorderBound.Height - Class6969.smethod_10(box.Style.BorderWidthTop) / 2f;
			float y2 = num2;
			float width3 = Class6969.smethod_10(box.Style.BorderWidthTop);
			method_0(x2, num2, width2, y2, width3, color2, rectangleF);
		}
		if (box.Style.BorderWidthRight.Value > 0f && box.Style.BorderStyleRight != 0)
		{
			Color color3 = Class6759.smethod_2(box.Style.BorderColorRight, box.Style, Enum934.const_2, string.Empty);
			float num3 = box.BorderBound.Width - Class6969.smethod_10(box.Style.BorderWidthRight) / 2f;
			float x3 = num3;
			float y3 = 0f;
			float height2 = box.BorderBound.Height;
			float width4 = Class6969.smethod_10(box.Style.BorderWidthRight);
			method_0(num3, y3, x3, height2, width4, color3, rectangleF);
		}
		if (box.Style.BorderWidthBottom.Value > 0f && box.Style.BorderStyleBottom != 0)
		{
			Color color4 = Class6759.smethod_2(box.Style.BorderColorBottom, box.Style, Enum934.const_3, string.Empty);
			float x4 = 0f;
			float width5 = box.BorderBound.Width;
			float num4 = Class6969.smethod_10(box.Style.BorderWidthBottom) / 2f;
			float y4 = num4;
			float width6 = Class6969.smethod_10(box.Style.BorderWidthBottom);
			method_0(x4, num4, width5, y4, width6, color4, rectangleF);
		}
		if (box.Style.BorderTableWidthLeft != null && box.Style.BorderTableWidthLeft.Value > 0f && box.Style.BorderTableStyleLeft != 0)
		{
			Color color5 = Class6759.smethod_2(box.Style.BorderTableColorLeft, box.Style, Enum934.const_0, "table");
			float num5 = Class6969.smethod_10(box.Style.BorderTableWidthLeft) / 2f;
			float x5 = num5;
			float y5 = 0f;
			float height3 = box.BorderBound.Height;
			float width7 = Class6969.smethod_10(box.Style.BorderTableWidthLeft);
			method_0(num5, y5, x5, height3, width7, color5, rectangleF);
		}
		if (box.Style.BorderTableWidthTop != null && box.Style.BorderTableWidthTop.Value > 0f && box.Style.BorderTableStyleTop != 0)
		{
			Color color6 = Class6759.smethod_2(box.Style.BorderTableColorTop, box.Style, Enum934.const_1, "table");
			float x6 = 0f;
			float width8 = box.BorderBound.Width;
			float num6 = box.BorderBound.Height - Class6969.smethod_10(box.Style.BorderTableWidthTop) / 2f;
			float y6 = num6;
			float width9 = Class6969.smethod_10(box.Style.BorderTableWidthTop);
			method_0(x6, num6, width8, y6, width9, color6, rectangleF);
		}
		if (box.Style.BorderTableWidthRight != null && box.Style.BorderTableWidthRight.Value > 0f && box.Style.BorderTableStyleRight != 0)
		{
			Color color7 = Class6759.smethod_2(box.Style.BorderTableColorRight, box.Style, Enum934.const_2, "table");
			float num7 = box.BorderBound.Width - Class6969.smethod_10(box.Style.BorderTableWidthRight) / 2f;
			float x7 = num7;
			float y7 = 0f;
			float height4 = box.BorderBound.Height;
			float width10 = Class6969.smethod_10(box.Style.BorderTableWidthRight);
			method_0(num7, y7, x7, height4, width10, color7, rectangleF);
		}
		if (box.Style.BorderTableWidthBottom != null && box.Style.BorderTableWidthBottom.Value > 0f && box.Style.BorderTableStyleBottom != 0)
		{
			Color color8 = Class6759.smethod_2(box.Style.BorderTableColorBottom, box.Style, Enum934.const_3, "table");
			float x8 = 0f;
			float width11 = box.BorderBound.Width;
			float num8 = Class6969.smethod_10(box.Style.BorderTableWidthBottom) / 2f;
			float y8 = num8;
			float width12 = Class6969.smethod_10(box.Style.BorderTableWidthBottom);
			method_0(x8, num8, width11, y8, width12, color8, rectangleF);
		}
	}

	public override void vmethod_2(string imageFileName, float x, float y, float width, float height, bool isAps, ref Hashtable pageSet)
	{
	}

	public override void vmethod_1(Class6855 box, PointF textPos, Interface356 link, bool isAps, ref Hashtable pageSet)
	{
		string wordDecoded = box.WordDecoded;
		float x = textPos.X;
		float y = textPos.Y;
		Color color = ((Color.Empty == box.Style.Color) ? Color.Black : box.Style.Color);
		using Graphics graphics = Graphics.FromImage(bitmap_0);
		using Brush brush = new SolidBrush(color);
		graphics.PageUnit = GraphicsUnit.Point;
		Font font = new Font(box.Style.FontFamilyName, box.Style.FontSize, box.Style.FontStyle);
		graphics.DrawString(wordDecoded, font, brush, x, y);
	}

	private void method_0(float x1, float y1, float x2, float y2, float width, Color color, RectangleF box1)
	{
		x1 += box1.X;
		x2 += box1.X;
		y1 += box1.Y;
		y2 += box1.Y;
		using Graphics graphics = Graphics.FromImage(bitmap_0);
		using Pen pen = new Pen(color, width);
		graphics.PageUnit = GraphicsUnit.Point;
		graphics.DrawLine(pen, x1, y1, x2, y2);
	}

	private void method_1()
	{
		if (bitmap_0 != null)
		{
			list_0.Add(bitmap_0);
		}
		bitmap_0 = new Bitmap(size_0.Width, size_0.Height);
		using Graphics graphics = Graphics.FromImage(bitmap_0);
		using Brush brush = new SolidBrush(Color.White);
		graphics.PageUnit = GraphicsUnit.Point;
		graphics.FillRectangle(brush, 0, 0, size_1.Width, size_1.Height);
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
}
