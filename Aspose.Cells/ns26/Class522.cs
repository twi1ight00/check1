using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;

namespace ns26;

internal class Class522
{
	private string string_0;

	private ChartType chartType_0;

	private string string_1;

	private Color color_0 = default(Color);

	private Color color_1 = default(Color);

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private string string_2;

	private ChartMarkerType chartMarkerType_0 = ChartMarkerType.None;

	private double double_0;

	private string string_3;

	private string string_4;

	private MsoLineDashStyle msoLineDashStyle_0 = MsoLineDashStyle.Solid;

	private string string_5;

	private WorksheetCollection worksheetCollection_0;

	private Aspose.Cells.Font font_0;

	private bool bool_3;

	private bool bool_4 = true;

	private Bar3DShapeType bar3DShapeType_0;

	private int int_0;

	private bool bool_5;

	private double double_1;

	private LabelPositionType labelPositionType_0 = LabelPositionType.BestFit;

	private string string_6;

	private bool bool_6;

	private bool bool_7;

	private DataLablesSeparatorType dataLablesSeparatorType_0;

	private TickLabelPositionType tickLabelPositionType_0;

	internal bool IsHorizontal
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	internal string RotationAngle
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	internal string Fill => string_1;

	internal Aspose.Cells.Font Font
	{
		get
		{
			if (font_0 == null)
			{
				font_0 = new Aspose.Cells.Font(worksheetCollection_0, 1);
			}
			return font_0;
		}
	}

	internal bool Is3D => bool_3;

	[SpecialName]
	internal string method_0()
	{
		return string_0;
	}

	[SpecialName]
	internal void method_1(string string_7)
	{
		string_0 = string_7;
	}

	[SpecialName]
	internal ChartType method_2()
	{
		return chartType_0;
	}

	[SpecialName]
	internal Color method_3()
	{
		return color_0;
	}

	[SpecialName]
	internal void method_4(Color color_2)
	{
		color_0 = color_2;
	}

	[SpecialName]
	internal Color method_5()
	{
		return color_1;
	}

	[SpecialName]
	internal void method_6(Color color_2)
	{
		color_1 = color_2;
	}

	[SpecialName]
	internal bool method_7()
	{
		return bool_1;
	}

	[SpecialName]
	internal void method_8(bool bool_8)
	{
		bool_1 = bool_8;
	}

	[SpecialName]
	internal bool method_9()
	{
		return bool_2;
	}

	[SpecialName]
	internal void method_10(bool bool_8)
	{
		bool_2 = bool_8;
	}

	[SpecialName]
	internal string method_11()
	{
		return string_2;
	}

	[SpecialName]
	internal void method_12(string string_7)
	{
		string_2 = string_7;
	}

	[SpecialName]
	internal ChartMarkerType method_13()
	{
		return chartMarkerType_0;
	}

	[SpecialName]
	internal void method_14(ChartMarkerType chartMarkerType_1)
	{
		chartMarkerType_0 = chartMarkerType_1;
	}

	[SpecialName]
	internal string method_15()
	{
		return string_4;
	}

	[SpecialName]
	internal void method_16(string string_7)
	{
		string_4 = string_7;
	}

	[SpecialName]
	internal void method_17(string string_7)
	{
		string_1 = string_7;
	}

	[SpecialName]
	internal MsoLineDashStyle method_18()
	{
		return msoLineDashStyle_0;
	}

	[SpecialName]
	internal void method_19(MsoLineDashStyle msoLineDashStyle_1)
	{
		msoLineDashStyle_0 = msoLineDashStyle_1;
	}

	[SpecialName]
	internal string method_20()
	{
		return string_5;
	}

	[SpecialName]
	internal void method_21(string string_7)
	{
		string_5 = string_7;
	}

	[SpecialName]
	internal void method_22(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
	}

	[SpecialName]
	internal void method_23(bool bool_8)
	{
		bool_3 = bool_8;
	}

	[SpecialName]
	internal bool method_24()
	{
		return bool_4;
	}

	[SpecialName]
	internal void method_25(bool bool_8)
	{
		bool_4 = bool_8;
	}

	[SpecialName]
	internal Bar3DShapeType method_26()
	{
		return bar3DShapeType_0;
	}

	[SpecialName]
	internal void method_27(Bar3DShapeType bar3DShapeType_1)
	{
		bar3DShapeType_0 = bar3DShapeType_1;
	}

	[SpecialName]
	internal int method_28()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_29(int int_1)
	{
		int_0 = int_1;
	}

	[SpecialName]
	internal bool method_30()
	{
		return bool_5;
	}

	[SpecialName]
	internal void method_31(bool bool_8)
	{
		bool_5 = bool_8;
	}

	[SpecialName]
	internal double method_32()
	{
		return double_0;
	}

	[SpecialName]
	internal void method_33(double double_2)
	{
		double_0 = double_2;
	}

	[SpecialName]
	internal double method_34()
	{
		return double_1;
	}

	[SpecialName]
	internal void method_35(double double_2)
	{
		double_1 = double_2;
	}

	[SpecialName]
	internal LabelPositionType method_36()
	{
		return labelPositionType_0;
	}

	[SpecialName]
	internal void method_37(LabelPositionType labelPositionType_1)
	{
		labelPositionType_0 = labelPositionType_1;
	}

	[SpecialName]
	internal string method_38()
	{
		return string_6;
	}

	[SpecialName]
	internal void method_39(string string_7)
	{
		string_6 = string_7;
	}

	[SpecialName]
	internal bool method_40()
	{
		return bool_6;
	}

	[SpecialName]
	internal void method_41(bool bool_8)
	{
		bool_6 = bool_8;
	}

	[SpecialName]
	internal bool method_42()
	{
		return bool_7;
	}

	[SpecialName]
	internal void method_43(bool bool_8)
	{
		bool_7 = bool_8;
	}

	[SpecialName]
	internal DataLablesSeparatorType method_44()
	{
		return dataLablesSeparatorType_0;
	}

	[SpecialName]
	internal void method_45(DataLablesSeparatorType dataLablesSeparatorType_1)
	{
		dataLablesSeparatorType_0 = dataLablesSeparatorType_1;
	}

	[SpecialName]
	internal TickLabelPositionType method_46()
	{
		return tickLabelPositionType_0;
	}

	[SpecialName]
	internal void method_47(TickLabelPositionType tickLabelPositionType_1)
	{
		tickLabelPositionType_0 = tickLabelPositionType_1;
	}
}
