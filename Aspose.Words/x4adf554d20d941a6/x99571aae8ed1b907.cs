using System;

namespace x4adf554d20d941a6;

internal class x99571aae8ed1b907
{
	internal const int x236cb0a4295bc034 = 0;

	internal const int x408f4b7efc86fd49 = 1;

	internal const int xc3819e13f60dd8e6 = 2;

	private const int xe1f05eae06081ed5 = 2;

	private const int xe6d27ba37fa97acc = 3;

	private const int xac9fc0a08a154a9d = 16;

	private int x4574aea041dd835f;

	internal bool xb8b2811ae16070e4 => x3f88a25febd23896(0) == 2;

	internal bool x7c63eb25ab9ec93b => x3f88a25febd23896(0) == 1;

	internal bool xe7690ed0fb0045a8
	{
		get
		{
			for (int num = x4574aea041dd835f; num != 0; num >>= 2)
			{
				if (2 != (num & 3))
				{
					return false;
				}
			}
			return 0 != x4574aea041dd835f;
		}
	}

	private bool x752cfab9af626fd5 => xd44988f225497f3a > 1;

	private int xd44988f225497f3a
	{
		get
		{
			int i;
			for (i = 0; i < 32 && x4574aea041dd835f >> i * 2 != 0; i++)
			{
			}
			return i;
		}
	}

	internal void x1914eddf1fde1228(int x4ae3aef7c573c0c7)
	{
		if (x4574aea041dd835f >> 31 != 0)
		{
			throw new InvalidOperationException("The stack is full.");
		}
		x4ae3aef7c573c0c7 = (x4ae3aef7c573c0c7 & 3) + 1;
		if (x4ae3aef7c573c0c7 > 3)
		{
			throw new ArgumentOutOfRangeException("reflowState");
		}
		x4574aea041dd835f <<= 2;
		x4574aea041dd835f |= x4ae3aef7c573c0c7;
	}

	internal int x47c79a4d207183de()
	{
		if (x4574aea041dd835f == 0)
		{
			throw new InvalidOperationException("The stack is empty.");
		}
		int result = x3f88a25febd23896(0);
		x4574aea041dd835f >>= 2;
		return result;
	}

	private int x3f88a25febd23896(int xc0c4c459c6ccbd00)
	{
		return ((x4574aea041dd835f >> xc0c4c459c6ccbd00 * 2) & 3) - 1;
	}
}
