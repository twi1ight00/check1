using System;
using System.Drawing;
using Aspose.Cells.Drawing;
using ns21;
using ns7;

namespace Aspose.Cells.Charts;

public class Marker
{
	private Line line_0;

	private Area area_0;

	private ChartMarkerType chartMarkerType_0;

	private int int_0 = 5;

	internal bool bool_0 = true;

	private object object_0;

	private Class1632 class1632_0;

	private ShapePropertyCollection shapePropertyCollection_0;

	public Line Border
	{
		get
		{
			if (line_0 == null)
			{
				line_0 = new Line(class1632_0.Chart, this);
			}
			return line_0;
		}
	}

	public Area Area
	{
		get
		{
			if (area_0 == null)
			{
				area_0 = new Area(class1632_0.Chart, this);
			}
			return area_0;
		}
	}

	public ChartMarkerType MarkerStyle
	{
		get
		{
			return chartMarkerType_0;
		}
		set
		{
			chartMarkerType_0 = value;
			method_0();
			switch (value)
			{
			case ChartMarkerType.None:
				Border.method_27(Enum229.const_2);
				Area.Formatting = FormattingType.None;
				break;
			case ChartMarkerType.Automatic:
				Border.method_27(Enum229.const_0);
				Area.Formatting = FormattingType.Automatic;
				break;
			}
		}
	}

	public int MarkerSize
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < 2 || value > 72)
			{
				throw new ArgumentException("Invalid marker size : it must be between 2 and 27.");
			}
			int_0 = value;
			method_0();
			method_5();
			bool_0 = false;
		}
	}

	internal Color MarkerForegroundColor
	{
		get
		{
			return Border.Color;
		}
		set
		{
			Border.Color = value;
			Border.method_27(Enum229.const_1);
			method_0();
			method_5();
		}
	}

	internal FormattingType MarkerForegroundColorSetType
	{
		get
		{
			if (line_0 != null)
			{
				switch (line_0.method_26())
				{
				case Enum229.const_0:
					return FormattingType.Automatic;
				case Enum229.const_1:
					if (!line_0.internalColor_0.method_2())
					{
						return FormattingType.Custom;
					}
					return FormattingType.Automatic;
				case Enum229.const_2:
					return FormattingType.None;
				}
			}
			return FormattingType.Automatic;
		}
		set
		{
			switch (value)
			{
			default:
				Border.method_27(Enum229.const_1);
				break;
			case FormattingType.Automatic:
				Border.method_27(Enum229.const_0);
				Border.internalColor_0.method_3(bool_0: true);
				break;
			case FormattingType.None:
				Border.method_27(Enum229.const_2);
				break;
			}
			method_0();
			method_5();
		}
	}

	internal Color MarkerBackgroundColor
	{
		get
		{
			return Area.ForegroundColor;
		}
		set
		{
			Area.ForegroundColor = value;
			Area.Formatting = FormattingType.Custom;
			method_0();
			method_5();
		}
	}

	internal FormattingType MarkerBackgroundColorSetType
	{
		get
		{
			return Area.Formatting;
		}
		set
		{
			Area.Formatting = value;
			method_0();
			method_5();
		}
	}

	internal Chart Chart
	{
		get
		{
			if (object_0 == null)
			{
				return null;
			}
			if (object_0 is ChartPoint)
			{
				return ((ChartPoint)object_0).method_0().NSeries.Chart;
			}
			if (object_0 is Series)
			{
				return ((Series)object_0).NSeries.Chart;
			}
			if (object_0 is Class1387)
			{
				return ((Class1387)object_0).method_0().Chart;
			}
			return null;
		}
	}

	internal ShapePropertyCollection ShapeProperties
	{
		get
		{
			if (shapePropertyCollection_0 == null)
			{
				shapePropertyCollection_0 = new ShapePropertyCollection(class1632_0.Chart, this, Enum178.const_4);
			}
			return shapePropertyCollection_0;
		}
	}

	internal void method_0()
	{
		class1632_0.method_0(null);
	}

	internal void method_1(ChartMarkerType chartMarkerType_1)
	{
		chartMarkerType_0 = chartMarkerType_1;
	}

	internal Area method_2()
	{
		return area_0;
	}

	internal Line method_3()
	{
		return line_0;
	}

	internal Marker(object object_1, Class1632 class1632_1)
	{
		object_0 = object_1;
		class1632_0 = class1632_1;
		Chart chart = class1632_1.Chart;
		if (chart != null)
		{
			if (chart.method_14().Workbook.method_23())
			{
				int_0 = 7;
			}
			else
			{
				int_0 = 5;
			}
		}
	}

	internal void method_4(ChartType chartType_0)
	{
		switch (chartType_0)
		{
		case ChartType.Line:
		case ChartType.LineStacked:
		case ChartType.Line100PercentStacked:
		case ChartType.Radar:
		case ChartType.ScatterConnectedByCurvesWithoutDataMarker:
		case ChartType.ScatterConnectedByLinesWithoutDataMarker:
			MarkerStyle = ChartMarkerType.None;
			method_0();
			break;
		}
	}

	internal void Copy(Marker marker_0)
	{
		chartMarkerType_0 = marker_0.chartMarkerType_0;
		MarkerSize = marker_0.MarkerSize;
		if (marker_0.line_0 != null)
		{
			line_0 = new Line(class1632_0.Chart, this);
			line_0.Copy(marker_0.line_0);
		}
		if (marker_0.area_0 != null)
		{
			area_0 = new Area(class1632_0.Chart, this);
			area_0.Copy(marker_0.area_0);
		}
		if (marker_0.shapePropertyCollection_0 != null)
		{
			shapePropertyCollection_0 = new ShapePropertyCollection(class1632_0.Chart, this, Enum178.const_4);
			shapePropertyCollection_0.Copy(marker_0.shapePropertyCollection_0);
		}
	}

	private void method_5()
	{
		if (chartMarkerType_0 != 0)
		{
			return;
		}
		int num = 0;
		if (object_0 != null)
		{
			num = 0;
			num = 0;
			if (object_0 is Series)
			{
				num = 0;
				num = 0;
				num = ((Series)object_0).Index;
				switch (num % 9)
				{
				default:
					chartMarkerType_0 = ChartMarkerType.None;
					return;
				case 1:
					chartMarkerType_0 = ChartMarkerType.Square;
					return;
				case 2:
					chartMarkerType_0 = ChartMarkerType.Triangle;
					return;
				case 3:
					chartMarkerType_0 = ChartMarkerType.SquareX;
					return;
				case 4:
					chartMarkerType_0 = ChartMarkerType.SquareStar;
					return;
				case 5:
					chartMarkerType_0 = ChartMarkerType.Circle;
					return;
				case 6:
					chartMarkerType_0 = ChartMarkerType.SquarePlus;
					return;
				case 7:
					chartMarkerType_0 = ChartMarkerType.Dot;
					return;
				case 8:
					chartMarkerType_0 = ChartMarkerType.Dash;
					return;
				case 0:
					break;
				}
			}
			else
			{
				num = 0;
				num = 0;
				num = 0 % 9;
				num = 0 + 2;
				int num2 = 2;
			}
		}
		else
		{
			num = 0;
			num = 0;
			num = 0 % 9;
			num = 0 + 2;
			int num2 = 2;
		}
		chartMarkerType_0 = ChartMarkerType.Diamond;
	}
}
