using System.IO;
using x5f3520a4b31ea90f;
using x6c95d9cf46ff5f25;

namespace xa604c4d210ae0581;

internal class x32939c68497cb083
{
	private byte[] x73f065a6b420cfe1;

	internal byte[] x6b73aa01aa019d3a
	{
		get
		{
			return x73f065a6b420cfe1;
		}
		set
		{
			x73f065a6b420cfe1 = value;
		}
	}

	internal x32939c68497cb083()
	{
	}

	internal x32939c68497cb083(byte[] data)
	{
		x73f065a6b420cfe1 = data;
	}

	internal x32939c68497cb083(BinaryReader reader, int grpprlSize)
	{
		x73f065a6b420cfe1 = reader.ReadBytes(grpprlSize);
	}

	internal x32939c68497cb083 x8b61531c8ea35b85()
	{
		return (x32939c68497cb083)MemberwiseClone();
	}

	public override int GetHashCode()
	{
		return (int)x5e4059a15fb5fca5.x5cc216ab9f5622aa(x73f065a6b420cfe1);
	}

	internal bool Equals(x32939c68497cb083 rhs)
	{
		return xcd4bd3abd72ff2da.xf920f15ca6067ada(x73f065a6b420cfe1, rhs.x73f065a6b420cfe1);
	}
}
