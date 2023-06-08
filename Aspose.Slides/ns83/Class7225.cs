using System;
using System.Collections;
using System.Collections.Generic;
using ns82;

namespace ns83;

internal class Class7225 : Class7222<Interface392>
{
	public Class7225(Interface387 adaptor, string elementDescription)
		: base(adaptor, elementDescription)
	{
	}

	public Class7225(Interface387 adaptor, string elementDescription, Interface392 oneElement)
		: base(adaptor, elementDescription, oneElement)
	{
	}

	public Class7225(Interface387 adaptor, string elementDescription, IList<Interface392> elements)
		: base(adaptor, elementDescription, elements)
	{
	}

	[Obsolete("This constructor is for internal use only and might be phased out soon. Use instead the one with IList<T>.")]
	public Class7225(Interface387 adaptor, string elementDescription, IList elements)
		: base(adaptor, elementDescription, elements)
	{
	}

	public object method_3()
	{
		return interface387_0.imethod_0((Interface392)method_1());
	}

	public Interface392 method_4()
	{
		return (Interface392)method_1();
	}

	protected override object vmethod_1(Interface392 el)
	{
		return el;
	}
}
