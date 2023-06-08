using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7662 : Class7456
{
	private static readonly Type type_0 = typeof(Class7091);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_10("getName");
		method_10("getNamespaceURI");
		method_10("contains");
		method_10("containsNS");
		method_11("length", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7091 @class = (Class7091)instance.Value;
		switch (function)
		{
		case "containsNS":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_6(@class.method_4(parameters[0].ToString(), parameters[1].ToString()));
		case "contains":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_6(@class.Contains(parameters[0].ToString()));
		case "get_Length":
			return method_5(@class.Length);
		case "getNamespaceURI":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_3(@class.method_3(parameters[0].vmethod_4()));
		case "getName":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_3(@class.method_2(parameters[0].vmethod_4()));
		default:
			throw new Exception89("unknown function");
		}
	}
}
