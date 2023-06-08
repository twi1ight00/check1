using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7664 : Class7456
{
	private static readonly Type type_0 = typeof(Class7075);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_10("item");
		method_11("length", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7075 @class = (Class7075)instance.Value;
		switch (function)
		{
		case "get_length":
			return method_5(@class.Length);
		case "item":
		{
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class6976 class2 = @class[parameters[0].vmethod_4()];
			if (class2 == null)
			{
				return base.Undefined;
			}
			return method_2(class2, class2.GetType());
		}
		default:
			throw new Exception89("unknown function");
		}
	}
}
