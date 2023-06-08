using System;
using System.Text;
using ns183;
using ns205;

namespace ns182;

internal class Class4983 : Class4982
{
	private Class4983()
	{
	}

	public static int[] smethod_0(Interface238 cs, Class5444 defaultLevel)
	{
		int[] array = new int[cs.imethod_0()];
		if (!smethod_25(cs, array) && defaultLevel != Class5444.class5444_1)
		{
			return null;
		}
		return smethod_1(array, (defaultLevel == Class5444.class5444_1) ? 1 : 0, new int[array.Length]);
	}

	public static int[] smethod_1(int[] chars, int defaultLevel, int[] levels)
	{
		return smethod_2(chars, smethod_24(chars), defaultLevel, levels, useRuleL1: false);
	}

	public static int[] smethod_2(int[] chars, int[] classes, int defaultLevel, int[] levels, bool useRuleL1)
	{
		int[] wca = smethod_3(classes);
		int[] ea = new int[levels.Length];
		smethod_4(wca, defaultLevel, ea);
		smethod_8(wca, defaultLevel, ea, smethod_7(ea, levels));
		if (useRuleL1)
		{
			smethod_18(classes, defaultLevel, levels);
		}
		return levels;
	}

	private static int[] smethod_3(int[] ta)
	{
		int[] array = new int[ta.Length];
		Array.Copy(ta, 0, array, 0, array.Length);
		return array;
	}

	private static void smethod_4(int[] wca, int defaultLevel, int[] ea)
	{
		int[] array = new int[61];
		int num = 0;
		int num2 = defaultLevel;
		int i = 0;
		for (int num3 = wca.Length; i < num3; i++)
		{
			int num4 = wca[i];
			int num5;
			switch (num4)
			{
			case 16:
				num5 = (num2 = defaultLevel);
				num = 0;
				break;
			default:
				num5 = num2;
				break;
			case 2:
			case 3:
			case 6:
			case 7:
			{
				int num6 = ((num4 == 6 || num4 == 7) ? (((num2 & -129) + 1) | 1) : (((num2 & -129) + 2) & -2));
				if (num6 < 62)
				{
					array[num++] = num2;
					num2 = ((num4 == 3 || num4 == 7) ? (num6 | 0x80) : (num6 & -129));
				}
				num5 = num2;
				break;
			}
			case 8:
				num5 = num2;
				if (num > 0)
				{
					num2 = array[--num];
				}
				break;
			}
			switch (num4)
			{
			default:
				if (((uint)num5 & 0x80u) != 0)
				{
					wca[i] = smethod_5(num5);
				}
				break;
			case 2:
			case 3:
			case 6:
			case 7:
			case 8:
				wca[i] = 15;
				break;
			case 15:
				break;
			}
			ea[i] = num5;
		}
	}

	private static int smethod_5(int level)
	{
		if ((level & 1) == 0)
		{
			return 1;
		}
		return 4;
	}

	private static int smethod_6(int embedding)
	{
		return embedding & -129;
	}

	private static int[] smethod_7(int[] ea, int[] la)
	{
		int i = 0;
		for (int num = la.Length; i < num; i++)
		{
			la[i] = smethod_6(ea[i]);
		}
		return la;
	}

	private static void smethod_8(int[] wca, int defaultLevel, int[] ea, int[] la)
	{
		if (la.Length != wca.Length)
		{
			throw new ArgumentException("levels sequence length must match classes sequence length");
		}
		if (la.Length != ea.Length)
		{
			throw new ArgumentException("levels sequence length must match embeddings sequence length");
		}
		int num = 0;
		int num2 = ea.Length;
		int num3 = defaultLevel;
		while (num < num2)
		{
			int num4 = num;
			int num5 = num4;
			int num6 = smethod_9(wca, ea, num4, num3);
			while (num5 < num2)
			{
				if (la[num5] != num6)
				{
					if (!smethod_11(wca, ea, num5))
					{
						break;
					}
					num5 += smethod_10(ea, num5);
				}
				else
				{
					num5++;
				}
			}
			num3 = smethod_13(wca, defaultLevel, ea, la, num4, num5, num6, num3);
			num = num5;
		}
	}

