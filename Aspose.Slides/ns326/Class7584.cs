using System;
using ns305;
using ns322;
using ns323;
using ns73;

namespace ns326;

internal class Class7584 : Class7456
{
	private static readonly Type type_0 = typeof(Interface63);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Class7097);

	public override void Initialize()
	{
		method_10("createCSSStyleSheet");
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Interface63 @interface = (Interface63)instance.Value;
		string text;
		if ((text = function) != null && text == "createCSSStyleSheet")
		{
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@interface.imethod_0(parameters[0].ToString(), parameters[1].ToString()), typeof(Interface76));
		}
		throw new Exception89("unknown function");
	}
}
