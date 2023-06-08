using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7667 : Class7456
{
	private static readonly Type type_0 = typeof(Class6980);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6977);

	public override void Initialize()
	{
		method_10("splitText");
		method_10("replaceWholeText");
		method_11("elementContentWhitespace", Enum983.flag_0);
		method_11("wholeText", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class6980 @class = (Class6980)instance.Value;
		switch (function)
		{
		case "replaceWholeText":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_21(parameters[0].ToString()), typeof(Class6980));
		case "get_wholeText":
			return method_3(@class.WholeText);
		case "get_elementContentWhitespace":
			return method_6(@class.IsElementContentWhitespace);
		case "splitText":
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@class.method_20(parameters[0].vmethod_4()), typeof(Class6980));
		default:
			throw new Exception89("unknown function");
		}
	}
}
