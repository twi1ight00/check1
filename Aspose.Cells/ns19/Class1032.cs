using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Cells.Rendering;
using ns18;
using ns22;

namespace ns19;

internal class Class1032 : Class1031
{
	public Class1032(int int_4, int int_5, ImageFormat imageFormat_1, ImageOrPrintOptions imageOrPrintOptions_1, Stream stream_1, Interface6 interface6_1)
		: base(int_4, int_5, imageFormat_1, imageOrPrintOptions_1, stream_1, interface6_1)
	{
	}

	[Attribute0(true)]
	public override Bitmap imethod_3()
	{
		return null;
	}

	public override void vmethod_1(Image image_0, Rectangle rectangle_0, int int_4, int int_5, int int_6, int int_7, GraphicsUnit graphicsUnit_1)
	{
	}

	protected override void vmethod_10(Region region_0, CombineMode combineMode_0)
	{
	}

	protected override void vmethod_2(string string_0, Font font_0, Brush brush_0, float float_3, float float_4, float float_5, float float_6, StringFormat stringFormat_0)
	{
		if (brush_0 == null)
		{
			throw new ArgumentNullException("brush");
		}
		if (font_0 == null)
		{
			throw new ArgumentNullException("font");
		}
		if (stringFormat_0 != null && stringFormat_0.LineAlignment != 0)
		{
			SizeF sizeF = imethod_40(string_0, font_0, new SizeF(float_5, float_6));
			float num = float_5;
			float num2 = float_6;
			if (float.IsPositiveInfinity(float_5))
			{
				num = (num2 = 0f);
			}
			bool flag = (((stringFormat_0.FormatFlags & StringFormatFlags.DirectionVertical) != 0) ? true : false);
			_ = stringFormat_0.FormatFlags;
			if (flag)
			{
				throw new ArgumentNullException("DrawString in Vertical not supported.");
			}
			float num3 = 0f;
			float num4 = 0f;
			if (stringFormat_0.LineAlignment == StringAlignment.Center)
			{
				num4 = (num2 - sizeF.Height) / 2f;
			}
			else if (stringFormat_0.LineAlignment == StringAlignment.Far)
			{
				num4 = num2 - sizeF.Height;
			}
			if (stringFormat_0.Alignment == StringAlignment.Center)
			{
				num3 = (num - sizeF.Width) / 2f;
			}
			else if (stringFormat_0.LineAlignment == StringAlignment.Far)
			{
				num3 = num - sizeF.Width;
			}
			float_3 = ((num3 > 0f) ? (float_3 + num3) : float_3);
			float_4 = ((num4 > 0f) ? (float_4 + num4) : float_4);
		}
		if (!float.IsPositiveInfinity(float_5) && (stringFormat_0 == null || (stringFormat_0.FormatFlags & StringFormatFlags.NoClip) == 0))
		{
			method_13(string_0, font_0, brush_0, float_3, float_4);
		}
		else
		{
			method_13(string_0, font_0, brush_0, float_3, float_4);
		}
	}

	private float method_12(Font font_0)
	{
		float num = 10f;
		if (font_0.Unit == GraphicsUnit.Point)
		{
			num = font_0.Size;
		}
		else
		{
			if (font_0.Unit != GraphicsUnit.Pixel && font_0.Unit != GraphicsUnit.Display)
			{
				throw new NotSupportedException();
			}
			num = (float)Class1395.smethod_3(font_0.Size, imethod_51());
		}
		return num * (float)int_0;
	}

	protected override void vmethod_11(float float_3, float float_4, float float_5, float float_6, Image image_0)
	{
	}

	private void method_13(string string_0, Font font_0, Brush brush_0, float float_3, float float_4)
	{
		Class463 @class = new Class463();
		@class.vmethod_1(class1035_0.method_0().Clone());
		@class.Text = string_0;
		@class.method_2(new Class1396(font_0.Name, method_12(font_0), font_0.Style));
		if (brush_0 is SolidBrush)
		{
			@class.Color = Color.FromArgb(((SolidBrush)brush_0).Color.ToArgb());
		}
		else
		{
			@class.Color = Color.Black;
		}
		@class.method_5(new PointF(vmethod_13(float_3), vmethod_13(float_4 + @class.method_1().method_1())));
		class454_1.Add(@class);
	}

	internal override float vmethod_12(float float_3, float float_4)
	{
		return float_3;
	}

	internal override float vmethod_13(float float_3)
	{
		return vmethod_12(float_3, imethod_51());
	}

	public override Class454 vmethod_9()
	{
		if (interface6_0 != null)
		{
			interface6_0.imethod_2();
		}
		if (class454_0.imethod_0() == null)
		{
			class454_0.vmethod_1(new Matrix(0.75f, 0f, 0f, 0.75f, 0f, 0f));
		}
		else
		{
			class454_0.imethod_0().Scale(0.75f, 0.75f);
		}
		return class454_0;
	}

	public override void imethod_2()
	{
		float width = (float)Class1395.smethod_3(int_2, imethod_51());
		float height = (float)Class1395.smethod_3(int_3, imethod_52());
		Class457 @class = new Class457(new SizeF(width, height));
		@class.Add(class454_0);
		GraphicsUnit graphicsUnit_ = GraphicsUnit.Pixel;
		if (imageFormat_0.Equals(ImageFormat.Emf))
		{
			method_15(@class, graphicsUnit_);
		}
		else
		{
			method_14(@class, graphicsUnit_);
		}
	}

	private void method_14(Class457 class457_0, GraphicsUnit graphicsUnit_1)
	{
		Bitmap bitmap = null;
		Graphics graphics = null;
		try
		{
			bitmap = new Bitmap(int_2, int_3);
			graphics = Graphics.FromImage(bitmap);
			graphics.PageUnit = graphicsUnit_1;
			Class472 @class = new Class472();
			@class.method_2(class457_0, graphics);
			bitmap.Save(stream_0, imageFormat_0);
		}
		finally
		{
			graphics?.Dispose();
			bitmap?.Dispose();
		}
	}

	private void method_15(Class457 class457_0, GraphicsUnit graphicsUnit_1)
	{
		Bitmap bitmap = null;
		Graphics graphics = null;
		IntPtr intPtr = IntPtr.Zero;
		Metafile metafile = null;
		Graphics graphics2 = null;
		try
		{
			bitmap = new Bitmap(1, 1);
			bitmap.SetResolution(float_1, float_1);
			graphics = Graphics.FromImage(bitmap);
			intPtr = graphics.GetHdc();
			metafile = new Metafile(stream_0, intPtr, new RectangleF(0f, 0f, int_2, int_3), MetafileFrameUnit.Pixel, Class1041.emfType_0);
			graphics2 = Graphics.FromImage(metafile);
			graphics2.PageUnit = graphicsUnit_1;
			Class472 @class = new Class472();
			@class.method_2(class457_0, graphics2);
		}
		finally
		{
			metafile?.Dispose();
			graphics2?.Dispose();
			if (intPtr != IntPtr.Zero)
			{
				graphics.ReleaseHdc(intPtr);
			}
			graphics?.Dispose();
			bitmap?.Dispose();
		}
	}
}
