using System.IO;

namespace xa604c4d210ae0581;

internal class x9dba795deb731d48 : x32939c68497cb083, x71d23a26ce0a5b23
{
	internal x9dba795deb731d48()
	{
	}

	internal x9dba795deb731d48(BinaryReader reader, bool isInFKP)
	{
		base.x6b73aa01aa019d3a = reader.ReadBytes((!isInFKP) ? reader.ReadInt16() : reader.ReadByte());
	}

	internal x9dba795deb731d48(byte[] data)
		: base(data)
	{
	}

	public void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b, bool x0381b6dfdcc2d7b9)
	{
		if (x0381b6dfdcc2d7b9)
		{
			xbdfb620b7167944b.Write((byte)base.x6b73aa01aa019d3a.Length);
		}
		else
		{
			xbdfb620b7167944b.Write((short)base.x6b73aa01aa019d3a.Length);
		}
		xbdfb620b7167944b.Write(base.x6b73aa01aa019d3a);
	}

	public int x1deebb03a3d03a50(bool x0381b6dfdcc2d7b9)
	{
		if (x0381b6dfdcc2d7b9)
		{
			if (base.x6b73aa01aa019d3a.Length == 0)
			{
				return 0;
			}
			return 1 + base.x6b73aa01aa019d3a.Length;
		}
		return 2 + base.x6b73aa01aa019d3a.Length;
	}
}
