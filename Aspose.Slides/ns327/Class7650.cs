using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7650 : Class7456
{
	private static readonly Type type_0 = typeof(Class7035);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_10("Add");
		method_10("Remove");
		method_10("Blur");
		method_10("Focus");
		method_11("type", Enum983.flag_0);
		method_11("selectedIndex", Enum983.flag_0 | Enum983.flag_1);
		method_11("value", Enum983.flag_0 | Enum983.flag_1);
		method_11("length", Enum983.flag_0 | Enum983.flag_1);
		method_11("form", Enum983.flag_0);
		method_11("options", Enum983.flag_0);
		method_11("disabled", Enum983.flag_0 | Enum983.flag_1);
		method_11("multiple", Enum983.flag_0 | Enum983.flag_1);
		method_11("name", Enum983.flag_0 | Enum983.flag_1);
		method_11("size", Enum983.flag_0 | Enum983.flag_1);
		method_11("tabIndex", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7035 @class = (Class7035)instance.Value;
		switch (function)
		{
		case "get_type":
			return method_3(@class.Type);
		case "get_selectedIndex":
			return method_5(@class.SelectedIndex);
		case "set_selectedIndex":
			@class.SelectedIndex = parameters[0].vmethod_4();
			break;
		case "get_value":
			return method_3(@class.Value);
		case "set_value":
			@class.Value = parameters[0].ToString();
			break;
		case "get_length":
			return method_5(@class.Length);
		case "set_length":
			@class.Length = parameters[0].vmethod_4();
			break;
		case "get_form":
			return method_2(@class.Form, typeof(Class7009));
		case "get_options":
			return method_2(@class.Options, typeof(Class7076));
		case "get_disabled":
			return method_6(@class.Disabled);
		case "set_disabled":
			@class.Disabled = parameters[0].vmethod_2();
			break;
		case "get_multiple":
			return method_6(@class.Multiple);
		case "set_multiple":
			@class.Multiple = parameters[0].vmethod_2();
			break;
		case "get_name":
			return method_3(@class.Name);
		case "set_name":
			@class.Name = parameters[0].ToString();
			break;
		case "get_size":
			return method_5(@class.Size);
		case "set_size":
			@class.Size = parameters[0].vmethod_4();
			break;
		case "get_tabIndex":
			return method_5(@class.TabIndex);
		case "set_tabIndex":
			@class.TabIndex = parameters[0].vmethod_4();
			break;
		case "add":
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			break;
		case "remove":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			break;
		default:
			throw new Exception89("unknown function");
		case "blur":
		case "focus":
			break;
		}
		return base.Undefined;
	}
}
