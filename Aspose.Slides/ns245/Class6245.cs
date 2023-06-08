using System.Collections.Generic;
using System.Drawing;
using ns242;
using ns243;

namespace ns245;

internal class Class6245 : Class6242
{
	public Class6245(Class6238 docComposer)
		: base(docComposer)
	{
	}

	public override Class6225[] vmethod_0(float requiredHeight, Class6225 node)
	{
		List<Class6225> list = new List<Class6225>();
		Class6228 @class = (Class6228)node;
		bool flag = false;
		Class6228 class2 = (Class6228)@class.vmethod_14();
		if (class2.vmethod_8() < requiredHeight)
		{
			while (@class.Count > 0)
			{
				Class6225 class3 = @class.vmethod_4(0);
				PointF location = class3.Location;
				class2.vmethod_5(class3);
				if (class2.vmethod_8() < requiredHeight)
				{
					@class.RemoveAt(0);
					flag = true;
					continue;
				}
				class2.RemoveAt(class2.Count - 1);
				class3.Location = location;
				break;
			}
		}
		if (flag)
		{
			list.Add(class2);
		}
		list.Add(@class);
		return list.ToArray();
	}
}
