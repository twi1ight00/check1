using System.IO;

namespace xa604c4d210ae0581;

internal class x3fdb33c580a0bef3
{
	internal int xe53f0e68147463d1;

	internal int x04c290dc4d04369c;

	internal x3fdb33c580a0bef3()
	{
		xe53f0e68147463d1 = 0;
		x04c290dc4d04369c = 0;
	}

	internal x3fdb33c580a0bef3(int fc, int lcb)
	{
		xe53f0e68147463d1 = fc;
		x04c290dc4d04369c = lcb;
	}

	internal void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75)
	{
		xe53f0e68147463d1 = xe134235b3526fa75.ReadInt32();
		x04c290dc4d04369c = xe134235b3526fa75.ReadInt32();
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(xe53f0e68147463d1);
		xbdfb620b7167944b.Write(x04c290dc4d04369c);
	}

	public override string ToString()
	{
		if (xe53f0e68147463d1 != 0 || x04c290dc4d04369c != 0)
		{
			return $"{xe53f0e68147463d1}, {x04c290dc4d04369c}";
		}
		return "-";
	}
}
