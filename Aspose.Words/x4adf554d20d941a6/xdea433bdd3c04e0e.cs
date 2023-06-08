using System;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;

namespace x4adf554d20d941a6;

internal class xdea433bdd3c04e0e
{
	internal int x887a0c79ecbe5ee3;

	internal int x79a071bfba0c5e7d;

	internal int x9ba60a33bc3988dc;

	internal int xb5ed9629008a9978;

	internal int x9d329a00f2c534a8;

	internal int x858cf35bef435420;

	internal int xe36c96d8c564b382;

	internal int x936edf4be441ef51;

	internal int x3903fbc9023c861c;

	internal int x853fb708c04424c4;

	internal int x4e941b39b4de92a5;

	internal int x817fa68c05425b51;

	internal int xb0f146032f47c24e => xb5ed9629008a9978 + x9d329a00f2c534a8 + x858cf35bef435420 + xe36c96d8c564b382 + x936edf4be441ef51 + x3903fbc9023c861c + x853fb708c04424c4;

	internal int xca4de43dee74bd20 => xb5ed9629008a9978 + x9d329a00f2c534a8 + x858cf35bef435420;

	internal int xeebd2917de4cec33 => x858cf35bef435420 + x9d329a00f2c534a8 + xe36c96d8c564b382 + x936edf4be441ef51 + x3903fbc9023c861c;

	internal int x14aae9da46f58141 => xca4de43dee74bd20 + xe36c96d8c564b382 + x936edf4be441ef51;

	internal void xd586e0c16bdae7fc(x56410a8dd70087c5 x62584df2cb5d40dd)
	{
		if (x62584df2cb5d40dd == null)
		{
			return;
		}
		bool flag = false;
		x56410a8dd70087c5 x56410a8dd70087c6 = null;
		x56410a8dd70087c5 x56410a8dd70087c7 = null;
		x56410a8dd70087c5 x56410a8dd70087c8 = null;
		x56410a8dd70087c5 x56410a8dd70087c9 = null;
		x56410a8dd70087c5 x56410a8dd70087c10 = null;
		bool flag2 = false;
		for (x56410a8dd70087c5 x56410a8dd70087c11 = x62584df2cb5d40dd; x56410a8dd70087c11 != null; x56410a8dd70087c11 = x56410a8dd70087c11.xbd2e6df53b2331ee)
		{
			switch (x56410a8dd70087c11.x5566e2d2acbd1fbe)
			{
			case 9216:
			case 9217:
			case 9238:
			case 9747:
			case 11284:
			case 11285:
				if (flag2 && (x56410a8dd70087c11.x5566e2d2acbd1fbe == 9238 || x56410a8dd70087c11.x5566e2d2acbd1fbe == 9747))
				{
					if (x56410a8dd70087c8 == null && !flag)
					{
						x56410a8dd70087c6 = x56410a8dd70087c11;
					}
					break;
				}
				if (x56410a8dd70087c11.xfc6971c7d8314663 != xfc6971c7d8314663.xe9605a4bea014f21)
				{
					x56410a8dd70087c8 = x56410a8dd70087c11;
				}
				xd9b83ec88faf079d(x56410a8dd70087c11, xfad304b5f8f3bb5b: true);
				break;
			case 10754:
			case 10768:
			case 10769:
			case 10770:
			case 10782:
			case 12803:
				if (flag2 && x56410a8dd70087c11.x5566e2d2acbd1fbe == 10769)
				{
					x56410a8dd70087c8 = x56410a8dd70087c11;
					xd9b83ec88faf079d(x56410a8dd70087c11, xfad304b5f8f3bb5b: true);
				}
				else if (x56410a8dd70087c8 == null && !flag)
				{
					x56410a8dd70087c6 = x56410a8dd70087c11;
				}
				break;
			case 21513:
			case 21514:
			case 21537:
			case 21577:
			case 21586:
			case 21595:
			case 21639:
			case 21779:
			case 21788:
			case 21857:
			case 21858:
			case 21859:
			case 21860:
			case 21861:
				if (x56410a8dd70087c8 == null && !flag && !((x41ac54db4e627dea)x56410a8dd70087c11).x53182140cf4abbfb())
				{
					x56410a8dd70087c6 = null;
					x56410a8dd70087c7 = x56410a8dd70087c11;
				}
				break;
			case 25604:
				if (x127e6d26eafdc091(x56410a8dd70087c11))
				{
					flag = x56410a8dd70087c6 != null;
					if (x56410a8dd70087c11.xfc6971c7d8314663 == xfc6971c7d8314663.xe9605a4bea014f21)
					{
						x56410a8dd70087c10 = x56410a8dd70087c11;
						break;
					}
					x56410a8dd70087c9 = x56410a8dd70087c11;
					xd9b83ec88faf079d(x56410a8dd70087c11, xfad304b5f8f3bb5b: true);
				}
				break;
			case 0:
				flag2 = xe3e59fefd6478634(x56410a8dd70087c11, flag2);
				break;
			}
		}
		bool xfad304b5f8f3bb5b = x56410a8dd70087c9 == null;
		if (x56410a8dd70087c8 == null)
		{
			if (x56410a8dd70087c6 != null)
			{
				xd9b83ec88faf079d(x56410a8dd70087c6, xfad304b5f8f3bb5b);
			}
			else if (x56410a8dd70087c7 != null)
			{
				xd9b83ec88faf079d(x56410a8dd70087c7, xfad304b5f8f3bb5b);
			}
		}
		if (x56410a8dd70087c10 != null)
		{
			xd9b83ec88faf079d(x56410a8dd70087c10, xfad304b5f8f3bb5b);
		}
	}

