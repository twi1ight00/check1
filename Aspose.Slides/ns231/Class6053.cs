using System.Text;
using Aspose.Foundation.sfntly.typography.font.sfntly.table.truetype;
using ns226;
using ns229;

namespace ns231;

internal class Class6053 : Glyph
{
	internal class Class6086 : Class6084
	{
		public Class6086(Class6017 data, int offset, int length)
			: base((Class6017)data.vmethod_0(offset, length))
		{
		}

		public Class6086(Class6016 data, int offset, int length)
			: base((Class6016)data.vmethod_0(offset, length))
		{
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6053(data, 0, data.method_2());
		}
	}

	internal class Class6114 : Class6113
	{
		protected Class6114()
		{
		}
	}

	private static int int_2 = 1;

	private static int int_3 = 2;

	private static int int_4 = 4;

	private static int int_5 = 8;

	private static int int_6 = 16;

	private static int int_7 = 32;

	private int int_8;

	private int int_9;

	private int int_10;

	private int int_11;

	private int int_12;

	private int int_13;

	private int int_14;

	private int int_15;

	private int int_16;

	private int[] int_17;

	private int[] int_18;

	private bool[] bool_1;

	private int[] int_19;

	public Class6053(Class6016 data, int offset, int length)
		: base(data, offset, length, GlyphType.Simple)
	{
	}

	private Class6053(Class6016 data)
		: base(data, GlyphType.Simple)
	{
	}

	protected override void Initialize()
	{
		if (bool_0 || bool_0)
		{
			return;
		}
		if (method_0().method_2() == 0)
		{
			int_8 = 0;
			int_9 = 0;
			int_10 = 0;
			int_11 = 0;
			int_12 = 0;
			int_13 = 0;
			return;
		}
		int_8 = class6016_0.method_16(10 + method_8() * 2);
		int_10 = 10 + (method_8() + 1) * 2;
		int_11 = int_10 + int_8;
		int_9 = method_17(method_8() - 1) + 1;
		int_17 = new int[int_9];
		int_18 = new int[int_9];
		bool_1 = new bool[int_9];
		method_15(fillArrays: false);
		int_12 = int_11 + int_14;
		int_13 = int_12 + int_15;
		int_19 = new int[method_8() + 1];
		int_19[0] = 0;
		for (int i = 0; i < int_19.Length - 1; i++)
		{
			int_19[i + 1] = method_17(i) + 1;
		}
		method_15(fillArrays: true);
		int num = 10 + method_8() * 2 + 2 + int_8 + int_14 + int_15 + int_16;
		method_6(method_2() - num);
		bool_0 = true;
	}

	private void method_15(bool fillArrays)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		for (int i = 0; i < int_9; i++)
		{
			if (num2 == 0)
			{
				num = method_16(num3++);
				if ((num & int_5) == int_5)
				{
					num2 = method_16(num3++);
				}
			}
			else
			{
				num2--;
			}
			if (fillArrays)
			{
				bool_1[i] = (((num & int_2) == int_2) ? true : false);
			}
			if ((num & int_3) == int_3)
			{
				if (fillArrays)
				{
					int_17[i] = class6016_0.method_13(int_12 + num4);
					int_17[i] *= (((num & int_6) == int_6) ? 1 : (-1));
				}
				num4++;
			}
			else if ((num & int_6) != int_6)
			{
				if (fillArrays)
				{
					int_17[i] = class6016_0.method_17(int_12 + num4);
				}
				num4 += 2;
			}
			if (fillArrays && i > 0)
			{
				int_17[i] += int_17[i - 1];
			}
			if ((num & int_4) == int_4)
			{
				if (fillArrays)
				{
					int_18[i] = class6016_0.method_13(int_13 + num5);
					int_18[i] *= (((num & int_7) == int_7) ? 1 : (-1));
				}
				num5++;
			}
			else if ((num & int_7) != int_7)
			{
				if (fillArrays)
				{
					int_18[i] = class6016_0.method_17(int_13 + num5);
				}
				num5 += 2;
			}
			if (fillArrays && i > 0)
			{
				int_18[i] += int_18[i - 1];
			}
		}
		int_14 = num3;
		int_15 = num4;
		int_16 = num5;
	}

	private int method_16(int index)
	{
		return class6016_0.method_13(int_11 + index);
	}

	public int method_17(int contour)
	{
		return class6016_0.method_16(contour * 2 + 10);
	}

	public override int vmethod_1()
	{
		Initialize();
		return int_8;
	}

	public override Class6016 vmethod_2()
	{
		Initialize();
		return (Class6016)class6016_0.vmethod_0(int_10, vmethod_1());
	}

	public int method_18(int contour)
	{
		Initialize();
		if (contour >= method_8())
		{
			return 0;
		}
		return int_19[contour + 1] - int_19[contour];
	}

	public int method_19(int contour, int point)
	{
		Initialize();
		return int_17[int_19[contour] + point];
	}

	public int method_20(int contour, int point)
	{
		Initialize();
		return int_18[int_19[contour] + point];
	}

	public bool method_21(int contour, int point)
	{
		Initialize();
		return bool_1[int_19[contour] + point];
	}

	public string method_22()
	{
		Initialize();
		StringBuilder stringBuilder = new StringBuilder(method_13());
		stringBuilder.Append("\tinstruction bytes = " + vmethod_1() + "\n");
		for (int i = 0; i < method_8(); i++)
		{
			for (int j = 0; j < method_18(i); j++)
			{
				stringBuilder.Append("\t" + i + ":" + j + " = [" + method_19(i, j) + ", " + method_20(i, j) + ", " + method_21(i, j) + "]\n");
			}
		}
		return stringBuilder.ToString();
	}
}
