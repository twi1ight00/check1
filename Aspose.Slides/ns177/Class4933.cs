using System;
using System.Collections;
using ns178;
using ns183;

namespace ns177;

internal class Class4933 : Interface155
{
	internal class Class4934 : Interface155
	{
		private Type type_0;

		private string string_0;

		public Class4934(Type type, string name)
		{
			type_0 = type;
			string_0 = name;
		}

		public Type method_0()
		{
			return type_0;
		}

		public string method_1()
		{
			return string_0;
		}

		public void imethod_0(Interface153 handler)
		{
			Class5699 @class = new Class5699();
			@class.method_1(string.Empty, "type", "type", "CDATA", method_0().FullName);
			@class.method_1(string.Empty, "name", "name", "CDATA", method_1());
			string text = "parameter";
			handler.imethod_6(string.Empty, text, text, @class);
			handler.imethod_7(string.Empty, text, text);
		}
	}

	private string string_0;

	private Class5598 class5598_0;

	private ArrayList arrayList_0 = new ArrayList();

	private string string_1;

	public Class4933(string methodName, Class5598 severity)
	{
		string_0 = methodName;
		class5598_0 = severity;
	}

	public void method_0(Class4934 param)
	{
		arrayList_0.Add(param);
	}

	public Class4934 method_1(Type type, string name)
	{
		Class4934 @class = new Class4934(type, name);
		method_0(@class);
		return @class;
	}

	public void method_2(string name)
	{
		string_0 = name;
	}

	public string method_3()
	{
		return string_0;
	}

	public void method_4(Class5598 severitY)
	{
		class5598_0 = severitY;
	}

	public Class5598 method_5()
	{
		return class5598_0;
	}

	public ArrayList method_6()
	{
		return arrayList_0;
	}

	public void method_7(string exceptionClasS)
	{
		string_1 = exceptionClasS;
	}

	public string method_8()
	{
		return string_1;
	}

	public void imethod_0(Interface153 handler)
	{
		Class5699 @class = new Class5699();
		@class.method_1(string.Empty, "name", "name", "CDATA", method_3());
		@class.method_1(string.Empty, "severity", "severity", "CDATA", method_5().method_0());
		if (method_8() != null)
		{
			@class.method_1(string.Empty, "exception", "exception", "CDATA", method_8());
		}
		string text = "method";
		handler.imethod_6(string.Empty, text, text, @class);
		Interface208 @interface = new Class5495(arrayList_0);
		while (@interface.imethod_0())
		{
			((Interface155)@interface.imethod_1()).imethod_0(handler);
		}
		handler.imethod_7(string.Empty, text, text);
	}
}
