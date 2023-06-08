using ns73;
using ns77;

namespace ns78;

internal class Class3748 : Class3739
{
	private float float_0;

	private float float_1;

	public Class3748(string feature, Class3679 argument)
		: base(feature, argument)
	{
		if (argument is Class3691 @class)
		{
			float_0 = ((Class3680)@class[0]).vmethod_1(1);
			float_1 = ((Class3680)@class[2]).vmethod_1(1);
		}
	}

	public override bool imethod_0(Class3677 device)
	{
		return float_0 / float_1 == (float)device.ScreenSize.Width / (float)device.ScreenSize.Height;
	}
}
