using System.Collections;
using ns196;

namespace ns198;

internal class Class5610
{
	private class Class5611
	{
		private int int_0;

		private double double_0;

		private ArrayList arrayList_0;

		internal Class5611(int lc, double dem)
		{
			int_0 = lc;
			double_0 = dem;
			arrayList_0 = new ArrayList(lc);
		}

		internal int method_0()
		{
			return int_0;
		}

		internal double method_1()
		{
			return double_0;
		}

		internal void method_2(Class5254 pos)
		{
			arrayList_0.Insert(0, pos);
		}

		internal Class5254 method_3(int i)
		{
			return (Class5254)arrayList_0[i];
		}
	}

	private ArrayList arrayList_0;

	private ArrayList arrayList_1;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	public Class5610()
	{
		arrayList_0 = new ArrayList();
		arrayList_1 = new ArrayList();
		int_1 = -1;
	}

	public void method_0(int ln, double dem)
	{
		arrayList_0.Add(new Class5611(ln, dem));
		if (arrayList_0.Count == 1)
		{
			int_0 = 0;
			int_1 = 0;
			int_2 = 0;
			int_3 = 0;
			return;
		}
		if (dem < ((Class5611)arrayList_0[int_1]).method_1())
		{
			int_1 = arrayList_0.Count - 1;
			int_3 = int_1;
		}
		if (ln < ((Class5611)arrayList_0[int_0]).method_0())
		{
			int_0 = arrayList_0.Count - 1;
		}
		if (ln > ((Class5611)arrayList_0[int_2]).method_0())
		{
			int_2 = arrayList_0.Count - 1;
		}
	}

	public void method_1(bool bSaveOptLineCount)
	{
		if (bSaveOptLineCount)
		{
			int_4 = method_7();
		}
		else
		{
			int_4 = 0;
		}
		arrayList_1 = arrayList_0;
		arrayList_0 = new ArrayList();
	}

	public void method_2()
	{
		int i = 0;
		while (arrayList_1.Count > 0)
		{
			Class5611 @class = (Class5611)arrayList_1[0];
			arrayList_1.Remove(0);
			if (@class.method_0() < method_6())
			{
				arrayList_0.Insert(0, @class);
				int_0 = 0;
				int_1++;
				int_2++;
				int_3++;
			}
			else if (@class.method_0() > method_8())
			{
				arrayList_0.Insert(arrayList_0.Count, @class);
				int_2 = arrayList_0.Count - 1;
				i = int_2;
			}
			else
			{
				for (; i < int_2 && method_10(i) < @class.method_0(); i++)
				{
				}
				if (method_10(i) != @class.method_0())
				{
					break;
				}
				arrayList_0[i] = @class;
			}
			if ((int_4 == 0 && method_12(int_1) > @class.method_1()) || (int_4 != 0 && @class.method_0() == int_4))
			{
				int_1 = i;
				int_3 = int_1;
			}
		}
	}

	public void method_3(Class5254 pos, int i)
	{
		((Class5611)arrayList_0[i]).method_2(pos);
	}

	public bool method_4()
	{
		return method_7() < method_8();
	}

	public bool method_5()
	{
		return method_6() < method_7();
	}

	public int method_6()
	{
		return method_10(int_0);
	}

	public int method_7()
	{
		return method_10(int_1);
	}

	public int method_8()
	{
		return method_10(int_2);
	}

	public int method_9()
	{
		return method_10(int_3);
	}

	public int method_10(int i)
	{
		return ((Class5611)arrayList_0[i]).method_0();
	}

	public double method_11()
	{
		return method_12(int_3);
	}

	public double method_12(int i)
	{
		return ((Class5611)arrayList_0[i]).method_1();
	}

	public int method_13()
	{
		return arrayList_0.Count;
	}

	public Class5254 method_14(int i)
	{
		return ((Class5611)arrayList_0[int_3]).method_3(i);
	}

	public int method_15(int adj)
	{
		if (adj >= method_6() - method_9() && adj <= method_8() - method_9() && method_10(int_3 + adj) == method_9() + adj)
		{
			int_3 += adj;
			return adj;
		}
		return 0;
	}

	public void method_16()
	{
	}
}
