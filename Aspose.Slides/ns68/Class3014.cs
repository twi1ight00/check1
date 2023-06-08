using System.Drawing;

namespace ns68;

internal sealed class Class3014
{
	private Class3013 class3013_0;

	private Class3011 class3011_0;

	private Point point_0;

	private bool bool_0;

	private int int_0;

	private double double_0;

	internal Class3013 Cell => class3013_0;

	internal Class3011 CellVertices => class3011_0;

	internal Point StartFillPoint
	{
		get
		{
			return point_0;
		}
		set
		{
			point_0 = value;
		}
	}

	internal bool FlagToRefillBecauseOfBlameBorderChained
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

	internal int BDegreesType
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal double BDegrees
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public Class3014()
	{
		class3013_0 = new Class3013();
		class3011_0 = new Class3011();
		bool_0 = false;
		int_0 = 0;
	}

	internal void method_0(Class3007 cellVertexRaw1)
	{
		Class3010 @class = new Class3010();
		@class.class3007_0 = cellVertexRaw1;
		CellVertices.Add(@class);
	}
}
