using System.Runtime.CompilerServices;

namespace ns52;

internal class Class1136
{
	private ushort ushort_0;

	private Enum183 enum183_0;

	private object object_0;

	internal Class1136(ushort ushort_1, Enum183 enum183_1, object object_1)
	{
		ushort_0 = ushort_1;
		object_0 = object_1;
		enum183_0 = enum183_1;
	}

	[SpecialName]
	internal bool method_0()
	{
		return (ushort_0 & 0x8000) != 0;
	}

	[SpecialName]
	internal ushort method_1()
	{
		return ushort_0;
	}

	[SpecialName]
	internal Enum183 method_2()
	{
		return enum183_0;
	}

	[SpecialName]
	internal void method_3(Enum183 enum183_1)
	{
		enum183_0 = enum183_1;
	}

	[SpecialName]
	internal object method_4()
	{
		return object_0;
	}

	[SpecialName]
	internal void method_5(object object_1)
	{
		object_0 = object_1;
	}
}
