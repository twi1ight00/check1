using System.Collections.Generic;
using System.Drawing;
using ns224;
using ns235;
using ns243;

namespace ns246;

internal class Class6248
{
	private Class6247[] class6247_0;

	private Class5998 class5998_0;

	private float float_0;

	public Class5998 ForeColor => class5998_0;

	public float Width => float_0;

	public Class6248()
	{
		class6247_0 = new Class6247[4];
		class5998_0 = Class5998.class5998_7;
		float_0 = 1f;
		for (int i = 0; i < 4; i++)
		{
			class6247_0[i] = new Class6247(ForeColor, Width);
		}
	}

	public Class6248(Class5998 color, float width)
	{
		class6247_0 = new Class6247[4];
		class5998_0 = color;
		float_0 = width;
		for (int i = 0; i < 4; i++)
		{
			class6247_0[i] = new Class6247(ForeColor, Width);
		}
	}

	public void method_0(Enum796 style, Class5998 color, float width)
	{
		Class6247 @class = new Class6247(color, width);
		class6247_0[(int)style] = @class;
	}

	public Class6204[] method_1(Class6225 owner)
	{
		List<Class6204> list = new List<Class6204>();
		RectangleF rectangleF = new RectangleF(owner.Location, owner.Size);
		if (class6247_0[0] != null)
		{
			list.AddRange(class6247_0[0].method_0(new PointF(rectangleF.Left, rectangleF.Bottom), new PointF(rectangleF.Left, rectangleF.Top)));
		}
		if (class6247_0[1] != null)
		{
			list.AddRange(class6247_0[1].method_0(new PointF(rectangleF.Left, rectangleF.Top), new PointF(rectangleF.Right, rectangleF.Top)));
		}
		if (class6247_0[2] != null)
		{
			list.AddRange(class6247_0[2].method_0(new PointF(rectangleF.Right, rectangleF.Top), new PointF(rectangleF.Right, rectangleF.Bottom)));
		}
		if (class6247_0[3] != null)
		{
			list.AddRange(class6247_0[3].method_0(new PointF(rectangleF.Right, rectangleF.Bottom), new PointF(rectangleF.Left, rectangleF.Bottom)));
		}
		return list.ToArray();
	}
}