	private static bool xe3e59fefd6478634(x56410a8dd70087c5 x5906905c888d3d98, bool xa4e7bd456e842247)
	{
		bool result = xa4e7bd456e842247;
		if (x5906905c888d3d98 is x5c28fdcd27dee7d9)
		{
			x5c28fdcd27dee7d9 x5c28fdcd27dee7d10 = (x5c28fdcd27dee7d9)x5906905c888d3d98;
			if (x5c28fdcd27dee7d10.xc96d173d58dd8a20 == FieldType.FieldFormTextInput)
			{
				if (x5c28fdcd27dee7d10.x275cb4c2185b2177 == x5c28fdcd27dee7d10)
				{
					result = true;
				}
				else if (x5c28fdcd27dee7d10.x70ff891026cb8704 == x5c28fdcd27dee7d10)
				{
					result = false;
				}
			}
		}
		return result;
	}

	internal xdea433bdd3c04e0e x8b61531c8ea35b85()
	{
		return (xdea433bdd3c04e0e)MemberwiseClone();
	}

	private void xd9b83ec88faf079d(x56410a8dd70087c5 x5906905c888d3d98, bool xfad304b5f8f3bb5b)
	{
		bool flag = x5906905c888d3d98.xfc6971c7d8314663 == xfc6971c7d8314663.xe9605a4bea014f21 && !(x5906905c888d3d98 is x92361dccfa0347fd);
		if (xfad304b5f8f3bb5b)
		{
			x4e941b39b4de92a5 = Math.Max(x5906905c888d3d98.x887a0c79ecbe5ee3, x4e941b39b4de92a5);
			x817fa68c05425b51 = Math.Max(x5906905c888d3d98.x79a071bfba0c5e7d, x817fa68c05425b51);
			if (flag && x5906905c888d3d98.x5566e2d2acbd1fbe == 25604)
			{
				x887a0c79ecbe5ee3 = Math.Max(x0b5ee02972f2b9ba.x6be2ce937644ef37(x5906905c888d3d98.x705ed5f9769744e5.xc2d4efc42998d87b.x53531537bb3331e6), x887a0c79ecbe5ee3);
			}
			else
			{
				x887a0c79ecbe5ee3 = Math.Max(x5906905c888d3d98.x887a0c79ecbe5ee3, x887a0c79ecbe5ee3);
			}
			if (!flag)
			{
				x79a071bfba0c5e7d = Math.Max(x5906905c888d3d98.x79a071bfba0c5e7d, x79a071bfba0c5e7d);
			}
		}
		if (!flag)
		{
			x9ba60a33bc3988dc = Math.Max(x5906905c888d3d98.x342336c67a7f5544 + x5906905c888d3d98.x3a04db961e36dc5b, x9ba60a33bc3988dc);
		}
	}

	private static bool x127e6d26eafdc091(x56410a8dd70087c5 x5906905c888d3d98)
	{
		if (x5906905c888d3d98.x5566e2d2acbd1fbe == 25604)
		{
			return x5906905c888d3d98.x34251722ab416841.x109e3389933c23a8.xab6edfb47ff0b74c == WrapType.Inline;
		}
		return false;
	}
}
