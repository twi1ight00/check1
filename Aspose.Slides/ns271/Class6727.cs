using System;
using System.Collections;
using System.IO;
using ns218;

namespace ns271;

internal class Class6727
{
	[Flags]
	private enum Enum895
	{
		flag_0 = 1,
		flag_1 = 2,
		flag_2 = 4,
		flag_3 = 8,
		flag_4 = 0x10,
		flag_5 = 0x20,
		flag_6 = 0x40,
		flag_7 = 0x80,
		flag_8 = 0x100,
		flag_9 = 0x200
	}

	private Class5950 class5950_0;

	private bool bool_0;

	private int[] int_0;

	private Class5962 class5962_0;

	private MemoryStream memoryStream_0;

	private MemoryStream memoryStream_1;

	private MemoryStream memoryStream_2;

	internal MemoryStream NewLoca => memoryStream_0;

	internal MemoryStream NewGlyf => memoryStream_1;

	internal MemoryStream NewHmtx => memoryStream_2;

	internal Class6727(Class5950 reader, bool isLocaShort)
	{
		class5950_0 = reader;
		bool_0 = isLocaShort;
	}

	internal int method_0(Class6729 oldLoca, Class6729 oldGlyf, Class6728 horizontalMetrics, Class5967 usedGlyphs)
	{
		method_6(oldLoca);
		method_8(oldGlyf, horizontalMetrics, usedGlyphs);
		method_7();
		return class5962_0.Count - 1;
	}

	internal Hashtable method_1(Class6729 oldLoca, Class6729 oldGlyf, Class5967 usedGlyphs, int EMHaight)
	{
		method_6(oldLoca);
		Hashtable hashtable = new Hashtable();
		Class5967 @class = smethod_1(usedGlyphs);
		for (int i = 0; i < @class.Count; i++)
		{
			Class6658 class2 = new Class6658(EMHaight);
			int oldGlyphIndex = (int)@class.method_3(i);
			method_2(oldGlyphIndex, oldGlyf, class2);
			hashtable[i] = class2;
		}
		return hashtable;
	}

	private void method_2(int oldGlyphIndex, Class6729 oldGlyf, Class6658 glyphData)
	{
		class5950_0.BaseStream.Position = oldGlyf.int_2 + int_0[oldGlyphIndex];
		short num = class5950_0.method_2();
		class5950_0.BaseStream.Position -= 2L;
		if (num < 0)
		{
			method_3(glyphData, oldGlyf);
		}
		else
		{
			method_4(glyphData);
		}
	}

	private void method_3(Class6658 glyphData, Class6729 oldGlyf)
	{
		class5950_0.method_2();
		class5950_0.method_2();
		class5950_0.method_2();
		class5950_0.method_2();
		class5950_0.method_2();
		Enum895 @enum;
		do
		{
			@enum = (Enum895)class5950_0.method_3();
			int oldGlyphIndex = class5950_0.method_3();
			if ((@enum & Enum895.flag_0) == 0)
			{
				class5950_0.ReadByte();
				class5950_0.ReadByte();
			}
			else
			{
				class5950_0.method_3();
				class5950_0.method_3();
			}
			if ((@enum & Enum895.flag_3) != 0)
			{
				method_5();
			}
			else if ((@enum & Enum895.flag_6) != 0)
			{
				method_5();
				method_5();
			}
			else if ((@enum & Enum895.flag_7) != 0)
			{
				method_5();
				method_5();
				method_5();
				method_5();
			}
			long position = class5950_0.BaseStream.Position;
			method_2(oldGlyphIndex, oldGlyf, glyphData);
			class5950_0.BaseStream.Position = position;
		}
		while ((@enum & Enum895.flag_5) != 0);
		if ((@enum & Enum895.flag_8) != 0)
		{
			int count = class5950_0.method_3();
			class5950_0.method_8(count);
		}
	}

