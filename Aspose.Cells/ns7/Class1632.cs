using System.Runtime.CompilerServices;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;

namespace ns7;

internal class Class1632
{
	internal byte[] byte_0;

	private Area area_0;

	private Line line_0;

	private Marker marker_0;

	private Class1633 class1633_0;

	private bool bool_0;

	private bool bool_1;

	internal bool bool_2;

	private object object_0;

	private bool bool_3 = true;

	internal bool bool_4;

	private Bar3DShapeType bar3DShapeType_0;

	internal ushort ushort_0;

	private bool bool_5;

	internal bool IsAuto
	{
		get
		{
			if (bool_3)
			{
				return true;
			}
			return false;
		}
	}

	internal ChartType Type
	{
		get
		{
			if (object_0 is Series)
			{
				return ((Series)object_0).Type;
			}
			if (object_0 is Class1387)
			{
				return ((Class1387)object_0).method_11();
			}
			return ChartType.Column;
		}
	}

	public Bar3DShapeType BarShape
	{
		get
		{
			if (!bool_4)
			{
				switch (Type)
				{
				case ChartType.Bar3DClustered:
				case ChartType.Bar3DStacked:
				case ChartType.Bar3D100PercentStacked:
				case ChartType.Column3D:
				case ChartType.Column3DClustered:
				case ChartType.Column3DStacked:
				case ChartType.Column3D100PercentStacked:
					return Bar3DShapeType.Box;
				case ChartType.Cone:
				case ChartType.ConeStacked:
				case ChartType.Cone100PercentStacked:
				case ChartType.ConicalBar:
				case ChartType.ConicalBarStacked:
				case ChartType.ConicalBar100PercentStacked:
				case ChartType.ConicalColumn3D:
					return Bar3DShapeType.ConeToPoint;
				case ChartType.Cylinder:
				case ChartType.CylinderStacked:
				case ChartType.Cylinder100PercentStacked:
				case ChartType.CylindricalBar:
				case ChartType.CylindricalBarStacked:
				case ChartType.CylindricalBar100PercentStacked:
				case ChartType.CylindricalColumn3D:
					return Bar3DShapeType.Cylinder;
				default:
					return bar3DShapeType_0;
				case ChartType.Pyramid:
				case ChartType.PyramidStacked:
				case ChartType.Pyramid100PercentStacked:
				case ChartType.PyramidBar:
				case ChartType.PyramidBarStacked:
				case ChartType.PyramidBar100PercentStacked:
				case ChartType.PyramidColumn3D:
					return Bar3DShapeType.PyramidToPoint;
				}
			}
			return bar3DShapeType_0;
		}
		set
		{
			if (ChartCollection.smethod_10(Type))
			{
				bool_4 = true;
				bar3DShapeType_0 = value;
			}
		}
	}

	internal Area Area
	{
		get
		{
			method_15();
			return area_0;
		}
	}

	internal Line Border
	{
		get
		{
			method_16();
			return line_0;
		}
	}

	internal Marker Marker
	{
		get
		{
			method_17();
			return marker_0;
		}
	}

