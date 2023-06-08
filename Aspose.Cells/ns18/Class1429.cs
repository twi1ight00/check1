using System.Drawing;
using System.IO;
using System.Text;

namespace ns18;

internal class Class1429 : BinaryReader
{
	internal Class1429(Stream stream_0)
		: base(stream_0)
	{
	}

	internal int[] method_0(int int_0)
	{
		int[] array = new int[int_0];
		for (int i = 0; i < int_0; i++)
		{
			array[i] = base.ReadInt16();
		}
		return array;
	}

	internal string method_1(int int_0)
	{
		StringBuilder stringBuilder = new StringBuilder(int_0);
		for (int i = 0; i < int_0; i++)
		{
			byte b = base.ReadByte();
			if (b == 0)
			{
				break;
			}
			stringBuilder.Append((char)b);
		}
		return stringBuilder.ToString();
	}

	internal PointF method_2()
	{
		short num = base.ReadInt16();
		short num2 = base.ReadInt16();
		return new PointF(num2, num);
	}

	internal SizeF method_3()
	{
		short num = base.ReadInt16();
		short num2 = base.ReadInt16();
		return new SizeF(num2, num);
	}

	internal RectangleF method_4()
	{
		int[] array = method_0(4);
		return RectangleF.FromLTRB(array[3], array[2], array[1], array[0]);
	}

	internal RectangleF method_5()
	{
		int[] array = method_0(4);
		return new RectangleF(array[3], array[2], array[1], array[0]);
	}

	internal Color method_6()
	{
		byte red = base.ReadByte();
		byte green = base.ReadByte();
		byte blue = base.ReadByte();
		base.ReadByte();
		return Color.FromArgb(red, green, blue);
	}

	internal PointF[] method_7()
	{
		ushort int_ = base.ReadUInt16();
		return method_8(int_);
	}

	internal PointF[] method_8(int int_0)
	{
		PointF[] array = new PointF[int_0];
		for (int i = 0; i < int_0; i++)
		{
			array[i].X = base.ReadInt16();
			array[i].Y = base.ReadInt16();
		}
		return array;
	}

	internal PointF[][] method_9()
	{
		ushort num = base.ReadUInt16();
		PointF[][] array = new PointF[num][];
		int[] array2 = method_0(num);
		for (int i = 0; i < num; i++)
		{
			array[i] = method_8(array2[i]);
		}
		return array;
	}
}
