using System;
using System.Collections;
using System.Globalization;
using ns174;
using ns175;
using ns183;

namespace ns207;

internal class Class5464
{
	private Class5738 class5738_0;

	private Hashtable hashtable_0 = new Hashtable();

	private CultureInfo cultureInfo_0;

	private Interface244 interface244_0;

	private string string_0 = string.Empty;

	public Class5464(Class5738 ua)
	{
		method_0(ua);
	}

	public void method_0(Class5738 ua)
	{
		if (class5738_0 != null)
		{
			throw new InvalidOperationException("The user agent was already set");
		}
		class5738_0 = ua;
	}

	public Class5738 method_1()
	{
		return class5738_0;
	}

	public Hashtable method_2()
	{
		return hashtable_0;
	}

	public object method_3(Class5619 qName)
	{
		return hashtable_0[qName];
	}

	public void method_4(Hashtable foreignAttributeS)
	{
		if (foreignAttributeS != null)
		{
			hashtable_0 = foreignAttributeS;
		}
		else
		{
			hashtable_0 = new Hashtable();
		}
	}

	public void method_5()
	{
		method_4(null);
	}

	public void method_6(CultureInfo lang)
	{
		cultureInfo_0 = lang;
	}

	public CultureInfo method_7()
	{
		return cultureInfo_0;
	}

	public void method_8(Interface244 structureTreeElement)
	{
		interface244_0 = structureTreeElement;
	}

	public void method_9()
	{
		method_8(null);
	}

	public Interface244 method_10()
	{
		return interface244_0;
	}

	private void method_11(string id)
	{
		string_0 = id;
	}

	private string method_12()
	{
		return string_0;
	}
}
