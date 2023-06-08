using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells.Charts;
using ns2;
using ns21;
using ns7;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Encapsulates the object that represents the line format.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///       //Applying a dotted line style on the lines of an NSeries
///       chart.NSeries[0].Line.Style = LineType.Dot;
///       //Applying a triangular marker style on the data markers of an NSeries
///       chart.NSeries[0].MarkerStyle = ChartMarkerType.Triangle;
///       //Setting the weight of all lines in an NSeries to medium
///       chart.NSeries[1].Line.Weight = WeightType.MediumLine;
///
///       [Visual Basic]
///
///       'Applying a dotted line style on the lines of an NSeries
///       chart.NSeries(0).Line.Style = LineType.Dot
///       'Applying a triangular marker style on the data markers of an NSeries
///       chart.NSeries(0).MarkerStyle = ChartMarkerType.Triangle
///       'Setting the weight of all lines in an NSeries to medium
///       chart.NSeries(1).Line.Weight = WeightType.MediumLine
///       </code>
/// </example>
public class Line
{
	protected object lineParent;

	private Chart chart_0;

	private Class923 class923_0;

	internal InternalColor internalColor_0;

	private int int_0;

	private int int_1;

	private GradientFill gradientFill_0;

	/// <summary>
	///       Represents the <see cref="T:System.Drawing.Color" /> of the line.
	///       </summary>
	public Color Color
	{
		get
		{
			return internalColor_0.method_6(chart_0.method_14().Workbook);
		}
		set
		{
			if (value.IsEmpty)
			{
				internalColor_0.SetColor(ColorType.Automatic, 0);
			}
			else
			{
				internalColor_0.SetColor(ColorType.RGB, value.ToArgb());
				if (method_26() == Enum229.const_2 || method_26() == Enum229.const_0)
				{
					method_27(Enum229.const_1);
				}
			}
			method_24();
			int_1 |= 1024;
		}
	}

	/// <summary>
	///       Returns or sets the degree of transparency of the line as a value from 0.0 (opaque) through 1.0 (clear).
	///       </summary>
	public double Transparency
	{
		get
		{
			return Math.Round((double)(100 - method_22()) / 100.0, 2);
		}
		set
		{
			if (value < 0.0 || value > 1.0)
			{
				throw new CellsException(ExceptionType.InvalidData, "Transparency must between 0.0 (opaque) and 1.0 (clear)");
			}
			method_23(100 - (int)(value * 100.0));
		}
	}

	/// <summary>
	///       Represents the style of the line.
	///       </summary>
	public LineType Style
	{
		get
		{
			if (method_0() != null && method_3() != MsoLineDashStyle.Solid)
			{
				switch (method_3())
				{
				case MsoLineDashStyle.DashDot:
					return LineType.DashDot;
				case MsoLineDashStyle.DashDotDot:
					return LineType.DashDotDot;
				case MsoLineDashStyle.Dash:
				case MsoLineDashStyle.DashLongDash:
				case MsoLineDashStyle.DashLongDashDot:
					return LineType.Dash;
				case MsoLineDashStyle.RoundDot:
				case MsoLineDashStyle.SquareDot:
					return LineType.Dot;
				}
			}
			return ((int_1 & 0xF0) >> 4) switch
			{
				0 => LineType.Solid, 
				1 => LineType.Dash, 
				2 => LineType.Dot, 
				3 => LineType.DashDot, 
				4 => LineType.DashDotDot, 
				6 => LineType.DarkGray, 
				7 => LineType.MediumGray, 
				8 => LineType.LightGray, 
				_ => LineType.Solid, 
			};
		}
		set
		{
			int_1 &= -241;
			if (method_0() != null && method_3() != MsoLineDashStyle.Solid)
			{
				method_4(MsoLineDashStyle.Solid);
			}
			IsVisible = true;
			switch (value)
			{
			case LineType.Dash:
				int_1 |= 16;
				method_4(MsoLineDashStyle.Dash);
				break;
			case LineType.Dot:
				int_1 |= 32;
				method_4(MsoLineDashStyle.RoundDot);
				break;
			case LineType.DashDot:
				int_1 |= 48;
				method_4(MsoLineDashStyle.DashDot);
				break;
			case LineType.DashDotDot:
				int_1 |= 64;
				method_4(MsoLineDashStyle.DashDotDot);
				break;
			case LineType.DarkGray:
				int_1 |= 96;
				break;
			case LineType.MediumGray:
				int_1 |= 112;
				break;
			case LineType.LightGray:
				int_1 |= 128;
				break;
			}
			method_24();
			int_1 |= 2048;
		}
	}

