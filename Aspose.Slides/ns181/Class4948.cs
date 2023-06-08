using System.Text;
using ns195;

namespace ns181;

internal class Class4948 : Class4947
{
	public Class4948()
	{
	}

	public Class4948(int stretch, int shrink, int adj)
		: base(stretch, shrink, adj)
	{
	}

	public void method_60()
	{
		arrayList_1.Clear();
	}

	public void method_61(string word, int offset)
	{
		method_63(word, 0, null, null, null, offset);
	}

	public void method_62(string word, int offset, int level)
	{
		method_63(word, 0, null, method_66(level, word.Length), null, offset);
	}

	public void method_63(string word, int ipD, int[] letterAdjust, int[] levels, int[][] gposAdjustments, int blockProgressionOffseT)
	{
		int num = smethod_0(levels);
		Class4956 @class = new Class4956(blockProgressionOffseT, num, word, letterAdjust, levels, gposAdjustments);
		@class.method_11(ipD);
		vmethod_2(@class);
		@class.vmethod_3(this);
		method_65(num);
	}

	public void method_64(char space, int ipD, bool adjustable, int blockProgressionOffseT, int level)
	{
		Class4955 @class = new Class4955(blockProgressionOffseT, level, space, adjustable);
		@class.method_11(ipD);
		vmethod_2(@class);
		@class.vmethod_3(this);
		method_65(level);
	}

	public virtual string vmethod_10()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (Class4943 item in arrayList_1)
		{
			if (item is Class4956)
			{
				stringBuilder.Append(((Class4956)item).method_51());
			}
			else
			{
				stringBuilder.Append(((Class4955)item).method_51());
			}
		}
		return stringBuilder.ToString();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(base.ToString());
		stringBuilder.Append(" {text=\"");
		stringBuilder.Append(Class5710.smethod_9(vmethod_10()));
		stringBuilder.Append("\"");
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}

	private void method_65(int newLevel)
	{
		if (newLevel < 0)
		{
			return;
		}
		int num = method_18();
		if (num >= 0)
		{
			if (newLevel < num)
			{
				method_16(newLevel);
			}
		}
		else
		{
			method_16(newLevel);
		}
	}

	private static int smethod_0(int[] levels)
	{
		if (levels != null)
		{
			int num = int.MaxValue;
			int i = 0;
			for (int num2 = levels.Length; i < num2; i++)
			{
				int num3 = levels[i];
				if (num3 >= 0 && num3 < num)
				{
					num = num3;
				}
			}
			if (num == int.MaxValue)
			{
				return -1;
			}
			return num;
		}
		return -1;
	}

	private int[] method_66(int level, int count)
	{
		if (level >= 0)
		{
			int[] array = new int[count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = level;
			}
			return array;
		}
		return null;
	}
}
