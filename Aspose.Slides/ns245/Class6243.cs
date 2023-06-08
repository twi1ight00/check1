using System.Collections.Generic;
using System.Drawing;
using ns242;
using ns243;

namespace ns245;

internal class Class6243 : Class6242
{
	public Class6243(Class6238 docComposer)
		: base(docComposer)
	{
	}

	public override Class6225[] vmethod_0(float requiredHeight, Class6225 node)
	{
		List<Class6225> list = new List<Class6225>();
		Class6230 @class = (Class6230)node;
		bool flag = false;
		Class6230 class2 = (Class6230)@class.vmethod_14();
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
				float num = requiredHeight - class2.vmethod_8();
				if (!(num <= 0f))
				{
					Class6242 class4 = class6238_0.vmethod_3(class3);
					Class6225[] array = class4.vmethod_0(num, class3);
					if (array.Length != 1)
					{
						class2.vmethod_5(array[0]);
						@class.RemoveAt(0);
						@class.vmethod_7(0, array[1]);
						flag = true;
					}
				}
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