	private void method_4(Class6658 glyphData)
	{
		int num = class5950_0.method_2();
		class5950_0.method_2();
		class5950_0.method_2();
		class5950_0.method_2();
		class5950_0.method_2();
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = class5950_0.method_3();
		}
		int num2 = 0;
		for (int j = 0; j < array.Length; j++)
		{
			num2 = 1 + ((num2 < array[j]) ? array[j] : num2);
		}
		int count = class5950_0.method_3();
		class5950_0.method_8(count);
		byte[] array2 = new byte[num2];
		for (int k = 0; k < num2; k++)
		{
			byte b = (array2[k] = class5950_0.ReadByte());
			bool[] array3 = Class5964.smethod_44(array2[k]);
			if (array3[3])
			{
				int num3 = class5950_0.ReadByte();
				for (int l = 0; l < num3; l++)
				{
					k++;
					array2[k] = b;
				}
			}
		}
		int[] array4 = new int[num2];
		for (int m = 0; m < num2; m++)
		{
			bool[] array5 = Class5964.smethod_44(array2[m]);
			if (array5[1])
			{
				array4[m] = class5950_0.ReadByte() * (array5[4] ? 1 : (-1));
			}
			else
			{
				array4[m] = (array5[4] ? array4[m] : class5950_0.method_2());
			}
		}
		int[] array6 = new int[num2];
		for (int n = 0; n < num2; n++)
		{
			bool[] array7 = Class5964.smethod_44(array2[n]);
			if (array7[2])
			{
				array6[n] = class5950_0.ReadByte() * (array7[5] ? 1 : (-1));
			}
			else
			{
				array6[n] = (array7[5] ? array6[n] : class5950_0.method_2());
			}
		}
		int num4 = 0;
		for (int num5 = 0; num5 < num2; num5++)
		{
			bool[] array8 = Class5964.smethod_44(array2[num5]);
			bool isEndOfCotour;
			if (isEndOfCotour = array[num4] == num5)
			{
				num4++;
			}
			glyphData.Points.Add(array4[num5], array6[num5], array8[0], isEndOfCotour);
		}
	}

	private float method_5()
	{
		short num = class5950_0.method_2();
		int num2 = num >> 14;
		float num3 = (num & 0x3FFF) / 16383;
		return (float)num2 + num3;
	}

	private void method_6(Class6729 oldLoca)
	{
		class5950_0.BaseStream.Position = oldLoca.int_2;
		if (bool_0)
		{
			int num = oldLoca.int_3 / 2;
			int_0 = new int[num];
			for (int i = 0; i < num; i++)
			{
				int_0[i] = class5950_0.method_3() * 2;
			}
		}
		else
		{
			int num2 = oldLoca.int_3 / 4;
			int_0 = new int[num2];
			for (int j = 0; j < num2; j++)
			{
				int_0[j] = class5950_0.method_0();
			}
		}
	}

	private void method_7()
	{
		memoryStream_0 = new MemoryStream();
		Class5951 @class = new Class5951(memoryStream_0);
		if (bool_0)
		{
			for (int i = 0; i < class5962_0.Count; i++)
			{
				@class.method_3(class5962_0[i] / 2);
			}
		}
		else
		{
			for (int j = 0; j < class5962_0.Count; j++)
			{
				@class.method_0(class5962_0[j]);
			}
		}
	}

	private void method_8(Class6729 oldGlyf, Class6728 horizontalMetrics, Class5967 oldToNewGlyphIndexes)
	{
		Class5967 @class = smethod_1(oldToNewGlyphIndexes);
		class5962_0 = new Class5962();
		memoryStream_1 = new MemoryStream();
		Class5951 class2 = new Class5951(memoryStream_1);
		memoryStream_2 = new MemoryStream();
		Class5951 writer = new Class5951(memoryStream_2);
		for (int i = 0; i < @class.Count; i++)
		{
			class5962_0.Add((int)class2.BaseStream.Position);
			int num = (int)@class.method_3(i);
			class5950_0.BaseStream.Position = oldGlyf.int_2 + int_0[num];
			int num2 = int_0[num + 1] - int_0[num];
			if (num2 > 0)
			{
				short num3 = class5950_0.method_2();
				if (num3 < 0)
				{
					class2.method_3(num3);
					byte[] array = class5950_0.method_8(8);
					class2.method_4(array, 0, array.Length);
					Enum895 @enum;
					do
					{
						@enum = (Enum895)class5950_0.method_3();
						class2.method_3((int)@enum);
						int num4 = class5950_0.method_3();
						object obj = oldToNewGlyphIndexes[num4];
						int num6;
						if (obj == null)
						{
							int num5 = @class.method_4(@class.Count - 1);
							num6 = num5 + 1;
							oldToNewGlyphIndexes.Add(num4, num6);
							@class.Add(num6, num4);
						}
						else
						{
							num6 = (int)obj;
						}
						byte[] array2 = class5950_0.method_8(smethod_0(@enum));
						class2.method_3(num6);
						class2.method_4(array2, 0, array2.Length);
					}
					while ((@enum & Enum895.flag_5) != 0);
					if ((@enum & Enum895.flag_8) != 0)
					{
						int num7 = class5950_0.method_3();
						byte[] array3 = class5950_0.method_8(num7);
						class2.method_3(num7);
						class2.method_4(array3, 0, array3.Length);
					}
				}
				else
				{
					class5950_0.BaseStream.Position -= 2L;
					byte[] array4 = class5950_0.method_8(num2);
					class2.method_4(array4, 0, array4.Length);
				}
				if (Class5964.smethod_4(class2.BaseStream.Position))
				{
					class2.WriteByte(0);
				}
			}
			horizontalMetrics.method_0(num).Write(writer);
		}
		class5962_0.Add((int)class2.BaseStream.Position);
	}

	private static int smethod_0(Enum895 flags)
	{
		int num = (((flags & Enum895.flag_0) == 0) ? 2 : 4);
		if ((flags & Enum895.flag_3) != 0)
		{
			num += 2;
		}
		else if ((flags & Enum895.flag_6) != 0)
		{
			num += 4;
		}
		else if ((flags & Enum895.flag_7) != 0)
		{
			num += 8;
		}
		return num;
	}

	private static Class5967 smethod_1(Class5967 keyToValue)
	{
		Class5967 @class = new Class5967();
		for (int i = 0; i < keyToValue.Count; i++)
		{
			int num = keyToValue.method_4(i);
			int key = (int)keyToValue.method_3(i);
			@class.Add(key, num);
		}
		return @class;
	}
}
