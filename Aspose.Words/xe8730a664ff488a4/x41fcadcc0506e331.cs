using System.IO;
using Aspose;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal class x41fcadcc0506e331
{
	private const int x23e4ef428c1ba0cd = 8192;

	private long _x6d0b3ba2ab87aa92;

	private static uint[] x954d98efde4a3506;

	private uint _xebdf9276ee7bd9e1 = uint.MaxValue;

	public long x6d0b3ba2ab87aa92 => _x6d0b3ba2ab87aa92;

	public int x882f8c1265bb8e85 => (int)(~_xebdf9276ee7bd9e1);

	public int xe337ac19fd29a432(Stream xcdaeea7afaf570ff)
	{
		return x606387aa1913bb31(xcdaeea7afaf570ff, null);
	}

	public int x606387aa1913bb31(Stream xcdaeea7afaf570ff, Stream x9c13656d94fc62d0)
	{
		if (xcdaeea7afaf570ff == null)
		{
			throw new xd449352d3501c52f("The input stream must not be null.");
		}
		byte[] array = new byte[8192];
		int count = 8192;
		_x6d0b3ba2ab87aa92 = 0L;
		int num = xcdaeea7afaf570ff.Read(array, 0, count);
		x9c13656d94fc62d0?.Write(array, 0, num);
		_x6d0b3ba2ab87aa92 += num;
		while (num > 0)
		{
			x8ebfa48686a2fc0c(array, 0, num);
			num = xcdaeea7afaf570ff.Read(array, 0, count);
			x9c13656d94fc62d0?.Write(array, 0, num);
			_x6d0b3ba2ab87aa92 += num;
		}
		return (int)(~_xebdf9276ee7bd9e1);
	}

	public int x9ac874b331c22f88(int x2e0a4d00809b4df8, byte x8e8f6cc6a0756b05)
	{
		return _xb081c58442594882((uint)x2e0a4d00809b4df8, x8e8f6cc6a0756b05);
	}

	internal int _xb081c58442594882(uint x2e0a4d00809b4df8, byte x8e8f6cc6a0756b05)
	{
		return (int)(x954d98efde4a3506[(x2e0a4d00809b4df8 ^ x8e8f6cc6a0756b05) & 0xFF] ^ (x2e0a4d00809b4df8 >> 8));
	}

	public void x8ebfa48686a2fc0c(byte[] xe413319369b234aa, int x374ea4fe62468d0f, int x10f4d88af727adbc)
	{
		if (xe413319369b234aa == null)
		{
			throw new xd449352d3501c52f("The data buffer must not be null.");
		}
		for (int i = 0; i < x10f4d88af727adbc; i++)
		{
			int num = x374ea4fe62468d0f + i;
			_xebdf9276ee7bd9e1 = (_xebdf9276ee7bd9e1 >> 8) ^ x954d98efde4a3506[xe413319369b234aa[num] ^ (_xebdf9276ee7bd9e1 & 0xFF)];
		}
		_x6d0b3ba2ab87aa92 += x10f4d88af727adbc;
	}

	static x41fcadcc0506e331()
	{
		uint num = 3988292384u;
		x954d98efde4a3506 = new uint[256];
		for (uint num2 = 0u; num2 < 256; num2++)
		{
			uint num3 = num2;
			for (uint num4 = 8u; num4 != 0; num4--)
			{
				num3 = (((num3 & 1) != 1) ? (num3 >> 1) : ((num3 >> 1) ^ num));
			}
			x954d98efde4a3506[num2] = num3;
		}
	}
}
