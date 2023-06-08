using System;
using System.Collections;
using System.IO;
using ns178;
using ns183;

namespace ns177;

internal class Class4935 : Interface155
{
	private Hashtable hashtable_0 = new Hashtable();

	public void method_0(Class4984 producer)
	{
		hashtable_0.Add(producer.method_0(), producer);
	}

	public Interface208 method_1()
	{
		ArrayList arrayList = new ArrayList();
		foreach (object value in hashtable_0.Values)
		{
			arrayList.Add(value);
		}
		return new Class5495(arrayList);
	}

	public Class4984 method_2(string interfaceName)
	{
		return (Class4984)hashtable_0[interfaceName];
	}

	public Class4984 method_3(Type clazz)
	{
		return method_2(clazz.FullName);
	}

	public void imethod_0(Interface153 handler)
	{
		Class5699 atts = new Class5699();
		string text = "event-model";
		handler.imethod_6(string.Empty, text, text, atts);
		Interface208 @interface = method_1();
		while (@interface.imethod_0())
		{
			((Interface155)@interface.imethod_1()).imethod_0(handler);
		}
		handler.imethod_7(string.Empty, text, text);
	}

	private static void smethod_0(Interface155 @object, Stream outputFile)
	{
		throw new NotImplementedException();
	}

	public void method_4(Stream modelFile)
	{
		smethod_0(this, modelFile);
	}
}
