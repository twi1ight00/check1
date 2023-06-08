using ns73;

namespace ns77;

internal class Class3768 : Class3737
{
	private Interface80 interface80_0;

	public override string Text => "NOT " + interface80_0.Text;

	public Class3768(Interface80 expression)
	{
		interface80_0 = expression;
	}

	public override bool imethod_0(Class3677 device)
	{
		return !interface80_0.imethod_0(device);
	}
}
