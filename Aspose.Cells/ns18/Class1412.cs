using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1412 : Interface46
{
	private Class1431[] class1431_0;

	private uint uint_0;

	internal Class1412()
	{
	}

	internal void method_0(Class1420 class1420_0)
	{
		uint_0 = class1420_0.ReadUInt32();
		class1420_0.ReadInt16();
		int num = class1420_0.ReadInt16();
		class1431_0 = new Class1431[num];
		for (int i = 0; i < num; i++)
		{
			class1431_0[i] = new Class1431();
			class1431_0[i].method_0(class1420_0.ReadByte());
			class1431_0[i].method_1(class1420_0.ReadByte());
			class1431_0[i].method_2(class1420_0.ReadByte());
			class1431_0[i].method_3((Enum166)class1420_0.ReadByte());
		}
	}

	[SpecialName]
	public uint imethod_0()
	{
		return uint_0;
	}

	[SpecialName]
	public void imethod_1(uint uint_1)
	{
		uint_0 = uint_1;
	}

	[SpecialName]
	Enum203 Interface46.get_Type()
	{
		return Enum203.const_10;
	}
}
