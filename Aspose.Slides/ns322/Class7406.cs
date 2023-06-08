namespace ns322;

internal abstract class Class7406 : Class7400
{
	private Interface401 interface401_0;

	public Interface401 Global => interface401_0;

	public abstract void vmethod_26(Interface401 global);

	public Class7406(Interface401 global)
		: base(global)
	{
		interface401_0 = global;
	}

	protected Class7406(Interface401 global, Class7399 prototype)
		: base(prototype)
	{
		interface401_0 = global;
	}
}