	/// <summary>
	///       Gets or sets the <see cref="T:Aspose.Cells.Drawing.WeightType" /> of the line.
	///       </summary>
	public WeightType Weight
	{
		get
		{
			if (int_0 <= 3175)
			{
				return WeightType.HairLine;
			}
			if (int_0 <= 12700)
			{
				return WeightType.SingleLine;
			}
			if (int_0 <= 25400)
			{
				return WeightType.MediumLine;
			}
			return WeightType.WideLine;
		}
		set
		{
			switch (value)
			{
			case WeightType.HairLine:
				int_0 = 3175;
				break;
			case WeightType.SingleLine:
				int_0 = 12700;
				break;
			case WeightType.MediumLine:
				int_0 = 25400;
				break;
			case WeightType.WideLine:
				int_0 = 38100;
				break;
			}
			method_24();
			int_1 |= 512;
		}
	}

	/// <summary>
	///       Gets or sets the weight of the line in unit of points.
	///       Only applies for Excel 2007 file.
	///       </summary>
	public double WeightPt
	{
		get
		{
			return (double)int_0 / Class1391.double_0;
		}
		set
		{
			int_0 = (int)(value * Class1391.double_0 + 0.5);
			method_24();
			int_1 |= 512;
		}
	}

	/// <summary>
	///       Indicates whether the color of line is auotmatic assigned.
	///       </summary>
	public bool IsAutomaticColor => (int_1 & 0x400) == 0;

	/// <summary>
	///       Represents if the axis is visible in the chart.
	///       </summary>
	public bool IsVisible
	{
		get
		{
			return method_26() != Enum229.const_2;
		}
		set
		{
			method_27((!value) ? Enum229.const_2 : Enum229.const_0);
			method_24();
		}
	}

	/// <summary>
	///       Indicates whether this line style is auto assigned.
	///       </summary>
	public bool IsAuto
	{
		get
		{
			return method_26() == Enum229.const_0;
		}
		set
		{
			method_27((!value) ? Enum229.const_1 : Enum229.const_0);
		}
	}

	public GradientFill GradientFill
	{
		get
		{
			if (method_26() == Enum229.const_3)
			{
				if (gradientFill_0 == null)
				{
					gradientFill_0 = new GradientFill(this, chart_0.method_14().Workbook);
				}
				return gradientFill_0;
			}
			return null;
		}
	}

	internal Class923 Properties
	{
		get
		{
			if (class923_0 == null)
			{
				class923_0 = new Class923();
			}
			return class923_0;
		}
	}

	internal Line(Chart chart_1, object object_0)
	{
		lineParent = object_0;
		chart_0 = chart_1;
		internalColor_0 = new InternalColor(bool_0: true);
	}

	internal Class923 method_0()
	{
		return class923_0;
	}

	[SpecialName]
	internal MsoLineStyle method_1()
	{
		if (class923_0 != null)
		{
			object obj = class923_0.method_1(Enum230.const_0);
			if (obj != null)
			{
				return (MsoLineStyle)obj;
			}
		}
		return MsoLineStyle.Single;
	}

	[SpecialName]
	internal void method_2(MsoLineStyle msoLineStyle_0)
	{
		Properties.method_0(Enum230.const_0, msoLineStyle_0);
		method_24();
	}

	[SpecialName]
	internal MsoLineDashStyle method_3()
	{
		object obj = Properties.method_1(Enum230.const_1);
		if (obj != null)
		{
			return (MsoLineDashStyle)obj;
		}
		return MsoLineDashStyle.Solid;
	}