	internal bool Smooth
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			ushort_0 |= 2;
			method_1(bool_6: false);
		}
	}

	internal bool Shadow
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
			method_1(bool_6: false);
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

	internal Class1632(object object_1)
	{
		object_0 = object_1;
	}

	internal void method_0(object object_1)
	{
		bool_3 = false;
	}

	internal void method_1(bool bool_6)
	{
		bool_3 = bool_6;
	}

	internal void method_2(Bar3DShapeType bar3DShapeType_1)
	{
		bool_4 = true;
		bar3DShapeType_0 = bar3DShapeType_1;
	}

	internal Bar3DShapeType method_3()
	{
		return bar3DShapeType_0;
	}

	internal void Copy(Class1632 class1632_0)
	{
		ushort_0 = class1632_0.ushort_0;
		bool_1 = class1632_0.bool_1;
		bool_0 = class1632_0.bool_0;
		bool_5 = class1632_0.bool_5;
		bar3DShapeType_0 = class1632_0.bar3DShapeType_0;
		bool_4 = class1632_0.bool_4;
		bool_3 = class1632_0.bool_3;
		if (class1632_0.area_0 != null)
		{
			method_15();
			area_0.Copy(class1632_0.area_0);
		}
		if (class1632_0.line_0 != null)
		{
			method_16();
			line_0.Copy(class1632_0.line_0);
		}
		if (class1632_0.marker_0 != null)
		{
			method_17();
			marker_0.Copy(class1632_0.marker_0);
		}
		if (class1632_0.class1633_0 != null)
		{
			class1633_0 = new Class1633(this);
			class1633_0.Copy(class1632_0.class1633_0);
		}
	}

	internal Line method_4()
	{
		return line_0;
	}

	internal Area method_5()
	{
		return area_0;
	}

	internal Class1633 method_6()
	{
		return class1633_0;
	}

	internal Marker method_7()
	{
		return marker_0;
	}

	[SpecialName]
	internal Class1633 method_8()
	{
		if (class1633_0 == null)
		{
			class1633_0 = new Class1633(this);
		}
		return class1633_0;
	}

	[SpecialName]
	internal bool method_9()
	{
		return (ushort_0 & 2) != 0;
	}

	[SpecialName]
	internal void method_10(bool bool_6)
	{
		if (bool_6)
		{
			ushort_0 |= 2;
		}
		else
		{
			ushort_0 |= 65533;
		}
	}

	[SpecialName]
	internal bool method_11()
	{
		return bool_1;
	}

	[SpecialName]
	internal void method_12(bool bool_6)
	{
		bool_1 = bool_6;
		ushort_0 |= 1;
		method_1(bool_6: false);
	}

	[SpecialName]
	internal bool method_13()
	{
		return (ushort_0 & 1) != 0;
	}

	[SpecialName]
	internal void method_14(bool bool_6)
	{
		if (bool_6)
		{
			ushort_0 |= 1;
		}
		else
		{
			ushort_0 |= 65534;
		}
	}

	private void method_15()
	{
		if (area_0 != null)
		{
			return;
		}
		area_0 = new Area(Chart, this);
		if (object_0 == null || !(object_0 is Series))
		{
			return;
		}
		Series series = (Series)object_0;
		Class1387 @class = series.method_28();
		if (@class != null && @class.method_3() != null)
		{
			Area area = @class.method_3().method_5();
			if (area != null)
			{
				area_0.Copy(area);
			}
		}
	}

	private void method_16()
	{
		if (line_0 != null)
		{
			return;
		}
		line_0 = new Line(Chart, this);
		if (object_0 == null || !(object_0 is Series))
		{
			return;
		}
		Series series = (Series)object_0;
		Class1387 @class = series.method_28();
		if (@class != null && @class.method_3() != null)
		{
			Line line = @class.method_3().method_4();
			if (line != null)
			{
				line_0.Copy(line);
			}
		}
	}

	private void method_17()
	{
		if (marker_0 != null)
		{
			return;
		}
		marker_0 = new Marker(object_0, this);
		if (object_0 == null || !(object_0 is Series))
		{
			return;
		}
		Series series = (Series)object_0;
		Class1387 @class = series.method_28();
		if (@class != null && @class.method_3() != null)
		{
			Marker marker = @class.method_3().method_7();
			if (marker != null)
			{
				marker_0.Copy(marker);
			}
		}
	}

	internal void method_18()
	{
		switch (Type)
		{
		case ChartType.Scatter:
			Border.IsVisible = false;
			Marker.method_4(Type);
			break;
		case ChartType.ScatterConnectedByCurvesWithDataMarker:
		case ChartType.ScatterConnectedByCurvesWithoutDataMarker:
			bool_0 = true;
			method_10(bool_6: true);
			method_16();
			Marker.method_4(Type);
			break;
		case ChartType.ScatterConnectedByLinesWithoutDataMarker:
			method_16();
			Marker.method_4(Type);
			break;
		case ChartType.Line:
		case ChartType.LineStacked:
		case ChartType.Line100PercentStacked:
		case ChartType.Radar:
			Marker.method_4(Type);
			break;
		case ChartType.Pie:
			class1633_0 = new Class1633(this);
			class1633_0.method_1(0);
			break;
		case ChartType.Doughnut:
		case ChartType.DoughnutExploded:
		case ChartType.PieExploded:
		case ChartType.Pie3DExploded:
			class1633_0 = new Class1633(this);
			break;
		case ChartType.Bubble:
			method_16();
			Marker.method_4(Type);
			break;
		case ChartType.Bubble3D:
			bool_1 = true;
			method_14(bool_6: true);
			method_16();
			method_15();
			Marker.method_4(Type);
			break;
		}
	}
}
