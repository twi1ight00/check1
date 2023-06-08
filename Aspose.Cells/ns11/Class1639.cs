namespace ns11;

internal class Class1639
{
	private Class1639()
	{
	}

	public static Class1642 smethod_0(Enum220 enum220_0, Enum222 enum222_0)
	{
		Class1642 result = null;
		if (enum220_0 == Enum220.const_1)
		{
			result = smethod_5(enum222_0);
		}
		return result;
	}

	public static Enum223 smethod_1(Class1642 class1642_0, Enum221 enum221_0, byte[] byte_0, uint uint_0, byte[] byte_1, uint uint_1)
	{
		if (class1642_0 == null)
		{
			return Enum223.const_1;
		}
		return smethod_6(class1642_0, enum221_0, byte_0, uint_0, byte_1, uint_1);
	}

	public static Enum223 smethod_2(Class1642 class1642_0, Enum221 enum221_0, byte[] byte_0, uint uint_0, byte[] byte_1, uint uint_1)
	{
		if (class1642_0 == null)
		{
			return Enum223.const_1;
		}
		return smethod_7(class1642_0, enum221_0, byte_0, uint_0, byte_1, uint_1);
	}

	public static Enum223 smethod_3(Class1642 class1642_0, byte[] byte_0, uint uint_0, uint uint_1, byte[] byte_1, uint uint_2, uint uint_3)
	{
		if (class1642_0 == null)
		{
			return Enum223.const_1;
		}
		return smethod_10(class1642_0, byte_0, uint_0, uint_1, byte_1, uint_2, uint_3);
	}

	public static Enum223 smethod_4(Class1642 class1642_0, byte[] byte_0, uint uint_0, uint uint_1, byte[] byte_1, uint uint_2, uint uint_3)
	{
		if (class1642_0 == null)
		{
			return Enum223.const_1;
		}
		return smethod_12(class1642_0, byte_0, uint_0, uint_1, byte_1, uint_2, uint_3);
	}

	private static Class1642 smethod_5(Enum222 enum222_0)
	{
		Class1642 @class = null;
		if (enum222_0 != Enum222.const_2)
		{
			return null;
		}
		@class = new Class1642();
		@class.class1641_0.enum220_0 = Enum220.const_1;
		@class.class1641_0.enum221_0 = Enum221.const_3;
		@class.class1641_0.enum222_0 = Enum222.const_2;
		return @class;
	}

	private static Enum223 smethod_6(Class1642 class1642_0, Enum221 enum221_0, byte[] byte_0, uint uint_0, byte[] byte_1, uint uint_1)
	{
		if (class1642_0 != null && byte_0 != null)
		{
			if (class1642_0.class1641_0.enum220_0 != Enum220.const_1)
			{
				return Enum223.const_2;
			}
			if (enum221_0 != Enum221.const_3)
			{
				class1642_0.class1641_0.enum221_0 = enum221_0;
				return smethod_9(class1642_0.class1640_0, byte_0, uint_0, byte_1, uint_1);
			}
			return Enum223.const_3;
		}
		return Enum223.const_1;
	}

	private static Enum223 smethod_7(Class1642 class1642_0, Enum221 enum221_0, byte[] byte_0, uint uint_0, byte[] byte_1, uint uint_1)
	{
		if (class1642_0 != null && byte_0 != null)
		{
			if (class1642_0.class1641_0.enum220_0 != Enum220.const_1)
			{
				return Enum223.const_2;
			}
			if (enum221_0 != Enum221.const_3)
			{
				class1642_0.class1641_0.enum221_0 = enum221_0;
				return smethod_8(class1642_0.class1640_0, byte_0, uint_0, byte_1, uint_1);
			}
			return Enum223.const_3;
		}
		return Enum223.const_1;
	}

	private static Enum223 smethod_8(Class1640 class1640_0, byte[] byte_0, uint uint_0, byte[] byte_1, uint uint_1)
	{
		uint[] uint_2 = class1640_0.uint_0;
		for (uint num = 0u; num < 256; num++)
		{
			uint_2[num] = num;
		}
		byte b = 0;
		for (uint num = 0u; num < 256; num += 16)
		{
			for (uint num2 = 0u; num2 < 16; num2++)
			{
				b = (byte)(b + (byte)((uint_2[num + num2] + byte_0[num2]) % 256u));
				byte b2 = (byte)uint_2[num + num2];
				uint_2[num + num2] = uint_2[b];
				uint_2[b] = b2;
			}
		}
		class1640_0.uint_1 = 0u;
		class1640_0.uint_2 = 0u;
		return Enum223.const_0;
	}

