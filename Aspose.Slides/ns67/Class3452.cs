using System;

namespace ns67;

internal sealed class Class3452 : Interface49
{
	private readonly Class3429 class3429_0 = new Class3429();

	public int ShapeCount => class3429_0.ShapeCount;

	internal Interface50 Shapes => class3429_0;

	public Class3431[] imethod_0()
	{
		return class3429_0.imethod_0();
	}

	public bool imethod_1(Class3431 child)
	{
		return class3429_0.imethod_1(child);
	}

	public void method_0(Interface53 device)
	{
		using Class3428 class2 = new Class3428(device);
		Class3431[] array = class3429_0.imethod_0();
		foreach (Class3431 @class in array)
		{
			@class.vmethod_0(class2, null);
		}
		class2.method_2();
	}

	internal void method_1(Class3431 shape)
	{
		if (shape == null)
		{
			throw new ArgumentNullException("shape");
		}
		class3429_0.method_0(shape);
	}
}