	private static int smethod_9(int[] wca, int[] ea, int start, int lPrev)
	{
		int i = start;
		int num;
		for (num = wca.Length; i < num && smethod_11(wca, ea, i); i += smethod_10(ea, i))
		{
		}
		if (i < num)
		{
			return smethod_6(ea[i]);
		}
		return lPrev;
	}

	private static int smethod_10(int[] ea, int start)
	{
		int num = 0;
		int i = start;
		int num2 = ea.Length;
		for (int num3 = smethod_6(ea[start]); i < num2 && smethod_6(ea[i]) == num3; i++)
		{
			num++;
		}
		return num;
	}

	private static bool smethod_11(int[] wca, int[] ea, int start)
	{
		int num = smethod_10(ea, start);
		if (num > 0)
		{
			int num2 = smethod_12(wca, start);
			return num2 >= num;
		}
		return false;
	}

	private static int smethod_12(int[] wca, int start)
	{
		int num = 0;
		int i = start;
		for (int num2 = wca.Length; i < num2 && wca[i] == 15; i++)
		{
			num++;
		}
		return num;
	}

	private static int smethod_13(int[] wca, int defaultLevel, int[] ea, int[] la, int start, int end, int level, int levelPrev)
	{
		int sor = smethod_5(smethod_23(levelPrev, level));
		int num = -1;
		if (end == wca.Length)
		{
			num = smethod_23(level, defaultLevel);
		}
		else
		{
			for (int i = end; i < wca.Length; i++)
			{
				if (wca[i] != 15)
				{
					num = smethod_23(level, la[i]);
					break;
				}
			}
			if (num < 0)
			{
				num = smethod_23(level, defaultLevel);
			}
		}
		int eor = smethod_5(num);
		smethod_14(wca, ea, la, start, end, level, sor, eor);
		smethod_15(wca, ea, la, start, end, level, sor, eor);
		smethod_17(wca, ea, la, start, end, level, sor, eor);
		if (!smethod_22(wca, start, end))
		{
			return level;
		}
		return levelPrev;
	}

	private static void smethod_14(int[] wca, int[] ea, int[] la, int start, int end, int level, int sor, int eor)
	{
		int i = start;
		int num = sor;
		for (; i < end; i++)
		{
			int num2 = wca[i];
			switch (num2)
			{
			case 14:
				wca[i] = num;
				break;
			default:
				num = num2;
				break;
			case 15:
				break;
			}
		}
		int j = start;
		int num3 = sor;
		for (; j < end; j++)
		{
			int num4 = wca[j];
			if (num4 == 9)
			{
				if (num3 == 5)
				{
					wca[j] = 12;
				}
			}
			else if (smethod_19(num4))
			{
				num3 = num4;
			}
		}
		for (int k = start; k < end; k++)
		{
			int num5 = wca[k];
			if (num5 == 5)
			{
				wca[k] = 4;
			}
		}
		int l = start;
		int num6 = sor;
		for (; l < end; l++)
		{
			int num7 = wca[l];
			switch (num7)
			{
			case 10:
			{
				int num9 = eor;
				for (int n = l + 1; n < end; n++)
				{
					if ((num7 = wca[n]) != 15)
					{
						num9 = num7;
						break;
					}
				}
				if (num6 == 9 && num9 == 9)
				{
					wca[l] = 9;
				}
				break;
			}
			case 13:
			{
				int num8 = eor;
				for (int m = l + 1; m < end; m++)
				{
					if ((num7 = wca[m]) != 15)
					{
						num8 = num7;
						break;
					}
				}
				if (num6 == 9 && num8 == 9)
				{
					wca[l] = 9;
				}
				else if (num6 == 12 && num8 == 12)
				{
					wca[l] = 12;
				}
				break;
			}
			}
			if (num7 != 15)
			{
				num6 = num7;
			}
		}
		int num10 = start;
		int num11 = sor;
		for (; num10 < end; num10++)
		{
			int num12 = wca[num10];
			switch (num12)
			{
			case 11:
			{
				int num13 = eor;
				for (int num14 = num10 + 1; num14 < end; num14++)
				{
					num12 = wca[num14];
					if (num12 != 15 && num12 != 11)
					{
						num13 = num12;
						break;
					}
				}
				if (num11 == 9 || num13 == 9)
				{
					wca[num10] = 9;
				}
				break;
			}
			default:
				if (num12 != 11)
				{
					num11 = num12;
				}
				break;
			case 15:
				break;
			}
		}
		for (int num15 = start; num15 < end; num15++)
		{
			int num16 = wca[num15];
			if (num16 == 11 || num16 == 10 || num16 == 13)
			{
				wca[num15] = 19;
				smethod_16(wca, start, end, num15, 19);
			}
		}
		int num17 = start;
		int num18 = sor;
		for (; num17 < end; num17++)
		{
			int num19 = wca[num17];
			switch (num19)
			{
			case 9:
				if (num18 == 1)
				{
					wca[num17] = 1;
				}
				break;
			case 1:
			case 4:
				num18 = num19;
				break;
			}
		}
	}

