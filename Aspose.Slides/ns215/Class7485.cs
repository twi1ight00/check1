using System;
using ns216;
using ns217;
using ns322;
using ns323;

namespace ns215;

internal class Class7485 : Class7458
{
	internal static readonly Type type_0 = typeof(Class5809);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => Class7552.type_0;

	public override void Initialize()
	{
		method_11("{default}", Enum983.flag_0 | Enum983.flag_1);
		method_11("anchorType", Enum983.flag_0 | Enum983.flag_1);
		method_11("colSpan", Enum983.flag_0 | Enum983.flag_1);
		method_11("h", Enum983.flag_0 | Enum983.flag_1);
		method_11("hAlign", Enum983.flag_0 | Enum983.flag_1);
		method_11("locale", Enum983.flag_0 | Enum983.flag_1);
		method_11("maxH", Enum983.flag_0 | Enum983.flag_1);
		method_11("maxW", Enum983.flag_0 | Enum983.flag_1);
		method_11("minH", Enum983.flag_0 | Enum983.flag_1);
		method_11("minW", Enum983.flag_0 | Enum983.flag_1);
		method_11("presence", Enum983.flag_0 | Enum983.flag_1);
		method_11("rawValue", Enum983.flag_0 | Enum983.flag_1);
		method_11("relevant", Enum983.flag_0 | Enum983.flag_1);
		method_11("rotate", Enum983.flag_0 | Enum983.flag_1);
		method_11("use", Enum983.flag_0 | Enum983.flag_1);
		method_11("usehref", Enum983.flag_0 | Enum983.flag_1);
		method_11("vAlign", Enum983.flag_0 | Enum983.flag_1);
		method_11("w", Enum983.flag_0 | Enum983.flag_1);
		method_11("x", Enum983.flag_0 | Enum983.flag_1);
		method_11("y", Enum983.flag_0 | Enum983.flag_1);
		method_11("rawValue", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class5809 @class = (Class5809)instance.Value;
		switch (function)
		{
		case "set_{default}":
		case "set_rawValue":
			@class.Value = parameters[0].ToString();
			return base.Undefined;
		case "get_{default}":
		case "get_rawValue":
			if (@class.Value != null)
			{
				return method_3(@class.Value);
			}
			return base.Null;
		default:
			return base.vmethod_1(function, instance, parameters);
		}
	}
}
