using System.IO;
using xa604c4d210ae0581;

namespace xaa035fc640f94856;

internal class xbcff2d724473288f : x3f476b1639f1fbe9, xf67718a36ff889c3
{
	internal const int xa230444f4711f2cc = 10;

	internal int x4a9eb9cfcb271717;

	internal int x481bfb52826b0a6e
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

	internal xbcff2d724473288f()
	{
	}

	internal xbcff2d724473288f(BinaryReader reader)
	{
		x481bfb52826b0a6e = reader.ReadInt32();
		x4a9eb9cfcb271717 = reader.ReadUInt16();
		x71e1774af0bcc655 = reader.ReadInt32();
	}

	private void x85313d56ab6f266e(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(x481bfb52826b0a6e);
		xbdfb620b7167944b.Write((ushort)x4a9eb9cfcb271717);
		xbdfb620b7167944b.Write(x71e1774af0bcc655);
	}

	void xf67718a36ff889c3.x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x85313d56ab6f266e
		this.x85313d56ab6f266e(xbdfb620b7167944b);
	}
}
