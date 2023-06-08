namespace ns322;

internal class Class7404 : Class7400
{
	private Interface401 interface401_0;

	public Class7397 method_4(Class7398 target, Class7397[] parameters)
	{
		return interface401_0.StringClass.method_5(string.Concat(target["name"], ": ", target["message"]));
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		Class7397 result;
		if (string_21 == "toString")
		{
			result = method_4(that, parameters);
		}
		else
		{
			if (!(string_21 == "toLocaleString"))
			{
				throw new Exception89("unknown error function");
			}
			result = method_4(that, parameters);
		}
		visitor.imethod_36(result);
		return result;
	}

	public override string ToString()
	{
		return $"function {base.Name}";
	}

	public Class7404(Interface401 global, string name, Class7399 prototype)
		: base(prototype)
	{
		string_21 = name;
		interface401_0 = global;
	}
}
