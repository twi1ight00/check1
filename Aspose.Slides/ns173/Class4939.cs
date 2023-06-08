using System.Collections;
using ns188;

namespace ns173;

internal class Class4939 : Class4937, Interface160
{
	private string string_0;

	private string[] string_1;

	private Class4974 class4974_0;

	public Class4939(Class5093 destination)
		: this(destination.method_25())
	{
	}

	public Class4939(string idRef)
	{
		string_0 = idRef;
		string_1 = new string[1] { idRef };
	}

	public string method_0()
	{
		return string_0;
	}

	public string[] imethod_3()
	{
		return string_1;
	}

	public Class4974 method_1()
	{
		return class4974_0;
	}

	public bool imethod_2()
	{
		return true;
	}

	public void imethod_4(string id, ArrayList pages)
	{
		class4974_0 = (Class4974)pages[0];
	}

	public override string imethod_1()
	{
		return "Destination";
	}
}
