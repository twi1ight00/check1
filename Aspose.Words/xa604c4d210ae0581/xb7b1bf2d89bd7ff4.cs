using System.IO;

namespace xa604c4d210ae0581;

internal class xb7b1bf2d89bd7ff4 : xf67718a36ff889c3
{
	internal const int xa230444f4711f2cc = 12;

	internal short x4b51b678ce829190;

	internal uint x7d0bd15adbf82de2;

	internal short x562a56f0d1df5917;

	internal uint x7a940f2d4e5b2394;

	internal x735141fc00f56ce0 x34e183d0e3285c7e;

	internal xb7b1bf2d89bd7ff4()
	{
	}

	internal xb7b1bf2d89bd7ff4(BinaryReader reader)
	{
		x4b51b678ce829190 = reader.ReadInt16();
		x7d0bd15adbf82de2 = reader.ReadUInt32();
		x562a56f0d1df5917 = reader.ReadInt16();
		x7a940f2d4e5b2394 = reader.ReadUInt32();
	}

	private void x85313d56ab6f266e(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(x4b51b678ce829190);
		xbdfb620b7167944b.Write(x7d0bd15adbf82de2);
		xbdfb620b7167944b.Write(x562a56f0d1df5917);
		xbdfb620b7167944b.Write(x7a940f2d4e5b2394);
	}

	void xf67718a36ff889c3.x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x85313d56ab6f266e
		this.x85313d56ab6f266e(xbdfb620b7167944b);
	}
}
