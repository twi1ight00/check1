using System;
using ns322;
using ns323;

namespace ns217;

internal class Class7557 : Class7456
{
	internal static readonly Type type_0 = typeof(object);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_11("className", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class5779 @class = (Class5779)instance.Value;
		string text;
		if ((text = function) == null || !(text == "get_className"))
		{
			throw new Exception89("unknown function");
		}
		return method_3(@class.ClassName);
	}
}
