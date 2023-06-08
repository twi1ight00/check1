using System.IO;

namespace xeb665d1aeef09d64;

internal class x6033a882faba96b0 : x25998da3963930e9
{
	private readonly byte[] x73f065a6b420cfe1;

	public byte[] x6b73aa01aa019d3a => x73f065a6b420cfe1;

	public x6033a882faba96b0(byte[] data)
	{
		x73f065a6b420cfe1 = data;
	}

	public override Stream OpenStream()
	{
		return new MemoryStream(x6b73aa01aa019d3a);
	}

	public override int GetSize()
	{
		if (!DoesDataExist())
		{
			return 0;
		}
		return x6b73aa01aa019d3a.Length;
	}

	public override bool DoesDataExist()
	{
		return x6b73aa01aa019d3a != null;
	}
}
