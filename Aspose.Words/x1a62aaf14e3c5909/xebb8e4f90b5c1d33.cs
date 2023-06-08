using System.IO;
using x13f1efc79617a47b;

namespace x1a62aaf14e3c5909;

internal class xebb8e4f90b5c1d33
{
	private int xca8d1b459aaab21b;

	private int xc1c3169b4f666022;

	private x773fe540042dad03 xf263b01e2956834c;

	private int x823c6b25cc2689d8;

	internal bool xffbe50541a5f9da3
	{
		get
		{
			return xca8d1b459aaab21b == 15;
		}
		set
		{
			xca8d1b459aaab21b = (value ? 15 : 0);
		}
	}

	internal int x77fa6322561797a0
	{
		get
		{
			return xca8d1b459aaab21b;
		}
		set
		{
			xca8d1b459aaab21b = value;
		}
	}

	internal int x9834ddb0e0bd5996
	{
		get
		{
			return xc1c3169b4f666022;
		}
		set
		{
			xc1c3169b4f666022 = value;
		}
	}

	internal x773fe540042dad03 x3146d638ec378671
	{
		get
		{
			return xf263b01e2956834c;
		}
		set
		{
			xf263b01e2956834c = value;
		}
	}

	internal int x1be93eed8950d961
	{
		get
		{
			return x823c6b25cc2689d8;
		}
		set
		{
			x823c6b25cc2689d8 = value;
		}
	}

	internal xebb8e4f90b5c1d33()
	{
	}

	internal xebb8e4f90b5c1d33(BinaryReader reader)
	{
		x06b0e25aa6ad68a9(reader);
	}

	public override string ToString()
	{
		return string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gmalbphldmolnnfmgnmmgndnenknonbofjiogipohlgpjnnpnmeapllabjcbpmjbbiaciihcdkocfmfdbhmdcgdefjkebkbflkifjkpfmjggpjngljeheglhckciffjiojajkehjldojbgfkdimkfidldiklngbmhhimjgpmiggnkdnniheomcloehcpacjpbbaakdhaafoagffbmembgfdchekcgbbdefidjapdafge", 1259909249)), xf263b01e2956834c, xca8d1b459aaab21b, xc1c3169b4f666022, x823c6b25cc2689d8);
	}

	internal void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75)
	{
		int num = xe134235b3526fa75.ReadInt32();
		xca8d1b459aaab21b = num & 0xF;
		xc1c3169b4f666022 = (num & 0xFFF0) >> 4;
		xf263b01e2956834c = (x773fe540042dad03)((num & 0xFFFF0000u) >> 16);
		x823c6b25cc2689d8 = xe134235b3526fa75.ReadInt32();
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		int num = 0;
		num |= xca8d1b459aaab21b;
		num |= xc1c3169b4f666022 << 4;
		num |= (int)xf263b01e2956834c << 16;
		xbdfb620b7167944b.Write(num);
		xbdfb620b7167944b.Write(x823c6b25cc2689d8);
	}
}
