using System.Collections.Generic;

namespace ns305;

internal class Class7073
{
	private Class7088 class7088_0;

	private Dictionary<string, object> dictionary_0;

	public Class7088 ParameterNames => class7088_0;

	internal Class7073()
	{
		class7088_0 = new Class7088();
		dictionary_0 = new Dictionary<string, object>();
	}

	public void method_0(string name, object value)
	{
		if (!ParameterNames.Contains(name))
		{
			Exception73.smethod_0(Enum968.const_7);
		}
		if (!method_2(name, value))
		{
			Exception73.smethod_0(Enum968.const_8);
		}
		dictionary_0[name] = value;
	}

	public object method_1(string name)
	{
		if (!ParameterNames.Contains(name))
		{
			Exception73.smethod_0(Enum968.const_7);
		}
		return dictionary_0[name];
	}

	public bool method_2(string name, object value)
	{
		if (!ParameterNames.Contains(name))
		{
			Exception73.smethod_0(Enum968.const_7);
		}
		return true;
	}
}
