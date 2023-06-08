using System.IO;
using System.Text;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace x2182451cabb5c30d;

internal class x03f56b37a0050a82
{
	private xe47a4d4f9d1aa906 xc67369e42f67472e;

	private readonly MemoryStream xd4251e57da4db8b6 = new MemoryStream();

	private int x92db6d5a5ff1f498;

	private readonly StringBuilder xe3a2e8b966c97b79 = new StringBuilder();

	private string x87dbae9535b3cf18;

	private bool x51159a269b86324d;

	private int x3aedd8ccc482410e;

	private readonly StringBuilder x9913fbaf0b91e577 = new StringBuilder();

	private byte[] x070d1797ad5f50db;

	internal xe47a4d4f9d1aa906 x77dc43988eaceb1c => xc67369e42f67472e;

	internal int x1be93eed8950d961 => (int)xd4251e57da4db8b6.Length;

	internal int x12576604d05c627a
	{
		get
		{
			return x92db6d5a5ff1f498;
		}
		set
		{
			x92db6d5a5ff1f498 = value;
		}
	}

	internal byte[] xd181aea83ad73c96
	{
		get
		{
			return x070d1797ad5f50db;
		}
		set
		{
			x070d1797ad5f50db = value;
		}
	}

	internal bool x01175ba8d76995be => x9f1a6a3451a38d10() == ";";

	internal bool x23bf7b5d9dee25de => xc67369e42f67472e == xe47a4d4f9d1aa906.xbb3b746e67ad7684;

	internal bool x5c3e5f6c95f2f83a => x9f1a6a3451a38d10().EndsWith(";");

	internal int xf1e97d28a3ee95a9 => x9913fbaf0b91e577.Length;

	internal x03f56b37a0050a82()
	{
	}

	internal x03f56b37a0050a82(xe47a4d4f9d1aa906 tokenType)
	{
		xc67369e42f67472e = tokenType;
	}

	internal void x74f5a1ef3906e23c(xe47a4d4f9d1aa906 x57f6ed0b38a53016)
	{
		xc67369e42f67472e = x57f6ed0b38a53016;
		xd4251e57da4db8b6.SetLength(0L);
		x92db6d5a5ff1f498 = 0;
		x87dbae9535b3cf18 = null;
		x51159a269b86324d = false;
		x3aedd8ccc482410e = 0;
		x9913fbaf0b91e577.Length = 0;
		x070d1797ad5f50db = null;
	}

	internal void xc351d479ff7ee789(int xe7ebe10fa44d8d49)
	{
		xd4251e57da4db8b6.WriteByte((byte)xe7ebe10fa44d8d49);
	}

	internal string x1dafd189c5465293()
	{
		if (xc67369e42f67472e != xe47a4d4f9d1aa906.xbb3b746e67ad7684)
		{
			return "";
		}
		if (x87dbae9535b3cf18 != null)
		{
			return x87dbae9535b3cf18;
		}
		xd4251e57da4db8b6.Position = 0L;
		xe3a2e8b966c97b79.Length = 0;
		int num = (int)xd4251e57da4db8b6.Length - x92db6d5a5ff1f498;
		for (int i = 0; i < num; i++)
		{
			xe3a2e8b966c97b79.Append((char)xd4251e57da4db8b6.ReadByte());
		}
		x87dbae9535b3cf18 = xe3a2e8b966c97b79.ToString();
		return x87dbae9535b3cf18;
	}

	internal byte[] xbfeb690f3f95a932()
	{
		string text = x9f1a6a3451a38d10().Trim();
		int num = text.Length / 2;
		byte[] array = new byte[num];
		for (int i = 0; i < num; i++)
		{
			int num2 = x0d299f323d241756.xe3ec68422266caf1(text[i * 2]);
			int num3 = x0d299f323d241756.xe3ec68422266caf1(text[i * 2 + 1]);
			array[i] = (byte)((num2 << 4) | num3);
		}
		return array;
	}

