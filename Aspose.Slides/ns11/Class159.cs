using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Aspose.Slides;
using ns218;
using ns224;
using ns33;
using ns4;

namespace ns11;

internal abstract class Class159 : IDisposable
{
	private PointF pointF_0;

	private Class6002 class6002_0;

	private Class169 class169_0;

	protected readonly Bitmap bitmap_0;

	protected readonly Graphics graphics_0;

	protected readonly bool bool_0;

	protected readonly StringFormat stringFormat_0;

	protected readonly Stack<Class6002> stack_0;

	private bool bool_1;

	public Class169 Context
	{
		get
		{
			return class169_0;
		}
		set
		{
			class169_0 = value;
		}
	}

	public Class6002 Transform
	{
		get
		{
			if (!(class6002_0 != null))
			{
				return null;
			}
			return class6002_0.Clone();
		}
		set
		{
			if (value == null)
			{
				value = new Class6002();
			}
			class6002_0 = value;
			TransformImpl = value;
		}
	}

	protected abstract Class6002 TransformImpl { get; set; }

	public abstract float DpiX { get; }

	public abstract float DpiY { get; }

	public abstract int Width { get; }

	public abstract int Height { get; }

	public virtual Hashtable ExtendedProperties => null;

	protected Class159(Bitmap bmp)
	{
		stack_0 = new Stack<Class6002>(3);
		pointF_0 = new PointF(0f, 0f);
		stringFormat_0 = new StringFormat(StringFormat.GenericTypographic);
		stringFormat_0.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
		if (bmp != null)
		{
			bitmap_0 = bmp;
			bool_0 = false;
		}
		else
		{
			bitmap_0 = new Bitmap(32, 32);
			bool_0 = true;
		}
		SizeF sizeF = new SizeF(bitmap_0.HorizontalResolution, bitmap_0.VerticalResolution);
		bitmap_0.SetResolution(96f, 96f);
		graphics_0 = Graphics.FromImage(bitmap_0);
		if (sizeF.Width != 0f && sizeF.Height != 0f)
		{
			bitmap_0.SetResolution(sizeF.Width, sizeF.Height);
		}
		graphics_0.CompositingQuality = CompositingQuality.AssumeLinear;
		graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
		graphics_0.TextRenderingHint = TextRenderingHint.AntiAlias;
	}

	public void method_0(Class6002 transform)
	{
		stack_0.Push(class6002_0);
		Transform = transform;
	}

	public Class6002 method_1()
	{
		return Transform = stack_0.Pop();
	}

	public virtual void vmethod_0(float dx, float dy, MatrixOrder matrixOrder)
	{
		Class6002 transform = Transform;
		transform.method_7(dx, dy, matrixOrder);
		Transform = transform;
	}

	public virtual void vmethod_1(float scaleX, float scaleY, MatrixOrder matrixOrder)
	{
		Class6002 transform = Transform;
		transform.method_5(scaleX, scaleY, matrixOrder);
		Transform = transform;
	}

	public virtual void vmethod_2(float shearX, float shearY, MatrixOrder matrixOrder)
	{
		Class6002 transform = Transform;
		transform = Class1170.smethod_2(transform, shearX, shearY, matrixOrder);
		Transform = transform;
	}

	public virtual void vmethod_3(float angle, MatrixOrder matrixOrder)
	{
		Class6002 transform = Transform;
		transform.method_11(angle, matrixOrder);
		Transform = transform;
	}

	public void method_2(float dx, float dy)
	{
		vmethod_0(dx, dy, MatrixOrder.Prepend);
	}

	public void method_3(float scaleX, float scaleY)
	{
		vmethod_1(scaleX, scaleY, MatrixOrder.Prepend);
	}

	public void method_4(float shearX, float shearY)
	{
		vmethod_2(shearX, shearY, MatrixOrder.Prepend);
	}

	public void method_5(float angle)
	{
		vmethod_3(angle, MatrixOrder.Prepend);
	}

	protected virtual void vmethod_4()
	{
		ref PointF reference = ref pointF_0;
		ref PointF reference2 = ref pointF_0;
		float x = 0f;
		reference2.Y = 0f;
		reference.X = x;
	}

	public abstract void vmethod_5(GraphicsPath graphicsPath, Class66 lineParam, Class63 fillParam);

	public abstract void vmethod_6(Image img, int x, int y);

