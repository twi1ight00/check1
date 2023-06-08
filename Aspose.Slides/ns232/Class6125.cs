namespace ns232;

internal class Class6125
{
	private class Class6126
	{
		internal short short_0;

		internal short short_1;

		internal short short_2;

		internal short short_3;

		internal int int_0;
	}

	private static int int_0 = 1;

	private readonly Class6126[] class6126_0;

	private readonly short[] short_0;

	private readonly int int_1;

	private readonly int int_2;

	private readonly Class6119 class6119_0;

	public Class6125(Class6119 bits, int range)
	{
		class6119_0 = bits;
		int_2 = range;
		smethod_0(range - 1);
		if (range > 256 && range < 512)
		{
			int_1 = smethod_0(range - 257);
		}
		else
		{
			int_1 = 0;
		}
		short_0 = new short[range];
		int num = 2 * range;
		class6126_0 = new Class6126[num];
		for (int i = 0; i < num; i++)
		{
			class6126_0[i] = new Class6126();
		}
		for (int j = 2; j < num; j++)
		{
			class6126_0[j].short_0 = (short)(j / 2);
			class6126_0[j].int_0 = 1;
		}
		for (int k = 1; k < range; k++)
		{
			class6126_0[k].short_1 = (short)(2 * k);
			class6126_0[k].short_2 = (short)(2 * k + 1);
		}
		for (int l = 0; l < range; l++)
		{
			class6126_0[l].short_3 = -1;
			class6126_0[range + l].short_3 = (short)l;
			class6126_0[range + l].short_1 = -1;
			class6126_0[range + l].short_2 = -1;
			short_0[l] = (short)(range + l);
		}
		method_1(int_0);
		if (int_1 != 0)
		{
			method_2(short_0[256]);
			method_2(short_0[257]);
			for (int m = 0; m < 12; m++)
			{
				method_2(short_0[range - 3]);
			}
			for (int n = 0; n < 6; n++)
			{
				method_2(short_0[range - 2]);
			}
			return;
		}
		for (int num2 = 0; num2 < 2; num2++)
		{
			for (int num3 = 0; num3 < range; num3++)
			{
				method_2(short_0[num3]);
			}
		}
	}

	private string method_0()
	{
		int num = int_0;
		while (true)
		{
			if (num < int_2)
			{
				if (class6126_0[num].short_3 < 0)
				{
					if (class6126_0[class6126_0[num].short_1].short_0 != num)
					{
						return "tree[tree[" + num + "].left].up == " + class6126_0[class6126_0[num].short_1].short_0 + ", expected " + num;
					}
					if (class6126_0[class6126_0[num].short_2].short_0 != num)
					{
						break;
					}
				}
				num++;
				continue;
			}
			int num2 = int_0;
			while (true)
			{
				if (num2 < int_2)
				{
					if (class6126_0[num2].short_3 < 0 && class6126_0[num2].int_0 != class6126_0[class6126_0[num2].short_1].int_0 + class6126_0[class6126_0[num2].short_2].int_0)
					{
						break;
					}
					num2++;
					continue;
				}
				int num3 = int_2 * 2 - 1;
				int num4 = int_0;
				while (true)
				{
					if (num4 < num3)
					{
						if (class6126_0[num4].int_0 < class6126_0[num4 + 1].int_0)
						{
							break;
						}
						num4++;
						continue;
					}
					int num5 = int_0 + 1;
					while (true)
					{
						if (num5 < num3)
						{
							if (class6126_0[num5].short_3 < 0)
							{
								int short_ = class6126_0[num5].short_1;
								int short_2 = class6126_0[num5].short_2;
								if (short_ - short_2 != 1 && short_ - short_2 != -1)
								{
									break;
								}
							}
							num5++;
							continue;
						}
						int num6 = int_0 + 1;
						int num7;
						while (true)
						{
							if (num6 < int_2 * 2)
							{
								num7 = class6126_0[num6].short_0;
								if (class6126_0[num7].short_1 != num6 && class6126_0[num7].short_2 != num6)
								{
									break;
								}
								num6++;
								continue;
							}
							return null;
						}
						return "tree[" + num7 + "].left != " + num6 + " && tree[" + num7 + "].right != " + num6;
					}
					return "tree[" + num5 + "].left == " + class6126_0[num5].short_1 + ", tree[" + num5 + "].right] == " + class6126_0[num5].short_2 + ", siblings not adjacent";
				}
				return "tree[" + num4 + "].weight == " + class6126_0[num4].int_0 + ", tree[" + (num4 + 1) + ".weight == " + class6126_0[num4 + 1].int_0 + ", not >=";
			}
			return "tree[" + num2 + "].weight == " + class6126_0[num2].int_0 + ", expected " + class6126_0[class6126_0[num2].short_1].int_0 + " + " + class6126_0[class6126_0[num2].short_2].int_0;
		}
		return "tree[tree[" + num + "].right].up == " + class6126_0[class6126_0[num].short_2].short_0 + ", expected " + num;
	}

	private int method_1(int a)
	{
		if (class6126_0[a].short_3 < 0)
		{
			class6126_0[a].int_0 = method_1(class6126_0[a].short_1) + method_1(class6126_0[a].short_2);
		}
		return class6126_0[a].int_0;
	}

	private void method_2(int a)
	{
		while (a != int_0)
		{
			int num = class6126_0[a].int_0;
			int num2 = a - 1;
			if (class6126_0[num2].int_0 == num)
			{
				do
				{
					num2--;
				}
				while (class6126_0[num2].int_0 == num);
				num2++;
				if (num2 > int_0)
				{
					method_3(a, num2);
					a = num2;
				}
			}
			num++;
			class6126_0[a].int_0 = num;
			a = class6126_0[a].short_0;
		}
		class6126_0[a].int_0++;
	}

	private void method_3(int a, int b)
	{
		short num = class6126_0[a].short_0;
		short num2 = class6126_0[b].short_0;
		Class6126 @class = class6126_0[a];
		class6126_0[a] = class6126_0[b];
		class6126_0[b] = @class;
		class6126_0[a].short_0 = num;
		class6126_0[b].short_0 = num2;
		int short_ = class6126_0[a].short_3;
		if (short_ < 0)
		{
			class6126_0[class6126_0[a].short_1].short_0 = (short)a;
			class6126_0[class6126_0[a].short_2].short_0 = (short)a;
		}
		else
		{
			short_0[short_] = (short)a;
		}
		short_ = class6126_0[b].short_3;
		if (short_ < 0)
		{
			class6126_0[class6126_0[b].short_1].short_0 = (short)b;
			class6126_0[class6126_0[b].short_2].short_0 = (short)b;
		}
		else
		{
			short_0[short_] = (short)b;
		}
	}

	public int method_4(int symbol)
	{
		int num = short_0[symbol];
		int num2 = 0;
		do
		{
			num2++;
			num = class6126_0[num].short_0;
		}
		while (num != int_0);
		return num2 << 16;
	}

	public void method_5(int symbol)
	{
		int num = short_0[symbol];
		int a = num;
		bool[] array = new bool[50];
		int num2 = 0;
		do
		{
			int num3 = class6126_0[num].short_0;
			array[num2++] = class6126_0[num3].short_2 == num;
			num = num3;
		}
		while (num != int_0);
		do
		{
			class6119_0.method_1(array[--num2]);
		}
		while (num2 > 0);
		method_2(a);
	}

	public static int smethod_0(int x)
	{
		int num = 32;
		while (num > 1 && (x & (1 << num - 1)) == 0)
		{
			num--;
		}
		return num;
	}
}