	private static void smethod_15(int[] wca, int[] ea, int[] la, int start, int end, int level, int sor, int eor)
	{
		int i = start;
		int num = sor;
		for (; i < end; i++)
		{
			int num2 = wca[i];
			if (smethod_20(num2))
			{
				int num3 = eor;
				for (int j = i + 1; j < end; j++)
				{
					num2 = wca[j];
					switch (num2)
					{
					default:
						if (smethod_20(num2) || smethod_21(num2))
						{
							continue;
						}
						break;
					case 9:
					case 12:
						num3 = 4;
						break;
					case 1:
					case 4:
						num3 = num2;
						break;
					}
					break;
				}
				if (num == num3)
				{
					wca[i] = num;
					smethod_16(wca, start, end, i, num);
				}
			}
			else
			{
				switch (num2)
				{
				case 9:
				case 12:
					num = 4;
					break;
				case 1:
				case 4:
					num = num2;
					break;
				}
			}
		}
		for (int k = start; k < end; k++)
		{
			int bc = wca[k];
			if (smethod_20(bc))
			{
				smethod_16(wca, start, end, k, wca[k] = smethod_5(smethod_6(ea[k])));
			}
		}
	}

	private static void smethod_16(int[] wca, int start, int end, int index, int bcNew)
	{
		if (index >= start && index < end)
		{
			for (int num = index - 1; num >= start; num--)
			{
				int num2 = wca[num];
				if (num2 != 15)
				{
					break;
				}
				wca[num] = bcNew;
			}
			for (int i = index + 1; i < end; i++)
			{
				int num3 = wca[i];
				if (num3 == 15)
				{
					wca[i] = bcNew;
					continue;
				}
				break;
			}
			return;
		}
		throw new ArgumentException();
	}

	private static void smethod_17(int[] wca, int[] ea, int[] la, int start, int end, int level, int sor, int eor)
	{
		for (int i = start; i < end; i++)
		{
			int num = wca[i];
			int num2 = la[i];
			int num3 = 0;
			if ((num2 & 1) == 0)
			{
				switch (num)
				{
				case 4:
					num3 = 1;
					break;
				case 12:
					num3 = 2;
					break;
				case 9:
					num3 = 2;
					break;
				}
			}
			else
			{
				switch (num)
				{
				case 1:
					num3 = 1;
					break;
				case 9:
					num3 = 1;
					break;
				case 12:
					num3 = 1;
					break;
				}
			}
			la[i] = num2 + num3;
		}
	}

	private static void smethod_18(int[] ica, int dl, int[] la)
	{
		int i = 0;
		for (int num = ica.Length; i < num; i++)
		{
			int num2 = ica[i];
			if (num2 != 17 && num2 != 16)
			{
				continue;
			}
			la[i] = dl;
			for (int num3 = i - 1; num3 >= 0; num3--)
			{
				int num4 = ica[num3];
				if (!smethod_21(num4))
				{
					if (num4 != 18)
					{
						break;
					}
					la[num3] = dl;
				}
			}
		}
		for (int num5 = ica.Length; num5 > 0; num5--)
		{
			int num6 = num5 - 1;
			int num7 = ica[num6];
			if (!smethod_21(num7))
			{
				if (num7 != 18)
				{
					break;
				}
				la[num6] = dl;
			}
		}
		int j = 0;
		for (int num8 = ica.Length; j < num8; j++)
		{
			int bc = ica[j];
			if (smethod_21(bc))
			{
				if (j == 0)
				{
					la[j] = dl;
				}
				else
				{
					la[j] = la[j - 1];
				}
			}
		}
	}

