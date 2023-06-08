using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7599 : Class7456
{
	private static readonly Type type_0 = typeof(Class7090);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_10("getDOMImplementation");
		method_10("getDOMImplementationList");
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7090 @class = (Class7090)instance.Value;
		switch (function)
		{
		case "getDOMImplementationList":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_1(parameters[0].ToString()), typeof(Class7089));
		case "getDOMImplementation":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_0(parameters[0].ToString()), typeof(Class7097));
		default:
			throw new Exception89("unknown function");
		}
	}
}
