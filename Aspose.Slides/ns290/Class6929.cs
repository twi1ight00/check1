using System;
using System.Drawing;
using ns301;

namespace ns290;

internal class Class6929 : Class6927
{
	public override void imethod_0(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (!(box is Class6845 @class))
		{
			throw new ArgumentOutOfRangeException("box", "box should have ContainerBox type");
		}
		float num = 0f;
		Interface349 @interface = new Class6937(@class);
		for (int i = 0; i < @class.InnerBoxes.Count; i++)
		{
			Class6844 class2 = @class.InnerBoxes[i];
			float y = @interface.imethod_0(class2);
			class2.Location = new PointF(num, y);
			if (!method_0(class2))
			{
				method_1(class2, @class);
				@class.InnerBoxes.RemoveAt(i);
				i--;
			}
			else
			{
				num += class2.OuterBound.Width;
			}
		}
		Interface354 interface2 = Class6927.smethod_0(this);
		interface2.imethod_1(@class);
	}
}