	private static bool smethod_19(int bc)
	{
		switch (bc)
		{
		default:
			return false;
		case 1:
		case 4:
		case 5:
			return true;
		}
	}

	private static bool smethod_20(int bc)
	{
		switch (bc)
		{
		default:
			return false;
		case 16:
		case 17:
		case 18:
		case 19:
			return true;
		}
	}

	private static bool smethod_21(int bc)
	{
		switch (bc)
		{
		default:
			return false;
		case 2:
		case 3:
		case 6:
		case 7:
		case 8:
		case 15:
			return true;
		}
	}

	private static bool smethod_22(int[] ca, int s, int e)
	{
		int num = s;
		while (true)
		{
			if (num < e)
			{
				if (!smethod_21(ca[num]))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	private static int smethod_23(int x, int y)
	{
		if (x > y)
		{
			return x;
		}
		return y;
	}

	private static int[] smethod_24(int[] chars)
	{
		int[] array = new int[chars.Length];
		int i = 0;
		for (int num = chars.Length; i < num; i++)
		{
			int num2 = chars[i];
			int num3 = ((num2 < 0) ? 20 : Class4981.smethod_0(chars[i]));
			array[i] = num3;
		}
		return array;
	}

	private static bool smethod_25(Interface238 cs, int[] chars)
	{
		bool flag = false;
		if (chars.Length != cs.imethod_0())
		{
			throw new ArgumentException("characters array length must match input sequence length");
		}
		int num = 0;
		int num2 = chars.Length;
		while (num < num2)
		{
			int num3 = cs.imethod_1(num);
			int num4;
			if (num3 < 55296)
			{
				num4 = num3;
			}
			else if (num3 < 56320)
			{
				int chHi = num3;
				if (num + 1 >= num2)
				{
					throw new ArgumentException("truncated surrogate pair");
				}
				int num5 = cs.imethod_1(num + 1);
				if (num5 < 56320 || num5 > 57343)
				{
					throw new ArgumentException("isolated high surrogate");
				}
				num4 = smethod_26(chHi, num5);
			}
			else
			{
				if (num3 < 57344)
				{
					throw new ArgumentException("isolated low surrogate");
				}
				num4 = num3;
			}
			if (!flag && smethod_27(num4))
			{
				flag = true;
			}
			if ((num4 & 0xFF0000) == 0)
			{
				chars[num++] = num4;
				continue;
			}
			chars[num++] = num4;
			chars[num++] = -1;
		}
		return flag;
	}

	private static int smethod_26(int chHi, int chLo)
	{
		if (chHi >= 55296 && chHi <= 56319)
		{
			if (chLo < 56320 || chLo > 57343)
			{
				throw new ArgumentException("bad low surrogate");
			}
			return (((chHi & 0x3FF) << 10) | (chLo & 0x3FF)) + 65536;
		}
		throw new ArgumentException("bad high surrogate");
	}

	private static bool smethod_27(int ch)
	{
		switch (Class4981.smethod_0(ch))
		{
		default:
			return false;
		case 4:
		case 5:
		case 6:
		case 7:
		case 12:
			return true;
		}
	}

	private static string smethod_28(int bc)
	{
		return bc switch
		{
			1 => "L", 
			2 => "LRE", 
			3 => "LRO", 
			4 => "R", 
			5 => "AL", 
			6 => "RLE", 
			7 => "RLO", 
			8 => "PDF", 
			9 => "EN", 
			10 => "ES", 
			11 => "ET", 
			12 => "AN", 
			13 => "CS", 
			14 => "NSM", 
			15 => "BN", 
			16 => "B", 
			17 => "S", 
			18 => "WS", 
			19 => "ON", 
			20 => "SUR", 
			_ => "?", 
		};
	}

	private static string smethod_29(int n, int width)
	{
		return smethod_30(n.ToString(), width);
	}

	private static string smethod_30(string s, int width)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = s.Length; i < width; i++)
		{
			stringBuilder.Append(' ');
		}
		stringBuilder.Append(s);
		return stringBuilder.ToString();
	}

	private static string smethod_31(string s, int width)
	{
		StringBuilder stringBuilder = new StringBuilder(s);
		for (int i = stringBuilder.Length; i < width; i++)
		{
			stringBuilder.Append(' ');
		}
		return stringBuilder.ToString();
	}
}
