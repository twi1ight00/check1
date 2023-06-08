using ns59;

namespace ns27;

internal class Class705 : Class538
{
	private byte[] byte_1;

	internal Class705()
	{
		method_2(144);
	}

	internal override void vmethod_0(Class1725 class1725_0)
	{
		base.vmethod_0(class1725_0);
		if (byte_1 != null)
		{
			class1725_0.method_8(512);
			class1725_0.method_7((short)byte_1.Length);
			class1725_0.method_3(byte_1);
		}
	}
}
