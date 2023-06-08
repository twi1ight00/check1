using System.IO;
using xa604c4d210ae0581;

namespace xaa035fc640f94856;

internal class x3d444db51c9a3385 : x3f476b1639f1fbe9, xf67718a36ff889c3
{
	internal const int xa230444f4711f2cc = 8;

	internal int x0eb0702491646dc9
	{
		get
		{
			return x0d1e53f2c8fd6fb3;
		}
		set
		{
			x0d1e53f2c8fd6fb3 = value;
		}
	}

	internal x3d444db51c9a3385()
	{
	}

	internal x3d444db51c9a3385(BinaryReader reader)
	{
		x0eb0702491646dc9 = reader.ReadInt32();
		x71e1774af0bcc655 = reader.ReadInt32();
	}

	private void x85313d56ab6f266e(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(x0eb0702491646dc9);
		xbdfb620b7167944b.Write(x71e1774af0bcc655);
	}

	void xf67718a36ff889c3.x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x85313d56ab6f266e
		this.x85313d56ab6f266e(xbdfb620b7167944b);
	}
}
