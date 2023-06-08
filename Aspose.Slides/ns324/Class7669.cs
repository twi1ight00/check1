using System;
using Aspose.HTML.DOM.Core;
using ns305;
using ns322;
using ns323;

namespace ns324;

internal class Class7669 : Class7456
{
	private static readonly Type type_0 = typeof(Interface374);

	protected internal override Type Type => type_0;

	public override void Initialize()
	{
		method_10("handle");
	}

	protected override Class7397 vmethod_1(string function, Class7397 instance, Class7397[] parameters)
	{
		Interface374 @interface = (Interface374)instance.Value;
		string text;
		if ((text = function) != null && text == "handle")
		{
			if (parameters.Length != 5)
			{
				throw new Exception89("invalid arguments count.");
			}
			@interface.imethod_0((OperationType)parameters[0].vmethod_5(), parameters[1].ToString(), parameters[2].vmethod_5(), (Class6976)parameters[3].vmethod_5(), (Class6976)parameters[4].vmethod_5());
			return base.Undefined;
		}
		throw new Exception89("unknown function");
	}
}
