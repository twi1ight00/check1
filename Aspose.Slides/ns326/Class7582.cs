using System;
using ns322;
using ns323;
using ns73;

namespace ns326;

internal class Class7582 : Class7456
{
	private static readonly Type type_0 = typeof(Interface73);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_10("item");
		method_11("length", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Interface73 @interface = (Interface73)instance.Value;
		switch (function)
		{
		case "get_length":
			return method_5(@interface.Length);
		case "item":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@interface[parameters[0].vmethod_4()], typeof(Interface59));
		default:
			throw new Exception89("unknown function");
		}
	}
}
