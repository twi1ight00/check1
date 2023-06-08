using System;
using ns287;
using ns306;
using ns322;
using ns323;
using ns73;

namespace ns327;

internal class Class7609 : Class7456
{
	private static readonly Type type_0 = typeof(Class6999);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("href", Enum983.flag_0 | Enum983.flag_1);
		method_11("target", Enum983.flag_0 | Enum983.flag_1);
		method_11("style", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class6999 @class = (Class6999)instance.Value;
		switch (function)
		{
		case "get_style":
			return method_2(@class.InternalStyleCSS2, typeof(Interface57));
		case "set_target":
			@class.Target = parameters[0].ToString();
			goto IL_009a;
		case "get_target":
			return method_3(@class.Target);
		case "set_href":
			@class.Href = parameters[0].ToString();
			goto IL_009a;
		default:
			throw new Exception89("unknown function");
		case "get_href":
			{
				return method_3(@class.Href);
			}
			IL_009a:
			return base.Undefined;
		}
	}
}
