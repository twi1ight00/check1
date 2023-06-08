using System;
using System.Collections;

namespace ns130;

internal class Class4561
{
	internal class Class4562
	{
		public byte[] byte_0;

		public bool bool_0;

		public byte[] byte_1;

		public short short_0;

		public short short_1;

		public short short_2;

		public short short_3;

		public ushort ushort_0;

		public ushort ushort_1;

		public short short_4;

		public short short_5;

		public ushort ushort_2;

		public short short_6;
	}

	private class Class4563
	{
		public const int int_0 = 1;

		public const int int_1 = 8;

		public const int int_2 = 32;

		public const int int_3 = 64;

		public const int int_4 = 128;

		public const int int_5 = 256;
	}

	private class Class4564
	{
		public const int int_0 = 1;

		public const int int_1 = 2;

		public const int int_2 = 4;

		public const int int_3 = 8;

		public const int int_4 = 16;

		public const int int_5 = 32;
	}

	private struct Struct172
	{
		public short short_0;

		public short short_1;

		public Struct172(short x, short y)
		{
			short_0 = x;
			short_1 = y;
		}
	}

	private abstract class Class4565
	{
		public const int int_0 = 10;

		public short short_0;

		public short short_1;

		public short short_2;

		public short short_3;

		public short short_4;

		public byte[] byte_0;

		public byte[] byte_1;

		public virtual int Length => 10 + byte_0.Length + 2 + byte_1.Length;

		public abstract void Write(Class4573 writer);
	}

	private class Class4566 : Class4565
	{
		public ushort[] ushort_0;

		public short[] short_5;

		public short[] short_6;

		public override int Length
		{
			get
			{
				if (short_0 <= 0)
				{
					return 0;
				}
				return 10 + ushort_0.Length * 2 + 2 + byte_1.Length + byte_0.Length + short_5.Length * 2 + short_6.Length * 2;
			}
		}

		public override void Write(Class4573 writer)
		{
			if (short_0 > 0)
			{
				writer.Write(short_0);
				writer.Write(short_1);
				writer.Write(short_2);
				writer.Write(short_3);
				writer.Write(short_4);
				for (int i = 0; i < ushort_0.Length; i++)
				{
					writer.method_0(ushort_0[i]);
				}
				writer.method_0((ushort)byte_1.Length);
				for (int j = 0; j < byte_1.Length; j++)
				{
					writer.Write(byte_1[j]);
				}
				for (int k = 0; k < byte_0.Length; k++)
				{
					writer.Write(byte_0[k]);
				}
				for (int l = 0; l < short_5.Length; l++)
				{
					writer.Write(short_5[l]);
				}
				for (int m = 0; m < short_6.Length; m++)
				{
					writer.Write(short_6[m]);
				}
			}
		}
	}

	private class Class4567 : Class4565
	{
		public ushort ushort_0;

		public Class4567()
		{
			short_0 = -1;
		}

		public override void Write(Class4573 writer)
		{
			writer.Write(short_0);
			writer.Write(short_1);
			writer.Write(short_2);
			writer.Write(short_3);
			writer.Write(short_4);
			for (int i = 0; i < byte_0.Length; i++)
			{
				writer.Write(byte_0[i]);
			}
			writer.method_0((ushort)byte_1.Length);
			for (int j = 0; j < byte_1.Length; j++)
			{
				writer.Write(byte_1[j]);
			}
		}
	}

	private const byte byte_0 = 253;

	private const byte byte_1 = 254;

	private const byte byte_2 = byte.MaxValue;

	private const byte byte_3 = 253;

	private const byte byte_4 = 250;

	private const byte byte_5 = 250;

	private const byte byte_6 = 251;

	private const byte byte_7 = 252;

	private byte[] byte_8;

	private byte[] byte_9;

	private byte[] byte_10;

	private Class4572 class4572_0;

	private Class4572 class4572_1;

	private Class4572 class4572_2;

	public Class4561(byte[] glyphData, byte[] pushData, byte[] glyphInstructions)
	{
		byte_8 = glyphData;
		byte_9 = pushData;
		byte_10 = glyphInstructions;
		class4572_0 = new Class4572(glyphData);
		class4572_1 = new Class4572(pushData);
		class4572_2 = new Class4572(glyphInstructions);
	}

	public Class4562 method_0(int numberOfGlyphs, Class4588 hmtx)
	{
		Class4565[] array = method_2(numberOfGlyphs);
		uint num = 0u;
		bool isLongOffsets = false;
		for (int i = 0; i < numberOfGlyphs; i++)
		{
			if (num / 2u <= 65535)
			{
				num += (uint)((array[i].Length + 4 - 1) & -4);
				continue;
			}
			isLongOffsets = true;
			break;
		}
		return method_1(array, isLongOffsets, hmtx);
	}

