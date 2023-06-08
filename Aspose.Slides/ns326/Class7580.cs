using System;
using ns322;
using ns323;
using ns73;

namespace ns326;

internal class Class7580 : Class7456
{
	private static readonly Type type_0 = typeof(Class3679);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_11("cssText", Enum983.flag_0 | Enum983.flag_1);
		method_11("cssValueType", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class3679 @class = (Class3679)instance.Value;
		switch (function)
		{
		case "get_cssValueType":
			return method_5(@class.CSSValueType);
		case "set_cssText":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.CSSText = parameters[0].ToString();
			return base.Undefined;
		default:
			throw new Exception89("unknown function");
		case "get_cssText":
			return method_3(@class.CSSText);
		}
	}

	protected override void vmethod_2(Class7397 instance)
	{
		method_12(instance, "CSS_INHERIT", method_5(0.0));
		method_12(instance, "CSS_PRIMITIVE_VALUE", method_5(1.0));
		method_12(instance, "CSS_VALUE_LIST", method_5(2.0));
		method_12(instance, "CSS_CUSTOM", method_5(3.0));
		base.vmethod_2(instance);
	}
}
