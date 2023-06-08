using System;
using System.Globalization;
using ns216;
using ns217;
using ns322;
using ns323;

namespace ns215;

internal class Class7551 : Class7457
{
	internal static readonly Type type_0 = typeof(Class5875);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => Class7552.type_0;

	public override void Initialize()
	{
		method_11("{default}", Enum983.flag_0 | Enum983.flag_1);
		method_11("use", Enum983.flag_0 | Enum983.flag_1);
		method_11("usehref", Enum983.flag_0 | Enum983.flag_1);
		method_11("value", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class5875 @class = (Class5875)instance.Value;
		switch (function)
		{
		case "get_{default}":
			return method_5(@class.Value);
		case "set_{default}":
			@class.Value = (int)parameters[0].vmethod_3();
			break;
		case "get_use":
			return method_3(@class.Use);
		case "set_use":
			@class.Use = parameters[0].ToString();
			break;
		case "get_usehref":
			return method_3(@class.Usehref);
		case "set_usehref":
			@class.Usehref = parameters[0].ToString();
			break;
		case "get_value":
			return method_3(@class.Value.ToString(CultureInfo.InvariantCulture));
		case "set_value":
			@class.Value = int.Parse(parameters[0].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture);
			break;
		default:
			throw new Exception89("unknown function");
		}
		return base.Undefined;
	}
}
