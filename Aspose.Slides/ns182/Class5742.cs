using System.Collections;
using System.Text;
using ns181;
using ns195;

namespace ns182;

internal class Class5742
{
	private Class4943 class4943_0;

	private int[] int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	public Class5742(Class4943 inline, int[] levels)
	{
		class4943_0 = inline;
		int_0 = levels;
		method_4(levels);
	}

	public Class5742(Class4943 inline, int level, int count)
	{
		class4943_0 = inline;
		int_0 = smethod_0(level, count);
		method_4(int_0);
	}

	public Class4943 method_0()
	{
		return class4943_0;
	}

	public int method_1()
	{
		return int_1;
	}

	public int method_2()
	{
		return int_2;
	}

	public int[] method_3()
	{
		return int_0;
	}

	public void method_4(int[] levelS)
	{
		int num = int.MaxValue;
		int num2 = int.MinValue;
		if (levelS != null && levelS.Length > 0)
		{
			int i = 0;
			for (int num3 = levelS.Length; i < num3; i++)
			{
				int num4 = levelS[i];
				if (num4 < num)
				{
					num = num4;
				}
				if (num4 > num2)
				{
					num2 = num4;
				}
			}
		}
		else
		{
			num2 = -1;
			num = -1;
		}
		int_1 = num;
		int_2 = num2;
	}

	public bool method_5()
	{
		return int_1 == int_2;
	}

	public ArrayList method_6()
	{
		ArrayList arrayList = new ArrayList();
		int num = 0;
		int num2 = int_0.Length;
		while (num < num2)
		{
			int num3 = int_0[num];
			int num4 = num;
			int i;
			for (i = num4; i < num2 && int_0[i] == num3; i++)
			{
			}
			if (num4 < i)
			{
				arrayList.Add(new Class5742(class4943_0, num3, i - num4));
			}
			num = i;
		}
		return arrayList;
	}

	public void method_7(int[] mm)
	{
		if (int_1 < mm[0])
		{
			mm[0] = int_1;
		}
		if (int_2 > mm[1])
		{
			mm[1] = int_2;
		}
	}

	public bool method_8()
	{
		if (int_1 == int_2)
		{
			return (int_1 & 1) != 0;
		}
		return false;
	}

	public void method_9()
	{
		int_3++;
	}

	public void method_10(bool mirror)
	{
		if (!(class4943_0 is Class4956))
		{
			return;
		}
		Class4956 @class = (Class4956)class4943_0;
		if (!@class.method_60())
		{
			if (((uint)int_3 & (true ? 1u : 0u)) != 0)
			{
				@class.method_58(mirror);
			}
			else if (mirror && method_8())
			{
				@class.method_59();
			}
		}
	}

	public bool method_11(object o)
	{
		if (o is Class5742)
		{
			Class5742 @class = (Class5742)o;
			if (@class.class4943_0 != class4943_0)
			{
				return false;
			}
			if (@class.int_1 != int_1)
			{
				return false;
			}
			if (@class.int_2 != int_2)
			{
				return false;
			}
			if (@class.int_0 != null && int_0 != null)
			{
				if (@class.int_0.Length != int_0.Length)
				{
					return false;
				}
				int num = 0;
				int num2 = int_0.Length;
				while (true)
				{
					if (num < num2)
					{
						if (@class.int_0[num] != int_0[num])
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
			if (@class.int_0 == null && int_0 == null)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = ((class4943_0 != null) ? class4943_0.GetHashCode() : 0);
		num = (num ^ int_1) + (num << 19);
		return (num ^ int_2) + (num << 11);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("RR: { type = '");
		string s = null;
		char value;
		if (class4943_0 is Class4956)
		{
			value = 'W';
			s = ((Class4956)class4943_0).method_51();
		}
		else if (class4943_0 is Class4955)
		{
			value = 'S';
			s = ((Class4955)class4943_0).method_51();
		}
		else if (class4943_0 is Class4952)
		{
			value = 'A';
		}
		else if (class4943_0 is Class4953)
		{
			value = 'L';
		}
		else if (class4943_0 is Class4954)
		{
			value = 'S';
		}
		else if (!(class4943_0 is Class4949))
		{
			value = ((class4943_0 is Class4950) ? 'B' : ((class4943_0 is Class4951) ? 'V' : ((!(class4943_0 is Class4944)) ? '?' : 'I')));
		}
		else
		{
			value = '#';
			s = ((Class4949)class4943_0).vmethod_10();
		}
		stringBuilder.Append(value);
		stringBuilder.Append("', levels = '");
		stringBuilder.Append(method_12(int_0));
		stringBuilder.Append("', min = ");
		stringBuilder.Append(int_1);
		stringBuilder.Append(", max = ");
		stringBuilder.Append(int_2);
		stringBuilder.Append(", reversals = ");
		stringBuilder.Append(int_3);
		stringBuilder.Append(", content = <");
		stringBuilder.Append(Class5710.smethod_9(s));
		stringBuilder.Append("> }");
		return stringBuilder.ToString();
	}

	private string method_12(int[] levels)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = -1;
		int num2 = levels.Length;
		for (int i = 0; i < num2; i++)
		{
			int num3 = levels[i];
			if (num3 > num)
			{
				num = num3;
			}
		}
		if (num >= 0)
		{
			if (num < 10)
			{
				for (int j = 0; j < num2; j++)
				{
					stringBuilder.Append((char)(48 + levels[j]));
				}
			}
			else
			{
				bool flag = true;
				for (int k = 0; k < num2; k++)
				{
					if (flag)
					{
						flag = false;
					}
					else
					{
						stringBuilder.Append(',');
					}
					stringBuilder.Append(levels[k]);
				}
			}
		}
		return stringBuilder.ToString();
	}

	private static int[] smethod_0(int level, int count)
	{
		int[] array = new int[count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = level;
		}
		return array;
	}
}
