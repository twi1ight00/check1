using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;

namespace ns18;

internal class Class1420 : BinaryReader
{
	internal Class1420(Stream stream_0)
		: base(stream_0)
	{
	}

	internal int[] method_0()
	{
		int int_ = base.ReadInt32();
		return method_1(int_);
	}

	internal int[] method_1(int int_0)
	{
		int[] array = new int[int_0];
		for (int i = 0; i < int_0; i++)
		{
			array[i] = base.ReadInt32();
		}
		return array;
	}

	internal string method_2(int int_0)
	{
		int count = int_0 * 2;
		byte[] bytes = base.ReadBytes(count);
		string @string = Encoding.Unicode.GetString(bytes, 0, count);
		char[] trimChars = new char[1];
		return @string.Trim(trimChars);
	}

	internal PointF method_3()
	{
		int num = base.ReadInt32();
		int num2 = base.ReadInt32();
		return new PointF(num, num2);
	}

	internal SizeF method_4()
	{
		int num = base.ReadInt32();
		int num2 = base.ReadInt32();
		return new SizeF(num, num2);
	}

	internal RectangleF method_5()
	{
		int[] array = method_1(4);
		return RectangleF.FromLTRB(array[0], array[1], array[2], array[3]);
	}

	internal Color method_6()
	{
		byte red = base.ReadByte();
		byte green = base.ReadByte();
		byte blue = base.ReadByte();
		base.ReadByte();
		return Color.FromArgb(255, red, green, blue);
	}

	internal PointF[] method_7()
	{
		int int_ = base.ReadInt32();
		return method_8(int_);
	}

	internal PointF[] method_8(int int_0)
	{
		PointF[] array = new PointF[int_0];
		for (int i = 0; i < int_0; i++)
		{
			array[i].X = base.ReadInt32();
			array[i].Y = base.ReadInt32();
		}
		return array;
	}

	internal PointF[] method_9()
	{
		int int_ = base.ReadInt32();
		return method_10(int_);
	}

	internal PointF[] method_10(int int_0)
	{
		PointF[] array = new PointF[int_0];
		for (int i = 0; i < int_0; i++)
		{
			array[i].X = base.ReadInt16();
			array[i].Y = base.ReadInt16();
		}
		return array;
	}

	internal PointF[][] method_11()
	{
		int num = base.ReadInt32();
		base.ReadInt32();
		PointF[][] array = new PointF[num][];
		int[] array2 = method_1(num);
		for (int i = 0; i < num; i++)
		{
			array[i] = method_8(array2[i]);
		}
		return array;
	}

	internal PointF[][] method_12()
	{
		int num = base.ReadInt32();
		base.ReadInt32();
		PointF[][] array = new PointF[num][];
		int[] array2 = method_1(num);
		for (int i = 0; i < num; i++)
		{
			array[i] = method_10(array2[i]);
		}
		return array;
	}

	internal Matrix method_13()
	{
		float m = ReadSingle();
		float m2 = ReadSingle();
		float m3 = ReadSingle();
		float m4 = ReadSingle();
		float dx = ReadSingle();
		float dy = ReadSingle();
		return new Matrix(m, m2, m3, m4, dx, dy);
	}

	internal Enum164[] method_14(int int_0)
	{
		Enum164[] array = new Enum164[int_0];
		for (int i = 0; i < int_0; i++)
		{
			array[i] = (Enum164)base.ReadByte();
		}
		return array;
	}
}