	private Class4562 method_1(Class4565[] glyphs, bool isLongOffsets, Class4588 hmtx)
	{
		Class4565 @class = glyphs[0];
		Class4562 class2 = new Class4562();
		class2.byte_0 = smethod_0(glyphs);
		class2.bool_0 = isLongOffsets;
		class2.byte_1 = smethod_1(isLongOffsets, glyphs);
		class2.short_0 = @class.short_3;
		class2.short_1 = @class.short_4;
		class2.short_3 = @class.short_1;
		class2.short_3 = @class.short_2;
		class2.ushort_0 = (ushort)@class.byte_1.Length;
		if (@class is Class4567 class3)
		{
			class2.ushort_1 = class3.ushort_0;
		}
		short num = hmtx.method_6(0);
		ushort num2 = hmtx.method_5(0);
		short short_ = (short)(num2 - num - (@class.short_3 - @class.short_1));
		short short_2 = (short)(num + (@class.short_3 - @class.short_1));
		class2.short_4 = num;
		class2.ushort_2 = num2;
		class2.short_5 = short_;
		class2.short_6 = short_2;
		for (int i = 1; i < glyphs.Length; i++)
		{
			@class = glyphs[i];
			if (@class.short_3 > class2.short_0)
			{
				class2.short_0 = @class.short_3;
			}
			if (@class.short_4 > class2.short_1)
			{
				class2.short_1 = @class.short_4;
			}
			if (@class.short_1 < class2.short_2)
			{
				class2.short_2 = @class.short_1;
			}
			if (@class.short_2 < class2.short_3)
			{
				class2.short_3 = @class.short_2;
			}
			if (class2.ushort_0 < @class.byte_1.Length)
			{
				class2.ushort_0 = (ushort)@class.byte_1.Length;
			}
			if (@class is Class4567)
			{
				class2.ushort_1 = ((Class4567)@class).ushort_0;
			}
			num = hmtx.method_6(i);
			num2 = hmtx.method_5(i);
			short_ = (short)(num2 - num - (@class.short_3 - @class.short_1));
			short_2 = (short)(num + (@class.short_3 - @class.short_1));
			if (num < class2.short_4)
			{
				class2.short_4 = num;
			}
			if (short_ < class2.short_5)
			{
				class2.short_5 = short_;
			}
			if (num2 > class2.ushort_2)
			{
				class2.ushort_2 = num2;
			}
			if (short_2 > class2.short_6)
			{
				class2.short_6 = short_2;
			}
		}
		return class2;
	}

	private static byte[] smethod_0(Class4565[] glyphs)
	{
		int num = 0;
		foreach (Class4565 @class in glyphs)
		{
			num += (@class.Length + 4 - 1) & -4;
		}
		byte[] array = new byte[num];
		Class4573 class2 = new Class4573(array);
		foreach (Class4565 class3 in glyphs)
		{
			class3.Write(class2);
			int num2 = ((class3.Length + 4 - 1) & -4) - class3.Length;
			class2.Position += num2;
		}
		return array;
	}

	private static byte[] smethod_1(bool isNeedLongOffsets, Class4565[] glyphs)
	{
		byte[] array = new byte[(glyphs.Length + 1) * (isNeedLongOffsets ? 4 : 2)];
		Class4573 @class = new Class4573(array);
		uint num = 0u;
		for (int i = 0; i <= glyphs.Length; i++)
		{
			if (isNeedLongOffsets)
			{
				@class.Write(num);
			}
			else
			{
				@class.method_0((ushort)(num / 2u));
			}
			num += (uint)((i < glyphs.Length) ? ((glyphs[i].Length + 4 - 1) & -4) : 0);
		}
		return array;
	}

	private Class4565[] method_2(int numberOfGlyphs)
	{
		Class4565[] array = new Class4565[numberOfGlyphs];
		for (int i = 0; i < numberOfGlyphs; i++)
		{
			short num = class4572_0.method_4();
			array[i] = ((num < 0) ? ((Class4565)method_3()) : ((Class4565)method_4(num)));
		}
		if (class4572_0.Position != class4572_0.InputLength)
		{
			throw new InvalidOperationException("Invalid length of glyph data array");
		}
		if (class4572_1.Position != class4572_1.InputLength)
		{
			throw new InvalidOperationException("Invalid length of glyph push data array");
		}
		if (class4572_2.Position != class4572_2.InputLength)
		{
			throw new InvalidOperationException("Invalid length of glyph instructions array");
		}
		class4572_0.Position = 0;
		class4572_1.Position = 0;
		class4572_2.Position = 0;
		return array;
	}

