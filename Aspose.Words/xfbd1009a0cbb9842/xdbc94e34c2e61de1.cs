using System.Text;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal class xdbc94e34c2e61de1
{
	private readonly StringBuilder x800085dd555f7711 = new StringBuilder();

	private x98739d759efb5fe7 x558f176dc2e279e5 = x98739d759efb5fe7.x825c3b6fa3e39f20;

	private x98739d759efb5fe7 x3afe1d621db6d118 = x98739d759efb5fe7.x825c3b6fa3e39f20;

	internal string xf9ad6fb78355fe13 => x800085dd555f7711.ToString();

	internal int x1be93eed8950d961 => x800085dd555f7711.Length;

	internal bool x149a4512fc76c776
	{
		get
		{
			if (x1be93eed8950d961 > 0)
			{
				return true;
			}
			if (x558f176dc2e279e5.x30d6662e83251ab4)
			{
				return !x3afe1d621db6d118.x30d6662e83251ab4;
			}
			return true;
		}
	}

	internal x98739d759efb5fe7 x0bcabe1c3230f8a6 => x558f176dc2e279e5;

	internal x98739d759efb5fe7 xe7417f6a11716af5 => x3afe1d621db6d118;

	internal void x1f96778a29980753(x5c928e5f0a98a22c x9af1c2b12bb7a91a)
	{
		if (!x149a4512fc76c776)
		{
			x558f176dc2e279e5 = x9af1c2b12bb7a91a.x80766db8f9759629();
		}
		if (x9af1c2b12bb7a91a.xd420ac3415caa02b == x1b9dfa914d94b6e0.x6fe652a9a79f74c7)
		{
			x800085dd555f7711.Append(x9af1c2b12bb7a91a.x1efcac262b819134);
		}
	}

	internal void x9ed442c1833e090b(x5c928e5f0a98a22c x9af1c2b12bb7a91a)
	{
		if (!x558f176dc2e279e5.x30d6662e83251ab4)
		{
			x3afe1d621db6d118 = x9af1c2b12bb7a91a.x80766db8f9759629();
		}
	}

	internal void x551aecbd188f3fc8(char x3c4da2980d043c95)
	{
		x800085dd555f7711.Append(x3c4da2980d043c95);
	}

	internal void xa9d636b00ff486b7()
	{
		x800085dd555f7711.Length = 0;
		x558f176dc2e279e5 = x98739d759efb5fe7.x825c3b6fa3e39f20;
		x3afe1d621db6d118 = x98739d759efb5fe7.x825c3b6fa3e39f20;
	}

	internal void x4e44137a7ec5c645(xdbc94e34c2e61de1 xd07ce4b74c5774a7)
	{
		if (xd07ce4b74c5774a7.x149a4512fc76c776)
		{
			if (!x149a4512fc76c776)
			{
				x558f176dc2e279e5 = xd07ce4b74c5774a7.x0bcabe1c3230f8a6;
			}
			x3afe1d621db6d118 = xd07ce4b74c5774a7.xe7417f6a11716af5;
			x800085dd555f7711.Append(xd07ce4b74c5774a7.xf9ad6fb78355fe13);
			xd07ce4b74c5774a7.xa9d636b00ff486b7();
		}
	}

	internal x7e263f21a73a027a x451c3f5e0b9f8822()
	{
		return new x7e263f21a73a027a(x558f176dc2e279e5, x3afe1d621db6d118);
	}
}
