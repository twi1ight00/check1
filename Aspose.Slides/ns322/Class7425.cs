namespace ns322;

internal class Class7425 : Class7400
{
	private Interface401 interface401_0;

	public Class7425(Interface401 global)
		: base(global)
	{
		interface401_0 = global;
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		switch (parameters[0]._Class)
		{
		case "Boolean":
			visitor.imethod_36(interface401_0.NumberClass.method_4(parameters[0].vmethod_2().CompareTo(parameters[1].vmethod_2())));
			return Class7437.class7437_0;
		case "Number":
			visitor.imethod_36(interface401_0.NumberClass.method_4(parameters[0].vmethod_3().CompareTo(parameters[1].vmethod_3())));
			return Class7437.class7437_0;
		case "String":
			visitor.imethod_36(interface401_0.NumberClass.method_4(parameters[0].ToString().CompareTo(parameters[1].ToString())));
			return Class7437.class7437_0;
		default:
			return base.vmethod_25(visitor, that, parameters);
		}
	}
}
