using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7633 : Class7456
{
	private static readonly Type type_0 = typeof(Class7020);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("form", Enum983.flag_0);
		method_11("accessKey", Enum983.flag_0 | Enum983.flag_1);
		method_11("align", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7020 @class = (Class7020)instance.Value;
		switch (function)
		{
		case "set_align":
			@class.Align = parameters[0].ToString();
			goto IL_0080;
		case "get_align":
			return method_3(@class.Align);
		case "set_accessKey":
			@class.AccessKey = parameters[0].ToString();
			goto IL_0080;
		case "get_accessKey":
			return method_3(@class.AccessKey);
		default:
			throw new Exception89("unknown function");
		case "get_form":
			{
				return method_2(@class.Form, typeof(Class7009));
			}
			IL_0080:
			return base.Undefined;
		}
	}
}
