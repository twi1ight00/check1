using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7666 : Class7456
{
	private static readonly Type type_0 = typeof(Class7053);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6976);

	public override void Initialize()
	{
		method_11("target", Enum983.flag_0);
		method_11("data", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7053 @class = (Class7053)instance.Value;
		switch (function)
		{
		case "set_data":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			@class.Data = parameters[0].ToString();
			return base.Undefined;
		case "get_data":
			return method_3(@class.Data);
		default:
			throw new Exception89("unknown function");
		case "get_target":
			return method_3(@class.Target);
		}
	}
}
