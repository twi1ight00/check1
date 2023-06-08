using System.Collections;
using ns226;
using ns227;

namespace ns232;

internal class Class6130
{
	private static int int_0 = 65536;

	private static int int_1 = 12;

	private static int int_2 = 16;

	private static int int_3 = 4;

	private Hashtable hashtable_0;

	private Class6131 class6131_0;

	public Class6130()
	{
		hashtable_0 = new Hashtable();
		class6131_0 = new Class6131();
	}

	public Class6131 method_0()
	{
		return class6131_0;
	}

	public void AddTable(int tag, Class6016 data)
	{
		hashtable_0.Add(tag, data);
	}

	public void method_1(int tag, byte[] data)
	{
		AddTable(tag, Class6016.smethod_0(data));
	}

	private static void smethod_0(byte[] buf, int offset, int val)
	{
		buf[offset] = (byte)(val >> 8);
		buf[offset + 1] = (byte)val;
	}

	private static void smethod_1(byte[] buf, int offset, int val)
	{
		buf[offset] = (byte)(val >> 24);
		buf[offset + 1] = (byte)(val >> 16);
		buf[offset + 2] = (byte)(val >> 8);
		buf[offset + 3] = (byte)val;
	}

	public byte[] method_2()
	{
		AddTable(Class6116.int_2, class6131_0.method_2());
		ArrayList arrayList = new ArrayList();
		foreach (int key in hashtable_0.Keys)
		{
			arrayList.Add(key);
		}
		arrayList.Sort();
		int count = hashtable_0.Count;
		int num2 = int_1 + int_2 * count;
		foreach (DictionaryEntry item in hashtable_0)
		{
			Class6016 @class = (Class6016)item.Value;
			if (@class != null)
			{
				num2 += (((Class6016)item.Value).method_2() + int_3 - 1) & -int_3;
			}
		}
		byte[] array = new byte[num2];
		smethod_1(array, 0, int_0);
		smethod_0(array, 4, count);
		int num3 = smethod_4(count);
		smethod_0(array, 6, num3 * int_2);
		smethod_0(array, 8, smethod_5(num3));
		smethod_0(array, 10, (count - num3) * int_2);
		int num4 = int_1;
		int num5 = int_1 + int_2 * count;
		foreach (int item2 in arrayList)
		{
			Class6016 class2 = (Class6016)hashtable_0[item2];
			smethod_1(array, num4, item2);
			smethod_1(array, num4 + 4, 0);
			if (class2 == null)
			{
				smethod_1(array, num4 + 8, 0);
				smethod_1(array, num4 + 12, 0);
			}
			else
			{
				smethod_1(array, num4 + 8, num5);
				int num7 = class2.method_2();
				smethod_1(array, num4 + 12, num7);
				class2.method_14(0, array, num5, num7);
				num5 += (num7 + int_3 - 1) & -int_3;
			}
			num4 += int_2;
		}
		return array;
	}

	public static int smethod_2(int i)
	{
		i |= i >> 1;
		i |= i >> 2;
		i |= i >> 4;
		i |= i >> 8;
		i |= i >> 16;
		return i - (int)((uint)i >> 1);
	}

	public static int smethod_3(int i)
	{
		if (i == 0)
		{
			return 32;
		}
		int num = 1;
		if ((uint)i >> 16 == 0)
		{
			num += 16;
			i <<= 16;
		}
		if ((uint)i >> 24 == 0)
		{
			num += 8;
			i <<= 8;
		}
		if ((uint)i >> 28 == 0)
		{
			num += 4;
			i <<= 4;
		}
		if ((uint)i >> 30 == 0)
		{
			num += 2;
			i <<= 2;
		}
		return num - (int)((uint)i >> 31);
	}

	private static int smethod_4(int x)
	{
		return smethod_2(x);
	}

	private static int smethod_5(int x)
	{
		return 31 - smethod_3(x);
	}
}