	public virtual void vmethod_7(RectangleF rectangle, Class66 lineParam, Class63 fillParam)
	{
		using GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rectangle);
		vmethod_5(graphicsPath, lineParam, fillParam);
	}

	public virtual void vmethod_8(Rectangle rectangle, Class66 lineParam, Class63 fillParam)
	{
		using GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rectangle);
		vmethod_5(graphicsPath, lineParam, fillParam);
	}

	public virtual void vmethod_9(RectangleF rectangle, Class66 lineParam, Class63 fillParam)
	{
		using GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddEllipse(rectangle);
		vmethod_5(graphicsPath, lineParam, fillParam);
	}

	public virtual void vmethod_10(Rectangle rectangle, Class66 lineParam, Class63 fillParam)
	{
		using GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddEllipse(rectangle);
		vmethod_5(graphicsPath, lineParam, fillParam);
	}

	public virtual void vmethod_11(Class66 lineParam, params PointF[] points)
	{
		using GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLines(points);
		vmethod_5(graphicsPath, lineParam, null);
	}

	public virtual void vmethod_12(Class66 lineParam, params Point[] points)
	{
		using GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLines(points);
		vmethod_5(graphicsPath, lineParam, null);
	}

	public SizeF method_6(string text, PointF point, Class151 textParam)
	{
		if (text.Length > 2 && text[0] == '\u202d' && text[text.Length - 1] == '\u202c')
		{
			text = text.Substring(1, text.Length - 2);
		}
		Class733 @class = textParam.method_1();
		SizeF result = new SizeF(0f, 0f);
		lock (Class1164.Lock)
		{
			for (int i = 0; i < 3; i++)
			{
				try
				{
					using Class5971 class2 = new Class5971(graphics_0, stringFormat_0);
					for (int j = 0; j < text.Length; j++)
					{
						SizeF sizeF = class2.method_0(new string(text[j], 1), @class.Font);
						result.Width += (float)Math.Round(sizeF.Width * 8f) / 8f;
						if (sizeF.Height > result.Height)
						{
							result.Height = sizeF.Height;
						}
					}
				}
				catch
				{
					if (i == 2)
					{
						throw;
					}
					continue;
				}
				break;
			}
		}
		if (text.Length > 0 && ((double)Math.Abs(textParam.Spacing) > 0.005 || !float.IsNaN(textParam.ForcedWidth)))
		{
			int num = 0;
			for (int k = 0; k < text.Length; k++)
			{
				if (!Class1153.smethod_12(text[k]))
				{
					num++;
				}
			}
			if (!float.IsNaN(textParam.ForcedWidth))
			{
				result.Width = textParam.ForcedWidth * (float)num;
			}
			result.Width += (float)num * textParam.Spacing;
		}
		return result;
	}

	public abstract void vmethod_13(string text, RectangleF rect, Class151 textParam);

	public virtual void vmethod_14(IHyperlink link)
	{
	}

	public virtual void vmethod_15()
	{
	}

	public virtual void vmethod_16(IHyperlink link)
	{
	}

	public virtual void vmethod_17()
	{
	}

	public virtual void vmethod_18()
	{
	}

	public virtual void vmethod_19()
	{
	}

	public abstract void vmethod_20(IPPImage image, RectangleF rectangle, RectangleF sourceRectangle, Class65 imageParam);

	public virtual void vmethod_21(IPPImage image, RectangleF rectangle, Class65 imageParam)
	{
		vmethod_20(image, rectangle, new RectangleF(image.X, image.Y, image.Width, image.Height), imageParam);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~Class159()
	{
		Dispose(disposing: false);
	}

	protected void method_7(RectangleF rect, float baseLine, Class151 textParam, bool isItShadow)
	{
		float num = rect.Y;
		float num2 = rect.X;
		if (isItShadow)
		{
			PointF pointF = method_8();
			num2 += pointF.X * (float)textParam.FontHeight / 15f;
			num += pointF.Y * (float)textParam.FontHeight / 15f;
		}
		GraphicsPath graphicsPath = new GraphicsPath(FillMode.Winding);
		switch (textParam.TextStrikethrough)
		{
		case TextStrikethroughType.Single:
			graphicsPath.AddRectangle(new RectangleF(num2, num + baseLine * 0.7f, rect.Width, baseLine * 0.06f));
			break;
		case TextStrikethroughType.Double:
			graphicsPath.AddRectangle(new RectangleF(num2, num + baseLine * 0.65f, rect.Width, baseLine * 0.06f));
			graphicsPath.AddRectangle(new RectangleF(num2, num + baseLine * 0.75f, rect.Width, baseLine * 0.06f));
			break;
		}
		if (isItShadow)
		{
			Class66 @class = null;
			if (textParam.FontOutline != null)
			{
				@class = textParam.method_9(textParam.FontOutline);
				@class.ForeColor = textParam.ShadowColor;
			}
			Class63 fillParam = textParam.method_10(textParam.ShadowColor);
			vmethod_5(graphicsPath, @class, fillParam);
		}
		else
		{
			vmethod_5(graphicsPath, textParam.FontOutline, textParam.FontFill);
		}
	}

	internal PointF method_8()
	{
		if ((double)(Math.Abs(pointF_0.X) + Math.Abs(pointF_0.Y)) < 1E-05)
		{
			Class6002 drMatrix = TransformImpl.Clone();
			drMatrix = Class1170.smethod_1(drMatrix);
			PointF[] array = new PointF[1]
			{
				new PointF(1f, 1f)
			};
			Class1170.smethod_7(drMatrix, array);
			double num = Math.Sqrt(array[0].X * array[0].X + array[0].Y * array[0].Y);
			pointF_0 = new PointF((float)((double)array[0].X / num), (float)((double)array[0].Y / num));
		}
		return pointF_0;
	}

	protected static float smethod_0(Class733 font, Graphics graphics)
	{
		FontFamily fontFamily = font.Font.FontFamily;
		return font.Font.GetHeight(graphics) * (float)fontFamily.GetCellAscent(font.Style) / (float)fontFamily.GetLineSpacing(font.Style);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (bool_1)
		{
			return;
		}
		if (disposing)
		{
			graphics_0.Dispose();
			if (bool_0)
			{
				bitmap_0.Dispose();
			}
		}
		bool_1 = true;
	}
}
