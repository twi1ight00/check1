using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7651 : Class7456
{
	private static readonly Type type_0 = typeof(Class7036);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("disabled", Enum983.flag_0 | Enum983.flag_1);
		method_11("media", Enum983.flag_0 | Enum983.flag_1);
		method_11("type", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7036 @class = (Class7036)instance.Value;
		switch (function)
		{
		case "get_disabled":
			return method_6(@class.Disabled);
		case "set_disabled":
			@class.Disabled = parameters[0].vmethod_2();
			break;
		case "get_media":
			return method_3(@class.Media);
		case "set_media":
			@class.Media = parameters[0].ToString();
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
