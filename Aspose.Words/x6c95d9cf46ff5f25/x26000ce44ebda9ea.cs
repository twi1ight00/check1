namespace x6c95d9cf46ff5f25;

internal class x26000ce44ebda9ea
{
	private x26000ce44ebda9ea()
	{
	}

	public static long x12faa55b48ce2747(long xbcea506a33cf9111)
	{
		return ((xbcea506a33cf9111 & 0xFF) << 56) | ((xbcea506a33cf9111 & 0xFF00) << 40) | ((xbcea506a33cf9111 & 0xFF0000) << 24) | ((xbcea506a33cf9111 & 0xFF000000u) << 8) | ((xbcea506a33cf9111 & 0xFF00000000L) >> 8) | ((xbcea506a33cf9111 & 0xFF0000000000L) >> 24) | ((xbcea506a33cf9111 & 0xFF000000000000L) >> 40) | ((xbcea506a33cf9111 >> 56) & 0xFF);
	}

	public static int xc44c58d0078e5f2e(int xbcea506a33cf9111)
	{
		return (int)x539dc61123306a51((uint)xbcea506a33cf9111);
	}

	public static uint x539dc61123306a51(uint xbcea506a33cf9111)
	{
		return ((xbcea506a33cf9111 & 0xFF) << 24) | ((xbcea506a33cf9111 & 0xFF00) << 8) | ((xbcea506a33cf9111 & 0xFF0000) >> 8) | ((xbcea506a33cf9111 & 0xFF000000u) >> 24);
	}

	public static short xf3c41a4b1dccb1c1(short xbcea506a33cf9111)
	{
		return (short)xb26c35b8f72ab749((ushort)xbcea506a33cf9111);
	}

	public static ushort xb26c35b8f72ab749(ushort xbcea506a33cf9111)
	{
		return (ushort)(((xbcea506a33cf9111 & 0xFF) << 8) | ((xbcea506a33cf9111 & 0xFF00) >> 8));
	}

	public static int x5ef51986c8da8183(int xbf5a7e14ee8e42b9, int x5d2a6c6cedb75c5e, bool xed7e1b20b1a14b86)
	{
		if (xed7e1b20b1a14b86)
		{
			return xbf5a7e14ee8e42b9 | x5d2a6c6cedb75c5e;
		}
		return xbf5a7e14ee8e42b9 & ~x5d2a6c6cedb75c5e;
	}

	public static bool xf73042981b08c3f7(int xbf5a7e14ee8e42b9, int x5d2a6c6cedb75c5e)
	{
		return (xbf5a7e14ee8e42b9 & x5d2a6c6cedb75c5e) != 0;
	}

	public static bool x7bd02e5db572bb0e(uint xbf5a7e14ee8e42b9, uint x5d2a6c6cedb75c5e)
	{
		return (xbf5a7e14ee8e42b9 & x5d2a6c6cedb75c5e) != 0;
	}

	public static bool x3c25c5b87860f214(ushort xbf5a7e14ee8e42b9, ushort x5d2a6c6cedb75c5e)
	{
		return (xbf5a7e14ee8e42b9 & x5d2a6c6cedb75c5e) != 0;
	}

	public static bool xf7735b522c02eb76(byte xbf5a7e14ee8e42b9, byte x5d2a6c6cedb75c5e)
	{
		return (xbf5a7e14ee8e42b9 & x5d2a6c6cedb75c5e) != 0;
	}

	public static int x0c807056f6bea62e(int xbf5a7e14ee8e42b9, int x5d2a6c6cedb75c5e)
	{
		return xbf5a7e14ee8e42b9 ^ x5d2a6c6cedb75c5e;
	}

	public static int xca1bff78ae243f27(int x7b28e8a789372508)
	{
		x7b28e8a789372508 = (x7b28e8a789372508 & 0x55555555) + ((x7b28e8a789372508 >> 1) & 0x55555555);
		x7b28e8a789372508 = (x7b28e8a789372508 & 0x33333333) + ((x7b28e8a789372508 >> 2) & 0x33333333);
		x7b28e8a789372508 = (x7b28e8a789372508 & 0xF0F0F0F) + ((x7b28e8a789372508 >> 4) & 0xF0F0F0F);
		x7b28e8a789372508 = (x7b28e8a789372508 & 0xFF00FF) + ((x7b28e8a789372508 >> 8) & 0xFF00FF);
		x7b28e8a789372508 = (x7b28e8a789372508 & 0xFFFF) + ((x7b28e8a789372508 >> 16) & 0xFFFF);
		return x7b28e8a789372508;
	}

	public static int x6858b2d83f12ac81(long x7b28e8a789372508)
	{
		x7b28e8a789372508 = (x7b28e8a789372508 & 0x5555555555555555L) + ((x7b28e8a789372508 >> 1) & 0x5555555555555555L);
		x7b28e8a789372508 = (x7b28e8a789372508 & 0x3333333333333333L) + ((x7b28e8a789372508 >> 2) & 0x3333333333333333L);
		x7b28e8a789372508 = (x7b28e8a789372508 & 0xF0F0F0F0F0F0F0FL) + ((x7b28e8a789372508 >> 4) & 0xF0F0F0F0F0F0F0FL);
		x7b28e8a789372508 = (x7b28e8a789372508 & 0xFF00FF00FF00FFL) + ((x7b28e8a789372508 >> 8) & 0xFF00FF00FF00FFL);
		x7b28e8a789372508 = (x7b28e8a789372508 & 0xFFFF0000FFFFL) + ((x7b28e8a789372508 >> 16) & 0xFFFF0000FFFFL);
		x7b28e8a789372508 = (x7b28e8a789372508 & 0xFFFFFFFFu) + ((x7b28e8a789372508 >> 32) & 0xFFFFFFFFu);
		return (int)x7b28e8a789372508;
	}

	public static byte x668eca8c00199aa3(byte xe7ebe10fa44d8d49)
	{
		return (byte)((ulong)(((((long)xe7ebe10fa44d8d49 * 2050L) & 0x22110) | (((long)xe7ebe10fa44d8d49 * 32800L) & 0x88440)) * 65793) >> 16);
	}
}
