namespace x011d489fb9df7027;

internal class x98655ffe05324a50
{
	private readonly xc548449aaa21fea5 xf263b01e2956834c;

	private readonly int x4574aea041dd835f;

	internal int x98a6bc3f2b64620b => xf263b01e2956834c switch
	{
		xc548449aaa21fea5.xd93f803ca02a4434 => 0, 
		xc548449aaa21fea5.xff654ea4df290dd7 => 1, 
		xc548449aaa21fea5.x58d2ccae3c5cfd08 => 2, 
		xc548449aaa21fea5.x40937ad35b1cf5f7 => 3 + x4574aea041dd835f, 
		xc548449aaa21fea5.xfaab97dd0218026f => 256 + x4574aea041dd835f, 
		_ => x4574aea041dd835f, 
	};

	internal xc548449aaa21fea5 x3146d638ec378671 => xf263b01e2956834c;

	internal int xd2f68ee6f47e9dfb => x4574aea041dd835f;

	internal x98655ffe05324a50()
		: this(xc548449aaa21fea5.xf6c17f648b65c793, 0)
	{
	}

	internal x98655ffe05324a50(xc548449aaa21fea5 type, int value)
	{
		xf263b01e2956834c = type;
		x4574aea041dd835f = value;
	}

	internal x98655ffe05324a50(int packedValue)
	{
		x4574aea041dd835f = 0;
		switch (packedValue)
		{
		case 0:
			xf263b01e2956834c = xc548449aaa21fea5.xd93f803ca02a4434;
			return;
		case 1:
			xf263b01e2956834c = xc548449aaa21fea5.xff654ea4df290dd7;
			return;
		case 2:
			xf263b01e2956834c = xc548449aaa21fea5.x58d2ccae3c5cfd08;
			return;
		}
		if (packedValue >= 3 && packedValue <= 132)
		{
			xf263b01e2956834c = xc548449aaa21fea5.x40937ad35b1cf5f7;
			x4574aea041dd835f = packedValue - 3;
		}
		else
		{
			xf263b01e2956834c = xc548449aaa21fea5.xfaab97dd0218026f;
			x4574aea041dd835f = packedValue - 256;
		}
	}
}