	private Class4567 method_3()
	{
		Class4567 @class = new Class4567();
		@class.short_1 = class4572_0.method_4();
		@class.short_2 = class4572_0.method_4();
		@class.short_3 = class4572_0.method_4();
		@class.short_4 = class4572_0.method_4();
		int position = class4572_0.Position;
		ushort num;
		do
		{
			@class.ushort_0++;
			num = class4572_0.method_3();
			class4572_0.Position += 2;
			if ((num & 1) != 1)
			{
				class4572_0.Position += 2;
			}
			else
			{
				class4572_0.Position += 4;
			}
			if ((num & 8) == 8)
			{
				class4572_0.Position += 2;
			}
			else if ((num & 0x40) == 64)
			{
				class4572_0.Position += 4;
			}
			else if ((num & 0x80) == 128)
			{
				class4572_0.Position += 8;
			}
		}
		while ((num & 0x20) == 32);
		@class.byte_0 = new byte[class4572_0.Position - position];
		Buffer.BlockCopy(byte_8, position, @class.byte_0, 0, @class.byte_0.Length);
		@class.byte_1 = (((num & 0x100) == 256) ? method_5() : new byte[0]);
		return @class;
	}

	private Class4566 method_4(short numberOfCountours)
	{
		Struct172 @struct = default(Struct172);
		@struct.short_0 = short.MaxValue;
		@struct.short_1 = short.MaxValue;
		Struct172 struct2 = default(Struct172);
		struct2.short_0 = short.MinValue;
		struct2.short_1 = short.MinValue;
		bool flag = false;
		if (numberOfCountours == short.MaxValue)
		{
			numberOfCountours = class4572_0.method_4();
			@struct.short_0 = class4572_0.method_4();
			@struct.short_1 = class4572_0.method_4();
			struct2.short_0 = class4572_0.method_4();
			struct2.short_1 = class4572_0.method_4();
			flag = true;
		}
		Class4566 @class = new Class4566();
		@class.short_0 = numberOfCountours;
		@class.ushort_0 = new ushort[numberOfCountours];
		ushort num = 0;
		for (int i = 0; i < numberOfCountours; i++)
		{
			ushort num2 = smethod_4(class4572_0);
			num = (ushort)(num + num2);
			@class.ushort_0[i] = num;
		}
		if (num > 0)
		{
			num = (ushort)(num + 1);
		}
		@class.byte_0 = new byte[num];
		@class.short_5 = new short[num];
		@class.short_6 = new short[num];
		byte[] array = new byte[num];
		for (int j = 0; j < num; j++)
		{
			array[j] = class4572_0.ReadByte();
		}
		Struct172 struct3 = default(Struct172);
		for (int k = 0; k < num; k++)
		{
			byte flags;
			Struct172 struct4 = method_9(array[k], out flags);
			@class.byte_0[k] = flags;
			@class.short_5[k] = struct4.short_0;
			@class.short_6[k] = struct4.short_1;
			struct3.short_0 += struct4.short_0;
			struct3.short_1 += struct4.short_1;
			if (!flag)
			{
				if (@struct.short_0 > struct3.short_0)
				{
					@struct.short_0 = struct3.short_0;
				}
				if (@struct.short_1 > struct3.short_1)
				{
					@struct.short_1 = struct3.short_1;
				}
				if (struct2.short_0 < struct3.short_0)
				{
					struct2.short_0 = struct3.short_0;
				}
				if (struct2.short_1 < struct3.short_1)
				{
					struct2.short_1 = struct3.short_1;
				}
			}
		}
		@class.short_1 = @struct.short_0;
		@class.short_2 = @struct.short_1;
		@class.short_3 = struct2.short_0;
		@class.short_4 = struct2.short_1;
		@class.byte_1 = ((numberOfCountours > 0) ? method_5() : new byte[0]);
		return @class;
	}

	private byte[] method_5()
	{
		ushort num = smethod_4(class4572_0);
		ushort num2 = smethod_4(class4572_0);
		byte[] array2;
		if (num > 0)
		{
			byte[] array = method_6(method_8(num));
			array2 = new byte[array.Length + num2];
			int i;
			for (i = 0; i < array.Length; i++)
			{
				array2[i] = array[i];
			}
			for (; i < array2.Length; i++)
			{
				array2[i] = class4572_2.ReadByte();
			}
		}
		else
		{
			array2 = new byte[num2];
			for (int j = 0; j < num2; j++)
			{
				array2[j] = class4572_2.ReadByte();
			}
		}
		return array2;
	}

