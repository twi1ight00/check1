using System;
using System.Collections;
using System.Text;
using ns183;

namespace ns211;

internal class Class5591
{
	internal class Class5592
	{
		internal interface Interface217
		{
			object imethod_0(string key, object v1, object v2);
		}

		private int int_0;

		private int int_1;

		private int[] int_2;

		private Hashtable hashtable_0;

		private static volatile Hashtable hashtable_1;

		private static int[] int_3 = new int[16]
		{
			1391376, 463792, 198768, 86961, 33936, 13776, 4592, 1968, 861, 336,
			112, 48, 21, 7, 3, 1
		};

		private static int[] int_4 = new int[3] { 7, 3, 1 };

		public Class5592(int offset, int count, int[] subIntervals)
		{
			int_0 = offset;
			int_1 = count;
			int_2 = ((subIntervals == null || subIntervals.Length <= 2) ? null : subIntervals);
		}

		public Class5592(int offset, int count)
			: this(offset, count, null)
		{
		}

		public Class5592(int[] subIntervals)
			: this(smethod_6(subIntervals), smethod_7(subIntervals), subIntervals)
		{
		}

		public int method_0()
		{
			return int_0;
		}

		public int method_1()
		{
			return int_1;
		}

		public int method_2()
		{
			return method_0();
		}

		public int method_3()
		{
			return method_0() + method_1();
		}

		public bool method_4()
		{
			return int_2 != null;
		}

		public int[] method_5()
		{
			return int_2;
		}

		public int method_6()
		{
			if (int_2 == null)
			{
				return 0;
			}
			return int_2.Length / 2;
		}

		public bool method_7(int offset, int count)
		{
			int num = offset + count;
			if (!method_4())
			{
				int num2 = method_2();
				int num3 = method_3();
				if (num2 >= offset)
				{
					return num3 <= num;
				}
				return false;
			}
			int num4 = method_6();
			int num5 = 0;
			while (true)
			{
				if (num5 < num4)
				{
					int num6 = int_2[2 * num5];
					int num7 = int_2[2 * num5 + 1];
					if (num6 >= offset && num7 <= num)
					{
						break;
					}
					num5++;
					continue;
				}
				return false;
			}
			return true;
		}

		public void method_8(string key, object value)
		{
			if (hashtable_0 == null)
			{
				hashtable_0 = new Hashtable();
			}
			if (hashtable_0 != null)
			{
				hashtable_0.Add(key, value);
			}
		}

		public object method_9(string key)
		{
			if (hashtable_0 != null)
			{
				return hashtable_0[key];
			}
			return null;
		}

		public void method_10(string key, object value)
		{
			if (hashtable_0 == null)
			{
				hashtable_0 = new Hashtable();
			}
			if (hashtable_0 != null)
			{
				if (hashtable_0.ContainsKey(key))
				{
					object v = hashtable_0[key];
					hashtable_0.Add(key, smethod_0(key, v, value));
				}
				else
				{
					hashtable_0.Add(key, value);
				}
			}
		}

		public static object smethod_0(string key, object v1, object v2)
		{
			Interface217 @interface = smethod_2(key);
			if (@interface != null)
			{
				return @interface.imethod_0(key, v1, v2);
			}
			if (v2 != null)
			{
				return v2;
			}
			return v1;
		}

		public void method_11(Class5592 ca)
		{
			if (ca.hashtable_0 == null)
			{
				return;
			}
			foreach (DictionaryEntry item in ca.hashtable_0)
			{
				method_10((string)item.Key, item.Value);
			}
		}