	[SpecialName]
	internal void method_4(MsoLineDashStyle msoLineDashStyle_0)
	{
		Properties.method_0(Enum230.const_1, msoLineDashStyle_0);
		method_24();
	}

	[SpecialName]
	internal Enum231 method_5()
	{
		object obj = Properties.method_1(Enum230.const_2);
		if (obj != null)
		{
			return (Enum231)obj;
		}
		return Enum231.const_3;
	}

	[SpecialName]
	internal void method_6(Enum231 enum231_0)
	{
		Properties.method_0(Enum230.const_2, enum231_0);
		method_24();
	}

	[SpecialName]
	internal Enum232 method_7()
	{
		object obj = Properties.method_1(Enum230.const_3);
		if (obj != null)
		{
			return (Enum232)obj;
		}
		return Enum232.const_3;
	}

	[SpecialName]
	internal void method_8(Enum232 enum232_0)
	{
		Properties.method_0(Enum230.const_3, enum232_0);
		method_24();
	}

	[SpecialName]
	internal MsoArrowheadStyle method_9()
	{
		object obj = Properties.method_1(Enum230.const_4);
		if (obj != null)
		{
			return (MsoArrowheadStyle)obj;
		}
		return MsoArrowheadStyle.None;
	}

	[SpecialName]
	internal void method_10(MsoArrowheadStyle msoArrowheadStyle_0)
	{
		Properties.method_0(Enum230.const_4, msoArrowheadStyle_0);
	}

	[SpecialName]
	internal MsoArrowheadStyle method_11()
	{
		object obj = Properties.method_1(Enum230.const_7);
		if (obj != null)
		{
			return (MsoArrowheadStyle)obj;
		}
		return MsoArrowheadStyle.None;
	}

	[SpecialName]
	internal void method_12(MsoArrowheadStyle msoArrowheadStyle_0)
	{
		Properties.method_0(Enum230.const_7, msoArrowheadStyle_0);
	}

	[SpecialName]
	internal MsoArrowheadLength method_13()
	{
		object obj = Properties.method_1(Enum230.const_6);
		if (obj != null)
		{
			return (MsoArrowheadLength)obj;
		}
		return MsoArrowheadLength.Short;
	}

	[SpecialName]
	internal void method_14(MsoArrowheadLength msoArrowheadLength_0)
	{
		Properties.method_0(Enum230.const_6, msoArrowheadLength_0);
	}

	[SpecialName]
	internal MsoArrowheadLength method_15()
	{
		object obj = Properties.method_1(Enum230.const_9);
		if (obj != null)
		{
			return (MsoArrowheadLength)obj;
		}
		return MsoArrowheadLength.Short;
	}

	[SpecialName]
	internal void method_16(MsoArrowheadLength msoArrowheadLength_0)
	{
		Properties.method_0(Enum230.const_9, msoArrowheadLength_0);
	}

	[SpecialName]
	internal MsoArrowheadWidth method_17()
	{
		object obj = Properties.method_1(Enum230.const_5);
		if (obj != null)
		{
			return (MsoArrowheadWidth)obj;
		}
		return MsoArrowheadWidth.Narrow;
	}

	[SpecialName]
	internal void method_18(MsoArrowheadWidth msoArrowheadWidth_0)
	{
		Properties.method_0(Enum230.const_5, msoArrowheadWidth_0);
	}

	[SpecialName]
	internal MsoArrowheadWidth method_19()
	{
		object obj = Properties.method_1(Enum230.const_8);
		if (obj != null)
		{
			return (MsoArrowheadWidth)obj;
		}
		return MsoArrowheadWidth.Narrow;
	}

	[SpecialName]
	internal void method_20(MsoArrowheadWidth msoArrowheadWidth_0)
	{
		Properties.method_0(Enum230.const_8, msoArrowheadWidth_0);
	}

	internal void method_21(Color color_0)
	{
		if (color_0.IsEmpty)
		{
			internalColor_0.SetColor(ColorType.Automatic, 0);
		}
		else
		{
			internalColor_0.SetColor(ColorType.RGB, color_0.ToArgb());
		}
		method_24();
		int_1 |= 1024;
	}

