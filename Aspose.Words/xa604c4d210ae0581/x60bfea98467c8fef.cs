using System.IO;

namespace xa604c4d210ae0581;

internal class x60bfea98467c8fef : xf67718a36ff889c3
{
	internal const int xa230444f4711f2cc = 12;

	private int xa3226e9591a56d2e;

	internal int xb2c71475f39bdeb3
	{
		get
		{
			return xa3226e9591a56d2e;
		}
		set
		{
			xa3226e9591a56d2e = value;
		}
	}

	internal x60bfea98467c8fef()
		: this(0)
	{
	}

	internal x60bfea98467c8fef(int fnpi)
	{
		xa3226e9591a56d2e = fnpi;
	}

	internal x60bfea98467c8fef(BinaryReader reader)
	{
		reader.ReadUInt16();
		reader.ReadUInt16();
		reader.ReadUInt16();
		xa3226e9591a56d2e = reader.ReadInt16();
		reader.ReadInt32();
	}

	public void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((ushort)0);
		xbdfb620b7167944b.Write((ushort)36);
		xbdfb620b7167944b.Write((ushort)2);
		xbdfb620b7167944b.Write((ushort)xa3226e9591a56d2e);
		xbdfb620b7167944b.Write(0);
	}
}
