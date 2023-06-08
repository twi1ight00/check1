using System;

namespace ns309;

internal class Class7115
{
	private Class7119[] class7119_0;

	private Class7119[] class7119_1;

	private int[] int_0;

	private int[] int_1;

	private float float_0;

	internal virtual float AdjustSpace => float_0;

	internal Class7115(int[] firstGlyphCodes, int[] secondGlyphCodes, Class7119[] firstUnicodeRanges, Class7119[] secondUnicodeRanges, float adjust)
	{
		int_0 = firstGlyphCodes;
		int_1 = secondGlyphCodes;
		class7119_0 = firstUnicodeRanges;
		class7119_1 = secondUnicodeRanges;
		float_0 = adjust;
		if (firstGlyphCodes != null)
		{
			Array.Sort(int_0);
		}
		if (secondGlyphCodes != null)
		{
			Array.Sort(int_1);
		}
	}

	internal virtual bool vmethod_0(int glyphCode, string glyphUnicode)
	{
		if (int_0 != null)
		{
			int num = Array.BinarySearch(int_0, glyphCode);
			if (num >= 0)
			{
				return true;
			}
		}
		if (glyphUnicode.Length < 1)
		{
			return false;
		}
		char unicodeVal = glyphUnicode[0];
		int num2 = 0;
		while (true)
		{
			if (num2 < class7119_0.Length)
			{
				if (class7119_0[num2].vmethod_1(unicodeVal))
				{
					break;
				}
				num2++;
				continue;
			}
			return false;
		}
		return true;
	}

	internal virtual bool vmethod_1(int glyphCode, char glyphUnicode)
	{
		if (int_0 != null)
		{
			int num = Array.BinarySearch(int_0, glyphCode);
			if (num >= 0)
			{
				return true;
			}
		}
		int num2 = 0;
		while (true)
		{
			if (num2 < class7119_0.Length)
			{
				if (class7119_0[num2].vmethod_1(glyphUnicode))
				{
					break;
				}
				num2++;
				continue;
			}
			return false;
		}
		return true;
	}

	internal virtual bool vmethod_2(int glyphCode, string glyphUnicode)
	{
		if (int_1 != null)
		{
			int num = Array.BinarySearch(int_1, glyphCode);
			if (num >= 0)
			{
				return true;
			}
		}
		if (glyphUnicode.Length < 1)
		{
			return false;
		}
		char unicodeVal = glyphUnicode[0];
		int num2 = 0;
		while (true)
		{
			if (num2 < class7119_1.Length)
			{
				if (class7119_1[num2].vmethod_1(unicodeVal))
				{
					break;
				}
				num2++;
				continue;
			}
			return false;
		}
		return true;
	}

	internal virtual bool vmethod_3(int glyphCode, char glyphUnicode)
	{
		if (int_1 != null)
		{
			int num = Array.BinarySearch(int_1, glyphCode);
			if (num >= 0)
			{
				return true;
			}
		}
		int num2 = 0;
		while (true)
		{
			if (num2 < class7119_1.Length)
			{
				if (class7119_1[num2].vmethod_1(glyphUnicode))
				{
					break;
				}
				num2++;
				continue;
			}
			return false;
		}
		return true;
	}
}
