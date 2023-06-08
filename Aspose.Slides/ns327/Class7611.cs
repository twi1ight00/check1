using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7611 : Class7456
{
	private static readonly Type type_0 = typeof(Class7001);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("aLink", Enum983.flag_0 | Enum983.flag_1);
		method_11("background", Enum983.flag_0 | Enum983.flag_1);
		method_11("bgColor", Enum983.flag_0 | Enum983.flag_1);
		method_11("link", Enum983.flag_0 | Enum983.flag_1);
		method_11("text", Enum983.flag_0 | Enum983.flag_1);
		method_11("vLink", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7001 @class = (Class7001)instance.Value;
		switch (function)
		{
		case "get_aLink":
			return method_3(@class.ALink);
		case "set_aLink":
			@class.ALink = parameters[0].ToString();
			break;
		case "get_background":
			return method_3(@class.Background);
		case "set_background":
			@class.Background = parameters[0].ToString();
			break;
		case "get_bgColor":
			return method_3(@class.BgColor);
		case "set_bgColor":
			@class.BgColor = parameters[0].ToString();
			break;
		case "get_link":
			return method_3(@class.Link);
		case "set_link":
			@class.Link = parameters[0].ToString();
			break;
		case "get_text":
			return method_3(@class.Text);
		case "set_text":
			@class.Text = parameters[0].ToString();
			break;
		case "get_vLink":
			return method_3(@class.VLink);
		case "set_vLink":
			@class.VLink = parameters[0].ToString();
			break;
		default:
			throw new Exception89("unknown function");
		}
		return base.Undefined;
	}
}
