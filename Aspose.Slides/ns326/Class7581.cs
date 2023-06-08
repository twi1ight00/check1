using System;
using ns322;
using ns323;
using ns73;

namespace ns326;

internal class Class7581 : Class7456
{
	private static readonly Type type_0 = typeof(Interface59);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_11("type", Enum983.flag_0);
		method_11("cssText", Enum983.flag_0 | Enum983.flag_1);
		method_11("parentStyleSheet", Enum983.flag_0);
		method_11("parentRule", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Interface59 @interface = (Interface59)instance.Value;
		switch (function)
		{
		case "get_parentRule":
			return method_2(@interface.ParentRule, @interface.ParentRule.GetType());
		case "get_parentStyleSheet":
			return method_2(@interface.ParentStyleSheet, @interface.ParentStyleSheet.GetType());
		case "set_cssText":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			@interface.CSSText = parameters[0].ToString();
			return base.Undefined;
		case "get_cssText":
			return method_3(@interface.CSSText);
		default:
			throw new Exception89("unknown function");
		case "get_type":
			return method_5(@interface.Type);
		}
	}

	protected override void vmethod_2(Class7397 instance)
	{
		method_12(instance, "CSS_INHERIT", method_5(0.0));
		method_12(instance, "STYLE_RULE", method_5(1.0));
		method_12(instance, "CHARSET_RULE", method_5(2.0));
		method_12(instance, "IMPORT_RULE", method_5(3.0));
		method_12(instance, "MEDIA_RULE", method_5(4.0));
		method_12(instance, "FONT_FACE_RULE", method_5(5.0));
		method_12(instance, "PAGE_RULE", method_5(6.0));
		base.vmethod_2(instance);
	}
}
