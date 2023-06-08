using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells.Charts;
using ns21;
using ns7;

namespace Aspose.Cells.Drawing;

public class ShapePropertyCollection
{
	private Workbook workbook_0;

	internal object object_0;

	internal Enum178 enum178_0;

	private Class1113 class1113_0;

	private Class1295 class1295_0;

	private Class1288 class1288_0;

	private Format3D format3D_0;

	private ShadowEffect shadowEffect_0;

	public GlowEffect GlowEffect => method_5().GlowEffect;

	public Format3D Format3D
	{
		get
		{
			if (format3D_0 == null)
			{
				format3D_0 = new Format3D(this);
			}
			return format3D_0;
		}
	}

	public double SoftEdgeRadius
	{
		get
		{
			if (class1288_0 == null)
			{
				return 0.0;
			}
			return method_5().SoftEdgeRadius;
		}
		set
		{
			method_5().SoftEdgeRadius = value;
		}
	}

	public ShadowEffect ShadowEffect
	{
		get
		{
			if (shadowEffect_0 == null)
			{
				shadowEffect_0 = new ShadowEffect(this);
			}
			return shadowEffect_0;
		}
	}

	internal Workbook Workbook => workbook_0;

	internal Area Area
	{
		get
		{
			switch (enum178_0)
			{
			case Enum178.const_0:
				return ((Axis)object_0).Area;
			case Enum178.const_4:
				return ((Marker)object_0).Area;
			case Enum178.const_5:
				return ((ChartPoint)object_0).Area;
			default:
				return null;
			case Enum178.const_8:
				if (method_12((Series)object_0))
				{
					return null;
				}
				return ((Series)object_0).Area;
			case Enum178.const_9:
				return ((DropBars)object_0).Area;
			case Enum178.const_10:
				return (Area)object_0;
			case Enum178.const_11:
				return ((ChartFrame)object_0).Area;
			}
		}
	}

	internal Line Line => enum178_0 switch
	{
		Enum178.const_0 => ((Axis)object_0).AxisLine, 
		Enum178.const_1 => ((Axis)object_0).MajorGridLines, 
		Enum178.const_2 => ((Axis)object_0).MinorGridLines, 
		Enum178.const_3 => ((ChartDataTable)object_0).Border, 
		Enum178.const_4 => ((Marker)object_0).Border, 
		Enum178.const_5 => ((ChartPoint)object_0).Border, 
		Enum178.const_6 => (Line)object_0, 
		Enum178.const_7 => (Line)object_0, 
		Enum178.const_8 => ((Series)object_0).Border, 
		Enum178.const_9 => ((DropBars)object_0).Border, 
		Enum178.const_10 => ((Floor)object_0).Border, 
		Enum178.const_11 => ((ChartFrame)object_0).Border, 
		Enum178.const_12 => ((Class1387)object_0).SeriesLines, 
		Enum178.const_13 => ((Class1387)object_0).DropLines, 
		Enum178.const_14 => ((Class1387)object_0).HiLoLines, 
		Enum178.const_15 => ((Class1387)object_0).LeaderLines, 
		Enum178.const_16 => ((Series)object_0).LeaderLines, 
		_ => null, 
	};

	internal ShapePropertyCollection(Chart chart_0, object object_1, Enum178 enum178_1)
	{
		workbook_0 = chart_0.method_14().Workbook;
		object_0 = object_1;
		enum178_0 = enum178_1;
	}

	internal Class1113 method_0()
	{
		return class1113_0;
	}

	[SpecialName]
	internal Class1113 method_1()
	{
		if (class1113_0 == null)
		{
			class1113_0 = new Class1113(this);
		}
		return class1113_0;
	}

	internal Class1295 method_2()
	{
		return class1295_0;
	}

	[SpecialName]
	internal Class1295 method_3()
	{
		if (class1295_0 == null)
		{
			class1295_0 = new Class1295(this);
		}
		return class1295_0;
	}

	internal Class1288 method_4()
	{
		return class1288_0;
	}

	[SpecialName]
	internal Class1288 method_5()
	{
		if (class1288_0 == null)
		{
			class1288_0 = new Class1288(this);
		}
		return class1288_0;
	}

	internal void Copy(ShapePropertyCollection shapePropertyCollection_0)
	{
		if (shapePropertyCollection_0.class1288_0 != null)
		{
			class1288_0 = new Class1288(this);
			class1288_0.Copy(shapePropertyCollection_0.class1288_0);
		}
		if (shapePropertyCollection_0.class1113_0 != null)
		{
			class1113_0 = new Class1113(this);
			class1113_0.Copy(shapePropertyCollection_0.class1113_0);
		}
		if (shapePropertyCollection_0.class1295_0 != null)
		{
			class1295_0 = new Class1295(this);
			class1295_0.Copy(shapePropertyCollection_0.class1295_0);
		}
		if (shapePropertyCollection_0.method_11() != null)
		{
			Area?.Copy(shapePropertyCollection_0.method_11());
		}
		if (shapePropertyCollection_0.method_13() != null)
		{
			Line?.Copy(shapePropertyCollection_0.method_13());
		}
	}

