using System.IO;

namespace xa604c4d210ae0581;

internal class x5c12f3cc90da0a84 : x9dba795deb731d48
{
	internal x5c12f3cc90da0a84(byte[] data)
		: base(data)
	{
	}

	internal x5c12f3cc90da0a84(BinaryReader reader)
	{
		int count = reader.ReadInt16();
		base.x6b73aa01aa019d3a = reader.ReadBytes(count);
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		x6210059f049f0d48(xbdfb620b7167944b, x0381b6dfdcc2d7b9: false);
	}
}
