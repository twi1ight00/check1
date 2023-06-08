using System;

namespace ns322;

internal class Class7418 : Class7400
{
	private Interface401 interface401_0;

	private Random random_0 = new Random();

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		Class7397 result;
		if (string_21 == "abs")
		{
			result = interface401_0.NumberClass.method_4(Math.Abs(parameters[0].vmethod_3()));
		}
		else if (string_21 == "asin")
		{
			result = interface401_0.NumberClass.method_4(Math.Asin(parameters[0].vmethod_3()));
		}
		else if (string_21 == "atan")
		{
			result = interface401_0.NumberClass.method_4(Math.Atan(parameters[0].vmethod_3()));
		}
		else if (string_21 == "atan2")
		{
			result = interface401_0.NumberClass.method_4(Math.Atan2(parameters[0].vmethod_3(), parameters[1].vmethod_3()));
		}
		else if (string_21 == "ceil")
		{
			result = interface401_0.NumberClass.method_4(Math.Ceiling(parameters[0].vmethod_3()));
		}
		else if (string_21 == "cos")
		{
			result = interface401_0.NumberClass.method_4(Math.Cos(parameters[0].vmethod_3()));
		}
		else if (string_21 == "exp")
		{
			result = interface401_0.NumberClass.method_4(Math.Exp(parameters[0].vmethod_3()));
		}
		else if (string_21 == "floor")
		{
			result = interface401_0.NumberClass.method_4(Math.Floor(parameters[0].vmethod_3()));
		}
		else if (string_21 == "log")
		{
			result = interface401_0.NumberClass.method_4(Math.Log(parameters[0].vmethod_3()));
		}
		else if (string_21 == "max")
		{
			result = interface401_0.NumberClass.method_4(Math.Max(parameters[0].vmethod_3(), parameters[1].vmethod_3()));
		}
		else if (string_21 == "min")
		{
			result = interface401_0.NumberClass.method_4(Math.Min(parameters[0].vmethod_3(), parameters[1].vmethod_3()));
		}
		else if (string_21 == "pow")
		{
			result = interface401_0.NumberClass.method_4(Math.Pow(parameters[0].vmethod_3(), parameters[1].vmethod_3()));
		}
		else if (string_21 == "random")
		{
			result = interface401_0.NumberClass.method_4(random_0.NextDouble());
		}
		else if (string_21 == "round")
		{
			result = interface401_0.NumberClass.method_4(Math.Round(parameters[0].vmethod_3()));
		}
		else if (string_21 == "sin")
		{
			result = interface401_0.NumberClass.method_4(Math.Sin(parameters[0].vmethod_3()));
		}
		else if (string_21 == "sqrt")
		{
			result = interface401_0.NumberClass.method_4(Math.Sqrt(parameters[0].vmethod_3()));
		}
		else
		{
			if (!(string_21 == "tan"))
			{
				throw new Exception89("unknown math function");
			}
			result = interface401_0.NumberClass.method_4(Math.Tan(parameters[0].vmethod_3()));
		}
		visitor.imethod_36(result);
		return result;
	}

	public override string ToString()
	{
		return $"function {base.Name}";
	}

	public Class7418(Interface401 global, string name, Class7399 prototype)
		: base(prototype)
	{
		string_21 = name;
		interface401_0 = global;
	}
}
