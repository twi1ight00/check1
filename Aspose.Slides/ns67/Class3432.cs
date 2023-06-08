using System;

namespace ns67;

internal sealed class Class3432 : Class3431, Interface49
{
	private readonly Class3429 class3429_0 = new Class3429();

	private Class3456 class3456_0 = new Class3456(0.0, 0.0);

	private Class3455 class3455_0 = new Class3455(0.0, 0.0);

	public Class3456 ChildrenOffset
	{
		get
		{
			return class3456_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			class3456_0 = value.method_0();
		}
	}

	public Class3455 ChildrenExtents
	{
		get
		{
			return class3455_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			class3455_0 = value.method_0();
		}
	}

	public int ShapeCount => class3429_0.ShapeCount;

	internal Interface50 Children => class3429_0;

	public Class3431[] imethod_0()
	{
		return class3429_0.imethod_0();
	}

	public bool imethod_1(Class3431 child)
	{
		return class3429_0.imethod_1(child);
	}

	public Class3432(Class3452 slide, Class3432 parent)
		: base(slide, parent)
	{
	}

	internal void method_2(Class3431 child)
	{
		class3429_0.method_0(child);
		method_3();
	}

	internal override void vmethod_0(Class3428 renderer, Class3434 parentAttributes)
	{
		Class3434 @class = base.Attributes;
		if (parentAttributes != null)
		{
			@class = base.Attributes.method_0();
			@class.method_1(parentAttributes);
		}
		Class3431[] array = class3429_0.imethod_0();
		foreach (Class3431 class2 in array)
		{
			class2.vmethod_0(renderer, @class);
		}
	}

	private void method_3()
	{
		throw new NotImplementedException();
	}
}
