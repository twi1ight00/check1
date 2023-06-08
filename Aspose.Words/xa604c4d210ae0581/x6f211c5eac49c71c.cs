using System.IO;
using Aspose;

namespace xa604c4d210ae0581;

internal abstract class x6f211c5eac49c71c
{
	internal void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, int xbd275f4c48a1b4c6, int x7f6c4e8aaf0db1ab)
	{
		if (x7f6c4e8aaf0db1ab == 0)
		{
			return;
		}
		xe134235b3526fa75.BaseStream.Position = xbd275f4c48a1b4c6;
		int num = xe134235b3526fa75.ReadUInt16();
		bool flag = num == 65535;
		int num2 = (flag ? xe134235b3526fa75.ReadInt16() : num);
		int num3 = xe134235b3526fa75.ReadInt16();
		if (num2 == 0 && num3 > 0)
		{
			num2 = 1;
		}
		int num4 = xbd275f4c48a1b4c6 + x7f6c4e8aaf0db1ab;
		for (int i = 0; i < num2; i++)
		{
			if (xe134235b3526fa75.BaseStream.Position >= num4)
			{
				break;
			}
			x2a1ea9d24e62bf84(xe134235b3526fa75, flag);
		}
	}

	internal void xe292217eeca8ebc0(BinaryReader xe134235b3526fa75)
	{
		int num = xe134235b3526fa75.ReadUInt16();
		bool flag = num == 65535;
		int num2 = (flag ? xe134235b3526fa75.ReadInt32() : num);
		xe134235b3526fa75.ReadInt16();
		for (int i = 0; i < num2; i++)
		{
			x2a1ea9d24e62bf84(xe134235b3526fa75, flag);
		}
	}

	private void x2a1ea9d24e62bf84(BinaryReader xe134235b3526fa75, bool x8ae067df85660589)
	{
		int x10f4d88af727adbc = (x8ae067df85660589 ? xe134235b3526fa75.ReadInt16() : xe134235b3526fa75.ReadByte());
		string name = new string(x93b05c1ad709a695.xc391923d699d676a(xe134235b3526fa75, x8ae067df85660589, x10f4d88af727adbc));
		DoReadExtraData(name, xe134235b3526fa75);
	}

	[JavaThrows(true)]
	protected abstract void DoReadExtraData(string name, BinaryReader dataReader);

	internal int x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		return x6210059f049f0d48(xbdfb620b7167944b, x4f5b2499ca42a09c: false);
	}

	internal int x6210059f049f0d48(BinaryWriter xbdfb620b7167944b, bool x4f5b2499ca42a09c)
	{
		int num = DoGetCountForWrite();
		if (num == 0 && !x4f5b2499ca42a09c)
		{
			return 0;
		}
		long position = xbdfb620b7167944b.BaseStream.Position;
		xbdfb620b7167944b.Write(ushort.MaxValue);
		if (x4f5b2499ca42a09c)
		{
			xbdfb620b7167944b.Write(num);
		}
		else
		{
			xbdfb620b7167944b.Write((short)num);
		}
		xbdfb620b7167944b.Write((short)DoGetExtraDataSize());
		DoWrite(xbdfb620b7167944b);
		return (int)(xbdfb620b7167944b.BaseStream.Position - position);
	}

	protected static void x3d1be38abe5723e3(string xbcea506a33cf9111, BinaryWriter xbdfb620b7167944b)
	{
		x93b05c1ad709a695.x4a3c44ae9b1cf5ab(xbcea506a33cf9111, int.MaxValue, xbdfb620b7167944b, x5be1cad1d00af914: true, xac1baf51b3e43d13: false);
	}

	protected abstract int DoGetCountForWrite();

	protected abstract int DoGetExtraDataSize();

	[JavaThrows(true)]
	protected abstract void DoWrite(BinaryWriter writer);
}
