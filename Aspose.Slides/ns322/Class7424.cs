using System;

namespace ns322;

internal class Class7424 : Class7400
{
	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		if (!(that is Class7400 function))
		{
			throw new ArgumentException("the target of call() must be a function");
		}
		Class7398 @this = ((parameters.Length < 1 || parameters[0] == Class7437.class7437_0 || parameters[0] == Class7433.class7433_0) ? (visitor.Global as Class7398) : (parameters[0] as Class7398));
		Class7397[] array;
		if (parameters.Length >= 2 && parameters[1] != Class7433.class7433_0)
		{
			array = new Class7397[parameters.Length - 1];
			for (int i = 1; i < parameters.Length; i++)
			{
				array[i - 1] = parameters[i];
			}
		}
		else
		{
			array = Class7397.class7397_0;
		}
		visitor.imethod_37(function, @this, array);
		return visitor.Result;
	}

	public Class7424(Class7412 constructor)
		: base(constructor.PrototypeProperty)
	{
		method_0("length", constructor.Global.NumberClass.method_4(1.0), Enum988.flag_1);
	}
}
