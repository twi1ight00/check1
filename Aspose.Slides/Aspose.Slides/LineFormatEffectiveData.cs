using ns33;

namespace Aspose.Slides;

public class LineFormatEffectiveData : ILineFormatEffectiveData, IEffectiveData, ILineParamSource
{
	private LineFillFormatEffectiveData lineFillFormatEffectiveData_0;

	private double double_0 = 0.75;

	private LineDashStyle lineDashStyle_0;

	private float[] float_0;

	private LineCapStyle lineCapStyle_0 = LineCapStyle.Flat;

	private LineStyle lineStyle_0;

	private LineAlignment lineAlignment_0;

	private LineJoinStyle lineJoinStyle_0 = LineJoinStyle.Miter;

	private float float_1 = 10f;

	private LineArrowheadStyle lineArrowheadStyle_0;

	private LineArrowheadStyle lineArrowheadStyle_1;

	private LineArrowheadWidth lineArrowheadWidth_0 = LineArrowheadWidth.Medium;

	private LineArrowheadWidth lineArrowheadWidth_1 = LineArrowheadWidth.Medium;

	private LineArrowheadLength lineArrowheadLength_0 = LineArrowheadLength.Medium;

	private LineArrowheadLength lineArrowheadLength_1 = LineArrowheadLength.Medium;

	public ILineFillFormatEffectiveData FillFormat => lineFillFormatEffectiveData_0;

	public double Width => double_0;

	public LineDashStyle DashStyle => lineDashStyle_0;

	public float[] CustomDashPattern => float_0;

	public LineCapStyle CapStyle => lineCapStyle_0;

	public LineStyle Style => lineStyle_0;

	public LineAlignment Alignment => lineAlignment_0;

	public LineJoinStyle JoinStyle => lineJoinStyle_0;

	public float MiterLimit => float_1;

	public LineArrowheadStyle BeginArrowheadStyle => lineArrowheadStyle_0;

	public LineArrowheadStyle EndArrowheadStyle => lineArrowheadStyle_1;

	public LineArrowheadWidth BeginArrowheadWidth => lineArrowheadWidth_0;

	public LineArrowheadWidth EndArrowheadWidth => lineArrowheadWidth_1;

	public LineArrowheadLength BeginArrowheadLength => lineArrowheadLength_0;

	public LineArrowheadLength EndArrowheadLength => lineArrowheadLength_1;

	internal LineFormatEffectiveData()
	{
		lineFillFormatEffectiveData_0 = new LineFillFormatEffectiveData();
	}

	internal LineFormatEffectiveData(ILineFormat source, BaseSlide slide, FloatColor styleColor)
		: this()
	{
		method_0(source, slide, styleColor);
	}

	internal void method_0(ILineFormat source, BaseSlide slide, FloatColor styleColor)
	{
		if (source == null)
		{
			lineFillFormatEffectiveData_0 = new LineFillFormatEffectiveData();
			return;
		}
		lineFillFormatEffectiveData_0.method_1((LineFillFormat)source.FillFormat, slide, styleColor);
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
	}

	internal void method_1(ILineFormat source, BaseSlide slide, FloatColor styleColor)
	{
		if (source == null)
		{
			return;
		}
		if (source.FillFormat.FillType != FillType.NotDefined)
		{
			if (lineFillFormatEffectiveData_0.fillType_0 == source.FillFormat.FillType)
			{
				lineFillFormatEffectiveData_0.method_1((LineFillFormat)source.FillFormat, slide, styleColor);
			}
			else
			{
				lineFillFormatEffectiveData_0 = new LineFillFormatEffectiveData((LineFillFormat)source.FillFormat, slide, styleColor);
			}
		}
		if (source.DashStyle != LineDashStyle.NotDefined)
		{
			lineDashStyle_0 = source.DashStyle;
		}
		if (!double.IsNaN(source.Width))
		{
			double_0 = source.Width;
		}
		if (source.CapStyle != LineCapStyle.NotDefined)
		{
			lineCapStyle_0 = source.CapStyle;
		}
		if (source.Style != LineStyle.NotDefined)
		{
			lineStyle_0 = source.Style;
		}
		if (source.Alignment != LineAlignment.NotDefined)
		{
			lineAlignment_0 = source.Alignment;
		}
		if (source.JoinStyle != LineJoinStyle.NotDefined)
		{
			lineJoinStyle_0 = source.JoinStyle;
		}
		if (!float.IsNaN(source.MiterLimit))
		{
			float_1 = source.MiterLimit;
		}
		if (source.BeginArrowheadStyle != LineArrowheadStyle.NotDefined)
		{
			lineArrowheadStyle_0 = source.BeginArrowheadStyle;
		}
		if (source.EndArrowheadStyle != LineArrowheadStyle.NotDefined)
		{
			lineArrowheadStyle_1 = source.EndArrowheadStyle;
		}
		if (source.BeginArrowheadWidth != LineArrowheadWidth.NotDefined)
		{
			lineArrowheadWidth_0 = source.BeginArrowheadWidth;
		}
		if (source.EndArrowheadWidth != LineArrowheadWidth.NotDefined)
		{
			lineArrowheadWidth_1 = source.EndArrowheadWidth;
		}
		if (source.BeginArrowheadLength != LineArrowheadLength.NotDefined)
		{
			lineArrowheadLength_0 = source.BeginArrowheadLength;
		}
		if (source.EndArrowheadLength != LineArrowheadLength.NotDefined)
		{
			lineArrowheadLength_1 = source.EndArrowheadLength;
		}
	}

	public override bool Equals(object obj)
	{
		if (obj is LineFormatEffectiveData)
		{
			return Equals((LineFormatEffectiveData)obj);
		}
		return false;
	}

	public bool Equals(ILineFormatEffectiveData lf)
	{
		LineFormatEffectiveData lineFormatEffectiveData = (LineFormatEffectiveData)lf;
		if (lineFormatEffectiveData == null)
		{
			return false;
		}
		if (lineFillFormatEffectiveData_0.Equals(lineFormatEffectiveData.lineFillFormatEffectiveData_0) && Class1165.smethod_1(double_0, lineFormatEffectiveData.double_0) && lineAlignment_0 == lineFormatEffectiveData.lineAlignment_0 && lineStyle_0 == lineFormatEffectiveData.lineStyle_0 && lineJoinStyle_0 == lineFormatEffectiveData.lineJoinStyle_0 && lineCapStyle_0 == lineFormatEffectiveData.lineCapStyle_0 && Class1165.smethod_0(float_1, lineFormatEffectiveData.float_1) && BeginArrowheadStyle == lineFormatEffectiveData.BeginArrowheadStyle && BeginArrowheadLength == lineFormatEffectiveData.BeginArrowheadLength && BeginArrowheadWidth == lineFormatEffectiveData.BeginArrowheadWidth && EndArrowheadStyle == lineFormatEffectiveData.EndArrowheadStyle && EndArrowheadLength == lineFormatEffectiveData.EndArrowheadLength)
		{
			return EndArrowheadWidth == lineFormatEffectiveData.EndArrowheadWidth;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return 23456;
	}
}