	private static Enum223 smethod_9(Class1640 class1640_0, byte[] byte_0, uint uint_0, byte[] byte_1, uint uint_1)
	{
		uint[] array = new uint[256];
		uint[] uint_2 = class1640_0.uint_0;
		uint num;
		for (num = 0u; num < 256; num++)
		{
			uint_2[num] = num;
		}
		uint num2 = 0u;
		uint num3;
		for (num3 = 256u; num3 > uint_0; num3 -= uint_0)
		{
			for (uint num4 = 0u; num4 < uint_0; num4++)
			{
				array[num2 + num4] = byte_0[num4];
			}
			num2 += uint_0;
		}
		for (uint num4 = 0u; num4 < num3; num4++)
		{
			array[num2 + num4] = byte_0[num4];
		}
		num = 0u;
		uint num5 = 0u;
		for (; num < 256; num++)
		{
			num5 = (num5 + uint_2[num] + array[num]) % 256u;
			uint num6 = uint_2[num];
			uint_2[num] = uint_2[num5];
			uint_2[num5] = num6;
		}
		class1640_0.uint_1 = 0u;
		class1640_0.uint_2 = 0u;
		return Enum223.const_0;
	}

	private static Enum223 smethod_10(Class1642 class1642_0, byte[] byte_0, uint uint_0, uint uint_1, byte[] byte_1, uint uint_2, uint uint_3)
	{
		if (class1642_0 == null)
		{
			return Enum223.const_1;
		}
		if (class1642_0.class1641_0.enum220_0 != Enum220.const_1)
		{
			return Enum223.const_2;
		}
		if (class1642_0.class1641_0.enum221_0 == Enum221.const_3)
		{
			return Enum223.const_3;
		}
		return smethod_11(class1642_0.class1640_0, byte_0, uint_0, uint_1, byte_1, uint_2, uint_3);
	}

	private static Enum223 smethod_11(Class1640 class1640_0, byte[] byte_0, uint uint_0, uint uint_1, byte[] byte_1, uint uint_2, uint uint_3)
	{
		if (byte_0 != null && byte_1 != null)
		{
			if (0 < uint_1 && uint_1 <= uint_3)
			{
				uint[] uint_4 = class1640_0.uint_0;
				for (uint num = 0u; num < uint_1; num++)
				{
					uint uint_5 = class1640_0.uint_1;
					uint uint_6 = class1640_0.uint_2;
					uint_5 = (uint_5 + 1) % 256u;
					uint_6 = (uint_6 + uint_4[uint_5]) % 256u;
					class1640_0.uint_1 = uint_5;
					class1640_0.uint_2 = uint_6;
					uint num2 = uint_4[uint_5];
					uint_4[uint_5] = uint_4[uint_6];
					uint_4[uint_6] = num2;
					num2 = (uint_4[uint_5] + uint_4[uint_6]) % 256u;
					byte_1[uint_2 + num] = (byte)(byte_0[uint_0 + num] ^ (byte)(uint_4[num2] & 0xFFu));
				}
				return Enum223.const_0;
			}
			return Enum223.const_5;
		}
		return Enum223.const_1;
	}

	private static Enum223 smethod_12(Class1642 class1642_0, byte[] byte_0, uint uint_0, uint uint_1, byte[] byte_1, uint uint_2, uint uint_3)
	{
		if (class1642_0 == null)
		{
			return Enum223.const_1;
		}
		if (class1642_0.class1641_0.enum220_0 != Enum220.const_1)
		{
			return Enum223.const_2;
		}
		if (class1642_0.class1641_0.enum221_0 == Enum221.const_3)
		{
			return Enum223.const_3;
		}
		return smethod_11(class1642_0.class1640_0, byte_0, uint_0, uint_1, byte_1, uint_2, uint_3);
	}
}
