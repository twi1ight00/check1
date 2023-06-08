using System;

namespace ns130;

internal class Class4570
{
	private struct Struct175
	{
		public const int int_0 = 4;

		public byte byte_0;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;
	}

	private struct Struct176
	{
		public const int int_0 = 6;

		public ushort ushort_0;

		public short short_0;

		public short short_1;
	}

	private class Class4571
	{
		public const int int_0 = 4;

		public ushort ushort_0;

		public byte byte_0;

		public byte byte_1;

		public Struct176[] struct176_0;
	}

	public static byte[] smethod_0(byte[] data)
	{
		Class4572 @class = new Class4572(data);
		ushort version = @class.method_3();
		ushort num = @class.method_3();
		ushort num2 = @class.method_3();
		Struct175[] array = new Struct175[num2];
		for (int i = 0; i < num2; i++)
		{
			array[i] = default(Struct175);
			array[i].byte_0 = @class.ReadByte();
			array[i].byte_1 = @class.ReadByte();
			array[i].byte_2 = @class.ReadByte();
			array[i].byte_3 = @class.ReadByte();
		}
		ushort[] array2 = new ushort[num2];
		for (int j = 0; j < num2; j++)
		{
			array2[j] = @class.method_3();
		}
		Class4571[] array3 = new Class4571[num];
		Class4574 class2 = new Class4574(data, isReverse: true);
		for (int k = 0; k < num; k++)
		{
			Class4571 class3 = new Class4571();
			class3.ushort_0 = @class.method_3();
			array3[k] = class3;
			short num3 = @class.method_4();
			short num4 = @class.method_4();
			class2.Position = @class.Position;
			class3.struct176_0 = new Struct176[class3.ushort_0];
			int num5 = 8;
			for (int l = 0; l < class3.ushort_0; l++)
			{
				sbyte b = smethod_2(class2);
				sbyte b2 = smethod_2(class2);
				sbyte b3 = smethod_2(class2);
				int num6 = b + num5;
				int num7 = (int)(((double)num6 * (double)num3 + 1024.0) / 2048.0);
				int num8 = (int)((0.0 - ((double)num6 * (double)num4 + 1024.0)) / 2048.0);
				class3.struct176_0[l] = default(Struct176);
				class3.struct176_0[l].ushort_0 = (ushort)num6;
				class3.struct176_0[l].short_0 = (short)(num7 + b2);
				class3.struct176_0[l].short_1 = (short)(num8 + b3);
				if (l == 0)
				{
					class3.byte_0 = (byte)num6;
				}
				class3.byte_1 = (byte)num6;
				num5 = num6 + 1;
			}
			@class.Position = class2.Position;
		}
		if (@class.Position != data.Length)
		{
			throw new InvalidOperationException("Incorrect length of 'VDMX' table");
		}
		return smethod_1(version, array, array2, array3);
	}

	private static byte[] smethod_1(ushort version, Struct175[] ratios, ushort[] offsets, Class4571[] groups)
	{
		if (version != 0 && version != 1)
		{
			throw new ArgumentException("Version of 'VDMX' table is incorrect");
		}
		int num = 6 + 4 * ratios.Length + 2 * offsets.Length + 4 * groups.Length;
		for (int i = 0; i < groups.Length; i++)
		{
			num += groups[i].struct176_0.Length * 6;
		}
		byte[] array = new byte[num];
		Class4573 @class = new Class4573(array);
		@class.method_0(version);
		@class.method_0((ushort)groups.Length);
		@class.method_0((ushort)ratios.Length);
		for (int j = 0; j < ratios.Length; j++)
		{
			Struct175 @struct = ratios[j];
			@class.Write(@struct.byte_0);
			@class.Write(@struct.byte_1);
			@class.Write(@struct.byte_2);
			@class.Write(@struct.byte_3);
		}
		for (int k = 0; k < offsets.Length; k++)
		{
			@class.method_0(offsets[k]);
		}
		for (int l = 0; l < groups.Length; l++)
		{
			Class4571 class2 = groups[l];
			@class.method_0(class2.ushort_0);
			@class.Write(class2.byte_0);
			@class.Write(class2.byte_1);
			for (int m = 0; m < class2.struct176_0.Length; m++)
			{
				Struct176 struct2 = class2.struct176_0[l];
				@class.method_0(struct2.ushort_0);
				@class.Write(struct2.short_0);
				@class.Write(struct2.short_1);
			}
		}
		return array;
	}

	private static sbyte smethod_2(Class4574 reader)
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
