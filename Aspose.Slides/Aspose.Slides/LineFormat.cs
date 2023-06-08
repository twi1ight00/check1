using ns28;
using ns33;

namespace Aspose.Slides;

public class LineFormat : ILineFormat, ILineParamSource
{
	private LineFillFormat lineFillFormat_0;

	private double double_0 = double.NaN;

	private LineDashStyle lineDashStyle_0 = LineDashStyle.NotDefined;

	private float[] float_0;

	private LineCapStyle lineCapStyle_0 = LineCapStyle.NotDefined;

	private LineStyle lineStyle_0 = LineStyle.NotDefined;

	private LineAlignment lineAlignment_0 = LineAlignment.NotDefined;

	private LineJoinStyle lineJoinStyle_0 = LineJoinStyle.NotDefined;

	private float float_1 = float.NaN;

	private LineArrowheadStyle lineArrowheadStyle_0 = LineArrowheadStyle.NotDefined;

	private LineArrowheadStyle lineArrowheadStyle_1 = LineArrowheadStyle.NotDefined;

	private LineArrowheadWidth lineArrowheadWidth_0 = LineArrowheadWidth.NotDefined;

	private LineArrowheadWidth lineArrowheadWidth_1 = LineArrowheadWidth.NotDefined;

	private LineArrowheadLength lineArrowheadLength_0 = LineArrowheadLength.NotDefined;

	private LineArrowheadLength lineArrowheadLength_1 = LineArrowheadLength.NotDefined;

	private IPresentationComponent ipresentationComponent_0;

	private uint uint_0;

	public bool IsFormatNotDefined
	{
		get
		{
			if (lineFillFormat_0.fillType_0 == FillType.NotDefined && double.IsNaN(double_0) && lineAlignment_0 == LineAlignment.NotDefined && lineStyle_0 == LineStyle.NotDefined && lineJoinStyle_0 == LineJoinStyle.NotDefined && lineCapStyle_0 == LineCapStyle.NotDefined && lineDashStyle_0 == LineDashStyle.NotDefined && float.IsNaN(float_1) && lineArrowheadStyle_0 == LineArrowheadStyle.NotDefined && lineArrowheadLength_0 == LineArrowheadLength.NotDefined && lineArrowheadWidth_0 == LineArrowheadWidth.NotDefined && lineArrowheadStyle_1 == LineArrowheadStyle.NotDefined && lineArrowheadLength_1 == LineArrowheadLength.NotDefined)
			{
				return lineArrowheadWidth_1 == LineArrowheadWidth.NotDefined;
			}
			return false;
		}
	}

	public ILineFillFormat FillFormat => lineFillFormat_0;

