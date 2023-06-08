using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7635 : Class7456
{
	private static readonly Type type_0 = typeof(Class7022);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("disabled", Enum983.flag_0 | Enum983.flag_1);
		method_11("charset", Enum983.flag_0 | Enum983.flag_1);
		method_11("href", Enum983.flag_0 | Enum983.flag_1);
		method_11("hreflang", Enum983.flag_0 | Enum983.flag_1);
		method_11("media", Enum983.flag_0 | Enum983.flag_1);
		method_11("rel", Enum983.flag_0 | Enum983.flag_1);
		method_11("rev", Enum983.flag_0 | Enum983.flag_1);
		method_11("target", Enum983.flag_0 | Enum983.flag_1);
		method_11("type", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7022 @class = (Class7022)instance.Value;
		switch (function)
		{
		case "get_disabled":
			return method_6(@class.Disabled);
		case "set_disabled":
			@class.Disabled = parameters[0].vmethod_2();
			break;
		case "get_charset":
			return method_3(@class.Charset);
		case "set_charset":
			@class.Charset = parameters[0].ToString();
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
		case "get_media":
			return method_3(@class.Media);
		case "set_media":
			@class.Media = parameters[0].ToString();
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
		default:
			throw new Exception89("unknown function");
		}
		return base.Undefined;
	}
}
