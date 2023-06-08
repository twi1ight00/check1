using System.Drawing;
using ns166;
using ns167;

namespace ns169;

internal class Class4808
{
	internal static bool smethod_0(Class4779 el1, Class4779 el2, Class4786 elements)
	{
		bool flag;
		if (flag = (flag = Class4778.smethod_36(el1, el2)) & Class4778.smethod_33(el1, el2))
		{
			Class4846 @class = elements.method_6(RectangleF.Union(el1.BoundingBox, el2.BoundingBox));
			flag &= !@class.method_0();
		}
		return flag;
	}
}
