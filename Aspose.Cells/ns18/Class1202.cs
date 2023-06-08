using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1202 : Class1201
{
	private Size size_0;

	internal override Image Image => null;

	internal override int Width => size_0.Width;

	internal override int Height => size_0.Height;

	public Class1202(byte[] byte_2, Size size_1)
	{
		size_0 = size_1;
		byte_0 = byte_2;
	}

	[SpecialName]
	internal override int vmethod_0()
	{
		return 8;
	}

	[SpecialName]
	internal override Class1439 vmethod_1()
	{
		return Class1439.smethod_1();
	}

	[SpecialName]
	internal override bool vmethod_2()
	{
		return false;
	}

	[SpecialName]
	internal override bool vmethod_3()
	{
		return false;
	}
}
