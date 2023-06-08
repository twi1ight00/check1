using System;
using System.IO;

namespace x6c95d9cf46ff5f25;

internal class x05cddb129b0360cd
{
	private const int x648114bcf1499890 = 8;

	private readonly BinaryReader x7450cc1e48712286;

	private readonly bool x8cab777b43454dac;

	private byte x4348c96b3a2259b3;

	private int xdcfcd58ee214ec54;

	public x05cddb129b0360cd(Stream stream, bool useMsbFirstBitOrdering)
	{
		x7450cc1e48712286 = new BinaryReader(stream);
		x4348c96b3a2259b3 = 0;
		xdcfcd58ee214ec54 = 0;
		x8cab777b43454dac = useMsbFirstBitOrdering;
	}

	public bool xa1e7dc86736d5ffd()
	{
		if (xdcfcd58ee214ec54 == 0)
		{
			x4348c96b3a2259b3 = x7450cc1e48712286.ReadByte();
		}
		bool result = x0be307be62f48285();
		xdcfcd58ee214ec54++;
		if (xdcfcd58ee214ec54 == 8)
		{
			xdcfcd58ee214ec54 = 0;
		}
		return result;
	}

	public long x59692b33f32fe96f(int x961016a387451f05)
	{
		if (!x8cab777b43454dac)
		{
			throw new NotSupportedException("Reading LSB ordered values is not supported.");
		}
		switch (x961016a387451f05)
		{
		default:
			throw new ArgumentOutOfRangeException("length");
		case 0:
			return 0L;
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
		case 20:
		case 21:
		case 22:
		case 23:
		case 24:
		case 25:
		case 26:
		case 27:
		case 28:
		case 29:
		case 30:
		case 31:
		case 32:
		case 33:
		case 34:
		case 35:
		case 36:
		case 37:
		case 38:
		case 39:
		case 40:
		case 41:
		case 42:
		case 43:
		case 44:
		case 45:
		case 46:
		case 47:
		case 48:
		case 49:
		case 50:
		case 51:
		case 52:
		case 53:
		case 54:
		case 55:
		case 56:
		case 57:
		case 58:
		case 59:
		case 60:
		case 61:
		case 62:
		case 63:
		{
			long num = 0L;
			long num2 = 1 << x961016a387451f05 - 1;
			for (int i = 0; i < x961016a387451f05; i++)
			{
				num += (xa1e7dc86736d5ffd() ? num2 : 0);
				num2 >>= 1;
			}
			return num;
		}
		}
	}

	private bool x0be307be62f48285()
	{
		return x26000ce44ebda9ea.xf7735b522c02eb76(x4348c96b3a2259b3, xf5a8240e9bde3439());
	}

	private static long xfcd92fe8fb3b9dc7(int x13d4cb8d1bd20347, int xd03ef5cc33a198ba, bool xa965f4caa65ff7bc)
	{
		long num = ((!xa965f4caa65ff7bc) ? 1 : (1 << xd03ef5cc33a198ba - 1));
		for (int i = 0; i < x13d4cb8d1bd20347; i++)
		{
			num = (xa965f4caa65ff7bc ? (num >> 1) : (num << 1));
		}
		return num;
	}

	private byte xf5a8240e9bde3439()
	{
		return (byte)xfcd92fe8fb3b9dc7(xdcfcd58ee214ec54, 8, x8cab777b43454dac);
	}
}
