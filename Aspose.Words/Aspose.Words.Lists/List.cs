using System;
using xd2754ae26d400653;

namespace Aspose.Words.Lists;

public class List : IComparable
{
	private DocumentBase xd1424e1a0bb4a72b;

	private int xf07940917db8b054;

	private int x3801e21814acef38;

	private x178ff6dcbf808c38 x02b64c3c25ffdc22;

	private xcc042bdddde169d7 xe42cd184c74e6f24 = new xcc042bdddde169d7();

	internal xcc042bdddde169d7 x6047afa6812e47bc => xe42cd184c74e6f24;

	public int ListId => xf07940917db8b054;

	public DocumentBase Document => xd1424e1a0bb4a72b;

	public bool IsMultiLevel => x178ff6dcbf808c38.x902c8ac86fbaf048 != x902c8ac86fbaf048.xabed123f43874357;

	public ListLevelCollection ListLevels => x178ff6dcbf808c38.x8ffa0d8453c05602().x438a2a8db4b2d07b;

	internal x178ff6dcbf808c38 x178ff6dcbf808c38
	{
		get
		{
			if (x02b64c3c25ffdc22 == null)
			{
				x02b64c3c25ffdc22 = xd1424e1a0bb4a72b.Lists.x44c0fd1f259e7914(x3801e21814acef38);
			}
			return x02b64c3c25ffdc22;
		}
	}

	public bool IsListStyleDefinition => x178ff6dcbf808c38.xf81d0e09758457fe;

	public bool IsListStyleReference => x178ff6dcbf808c38.x01381925b7dd551e;

	public Style Style
	{
		get
		{
			if (x178ff6dcbf808c38.xc657ea789af2c1f0 != 12)
			{
				return x178ff6dcbf808c38.xfe2178c1f916f36c;
			}
			return null;
		}
	}

	internal int x1eac770549050632
	{
		get
		{
			return x3801e21814acef38;
		}
		set
		{
			x3801e21814acef38 = value;
		}
	}

	internal List(DocumentBase document, int listId)
	{
		xd1424e1a0bb4a72b = document;
		xf07940917db8b054 = listId;
	}

	internal List x8b61531c8ea35b85(DocumentBase x3664041d21d73fdc, int x43eb71c4e55e38d0)
	{
		List list = (List)MemberwiseClone();
		list.xd1424e1a0bb4a72b = x3664041d21d73fdc;
		list.xf07940917db8b054 = x43eb71c4e55e38d0;
		list.x02b64c3c25ffdc22 = null;
		list.xe42cd184c74e6f24 = new xcc042bdddde169d7();
		foreach (x136abcf7d9c0eef3 item in xe42cd184c74e6f24)
		{
			list.xe42cd184c74e6f24.Add(item.x8b61531c8ea35b85());
		}
		return list;
	}

	internal void xd01d085303c8ed31(int x43eb71c4e55e38d0)
	{
		xf07940917db8b054 = x43eb71c4e55e38d0;
	}

	private x136abcf7d9c0eef3 x247f9664a0df3e54(int x66bbd7ed8c65740d)
	{
		foreach (x136abcf7d9c0eef3 item in x6047afa6812e47bc)
		{
			if (item.xf13a626e550cef8f.x008c23e8f687bbd3 == x66bbd7ed8c65740d && item.x33160172e2e7ff13)
			{
				return item;
			}
		}
		return null;
	}

	private x136abcf7d9c0eef3 x871d3b50aaee173b(int x66bbd7ed8c65740d)
	{
		foreach (x136abcf7d9c0eef3 item in x6047afa6812e47bc)
		{
			if (item.xf13a626e550cef8f.x008c23e8f687bbd3 == x66bbd7ed8c65740d && item.x178c863a9c967cd2)
			{
				return item;
			}
		}
		return null;
	}

	internal bool xe736f89697fc827f(int x66bbd7ed8c65740d)
	{
		return x247f9664a0df3e54(x66bbd7ed8c65740d) != null;
	}

	internal int xc6c2afc83ab5edd9(int x66bbd7ed8c65740d)
	{
		return x247f9664a0df3e54(x66bbd7ed8c65740d)?.xa12fba83b43c84d8 ?? ListLevels.x90a164d2f15bfc09(x66bbd7ed8c65740d).StartAt;
	}

	internal ListLevel x1fc16b41653eb571(int x66bbd7ed8c65740d)
	{
		x136abcf7d9c0eef3 x136abcf7d9c0eef = x871d3b50aaee173b(x66bbd7ed8c65740d);
		if (x136abcf7d9c0eef == null)
		{
			return ListLevels.x90a164d2f15bfc09(x66bbd7ed8c65740d);
		}
		return x136abcf7d9c0eef.xf13a626e550cef8f;
	}

	internal static bool xda93661a4158325a(List x3763849ab45f2492, List xd505507cf33ae543)
	{
		bool result = true;
		if (x3763849ab45f2492.ListLevels.Count != xd505507cf33ae543.ListLevels.Count)
		{
			return false;
		}
		for (int i = 0; i < x3763849ab45f2492.ListLevels.Count; i++)
		{
			if (!ListLevel.x1f45bf73937dd66f(x3763849ab45f2492.ListLevels[i], xd505507cf33ae543.ListLevels[i]))
			{
				result = false;
				break;
			}
		}
		return result;
	}

	public int CompareTo(object obj)
	{
		return ListId - ((List)obj).ListId;
	}
}
