using System;
using ns322;
using ns323;
using ns73;

namespace ns326;

internal class Class7578 : Class7456
{
	private static readonly Type type_0 = typeof(Interface64);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Interface59);

	public override void Initialize()
	{
		method_11("encoding", Enum983.flag_0 | Enum983.flag_1);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Interface64 @interface = (Interface64)instance.Value;
		switch (function)
		{
		case "set_encoding":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			@interface.Encoding = parameters[0].ToString();
			return base.Undefined;
		default:
			throw new Exception89("unknown function");
		case "get_encoding":
			return method_3(@interface.Encoding);
		}
	}
}
