using System;
using ns287;
using ns305;
using ns322;
using ns323;

namespace ns327;

internal class Class7644 : Class7456
{
	private static readonly Type type_0 = typeof(Class7076);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class7075);

	public override void Initialize()
	{
		method_10("NamedItem");
		method_10("Item");
		method_11("length", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7076 @class = (Class7076)instance.Value;
		switch (function)
		{
		case "namedItem":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.vmethod_0(parameters[0].ToString()), typeof(Class6976));
		case "Item":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class[parameters[0].vmethod_4()], typeof(Class6976));
		default:
			throw new Exception89("unknown function");
		case "get_length":
			return method_5(@class.Length);
		}
	}
}
