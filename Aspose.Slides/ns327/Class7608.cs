using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7608 : Class7456
{
	private static readonly Type type_0 = typeof(Class6998);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("accessKey", Enum983.flag_0 | Enum983.flag_1);
		method_11("alt", Enum983.flag_0 | Enum983.flag_1);
		method_11("coords", Enum983.flag_0 | Enum983.flag_1);
		method_11("href", Enum983.flag_0 | Enum983.flag_1);
		method_11("noHref", Enum983.flag_0 | Enum983.flag_1);
		method_11("shape", Enum983.flag_0 | Enum983.flag_1);
		method_11("tabIndex", Enum983.flag_0 | Enum983.flag_1);
		method_11("target", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class6998 @class = (Class6998)instance.Value;
		switch (function)
		{
		case "get_accessKey":
			return method_3(@class.AccessKey);
		case "set_accessKey":
			@class.AccessKey = parameters[0].ToString();
			break;
		case "get_alt":
			return method_3(@class.Alt);
		case "set_alt":
			@class.Alt = parameters[0].ToString();
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
		case "get_noHref":
			return method_6(@class.NoHref);
		case "set_noHref":
			@class.NoHref = parameters[0].vmethod_2();
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
		default:
			throw new Exception89("unknown function");
		}
		return base.Undefined;
	}
}
