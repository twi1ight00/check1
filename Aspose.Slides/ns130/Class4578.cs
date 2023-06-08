using System.Diagnostics;

namespace ns130;

internal class Class4578
{
	public struct Struct177
	{
		public short short_0;

		public short short_1;

		public short short_2;

		public short short_3;

		public int int_0;
	}

	public const int int_0 = 1;

	public Struct177[] struct177_0;

	public short[] short_0;

	private int int_1;

	public static int smethod_0(int value)
	{
		int num = 32;
		while (num > 1 && (value & (1 << num - 1)) == 0)
		{
			num--;
		}
		return num;
	}

	public Class4578(int range)
	{
		int_1 = range;
		int num = ((range > 256 && range < 512) ? smethod_0(range - 257) : 0);
		short_0 = new short[range];
		int num2 = 2 * range;
		struct177_0 = new Struct177[num2];
		for (int i = 0; i < num2; i++)
		{
			struct177_0[i] = default(Struct177);
		}
		for (int j = 2; j < num2; j++)
		{
			struct177_0[j].short_0 = (short)(j / 2);
			struct177_0[j].int_0 = 1;
		}
		for (int k = 1; k < range; k++)
		{
			struct177_0[k].short_1 = (short)(2 * k);
			struct177_0[k].short_2 = (short)(2 * k + 1);
		}
		for (int l = 0; l < range; l++)
		{
			struct177_0[l].short_3 = -1;
			struct177_0[range + l].short_3 = (short)l;
			struct177_0[range + l].short_1 = -1;
			struct177_0[range + l].short_2 = -1;
			short_0[l] = (short)(range + l);
		}
		method_2(1);
		if (num != 0)
		{
			method_0(short_0[256]);
			method_0(short_0[257]);
			for (int m = 0; m < 12; m++)
			{
				method_0(short_0[range - 3]);
			}
			for (int n = 0; n < 6; n++)
			{
				method_0(short_0[range - 2]);
			}
			return;
		}
		for (int num3 = 0; num3 < 2; num3++)
		{
			for (int num4 = 0; num4 < range; num4++)
			{
				method_0(short_0[num4]);
			}
		}
	}

	public void method_0(int a)
	{
		while (a != 1)
		{
			int num = struct177_0[a].int_0;
			int num2 = a - 1;
			if (struct177_0[num2].int_0 == num)
			{
				do
				{
					num2--;
				}
				while (struct177_0[num2].int_0 == num);
				num2++;
				if (num2 > 1)
				{
					method_3(a, num2);
					a = num2;
				}
			}
			num++;
			struct177_0[a].int_0 = num;
			a = struct177_0[a].short_0;
		}
		struct177_0[a].int_0++;
	}

	[Conditional("DEBUG")]
	private void method_1()
	{
		for (int i = 1; i < int_1; i++)
		{
			if (struct177_0[i].short_3 >= 0)
			{
			}
		}
		for (int j = 1; j < int_1; j++)
		{
			if (struct177_0[j].short_3 >= 0)
			{
			}
		}
		int num = int_1 * 2 - 1;
		for (int k = 1; k < num; k++)
		{
		}
		for (int l = 2; l < num; l++)
		{
			if (struct177_0[l].short_3 < 0)
			{
				int short_ = struct177_0[l].short_1;
				int short_2 = struct177_0[l].short_2;
				if (short_ - short_2 == 1)
				{
				}
			}
		}
		for (int m = 2; m < int_1 * 2; m++)
		{
			int num2 = struct177_0[m].short_0;
			if (struct177_0[num2].short_1 != m)
			{
			}
		}
	}

	private int method_2(int a)
	{
		if (struct177_0[a].short_3 < 0)
		{
			struct177_0[a].int_0 = method_2(struct177_0[a].short_1) + method_2(struct177_0[a].short_2);
		}
		return struct177_0[a].int_0;
	}

	private void method_3(int a, int b)
	{
		short num = struct177_0[a].short_0;
		short num2 = struct177_0[b].short_0;
		Struct177 @struct = struct177_0[a];
		ref Struct177 reference = ref struct177_0[a];
		reference = struct177_0[b];
		struct177_0[b] = @struct;
		struct177_0[a].short_0 = num;
		struct177_0[b].short_0 = num2;
		int short_ = struct177_0[a].short_3;
		if (short_ < 0)
		{
			struct177_0[struct177_0[a].short_1].short_0 = (short)a;
			struct177_0[struct177_0[a].short_2].short_0 = (short)a;
		}
		else
		{
			short_0[short_] = (short)a;
		}
		short_ = struct177_0[b].short_3;
		if (short_ < 0)
		{
			struct177_0[struct177_0[b].short_1].short_0 = (short)b;
			struct177_0[struct177_0[b].short_2].short_0 = (short)b;
		}
		else
		{
			short_0[short_] = (short)b;
		}
	}
}