		public object method_12()
		{
			try
			{
				Class5592 @class = new Class5592(int_0, int_1, int_2);
				if (hashtable_0 != null)
				{
					@class.hashtable_0 = new Hashtable(hashtable_0);
				}
				return @class;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static void smethod_1(string key, Interface217 pm)
		{
			if (hashtable_1 == null)
			{
				hashtable_1 = new Hashtable();
			}
			if (hashtable_1 != null)
			{
				hashtable_1.Add(key, pm);
			}
		}

		public static Interface217 smethod_2(string key)
		{
			if (hashtable_1 != null)
			{
				return (Interface217)hashtable_1[key];
			}
			return null;
		}

		public static Class5592[] smethod_3(Class5592 a, int repeat)
		{
			Class5592[] array = new Class5592[repeat];
			int i = 0;
			for (int num = array.Length; i < num; i++)
			{
				array[i] = (Class5592)a.method_12();
			}
			return array;
		}

		public static Class5592 smethod_4(Class5592[] aa)
		{
			int[] array = smethod_8(aa);
			Class5592 ca;
			if (array != null && array.Length != 0)
			{
				if (array.Length == 2)
				{
					int num = array[0];
					int num2 = array[1];
					ca = new Class5592(num, num2 - num);
				}
				else
				{
					ca = new Class5592(smethod_10(array));
				}
			}
			else
			{
				ca = new Class5592(0, 0);
			}
			return smethod_5(ca, aa);
		}

		private static Class5592 smethod_5(Class5592 ca, Class5592[] aa)
		{
			foreach (Class5592 ca2 in aa)
			{
				ca.method_11(ca2);
			}
			return ca;
		}

		private static int smethod_6(int[] ia)
		{
			int num = int.MaxValue;
			int num2 = int.MinValue;
			if (ia != null)
			{
				int i = 0;
				for (int num3 = ia.Length; i < num3; i += 2)
				{
					int num4 = ia[i];
					int num5 = ia[i + 1];
					if (num4 < num)
					{
						num = num4;
					}
					if (num5 > num2)
					{
						num2 = num5;
					}
				}
				if (num2 < 0)
				{
					num2 = 0;
				}
				if (num > num2)
				{
					num = num2;
				}
			}
			return num;
		}

		private static int smethod_7(int[] ia)
		{
			int num = int.MaxValue;
			int num2 = int.MinValue;
			if (ia != null)
			{
				int i = 0;
				for (int num3 = ia.Length; i < num3; i += 2)
				{
					int num4 = ia[i];
					int num5 = ia[i + 1];
					if (num4 < num)
					{
						num = num4;
					}
					if (num5 > num2)
					{
						num2 = num5;
					}
				}
				if (num2 < 0)
				{
					num2 = 0;
				}
				if (num > num2)
				{
					num = num2;
				}
			}
			return num2 - num;
		}

		private static int[] smethod_8(Class5592[] aa)
		{
			int num = 0;
			int i = 0;
			for (int num2 = aa.Length; i < num2; i++)
			{
				Class5592 @class = aa[i];
				num = ((!@class.method_4()) ? (num + 1) : (num + @class.method_6()));
			}
			int[] array = new int[num];
			int[] array2 = new int[num];
			int j = 0;
			int num3 = 0;
			for (; j < aa.Length; j++)
			{
				Class5592 class2 = aa[j];
				if (class2.method_4())
				{
					int[] array3 = class2.method_5();
					for (int k = 0; k < array3.Length; k += 2)
					{
						array[num3] = array3[k];
						array2[num3] = array3[k + 1];
						num3++;
					}
				}
				else
				{
					array[num3] = class2.method_2();
					array2[num3] = class2.method_3();
					num3++;
				}
			}
			return smethod_9(array, array2);
		}

		private static int[] smethod_9(int[] sa, int[] ea)
		{
			int num = sa.Length;
			int[] array = ((num < 21) ? int_4 : int_3);
			foreach (int num2 in array)
			{
				int j = num2;
				for (int num3 = num; j < num3; j++)
				{
					int num4 = sa[j];
					int num5 = ea[j];
					int num6;
					for (num6 = j; num6 >= num2; num6 -= num2)
					{
						int num7 = sa[num6 - num2];
						int num8 = ea[num6 - num2];
						if (num7 > num4)
						{
							sa[num6] = num7;
							ea[num6] = num8;
						}
						else
						{
							if (num7 != num4 || num8 <= num5)
							{
								break;
							}
							sa[num6] = num7;
							ea[num6] = num8;
						}
					}
					sa[num6] = num4;
					ea[num6] = num5;
				}
			}
			int[] array2 = new int[num * 2];
			for (int k = 0; k < num; k++)
			{
				array2[k * 2] = sa[k];
				array2[k * 2 + 1] = ea[k];
			}
			return array2;
		}

		private static int[] smethod_10(int[] ia)
		{
			int num = ia.Length;
			int i = 0;
			int num2 = num;
			int num3 = 0;
			int num4 = -1;
			int num5 = -1;
			for (; i < num2; i += 2)
			{
				int num6 = ia[i];
				int num7 = ia[i + 1];
				if (num4 >= 0 && num6 <= num4)
				{
					if (num6 >= num5 && num7 > num4)
					{
						num4 = num7;
					}
				}
				else
				{
					num5 = num6;
					num4 = num7;
					num3++;
				}
			}
			int[] array = new int[num3 * 2];
			i = 0;
			num2 = num;
			num3 = 0;
			num4 = -1;
			num5 = -1;
			for (; i < num2; i += 2)
			{
				int num8 = ia[i];
				int num9 = ia[i + 1];
				int num10 = num3 * 2;
				if (num4 >= 0 && num8 <= num4)
				{
					if (num8 >= num5)
					{
						if (num9 > num4)
						{
							num4 = num9;
						}
						array[num10 - 1] = num4;
					}
				}
				else
				{
					num5 = num8;
					num4 = num9;
					array[num10] = num5;
					array[num10 + 1] = num4;
					num3++;
				}
			}
			return array;
		}
	}

