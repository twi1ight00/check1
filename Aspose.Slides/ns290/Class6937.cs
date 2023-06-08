using System.Drawing;
using ns284;
using ns301;

namespace ns290;

internal class Class6937 : Interface349
{
	private readonly Class6845 class6845_0;

	private readonly Interface351 interface351_0;

	public Class6937(Class6845 container)
	{
		Class6892.smethod_0(container, "container");
		class6845_0 = container;
		interface351_0 = new Class6942();
		method_0(class6845_0);
	}

	public float imethod_0(Class6844 box)
	{
		Class6892.smethod_0(box, "box");
		return class6845_0.float_1 - smethod_0(box) - interface351_0.imethod_18(box);
	}

	private void method_0(Class6845 container)
	{
		Class6892.smethod_0(container, "container");
		if (container is Class6846)
		{
			if (!container.Style.Height.IsAuto)
			{
				container.Size = new SizeF(container.Size.Width, Class6969.smethod_10(container.Style.Height));
			}
			container.float_0 = (container.float_1 = container.Size.Height + interface351_0.imethod_17(container));
			return;
		}
		SizeF sizeF = Class6971.Instance.method_1(container.Style.FontFamilyName, container.Style.FontSize, container.Style.FontStyle);
		if (container != null && container.Tag == "IMG" && container.Style.Display == Enum952.const_0)
		{
			container.Size = new SizeF(container.Size.Width, container.Size.Height);
		}
		else
		{
			container.Size = new SizeF(container.Size.Width, sizeF.Height);
		}
		container.float_0 = (container.float_1 = Class6971.smethod_1(container.Style.FontFamilyName, container.Style.FontSize, container.Style.FontStyle));
		container.float_2 = Class6971.smethod_2(container.Style.FontFamilyName, container.Style.FontSize, container.Style.FontStyle);
	}

	private static float smethod_0(Class6844 box)
	{
		float result = 0f;
		switch (box.Style.TextVAlign)
		{
		case Enum958.const_2:
			result = box.Size.Height / 2f;
			break;
		case Enum958.const_4:
			result = box.float_1 - box.float_2 / 2f;
			break;
		case Enum958.const_5:
			result = box.float_1 + box.float_2 / 2f;
			break;
		case Enum958.const_0:
		case Enum958.const_1:
		case Enum958.const_3:
		case Enum958.const_6:
		case Enum958.const_7:
			result = box.float_1;
			break;
		}
		return result;
	}
}
