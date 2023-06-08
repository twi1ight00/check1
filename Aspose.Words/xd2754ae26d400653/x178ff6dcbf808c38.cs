using System;
using Aspose.Words;
using Aspose.Words.Lists;

namespace xd2754ae26d400653;

internal class x178ff6dcbf808c38 : IComparable
{
	private DocumentBase xd1424e1a0bb4a72b;

	private int x3801e21814acef38;

	private x902c8ac86fbaf048 x37a3a9edb53f138b = x902c8ac86fbaf048.x7e86ac926e2dc940;

	private int x88d99b600ff63e5f;

	private string xc61ff88f1f98652d;

	private ListLevelCollection x2c5afac3b4beff6a;

	private int xa8c1c11952389405 = 12;

	internal int x1eac770549050632 => x3801e21814acef38;

	internal x902c8ac86fbaf048 x902c8ac86fbaf048 => x37a3a9edb53f138b;

	internal int x18f9fc979b70e77f => x88d99b600ff63e5f;

	internal string x759aa16c2016a289
	{
		get
		{
			return xc61ff88f1f98652d;
		}
		set
		{
			xc61ff88f1f98652d = value;
		}
	}

	internal ListLevelCollection x438a2a8db4b2d07b => x2c5afac3b4beff6a;

	internal bool xf81d0e09758457fe
	{
		get
		{
			Style style = xfe2178c1f916f36c;
			if (style != null)
			{
				return style.List.x178ff6dcbf808c38 == this;
			}
			return false;
		}
	}

	internal bool x01381925b7dd551e
	{
		get
		{
			Style style = xfe2178c1f916f36c;
			if (style != null)
			{
				return style.List.x178ff6dcbf808c38 != this;
			}
			return false;
		}
	}

	internal int xc657ea789af2c1f0
	{
		get
		{
			return xa8c1c11952389405;
		}
		set
		{
			xa8c1c11952389405 = value;
			if (xa8c1c11952389405 == 4095)
			{
				xa8c1c11952389405 = 12;
			}
		}
	}

	internal Style xfe2178c1f916f36c
	{
		get
		{
			if (xa8c1c11952389405 == 4095 || xa8c1c11952389405 == 12)
			{
				return null;
			}
			Style style = xd1424e1a0bb4a72b.Styles.x1976fb6958cf7237(xa8c1c11952389405, x988fcf605f8efa7e: true);
			if (style.Type == StyleType.List)
			{
				return style;
			}
			return null;
		}
	}

	internal DocumentBase x2c8c6741422a1298 => xd1424e1a0bb4a72b;

	internal x178ff6dcbf808c38(DocumentBase document)
	{
		xd1424e1a0bb4a72b = document;
		x2c5afac3b4beff6a = new ListLevelCollection();
	}

	internal x178ff6dcbf808c38(DocumentBase document, int listDefId, x902c8ac86fbaf048 listType, int templateCode)
	{
		xd1424e1a0bb4a72b = document;
		x3801e21814acef38 = listDefId;
		x37a3a9edb53f138b = listType;
		x88d99b600ff63e5f = templateCode;
		x2c5afac3b4beff6a = new ListLevelCollection(document, listType);
	}

	internal x178ff6dcbf808c38 x8b61531c8ea35b85(DocumentBase x3664041d21d73fdc, int x6b9cdc3a87f7e946)
	{
		x178ff6dcbf808c38 x178ff6dcbf808c39 = (x178ff6dcbf808c38)MemberwiseClone();
		x178ff6dcbf808c39.xd1424e1a0bb4a72b = x3664041d21d73fdc;
		x178ff6dcbf808c39.x3801e21814acef38 = x6b9cdc3a87f7e946;
		x178ff6dcbf808c39.x2c5afac3b4beff6a = x2c5afac3b4beff6a.x8b61531c8ea35b85(x3664041d21d73fdc);
		return x178ff6dcbf808c39;
	}

	internal void xd0e9f66f8c4d99a4(int x6b9cdc3a87f7e946)
	{
		x3801e21814acef38 = x6b9cdc3a87f7e946;
	}

	internal void x570106e08534c22d(x902c8ac86fbaf048 xd275fdd8cec9b85e)
	{
		x37a3a9edb53f138b = xd275fdd8cec9b85e;
	}

	internal void xb194d434d9f9f2fe(int x9367689a5bf3c890)
	{
		x88d99b600ff63e5f = x9367689a5bf3c890;
	}

	internal x178ff6dcbf808c38 x8ffa0d8453c05602()
	{
		Style style = xfe2178c1f916f36c;
		if (style == null)
		{
			return this;
		}
		x178ff6dcbf808c38 x178ff6dcbf808c39 = style.List.x178ff6dcbf808c38;
		if (x178ff6dcbf808c39 != this)
		{
			return x178ff6dcbf808c39.x8ffa0d8453c05602();
		}
		return this;
	}

	public int CompareTo(object obj)
	{
		return Math.Sign(x3801e21814acef38 - ((x178ff6dcbf808c38)obj).x1eac770549050632);
	}
}