	private byte[] method_6(short[] data)
	{
		int i = 0;
		ArrayList arrayList = new ArrayList();
		while (i < data.Length)
		{
			arrayList.AddRange(method_7(ref i, data));
		}
		return (byte[])arrayList.ToArray(typeof(byte));
	}

	private byte[] method_7(ref int i, short[] data)
	{
		bool flag = false;
		int num = i;
		ArrayList arrayList = new ArrayList(data.Length * 2);
		while (i < data.Length)
		{
			if (!flag)
			{
				if (data[i] >= 0 && data[i] <= 255)
				{
					smethod_2(arrayList, (byte)data[i]);
				}
				else
				{
					if (num != i)
					{
						break;
					}
					flag = true;
					smethod_3(arrayList, data[i]);
				}
			}
			else
			{
				if (data[i] >= 0 && data[i] <= 255)
				{
					break;
				}
				smethod_3(arrayList, data[i]);
			}
			i++;
		}
		byte b = (byte)(i - num);
		byte b2 = (byte)((!flag) ? ((b <= 8) ? ((byte)(176 + b - 1)) : 64) : ((b <= 8) ? ((byte)(184 + b - 1)) : 65));
		arrayList.Insert(0, b2);
		if (b > 8)
		{
			arrayList.Insert(1, b);
		}
		return (byte[])arrayList.ToArray(typeof(byte));
	}

	private static void smethod_2(ArrayList list, byte value)
	{
		list.Add(value);
	}

	private static void smethod_3(ArrayList list, short value)
	{
		list.Add((byte)((uint)(value >> 8) & 0xFFu));
		list.Add((byte)((uint)value & 0xFFu));
	}

	private short[] method_8(int pushCount)
	{
		short[] array = new short[pushCount];
		if (class4572_1.Position < byte_9.Length)
		{
			int num = 0;
			while (num < pushCount)
			{
				switch (byte_9[class4572_1.Position])
				{
				case 251:
				{
					short num2 = array[num - 2];
					class4572_1.Position++;
					array[num++] = num2;
					array[num++] = smethod_5(class4572_1);
					array[num++] = num2;
					break;
				}
				case 252:
				{
					short num2 = array[num - 2];
					class4572_1.Position++;
					array[num++] = num2;
					array[num++] = smethod_5(class4572_1);
					array[num++] = num2;
					array[num++] = smethod_5(class4572_1);
					array[num++] = num2;
					break;
				}
				default:
					array[num++] = smethod_5(class4572_1);
					break;
				}
			}
		}
		return array;
	}

	private Struct172 method_9(byte tripletFlags, out byte flags)
	{
		flags = 0;
		if ((tripletFlags & 0x80) == 0)
		{
			flags |= 1;
		}
		Class4569.Struct174 @struct = Class4569.smethod_0(tripletFlags & 0x7F);
		byte b = (byte)(@struct.byte_0 - 1);
		int num = 0;
		for (int i = 0; i < b; i++)
		{
			num <<= 8;
			num |= class4572_0.ReadByte();
		}
		int num2 = num >> b * 8 - @struct.byte_1;
		num2 &= (1 << (int)@struct.byte_1) - 1;
		int num3 = num >> b * 8 - @struct.byte_1 - @struct.byte_2;
		num3 &= (1 << (int)@struct.byte_2) - 1;
		num2 += @struct.ushort_0;
		num3 += @struct.ushort_1;
		if (@struct.bool_0)
		{
			num2 = -num2;
		}
		if (@struct.bool_1)
		{
			num3 = -num3;
		}
		return new Struct172((short)num2, (short)num3);
	}

	private static ushort smethod_4(Class4572 reader)
	{
		ushort num = 0;
		byte b = reader.ReadByte();
		switch (b)
		{
		case 253:
			num = reader.ReadByte();
			num = (ushort)(num << 8);
			return (ushort)(num | reader.ReadByte());
		case byte.MaxValue:
			return (ushort)(reader.ReadByte() + 253);
		case 254:
			return (ushort)(reader.ReadByte() + 506);
		default:
			return b;
		}
	}

	private static short smethod_5(Class4572 reader)
	{
		byte b = reader.ReadByte();
		if (b == 253)
		{
			ushort num = reader.ReadByte();
			num = (ushort)(num << 8);
			num = (ushort)(num | reader.ReadByte());
			return (short)num;
		}
		sbyte b2 = 1;
		if (b == 250)
		{
			b2 = -1;
			b = reader.ReadByte();
		}
		return (short)(b switch
		{
			byte.MaxValue => (short)(reader.ReadByte() + 250), 
			254 => (short)(reader.ReadByte() + 500), 
			_ => b, 
		} * b2);
	}
}
