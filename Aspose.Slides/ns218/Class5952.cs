using System;

namespace ns218;

internal static class Class5952
{
	public static int smethod_0(int value)
	{
		return (int)smethod_1((uint)value);
	}

	[CLSCompliant(false)]
	public static uint smethod_1(uint value)
	{
		return ((value & 0xFF) << 24) | ((value & 0xFF00) << 8) | ((value & 0xFF0000) >> 8) | ((value & 0xFF000000u) >> 24);
	}

	public static short smethod_2(short value)
	{
		return (short)smethod_3((ushort)value);
	}

	[CLSCompliant(false)]
	public static ushort smethod_3(ushort value)
	{
		return (ushort)(((value & 0xFF) << 8) | ((value & 0xFF00) >> 8));
	}

	public static int smethod_4(int curValue, int bitMask, bool newValue)
	{
		if (newValue)
		{
			return curValue | bitMask;
		}
		return curValue & ~bitMask;
	}

	public static bool smethod_5(int curValue, int bitMask)
	{
		return (curValue & bitMask) != 0;
	}

	public static int smethod_6(int curValue, int bitMask)
	{
		return curValue ^ bitMask;
	}

	public static int smethod_7(int i)
	{
		i = (i & 0x55555555) + ((i >> 1) & 0x55555555);
		i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
		i = (i & 0xF0F0F0F) + ((i >> 4) & 0xF0F0F0F);
		i = (i & 0xFF00FF) + ((i >> 8) & 0xFF00FF);
		i = (i & 0xFFFF) + ((i >> 16) & 0xFFFF);
		return i;
	}

	public static int smethod_8(long i)
	{
		i = (i & 0x5555555555555555L) + ((i >> 1) & 0x5555555555555555L);
		i = (i & 0x3333333333333333L) + ((i >> 2) & 0x3333333333333333L);
		i = (i & 0xF0F0F0F0F0F0F0FL) + ((i >> 4) & 0xF0F0F0F0F0F0F0FL);
		i = (i & 0xFF00FF00FF00FFL) + ((i >> 8) & 0xFF00FF00FF00FFL);
		i = (i & 0xFFFF0000FFFFL) + ((i >> 16) & 0xFFFF0000FFFFL);
		i = (i & 0xFFFFFFFFL) + ((i >> 32) & 0xFFFFFFFFL);
		return (int)i;
	}
}