	private static int int_0 = 8;

	private Class5602 class5602_0;

	private Class5602 class5602_1;

	private ArrayList arrayList_0;

	private bool bool_0;

	public Class5591(Class5602 characters, Class5602 glyphs, ArrayList associations, bool predications)
	{
		if (characters == null)
		{
			characters = Class5602.smethod_0(int_0);
		}
		if (glyphs == null)
		{
			glyphs = Class5602.smethod_0(characters.method_1());
		}
		if (associations == null)
		{
			associations = smethod_6(characters.method_16(), glyphs.method_16());
		}
		class5602_0 = characters;
		class5602_1 = glyphs;
		arrayList_0 = associations;
		bool_0 = predications;
	}

	public Class5591(Class5602 characters, Class5602 glyphs, ArrayList associations)
		: this(characters, glyphs, associations, predications: false)
	{
	}

	public Class5591(Class5591 gs)
		: this(gs.class5602_0, smethod_7(gs.class5602_1), smethod_8(gs.arrayList_0), gs.bool_0)
	{
	}

	public Class5591(Class5591 gs, int[] bga, int[] iga, int[] lga, Class5592[] bal, Class5592[] ial, Class5592[] lal)
		: this(gs.class5602_0, smethod_1(bga, iga, lga), smethod_2(bal, ial, lal), gs.bool_0)
	{
	}

	public Class5602 method_0()
	{
		return class5602_0;
	}

	public int[] method_1(bool copy)
	{
		if (copy)
		{
			return smethod_5(class5602_0);
		}
		return class5602_0.method_20();
	}

	public int method_2()
	{
		return class5602_0.method_16();
	}

	public int method_3(int index)
	{
		return class5602_1.method_9(index);
	}

	public void method_4(int index, int gi)
	{
		if (gi > 65535)
		{
			gi = 65535;
		}
		class5602_1.method_5(index, gi);
	}

	public Class5602 method_5()
	{
		return class5602_1;
	}

	public int[] method_6(int offset, int count)
	{
		int num = method_8();
		if (offset < 0)
		{
			offset = 0;
		}
		else if (offset > num)
		{
			offset = num;
		}
		if (count < 0)
		{
			count = num - offset;
		}
		int[] array = new int[count];
		int i = offset;
		int num2 = offset + count;
		int num3 = 0;
		for (; i < num2; i++)
		{
			if (num3 < array.Length)
			{
				array[num3++] = class5602_1.method_9(i);
			}
		}
		return array;
	}

	public int[] method_7(bool copy)
	{
		if (copy)
		{
			return smethod_5(class5602_1);
		}
		return class5602_1.method_20();
	}

	public int method_8()
	{
		return class5602_1.method_16();
	}

	public Class5592 method_9(int index)
	{
		return (Class5592)arrayList_0[index];
	}

	public ArrayList method_10()
	{
		return arrayList_0;
	}

