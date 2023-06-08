using System;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns21;

namespace ns7;

internal class Class1387
{
	private Class1388 class1388_0;

	internal byte[] byte_0;

	private Class1632 class1632_0;

	private ChartType chartType_0;

	private bool bool_0;

	private bool bool_1;

	private Line line_0;

	private bool bool_2;

	private Line line_1;

	private bool bool_3;

	private Line line_2;

	private bool bool_4;

	private DropBars dropBars_0;

	private DropBars dropBars_1;

	private bool bool_5;

	private int int_0 = 150;

	private int int_1;

	private int int_2;

	private int int_3 = 75;

	private ChartSplitType chartSplitType_0;

	private bool bool_6 = true;

	private double double_0 = 1.0;

	private int int_4 = 100;

	private BubbleSizeRepresents bubbleSizeRepresents_0;

	private bool bool_7;

	private int int_5 = 50;

	private bool bool_8;

	private bool bool_9 = true;

	private bool bool_10 = true;

	private Line line_3;

	private ShapePropertyCollection shapePropertyCollection_0;

	private ShapePropertyCollection shapePropertyCollection_1;

	private ShapePropertyCollection shapePropertyCollection_2;

	private ShapePropertyCollection shapePropertyCollection_3;

	internal int Index
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < class1388_0.Count)
				{
					if (this == class1388_0[num])
					{
						break;
					}
					num++;
					continue;
				}
				throw new CellsException(ExceptionType.Chart, "The chart type is not in this chart");
			}
			return num;
		}
	}

	public bool PlotOnSecondAxis
	{
		get
		{
			return bool_0;
		}
		set
		{
			if (bool_0 != value)
			{
			}
			bool_0 = value;
		}
	}

	public bool HasHiLoLines
	{
		get
		{
			if (ChartCollection.smethod_14(chartType_0))
			{
				return bool_1;
			}
			return false;
		}
		set
		{
			if (ChartCollection.smethod_14(chartType_0))
			{
				bool_1 = value;
			}
		}
	}

	public Line HiLoLines
	{
		get
		{
			if (line_0 == null)
			{
				line_0 = new Line(class1388_0.Chart, this);
			}
			return line_0;
		}
	}

	public bool HasSeriesLines
	{
		get
		{
			switch (chartType_0)
			{
			default:
				return false;
			case ChartType.BarStacked:
			case ChartType.Bar100PercentStacked:
			case ChartType.ColumnStacked:
			case ChartType.Column100PercentStacked:
			case ChartType.PiePie:
			case ChartType.PieBar:
				return bool_2;
			}
		}
		set
		{
			switch (chartType_0)
			{
			case ChartType.BarStacked:
			case ChartType.Bar100PercentStacked:
			case ChartType.ColumnStacked:
			case ChartType.Column100PercentStacked:
			case ChartType.PiePie:
			case ChartType.PieBar:
				bool_2 = value;
				break;
			}
		}
	}

	public Line SeriesLines
	{
		get
		{
			if (line_1 == null)
			{
				return line_1 = new Line(class1388_0.Chart, this);
			}
			return line_1;
		}
	}

	public bool HasDropLines
	{
		get
		{
			if (!ChartCollection.smethod_14(chartType_0) && !ChartCollection.smethod_16(chartType_0))
			{
				return false;
			}
			return bool_3;
		}
		set
		{
			if (ChartCollection.smethod_14(chartType_0) || ChartCollection.smethod_16(chartType_0))
			{
				bool_3 = value;
			}
		}
	}

	public Line DropLines
	{
		get
		{
			if (line_2 == null)
			{
				return line_2 = new Line(class1388_0.Chart, this);
			}
			return line_2;
		}
	}

	public bool HasUpDownBars
	{
		get
		{
			if (!ChartCollection.smethod_14(chartType_0))
			{
				return false;
			}
			return bool_4;
		}
		set
		{
			if (ChartCollection.smethod_14(chartType_0))
			{
				bool_4 = value;
			}
		}
	}

	internal DropBars UpBars
	{
		get
		{
			if (dropBars_0 == null)
			{
				dropBars_0 = new DropBars(class1388_0.Chart);
			}
			return dropBars_0;
		}
	}

	public DropBars DownBars
	{
		get
		{
			if (dropBars_1 == null)
			{
				dropBars_1 = new DropBars(class1388_0.Chart);
			}
			return dropBars_1;
		}
	}

	public bool IsColorVaried
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public int GapWidth
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < 0 || value > 500)
			{
				throw new ArgumentException("First slice angle should be degree 0 to 500.");
			}
			int_0 = value;
		}
	}

	public int FirstSliceAngle
	{
		get
		{
			return int_1;
		}
		set
		{
			if (value < 0 || value > 360)
			{
				throw new ArgumentException("First slice angle should be degree 0 to 360.");
			}
			int_1 = value;
		}
	}

	public int Overlap
	{
		get
		{
			return int_2;
		}
		set
		{
			if (value < -100 || value > 100)
			{
				throw new CellsException(ExceptionType.Chart, "Invalid over lap: it must be between -100 and 100.");
			}
			int_2 = value;
		}
	}

	public int SecondPlotSize
	{
		get
		{
			return int_3;
		}
		set
		{
			if (value < 5 || value > 200)
			{
				throw new CellsException(ExceptionType.Chart, "Invalid size of the secondary section: it must be between 5 and 200.");
			}
			int_3 = value;
		}
	}

	public ChartSplitType SplitType
	{
		get
		{
			return chartSplitType_0;
		}
		set
		{
			chartSplitType_0 = value;
		}
	}

	public double SplitValue
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			bool_6 = false;
		}
	}

	internal bool IsAutoSplit => bool_6;

	public int BubbleScale
	{
		get
		{
			return int_4;
		}
		set
		{
			if (value < 0 || value > 300)
			{
				throw new ArgumentException("Invalid bubble scale : it must be between 0 and 300.");
			}
			int_4 = value;
		}
	}

	public BubbleSizeRepresents SizeRepresents
	{
		get
		{
			return bubbleSizeRepresents_0;
		}
		set
		{
			bubbleSizeRepresents_0 = value;
		}
	}

	public bool ShowNegativeBubbles
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	public int DoughnutHoleSize
	{
		get
		{
			return int_5;
		}
		set
		{
			switch (value)
			{
			default:
				throw new CellsException(ExceptionType.Chart, "Invalid hole size : it must be between 10 and 90");
			case 0:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
			case 26:
			case 27:
			case 28:
			case 29:
			case 30:
			case 31:
			case 32:
			case 33:
			case 34:
			case 35:
			case 36:
			case 37:
			case 38:
			case 39:
			case 40:
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 57:
			case 58:
			case 59:
			case 60:
			case 61:
			case 62:
			case 63:
			case 64:
			case 65:
			case 66:
			case 67:
			case 68:
			case 69:
			case 70:
			case 71:
			case 72:
			case 73:
			case 74:
			case 75:
			case 76:
			case 77:
			case 78:
			case 79:
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 89:
			case 90:
				int_5 = value;
				break;
			}
		}
	}

	public bool HasRadarAxisLabels
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
		}
	}

	internal bool HasLeaderLines
	{
		get
		{
			return bool_10;
		}
		set
		{
			bool_10 = value;
		}
	}

	internal Line LeaderLines
	{
		get
		{
			if (line_3 == null)
			{
				return line_3 = new Line(class1388_0.Chart, this);
			}
			return line_3;
		}
	}

	[SpecialName]
	internal Class1388 method_0()
	{
		return class1388_0;
	}

	internal Class1387(Class1388 class1388_1, ChartType chartType_1, bool bool_11)
	{
		class1388_0 = class1388_1;
		chartType_0 = chartType_1;
		bool_0 = bool_11;
		method_1();
	}

	internal void method_1()
	{
		method_2();
		method_6();
	}

	internal void method_2()
	{
		switch (chartType_0)
		{
		case ChartType.Doughnut:
		case ChartType.DoughnutExploded:
			bool_5 = true;
			break;
		case ChartType.Pie:
		case ChartType.Pie3D:
		case ChartType.PieExploded:
		case ChartType.Pie3DExploded:
			bool_5 = true;
			int_5 = 0;
			break;
		case ChartType.PiePie:
		case ChartType.PieBar:
			bool_2 = true;
			bool_5 = true;
			int_5 = 0;
			break;
		case ChartType.BarStacked:
		case ChartType.Bar100PercentStacked:
		case ChartType.Bar3DStacked:
		case ChartType.Bar3D100PercentStacked:
		case ChartType.ColumnStacked:
		case ChartType.Column100PercentStacked:
		case ChartType.Column3DStacked:
		case ChartType.Column3D100PercentStacked:
		case ChartType.ConeStacked:
		case ChartType.Cone100PercentStacked:
		case ChartType.ConicalBarStacked:
		case ChartType.ConicalBar100PercentStacked:
		case ChartType.CylinderStacked:
		case ChartType.Cylinder100PercentStacked:
		case ChartType.CylindricalBarStacked:
		case ChartType.CylindricalBar100PercentStacked:
		case ChartType.PyramidStacked:
		case ChartType.Pyramid100PercentStacked:
		case ChartType.PyramidBarStacked:
		case ChartType.PyramidBar100PercentStacked:
			int_2 = 100;
			break;
		case ChartType.Bar3DClustered:
		case ChartType.Bubble:
		case ChartType.Bubble3D:
		case ChartType.Column:
		case ChartType.Column3D:
		case ChartType.Column3DClustered:
		case ChartType.Cone:
		case ChartType.ConicalBar:
		case ChartType.ConicalColumn3D:
		case ChartType.Cylinder:
		case ChartType.CylindricalBar:
		case ChartType.CylindricalColumn3D:
		case ChartType.Line:
		case ChartType.LineStacked:
		case ChartType.Line100PercentStacked:
		case ChartType.LineWithDataMarkers:
		case ChartType.LineStackedWithDataMarkers:
		case ChartType.Line100PercentStackedWithDataMarkers:
		case ChartType.Line3D:
		case ChartType.Pyramid:
		case ChartType.PyramidBar:
			break;
		}
	}

	[SpecialName]
	internal Class1632 method_3()
	{
		return class1632_0;
	}

	[SpecialName]
	internal void method_4(Class1632 class1632_1)
	{
		class1632_0 = class1632_1;
	}

	internal Class1632 method_5()
	{
		return class1632_0;
	}

	private void method_6()
	{
		switch (chartType_0)
		{
		default:
			class1632_0 = null;
			break;
		case ChartType.Bubble3D:
		case ChartType.Cone:
		case ChartType.ConeStacked:
		case ChartType.Cone100PercentStacked:
		case ChartType.ConicalBar:
		case ChartType.ConicalBarStacked:
		case ChartType.ConicalBar100PercentStacked:
		case ChartType.ConicalColumn3D:
		case ChartType.Cylinder:
		case ChartType.CylinderStacked:
		case ChartType.Cylinder100PercentStacked:
		case ChartType.CylindricalBar:
		case ChartType.CylindricalBarStacked:
		case ChartType.CylindricalBar100PercentStacked:
		case ChartType.CylindricalColumn3D:
		case ChartType.DoughnutExploded:
		case ChartType.Line:
		case ChartType.LineStacked:
		case ChartType.Line100PercentStacked:
		case ChartType.Pie:
		case ChartType.PiePie:
		case ChartType.PieExploded:
		case ChartType.Pie3DExploded:
		case ChartType.PieBar:
		case ChartType.Pyramid:
		case ChartType.PyramidStacked:
		case ChartType.Pyramid100PercentStacked:
		case ChartType.PyramidBar:
		case ChartType.PyramidBarStacked:
		case ChartType.PyramidBar100PercentStacked:
		case ChartType.PyramidColumn3D:
		case ChartType.Radar:
		case ChartType.Scatter:
		case ChartType.ScatterConnectedByCurvesWithDataMarker:
		case ChartType.ScatterConnectedByCurvesWithoutDataMarker:
		case ChartType.ScatterConnectedByLinesWithoutDataMarker:
			class1632_0 = new Class1632(this);
			class1632_0.method_18();
			break;
		}
	}

	internal Class1387(Class1388 class1388_1)
	{
		class1388_0 = class1388_1;
	}

	internal void Copy(Class1387 class1387_0)
	{
		chartType_0 = class1387_0.chartType_0;
		bool_0 = class1387_0.bool_0;
		int_1 = class1387_0.int_1;
		int_0 = class1387_0.int_0;
		bool_5 = class1387_0.bool_5;
		int_2 = class1387_0.int_2;
		bool_0 = class1387_0.bool_0;
		int_5 = class1387_0.int_5;
		bool_8 = class1387_0.bool_8;
		bool_3 = class1387_0.bool_3;
		bool_9 = class1387_0.bool_9;
		bool_7 = class1387_0.bool_7;
		int_4 = class1387_0.int_4;
		bool_6 = class1387_0.bool_6;
		int_3 = class1387_0.int_3;
		bubbleSizeRepresents_0 = class1387_0.bubbleSizeRepresents_0;
		chartSplitType_0 = class1387_0.chartSplitType_0;
		double_0 = class1387_0.double_0;
		if (bool_3 && class1387_0.line_2 != null)
		{
			line_2 = new Line(class1388_0.Chart, this);
			line_2.Copy(class1387_0.line_2);
		}
		bool_1 = class1387_0.bool_1;
		if (bool_1 && class1387_0.line_0 != null)
		{
			line_0 = new Line(class1388_0.Chart, this);
			line_0.Copy(class1387_0.line_0);
		}
		bool_2 = class1387_0.bool_2;
		if (bool_2 && class1387_0.line_1 != null)
		{
			line_1 = new Line(class1388_0.Chart, this);
			line_1.Copy(class1387_0.line_1);
		}
		bool_10 = class1387_0.bool_10;
		if (bool_10 && class1387_0.line_3 != null)
		{
			line_3 = new Line(class1388_0.Chart, this);
			line_3.Copy(class1387_0.line_3);
		}
		bool_4 = class1387_0.bool_4;
		if (bool_4)
		{
			if (class1387_0.dropBars_0 != null)
			{
				dropBars_0 = new DropBars(class1388_0.Chart);
				dropBars_0.Copy(class1387_0.dropBars_0);
			}
			if (class1387_0.dropBars_1 != null)
			{
				dropBars_1 = new DropBars(class1388_0.Chart);
				dropBars_1.Copy(class1387_0.dropBars_1);
			}
		}
		if (class1387_0.class1632_0 != null)
		{
			if (class1632_0 == null)
			{
				class1632_0 = new Class1632(this);
			}
			class1632_0.Copy(class1387_0.class1632_0);
		}
		if (class1387_0.shapePropertyCollection_0 != null)
		{
			shapePropertyCollection_0 = new ShapePropertyCollection(class1388_0.Chart, this, Enum178.const_12);
			shapePropertyCollection_0.Copy(class1387_0.shapePropertyCollection_0);
		}
		if (class1387_0.shapePropertyCollection_1 != null)
		{
			shapePropertyCollection_1 = new ShapePropertyCollection(class1388_0.Chart, this, Enum178.const_13);
			shapePropertyCollection_1.Copy(class1387_0.shapePropertyCollection_1);
		}
		if (class1387_0.shapePropertyCollection_2 != null)
		{
			shapePropertyCollection_2 = new ShapePropertyCollection(class1388_0.Chart, this, Enum178.const_14);
			shapePropertyCollection_2.Copy(class1387_0.shapePropertyCollection_2);
		}
		if (class1387_0.shapePropertyCollection_3 != null)
		{
			shapePropertyCollection_3 = new ShapePropertyCollection(class1388_0.Chart, this, Enum178.const_15);
			shapePropertyCollection_3.Copy(class1387_0.shapePropertyCollection_3);
		}
	}

	internal Marker method_7()
	{
		if (class1632_0 == null)
		{
			return null;
		}
		return class1632_0.method_7();
	}

	internal Line method_8()
	{
		if (class1632_0 == null)
		{
			return null;
		}
		return class1632_0.method_4();
	}

	internal Area method_9()
	{
		if (class1632_0 == null)
		{
			return null;
		}
		return class1632_0.method_5();
	}

	internal Class1633 method_10()
	{
		if (class1632_0 == null)
		{
			return null;
		}
		return class1632_0.method_6();
	}

	[SpecialName]
	internal ChartType method_11()
	{
		return chartType_0;
	}

	[SpecialName]
	internal void method_12(ChartType chartType_1)
	{
		if (chartType_0 != chartType_1)
		{
			chartType_0 = chartType_1;
			method_1();
		}
	}

	internal void method_13(ChartType chartType_1)
	{
		chartType_0 = chartType_1;
	}

	[SpecialName]
	internal int method_14()
	{
		int num = 0;
		foreach (Series item in class1388_0.Chart.NSeries)
		{
			if (item.method_28() == this)
			{
				num++;
			}
		}
		return num;
	}

	internal void method_15(bool bool_11)
	{
		bool_1 = bool_11;
	}

	internal void method_16(bool bool_11)
	{
		bool_2 = bool_11;
	}

	internal void method_17(bool bool_11)
	{
		bool_3 = bool_11;
	}

	internal void method_18(bool bool_11)
	{
		bool_4 = bool_11;
	}

	internal DropBars method_19()
	{
		return dropBars_0;
	}

	internal DropBars method_20()
	{
		return dropBars_1;
	}

	[SpecialName]
	internal void method_21(bool bool_11)
	{
		bool_6 = bool_11;
	}

	[SpecialName]
	internal bool method_22()
	{
		return bool_8;
	}

	[SpecialName]
	internal void method_23(bool bool_11)
	{
		bool_8 = bool_11;
	}

	internal Line method_24()
	{
		return line_3;
	}

	internal Line method_25()
	{
		return line_2;
	}

	internal Line method_26()
	{
		return line_0;
	}

	internal Line method_27()
	{
		return line_1;
	}

	[SpecialName]
	internal ShapePropertyCollection method_28()
	{
		if (shapePropertyCollection_0 == null)
		{
			shapePropertyCollection_0 = new ShapePropertyCollection(class1388_0.Chart, this, Enum178.const_12);
		}
		return shapePropertyCollection_0;
	}

	[SpecialName]
	internal ShapePropertyCollection method_29()
	{
		if (shapePropertyCollection_1 == null)
		{
			shapePropertyCollection_1 = new ShapePropertyCollection(class1388_0.Chart, this, Enum178.const_13);
		}
		return shapePropertyCollection_1;
	}

	[SpecialName]
	internal ShapePropertyCollection method_30()
	{
		if (shapePropertyCollection_2 == null)
		{
			shapePropertyCollection_2 = new ShapePropertyCollection(class1388_0.Chart, this, Enum178.const_14);
		}
		return shapePropertyCollection_2;
	}

	[SpecialName]
	internal ShapePropertyCollection method_31()
	{
		if (shapePropertyCollection_3 == null)
		{
			shapePropertyCollection_3 = new ShapePropertyCollection(class1388_0.Chart, this, Enum178.const_15);
		}
		return shapePropertyCollection_3;
	}
}
