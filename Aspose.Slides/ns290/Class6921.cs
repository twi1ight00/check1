using System.Collections;
using System.Drawing;
using ns301;

namespace ns290;

internal class Class6921
{
	private readonly Interface351 interface351_0;

	private float float_0;

	private readonly Class6922 class6922_0;

	public Class6921(Interface351 boxInfo)
	{
		Class6892.smethod_0(boxInfo, "boxInfo");
		interface351_0 = boxInfo;
		class6922_0 = new Class6922(boxInfo);
	}

	public Class6844 method_0(Class6844 box, Class6845 container)
	{
		Class6892.smethod_0(container, "container");
		Class6892.smethod_0(box, "box");
		switch (interface351_0.imethod_8(box, container))
		{
		default:
			return null;
		case Enum945.const_0:
		case Enum945.const_1:
			method_2(box, container);
			return null;
		case Enum945.const_2:
		case Enum945.const_3:
			if (interface351_0.imethod_14(box))
			{
				Class6845 @class = container;
				Class6845 class2 = container;
				Enum946 @enum = interface351_0.imethod_1(@class);
				while (@enum != Enum946.const_1 && @class.Parent != null)
				{
					class2 = @class;
					@class = @class.Parent as Class6845;
					@enum = interface351_0.imethod_1(@class);
				}
				if (class2.InnerBoxes.Count == 0)
				{
					method_2(box, container);
					return null;
				}
			}
			return method_1(box, container);
		}
	}

	private Class6844 method_1(Class6844 box, Class6845 parentContainer)
	{
		if (!(box is Class6845 @class))
		{
			return box;
		}
		float width = interface351_0.imethod_9(parentContainer);
		IList list = class6922_0.imethod_0(@class, width);
		Class6845 class2 = (Class6845)list[0];
		Class6845 class3 = (Class6845)list[1];
		Class6844 class4 = null;
		bool flag = false;
		float num = float_0;
		for (int i = 0; i < @class.InnerBoxes.Count; i++)
		{
			Class6844 class5 = @class.InnerBoxes[i];
			if (!flag)
			{
				Class6844 class6 = method_0(class5, class2);
				if (class6 != null)
				{
					float_0 = class6.Location.X;
					flag = true;
					method_2(class6, class3);
					class4 = class3;
				}
			}
			else
			{
				method_2(class5, class3);
			}
		}
		if (class4 is Class6845 class7 && class7.InnerBoxes.Count > 0 && class4 != null)
		{
			Class6844 class8 = class7.InnerBoxes[class7.InnerBoxes.Count - 1];
			float width2 = class8.Location.X + class8.OuterBound.Width;
			class4.Size = new SizeF(width2, class4.Size.Height);
			class4.Location = new PointF(class4.Location.X + float_0, class4.Location.Y);
		}
		float_0 = num;
		if (class2 != null && class2.InnerBoxes.Count > 0)
		{
			method_2(class2, parentContainer);
		}
		return class4;
	}

	private void method_2(Class6844 innerBox, Class6845 container)
	{
		container.InnerBoxes.Add(innerBox);
		innerBox.Location = new PointF(innerBox.Location.X - float_0, innerBox.Location.Y);
		innerBox.Parent = container;
	}
}
