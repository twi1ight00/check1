using System.Collections.Generic;
using ns284;
using ns301;

namespace ns290;

internal class Class6943 : Interface352
{
	private readonly Interface351 interface351_0;

	private readonly Interface344 interface344_0;

	public Class6943(Interface351 boxInfo, Interface344 factory)
	{
		Class6892.smethod_0(boxInfo, "boxInfo");
		Class6892.smethod_0(factory, "factory");
		interface351_0 = boxInfo;
		interface344_0 = factory;
	}

	public void imethod_1(Class6844 box, Class6845 container)
	{
		imethod_2(box, container, out var _, out var _);
	}

	public void imethod_2(Class6844 box, Class6845 container, out bool wasContainerBoxSplitted, out Class6845 newContainer)
	{
		Class6892.smethod_0(container, "container");
		Class6892.smethod_0(box, "box");
		wasContainerBoxSplitted = false;
		newContainer = null;
		if (container.InnerBoxes.Count == 0)
		{
			smethod_0(box, container);
			Enum946 @enum = interface351_0.imethod_1(box);
			Enum946 enum2 = interface351_0.imethod_1(container);
			if (@enum == Enum946.const_1 && enum2 != Enum946.const_1)
			{
				container.Style.Display = Enum952.const_1;
			}
			return;
		}
		Enum946 enum3 = interface351_0.imethod_0(container);
		Enum946 enum4 = interface351_0.imethod_1(box);
		if (enum3 == enum4)
		{
			smethod_0(box, container);
			return;
		}
		switch (enum3)
		{
		case Enum946.const_1:
		{
			Class6848 @class = interface344_0.imethod_3();
			@class.Style = Class6960.smethod_3(container);
			smethod_0(@class, container);
			smethod_0(box, @class);
			newContainer = @class;
			wasContainerBoxSplitted = true;
			break;
		}
		case Enum946.const_0:
			newContainer = method_0(container, box);
			wasContainerBoxSplitted = true;
			break;
		}
	}

	public Class6845 imethod_0(Class6845 source, Class6845 dest)
	{
		Class6892.smethod_0(source, "source");
		Class6892.smethod_0(dest, "dest");
		Class6845 @class = source;
		Class6845 class2 = null;
		while (@class != dest)
		{
			Class6845 class3 = (Class6845)@class.Clone();
			if (class2 != null)
			{
				class3.InnerBoxes.Add(class2);
				class2.Parent = class3;
			}
			class2 = class3;
			if (@class.Parent == null)
			{
				break;
			}
			if (@class.Parent is Class6845)
			{
				@class = @class.Parent as Class6845;
				continue;
			}
			throw new Exception70();
		}
		return class2;
	}

	private Class6845 method_0(Class6845 container, Class6844 box)
	{
		Class6848 @class = interface344_0.imethod_3();
		Class6960.smethod_4(@class, container);
		Class6845 class2 = interface351_0.imethod_3(container);
		Class6845 class3 = imethod_0(container, class2);
		@class.InnerBoxes = class2.InnerBoxes;
		class2.InnerBoxes = new List<Class6844>();
		smethod_0(@class, class2);
		smethod_0(box, class2);
		Class6848 class4 = interface344_0.imethod_3();
		if (class3 != null)
		{
			smethod_0(class3, class4);
		}
		else
		{
			class3 = class4;
		}
		smethod_0(class4, class2);
		while (class3.InnerBoxes.Count > 0)
		{
			class3 = (Class6845)class3.InnerBoxes[0];
		}
		Class6960.smethod_4(class3, container);
		container = class3;
		return container;
	}

	private static void smethod_0(Class6844 box, Class6845 container)
	{
		container.InnerBoxes.Add(box);
		box.Parent = container;
	}
}
