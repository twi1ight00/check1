using System;
using System.Collections.Specialized;
using System.IO;

namespace xa604c4d210ae0581;

internal class xaf807f6784ee1743 : x6f211c5eac49c71c
{
	private readonly StringCollection x844a06e73f5fb69e;

	internal xaf807f6784ee1743(StringCollection strings)
	{
		x844a06e73f5fb69e = strings;
	}

	internal static void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, x3fdb33c580a0bef3 x2e35a61e0b396eec, StringCollection x0a6f7002484e4f46)
	{
		x06b0e25aa6ad68a9(xe134235b3526fa75, x2e35a61e0b396eec.xe53f0e68147463d1, x2e35a61e0b396eec.x04c290dc4d04369c, x0a6f7002484e4f46);
	}

	internal static void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, int xbd275f4c48a1b4c6, int x7f6c4e8aaf0db1ab, StringCollection x0a6f7002484e4f46)
	{
		xaf807f6784ee1743 xaf807f6784ee1744 = new xaf807f6784ee1743(x0a6f7002484e4f46);
		xaf807f6784ee1744.x06b0e25aa6ad68a9(xe134235b3526fa75, xbd275f4c48a1b4c6, x7f6c4e8aaf0db1ab);
	}

	internal static void xe292217eeca8ebc0(BinaryReader xe134235b3526fa75, StringCollection x0a6f7002484e4f46)
	{
		xaf807f6784ee1743 xaf807f6784ee1744 = new xaf807f6784ee1743(x0a6f7002484e4f46);
		xaf807f6784ee1744.xe292217eeca8ebc0(xe134235b3526fa75);
	}

	internal static int x6210059f049f0d48(BinaryWriter xbdfb620b7167944b, StringCollection x0a6f7002484e4f46)
	{
		return x6210059f049f0d48(xbdfb620b7167944b, x0a6f7002484e4f46, x4f5b2499ca42a09c: false);
	}

	internal static int x6210059f049f0d48(BinaryWriter xbdfb620b7167944b, StringCollection x0a6f7002484e4f46, bool x4f5b2499ca42a09c)
	{
		xaf807f6784ee1743 xaf807f6784ee1744 = new xaf807f6784ee1743(x0a6f7002484e4f46);
		return xaf807f6784ee1744.x6210059f049f0d48(xbdfb620b7167944b, x4f5b2499ca42a09c);
	}

	protected override void DoReadExtraData(string name, BinaryReader dataReader)
	{
		x844a06e73f5fb69e.Add(name);
	}

	protected override int DoGetCountForWrite()
	{
		return x844a06e73f5fb69e.Count;
	}

	protected override int DoGetExtraDataSize()
	{
		return 0;
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		StringEnumerator enumerator = x844a06e73f5fb69e.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				x6f211c5eac49c71c.x3d1be38abe5723e3(current, writer);
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
	}
}
