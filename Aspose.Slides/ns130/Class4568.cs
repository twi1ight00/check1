using System;

namespace ns130;

internal class Class4568
{
	private struct Struct173
	{
		public const int int_0 = 2;

		public byte byte_0;

		public byte byte_1;
	}

	public static byte[] smethod_0(Class4588 hmtx, byte[] data, ushort numberOfGlyphs, ushort unitsPerEm)
	{
		Class4572 @class = new Class4572(data);
		@class.method_3();
		ushort num = @class.method_3();
		@class.method_1();
		Struct173[] array = new Struct173[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = default(Struct173);
			array[i].byte_0 = @class.ReadByte();
			array[i].byte_1 = @class.ReadByte();
		}
		Class4574 class2 = new Class4574(data, isReverse: true);
		class2.Position = @class.Position;
		int num2 = (numberOfGlyphs + 2 + 4 - 1) & -4;
		byte[] array2 = new byte[8 + array.Length * num2];
		int j;
		for (j = 0; j < 8; j++)
		{
			array2[j] = data[j];
		}
		Struct173[] array3 = array;
		for (int k = 0; k < array3.Length; k++)
		{
			Struct173 @struct = array3[k];
			array2[j] = @struct.byte_0;
			array2[j + 1] = @struct.byte_1;
			j += 2;
			for (int l = 0; l < numberOfGlyphs; l++)
			{
				int num3 = (int)(((64.0 * (double)(int)@struct.byte_0 * (double)(int)hmtx.method_5(l) + (double)(int)unitsPerEm / 2.0) / (double)(int)unitsPerEm + 32.0) / 64.0);
				int num4 = smethod_1(class2);
				array2[l + j] = (byte)(num3 + num4);
			}
			j += num2 - 2;
		}
		if (j != array2.Length)
		{
			throw new InvalidOperationException("Incorrect length of output data in 'hdmx' decoder");
		}
		return array2;
	}

	private static sbyte smethod_1(Class4574 reader)
	{
		sbyte b = 0;
		while (reader.method_0())
		{
			b = (sbyte)(b + 1);
		}
		if (b != 0 && !reader.method_0())
		{
			b = (sbyte)(b * -1);
		}
		return b;
	}
}
