using System;
using System.Drawing;
using ns301;

namespace ns290;

internal class Class6947 : Interface354
{
	public void imethod_0(Class6845 container)
	{
		throw new NotImplementedException();
	}

	public void imethod_1(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (!(box is Class6845 @class))
		{
			return;
		}
		float width = 0f;
		if (@class.Style.Width.IsAuto)
		{
			if (@class.InnerBoxes.Count > 0)
			{
				Class6844 class2 = @class.InnerBoxes[@class.InnerBoxes.Count - 1];
				width = class2.Location.X + class2.OuterBound.Width;
			}
		}
		else
		{
			width = Class6969.smethod_9(@class.Style.Width, 1000f);
		}
		@class.Size = new SizeF(width, @class.Size.Height);
	}

	public void imethod_2(Class6844 box, SizeF size)
	{
		Class6892.smethod_0(box, "box");
		Interface351 @interface = new Class6942();
		float width = ((!box.Style.Width.IsAuto) ? Class6969.smethod_9(box.Style.Width, size.Width) : (size.Width - @interface.imethod_15(box) - @interface.imethod_16(box)));
		box.Size = new SizeF(width, box.Size.Height);
	}

	public void imethod_3(Class6844 box)
	{
	}
}
