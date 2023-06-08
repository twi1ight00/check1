using x6c95d9cf46ff5f25;

namespace x2182451cabb5c30d;

internal class x2dce569e9052de2d
{
	private readonly string x4093e041a32c0256;

	private int xa3f9b2fd98264390;

	internal x2dce569e9052de2d(string inputString)
	{
		x4093e041a32c0256 = inputString;
	}

	internal short x2e6b89ad8001e18f()
	{
		int num = 0;
		num |= x672ed37ee25c078c() & 0xFF;
		num |= x672ed37ee25c078c() << 8;
		return (short)num;
	}

	internal int x95ea7d23cc8ee04d()
	{
		int num = 0;
		num |= x672ed37ee25c078c() & 0xFF;
		num |= x672ed37ee25c078c() << 8;
		num |= x672ed37ee25c078c() << 16;
		return num | (x672ed37ee25c078c() << 24);
	}

	internal byte x672ed37ee25c078c()
	{
		byte b = 0;
		b = (byte)(b | (byte)(xac9063cb41572910() << 4));
		return (byte)(b | (byte)xac9063cb41572910());
	}

	internal byte[] x0f6807cca84a8e5b(int x10f4d88af727adbc)
	{
		byte[] array = new byte[x10f4d88af727adbc];
		for (int i = 0; i < x10f4d88af727adbc; i++)
		{
			array[i] = x672ed37ee25c078c();
		}
		return array;
	}

	internal byte[] x0f6807cca84a8e5b()
	{
		byte[] array = new byte[x4093e041a32c0256.Length / 2];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = x672ed37ee25c078c();
		}
		return array;
	}

	private int xac9063cb41572910()
	{
		if (xa3f9b2fd98264390 == x4093e041a32c0256.Length)
		{
			return -1;
		}
		return x0d299f323d241756.xe3ec68422266caf1(x4093e041a32c0256[xa3f9b2fd98264390++]);
	}
}
