using System;
using ns287;
using ns306;
using ns322;
using ns323;

namespace ns327;

internal class Class7619 : Class7456
{
	private static readonly Type type_0 = typeof(Class7007);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class6982);

	public override void Initialize()
	{
		method_11("form", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Class7007 @class = (Class7007)instance.Value;
		string text;
		if ((text = function) == null || !(text == "get_form"))
		{
			throw new Exception89("unknown function");
		}
		return method_2(@class.Form, typeof(Class7009));
	}
}
