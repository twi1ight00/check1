using System;
using System.Collections;
using ns182;
using ns211;

namespace ns181;

internal class Class4956 : Class4943
{
	internal class Class5762
	{
		public static string smethod_0(string s)
		{
			char[] array = s.ToCharArray();
			Array.Reverse(array);
			return new string(array);
		}
	}

	protected string string_0;

	protected int[] int_17;

	protected int[] int_18;

	protected int[][] int_19;

	protected bool bool_0;

	public Class4956(int blockProgressionOffset, int level, string word, int[] letterAdjust, int[] levels, int[][] gposAdjustments, bool reversed)
		: base(blockProgressionOffset, level)
	{
		int num = word?.Length ?? 0;
		string_0 = word;
		int_17 = smethod_0(letterAdjust, num);
		int_18 = smethod_2(levels, level, num);
		int_19 = smethod_1(gposAdjustments, num);
		bool_0 = reversed;
	}

	public Class4956(int blockProgressionOffset, int level, string word, int[] letterAdjust, int[] levels, int[][] gposAdjustments)
		: this(blockProgressionOffset, level, word, letterAdjust, levels, gposAdjustments, reversed: false)
	{
	}

	public string method_51()
	{
		return string_0;
	}

	public int[] method_52()
	{
		return int_17;
	}

	public int[] method_53()
	{
		return int_18;
	}

	public int[] method_54(int start, int end)
	{
		if (int_18 != null)
		{
			int num = end - start;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = int_18[start + i];
			}
			return array;
		}
		return null;
	}

	public int method_55(int position)
	{
		if (position > string_0.Length)
		{
			throw new IndexOutOfRangeException();
		}
		if (int_18 != null)
		{
			return int_18[position];
		}
		return -1;
	}

	public override ArrayList vmethod_8(ArrayList runs)
	{
		Class5742 value = ((method_53() == null) ? new Class5742(this, -1, string_0.Length) : new Class5742(this, method_53()));
		runs.Add(value);
		return runs;
	}

	public int[][] method_56()
	{
		return int_19;
	}

	public int[] method_57(int position)
	{
		if (position > string_0.Length)
		{
			throw new IndexOutOfRangeException();
		}
		if (int_19 != null)
		{
			return int_19[position];
		}
		return null;
	}

	public void method_58(bool mirror)
	{
		if (string_0.Length > 0)
		{
			string_0 = Class5762.smethod_0(string_0);
			if (int_18 != null)
			{
				smethod_3(int_18);
			}
			if (int_19 != null)
			{
				smethod_4(int_19);
			}
			bool_0 = !bool_0;
			if (mirror)
			{
				string_0 = Class5708.smethod_0(string_0);
			}
		}
	}

	public void method_59()
	{
		if (string_0.Length > 0)
		{
			string_0 = Class5708.smethod_0(string_0);
		}
	}

	public bool method_60()
	{
		return bool_0;
	}

	private static int[] smethod_0(int[] ia, int length)
	{
		if (ia != null)
		{
			if (ia.Length == length)
			{
				return ia;
			}
			int[] array = new int[length];
			int i = 0;
			for (int num = ia.Length; i < num && i < length; i++)
			{
				array[i] = ia[i];
			}
			return array;
		}
		return ia;
	}

	private static int[][] smethod_1(int[][] im, int length)
	{
		if (im != null)
		{
			if (im.Length == length)
			{
				return im;
			}
			int[][] array = new int[length][];
			int i = 0;
			for (int num = im.Length; i < num && i < length; i++)
			{
				array[i] = im[i];
			}
			return array;
		}
		return im;
	}

	private static int[] smethod_2(int[] levels, int level, int count)
	{
		if (levels == null && level >= 0)
		{
			levels = new int[count];
			for (int i = 0; i < count; i++)
			{
				levels[i] = level;
			}
		}
		return smethod_0(levels, count);
	}

	private static void smethod_3(int[] a)
	{
		int i = 0;
		int num = a.Length;
		for (int num2 = num / 2; i < num2; i++)
		{
			int num3 = num - i - 1;
			int num4 = a[num3];
			a[num3] = a[i];
			a[i] = num4;
		}
	}

	private static void smethod_4(int[][] aa)
	{
		int i = 0;
		int num = aa.Length;
		for (int num2 = num / 2; i < num2; i++)
		{
			int num3 = num - i - 1;
			int[] array = aa[num3];
			aa[num3] = aa[i];
			aa[i] = array;
		}
	}
}
