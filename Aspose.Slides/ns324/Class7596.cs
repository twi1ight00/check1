using System;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7596 : Class7456
{
	private static readonly Type type_0 = typeof(Interface373);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_10("handleError");
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Interface373 @interface = (Interface373)instance.Value;
		string text;
		if ((text = function) != null && text == "handleError")
		{
			if (parameters.Length != 1)
			{
				throw new Exception89("invalid arguments count.");
			}
			Class7086 error = (Class7086)parameters[0].Value;
			return method_6(@interface.imethod_0(error));
		}
		throw new Exception89("unknown function");
	}
}
