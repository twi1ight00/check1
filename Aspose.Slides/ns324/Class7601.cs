using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7601 : Class7456
{
	private static readonly Type type_0 = typeof(Class7088);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_10("item");
		method_10("contains");
		method_11("length", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7088 @class = (Class7088)instance.Value;
		switch (function)
		{
		case "contains":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_6(@class.Contains(parameters[0].ToString()));
		case "get_length":
			return method_5(@class.Length);
		case "item":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_3(@class.method_0(parameters[0].vmethod_4()));
		default:
			throw new Exception89("unknown function");
		}
	}
}
