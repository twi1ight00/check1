using System.Drawing;
using System.IO;
using System.Text;
using ns224;

namespace ns264;

internal class Class6498 : BinaryReader
{
	internal Class6498(Stream stream)
		: base(stream)
	{
	}

	internal int[] method_0()
	{
		int length = base.ReadInt32();
		return method_1(length);
	}

	internal int[] method_1(int length)
	{
		int[] array = new int[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = base.ReadInt32();
		}
		return array;
	}

	internal int[] method_2(int length)
	{
		int[] array = new int[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = base.ReadInt16();
		}
		return array;
	}

	internal float[] method_3()
	{
		int length = base.ReadInt32();
		return method_4(length);
	}

	internal float[] method_4(int length)
	{
		float[] array = new float[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = base.ReadSingle();
		}
		return array;
	}

	internal string method_5(int charCount)
	{
		int num = charCount * 2;
		byte[] array = base.ReadBytes(num);
		int i;
		for (i = 0; i < num && (array[i] != 0 || array[i + 1] != 0); i += 2)
		{
		}
		return Encoding.Unicode.GetString(array, 0, i);
	}

	internal PointF method_6()
	{
		int num = base.ReadInt32();
		int num2 = base.ReadInt32();
		return new PointF(num, num2);
	}

	internal SizeF method_7()
	{
		int num = base.ReadInt32();
		int num2 = base.ReadInt32();
		return new SizeF(num, num2);
	}

	internal RectangleF method_8()
	{
		return RectangleF.FromLTRB(ReadInt32(), ReadInt32(), ReadInt32(), ReadInt32());
	}

	internal Class5998 method_9()
	{
		int r = base.ReadByte();
		int g = base.ReadByte();
		int b = base.ReadByte();
		base.ReadByte();
		return new Class5998(r, g, b);
	}

	internal PointF[] method_10()
	{
		int length = base.ReadInt32();
		return method_11(length);
	}

	internal PointF[] method_11(int length)
	{
		PointF[] array = new PointF[length];
		for (int i = 0; i < length; i++)
		{
			int num = base.ReadInt32();
			int num2 = base.ReadInt32();
			ref PointF reference = ref array[i];
			reference = new PointF(num, num2);
		}
		return array;
	}

	internal PointF[] method_12()
	{
		int length = base.ReadInt32();
		return method_13(length);
	}

	internal PointF[] method_13(int length)
	{
		PointF[] array = new PointF[length];
		for (int i = 0; i < length; i++)
		{
			int num = base.ReadInt16();
			int num2 = base.ReadInt16();
			ref PointF reference = ref array[i];
			reference = new PointF(num, num2);
		}
		return array;
	}

	internal PointF[][] method_14()
	{
		int num = base.ReadInt32();
		base.ReadInt32();
		PointF[][] array = new PointF[num][];
		int[] array2 = method_1(num);
		for (int i = 0; i < num; i++)
		{
			array[i] = method_11(array2[i]);
		}
		return array;
	}

	internal PointF[][] method_15()
	{
		int num = base.ReadInt32();
		base.ReadInt32();
		PointF[][] array = new PointF[num][];
		int[] array2 = method_1(num);
		for (int i = 0; i < num; i++)
		{
			array[i] = method_13(array2[i]);
		}
		return array;
	}

	internal Class6002 method_16()
	{
		float m = ReadSingle();
		float m2 = ReadSingle();
		float m3 = ReadSingle();
		float m4 = ReadSingle();
		float m5 = ReadSingle();
		float m6 = ReadSingle();
		return new Class6002(m, m2, m3, m4, m5, m6);
	}

	internal Enum857[] method_17(int length)
	{
		Enum857[] array = new Enum857[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = (Enum857)base.ReadByte();
		}
		return array;
	}
}
