using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns11;

internal class Class167
{
	private readonly List<PointF> list_0;

	private readonly List<PathPointType> list_1;

	private bool bool_0;

	internal bool Closed
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

	internal Class167()
	{
		list_0 = new List<PointF>();
		list_1 = new List<PathPointType>();
	}

	internal PathPointType[] method_0()
	{
		return list_1.ToArray();
	}

	internal PointF[] method_1()
	{
		return list_0.ToArray();
	}

	internal void Add(PointF point, PathPointType drawType)
	{
		list_0.Add(point);
		list_1.Add(drawType);
	}
}
