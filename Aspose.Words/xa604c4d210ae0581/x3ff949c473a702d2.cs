using System;
using System.IO;
using System.Text;
using x6c95d9cf46ff5f25;

namespace xa604c4d210ae0581;

internal class x3ff949c473a702d2 : x32939c68497cb083, x71d23a26ce0a5b23
{
	private const int xf423ee8a70720340 = 1;

	private const int x1f6bc2cba5a6e93d = 2;

	private const int x35ffb52d09644fbd = 485;

	private int xddd12ddd8b1e4a90;

	internal static bool x492f529cee830a40;

	internal int x8301ab10c226b0c2 => xddd12ddd8b1e4a90;

	internal x3ff949c473a702d2()
	{
	}

	internal x3ff949c473a702d2(BinaryReader reader, bool isInFKP)
	{
		int num2;
		if (isInFKP)
		{
			int num = reader.ReadByte();
			if (num == 0)
			{
				_ = x492f529cee830a40;
				num = reader.ReadByte();
				num2 = num * 2;
			}
			else
			{
				num2 = num * 2 - 1;
			}
		}
		else
		{
			num2 = reader.ReadInt16();
		}
		int num3;
		if (num2 > 0)
		{
			xddd12ddd8b1e4a90 = reader.ReadInt16();
			num3 = num2 - 2;
		}
		else
		{
			num3 = 0;
		}
		if (num3 > 0)
		{
			base.x6b73aa01aa019d3a = reader.ReadBytes(num3);
		}
		else
		{
			base.x6b73aa01aa019d3a = xcd4bd3abd72ff2da.x2b0797e1bb4e840a;
		}
	}

	internal x3ff949c473a702d2(int istd, byte[] data)
	{
		xddd12ddd8b1e4a90 = istd;
		base.x6b73aa01aa019d3a = data;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode() ^ xddd12ddd8b1e4a90;
	}

	internal bool Equals(x3ff949c473a702d2 rhs)
	{
		if (Equals((x32939c68497cb083)rhs))
		{
			return xddd12ddd8b1e4a90 == rhs.xddd12ddd8b1e4a90;
		}
		return false;
	}

	internal void x917b69030691beda(x32939c68497cb083 x24c45257571ea504)
	{
		byte[] array = new byte[base.x6b73aa01aa019d3a.Length + x24c45257571ea504.x6b73aa01aa019d3a.Length];
		base.x6b73aa01aa019d3a.CopyTo(array, 0);
		x24c45257571ea504.x6b73aa01aa019d3a.CopyTo(array, base.x6b73aa01aa019d3a.Length);
		base.x6b73aa01aa019d3a = array;
	}

	internal static x32939c68497cb083 x8300c23c6ee65fb7(BinaryReader xe134235b3526fa75, int xd59ec9a3f7a434cb)
	{
		if (xe134235b3526fa75 == null)
		{
			throw new ArgumentNullException("reader");
		}
		xe134235b3526fa75.BaseStream.Seek(xd59ec9a3f7a434cb, SeekOrigin.Begin);
		int grpprlSize = xe134235b3526fa75.ReadInt16();
		x32939c68497cb083 result = new x32939c68497cb083(xe134235b3526fa75, grpprlSize);
		_ = x492f529cee830a40;
		return result;
	}

	internal static bool x6f3e3e0c92cba9ab(x3ff949c473a702d2 x03ef0b0129c670a6)
	{
		return x03ef0b0129c670a6.x6b73aa01aa019d3a.Length > 485;
	}

	internal static x3ff949c473a702d2 x41e3dda3ab60a5ba(Stream x08414f6582e09cd6, x3ff949c473a702d2 x03ef0b0129c670a6)
	{
		int xbcea506a33cf = (int)x08414f6582e09cd6.Position;
		BinaryWriter binaryWriter = new BinaryWriter(x08414f6582e09cd6, Encoding.Unicode);
		binaryWriter.Write((short)x03ef0b0129c670a6.x6b73aa01aa019d3a.Length);
		binaryWriter.Write(x03ef0b0129c670a6.x6b73aa01aa019d3a);
		MemoryStream memoryStream = new MemoryStream();
		x354e9ebad65eecc8 x354e9ebad65eecc9 = new x354e9ebad65eecc8(memoryStream);
		x354e9ebad65eecc9.x138617e45a6d57be(x875aca5784596b73.xa58379af07dd1eca, xbcea506a33cf);
		return new x3ff949c473a702d2(x03ef0b0129c670a6.x8301ab10c226b0c2, memoryStream.ToArray());
	}

	public void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b, bool x0381b6dfdcc2d7b9)
	{
		if (x0381b6dfdcc2d7b9)
		{
			if (x0d299f323d241756.x7e32f71c3f39b6bc(base.x6b73aa01aa019d3a.Length))
			{
				int num = (3 + base.x6b73aa01aa019d3a.Length) / 2;
				xbdfb620b7167944b.Write((byte)num);
			}
			else
			{
				xbdfb620b7167944b.Write((byte)0);
				int num2 = (2 + base.x6b73aa01aa019d3a.Length) / 2;
				xbdfb620b7167944b.Write((byte)num2);
			}
		}
		else
		{
			int num3 = 2 + base.x6b73aa01aa019d3a.Length;
			xbdfb620b7167944b.Write((short)num3);
		}
		xbdfb620b7167944b.Write((short)xddd12ddd8b1e4a90);
		xbdfb620b7167944b.Write(base.x6b73aa01aa019d3a);
	}

	public int x1deebb03a3d03a50(bool x0381b6dfdcc2d7b9)
	{
		if (x0381b6dfdcc2d7b9)
		{
			int num = 3 + base.x6b73aa01aa019d3a.Length;
			if (x0d299f323d241756.x7e32f71c3f39b6bc(num))
			{
				num++;
			}
			return num;
		}
		return 4 + base.x6b73aa01aa019d3a.Length;
	}
}