	internal bool x1ad7968449b109cd()
	{
		switch (x92db6d5a5ff1f498)
		{
		case 0:
			return true;
		case 1:
		{
			xd4251e57da4db8b6.Position = xd4251e57da4db8b6.Length - 1;
			int num = xd4251e57da4db8b6.ReadByte();
			return num == 49;
		}
		default:
			return false;
		}
	}

	internal x9b28b1f7f0cc963f xc55827845a964d45()
	{
		return x9b28b1f7f0cc963f.x1e5f5c3e4c508bf0(x1ad7968449b109cd());
	}

	internal string x8b1c61c709b6f253()
	{
		string text = x9f1a6a3451a38d10();
		if (x5c3e5f6c95f2f83a)
		{
			return text.Substring(0, text.Length - 1);
		}
		return text;
	}

	internal void xae40f82718c98fb1(char x3c4da2980d043c95)
	{
		x74f5a1ef3906e23c(xe47a4d4f9d1aa906.x08c5d9f4b0653c8d);
		xa5ab4b86ecf60eca(x3c4da2980d043c95);
	}

	internal void xdbac92cad578ee39(string xe4115acdf4fbfccc)
	{
		x74f5a1ef3906e23c(xe47a4d4f9d1aa906.xbb3b746e67ad7684);
		for (int i = 0; i < xe4115acdf4fbfccc.Length; i++)
		{
			xd4251e57da4db8b6.WriteByte((byte)xe4115acdf4fbfccc[i]);
		}
	}

	internal void xadbb31d0e87f1677(Encoding xff3edc9aa5f0523b)
	{
		xa5ab4b86ecf60eca(xff3edc9aa5f0523b.GetString(xd4251e57da4db8b6.ToArray()));
	}

	internal void xd373314879c5ac75(string xbcea506a33cf9111)
	{
		x9913fbaf0b91e577.Append(xbcea506a33cf9111);
	}

	private void xa5ab4b86ecf60eca(char x3c4da2980d043c95)
	{
		x9913fbaf0b91e577.Length = 0;
		x9913fbaf0b91e577.Append(x3c4da2980d043c95);
	}

	private void xa5ab4b86ecf60eca(string xe4115acdf4fbfccc)
	{
		x9913fbaf0b91e577.Length = 0;
		x9913fbaf0b91e577.Append(xe4115acdf4fbfccc);
	}

	internal string x9f1a6a3451a38d10()
	{
		return x9913fbaf0b91e577.ToString();
	}

	internal int xd6f9e3c5ae6509d7()
	{
		if (x51159a269b86324d)
		{
			return x3aedd8ccc482410e;
		}
		x51159a269b86324d = true;
		x3aedd8ccc482410e = 0;
		if (x92db6d5a5ff1f498 == 0)
		{
			return x3aedd8ccc482410e;
		}
		xd4251e57da4db8b6.Position = xd4251e57da4db8b6.Length - x92db6d5a5ff1f498;
		int num = xd4251e57da4db8b6.ReadByte();
		bool flag = num == 45;
		int num2;
		if (flag)
		{
			num2 = x92db6d5a5ff1f498 - 1;
		}
		else
		{
			num2 = x92db6d5a5ff1f498;
			xd4251e57da4db8b6.Position -= 1;
		}
		for (int num3 = num2 - 1; num3 >= 0; num3--)
		{
			num = xd4251e57da4db8b6.ReadByte();
			if (num == 46)
			{
				break;
			}
			int num4 = num - 48;
			if (x3aedd8ccc482410e > 214748364)
			{
				break;
			}
			x3aedd8ccc482410e *= 10;
			if (x3aedd8ccc482410e + num4 > int.MaxValue)
			{
				break;
			}
			x3aedd8ccc482410e += num4;
		}
		if (flag)
		{
			x3aedd8ccc482410e = -x3aedd8ccc482410e;
		}
		return x3aedd8ccc482410e;
	}
}
