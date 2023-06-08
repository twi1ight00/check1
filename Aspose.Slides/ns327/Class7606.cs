using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7606 : Class7456
{
	private static readonly Type type_0 = typeof(Class6996);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_10("blur");
		method_10("focus");
		method_11("accessKey", Enum983.flag_0 | Enum983.flag_1);
		method_11("charset", Enum983.flag_0 | Enum983.flag_1);
		method_11("coords", Enum983.flag_0 | Enum983.flag_1);
		method_11("href", Enum983.flag_0 | Enum983.flag_1);
		method_11("hreflang", Enum983.flag_0 | Enum983.flag_1);
		method_11("name", Enum983.flag_0 | Enum983.flag_1);
		method_11("rel", Enum983.flag_0 | Enum983.flag_1);
		method_11("rev", Enum983.flag_0 | Enum983.flag_1);
		method_11("shape", Enum983.flag_0 | Enum983.flag_1);
		method_11("tabIndex", Enum983.flag_0 | Enum983.flag_1);
		method_11("target", Enum983.flag_0 | Enum983.flag_1);
		method_11("type", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class6996 @class = (Class6996)instance.Value;
		switch (function)
		{
		case "get_accessKey":
			return method_3(@class.AccessKey);
		case "set_accessKey":
			@class.AccessKey = parameters[0].ToString();
			break;
		case "get_charset":
			return method_3(@class.Charset);
		case "set_charset":
			@class.Charset = parameters[0].ToString();
			break;
		case "get_coords":
			return method_3(@class.Coords);
		case "set_coords":
			@class.Coords = parameters[0].ToString();
			break;
		case "get_href":
			return method_3(@class.Href);
		case "set_href":
			@class.Href = parameters[0].ToString();
			break;
		case "get_hreflang":
			return method_3(@class.Hreflang);
		case "set_hreflang":
			@class.Hreflang = parameters[0].ToString();
			break;
		case "get_name":
			return method_3(@class.Name);
		case "set_name":
			@class.Name = parameters[0].ToString();
			break;
		case "get_rel":
			return method_3(@class.Rel);
		case "set_rel":
			@class.Rel = parameters[0].ToString();
			break;
		case "get_rev":
			return method_3(@class.Rev);
		case "set_rev":
			@class.Rev = parameters[0].ToString();
			break;
		case "get_shape":
			return method_3(@class.Shape);
		case "set_shape":
			@class.Shape = parameters[0].ToString();
			break;
		case "get_tabIndex":
			return method_5(@class.TabIndex);
		case "set_tabIndex":
			@class.TabIndex = parameters[0].vmethod_4();
			break;
		case "get_target":
			return method_3(@class.Target);
		case "set_target":
			@class.Target = parameters[0].ToString();
			break;
		case "get_type":
			return method_3(@class.Type);
		case "set_type":
			@class.Type = parameters[0].ToString();
			break;
		case "blur":
			@class.method_53();
			break;
		case "focus":
			@class.method_54();
			break;
		default:
			throw new Exception89("unknown function");
		}
		return base.Undefined;
	}
}
