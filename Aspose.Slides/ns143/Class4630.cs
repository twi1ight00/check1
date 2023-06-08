using System;
using System.Collections;
using System.IO;
using ns147;
using ns149;

namespace ns143;

internal class Class4630 : Class4625
{
	private ushort ushort_2;

	private ushort[] ushort_3;

	private ushort[] ushort_4;

	private ushort[] ushort_5;

	private ushort[] ushort_6;

	private ushort[] ushort_7;

	private SortedList sortedList_0 = new SortedList();

	internal Class4630(Class4657 baseTable)
		: base(3, 1, baseTable)
	{
	}

	internal Class4630(ushort platformID, ushort platformSpecificID, Class4657 baseTable)
		: base(platformID, platformSpecificID, baseTable)
	{
	}

	internal override void vmethod_0(Class4689 ttfReader)
	{
		ushort num = ttfReader.method_18();
		ttfReader.method_18();
		ushort_2 = (ushort)((int)ttfReader.method_18() / 2);
		ttfReader.method_18();
		ttfReader.method_18();
		ttfReader.method_18();
		ushort_3 = new ushort[ushort_2];
		for (int i = 0; i < ushort_3.Length; i++)
		{
			ushort_3[i] = ttfReader.method_18();
		}
		ttfReader.method_18();
		ushort_4 = new ushort[ushort_2];
		ushort_5 = new ushort[ushort_2];
		ushort_7 = new ushort[ushort_2];
		for (int j = 0; j < ushort_4.Length; j++)
		{
			ushort_4[j] = ttfReader.method_18();
		}
		for (int k = 0; k < ushort_5.Length; k++)
		{
			ushort_5[k] = ttfReader.method_18();
		}
		for (int l = 0; l < ushort_7.Length; l++)
		{
			ushort_7[l] = ttfReader.method_18();
		}
		int num2 = (num - (8 * ushort_2 + 16)) / 2;
		ushort_6 = new ushort[num2];
		for (int m = 0; m < num2; m++)
		{
			ushort_6[m] = ttfReader.method_18();
		}
		base.vmethod_0(ttfReader);
	}

	public override void vmethod_1(ushort code, ushort glyphIndex)
	{
		if (!sortedList_0.ContainsKey(code))
		{
			sortedList_0.Add(code, glyphIndex);
		}
	}

	internal override void Save(out byte[] tableBytes, out uint length)
	{
		using MemoryStream memoryStream = new MemoryStream();
		using (Class4685 @class = new Class4685(memoryStream, closeStreamOnDispose: true))
		{
			@class.method_6(4);
			@class.method_6(0);
			@class.method_6(0);
			vmethod_1(ushort.MaxValue, 0);
			int count = sortedList_0.Count;
			@class.method_6((ushort)(count * 2));
			ushort num = (ushort)(2.0 * Math.Pow(2.0, Math.Floor(Math.Log(count, 2.0))));
			@class.method_6(num);
			@class.method_6((ushort)Math.Log((float)(int)num / 2f, 2.0));
			@class.method_6((ushort)(2 * count - num));
			foreach (ushort key in sortedList_0.Keys)
			{
				@class.method_6(key);
			}
			@class.method_6(0);
			foreach (ushort key2 in sortedList_0.Keys)
			{
				@class.method_6(key2);
			}
			foreach (ushort key3 in sortedList_0.Keys)
			{
				_ = key3;
				@class.method_6(0);
			}
			int num2 = 0;
			foreach (ushort key4 in sortedList_0.Keys)
			{
				_ = key4;
				int num3 = (count - num2 + num2) * 2;
				@class.method_6((ushort)num3);
				num2++;
			}
			foreach (ushort key5 in sortedList_0.Keys)
			{
				ushort value3 = (ushort)sortedList_0[key5];
				@class.method_6(value3);
			}
			length = (ushort)memoryStream.Position;
			@class.Position = 2L;
			@class.method_6((ushort)length);
		}
		memoryStream.Close();
		tableBytes = memoryStream.ToArray();
	}

	public override int vmethod_2(char charCode)
	{
		if (base.BaseTable.IsNewFont)
		{
			if (sortedList_0.ContainsKey((ushort)charCode))
			{
				return (ushort)sortedList_0[(ushort)charCode];
			}
		}
		else
		{
			for (int i = 0; i < ushort_2; i++)
			{
				if (charCode <= ushort_3[i] && ushort_4[i] <= charCode)
				{
					if (ushort_7[i] <= 0)
					{
						return (ushort_5[i] + charCode) % 65536;
					}
					int num = (int)ushort_7[i] / 2 + (charCode - ushort_4[i]) - (ushort_2 - i);
					if (num < ushort_6.Length)
					{
						return ushort_6[num];
					}
				}
				else if (charCode <= ushort_3[i])
				{
					break;
				}
			}
		}
		return 0;
	}
}
