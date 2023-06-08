using System.Drawing;
using System.IO;
using System.Text;
using x5794c252ba25e723;

namespace x74500b509de15565;

internal class xa1f7a3d42bca7cb8 : BinaryReader
{
	internal xa1f7a3d42bca7cb8(Stream stream)
		: base(stream)
	{
	}

	internal int[] xdba4185013f2ac84()
	{
		ushort x961016a387451f = base.ReadUInt16();
		return xdba4185013f2ac84(x961016a387451f);
	}

	internal int[] xdba4185013f2ac84(int x961016a387451f05)
	{
		int[] array = new int[x961016a387451f05];
		for (int i = 0; i < x961016a387451f05; i++)
		{
			array[i] = base.ReadInt16();
		}
		return array;
	}

	internal string x2a1ea9d24e62bf84(int xcc5dca50464c8f6f, Encoding xff3edc9aa5f0523b)
	{
		byte[] array = base.ReadBytes(xcc5dca50464c8f6f);
		int i;
		for (i = 0; i < xcc5dca50464c8f6f && array[i] != 0; i++)
		{
		}
		return xff3edc9aa5f0523b.GetString(array, 0, i);
	}

	internal PointF x7e2a3c059f5793af()
	{
		short num = base.ReadInt16();
		short num2 = base.ReadInt16();
		return new PointF(num2, num);
	}

	internal Point x0d7313e4f6fc5d88()
	{
		short y = base.ReadInt16();
		short x = base.ReadInt16();
		return new Point(x, y);
	}

	internal SizeF xb4a9b516a22e4a7a()
	{
		short num = base.ReadInt16();
		short num2 = base.ReadInt16();
		return new SizeF(num2, num);
	}

	internal RectangleF x70a5bafbe8fbfeb2()
	{
		int[] array = xdba4185013f2ac84(4);
		return RectangleF.FromLTRB(array[0], array[1], array[2], array[3]);
	}

	internal RectangleF xf1575d122ac7f90e()
	{
		int[] array = xdba4185013f2ac84(4);
		return RectangleF.FromLTRB(array[3], array[2], array[1], array[0]);
	}

	internal RectangleF x5134dcd1deb72a24()
	{
		int[] array = xdba4185013f2ac84(4);
		return new RectangleF(array[3], array[2], array[1], array[0]);
	}

	internal x26d9ecb4bdf0456d x07d1b52af8293592()
	{
		int r = base.ReadByte();
		int g = base.ReadByte();
		int b = base.ReadByte();
		base.ReadByte();
		return new x26d9ecb4bdf0456d(r, g, b);
	}

	internal PointF[] x22cd88977f8c06b2()
	{
		ushort x961016a387451f = base.ReadUInt16();
		return x22cd88977f8c06b2(x961016a387451f);
	}

	internal PointF[] x22cd88977f8c06b2(int x961016a387451f05)
	{
		PointF[] array = new PointF[x961016a387451f05];
		for (int i = 0; i < x961016a387451f05; i++)
		{
			int num = base.ReadInt16();
			int num2 = base.ReadInt16();
			ref PointF reference = ref array[i];
			reference = new PointF(num, num2);
		}
		return array;
	}

	internal PointF[][] x155f861783e460dc()
	{
		ushort num = base.ReadUInt16();
		PointF[][] array = new PointF[num][];
		int[] array2 = xdba4185013f2ac84(num);
		for (int i = 0; i < num; i++)
		{
			array[i] = x22cd88977f8c06b2(array2[i]);
		}
		return array;
	}

	internal x008aeca5918dcf49 x322e9b24055afef2()
	{
		int yDenom = ReadInt16();
		int yNum = ReadInt16();
		int xDenom = ReadInt16();
		int xNum = ReadInt16();
		return new x008aeca5918dcf49(yDenom, yNum, xDenom, xNum);
	}
}
