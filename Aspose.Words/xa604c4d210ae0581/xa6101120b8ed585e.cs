namespace xa604c4d210ae0581;

internal class xa6101120b8ed585e
{
	private int x10aaa7cdfa38f254;

	private int xca09b6c2b5b18485;

	internal int x12cb12b5d2cad53d
	{
		get
		{
			return x10aaa7cdfa38f254;
		}
		set
		{
			x10aaa7cdfa38f254 = value;
		}
	}

	internal int x9fd888e65466818c
	{
		get
		{
			return xca09b6c2b5b18485;
		}
		set
		{
			xca09b6c2b5b18485 = value;
		}
	}

	internal int x1be93eed8950d961 => xca09b6c2b5b18485 - x10aaa7cdfa38f254;

	internal xa6101120b8ed585e()
	{
	}

	internal xa6101120b8ed585e(int start, int end)
	{
		x10aaa7cdfa38f254 = start;
		xca09b6c2b5b18485 = end;
	}

	internal bool x263d579af1d0d43f(int x30cc7819189f11b6)
	{
		if (x30cc7819189f11b6 >= x10aaa7cdfa38f254)
		{
			return x30cc7819189f11b6 < xca09b6c2b5b18485;
		}
		return false;
	}

	internal bool x7149c962c02931b3()
	{
		return x10aaa7cdfa38f254 == xca09b6c2b5b18485;
	}
}
