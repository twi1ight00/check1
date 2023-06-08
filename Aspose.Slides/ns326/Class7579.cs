using System;
using ns322;
using ns323;
using ns73;

namespace ns326;

internal class Class7579 : Class7456
{
	private static readonly Type type_0 = typeof(Interface58);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_10("getPropertyValue");
		method_10("getPropertyCSSValue");
		method_10("removeProperty");
		method_10("getPropertyPriority");
		method_10("setProperty");
		method_10("item");
		method_11("cssText", Enum983.flag_0 | Enum983.flag_1);
		method_11("length", Enum983.flag_0);
		method_11("parentRule", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Interface58 @interface = (Interface58)instance.Value;
		switch (function)
		{
		case "get_cssText":
			return method_3(@interface.CSSText);
		case "set_cssText":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			@interface.CSSText = parameters[0].ToString();
			goto IL_01f0;
		case "getPropertyValue":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_3(@interface.imethod_244(parameters[0].ToString()));
		case "getPropertyCSSValue":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@interface.imethod_245(parameters[0].ToString()), typeof(Class3679));
		case "removeProperty":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_3(@interface.imethod_246(parameters[0].ToString()));
		case "getPropertyPriority":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_3(@interface.imethod_247(parameters[0].ToString()));
		case "setProperty":
			if (parameters.Length != 3)
			{
				throw new Exception89("invalid arguments count.");
			}
			@interface.imethod_248(parameters[0].ToString(), parameters[1].ToString(), parameters[2].ToString());
			goto IL_01f0;
		case "get_length":
			return method_5(@interface.Length);
		case "item":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_3(@interface[parameters[0].vmethod_4()]);
		default:
			throw new Exception89("unknown function");
		case "get_parentRule":
			{
				return method_2(@interface.ParentRule, typeof(Interface59));
			}
			IL_01f0:
			return base.Undefined;
		}
	}
}
