using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using ns11;
using ns4;
using ns5;

namespace Aspose.Slides.Effects;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Guid("A276CE41-002A-4FEF-82E3-190A7D8E045A")]
public class OuterShadow : IOuterShadow, IEffect
{
	private ColorFormat colorFormat_0;

	private RectangleAlignment rectangleAlignment_0 = RectangleAlignment.Bottom;

	private double double_0;

	private float float_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private bool bool_0 = true;

	private double double_4 = 100.0;

	private double double_5 = 100.0;

	private IPresentationComponent ipresentationComponent_0;

	private uint uint_0;

	public double BlurRadius
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			method_2();
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
			method_2();
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
			method_2();
		}
	}

	public IColorFormat ShadowColor => colorFormat_0;

	public RectangleAlignment RectangleAlign
	{
		get
		{
			return rectangleAlignment_0;
		}
		set
		{
			rectangleAlignment_0 = value;
			method_2();
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
			method_2();
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
			method_2();
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
			method_2();
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
			method_2();
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
			method_2();
		}
	}

	internal IPresentationComponent Parent => ipresentationComponent_0;

	internal uint Version => uint_0 + colorFormat_0.Version;

	internal OuterShadow(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		colorFormat_0 = new ColorFormat(parent as ISlideComponent, PresetColor.Black);
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
			fp.ForeColor = ShadowColor.Color;
		}
		if (lp != null)
		{
			lp.ForeColor = ShadowColor.Color;
		}
		canvas.vmethod_5(graphicsPath, lp, fp);
	}

	internal OuterShadow Clone()
	{
		OuterShadow outerShadow = (OuterShadow)MemberwiseClone();
		outerShadow.colorFormat_0 = new ColorFormat(null);
		outerShadow.colorFormat_0.method_0(colorFormat_0);
		return outerShadow;
	}

	internal void method_1(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		colorFormat_0.Parent = parent as ISlideComponent;
		method_2();
	}

	EffectEffectiveData IEffect.GetReadonly(BaseSlide slide, FloatColor styleColor)
	{
		return new OuterShadowEffectiveData(rectangleAlignment_0, double_0, float_0, double_1, double_2, double_3, bool_0, double_4, double_5, colorFormat_0.method_5(slide, styleColor));
	}

	EffectEffectiveDataPVITemp IEffect.GetReadonly()
	{
		return new Class41(rectangleAlignment_0, double_0, float_0, double_1, double_2, double_3, bool_0, double_4, double_5, colorFormat_0.method_5);
	}

	private void method_2()
	{
		uint_0++;
	}
}
