using System.Drawing;
using System.IO;
using System.Text;
using ns224;

namespace ns264;

internal class Class6501 : BinaryReader
{
	internal Class6501(Stream stream)
		: base(stream)
	{
	}

	internal int[] method_0()
	{
		ushort length = base.ReadUInt16();
		return method_1(length);
	}

	internal int[] method_1(int length)
	{
		int[] array = new int[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = base.ReadInt16();
		}
		return array;
	}

	internal string method_2(int maxLength, Encoding encoding)
	{
		byte[] array = base.ReadBytes(maxLength);
		int i;
		for (i = 0; i < maxLength && array[i] != 0; i++)
		{
		}
		return encoding.GetString(array, 0, i);
	}

	internal PointF method_3()
	{
		short num = base.ReadInt16();
		short num2 = base.ReadInt16();
		return new PointF(num2, num);
	}

	internal Point method_4()
	{
		short y = base.ReadInt16();
		short x = base.ReadInt16();
		return new Point(x, y);
	}

	internal SizeF method_5()
	{
		short num = base.ReadInt16();
		short num2 = base.ReadInt16();
		return new SizeF(num2, num);
	}

	internal RectangleF method_6()
	{
		int[] array = method_1(4);
		return RectangleF.FromLTRB(array[0], array[1], array[2], array[3]);
	}

	internal RectangleF method_7()
	{
		int[] array = method_1(4);
		return RectangleF.FromLTRB(array[3], array[2], array[1], array[0]);
	}

	internal RectangleF method_8()
	{
		int[] array = method_1(4);
		return new RectangleF(array[3], array[2], array[1], array[0]);
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
		ushort length = base.ReadUInt16();
		return method_11(length);
	}

	internal PointF[] method_11(int length)
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

	internal PointF[][] method_12()
	{
		ushort num = base.ReadUInt16();
		PointF[][] array = new PointF[num][];
		int[] array2 = method_1(num);
		for (int i = 0; i < num; i++)
		{
			array[i] = method_11(array2[i]);
		}
		return array;
	}
}