	public Class5592[] method_11(int offset, int count)
	{
		int num = method_8();
		if (offset < 0)
		{
			offset = 0;
		}
		else if (offset > num)
		{
			offset = num;
		}
		if (count < 0)
		{
			count = num - offset;
		}
		Class5592[] array = new Class5592[count];
		int i = offset;
		int num2 = offset + count;
		int num3 = 0;
		for (; i < num2; i++)
		{
			if (num3 < array.Length)
			{
				array[num3++] = (Class5592)arrayList_0[i];
			}
		}
		return array;
	}

	public void method_12(bool enable)
	{
		bool_0 = enable;
	}

	public bool method_13()
	{
		return bool_0;
	}

	public void method_14(int offset, string key, object value)
	{
		if (bool_0)
		{
			Class5592[] array = method_11(offset, 1);
			Class5592 @class = array[0];
			@class.method_8(key, value);
		}
	}

	public object method_15(int offset, string key)
	{
		if (bool_0)
		{
			Class5592[] array = method_11(offset, 1);
			Class5592 @class = array[0];
			return @class.method_9(key);
		}
		return null;
	}

	public int method_16(Class5602 gb)
	{
		int num = method_8();
		int num2 = 0;
		int num3 = gb.method_16();
		while (true)
		{
			if (num2 < num3)
			{
				if (num2 >= num)
				{
					break;
				}
				int num4 = class5602_1.method_9(num2);
				int num5 = gb.method_9(num2);
				if (num4 <= num5)
				{
					if (num4 >= num5)
					{
						num2++;
						continue;
					}
					return -1;
				}
				return 1;
			}
			return 0;
		}
		return -1;
	}

	public object method_17()
	{
		try
		{
			Class5591 @class = new Class5591(class5602_0, class5602_1, arrayList_0, bool_0);
			@class.class5602_0 = smethod_7(class5602_0);
			@class.class5602_1 = smethod_7(class5602_1);
			@class.arrayList_0 = smethod_8(arrayList_0);
			return @class;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('{');
		stringBuilder.Append("chars = [");
		stringBuilder.Append(class5602_0);
		stringBuilder.Append("], glyphs = [");
		stringBuilder.Append(class5602_1);
		stringBuilder.Append("], associations = [");
		stringBuilder.Append(arrayList_0);
		stringBuilder.Append("]");
		stringBuilder.Append('}');
		return stringBuilder.ToString();
	}

