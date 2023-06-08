using ns73;

namespace ns77;

internal class Class3738 : Class3737
{
	private Interface80 interface80_0;

	private Interface80 interface80_1;

	public override string Text => interface80_0.Text + " AND " + interface80_1.Text;

	public Class3738(Interface80 left, Interface80 rigth)
	{
		interface80_0 = left;
		interface80_1 = rigth;
	}

	public override bool imethod_0(Class3677 device)
	{
		if (interface80_0.imethod_0(device))
		{
			return interface80_1.imethod_0(device);
		}
		return false;
	}
}