	public double Width
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = Class1165.smethod_6(value, 0.0, 4096.0);
			method_3();
		}
	}

	public LineDashStyle DashStyle
	{
		get
		{
			return lineDashStyle_0;
		}
		set
		{
			lineDashStyle_0 = value;
			method_3();
		}
	}

	public float[] CustomDashPattern
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			if (value != null)
			{
				lineDashStyle_0 = LineDashStyle.Custom;
			}
			method_3();
		}
	}

	public LineCapStyle CapStyle
	{
		get
		{
			return lineCapStyle_0;
		}
		set
		{
			lineCapStyle_0 = value;
			method_3();
		}
	}

	public LineStyle Style
	{
		get
		{
			return lineStyle_0;
		}
		set
		{
			lineStyle_0 = value;
			method_3();
		}
	}

	public LineAlignment Alignment
	{
		get
		{
			return lineAlignment_0;
		}
		set
		{
			lineAlignment_0 = value;
			method_3();
		}
	}

	public LineJoinStyle JoinStyle
	{
		get
		{
			return lineJoinStyle_0;
		}
		set
		{
			lineJoinStyle_0 = value;
			method_3();
		}
	}

	public float MiterLimit
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

	public LineArrowheadStyle BeginArrowheadStyle
	{
		get
		{
			return lineArrowheadStyle_0;
		}
		set
		{
			lineArrowheadStyle_0 = value;
			method_3();
		}
	}

	public LineArrowheadStyle EndArrowheadStyle
	{
		get
		{
			return lineArrowheadStyle_1;
		}
		set
		{
			lineArrowheadStyle_1 = value;
			method_3();
		}
	}

	public LineArrowheadWidth BeginArrowheadWidth
	{
		get
		{
			return lineArrowheadWidth_0;
		}
		set
		{
			lineArrowheadWidth_0 = value;
			method_3();
		}
	}

	public LineArrowheadWidth EndArrowheadWidth
	{
		get
		{
			return lineArrowheadWidth_1;
		}
		set
		{
			lineArrowheadWidth_1 = value;
			method_3();
		}
	}

	public LineArrowheadLength BeginArrowheadLength
	{
		get
		{
			return lineArrowheadLength_0;
		}
		set
		{
			lineArrowheadLength_0 = value;
			method_3();
		}
	}

	public LineArrowheadLength EndArrowheadLength
	{
		get
		{
			return lineArrowheadLength_1;
		}
		set
		{
			lineArrowheadLength_1 = value;
			method_3();
		}
	}

	internal IBaseSlide Slide
	{
		get
		{
			if (!(ipresentationComponent_0 is ISlideComponent slideComponent))
			{
				return null;
			}
			return slideComponent.Slide;
		}
	}

	internal uint Version => uint_0 + lineFillFormat_0.Version;

	internal LineFormat(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		lineFillFormat_0 = new LineFillFormat(parent);
	}

	internal void method_0(LineFormat source)
	{
		lineFillFormat_0.method_0(source.lineFillFormat_0);
		lineDashStyle_0 = source.lineDashStyle_0;
		double_0 = source.double_0;
		lineCapStyle_0 = source.lineCapStyle_0;
		lineStyle_0 = source.lineStyle_0;
		lineAlignment_0 = source.lineAlignment_0;
		lineJoinStyle_0 = source.lineJoinStyle_0;
		float_1 = source.float_1;
		lineArrowheadStyle_0 = source.lineArrowheadStyle_0;
		lineArrowheadStyle_1 = source.lineArrowheadStyle_1;
		lineArrowheadWidth_0 = source.lineArrowheadWidth_0;
		lineArrowheadWidth_1 = source.lineArrowheadWidth_1;
		lineArrowheadLength_0 = source.lineArrowheadLength_0;
		lineArrowheadLength_1 = source.lineArrowheadLength_1;
		method_3();
	}

	internal void method_1(LineFormatEffectiveData source)
	{
		lineFillFormat_0.method_1(source.FillFormat);
		lineDashStyle_0 = source.DashStyle;
		double_0 = source.Width;
		lineCapStyle_0 = source.CapStyle;
		lineStyle_0 = source.Style;
		lineAlignment_0 = source.Alignment;
		lineJoinStyle_0 = source.JoinStyle;
		float_1 = source.MiterLimit;
		lineArrowheadStyle_0 = source.BeginArrowheadStyle;
		lineArrowheadStyle_1 = source.EndArrowheadStyle;
		lineArrowheadWidth_0 = source.BeginArrowheadWidth;
		lineArrowheadWidth_1 = source.EndArrowheadWidth;
		lineArrowheadLength_0 = source.BeginArrowheadLength;
		lineArrowheadLength_1 = source.EndArrowheadLength;
		method_3();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is LineFormat lineFormat))
		{
			return false;
		}
		return Equals(lineFormat);
	}

	public bool Equals(ILineFormat lineFormat)
	{
		if (lineFormat == null)
		{
			return false;
		}
		LineFormat lineFormat2 = (LineFormat)lineFormat;
		if (lineFillFormat_0.Equals(lineFormat2.lineFillFormat_0) && Class1165.smethod_1(double_0, lineFormat2.double_0) && lineAlignment_0 == lineFormat2.lineAlignment_0 && lineStyle_0 == lineFormat2.lineStyle_0 && lineJoinStyle_0 == lineFormat2.lineJoinStyle_0 && lineCapStyle_0 == lineFormat2.lineCapStyle_0 && Class1165.smethod_0(float_1, lineFormat2.float_1) && lineArrowheadStyle_0 == lineFormat2.lineArrowheadStyle_0 && lineArrowheadLength_0 == lineFormat2.lineArrowheadLength_0 && lineArrowheadWidth_0 == lineFormat2.lineArrowheadWidth_0 && lineArrowheadStyle_1 == lineFormat2.lineArrowheadStyle_1 && lineArrowheadLength_1 == lineFormat2.lineArrowheadLength_1)
		{
			return lineArrowheadWidth_1 == lineFormat2.lineArrowheadWidth_1;
		}
		return false;
	}

	internal void method_2(Class437 style, Class476 package)
	{
		if (style != null && style.GraphicProperties.StrokeStyle != Enum83.const_3)
		{
			if (!double.IsNaN(style.GraphicProperties.StrokeWidth))
			{
				Width = style.GraphicProperties.StrokeWidth;
			}
			lineFillFormat_0.SolidFillColor.Color = style.GraphicProperties.StrokeColor;
			if (style.GraphicProperties.StartMarker != "")
			{
				Class409 @class = package.class465_0.method_8(style.GraphicProperties.StartMarker);
				Class368.smethod_5(@class.D, @class.ViewBox, style.GraphicProperties.StrokeWidth, style.GraphicProperties.StartMarkerWidth, out lineArrowheadStyle_0, out lineArrowheadLength_0, out lineArrowheadWidth_0);
			}
			if (style.GraphicProperties.EndMarker != "")
			{
				Class409 class2 = package.class465_0.method_8(style.GraphicProperties.EndMarker);
				Class368.smethod_5(class2.D, class2.ViewBox, style.GraphicProperties.StrokeWidth, style.GraphicProperties.EndMarkerWidth, out lineArrowheadStyle_1, out lineArrowheadLength_1, out lineArrowheadWidth_1);
			}
			switch (style.GraphicProperties.StrokeStyle)
			{
			case Enum83.const_0:
				lineFillFormat_0.FillType = FillType.NoFill;
				DashStyle = LineDashStyle.Solid;
				break;
			case Enum83.const_1:
			{
				lineFillFormat_0.FillType = FillType.Solid;
				DashStyle = LineDashStyle.Custom;
				Class436 class3 = package.class465_0.method_11(style.GraphicProperties.StrokeDash);
				if (class3 == null)
				{
					break;
				}
				double num = 0.0;
				double num2 = 0.0;
				double num3 = style.GraphicProperties.StrokeWidth;
				if (num3 == 0.0)
				{
					num3 = 1.0;
				}
				if (class3.bool_2)
				{
					num2 = num3 / 100.0 * class3.Distance;
					num2 /= 6.0;
				}
				else
				{
					num2 = class3.Distance / num3;
				}
				double num4;
				if (class3.bool_0)
				{
					num4 = num3 / 100.0 * class3.Dots1Length;
					num4 /= 6.0;
				}
				else
				{
					num4 = class3.Dots1Length / num3;
				}
				if (class3.Dots2 > 0)
				{
					if (class3.bool_1)
					{
						num = num3 / 100.0 * class3.Dots2Length;
						num /= 6.0;
					}
					else
					{
						num = class3.Dots2Length / num3;
					}
				}
				float[] array = new float[(class3.Dots1 + class3.Dots2) * 2];
				for (int i = 0; i < class3.Dots1 * 2; i += 2)
				{
					array[i] = (float)num4;
					array[i + 1] = (float)num2;
				}
				for (int j = class3.Dots1 * 2; j < array.Length; j += 2)
				{
					array[j] = (float)num;
					array[j + 1] = (float)num2;
				}
				float_0 = array;
				break;
			}
			case Enum83.const_2:
				lineFillFormat_0.FillType = FillType.Solid;
				DashStyle = LineDashStyle.Solid;
				break;
			}
		}
		method_3();
	}

	public override int GetHashCode()
	{
		return 23456;
	}

	private void method_3()
	{
		uint_0++;
	}
}
