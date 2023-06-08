using System;
using ns322;
using ns323;
using ns73;

namespace ns326;

internal class Class7576 : Class7456
{
	private static readonly Type type_0 = typeof(Interface71);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Interface59);

	public override void Initialize()
	{
		method_10("insertRule");
		method_10("deleteRule");
		method_11("media", Enum983.flag_0);
		method_11("cssRules", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Interface71 @interface = (Interface71)instance.Value;
		switch (function)
		{
		case "deleteRule":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			@interface.imethod_1(parameters[0].vmethod_4());
			return base.Undefined;
		case "insertRule":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_5(@interface.imethod_0(parameters[0].ToString(), parameters[1].vmethod_4()));
		case "get_cssRules":
			return method_2(@interface.CSSRules, typeof(Interface73));
		default:
			throw new Exception89("unknown function");
		case "get_media":
			return method_2(@interface.Media, typeof(Interface79));
		}
	}
}
