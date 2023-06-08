using System.IO;

namespace xa604c4d210ae0581;

internal class x4e1a1265364c495c : xf67718a36ff889c3
{
	internal const int xa230444f4711f2cc = 13;

	internal const int x7a15815641e1755f = 12;

	internal int xa7fd93208ce6c30b;

	internal x4e1a1265364c495c(BinaryReader reader)
	{
		xa7fd93208ce6c30b = reader.ReadByte();
		reader.BaseStream.Seek(12L, SeekOrigin.Current);
	}

	internal x4e1a1265364c495c(int wordOffset)
	{
		xa7fd93208ce6c30b = wordOffset;
	}

	private void x85313d56ab6f266e(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((byte)xa7fd93208ce6c30b);
		xbdfb620b7167944b.BaseStream.Seek(12L, SeekOrigin.Current);
	}

	void xf67718a36ff889c3.x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x85313d56ab6f266e
		this.x85313d56ab6f266e(xbdfb620b7167944b);
	}
}
