using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7649 : Class7456
{
	private static readonly Type type_0 = typeof(Class7034);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("text", Enum983.flag_0 | Enum983.flag_1);
		method_11("htmlFor", Enum983.flag_0 | Enum983.flag_1);
		method_11("event", Enum983.flag_0 | Enum983.flag_1);
		method_11("charset", Enum983.flag_0 | Enum983.flag_1);
		method_11("defer", Enum983.flag_0 | Enum983.flag_1);
		method_11("src", Enum983.flag_0 | Enum983.flag_1);
		method_11("type", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7034 @class = (Class7034)instance.Value;
		switch (function)
		{
		case "get_text":
			return method_3(@class.Text);
		case "set_text":
			@class.Text = parameters[0].ToString();
			break;
		case "get_htmlFor":
			return method_3(@class.HtmlFor);
		case "set_htmlFor":
			@class.HtmlFor = parameters[0].ToString();
			break;
		case "get_event":
			return method_3(@class.Event);
		case "set_event":
			@class.Event = parameters[0].ToString();
			break;
		case "get_charset":
			return method_3(@class.Charset);
		case "set_charset":
			@class.Charset = parameters[0].ToString();
			break;
		case "get_defer":
			return method_6(@class.Defer);
		case "set_defer":
			@class.Defer = parameters[0].vmethod_2();
			break;
		case "get_src":
			return method_3(@class.Src);
		case "set_src":
			@class.Src = parameters[0].ToString();
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
