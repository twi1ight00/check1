using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7623 : Class7456
{
	private static readonly Type type_0 = typeof(Class7011);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("cols", Enum983.flag_0 | Enum983.flag_1);
		method_11("rows", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7011 @class = (Class7011)instance.Value;
		switch (function)
		{
		case "set_rows":
			@class.Rows = parameters[0].ToString();
			goto IL_0070;
		case "get_rows":
			return method_3(@class.Rows);
		case "set_cols":
			@class.Cols = parameters[0].ToString();
			goto IL_0070;
		default:
			throw new Exception89("unknown function");
		case "get_cols":
			{
				return method_3(@class.Cols);
			}
			IL_0070:
			return base.Undefined;
		}
	}
}
