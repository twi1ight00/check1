using System.Drawing;
using ns284;
using ns301;

namespace ns290;

internal class Class6946 : Interface354
{
	public void imethod_0(Class6845 container)
	{
		Class6892.smethod_0(container, "container");
		float height = 0f;
		if (container.Style.Height.IsAuto)
		{
			if (container.InnerBoxes.Count > 0)
			{
				Class6844 @class = container.InnerBoxes[container.InnerBoxes.Count - 1];
				height = @class.Location.Y + @class.OuterBound.Height;
			}
		}
		else
		{
			height = Class6969.smethod_9(container.Style.Height, 1000f);
		}
		container.Size = new SizeF(container.Size.Width, height);
	}

	public void imethod_1(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		if (box.Parent == null)
		{
			return;
		}
		Interface351 @interface = new Class6942();
		float width;
		if (box.Style.Width.IsAuto)
		{
			if (box.Style.Position == Enum956.const_1)
			{
				return;
			}
			width = box.Parent.InnerBound.Width - @interface.imethod_15(box) - @interface.imethod_16(box);
		}
		else
		{
			width = Class6969.smethod_9(box.Style.Width, box.Parent.InnerBound.Width);
		}
		box.Size = new SizeF(width, box.Size.Height);
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
		Class6892.smethod_0(box, "box");
		if (!(box is Class6845 @class))
		{
			return;
		}
		Class6942 class2 = new Class6942();
		switch (class2.imethod_0(@class))
		{
		case Enum946.const_0:
		{
			for (int j = 0; j < @class.InnerBoxes.Count; j++)
			{
				Class6850 class4 = (Class6850)@class.InnerBoxes[j];
				if (@class.MinWidth < class4.MinWidth)
				{
					@class.MinWidth = class4.MinWidth;
				}
				if (@class.MaxWidth < class4.OuterBound.Width)
				{
					@class.MaxWidth = class4.OuterBound.Width;
				}
			}
			break;
		}
		case Enum946.const_1:
		{
			for (int i = 0; i < @class.InnerBoxes.Count; i++)
			{
				if (@class.InnerBoxes[i] is Class6845)
				{
					Class6845 class3 = @class.InnerBoxes[i] as Class6845;
					if (@class.MinWidth < class3.MinWidth)
					{
						@class.MinWidth = class3.MinWidth;
					}
					if (@class.MaxWidth < class3.MaxWidth)
					{
						@class.MaxWidth = class3.MaxWidth;
					}
				}
			}
			break;
		}
		}
	}
}
