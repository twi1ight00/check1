using System.Collections;
using ns178;
using ns183;

namespace ns177;

internal class Class4984 : Interface155
{
	private string string_0;

	private Hashtable hashtable_0 = new Hashtable();

	public Class4984(string interfaceName)
	{
		string_0 = interfaceName;
	}

	public string method_0()
	{
		return string_0;
	}

	public void method_1(string name)
	{
		string_0 = name;
	}

	public void method_2(Class4933 method)
	{
		hashtable_0.Add(method.method_3(), method);
	}

	public Class4933 method_3(string methodName)
	{
		return (Class4933)hashtable_0[methodName];
	}

	public Interface208 method_4()
	{
		ArrayList arrayList = new ArrayList();
		foreach (object value in hashtable_0.Values)
		{
			arrayList.Add(value);
		}
		return new Class5495(arrayList);
	}

	public void imethod_0(Interface153 handler)
	{
		Class5699 @class = new Class5699();
		@class.method_1(string.Empty, "name", "name", "CDATA", method_0());
		string text = "producer";
		handler.imethod_6(string.Empty, text, text, @class);
		Interface208 @interface = method_4();
		while (@interface.imethod_0())
		{
			((Interface155)@interface.imethod_1()).imethod_0(handler);
		}
		handler.imethod_7(string.Empty, text, text);
	}
}
