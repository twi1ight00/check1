using System;
using System.Drawing;
using System.IO;
using System.Text;
using x5794c252ba25e723;
using xa7850104c8d8c135;

namespace x74500b509de15565;

internal class x28a5d52551b64191 : BinaryReader
{
	internal x28a5d52551b64191(Stream stream)
		: base(stream)
	{
	}

	internal int[] xdba4185013f2ac84()
	{
		int x961016a387451f = base.ReadInt32();
		return xdba4185013f2ac84(x961016a387451f);
	}

	internal int[] xdba4185013f2ac84(int x961016a387451f05)
	{
		int[] array = new int[x961016a387451f05];
		for (int i = 0; i < x961016a387451f05; i++)
		{
			array[i] = base.ReadInt32();
		}
		return array;
	}

	internal int[] x097eb7ae41ab0024(int x961016a387451f05)
	{
		int[] array = new int[x961016a387451f05];
		for (int i = 0; i < x961016a387451f05; i++)
		{
			array[i] = base.ReadInt16();
		}
		return array;
	}

	internal float[] x5472c0dae883be66()
	{
		int x961016a387451f = base.ReadInt32();
		return x5472c0dae883be66(x961016a387451f);
	}

	internal float[] x5472c0dae883be66(int x961016a387451f05)
	{
		float[] array = new float[x961016a387451f05];
		for (int i = 0; i < x961016a387451f05; i++)
		{
			array[i] = base.ReadSingle();
		}
		return array;
	}

	internal string x2a1ea9d24e62bf84(int xb4ec4aba4b97eacf)
	{
		int num = xb4ec4aba4b97eacf * 2;
		byte[] array = base.ReadBytes(num);
		int i;
		for (i = 0; i < num && (array[i] != 0 || array[i + 1] != 0); i += 2)
		{
		}
		return Encoding.Unicode.GetString(array, 0, i);
	}

	internal PointF x7e2a3c059f5793af()
	{
		int num = base.ReadInt32();
		int num2 = base.ReadInt32();
		return new PointF(num, num2);
	}

	internal PointF xa4a92a61b2092da6()
	{
		float x = base.ReadSingle();
		float y = base.ReadSingle();
		return new PointF(x, y);
	}

	internal SizeF xb4a9b516a22e4a7a()
	{
		int num = base.ReadInt32();
		int num2 = base.ReadInt32();
		return new SizeF(num, num2);
	}

	internal RectangleF x70a5bafbe8fbfeb2()
	{
		int val = ReadInt32();
		int val2 = ReadInt32();
		int val3 = ReadInt32();
		int val4 = ReadInt32();
		return RectangleF.FromLTRB(Math.Min(val, val3), Math.Min(val2, val4), Math.Max(val, val3), Math.Max(val2, val4));
	}

	public RectangleF x3b0757d2103a91b5()
	{
		return new RectangleF(ReadSingle(), ReadSingle(), ReadSingle(), ReadSingle());
	}

	internal x26d9ecb4bdf0456d x07d1b52af8293592()
	{
		int r = base.ReadByte();
		int g = base.ReadByte();
		int b = base.ReadByte();
		base.ReadByte();
		return new x26d9ecb4bdf0456d(r, g, b);
	}

	internal x26d9ecb4bdf0456d x458cbe2343cf2fba()
	{
		int b = base.ReadByte();
		int g = base.ReadByte();
		int r = base.ReadByte();
		int a = base.ReadByte();
		return new x26d9ecb4bdf0456d(a, r, g, b);
	}

	internal PointF[] x87f464b3767301f7(int x961016a387451f05)
	{
		PointF[] array = new PointF[x961016a387451f05];
		for (int i = 0; i < x961016a387451f05; i++)
		{
			ref PointF reference = ref array[i];
			reference = xa4a92a61b2092da6();
		}
		return array;
	}

	internal PointF[] x22cd88977f8c06b2()
	{
		int x961016a387451f = base.ReadInt32();
		return x22cd88977f8c06b2(x961016a387451f);
	}

	internal PointF[] x22cd88977f8c06b2(int x961016a387451f05)
	{
		PointF[] array = new PointF[x961016a387451f05];
		for (int i = 0; i < x961016a387451f05; i++)
		{
			int num = base.ReadInt32();
			int num2 = base.ReadInt32();
			ref PointF reference = ref array[i];
			reference = new PointF(num, num2);
		}
		return array;
	}

	internal PointF[] xfc6685e65ca6a644()
	{
		int x961016a387451f = base.ReadInt32();
		return xfc6685e65ca6a644(x961016a387451f);
	}

	internal PointF[] xfc6685e65ca6a644(int x961016a387451f05)
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
		int num = base.ReadInt32();
		base.ReadInt32();
		PointF[][] array = new PointF[num][];
		int[] array2 = xdba4185013f2ac84(num);
		for (int i = 0; i < num; i++)
		{
			array[i] = x22cd88977f8c06b2(array2[i]);
		}
		return array;
	}

	internal PointF[][] x1049ca045363ccd7()
	{
		int num = base.ReadInt32();
		base.ReadInt32();
		PointF[][] array = new PointF[num][];
		int[] array2 = xdba4185013f2ac84(num);
		for (int i = 0; i < num; i++)
		{
			array[i] = xfc6685e65ca6a644(array2[i]);
		}
		return array;
	}

	internal x54366fa5f75a02f7 x8c1dae79b4f085c4()
	{
		float m = ReadSingle();
		float m2 = ReadSingle();
		float m3 = ReadSingle();
		float m4 = ReadSingle();
		float m5 = ReadSingle();
		float m6 = ReadSingle();
		return new x54366fa5f75a02f7(m, m2, m3, m4, m5, m6);
	}

	internal x33f715239b303e2e[] x1565e70224fd3281(int x961016a387451f05)
	{
		x33f715239b303e2e[] array = new x33f715239b303e2e[x961016a387451f05];
		for (int i = 0; i < x961016a387451f05; i++)
		{
			array[i] = (x33f715239b303e2e)base.ReadByte();
		}
		return array;
	}

	internal x008aeca5918dcf49 x322e9b24055afef2()
	{
		int yDenom = ReadInt32();
		int yNum = ReadInt32();
		int xDenom = ReadInt32();
		int xNum = ReadInt32();
		return new x008aeca5918dcf49(yDenom, yNum, xDenom, xNum);
	}
}
