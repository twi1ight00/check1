using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ns224;
using ns233;
using ns99;

namespace ns239;

internal class Class6563 : Class6562
{
	private string string_0 = string.Empty;

	private Class6565 class6565_0;

	private Image image_0 = new Bitmap(1, 1);

	private Brush brush_0 = new SolidBrush(Color.White);

	private Pen pen_0 = new Pen(Color.Black, 2f);

	public Image Image => image_0;

	public Brush Brush => brush_0;

	public Pen Pen
	{
		get
		{
			return pen_0;
		}
		set
		{
			pen_0 = value;
		}
	}

	public SizeF Size => image_0.Size;

	public string Hyperlink
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class6565 Bookmark
	{
		get
		{
			return class6565_0;
		}
		set
		{
			value = class6565_0;
		}
	}

	public Class6563(Class6562 builder)
		: base(builder)
	{
	}

	public byte[] ToArray()
	{
		return Class6632.smethod_5(image_0);
	}

	private void method_0(SizeF size)
	{
		if (size.Width > (float)image_0.Width || size.Height > (float)image_0.Height)
		{
			Bitmap bitmap = new Bitmap(Convert.ToInt32((size.Width > (float)image_0.Width) ? size.Width : ((float)image_0.Width)) + 5, Convert.ToInt32((size.Height > (float)image_0.Height) ? size.Height : ((float)image_0.Height)) + 5);
			Graphics graphics = Graphics.FromImage(bitmap);
			try
			{
				graphics.FillRectangle(brush_0, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
				graphics.DrawImage(image_0, 0, 0);
			}
			finally
			{
				graphics.Dispose();
			}
			image_0 = bitmap;
		}
	}

	public override void vmethod_3(List<PointF> coords)
	{
		SizeF size = Class6632.smethod_4(coords);
		method_0(size);
		Graphics graphics = Graphics.FromImage(image_0);
		try
		{
			PointF[] array = new PointF[coords.Count];
			for (int i = 0; i <= coords.Count - 1; i++)
			{
				ref PointF reference = ref array[i];
				reference = coords[i];
			}
			graphics.DrawLines(pen_0, array);
		}
		finally
		{
			graphics.Dispose();
		}
	}

	public override void vmethod_1(PointF startPoint, PointF controlPoint1, PointF controlPoint2, PointF EndPoint)
	{
		SizeF size = Class6632.smethod_3(startPoint, controlPoint1, controlPoint2, EndPoint);
		method_0(size);
		Graphics graphics = Graphics.FromImage(image_0);
		try
		{
			graphics.DrawBezier(pen_0, startPoint, controlPoint1, controlPoint2, EndPoint);
		}
		finally
		{
			graphics.Dispose();
		}
	}

	public override void vmethod_0(Class5999 font, Class5998 color, Class5998 outlineColor, PointF origin, string text, SizeF size, float charSpace, string hyperlink)
	{
		method_0(new Size(Convert.ToInt32(size.Width + origin.X), Convert.ToInt32(size.Height + origin.Y)));
		Graphics graphics = Graphics.FromImage(image_0);
		try
		{
			Brush brush = new SolidBrush(color.method_0());
			graphics.DrawString(text, Class6009.smethod_0(font.FamilyName, font.SizePoints, font.Style), brush, origin);
		}
		finally
		{
			graphics.Dispose();
		}
	}

	public override void vmethod_2(PointF origin, string name)
	{
		class6565_0 = new Class6565();
		class6565_0.string_0 = name;
		class6565_0.pointF_0 = origin;
	}

	public override void AddImage(SizeF size, PointF origin, byte[] byteArray, Class6145 crop, string hyperlink)
	{
		Graphics graphics = Graphics.FromImage(image_0);
		try
		{
			MemoryStream stream = new MemoryStream(byteArray);
			Image image = Image.FromStream(stream);
			graphics.DrawImage(image, origin.X, origin.Y, image.Width, image.Height);
		}
		finally
		{
			graphics.Dispose();
		}
	}

	public override void vmethod_8(Class6563 canvas)
	{
		method_0(canvas.Size);
		AddImage(canvas.Size, new PointF(0f, 0f), canvas.ToArray(), null, null);
	}
}