	internal void method_6()
	{
		if (enum178_0 == Enum178.const_11)
		{
			((ChartFrame)object_0).Shadow = method_8();
		}
		else if (enum178_0 == Enum178.const_8)
		{
			((Series)object_0).Shadow = method_8();
		}
		else if (enum178_0 == Enum178.const_5)
		{
			((ChartPoint)object_0).Shadow = method_8();
		}
	}

	internal void method_7()
	{
		bool flag = false;
		bool flag2 = false;
		if (enum178_0 == Enum178.const_11)
		{
			flag = true;
			flag2 = ((ChartFrame)object_0).Shadow;
		}
		else if (enum178_0 == Enum178.const_8)
		{
			flag = true;
			flag2 = ((Series)object_0).Shadow;
		}
		else if (enum178_0 == Enum178.const_5)
		{
			flag = true;
			flag2 = ((ChartPoint)object_0).Shadow;
		}
		if (flag && method_8() != flag2)
		{
			method_9(flag2);
		}
	}

	[SpecialName]
	internal bool method_8()
	{
		if (class1288_0 != null && class1288_0.method_9() != null)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	internal void method_9(bool bool_0)
	{
		method_5().method_5();
		if (bool_0)
		{
			Class1291 @class = method_5().method_8();
			CellsColor cellsColor = new CellsColor(workbook_0);
			cellsColor.internalColor_0.SetColor(ColorType.RGB, Color.Black.ToArgb());
			@class.method_1(cellsColor);
			@class.int_1 = 2700000;
			@class.int_2 = 35921;
			@class.rectangleAlignmentType_0 = RectangleAlignmentType.BottomRight;
		}
	}

	internal void method_10()
	{
		method_1().method_5(PresetMaterialType.Flat);
	}

	internal Area method_11()
	{
		switch (enum178_0)
		{
		case Enum178.const_0:
			return ((Axis)object_0).method_2();
		case Enum178.const_4:
			return ((Marker)object_0).method_2();
		case Enum178.const_5:
			return ((ChartPoint)object_0).method_6();
		default:
			return null;
		case Enum178.const_8:
			if (method_12((Series)object_0))
			{
				return null;
			}
			return ((Series)object_0).method_5();
		case Enum178.const_9:
			return ((DropBars)object_0).method_1();
		case Enum178.const_10:
			return (Area)object_0;
		case Enum178.const_11:
			return ((ChartFrame)object_0).method_11();
		}
	}

	private bool method_12(Series series_0)
	{
		ChartType chartType = series_0.method_28().method_11();
		bool flag = ChartCollection.smethod_14(chartType) || ChartCollection.smethod_18(chartType);
		bool flag2 = ChartCollection.smethod_11(chartType);
		if ((!flag || chartType == ChartType.Line3D) && !flag2 && chartType != ChartType.Radar && chartType != ChartType.RadarWithDataMarkers)
		{
			return false;
		}
		return true;
	}

	internal Line method_13()
	{
		return enum178_0 switch
		{
			Enum178.const_0 => ((Axis)object_0).method_11(), 
			Enum178.const_1 => ((Axis)object_0).method_26(), 
			Enum178.const_2 => ((Axis)object_0).method_28(), 
			Enum178.const_3 => ((ChartDataTable)object_0).method_4(), 
			Enum178.const_4 => ((Marker)object_0).method_3(), 
			Enum178.const_5 => ((ChartPoint)object_0).method_5(), 
			Enum178.const_6 => (Line)object_0, 
			Enum178.const_7 => (Line)object_0, 
			Enum178.const_8 => ((Series)object_0).method_6(), 
			Enum178.const_9 => ((DropBars)object_0).method_0(), 
			Enum178.const_10 => ((Floor)object_0).Border, 
			Enum178.const_11 => ((ChartFrame)object_0).method_10(), 
			Enum178.const_12 => ((Class1387)object_0).method_27(), 
			Enum178.const_13 => ((Class1387)object_0).method_25(), 
			Enum178.const_14 => ((Class1387)object_0).method_26(), 
			Enum178.const_15 => ((Class1387)object_0).method_24(), 
			Enum178.const_16 => ((Series)object_0).method_37(), 
			_ => null, 
		};
	}

	public void ClearGlowEffect()
	{
		if (class1288_0 != null)
		{
			class1288_0.method_3(null);
		}
	}

	public bool HasGlowEffect()
	{
		if (class1288_0 != null && class1288_0.method_4() != null && class1288_0.method_4().method_0())
		{
			return true;
		}
		return false;
	}

	public bool HasFormat3D()
	{
		if (class1295_0 != null && class1113_0 != null)
		{
			return true;
		}
		return false;
	}

	public void ClearFormat3D()
	{
		class1295_0 = null;
		class1113_0 = null;
	}

	public void ClearShadowEffect()
	{
		if (class1288_0 != null)
		{
			class1288_0.method_5();
		}
	}

	public bool HasShadowEffect()
	{
		if (class1288_0 == null)
		{
			return false;
		}
		Class1291 @class = class1288_0.method_9();
		Class1289 class2 = class1288_0.method_7();
		if (@class == null && class2 == null)
		{
			return false;
		}
		return true;
	}
}
