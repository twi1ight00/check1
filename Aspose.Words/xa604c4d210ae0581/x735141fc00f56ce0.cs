using System.IO;

namespace xa604c4d210ae0581;

internal class x735141fc00f56ce0 : x32939c68497cb083
{
	internal x735141fc00f56ce0()
	{
	}

	internal x735141fc00f56ce0(byte[] data)
		: base(data)
	{
	}

	internal x735141fc00f56ce0(BinaryReader reader)
	{
		int count = reader.ReadInt16();
		base.x6b73aa01aa019d3a = reader.ReadBytes(count);
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((short)base.x6b73aa01aa019d3a.Length);
		xbdfb620b7167944b.Write(base.x6b73aa01aa019d3a);
	}
}
