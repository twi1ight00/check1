using System;
using ns305;
using ns322;
using ns323;
using ns73;

namespace ns326;

internal class Class7560 : Class7456
{
	private static readonly Type type_0 = typeof(Interface56);

	private Class3699 class3699_0;

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_10("getComputedStyle");
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Interface56 @interface = (Interface56)instance.Value;
		string text;
		if ((text = function) != null && text == "getComputedStyle")
		{
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			Interface58 interface2 = @interface.imethod_0((Class6981)parameters[0].vmethod_5(), parameters[1].ToString());
			if (class3699_0 == null || (class3699_0 != null && class3699_0.StyleDeclaration != interface2))
			{
				class3699_0 = new Class3699(interface2);
			}
			return method_2(class3699_0, typeof(Interface57));
		}
		throw new Exception89("unknown function");
	}
}
