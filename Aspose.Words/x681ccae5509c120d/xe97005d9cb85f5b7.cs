using System.IO;
using xa604c4d210ae0581;

namespace x681ccae5509c120d;

internal class xe97005d9cb85f5b7 : xf67718a36ff889c3
{
	internal const int xa230444f4711f2cc = 4;

	internal int xff616fa638fdd6e3;

	internal int x2a76b84551a9607a;

	internal xe97005d9cb85f5b7()
	{
	}

	internal xe97005d9cb85f5b7(BinaryReader reader)
	{
		xff616fa638fdd6e3 = reader.ReadUInt16();
		x2a76b84551a9607a = reader.ReadUInt16();
	}

	private void x85313d56ab6f266e(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((ushort)xff616fa638fdd6e3);
		xbdfb620b7167944b.Write((ushort)x2a76b84551a9607a);
	}

	void xf67718a36ff889c3.x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x85313d56ab6f266e
		this.x85313d56ab6f266e(xbdfb620b7167944b);
	}
}
