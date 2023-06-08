using System;
using ns178;

namespace ns175;

internal class Exception53 : Exception
{
	private string string_0;

	private int int_0;

	private int int_1;

	private string string_1;

	public Exception53(string message)
		: base(message)
	{
	}

	public Exception53(string message, string systemId, int line, int column)
		: base(message)
	{
		string_0 = systemId;
		int_0 = line;
		int_1 = column;
	}

	public Exception53(string message, Interface243 locator)
		: base(message)
	{
		method_0(locator);
	}

	public void method_0(Interface243 locator)
	{
		if (locator != null)
		{
			string_0 = locator.imethod_2();
			int_0 = locator.imethod_0();
			int_1 = locator.imethod_1();
		}
	}

	public void method_1(string systemID, int linE, int columN)
	{
		string_0 = systemID;
		int_0 = linE;
		int_1 = columN;
	}

	public bool method_2()
	{
		return int_0 > 0;
	}

	public virtual string vmethod_0()
	{
		if (method_2())
		{
			return string_0 + ":" + int_0 + ":" + int_1 + ": " + base.Message;
		}
		return base.Message;
	}

	public void method_3(string msg)
	{
		string_1 = msg;
	}

	public string method_4()
	{
		if (string_1 != null)
		{
			return string_1;
		}
		return base.Message;
	}
}
