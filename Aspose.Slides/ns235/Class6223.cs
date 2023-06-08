using System.Collections.Generic;
using System.Drawing;
using ns224;

namespace ns235;

internal class Class6223 : Class6204, Interface262, Interface263
{
	private readonly Class5998 class5998_0 = Class5998.class5998_7;

	private readonly List<PointF> list_0 = new List<PointF>();

	public List<PointF> Points => list_0;

	public Class5998 LineColor => class5998_0;

	public Class6223()
	{
	}

	public Class6223(Class5998 color)
	{
		class5998_0 = color;
	}

	public Class6223(PointF startPoint, PointF endPoint)
	{
		list_0.Add(startPoint);
		list_0.Add(endPoint);
	}

	public Class6223(PointF startPoint, PointF endPoint, Class5998 color)
		: this(startPoint, endPoint)
	{
		class5998_0 = color;
	}

	public Class6223(float[] coords)
	{
		int num = coords.Length / 2;
		for (int i = 0; i < num; i++)
		{
			list_0.Add(new PointF(coords[i * 2], coords[i * 2 + 1]));
		}
	}

	public Class6223(float[] coords, Class5998 color)
		: this(coords)
	{
		class5998_0 = color;
	}

	public Class6223(PointF[] points)
	{
		foreach (PointF item in points)
		{
			list_0.Add(item);
		}
	}

	public Class6223(PointF[] points, Class5998 color)
		: this(points)
	{
		class5998_0 = color;
	}

	public override void vmethod_0(Class6176 visitor)
	{
		visitor.vmethod_9(this);
	}

	public void imethod_0(Class6002 matrix)
	{
		PointF[] array = new PointF[list_0.Count];
		for (int i = 0; i < list_0.Count; i++)
		{
			ref PointF reference = ref array[i];
			reference = list_0[i];
		}
		matrix.method_3(array);
		for (int j = 0; j < array.Length; j++)
		{
			list_0[j] = array[j];
		}
	}

	public Class6204 Clone()
	{
		Class6223 @class = new Class6223(class5998_0);
		for (int i = 0; i < list_0.Count; i++)
		{
			PointF pointF = list_0[i];
			@class.list_0.Add(new PointF(pointF.X, pointF.Y));
		}
		return @class;
	}
}
