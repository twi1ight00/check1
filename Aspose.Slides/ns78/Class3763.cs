using ns73;
using ns74;
using ns77;

namespace ns78;

internal class Class3763 : Class3739
{
	private float float_0;

	public Class3763(string feature, Class3679 argument)
		: base(feature, argument)
	{
		float_0 = ((Class3684)argument).vmethod_1(18);
	}

	public override bool imethod_0(Class3677 device)
	{
		return device.Resolution.Value >= float_0;
	}
}
