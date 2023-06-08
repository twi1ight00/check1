namespace x09d959ca29199776;

internal class xa07b20c560e88b89
{
	private const short x5708ecfe51d65249 = 3;

	private const short x03090ab3e14567a7 = 3;

	private const long xa45e43bf08937837 = 1L;

	private readonly int xbfa90489c7e88918;

	private x4978a4bdb03182b4 x57eb0819c9e6e2e4;

	private x4978a4bdb03182b4 xd5f0fdec5b56e868;

	private x4978a4bdb03182b4 xb6152f22d9314125;

	private int xeafc809462667351;

	private int x2881e42489a29306;

	private int xbe274cf53ee873ce;

	private int x43f8c84ab255b29a;

	private byte[] xa89312e89f2dd9e8;

	public byte[] x2f23ffd1bb98f036 => xa89312e89f2dd9e8;

	public x4978a4bdb03182b4 x22fb50187bc072a8 => x57eb0819c9e6e2e4;

	public x4978a4bdb03182b4 xbd794880cc56fc6a => xd5f0fdec5b56e868;

	public x4978a4bdb03182b4 xebcf3366938d31ee => xb6152f22d9314125;

	public int x3202b46cb7745349 => xeafc809462667351;

	public int x79e977c66a0ee274 => x2881e42489a29306;

	public int x2b2d19e5041097b5 => xbe274cf53ee873ce;

	public xa07b20c560e88b89(int outputLength)
	{
		xbfa90489c7e88918 = outputLength;
		x5b108ae7550dda0b();
		x59f76c761907e6af();
		x1cc35dfa006631e6();
		xf7682bdaeda6dde0();
		x930d4687de19d463();
	}

	private void x5b108ae7550dda0b()
	{
		int num = 1;
		for (long num2 = 1L + (long)(1 << 3 * num) - 1; num2 < xbfa90489c7e88918; num2 = 1L + (long)(1 << 3 * num) - 1)
		{
			num++;
		}
		xeafc809462667351 = 256 + 8 * num;
		x2881e42489a29306 = xeafc809462667351 + 1;
		xbe274cf53ee873ce = x2881e42489a29306 + 1;
		x43f8c84ab255b29a = xbe274cf53ee873ce + 1;
	}

	private void x59f76c761907e6af()
	{
		x57eb0819c9e6e2e4 = new x4978a4bdb03182b4(8);
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				x57eb0819c9e6e2e4.x42237e0547d7298c(j);
			}
		}
	}

	private void x1cc35dfa006631e6()
	{
		xd5f0fdec5b56e868 = new x4978a4bdb03182b4(8);
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				xd5f0fdec5b56e868.x42237e0547d7298c(j);
			}
		}
	}

	private void xf7682bdaeda6dde0()
	{
		xb6152f22d9314125 = new x4978a4bdb03182b4(x43f8c84ab255b29a);
		xb6152f22d9314125.x42237e0547d7298c(256);
		xb6152f22d9314125.x42237e0547d7298c(257);
		for (int i = 0; i < 12; i++)
		{
			xb6152f22d9314125.x42237e0547d7298c(xeafc809462667351);
		}
		for (int j = 0; j < 6; j++)
		{
			xb6152f22d9314125.x42237e0547d7298c(x2881e42489a29306);
		}
	}

	private void x930d4687de19d463()
	{
		xa89312e89f2dd9e8 = new byte[7168];
		int num = 0;
		for (byte b = 0; b < 32; b = (byte)(b + 1))
		{
			for (byte b2 = 0; b2 < 96; b2 = (byte)(b2 + 1))
			{
				xa89312e89f2dd9e8[num++] = b;
				xa89312e89f2dd9e8[num++] = b2;
			}
		}
		for (int i = 0; i < 256; i++)
		{
			xa89312e89f2dd9e8[num++] = (byte)i;
			xa89312e89f2dd9e8[num++] = (byte)i;
			xa89312e89f2dd9e8[num++] = (byte)i;
			xa89312e89f2dd9e8[num++] = (byte)i;
		}
	}
}
