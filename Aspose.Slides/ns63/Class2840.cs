using System.IO;
using ns60;

namespace ns63;

internal class Class2840 : Class2623
{
	internal const int int_0 = 2032;

	private int[] int_1 = new int[8] { 16777215, 0, 8421504, 0, 14934203, 10040115, 10066176, 52377 };

	public int Color0 => int_1[0];

	public int Color1 => int_1[1];

	public int Color2 => int_1[2];

	public int Color3 => int_1[3];

	public int Color4 => int_1[4];

	public int Color5 => int_1[5];

	public int Color6 => int_1[6];

	public int Color7 => int_1[7];

	public Class2840()
	{
		base.Header.Instance = 1;
		base.Header.Type = 2032;
	}

	public void method_1(int index)
	{
		switch (index)
		{
		default:
			int_1 = new int[8] { 16777215, 0, 8421504, 0, 14934203, 10040115, 10066176, 52377 };
			break;
		case 0:
			int_1 = new int[8] { 16777215, 0, 8421504, 0, 14934203, 10040115, 10066176, 52377 };
			break;
		case 1:
			int_1 = new int[8] { 16777215, 0, 9868950, 0, 5496827, 6724095, 13260, 26265 };
			break;
		case 2:
			int_1 = new int[8] { 16777215, 0, 8421504, 0, 16764057, 16764108, 13382451, 16738223 };
			break;
		case 3:
			int_1 = new int[8] { 15857374, 0, 9868950, 0, 16777215, 16762509, 13395456, 43008 };
			break;
		case 4:
			int_1 = new int[8] { 14286847, 0, 7829367, 0, 16252927, 13421619, 5263615, 39423 };
			break;
		case 5:
			int_1 = new int[8] { 8421376, 16777215, 5790208, 10092543, 6448128, 13070189, 16776960, 65280 };
			break;
		case 6:
			int_1 = new int[8] { 128, 16777215, 8028, 9687775, 13260, 6322622, 10092543, 1680083 };
			break;
		case 7:
			int_1 = new int[8] { 10027008, 16777215, 6697728, 16777164, 13395507, 45056, 16764006, 124927 };
			break;
		case 8:
			int_1 = new int[8] { 0, 16777215, 10053171, 15854563, 10040064, 4950598, 16764006, 58864 };
			break;
		case 9:
			int_1 = new int[8] { 6122344, 16777215, 7829367, 13357521, 8556688, 11050624, 6737151, 12180713 };
			break;
		case 10:
			int_1 = new int[8] { 10053222, 16777215, 6045246, 16777215, 8083808, 16737894, 16764057, 10092543 };
			break;
		case 11:
			int_1 = new int[8] { 2506322, 16777215, 1384493, 9289951, 7371660, 3104655, 46284, 10526348 };
			break;
		}
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		for (int i = 0; i < 8; i++)
		{
			int_1[i] = reader.ReadInt32();
		}
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		for (int i = 0; i < 8; i++)
		{
			writer.Write(int_1[i]);
		}
	}

	public override int vmethod_2()
	{
		return 32;
	}

	public int method_2(int index)
	{
		if (index > 7)
		{
			index = 7;
		}
		if (index < 0)
		{
			index = 0;
		}
		return int_1[index];
	}

	public void method_3(int index, int color)
	{
		if (index > 7)
		{
			index = 7;
		}
		if (index < 0)
		{
			index = 0;
		}
		int_1[index] = ((color & 0xFF) << 16) + (color & 0xFF00) + ((color >> 16) & 0xFF);
	}
}
