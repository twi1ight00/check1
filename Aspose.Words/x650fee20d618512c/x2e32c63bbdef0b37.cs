using System.Collections;
using System.IO;
using System.Text;

namespace x650fee20d618512c;

internal class x2e32c63bbdef0b37
{
	private const int xdbb7cb0c17e9ec6a = 2;

	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	internal int xd44988f225497f3a => x82b70567a5f68f41.Count;

	internal byte[] x6e6007b87273674e(int xc0c4c459c6ccbd00)
	{
		return (byte[])x82b70567a5f68f41[xc0c4c459c6ccbd00];
	}

	internal string xe2057a7a2a551874(int xc0c4c459c6ccbd00)
	{
		return Encoding.Unicode.GetString(x6e6007b87273674e(xc0c4c459c6ccbd00));
	}

	internal void x510567f1132da166(string xbcea506a33cf9111)
	{
		x9d4ceecf381e0ab8(Encoding.Unicode.GetBytes(xbcea506a33cf9111));
	}

	internal void x9d4ceecf381e0ab8(byte[] xbcea506a33cf9111)
	{
		x82b70567a5f68f41.Add(xbcea506a33cf9111);
	}

	internal void x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75, int xbd275f4c48a1b4c6, int x7f6c4e8aaf0db1ab)
	{
		if (x7f6c4e8aaf0db1ab != 0)
		{
			xe134235b3526fa75.BaseStream.Position = xbd275f4c48a1b4c6;
			xe134235b3526fa75.ReadUInt16();
			int num = xe134235b3526fa75.ReadInt16();
			xe134235b3526fa75.ReadUInt16();
			for (int i = 0; i < num; i++)
			{
				int num2 = xe134235b3526fa75.ReadInt16();
				byte[] value = xe134235b3526fa75.ReadBytes(num2 * 2);
				xe134235b3526fa75.ReadUInt16();
				x82b70567a5f68f41.Add(value);
			}
		}
	}

	internal int x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		int count = x82b70567a5f68f41.Count;
		if (count == 0)
		{
			return 0;
		}
		long position = xbdfb620b7167944b.BaseStream.Position;
		xbdfb620b7167944b.Write(ushort.MaxValue);
		xbdfb620b7167944b.Write((short)count);
		xbdfb620b7167944b.Write((short)2);
		for (int i = 0; i < count; i++)
		{
			byte[] array = (byte[])x82b70567a5f68f41[i];
			int num = array.Length / 2;
			xbdfb620b7167944b.Write((short)num);
			xbdfb620b7167944b.Write(array);
			xbdfb620b7167944b.Write((short)1);
		}
		return (int)(xbdfb620b7167944b.BaseStream.Position - position);
	}
}
