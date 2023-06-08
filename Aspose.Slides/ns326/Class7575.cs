using System;
using ns322;
using ns323;
using ns73;

namespace ns326;

internal class Class7575 : Class7456
{
	private static readonly Type type_0 = typeof(Interface60);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Interface59);

	public override void Initialize()
	{
		method_11("style", Enum983.flag_0);
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Interface60 @interface = (Interface60)instance.Value;
		string text;
		if ((text = function) == null || !(text == "get_style"))
		{
			throw new Exception89("unknown function");
		}
		return method_2(@interface.Style, typeof(Interface58));
	}
}
