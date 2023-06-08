using System;
using System.Collections.Generic;
using ns73;
using ns76;
using ns88;

namespace ns79;

internal abstract class Class3969 : Class3770
{
	public abstract void vmethod_3(Class3726 engine, Interface100 propertyHandler, Interface99 lu, bool important);

	public override Class3679 vmethod_0(Interface99 lu, Class3726 engine)
	{
		throw new NotSupportedException("See individual properties.");
	}

	public override Class3679 vmethod_1()
	{
		throw new NotSupportedException("See individual properties.");
	}

	protected void method_7(Interface100 propertyHandler, string property, Interface99 lu, bool important)
	{
		propertyHandler.imethod_0(property, lu, important);
	}

	protected void method_8(Interface100 propertyHandler, string property, IList<Interface99> units, bool important)
	{
		if (units.Count != 0)
		{
			propertyHandler.imethod_0(property, Class4233.smethod_14(units).First, important);
		}
	}
}
