using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;

namespace ns52;

internal class Class1713
{
	private int int_0 = 1025;

	private int int_1 = 2560;

	private short short_0 = 4095;

	internal int Length => 8;

	internal Class1713(MsoDrawingType msoDrawingType_0, int int_2, int int_3)
	{
		int_0 = int_2;
		int_1 = int_3;
	}

	internal void Copy(Class1713 class1713_0)
	{
		short_0 = class1713_0.short_0;
		int_1 = class1713_0.int_1;
	}

	[SpecialName]
	internal int method_0()
	{
		return short_0;
	}

	[SpecialName]
	internal void method_1(int int_2)
	{
		short_0 = (short)int_2;
	}

	[SpecialName]
	internal int method_2()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_3(int int_2)
	{
		int_0 = int_2;
	}

	[SpecialName]
	internal int method_4()
	{
		return int_1;
	}

	[SpecialName]
	internal void method_5(int int_2)
	{
		int_1 = int_2;
	}

	[SpecialName]
	internal void method_6(bool bool_0)
	{
		int_1 &= -2;
		int_1 |= (bool_0 ? 1 : 0);
	}

	[SpecialName]
	internal void method_7(bool bool_0)
	{
		int_1 &= -3;
		int_1 |= (bool_0 ? 2 : 0);
	}

	[SpecialName]
	internal void method_8(bool bool_0)
	{
		int_1 &= -17;
		int_1 |= (bool_0 ? 16 : 0);
	}

	[SpecialName]
	public bool method_9()
	{
		return (int_1 & 0x80) != 0;
	}

	[SpecialName]
	public void method_10(bool bool_0)
	{
		int_1 &= -129;
		int_1 |= (bool_0 ? 128 : 0);
	}

	[SpecialName]
	public bool method_11()
	{
		return (int_1 & 0x40) != 0;
	}

	[SpecialName]
	public void method_12(bool bool_0)
	{
		int_1 &= -65;
		int_1 |= (bool_0 ? 64 : 0);
	}
}
