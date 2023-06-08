using System.Runtime.CompilerServices;

namespace ns42;

internal class Class971
{
	private static int int_0;

	private static bool bool_0;

	private static int int_1;

	static Class971()
	{
		Clear();
	}

	internal static void Clear()
	{
		int_0 = 48;
		bool_0 = true;
		int_1 = 0;
	}

	internal static int smethod_0()
	{
		if (int_0 == 128 && !bool_0)
		{
			return 256;
		}
		return 4096;
	}

	[SpecialName]
	internal static int smethod_1()
	{
		return int_1;
	}

	[SpecialName]
	internal static void smethod_2(int int_2)
	{
		int_1 = int_2;
	}

	[SpecialName]
	internal static int smethod_3()
	{
		return int_0;
	}

	[SpecialName]
	internal static void smethod_4(int int_2)
	{
		int_0 = int_2;
	}

	[SpecialName]
	internal static void smethod_5(bool bool_1)
	{
		bool_0 = bool_1;
	}
}
