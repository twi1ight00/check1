using System;
using System.Collections;
using ns175;
using ns178;

namespace ns171;

internal class Class5599
{
	protected Hashtable hashtable_0 = new Hashtable();

	protected Hashtable hashtable_1 = new Hashtable();

	public Class5599(Class5734 factory)
	{
		smethod_0();
	}

	private static void smethod_0()
	{
	}

	public void method_0(string mappingClassName)
	{
		Type type = Type.GetType(mappingClassName);
		Class5180 mapping = (Class5180)type.GetConstructor(Type.EmptyTypes).Invoke(null);
		method_1(mapping);
	}

	public void method_1(Class5180 mapping)
	{
		hashtable_0.Add(mapping.method_1(), mapping.method_0());
		hashtable_1.Add(mapping.method_1(), mapping);
	}

	public Class5180.Class5185 method_2(string namespaceURI, string localName, Interface243 locator)
	{
		Hashtable hashtable = (Hashtable)hashtable_0[namespaceURI];
		Class5180.Class5185 @class = null;
		if (hashtable != null)
		{
			@class = (Class5180.Class5185)hashtable[localName];
			if (@class == null)
			{
				@class = (Class5180.Class5185)hashtable[Class5180.string_0];
			}
		}
		if (@class == null)
		{
			if (hashtable_1.ContainsKey(namespaceURI))
			{
				throw new Exception53(Class5088.smethod_3(locator) + "No element mapping definition found for " + Class5088.smethod_2(namespaceURI, localName), locator);
			}
			@class = new Class5092.Class5190(namespaceURI);
		}
		return @class;
	}

	public Class5180 method_3(string namespaceURI)
	{
		return (Class5180)hashtable_1[namespaceURI];
	}

	public bool method_4(string namespaceURI)
	{
		return hashtable_1.ContainsKey(namespaceURI);
	}
}
