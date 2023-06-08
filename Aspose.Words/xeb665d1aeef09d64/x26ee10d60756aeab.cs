using System;
using System.Collections;
using System.Drawing;
using x13f1efc79617a47b;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xeb665d1aeef09d64;

internal class x26ee10d60756aeab : x29ade4ed2382a039
{
	private readonly xe1f670dfbcd03c5c x154caea24cfa721a;

	private readonly ArrayList x6bdd4eb84ba9e673 = new ArrayList();

	private readonly IDictionary x6d83411e8f3c619e = xd51c34d05311eee3.xdb04a310bbb29cff();

	public ArrayList xc7b443f1cdbccfbe => x6bdd4eb84ba9e673;

	public x26ee10d60756aeab(x8989ff189b375934[] fontEntries)
	{
		x154caea24cfa721a = new xe1f670dfbcd03c5c(fontEntries);
	}

	public override x6b1a899052c71a60 FetchTTFont(string familyName, FontStyle style, string altFamilyName)
	{
		bool xe32a0a0f6650335e = false;
		x6b1a899052c71a60 x6b1a899052c71a = xdc2247c8d4648ae8(familyName, style);
		if (x6b1a899052c71a == null && x0d299f323d241756.x5959bccb67bbf051(altFamilyName))
		{
			x6b1a899052c71a = xdc2247c8d4648ae8(altFamilyName, style);
		}
		if (x6b1a899052c71a == null)
		{
			xe32a0a0f6650335e = true;
			x6b1a899052c71a = x96e7db792b9f6e0e(style);
		}
		if (x6b1a899052c71a == null)
		{
			x6b1a899052c71a = xd3f8e541b341f67a();
		}
		if (x6b1a899052c71a == null)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lpangbinacpnnbgolbnonbepgmkpjacajajalaabopgbhlnbfpecpplchaddlkjdooaeepheapoedpffpomfjjdgpnkgbobhdoihbophlmgidnnianejgmljcmcklhjkhmaldmhlcholdmfmelmmokdnggknglbojlioalpookgpmjnpbkeapfla", 922996920)));
		}
		xf0f0a3c9f9db7927(familyName, x6b1a899052c71a, xe32a0a0f6650335e);
		return x6b1a899052c71a;
	}

	internal override x6b1a899052c71a60 xdc2247c8d4648ae8(string xa79a9f649c74f4a4, FontStyle x44ecfea61c937b8e)
	{
		x6b1a899052c71a60 x6b1a899052c71a = x9d888f53892d94df.x9834ddb0e0bd5996.xdc2247c8d4648ae8(xa79a9f649c74f4a4, x44ecfea61c937b8e);
		if (x6b1a899052c71a == null)
		{
			x6b1a899052c71a = x154caea24cfa721a.xdc2247c8d4648ae8(xa79a9f649c74f4a4, x44ecfea61c937b8e);
		}
		return x6b1a899052c71a;
	}

	internal override x6b1a899052c71a60 x96e7db792b9f6e0e(FontStyle x44ecfea61c937b8e)
	{
		x6b1a899052c71a60 x6b1a899052c71a = x9d888f53892d94df.x9834ddb0e0bd5996.x96e7db792b9f6e0e(x44ecfea61c937b8e);
		if (x6b1a899052c71a == null)
		{
			x6b1a899052c71a = x154caea24cfa721a.xdc2247c8d4648ae8(x9d888f53892d94df.x9834ddb0e0bd5996.x24fe1274033c7866, x44ecfea61c937b8e);
		}
		return x6b1a899052c71a;
	}

	internal override x6b1a899052c71a60 xd3f8e541b341f67a()
	{
		x6b1a899052c71a60 x6b1a899052c71a = x9d888f53892d94df.x9834ddb0e0bd5996.xd3f8e541b341f67a();
		if (x6b1a899052c71a == null)
		{
			x6b1a899052c71a = x154caea24cfa721a.xd3f8e541b341f67a();
		}
		return x6b1a899052c71a;
	}

	private void xf0f0a3c9f9db7927(string xa79a9f649c74f4a4, x6b1a899052c71a60 x26094932cf7a9139, bool xe32a0a0f6650335e)
	{
		x377d898eb7908753 x377d898eb = (x377d898eb7908753)x6d83411e8f3c619e[xa79a9f649c74f4a4];
		if (x377d898eb == null)
		{
			x377d898eb = new x377d898eb7908753(xa79a9f649c74f4a4);
			x6d83411e8f3c619e[xa79a9f649c74f4a4] = x377d898eb;
		}
		x6b1a899052c71a60 x6b1a899052c71a = x377d898eb.xdc2247c8d4648ae8(x26094932cf7a9139.xfe2178c1f916f36c, xa456a0d7ead141be: false);
		if (x6b1a899052c71a == null || x6b1a899052c71a != x26094932cf7a9139)
		{
			x377d898eb.xd6b6ed77479ef68c(x26094932cf7a9139);
			if (xe32a0a0f6650335e)
			{
				xc59a1e906a9f6ee3(xa79a9f649c74f4a4, x26094932cf7a9139.x6054c4379c01a50d);
			}
		}
	}

	private void xc59a1e906a9f6ee3(string xbc9fca05086d275e, string x92b1b0855f30d937)
	{
		x6bdd4eb84ba9e673.Add(new xe82e7ab706bd4d43(x6d058fdf61831c39.x73d48b73a1b487ac, x3959df40367ac8a3.x2445f4cefb3cff80, $"Font '{xbc9fca05086d275e}' has not been found. Using '{x92b1b0855f30d937}' font instead."));
	}
}
