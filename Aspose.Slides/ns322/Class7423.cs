using System;

namespace ns322;

internal class Class7423 : Class7400
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
			if (!(parameters[1] is Class7399 @class))
			{
				throw new Exception88(visitor.Global.TypeErrorClass.method_4("second argument must be an array"));
			}
			array = new Class7397[@class.Length];
			for (int i = 0; i < @class.Length; i++)
			{
				array[i] = @class[i.ToString()];
			}
		}
		else
		{
			array = Class7397.class7397_0;
		}
		visitor.imethod_37(function, @this, array);
		return visitor.Result;
	}

	public Class7423(Class7412 constructor)
		: base(constructor.PrototypeProperty)
	{
		method_0("length", constructor.Global.NumberClass.method_4(2.0), Enum988.flag_1);
	}
}
