using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Effects;
using ns11;
using ns4;

namespace ns5;

internal class Class41 : EffectEffectiveDataPVITemp, IOuterShadowEffectiveData
{
	internal Class18 class18_0;

	internal RectangleAlignment rectangleAlignment_0 = RectangleAlignment.Bottom;

	internal double double_0;

	internal float float_0;

	internal double double_1;

	internal double double_2;

	internal double double_3;

	internal bool bool_0 = true;

	internal double double_4 = 100.0;

	internal double double_5 = 100.0;

	public double BlurRadius => double_0;

	public float Direction => float_0;

	public double Distance => double_1;

	public Color ShadowColor => class18_0.Color;

	public RectangleAlignment RectangleAlign => rectangleAlignment_0;

	public double SkewHorizontal => double_2;

	public double SkewVertical => double_3;

	public bool RotateShadowWithShape => bool_0;

	public double ScaleHorizontal => double_4;

	public double ScaleVertical => double_5;

	internal Class41(RectangleAlignment alignment, double blurRad, float direction, double distance, double skewX, double skewY, bool rotateWithShape, double scaleX, double scaleY, Class21.Delegate2 shadowColorResolver)
	{
		rectangleAlignment_0 = alignment;
		double_0 = blurRad;
		float_0 = direction;
		double_1 = distance;
		double_2 = skewX;
		double_3 = skewY;
		bool_0 = rotateWithShape;
		double_4 = scaleX;
		double_5 = scaleY;
		class18_0 = new Class18(shadowColorResolver);
	}

	internal override Class190 vmethod_0(Class190 img)
	{
		throw new InvalidOperationException();
	}

	internal void method_0(Class159 canvas, GraphicsPath graphicsPath, Class63 fp, Class66 lp, RectangleF rect)
	{
		_ = lp?.Width;
		Matrix matrix = new Matrix();
		matrix.Scale((float)(ScaleHorizontal / 100.0), (float)(ScaleVertical / 100.0));
		matrix.Shear((float)SkewHorizontal, (float)SkewVertical);
		matrix.RotateAt(Direction, new PointF(rect.X + rect.Width / 2f, rect.Y + rect.Height / 2f));
		matrix.Translate((float)Distance, 0f);
		matrix.RotateAt(0f - Direction, new PointF(rect.X + rect.Width / 2f, rect.Y + rect.Height / 2f));
		graphicsPath.Transform(matrix);
		if (fp != null)
		{
			fp.FillType = FillType.Solid;
			fp.ForeColor = ShadowColor;
		}
		if (lp != null)
		{
			lp.ForeColor = ShadowColor;
		}
		canvas.vmethod_5(graphicsPath, lp, fp);
	}

	internal override void vmethod_2(IBaseSlide slide, FloatColor styleColor)
	{
		class18_0.method_0(slide, styleColor);
	}
}
