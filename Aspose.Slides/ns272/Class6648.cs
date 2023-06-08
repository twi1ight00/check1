using System;
using System.Collections;
using ns218;
using ns221;
using ns271;

namespace ns272;

internal class Class6648 : Class6644
{
	private int int_0;

	private int[] int_1;

	private int[] int_2;

	private int[] int_3;

	private int[] int_4;

	private int[] int_5;

	private int int_6;

	internal int int_7;

	internal int int_8;

	internal int int_9;

	private SortedList sortedList_0 = new SortedList();

	public int SegCount => int_0;

	public int[] EndCode => int_1;

	public int[] StartCode => int_2;

	public Class6648(Class6634 baseTable)
		: base(3, 1, baseTable)
	{
	}

	public Class6648(ushort platformID, ushort platformSpecificID, Class6634 baseTable)
		: base(platformID, platformSpecificID, baseTable)
	{
	}

	[Attribute7(true)]
	internal override void vmethod_0(Class5950 ttfReader)
	{
		ushort num = ttfReader.method_3();
		int_6 = ttfReader.method_3();
		int_0 = (ushort)((int)ttfReader.method_3() / 2);
		int_7 = ttfReader.method_3();
		int_8 = ttfReader.method_3();
		int_9 = ttfReader.method_3();
		int_1 = new int[int_0];
		for (int i = 0; i < int_1.Length; i++)
		{
			int_1[i] = ttfReader.method_3();
		}
		ttfReader.method_3();
		int_2 = new int[int_0];
		int_3 = new int[int_0];
		int_5 = new int[int_0];
		for (int j = 0; j < int_2.Length; j++)
		{
			int_2[j] = ttfReader.method_3();
		}
		for (int k = 0; k < int_3.Length; k++)
		{
			int_3[k] = ttfReader.method_3();
		}
		for (int l = 0; l < int_5.Length; l++)
		{
			int_5[l] = ttfReader.method_3();
		}
		int num2 = (num - (8 * int_0 + 16)) / 2;
		int_4 = new int[num2];
		for (int m = 0; m < num2; m++)
		{
			int_4[m] = ttfReader.method_3();
		}
		base.vmethod_0(ttfReader);
	}

	internal override void vmethod_1(ushort code, ushort glyphIndex)
	{
		if (!sortedList_0.ContainsKey(code))
		{
			sortedList_0.Add(code, glyphIndex);
		}
	}

	internal override Class6735 vmethod_2(Class6728 hMetrics)
	{
		Class6735 @class = new Class6735(((Class6636)base.BaseTable).IsSymbolicFont);
		for (int i = 0; i < int_0; i++)
		{
			for (int j = int_2[i]; j <= int_1[i]; j++)
			{
				int num = ((j < 65535) ? vmethod_3((char)j) : 0);
				Struct223 @struct = hMetrics.method_0(num);
				Class6734 class2 = new Class6734((char)j, num, @struct.ushort_0, @struct.short_0);
				@class.Add(class2);
				if (class2.OldGlyphIndex == 0)
				{
					@class.MissingGlyph = class2;
				}
			}
		}
		return @class;
	}

	internal override void Save(Class5951 writer)
	{
		writer.method_3(4);
		int value = 16 + SegCount * 8 + int_4.Length * 2;
		writer.method_3(value);
		writer.method_3(int_6);
		writer.method_3(SegCount * 2);
		writer.method_3(int_7);
		writer.method_3(int_8);
		writer.method_3(int_9);
		smethod_0(int_1, writer);
		writer.method_3(0);
		smethod_0(int_2, writer);
		smethod_0(int_3, writer);
		smethod_0(int_5, writer);
		smethod_0(int_4, writer);
	}

	private static void smethod_0(int[] data, Class5951 writer)
	{
		foreach (int value in data)
		{
			writer.method_3(value);
		}
	}

	public override int vmethod_3(char charCode)
	{
		for (int i = 0; i < int_0; i++)
		{
			if (charCode <= int_1[i] && int_2[i] <= charCode)
			{
				if (int_5[i] <= 0)
				{
					return (int_3[i] + charCode) % 65536;
				}
				int num = int_5[i] / 2 + (charCode - int_2[i]) - (int_0 - i);
				if (num < int_4.Length)
				{
					return int_4[num];
				}
			}
			else if (charCode <= int_1[i])
			{
				break;
			}
		}
		return 0;
	}

	internal void method_1(Class5967 charsToNewGlyphIndexes)
	{
		int index = charsToNewGlyphIndexes.Count - 1;
		if (charsToNewGlyphIndexes.method_4(index) != 65535)
		{
			throw new InvalidOperationException("Last character is supposed to be the 0xffff (the missing character).");
		}
		if ((int)charsToNewGlyphIndexes.method_3(index) != 0)
		{
			throw new InvalidOperationException("Glyph index for the missing character is expected to be zero.");
		}
		int_0 = (ushort)charsToNewGlyphIndexes.Count;
		int_7 = 2 << (int)Math.Floor(Math.Log(int_0) / Math.Log(2.0));
		int_8 = (int)(Math.Log((double)int_7 / 2.0) / Math.Log(2.0));
		int_9 = 2 * int_0 - int_7;
		int_1 = new int[int_0];
		int_2 = new int[int_0];
		int_3 = new int[int_0];
		int_5 = new int[int_0];
		int_4 = new int[0];
		for (int i = 0; i < charsToNewGlyphIndexes.Count; i++)
		{
			int num = charsToNewGlyphIndexes.method_4(i);
			int num2 = (int)charsToNewGlyphIndexes.method_3(i);
			int_1[i] = num;
			int_2[i] = num;
			int_3[i] = num2 - num;
		}
	}
}
