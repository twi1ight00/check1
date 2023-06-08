using System;
using System.Drawing;
using ns301;

namespace ns290;

internal class Class6931 : Class6927
{
	public override void imethod_0(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (!(box is Class6850 @class))
		{
			throw new ArgumentOutOfRangeException("box", "box should have LineBox type");
		}
		Interface349 @interface = new Class6937(@class);
		float num = 0f;
		for (int i = 0; i < @class.InnerBoxes.Count; i++)
		{
			Class6844 class2 = @class.InnerBoxes[i];
			float y = @interface.imethod_0(class2);
			class2.Location = new PointF(num, y);
			num += class2.OuterBound.Width;
		}
		SizeF sizeF = Class6971.Instance.method_1(box.Style.FontFamilyName, box.Style.FontSize, box.Style.FontStyle);
		@class.Size = new SizeF(@class.Size.Width, sizeF.Height);
		Interface354 interface2 = Class6927.smethod_0(this);
		interface2.imethod_1(@class);
	}
}