	public static bool smethod_0(int[] ga1, int[] ga2)
	{
		if (ga1 == ga2)
		{
			return true;
		}
		if (ga1 != null && ga2 != null)
		{
			if (ga1.Length != ga2.Length)
			{
				return false;
			}
			int num = 0;
			int num2 = ga1.Length;
			while (true)
			{
				if (num < num2)
				{
					if (ga1[num] != ga2[num])
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
		return false;
	}

	public static Class5602 smethod_1(int[] bga, int[] iga, int[] lga)
	{
		int num = 0;
		if (bga != null)
		{
			num += bga.Length;
		}
		if (iga != null)
		{
			num += iga.Length;
		}
		if (lga != null)
		{
			num += lga.Length;
		}
		Class5602 @class = Class5602.smethod_0(num);
		if (bga != null)
		{
			@class.method_4(bga);
		}
		if (iga != null)
		{
			@class.method_4(iga);
		}
		if (lga != null)
		{
			@class.method_4(lga);
		}
		@class.method_19();
		return @class;
	}

	public static ArrayList smethod_2(Class5592[] baa, Class5592[] iaa, Class5592[] laa)
	{
		int num = 0;
		if (baa != null)
		{
			num += baa.Length;
		}
		if (iaa != null)
		{
			num += iaa.Length;
		}
		if (laa != null)
		{
			num += laa.Length;
		}
		if (num > 0)
		{
			ArrayList arrayList = new ArrayList(num);
			if (baa != null)
			{
				for (int i = 0; i < baa.Length; i++)
				{
					arrayList.Add(baa[i]);
				}
			}
			if (iaa != null)
			{
				for (int j = 0; j < iaa.Length; j++)
				{
					arrayList.Add(iaa[j]);
				}
			}
			if (laa != null)
			{
				for (int k = 0; k < laa.Length; k++)
				{
					arrayList.Add(laa[k]);
				}
			}
			return arrayList;
		}
		return null;
	}

	public static Class5591 smethod_3(Class5591 gs, Class5591[] sa)
	{
		int num = 0;
		int num2 = 0;
		int i = 0;
		for (int num3 = sa.Length; i < num3; i++)
		{
			Class5591 @class = sa[i];
			Class5602 class2 = @class.method_5();
			int num4 = class2.method_16();
			ArrayList arrayList = @class.method_10();
			int count = arrayList.Count;
			num += num4;
			num2 += count;
		}
		Class5602 class3 = Class5602.smethod_0(num);
		ArrayList arrayList2 = new ArrayList(num2);
		int j = 0;
		for (int num5 = sa.Length; j < num5; j++)
		{
			Class5591 class4 = sa[j];
			class3.method_7(class4.method_5());
			arrayList2.AddRange(class4.method_10());
		}
		return new Class5591(gs.method_0(), class3, arrayList2, gs.method_13());
	}

	public static Class5591 smethod_4(Class5591 gs, int source, int count, int target)
	{
		if (source != target)
		{
			int num = gs.method_8();
			int[] array = gs.method_7(copy: false);
			int[] array2 = new int[num];
			Class5592[] array3 = gs.method_11(0, num);
			Class5592[] array4 = new Class5592[num];
			if (source < target)
			{
				int num2 = 0;
				int num3 = 0;
				while (num3 < source)
				{
					array2[num2] = array[num3];
					array4[num2] = array3[num3];
					num3++;
					num2++;
				}
				int num4 = source + count;
				while (num4 < target)
				{
					array2[num2] = array[num4];
					array4[num2] = array3[num4];
					num4++;
					num2++;
				}
				int num5 = source;
				int num6 = source + count;
				while (num5 < num6)
				{
					array2[num2] = array[num5];
					array4[num2] = array3[num5];
					num5++;
					num2++;
				}
				int num7 = target;
				int num8 = num;
				while (num7 < num8)
				{
					array2[num2] = array[num7];
					array4[num2] = array3[num7];
					num7++;
					num2++;
				}
			}
			else
			{
				int num9 = 0;
				int num10 = 0;
				while (num10 < target)
				{
					array2[num9] = array[num10];
					array4[num9] = array3[num10];
					num10++;
					num9++;
				}
				int num11 = source;
				int num12 = source + count;
				while (num11 < num12)
				{
					array2[num9] = array[num11];
					array4[num9] = array3[num11];
					num11++;
					num9++;
				}
				int num13 = target;
				while (num13 < source)
				{
					array2[num9] = array[num13];
					array4[num9] = array3[num13];
					num13++;
					num9++;
				}
				int num14 = source + count;
				int num15 = num;
				while (num14 < num15)
				{
					array2[num9] = array[num14];
					array4[num9] = array3[num14];
					num14++;
					num9++;
				}
			}
			return new Class5591(gs, null, array2, null, null, array4, null);
		}
		return gs;
	}

	private static int[] smethod_5(Class5602 ib)
	{
		if (ib != null)
		{
			int num = ib.method_16();
			int[] array = new int[num];
			ib.method_10(array, 0, num);
			return array;
		}
		return new int[0];
	}

	private static ArrayList smethod_6(int numChars, int numGlyphs)
	{
		ArrayList arrayList = new ArrayList(numGlyphs);
		for (int i = 0; i < numGlyphs; i++)
		{
			int num = ((i > numChars) ? numChars : i);
			arrayList.Add(new Class5592(i, (num != numChars) ? 1 : 0));
		}
		return arrayList;
	}

	private static Class5602 smethod_7(Class5602 ib)
	{
		if (ib != null)
		{
			int[] array = new int[ib.method_1()];
			int num = ib.method_0();
			int num2 = ib.method_16();
			Array.Copy(ib.method_20(), 0, array, 0, array.Length);
			return Class5602.smethod_1(array, num, num2 - num);
		}
		return null;
	}

	private static ArrayList smethod_8(ArrayList ca)
	{
		if (ca != null)
		{
			return new ArrayList(ca);
		}
		return ca;
	}
}
