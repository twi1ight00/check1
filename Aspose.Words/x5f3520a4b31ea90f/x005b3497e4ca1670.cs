namespace x5f3520a4b31ea90f;

internal class x005b3497e4ca1670
{
	private readonly byte[] x9b529da35d1032aa = new byte[256];

	private int x7cf290e345b9b3cf;

	private int x7b7c4bf07166b4da;

	public void xcc381ffa3ede662f(byte[] x4a3f0a05c02f235f, int x961016a387451f05)
	{
		x246b032720dd4c0d(x4a3f0a05c02f235f, 0, x961016a387451f05);
	}

	public void x246b032720dd4c0d(byte[] x4a3f0a05c02f235f)
	{
		x246b032720dd4c0d(x4a3f0a05c02f235f, 0, x4a3f0a05c02f235f.Length, x4a3f0a05c02f235f, 0);
	}

	public void x246b032720dd4c0d(byte[] xfff2c0cc424f9ab8, byte[] xd129fd25992ddef2)
	{
		x246b032720dd4c0d(xfff2c0cc424f9ab8, 0, xfff2c0cc424f9ab8.Length, xd129fd25992ddef2, 0);
	}

	public void x246b032720dd4c0d(byte[] x4a3f0a05c02f235f, int x374ea4fe62468d0f, int x961016a387451f05)
	{
		x246b032720dd4c0d(x4a3f0a05c02f235f, x374ea4fe62468d0f, x961016a387451f05, x4a3f0a05c02f235f, x374ea4fe62468d0f);
	}

	public void x246b032720dd4c0d(byte[] xfff2c0cc424f9ab8, int x374ea4fe62468d0f, int x961016a387451f05, byte[] xd129fd25992ddef2, int xdd520b956cedf5b6)
	{
		int num = x961016a387451f05 + x374ea4fe62468d0f;
		for (int i = x374ea4fe62468d0f; i < num; i++)
		{
			x7cf290e345b9b3cf = (x7cf290e345b9b3cf + 1) & 0xFF;
			x7b7c4bf07166b4da = (x9b529da35d1032aa[x7cf290e345b9b3cf] + x7b7c4bf07166b4da) & 0xFF;
			byte b = x9b529da35d1032aa[x7cf290e345b9b3cf];
			x9b529da35d1032aa[x7cf290e345b9b3cf] = x9b529da35d1032aa[x7b7c4bf07166b4da];
			x9b529da35d1032aa[x7b7c4bf07166b4da] = b;
			xd129fd25992ddef2[i - x374ea4fe62468d0f + xdd520b956cedf5b6] = (byte)(xfff2c0cc424f9ab8[i] ^ x9b529da35d1032aa[(x9b529da35d1032aa[x7cf290e345b9b3cf] + x9b529da35d1032aa[x7b7c4bf07166b4da]) & 0xFF]);
		}
	}

	public void xb04c56f3a10310d3(byte[] xba08ce632055a1d9)
	{
		xb04c56f3a10310d3(xba08ce632055a1d9, 0, xba08ce632055a1d9.Length);
	}

	public void xb04c56f3a10310d3(byte[] xba08ce632055a1d9, int x374ea4fe62468d0f, int x961016a387451f05)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < 256; i++)
		{
			x9b529da35d1032aa[i] = (byte)i;
		}
		x7cf290e345b9b3cf = 0;
		x7b7c4bf07166b4da = 0;
		for (int j = 0; j < 256; j++)
		{
			num2 = (xba08ce632055a1d9[num + x374ea4fe62468d0f] + x9b529da35d1032aa[j] + num2) & 0xFF;
			byte b = x9b529da35d1032aa[j];
			x9b529da35d1032aa[j] = x9b529da35d1032aa[num2];
			x9b529da35d1032aa[num2] = b;
			num = (num + 1) % x961016a387451f05;
		}
	}
}
