using System;
using System.Collections;
using System.Collections.Generic;

namespace ns83;

internal class Class4375 : Class4374<object>
{
	public Class4375(Interface106 adaptor, string elementDescription)
		: base(adaptor, elementDescription)
	{
	}

	public Class4375(Interface106 adaptor, string elementDescription, object oneElement)
		: base(adaptor, elementDescription, oneElement)
	{
	}

	public Class4375(Interface106 adaptor, string elementDescription, IList<object> elements)
		: base(adaptor, elementDescription, elements)
	{
	}

	[Obsolete("This constructor is for internal use only and might be phased out soon. Use instead the one with IList<T>.")]
	public Class4375(Interface106 adaptor, string elementDescription, IList elements)
		: base(adaptor, elementDescription, elements)
	{
	}

	public object method_3()
	{
		return method_1();
	}

	protected override object vmethod_1(object el)
	{
		return interface106_0.imethod_1(el);
	}
}
