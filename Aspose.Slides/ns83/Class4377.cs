using System;
using System.Collections;
using System.Collections.Generic;
using ns82;

namespace ns83;

internal class Class4377 : Class4374<Interface86>
{
	public Class4377(Interface106 adaptor, string elementDescription)
		: base(adaptor, elementDescription)
	{
	}

	public Class4377(Interface106 adaptor, string elementDescription, Interface86 oneElement)
		: base(adaptor, elementDescription, oneElement)
	{
	}

	public Class4377(Interface106 adaptor, string elementDescription, IList<Interface86> elements)
		: base(adaptor, elementDescription, elements)
	{
	}

	[Obsolete("This constructor is for internal use only and might be phased out soon. Use instead the one with IList<T>.")]
	public Class4377(Interface106 adaptor, string elementDescription, IList elements)
		: base(adaptor, elementDescription, elements)
	{
	}

	public object method_3()
	{
		return interface106_0.imethod_0((Interface86)method_1());
	}

	public Interface86 method_4()
	{
		return (Interface86)method_1();
	}

	protected override object vmethod_1(Interface86 el)
	{
		return el;
	}
}
