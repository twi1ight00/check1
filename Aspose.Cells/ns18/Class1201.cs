using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns18;

internal abstract class Class1201
{
	protected byte[] byte_0;

	protected byte[] byte_1;

	protected Color[] color_0;

	internal abstract Image Image { get; }

	internal abstract int Width { get; }

	internal abstract int Height { get; }

	[SpecialName]
	internal abstract int vmethod_0();

	[SpecialName]
	internal abstract Class1439 vmethod_1();

	[SpecialName]
	internal byte[] method_0()
	{
		return byte_0;
	}

	[SpecialName]
	internal byte[] method_1()
	{
		return byte_1;
	}

	[SpecialName]
	internal Color[] method_2()
	{
		return color_0;
	}

	[SpecialName]
	internal abstract bool vmethod_2();

	[SpecialName]
	internal abstract bool vmethod_3();
}
