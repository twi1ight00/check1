using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7630 : Class7456
{
	private static readonly Type type_0 = typeof(Class6995);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_10("Blur");
		method_10("Focus");
		method_10("Select");
		method_10("Click");
		method_11("defaultValue", Enum983.flag_0 | Enum983.flag_1);
		method_11("defaultChecked", Enum983.flag_0 | Enum983.flag_1);
		method_11("form", Enum983.flag_0);
		method_11("accept", Enum983.flag_0 | Enum983.flag_1);
		method_11("accessKey", Enum983.flag_0 | Enum983.flag_1);
		method_11("align", Enum983.flag_0 | Enum983.flag_1);
		method_11("alt", Enum983.flag_0 | Enum983.flag_1);
		method_11("checked", Enum983.flag_0 | Enum983.flag_1);
		method_11("disabled", Enum983.flag_0 | Enum983.flag_1);
		method_11("maxLength", Enum983.flag_0 | Enum983.flag_1);
		method_11("name", Enum983.flag_0 | Enum983.flag_1);
		method_11("readOnly", Enum983.flag_0 | Enum983.flag_1);
		method_11("size", Enum983.flag_0 | Enum983.flag_1);
		method_11("src", Enum983.flag_0 | Enum983.flag_1);
		method_11("tabIndex", Enum983.flag_0 | Enum983.flag_1);
		method_11("type", Enum983.flag_0 | Enum983.flag_1);
		method_11("useMap", Enum983.flag_0 | Enum983.flag_1);
		method_11("value", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class6995 @class = (Class6995)instance.Value;
		switch (function)
		{
		case "get_defaultValue":
			return method_3(@class.DefaultValue);
		case "set_defaultValue":
			@class.DefaultValue = parameters[0].ToString();
			break;
		case "get_defaultChecked":
			return method_6(@class.DefaultChecked);
		case "set_defaultChecked":
			@class.DefaultChecked = parameters[0].vmethod_2();
			break;
		case "get_form":
			return method_2(@class.Form, typeof(Class7009));
		case "get_accept":
			return method_3(@class.Accept);
		case "set_accept":
			@class.Accept = parameters[0].ToString();
			break;
		case "get_accessKey":
			return method_3(@class.AccessKey);
		case "set_accessKey":
			@class.AccessKey = parameters[0].ToString();
			break;
		case "get_align":
			return method_3(@class.Align);
		case "set_align":
			@class.Align = parameters[0].ToString();
			break;
		case "get_alt":
			return method_3(@class.Alt);
		case "set_alt":
			@class.Alt = parameters[0].ToString();
			break;
		case "get_checked":
			return method_6(@class.Checked);
		case "set_checked":
			@class.Checked = parameters[0].vmethod_2();
			break;
		case "get_disabled":
			return method_6(@class.Disabled);
		case "set_disabled":
			@class.Disabled = parameters[0].vmethod_2();
			break;
		case "get_maxLength":
			return method_5(@class.MaxLength);
		case "set_maxLength":
			@class.MaxLength = parameters[0].vmethod_4();
			break;
		case "get_name":
			return method_3(@class.Name);
		case "set_name":
			@class.Name = parameters[0].ToString();
			break;
		case "get_readOnly":
			return method_6(@class.ReadOnly);
		case "set_readOnly":
			@class.ReadOnly = parameters[0].vmethod_2();
			break;
		case "get_size":
			return method_5(@class.Size);
		case "set_size":
			@class.Size = parameters[0].vmethod_4();
			break;
		case "get_src":
			return method_3(@class.Src);
		case "set_src":
			@class.Src = parameters[0].ToString();
			break;
		case "get_tabIndex":
			return method_5(@class.TabIndex);
		case "set_tabIndex":
			@class.TabIndex = parameters[0].vmethod_4();
			break;
		case "get_type":
			return method_3(@class.Type);
		case "set_type":
			@class.Type = parameters[0].ToString();
			break;
		case "get_useMap":
			return method_3(@class.UseMap);
		case "set_useMap":
			@class.UseMap = parameters[0].ToString();
			break;
		case "get_value":
			return method_3(@class.Value);
		case "set_value":
			@class.Value = parameters[0].ToString();
			break;
		default:
			throw new Exception89("unknown function");
		case "blur":
		case "focus":
		case "select":
		case "click":
			break;
		}
		return base.Undefined;
	}
}
