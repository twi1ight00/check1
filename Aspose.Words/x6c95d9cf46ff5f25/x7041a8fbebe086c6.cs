namespace x6c95d9cf46ff5f25;

internal class x7041a8fbebe086c6
{
	private int x0b9e3510a8fd10aa;

	private int x40e254f6644a545b;

	private int x4625b890ce81291d;

	private byte[] xd4251e57da4db8b6;

	public int x6902704a206de8be
	{
		get
		{
			return x40e254f6644a545b;
		}
		set
		{
			xbb7550bbb62a218c();
			x8739094aa0187d3b();
			x40e254f6644a545b = value;
		}
	}

	private bool x9690bb75f1db5849 => x0b9e3510a8fd10aa == 1;

	public x7041a8fbebe086c6(byte[] bytes)
	{
		xd4251e57da4db8b6 = bytes;
		x8739094aa0187d3b();
	}

	public void x5879967bb0ed3219(string xcfba402eef386a24)
	{
		for (int i = 0; i < xcfba402eef386a24.Length; i++)
		{
			switch (xcfba402eef386a24[i])
			{
			case '0':
				xee48077742d1f032();
				break;
			case '1':
				x310c586f4b637864();
				xee48077742d1f032();
				break;
			}
		}
	}

	public void x310c586f4b637864()
	{
		x4625b890ce81291d += (byte)x0b9e3510a8fd10aa;
	}

	public void xee48077742d1f032()
	{
		if (x9690bb75f1db5849)
		{
			xe78420fdb5a85c8e();
			x6902704a206de8be++;
		}
		else
		{
			x0b9e3510a8fd10aa >>= 1;
		}
	}

	public void xbb7550bbb62a218c()
	{
		if (x0b9e3510a8fd10aa != 128 && x40e254f6644a545b < xd4251e57da4db8b6.Length)
		{
			xe78420fdb5a85c8e();
		}
	}

	private void x8739094aa0187d3b()
	{
		x0b9e3510a8fd10aa = 128;
		x4625b890ce81291d = 0;
	}

	private void xe78420fdb5a85c8e()
	{
		xd4251e57da4db8b6[x6902704a206de8be] = (byte)x4625b890ce81291d;
	}
}
