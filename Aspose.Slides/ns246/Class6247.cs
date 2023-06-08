using System.Collections.Generic;
using System.Drawing;
using ns224;
using ns235;

namespace ns246;

internal class Class6247
{
	public Class5998 class5998_0;

	public float float_0;

	public Class6247(Class5998 color, float width)
	{
		class5998_0 = color;
		float_0 = width;
	}

	public Class6204[] method_0(PointF start, PointF end)
	{
		List<Class6204> list = new List<Class6204>();
		Class6217 @class = Class6217.smethod_3(start, end);
		@class.Pen = new Class6003(class5998_0);
		@class.Pen.Width = float_0;
		Class6215 class2 = new Class6215();
		class2.Add(@class);
		list.Add(class2);
		return list.ToArray();
	}
}
