using System;
using System.Drawing;
using System.Text;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x74500b509de15565;
using xeb665d1aeef09d64;

namespace xf269d97e8a02e911;

internal class x3cc1f6fa2c94cf17 : xbadcaf18b423f918
{
	public const string x24fe1274033c7866 = "Microsoft Sans Serif";

	public const float x078fee20a1529fce = 12f;

	private int x4b088f70e8b96620;

	private FontStyle x6d086e6c01ed6b93;

	private int x8918dc7c534575e5;

	private int x2df8141d57fbf5e5;

	private int x8757d6e73d955cca;

	private bool xdfebec19c51b4843;

	private bool xa68cb11d4b5dd9ab;

	private bool x0fb39f8e1529b913;

	private int x4324adbcbde121c7;

	private string xd0c79c1487a8c8db;

	x1c26f4f3c6f98ecc xbadcaf18b423f918.xfae96ceb2d396a78 => x1c26f4f3c6f98ecc.xc2d4efc42998d87b;

	public int x7efbe0a2dc0d335f
	{
		get
		{
			return x4b088f70e8b96620;
		}
		set
		{
			x4b088f70e8b96620 = value;
		}
	}

	internal Encoding x9ee491ab5579b9fc
	{
		get
		{
			int codepage = xe4b3641e8e4ef359.x7e0944f4a3af6926(xbab94787eb927948, 1252);
			return Encoding.GetEncoding(codepage);
		}
	}

	internal float x05c1c7396142396f => (float)x2df8141d57fbf5e5 / 10f;

	internal string x77a92edb600f019b
	{
		get
		{
			return xd0c79c1487a8c8db;
		}
		set
		{
			xd0c79c1487a8c8db = value;
		}
	}

	internal int xbab94787eb927948 => x4324adbcbde121c7;

	internal x3cc1f6fa2c94cf17()
	{
		x8918dc7c534575e5 = 0;
		x2df8141d57fbf5e5 = 0;
		x8757d6e73d955cca = 0;
		x6d086e6c01ed6b93 = FontStyle.Regular;
		xdfebec19c51b4843 = false;
		xa68cb11d4b5dd9ab = false;
		x0fb39f8e1529b913 = false;
		xd0c79c1487a8c8db = "Microsoft Sans Serif";
	}

	internal void xda72e69795827549(xa1f7a3d42bca7cb8 xe134235b3526fa75)
	{
		x8918dc7c534575e5 = xe134235b3526fa75.ReadInt16();
		xe134235b3526fa75.ReadInt16();
		x2df8141d57fbf5e5 = xe134235b3526fa75.ReadInt16();
		xe134235b3526fa75.ReadInt16();
		x8757d6e73d955cca = xe134235b3526fa75.ReadInt16();
		xdfebec19c51b4843 = xe134235b3526fa75.ReadBoolean();
		xa68cb11d4b5dd9ab = xe134235b3526fa75.ReadBoolean();
		x0fb39f8e1529b913 = xe134235b3526fa75.ReadBoolean();
		x4324adbcbde121c7 = xe134235b3526fa75.ReadByte();
		xe134235b3526fa75.ReadByte();
		xe134235b3526fa75.ReadByte();
		xe134235b3526fa75.ReadByte();
		xe134235b3526fa75.ReadByte();
		xd0c79c1487a8c8db = x09d499c483428bd1.x728c19b085a53832(xe134235b3526fa75.x2a1ea9d24e62bf84(32, x9ee491ab5579b9fc));
		x3c9bc56d34f3ace4();
	}

	internal void x5023e134b4415253(x28a5d52551b64191 xe134235b3526fa75)
	{
		x4b088f70e8b96620 = xe134235b3526fa75.ReadInt32();
		x8918dc7c534575e5 = xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		x2df8141d57fbf5e5 = xe134235b3526fa75.ReadInt32();
		xe134235b3526fa75.ReadInt32();
		x8757d6e73d955cca = xe134235b3526fa75.ReadInt32();
		xdfebec19c51b4843 = xe134235b3526fa75.ReadBoolean();
		xa68cb11d4b5dd9ab = xe134235b3526fa75.ReadBoolean();
		x0fb39f8e1529b913 = xe134235b3526fa75.ReadBoolean();
		x4324adbcbde121c7 = xe134235b3526fa75.ReadByte();
		xe134235b3526fa75.ReadByte();
		xe134235b3526fa75.ReadByte();
		xe134235b3526fa75.ReadByte();
		xe134235b3526fa75.ReadByte();
		xd0c79c1487a8c8db = x09d499c483428bd1.x728c19b085a53832(xe134235b3526fa75.x2a1ea9d24e62bf84(32));
		x3c9bc56d34f3ace4();
	}

	internal xe39d06eee35dd23d x82e5e28f1251a140()
	{
		return x9d888f53892d94df.x9834ddb0e0bd5996.x491f5a7224612753(xd0c79c1487a8c8db, xc7d0ae7d4bcf5c8b(), x659bc4263aa7ef66(), "Microsoft Sans Serif");
	}

	private FontStyle x659bc4263aa7ef66()
	{
		if (x6d086e6c01ed6b93 != 0)
		{
			return x6d086e6c01ed6b93;
		}
		if (x8757d6e73d955cca >= 700)
		{
			x6d086e6c01ed6b93 |= FontStyle.Bold;
		}
		if (xdfebec19c51b4843)
		{
			x6d086e6c01ed6b93 |= FontStyle.Italic;
		}
		if (xa68cb11d4b5dd9ab)
		{
			x6d086e6c01ed6b93 |= FontStyle.Underline;
		}
		if (x0fb39f8e1529b913)
		{
			x6d086e6c01ed6b93 |= FontStyle.Strikeout;
		}
		return x6d086e6c01ed6b93;
	}

	private float xc7d0ae7d4bcf5c8b()
	{
		if (x8918dc7c534575e5 != 0)
		{
			return Math.Abs(x8918dc7c534575e5);
		}
		return 12f;
	}

	private void x3c9bc56d34f3ace4()
	{
		if (xd0c79c1487a8c8db.StartsWith("@"))
		{
			x8918dc7c534575e5 = x15e971129fd80714.x43fcc3f62534530b((double)x8918dc7c534575e5 * 0.8);
			xd0c79c1487a8c8db = xd0c79c1487a8c8db.Substring(1, xd0c79c1487a8c8db.Length - 1);
		}
	}
}
