using System;
using ns305;
using ns322;
using ns323;
using ns73;

namespace ns326;

internal class Class7566 : Class7456
{
	private static readonly Type type_0 = typeof(Interface88);

	protected internal override Type Type => type_0;

	protected override Type InheritedType => typeof(Interface87);

	public override void Initialize()
	{
		method_10("getOverrideStyle");
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Interface88 @interface = (Interface88)instance.Value;
		string text;
		if ((text = function) != null && text == "getOverrideStyle")
		{
			if (parameters.Length != 2)
			{
				throw new Exception89("invalid arguments count.");
			}
			return method_2(@interface.imethod_1((Class6981)parameters[0].vmethod_5(), parameters[1].ToString()), typeof(Interface58));
		}
		throw new Exception89("unknown function");
	}
}
