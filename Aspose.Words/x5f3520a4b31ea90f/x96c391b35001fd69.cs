namespace x5f3520a4b31ea90f;

internal class x96c391b35001fd69
{
	private int x7bc95a6c91d75cef = 16;

	private long xf46eb77b94ef49e3 = 4129L;

	private int xdcde4add35c2ac43 = 1;

	private long x38bc204fc0ec313c = 65535L;

	private long xc11cb02f1227b00b;

	private int xf485ef766d695d4f;

	private int x22d416cd5a266943;

	private long xce3bf4df6bc58d1a;

	private long x90a5500aa92b9535;

	private long xce872e3544abdab9;

	private long xd4f5484c42318eee;

	private long[] xb211b882e5ed402e = new long[256];

	private xf1904093bac6efc1 xff3edc9aa5f0523b;

	public xf1904093bac6efc1 x9ee491ab5579b9fc => xff3edc9aa5f0523b;

	public x96c391b35001fd69()
	{
		x07279a63090af02d(xf1904093bac6efc1.x41fcadcc0506e331);
	}

	public x96c391b35001fd69(xf1904093bac6efc1 encoding)
	{
		x07279a63090af02d(encoding);
	}

	private void x07279a63090af02d(xf1904093bac6efc1 xff3edc9aa5f0523b)
	{
		this.xff3edc9aa5f0523b = xff3edc9aa5f0523b;
		switch (xff3edc9aa5f0523b)
		{
		case xf1904093bac6efc1.xd87a7309c654b06f:
			x7bc95a6c91d75cef = 16;
			xdcde4add35c2ac43 = 1;
			xf46eb77b94ef49e3 = 32773L;
			x38bc204fc0ec313c = 0L;
			xc11cb02f1227b00b = 0L;
			xf485ef766d695d4f = 1;
			x22d416cd5a266943 = 1;
			break;
		case xf1904093bac6efc1.x3730d40ba23cd92e:
			x7bc95a6c91d75cef = 16;
			xdcde4add35c2ac43 = 1;
			xf46eb77b94ef49e3 = 4129L;
			x38bc204fc0ec313c = 0L;
			xc11cb02f1227b00b = 0L;
			xf485ef766d695d4f = 1;
			x22d416cd5a266943 = 1;
			break;
		case xf1904093bac6efc1.xee5d569d411d61c6:
			x7bc95a6c91d75cef = 16;
			xdcde4add35c2ac43 = 1;
			xf46eb77b94ef49e3 = 4129L;
			x38bc204fc0ec313c = 65535L;
			xc11cb02f1227b00b = 0L;
			xf485ef766d695d4f = 0;
			x22d416cd5a266943 = 0;
			break;
		default:
			x7bc95a6c91d75cef = 32;
			xdcde4add35c2ac43 = 1;
			xf46eb77b94ef49e3 = 79764919L;
			x38bc204fc0ec313c = 4294967295L;
			xc11cb02f1227b00b = 4294967295L;
			xf485ef766d695d4f = 1;
			x22d416cd5a266943 = 1;
			break;
		}
		xce3bf4df6bc58d1a = ((1L << x7bc95a6c91d75cef - 1) - 1 << 1) | 1;
		x90a5500aa92b9535 = 1L << x7bc95a6c91d75cef - 1;
		x18ba168524e75adb();
		long num;
		if (xdcde4add35c2ac43 == 0)
		{
			xd4f5484c42318eee = x38bc204fc0ec313c;
			num = x38bc204fc0ec313c;
			for (int i = 0; i < x7bc95a6c91d75cef; i++)
			{
				long num2 = num & x90a5500aa92b9535;
				num <<= 1;
				if (num2 != 0)
				{
					num ^= xf46eb77b94ef49e3;
				}
			}
			num &= xce3bf4df6bc58d1a;
			xce872e3544abdab9 = num;
			return;
		}
		xce872e3544abdab9 = x38bc204fc0ec313c;
		num = x38bc204fc0ec313c;
		for (int i = 0; i < x7bc95a6c91d75cef; i++)
		{
			long num2 = num & 1;
			if (num2 != 0)
			{
				num ^= xf46eb77b94ef49e3;
			}
			num >>= 1;
			if (num2 != 0)
			{
				num |= x90a5500aa92b9535;
			}
		}
		xd4f5484c42318eee = num;
	}

	public int xf4513182b4682707(byte[] x9c79b5ad7b769b12)
	{
		long num = xce872e3544abdab9;
		if (xf485ef766d695d4f != 0)
		{
			num = xad72e6a502680a53(num, x7bc95a6c91d75cef);
		}
		if (xf485ef766d695d4f == 0)
		{
			for (int i = 0; i < x9c79b5ad7b769b12.Length; i++)
			{
				num = (num << 8) ^ xb211b882e5ed402e[(int)(((num >> x7bc95a6c91d75cef - 8) & 0xFF) ^ x9c79b5ad7b769b12[i])];
			}
		}
		else
		{
			for (int j = 0; j < x9c79b5ad7b769b12.Length; j++)
			{
				num = (num >> 8) ^ xb211b882e5ed402e[(int)((num & 0xFF) ^ x9c79b5ad7b769b12[j])];
			}
		}
		if ((x22d416cd5a266943 ^ xf485ef766d695d4f) != 0)
		{
			num = xad72e6a502680a53(num, x7bc95a6c91d75cef);
		}
		num ^= xc11cb02f1227b00b;
		num &= xce3bf4df6bc58d1a;
		return (int)num;
	}

	private long xad72e6a502680a53(long xa4660e7fe4e71d99, int xc7b4d99905d845b2)
	{
		long num = 1L;
		long num2 = 0L;
		for (long num3 = 1L << xc7b4d99905d845b2 - 1; num3 != 0; num3 >>= 1)
		{
			if ((xa4660e7fe4e71d99 & num3) != 0)
			{
				num2 |= num;
			}
			num <<= 1;
		}
		return num2;
	}

	private void x18ba168524e75adb()
	{
		for (int i = 0; i < 256; i++)
		{
			long num = i;
			if (xf485ef766d695d4f != 0)
			{
				num = xad72e6a502680a53(num, 8);
			}
			num <<= x7bc95a6c91d75cef - 8;
			for (int j = 0; j < 8; j++)
			{
				long num2 = num & x90a5500aa92b9535;
				num <<= 1;
				if (num2 != 0)
				{
					num ^= xf46eb77b94ef49e3;
				}
			}
			if (xf485ef766d695d4f != 0)
			{
				num = xad72e6a502680a53(num, x7bc95a6c91d75cef);
			}
			num &= xce3bf4df6bc58d1a;
			xb211b882e5ed402e[i] = num;
		}
	}
}
