using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns11;
using ns4;
using ns5;

namespace Aspose.Slides.Effects;

public class ReflectionEffectiveData : EffectEffectiveData, IReflectionEffectiveData
{
	private readonly RectangleAlignment rectangleAlignment_0;

	private readonly double double_0;

	private readonly float float_0;

	private readonly double double_1;

	private readonly float float_1;

	private readonly float float_2;

	private readonly float float_3;

	private readonly float float_4;

	private readonly float float_5;

	private readonly double double_2;

	private readonly double double_3;

	private readonly bool bool_0;

	private readonly double double_4;

	private readonly double double_5;

	public float StartPosAlpha => float_1;

	public float EndPosAlpha => float_2;

	public float FadeDirection => float_3;

	public float StartReflectionOpacity => float_4;

	public float EndReflectionOpacity => float_5;

	public double BlurRadius => double_0;

	public float Direction => float_0;

	public double Distance => double_1;

	public RectangleAlignment RectangleAlign => rectangleAlignment_0;

	public double SkewHorizontal => double_2;

	public double SkewVertical => double_3;

	public bool RotateShadowWithShape => bool_0;

	public double ScaleHorizontal => double_4;

	public double ScaleVertical => double_5;

	internal ReflectionEffectiveData(RectangleAlignment algn, double blurRad, float dir, double dist, float stPos, float endPos, float fadeDir, float stA, float endA, double kx, double ky, bool rotWithShape, double sx, double sy)
	{
		rectangleAlignment_0 = algn;
		double_0 = blurRad;
		float_0 = dir;
		double_1 = dist;
		float_1 = stPos;
		float_2 = endPos;
		float_3 = fadeDir;
		float_4 = stA;
		float_5 = endA;
		double_2 = kx;
		double_3 = ky;
		bool_0 = rotWithShape;
		double_4 = sx;
		double_5 = sy;
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		throw new InvalidOperationException();
	}

	internal void method_0(Class159 canvas, GraphicsPath graphicsPath, Class63 fp, Class66 lp, RectangleF rect)
	{
		int num = 0;
		if (lp != null)
		{
			num = (int)lp.Width;
		}
		Matrix matrix = new Matrix();
		matrix.Scale((float)(ScaleHorizontal / 100.0), (float)(ScaleVertical / 100.0));
		Bitmap bitmap = new Bitmap((int)rect.Width + num, (int)rect.Height + num);
		Graphics graphics = Graphics.FromImage(bitmap);
		Matrix matrix2 = new Matrix();
		matrix2.Translate(0f - rect.X, 0f - rect.Y - rect.Height);
		graphicsPath.Transform(matrix2);
		graphicsPath.Transform(matrix);
		if (fp != null)
		{
			Brush brush = fp.method_9();
			Matrix matrix3 = new Matrix();
			if (brush is TextureBrush)
			{
				matrix3 = ((TextureBrush)brush).Transform;
			}
			if (brush is LinearGradientBrush)
			{
				matrix3 = ((LinearGradientBrush)brush).Transform;
			}
			if (brush is PathGradientBrush)
			{
				matrix3 = ((PathGradientBrush)brush).Transform;
			}
			Matrix matrix4 = new Matrix(matrix3.Elements[0], matrix3.Elements[1], matrix3.Elements[2], matrix3.Elements[3], 0f, rect.Height);
			matrix4.Multiply(matrix);
			if (brush is TextureBrush)
			{
				((TextureBrush)brush).Transform = matrix4;
			}
			if (brush is LinearGradientBrush)
			{
				((LinearGradientBrush)brush).Transform = matrix4;
			}
			if (brush is PathGradientBrush)
			{
				((PathGradientBrush)brush).Transform = matrix4;
			}
			graphics.FillPath(brush, graphicsPath);
		}
		if (lp != null)
		{
			Pen pen = lp.method_5();
			Matrix transform = pen.Transform;
			Matrix matrix5 = new Matrix(transform.Elements[0], transform.Elements[1], transform.Elements[2], transform.Elements[3], 0f, rect.Height);
			matrix5.Multiply(matrix);
			pen.Transform = matrix5;
			graphics.DrawPath(pen, graphicsPath);
		}
		if (fp != null || lp != null)
		{
			bitmap = method_1(bitmap, this);
			canvas.vmethod_6(bitmap, (int)rect.X, (int)((double)rect.Bottom + Distance));
		}
	}

	private Bitmap method_1(Bitmap bmp, ReflectionEffectiveData reflection)
	{
		float startReflectionOpacity = reflection.StartReflectionOpacity;
		float endReflectionOpacity = reflection.EndReflectionOpacity;
		float startPosAlpha = reflection.StartPosAlpha;
		float endPosAlpha = reflection.EndPosAlpha;
		int num = 0;
		float num2 = 0f;
		for (int i = 0; i < bmp.Width; i++)
		{
			for (int j = 0; j < bmp.Height; j++)
			{
				num2 = (float)j / (float)bmp.Height * 100f;
				Color pixel = bmp.GetPixel(i, j);
				if (num2 >= startPosAlpha && num2 <= endPosAlpha)
				{
					num = (int)(startReflectionOpacity + (endReflectionOpacity - startReflectionOpacity) * (num2 - startPosAlpha) / (endPosAlpha - startPosAlpha));
					if (pixel.A > 0)
					{
						bmp.SetPixel(i, j, Color.FromArgb((int)((float)num * 255f / 100f), pixel));
					}
				}
				else if (num2 > endPosAlpha && pixel.A > 0)
				{
					bmp.SetPixel(i, j, Color.FromArgb(0, pixel));
				}
			}
		}
		return bmp;
	}
}