	[SpecialName]
	internal int method_22()
	{
		object obj = Properties.method_1(Enum230.const_10);
		if (obj != null)
		{
			return (int)obj / 1000;
		}
		return 100;
	}

	[SpecialName]
	internal void method_23(int int_2)
	{
		Class1691 @class = Properties.method_2(Enum230.const_10);
		if (@class == null)
		{
			Properties.method_0(Enum230.const_10, int_2 * 1000);
		}
		else
		{
			@class.object_0 = int_2 * 1000;
		}
	}

	internal void method_24()
	{
		if (lineParent != null)
		{
			if (lineParent is ChartFrame)
			{
				((ChartFrame)lineParent).method_0(null);
			}
			else if (lineParent is DateTime)
			{
				((Class1632)lineParent).method_0(null);
			}
		}
		if (method_26() == Enum229.const_0)
		{
			method_27(Enum229.const_1);
		}
	}

	internal void method_25(LineType lineType_0)
	{
		int_1 &= -241;
		if (method_0() != null && method_3() != MsoLineDashStyle.Solid)
		{
			method_4(MsoLineDashStyle.Solid);
		}
		switch (lineType_0)
		{
		case LineType.Dash:
			int_1 |= 16;
			method_4(MsoLineDashStyle.Dash);
			break;
		case LineType.Dot:
			int_1 |= 32;
			method_4(MsoLineDashStyle.RoundDot);
			break;
		case LineType.DashDot:
			int_1 |= 48;
			method_4(MsoLineDashStyle.DashDot);
			break;
		case LineType.DashDotDot:
			int_1 |= 64;
			method_4(MsoLineDashStyle.DashDotDot);
			break;
		case LineType.DarkGray:
			int_1 |= 96;
			break;
		case LineType.MediumGray:
			int_1 |= 112;
			break;
		case LineType.LightGray:
			int_1 |= 128;
			break;
		}
		int_1 |= 2048;
	}

	[SpecialName]
	internal Enum229 method_26()
	{
		return (int_1 & 0xF) switch
		{
			0 => Enum229.const_0, 
			1 => Enum229.const_2, 
			2 => Enum229.const_1, 
			3 => Enum229.const_3, 
			_ => Enum229.const_0, 
		};
	}

	[SpecialName]
	internal void method_27(Enum229 enum229_0)
	{
		int_1 &= -16;
		switch (enum229_0)
		{
		case Enum229.const_1:
			int_1 |= 2;
			break;
		case Enum229.const_2:
			int_1 |= 1;
			break;
		case Enum229.const_3:
			int_1 |= 3;
			break;
		}
		int_1 |= 256;
	}

	[SpecialName]
	internal bool method_28()
	{
		return (int_1 & 0x200) != 0;
	}

	[SpecialName]
	internal bool method_29()
	{
		return (int_1 & 0x400) != 0;
	}

	[SpecialName]
	internal void method_30(bool bool_0)
	{
		if (bool_0)
		{
			int_1 |= 1024;
		}
		else
		{
			int_1 &= -1025;
		}
	}

	internal void Copy(Line line_0)
	{
		if (line_0.internalColor_0.ColorType == ColorType.RGB && line_0.chart_0.method_14() != chart_0.method_14())
		{
			internalColor_0.SetColor(ColorType.RGB, line_0.internalColor_0.method_7(line_0.chart_0.method_14().Workbook));
		}
		else
		{
			internalColor_0.method_19(line_0.internalColor_0);
		}
		if (line_0.class923_0 != null)
		{
			class923_0 = new Class923();
			class923_0.Copy(line_0.class923_0);
		}
		if (line_0.gradientFill_0 != null)
		{
			gradientFill_0 = new GradientFill(this, chart_0.method_14().Workbook);
			gradientFill_0.Copy(line_0.gradientFill_0);
		}
		int_0 = line_0.int_0;
		int_1 = line_0.int_1;
	}
}
