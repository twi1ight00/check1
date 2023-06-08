using ns322;

namespace ns323;

internal class Class7405 : Class7400
{
	private Interface401 interface401_0;

	private Delegate2787 delegate2787_0;

	public Class7405(Interface401 global, string name, Class7399 prototype, Delegate2787 execute)
		: base(prototype)
	{
		interface401_0 = global;
		string_21 = name;
		delegate2787_0 = execute;
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		Class7397 result = delegate2787_0(string_21, that, parameters);
		visitor.imethod_36(result);
		return result;
	}
}
