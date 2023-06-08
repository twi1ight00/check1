using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using ns11;
using ns4;
using ns5;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Guid("2877771A-457A-4F28-B4AA-C66198D19851")]
public class Reflection : IReflection, IEffect
{
	private RectangleAlignment rectangleAlignment_0 = RectangleAlignment.NotDefined;

	private double double_0;

	private float float_0;

	private double double_1;

	private float float_1;

	private float float_2 = 100f;

	private float float_3 = 90f;

	private float float_4 = 100f;

	private float float_5;

	private double double_2;

	private double double_3;

	private bool bool_0 = true;

	private double double_4 = 100.0;

	private double double_5 = 100.0;

	private IPresentationComponent ipresentationComponent_0;

	private uint uint_0;

	public float StartPosAlpha
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
			method_3();
		}
	}

	public float EndPosAlpha
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
			method_3();
		}
	}

	public float FadeDirection
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
			method_3();
		}
	}

	public float StartReflectionOpacity
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
			method_3();
		}
	}

	public float EndReflectionOpacity
	{
		get
		{
			return float_5;
		}
		set
		{
			float_5 = value;
			method_3();
		}
	}

	public double BlurRadius
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			method_3();
		}
	}

	public float Direction
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			method_3();
		}
	}

	public double Distance
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
			method_3();
		}
	}

	public RectangleAlignment RectangleAlign
	{
		get
		{
			return rectangleAlignment_0;
		}
		set
		{
			rectangleAlignment_0 = value;
			method_3();
		}
	}

	public double SkewHorizontal
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
			method_3();
		}
	}

	public double SkewVertical
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
			method_3();
		}
	}

	public bool RotateShadowWithShape
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			method_3();
		}
	}

	public double ScaleHorizontal
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
			method_3();
		}
	}

	public double ScaleVertical
	{
		get
		{
			return double_5;
		}
		set
		{
			double_5 = value;
			method_3();
		}
	}

	internal IPresentationComponent Parent => ipresentationComponent_0;

	internal uint Version => uint_0;

	internal Reflection(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
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

	private Bitmap method_1(Bitmap bmp, Reflection reflection)
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

	internal Reflection Clone()
	{
		return (Reflection)MemberwiseClone();
	}

	internal void method_2(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		method_3();
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new ReflectionEffectiveData(rectangleAlignment_0, double_0, float_0, double_1, float_1, float_2, float_3, float_4, float_5, double_2, double_3, bool_0, double_4, double_5);
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class43(rectangleAlignment_0, double_0, float_0, double_1, float_1, float_2, float_3, float_4, float_5, double_2, double_3, bool_0, double_4, double_5);
	}

	private void method_3()
	{
		uint_0++;
	}
}
