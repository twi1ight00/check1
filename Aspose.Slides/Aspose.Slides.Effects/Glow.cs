using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ns11;
using ns4;
using ns5;

namespace Aspose.Slides.Effects;

[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
[Guid("c46642e0-49c6-4590-9e83-2d2ffa9407f0")]
public class Glow : IGlow, IEffect
{
	private double double_0;

	private ColorFormat colorFormat_0;

	private IPresentationComponent ipresentationComponent_0;

	private uint uint_0;

	public double Radius
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			method_7();
		}
	}

	public IColorFormat Color => colorFormat_0;

	internal IPresentationComponent Parent => ipresentationComponent_0;

	internal uint Version => uint_0 + colorFormat_0.Version;

	internal Glow(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		colorFormat_0 = new ColorFormat(parent as ISlideComponent, SchemeColor.Accent1);
	}

	private float method_0(float s, float x)
	{
		return (float)((double)s * Math.Exp((double)((0f - x) * x) / (2.0 * double_0)));
	}

	private float[] method_1()
	{
		float s = (float)(1.0 / Math.Sqrt(Math.PI * 2.0 * double_0));
		float[] array = new float[(int)(2.0 * double_0 + 1.0)];
		for (int i = 0; (double)i < 2.0 * double_0 + 1.0; i++)
		{
			array[i] = method_0(s, (float)((double)i - double_0));
		}
		return array;
	}

	private byte method_2(float[] convM, byte[] m, int i, int h, int w)
	{
		int num = convM.Length / 2;
		float num2 = 0f;
		for (int j = 0; j < convM.Length; j++)
		{
			int num3 = (j - num) * w;
			int num4 = i + num3;
			num2 += convM[j] * ((num4 < 0 || num4 > m.Length - 1) ? 0f : ((float)(int)m[num4]));
		}
		if (num2 > 255f)
		{
			num2 = 255f;
		}
		return (byte)num2;
	}

	private byte method_3(float[] convM, byte[] m, int i, int w)
	{
		int num = convM.Length / 2;
		float num2 = 0f;
		for (int j = 0; j < convM.Length; j++)
		{
			int num3 = (j - num) * 4;
			int num4 = i + num3;
			int num5 = num4 % w;
			num2 += convM[j] * ((Math.Abs(num3) > w - num5 || Math.Abs(num3) > num5) ? 0f : ((float)(int)m[num4]));
		}
		return (byte)num2;
	}

	private Bitmap method_4(float[] convM, Bitmap bmp)
	{
		Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
		BitmapData bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
		IntPtr scan = bitmapData.Scan0;
		int num = bmp.Width * bmp.Height * 4;
		byte[] array = new byte[num];
		byte[] array2 = new byte[num];
		Marshal.Copy(scan, array, 0, num);
		for (int i = 0; i < bmp.Height; i++)
		{
			for (int j = 0; j < bmp.Width; j++)
			{
				array2[j * 4 + i * bmp.Width * 4] = method_3(convM, array, j * 4 + i * bmp.Width * 4, bmp.Width * 4);
				array2[j * 4 + i * bmp.Width * 4 + 1] = method_3(convM, array, j * 4 + i * bmp.Width * 4 + 1, bmp.Width * 4);
				array2[j * 4 + i * bmp.Width * 4 + 2] = method_3(convM, array, j * 4 + i * bmp.Width * 4 + 2, bmp.Width * 4);
				array2[j * 4 + i * bmp.Width * 4 + 3] = method_3(convM, array, j * 4 + i * bmp.Width * 4 + 3, bmp.Width * 4);
			}
		}
		array = array2;
		array2 = new byte[num];
		for (int k = 0; k < bmp.Height; k++)
		{
			for (int l = 0; l < bmp.Width; l++)
			{
				array2[l * 4 + k * bmp.Width * 4] = method_2(convM, array, l * 4 + k * bmp.Width * 4, bmp.Height, bmp.Width * 4);
				array2[l * 4 + k * bmp.Width * 4 + 1] = method_2(convM, array, l * 4 + k * bmp.Width * 4 + 1, bmp.Height, bmp.Width * 4);
				array2[l * 4 + k * bmp.Width * 4 + 2] = method_2(convM, array, l * 4 + k * bmp.Width * 4 + 2, bmp.Height, bmp.Width * 4);
				array2[l * 4 + k * bmp.Width * 4 + 3] = method_2(convM, array, l * 4 + k * bmp.Width * 4 + 3, bmp.Height, bmp.Width * 4);
			}
		}
		Marshal.Copy(array2, 0, scan, num);
		bmp.UnlockBits(bitmapData);
		return bmp;
	}

	internal void method_5(Class159 canvas, BaseSlide slide, GraphicsPath graphicsPath, Class63 fp, Class66 lp, RectangleF rect)
	{
		if (lp == null)
		{
			return;
		}
		int num = 0;
		Bitmap bitmap = new Bitmap((int)((double)(rect.Width + 0f) + 4.0 * Radius), (int)((double)(rect.Height + 0f) + 4.0 * Radius));
		Graphics graphics = Graphics.FromImage(bitmap);
		Matrix matrix = new Matrix();
		matrix.Translate((float)(0.0 - ((double)(rect.X - 0f) - 2.0 * Radius)), (float)(0.0 - ((double)(rect.Y - 0f) - 2.0 * Radius)));
		graphicsPath.Transform(matrix);
		Pen pen = lp.method_5();
		Color color;
		if (colorFormat_0.ColorType == ColorType.Scheme && slide != null)
		{
			ColorFormat colorFormat = slide.method_2(colorFormat_0.SchemeColor);
			color = colorFormat.Color;
		}
		else
		{
			color = colorFormat_0.Color;
		}
		pen.Color = color;
		float width = pen.Width;
		pen.Width += (float)double_0;
		float num2 = width / pen.Width;
		float[] dashPattern = pen.DashPattern;
		if (dashPattern.Length > 0)
		{
			for (int i = 0; i < dashPattern.Length; i++)
			{
				dashPattern[i] = (dashPattern[i] + 0.5f) * num2;
			}
			pen.DashOffset *= num2;
			pen.DashPattern = dashPattern;
		}
		graphics.DrawPath(pen, graphicsPath);
		bitmap = method_4(method_1(), bitmap);
		canvas.vmethod_6(bitmap, (int)((double)(rect.X - (float)num) - 2.0 * Radius), (int)((double)(rect.Y - (float)num) - 2.0 * Radius));
	}

	internal Glow Clone()
	{
		Glow glow = (Glow)MemberwiseClone();
		glow.colorFormat_0 = new ColorFormat(null);
		glow.colorFormat_0.method_0(colorFormat_0);
		return glow;
	}

	internal void method_6(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		colorFormat_0.Parent = parent as ISlideComponent;
		method_7();
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new GlowEffectiveData(double_0, colorFormat_0.method_5(slide, styleColor));
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class36(double_0, colorFormat_0.method_5);
	}

	private void method_7()
	{
		uint_0++;
	}
}
