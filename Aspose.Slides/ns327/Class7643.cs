using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7643 : Class7456
{
	private static readonly Type type_0 = typeof(Class7029);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("form", Enum983.flag_0);
		method_11("defaultSelected", Enum983.flag_0 | Enum983.flag_1);
		method_11("text", Enum983.flag_0);
		method_11("index", Enum983.flag_0);
		method_11("disabled", Enum983.flag_0 | Enum983.flag_1);
		method_11("label", Enum983.flag_0 | Enum983.flag_1);
		method_11("selected", Enum983.flag_0 | Enum983.flag_1);
		method_11("value", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7029 @class = (Class7029)instance.Value;
		switch (function)
		{
		case "get_form":
			return method_2(@class.Form, typeof(Class7009));
		case "get_defaultSelected":
			return method_6(@class.DefaultSelected);
		case "set_defaultSelected":
			@class.DefaultSelected = parameters[0].vmethod_2();
			break;
		case "get_text":
			return method_3(@class.Text);
		case "get_index":
			return method_5(@class.Index);
		case "get_disabled":
			return method_6(@class.Disabled);
		case "set_disabled":
			@class.Disabled = parameters[0].vmethod_2();
			break;
		case "get_label":
			return method_3(@class.Label);
		case "set_label":
			@class.Label = parameters[0].ToString();
			break;
		case "get_selected":
			return method_6(@class.Selected);
		case "set_selected":
			@class.Selected = parameters[0].vmethod_2();
			break;
		case "get_value":
			return method_3(@class.Value);
		case "set_value":
			@class.Value = parameters[0].ToString();
			break;
		default:
			throw new Exception89("unknown function");
		}
		return base.Undefined;
	}
}
