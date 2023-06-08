using System.Collections;
using System.Text;
using Aspose.Foundation.sfntly.typography.font.sfntly.table.truetype;
using ns226;
using ns229;

namespace ns231;

internal class Class6052 : Glyph
{
	internal class Class6085 : Class6084
	{
		protected Class6085(Class6017 data, int offset, int length)
			: base((Class6017)data.vmethod_0(offset, length))
		{
		}

		internal Class6085(Class6016 data, int offset, int length)
			: base((Class6016)data.vmethod_0(offset, length))
		{
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6052(data);
		}
	}

	public static int int_2 = 1;

	public static int int_3 = 2;

	public static int int_4 = 4;

	public static int int_5 = 8;

	public static int int_6 = 16;

	public static int int_7 = 32;

	public static int int_8 = 64;

	public static int int_9 = 128;

	public static int int_10 = 256;

	public static int int_11 = 512;

	public static int int_12 = 1024;

	public static int int_13 = 2048;

	public static int int_14 = 4096;

	private ArrayList arrayList_0 = new ArrayList();

	private int int_15;

	private int int_16;

	internal Class6052(Class6016 data, int offset, int length)
		: base(data, offset, length, GlyphType.Composite)
	{
		Initialize();
	}

	internal Class6052(Class6016 data)
		: base(data, GlyphType.Composite)
	{
		Initialize();
	}

	protected override void Initialize()
	{
		if (bool_0 || bool_0)
		{
			return;
		}
		int num = 10;
		int num2 = int_7;
		while ((num2 & int_7) == int_7)
		{
			arrayList_0.Add(num);
			num2 = class6016_0.method_16(num);
			num += 4;
			num = (((num2 & int_2) != int_2) ? (num + 2) : (num + 4));
			if ((num2 & int_5) == int_5)
			{
				num += 2;
			}
			else if ((num2 & int_8) == int_8)
			{
				num += 4;
			}
			else if ((num2 & int_9) == int_9)
			{
				num += 8;
			}
		}
		int num3 = num;
		if ((num2 & int_10) == int_10)
		{
			int_16 = class6016_0.method_16(num);
			num3 = (int_15 = num + 2) + int_16;
		}
		method_6(method_2() - num3);
	}

	public int method_15(int contour)
	{
		return class6016_0.method_16((int)arrayList_0[contour]);
	}

	public int method_16()
	{
		return arrayList_0.Count;
	}

	public int method_17(int contour)
	{
		return class6016_0.method_16(2 + (int)arrayList_0[contour]);
	}

	public int method_18(int contour)
	{
		int index = 4 + (int)arrayList_0[contour];
		int num = method_15(contour);
		if ((num & int_2) == int_2)
		{
			return class6016_0.method_16(index);
		}
		return class6016_0.ReadByte(index);
	}

	public int method_19(int contour)
	{
		int num = 4 + (int)arrayList_0[contour];
		int num2 = method_15(contour);
		if ((num2 & int_2) == int_2)
		{
			return class6016_0.method_16(num + 2);
		}
		return class6016_0.ReadByte(num + 1);
	}

	public int method_20(int contour)
	{
		int num = method_15(contour);
		if ((num & int_5) == int_5)
		{
			return 2;
		}
		if ((num & int_8) == int_8)
		{
			return 4;
		}
		if ((num & int_9) == int_9)
		{
			return 8;
		}
		return 0;
	}

	public byte[] method_21(int contour)
	{
		int num = method_15(contour);
		int num2 = (int)arrayList_0[contour] + 4;
		num2 = (((num & int_2) != int_2) ? (num2 + 2) : (num2 + 4));
		int num3 = method_20(contour);
		byte[] array = new byte[num3];
		class6016_0.method_14(num2, array, 0, num3);
		return array;
	}

	public override int vmethod_1()
	{
		return int_16;
	}

	public override Class6016 vmethod_2()
	{
		return (Class6016)class6016_0.vmethod_0(int_15, vmethod_1());
	}

	public string method_22()
	{
		StringBuilder stringBuilder = new StringBuilder(method_13());
		stringBuilder.Append("\ncontourOffset.length = ");
		stringBuilder.Append(arrayList_0.Count);
		stringBuilder.Append("\ninstructionSize = ");
		stringBuilder.Append(int_16);
		stringBuilder.Append("\n\tcontour index = [");
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			if (i != 0)
			{
				stringBuilder.Append(", ");
			}
			stringBuilder.Append(arrayList_0[i]);
		}
		stringBuilder.Append("]\n");
		for (int j = 0; j < arrayList_0.Count; j++)
		{
			stringBuilder.Append("\t" + j + " = [gid = " + method_17(j) + ", arg1 = " + method_18(j) + ", arg2 = " + method_19(j) + "]\n");
		}
		return stringBuilder.ToString();
	}
}
