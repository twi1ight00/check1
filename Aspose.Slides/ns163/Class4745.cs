using System;
using ns164;
using ns167;

namespace ns163;

internal class Class4745 : Class4744
{
	private Class4743 class4743_1;

	internal Class4745(Class4750 context)
		: base(context)
	{
		class4743_1 = Class4751.smethod_0(context);
	}

	protected override bool vmethod_1(Class4782 root, Class4846 visitedElements)
	{
		bool result = true;
		Class4744.smethod_2(root, visitedElements);
		foreach (Class4845 item in root)
		{
			if (visitedElements.Contains(item))
			{
				continue;
			}
			if (item.Value is Class4787 graphicsArea)
			{
				method_7(graphicsArea);
				continue;
			}
			if (class4743_1.vmethod_0(item.Value))
			{
				visitedElements.Add(item);
				continue;
			}
			throw new InvalidOperationException("Can not recognize pdf document");
		}
		if (root.Images != null)
		{
			foreach (Class4845 image in root.Images)
			{
				if (image.Value is Class4790 picture)
				{
					method_6(picture);
				}
			}
		}
		return result;
	}

	private void method_7(Class4787 graphicsArea)
	{
		class4750_0.CurrentElement.Add(new Class4756(graphicsArea));
	}
}
