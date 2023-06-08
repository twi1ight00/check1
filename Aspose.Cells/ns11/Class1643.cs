namespace ns11;

internal class Class1643
{
	private Class1643()
	{
	}

	public static Class1646 smethod_0(Enum224 enum224_0)
	{
		Class1646 result = null;
		if (enum224_0 == Enum224.const_0)
		{
			result = smethod_4();
		}
		return result;
	}

	public static Enum225 smethod_1(Class1646 class1646_0, byte[] byte_0, uint uint_0, uint uint_1)
	{
		uint num = uint_0;
		if (class1646_0 != null && byte_0 != null)
		{
			if (class1646_0.class1644_0.enum224_0 != 0)
			{
				return Enum225.const_2;
			}
			if (uint_1 == 0)
			{
				return Enum225.const_0;
			}
			Class1645 class1645_ = class1646_0.class1645_0;
			uint num2 = class1645_.uint_6 + (uint_1 << 3);
			if (num2 < class1645_.uint_6)
			{
				class1645_.uint_7++;
			}
			class1645_.uint_7 += uint_1 >> 29;
			class1645_.uint_6 = num2;
			if (class1645_.uint_0 != 0)
			{
				uint uint_2 = class1645_.uint_0;
				uint num3 = 64 - class1645_.uint_0;
				if (uint_1 < num3)
				{
					Class1649.smethod_0(class1645_.uint_1, uint_2, byte_0, num, uint_1);
					class1645_.uint_0 += uint_1;
					return Enum225.const_0;
				}
				Class1649.smethod_0(class1645_.uint_1, uint_2, byte_0, num, num3);
				num += num3;
				uint_1 -= num3;
				smethod_3(class1645_);
				class1645_.uint_0 = 0u;
			}
			while (uint_1 >= 64)
			{
				Class1649.smethod_0(class1645_.uint_1, 0u, byte_0, num, 64u);
				num += 64;
				uint_1 -= 64;
				smethod_3(class1645_);
			}
			Class1649.smethod_0(class1645_.uint_1, 0u, byte_0, num, uint_1);
			class1645_.uint_0 = uint_1;
			return Enum225.const_0;
		}
		return Enum225.const_1;
	}

	public static Enum225 smethod_2(Class1646 class1646_0, byte[] byte_0, uint uint_0)
	{
		uint uint_ = 0u;
		if (class1646_0 != null && byte_0 != null)
		{
			if (class1646_0.class1644_0.enum224_0 != 0)
			{
				return Enum225.const_2;
			}
			if (class1646_0.class1644_0.uint_0 > uint_0)
			{
				return Enum225.const_3;
			}
			Class1645 class1645_ = class1646_0.class1645_0;
			smethod_15(class1645_.uint_2, byte_0, ref uint_);
			smethod_15(class1645_.uint_3, byte_0, ref uint_);
			smethod_15(class1645_.uint_4, byte_0, ref uint_);
			smethod_15(class1645_.uint_5, byte_0, ref uint_);
			smethod_5(class1645_);
			return Enum225.const_0;
		}
		return Enum225.const_1;
	}

	private static void smethod_3(Class1645 class1645_0)
	{
		uint uint_ = class1645_0.uint_2;
		uint uint_2 = class1645_0.uint_3;
		uint uint_3 = class1645_0.uint_4;
		uint uint_4 = class1645_0.uint_5;
		uint[] uint_5 = class1645_0.uint_1;
		smethod_11(ref uint_, ref uint_2, ref uint_3, ref uint_4, ref uint_5[0], 7, 3614090360L);
		smethod_11(ref uint_4, ref uint_, ref uint_2, ref uint_3, ref uint_5[1], 12, 3905402710L);
		smethod_11(ref uint_3, ref uint_4, ref uint_, ref uint_2, ref uint_5[2], 17, 606105819L);
		smethod_11(ref uint_2, ref uint_3, ref uint_4, ref uint_, ref uint_5[3], 22, 3250441966L);
		smethod_11(ref uint_, ref uint_2, ref uint_3, ref uint_4, ref uint_5[4], 7, 4118548399L);
		smethod_11(ref uint_4, ref uint_, ref uint_2, ref uint_3, ref uint_5[5], 12, 1200080426L);
		smethod_11(ref uint_3, ref uint_4, ref uint_, ref uint_2, ref uint_5[6], 17, 2821735955L);
		smethod_11(ref uint_2, ref uint_3, ref uint_4, ref uint_, ref uint_5[7], 22, 4249261313L);
		smethod_11(ref uint_, ref uint_2, ref uint_3, ref uint_4, ref uint_5[8], 7, 1770035416L);
		smethod_11(ref uint_4, ref uint_, ref uint_2, ref uint_3, ref uint_5[9], 12, 2336552879L);
		smethod_11(ref uint_3, ref uint_4, ref uint_, ref uint_2, ref uint_5[10], 17, 4294925233L);
		smethod_11(ref uint_2, ref uint_3, ref uint_4, ref uint_, ref uint_5[11], 22, 2304563134L);
		smethod_11(ref uint_, ref uint_2, ref uint_3, ref uint_4, ref uint_5[12], 7, 1804603682L);
		smethod_11(ref uint_4, ref uint_, ref uint_2, ref uint_3, ref uint_5[13], 12, 4254626195L);
		smethod_11(ref uint_3, ref uint_4, ref uint_, ref uint_2, ref uint_5[14], 17, 2792965006L);
		smethod_11(ref uint_2, ref uint_3, ref uint_4, ref uint_, ref uint_5[15], 22, 1236535329L);
		smethod_12(ref uint_, ref uint_2, ref uint_3, ref uint_4, ref uint_5[1], 5, 4129170786L);
		smethod_12(ref uint_4, ref uint_, ref uint_2, ref uint_3, ref uint_5[6], 9, 3225465664L);
		smethod_12(ref uint_3, ref uint_4, ref uint_, ref uint_2, ref uint_5[11], 14, 643717713L);
		smethod_12(ref uint_2, ref uint_3, ref uint_4, ref uint_, ref uint_5[0], 20, 3921069994L);
		smethod_12(ref uint_, ref uint_2, ref uint_3, ref uint_4, ref uint_5[5], 5, 3593408605L);
		smethod_12(ref uint_4, ref uint_, ref uint_2, ref uint_3, ref uint_5[10], 9, 38016083L);
		smethod_12(ref uint_3, ref uint_4, ref uint_, ref uint_2, ref uint_5[15], 14, 3634488961L);
		smethod_12(ref uint_2, ref uint_3, ref uint_4, ref uint_, ref uint_5[4], 20, 3889429448L);
		smethod_12(ref uint_, ref uint_2, ref uint_3, ref uint_4, ref uint_5[9], 5, 568446438L);
		smethod_12(ref uint_4, ref uint_, ref uint_2, ref uint_3, ref uint_5[14], 9, 3275163606L);
		smethod_12(ref uint_3, ref uint_4, ref uint_, ref uint_2, ref uint_5[3], 14, 4107603335L);
		smethod_12(ref uint_2, ref uint_3, ref uint_4, ref uint_, ref uint_5[8], 20, 1163531501L);
		smethod_12(ref uint_, ref uint_2, ref uint_3, ref uint_4, ref uint_5[13], 5, 2850285829L);
		smethod_12(ref uint_4, ref uint_, ref uint_2, ref uint_3, ref uint_5[2], 9, 4243563512L);
		smethod_12(ref uint_3, ref uint_4, ref uint_, ref uint_2, ref uint_5[7], 14, 1735328473L);
		smethod_12(ref uint_2, ref uint_3, ref uint_4, ref uint_, ref uint_5[12], 20, 2368359562L);
		smethod_13(ref uint_, ref uint_2, ref uint_3, ref uint_4, ref uint_5[5], 4, 4294588738L);
		smethod_13(ref uint_4, ref uint_, ref uint_2, ref uint_3, ref uint_5[8], 11, 2272392833L);
		smethod_13(ref uint_3, ref uint_4, ref uint_, ref uint_2, ref uint_5[11], 16, 1839030562L);
		smethod_13(ref uint_2, ref uint_3, ref uint_4, ref uint_, ref uint_5[14], 23, 4259657740L);
		smethod_13(ref uint_, ref uint_2, ref uint_3, ref uint_4, ref uint_5[1], 4, 2763975236L);
		smethod_13(ref uint_4, ref uint_, ref uint_2, ref uint_3, ref uint_5[4], 11, 1272893353L);
		smethod_13(ref uint_3, ref uint_4, ref uint_, ref uint_2, ref uint_5[7], 16, 4139469664L);
		smethod_13(ref uint_2, ref uint_3, ref uint_4, ref uint_, ref uint_5[10], 23, 3200236656L);
		smethod_13(ref uint_, ref uint_2, ref uint_3, ref uint_4, ref uint_5[13], 4, 681279174L);
		smethod_13(ref uint_4, ref uint_, ref uint_2, ref uint_3, ref uint_5[0], 11, 3936430074L);
		smethod_13(ref uint_3, ref uint_4, ref uint_, ref uint_2, ref uint_5[3], 16, 3572445317L);
		smethod_13(ref uint_2, ref uint_3, ref uint_4, ref uint_, ref uint_5[6], 23, 76029189L);
		smethod_13(ref uint_, ref uint_2, ref uint_3, ref uint_4, ref uint_5[9], 4, 3654602809L);
		smethod_13(ref uint_4, ref uint_, ref uint_2, ref uint_3, ref uint_5[12], 11, 3873151461L);
		smethod_13(ref uint_3, ref uint_4, ref uint_, ref uint_2, ref uint_5[15], 16, 530742520L);
		smethod_13(ref uint_2, ref uint_3, ref uint_4, ref uint_, ref uint_5[2], 23, 3299628645L);
		smethod_14(ref uint_, ref uint_2, ref uint_3, ref uint_4, ref uint_5[0], 6, 4096336452L);
		smethod_14(ref uint_4, ref uint_, ref uint_2, ref uint_3, ref uint_5[7], 10, 1126891415L);
		smethod_14(ref uint_3, ref uint_4, ref uint_, ref uint_2, ref uint_5[14], 15, 2878612391L);
		smethod_14(ref uint_2, ref uint_3, ref uint_4, ref uint_, ref uint_5[5], 21, 4237533241L);
		smethod_14(ref uint_, ref uint_2, ref uint_3, ref uint_4, ref uint_5[12], 6, 1700485571L);
		smethod_14(ref uint_4, ref uint_, ref uint_2, ref uint_3, ref uint_5[3], 10, 2399980690L);
		smethod_14(ref uint_3, ref uint_4, ref uint_, ref uint_2, ref uint_5[10], 15, 4293915773L);
		smethod_14(ref uint_2, ref uint_3, ref uint_4, ref uint_, ref uint_5[1], 21, 2240044497L);
		smethod_14(ref uint_, ref uint_2, ref uint_3, ref uint_4, ref uint_5[8], 6, 1873313359L);
		smethod_14(ref uint_4, ref uint_, ref uint_2, ref uint_3, ref uint_5[15], 10, 4264355552L);
		smethod_14(ref uint_3, ref uint_4, ref uint_, ref uint_2, ref uint_5[6], 15, 2734768916L);
		smethod_14(ref uint_2, ref uint_3, ref uint_4, ref uint_, ref uint_5[13], 21, 1309151649L);
		smethod_14(ref uint_, ref uint_2, ref uint_3, ref uint_4, ref uint_5[4], 6, 4149444226L);
		smethod_14(ref uint_4, ref uint_, ref uint_2, ref uint_3, ref uint_5[11], 10, 3174756917L);
		smethod_14(ref uint_3, ref uint_4, ref uint_, ref uint_2, ref uint_5[2], 15, 718787259L);
		smethod_14(ref uint_2, ref uint_3, ref uint_4, ref uint_, ref uint_5[9], 21, 3951481745L);
		class1645_0.uint_2 += uint_;
		class1645_0.uint_3 += uint_2;
		class1645_0.uint_4 += uint_3;
		class1645_0.uint_5 += uint_4;
	}

	private static Class1646 smethod_4()
	{
		Class1646 @class = new Class1646();
		@class.class1644_0.enum224_0 = Enum224.const_0;
		@class.class1644_0.uint_0 = 16u;
		smethod_5(@class.class1645_0);
		return @class;
	}

	private static void smethod_5(Class1645 class1645_0)
	{
		class1645_0.uint_2 = 1732584193u;
		class1645_0.uint_3 = 4023233417u;
		class1645_0.uint_4 = 2562383102u;
		class1645_0.uint_5 = 271733878u;
	}

	private static uint smethod_6(uint uint_0, uint uint_1, uint uint_2)
	{
		return ((uint_1 ^ uint_2) & uint_0) ^ uint_2;
	}

	private static uint smethod_7(uint uint_0, uint uint_1, uint uint_2)
	{
		return ((uint_0 ^ uint_1) & uint_2) ^ uint_1;
	}

	private static uint smethod_8(uint uint_0, uint uint_1, uint uint_2)
	{
		return uint_0 ^ uint_1 ^ uint_2;
	}

	private static uint smethod_9(uint uint_0, uint uint_1, uint uint_2)
	{
		return (uint_0 | ~uint_2) ^ uint_1;
	}

	private static uint smethod_10(uint uint_0, int int_0)
	{
		return (uint_0 << int_0) | (uint_0 >> 32 - int_0);
	}

	private static void smethod_11(ref uint uint_0, ref uint uint_1, ref uint uint_2, ref uint uint_3, ref uint uint_4, int int_0, long long_0)
	{
		uint_0 += (uint)(int)(uint_4 + long_0 + smethod_6(uint_1, uint_2, uint_3));
		uint_0 = smethod_10(uint_0, int_0);
		uint_0 += uint_1;
	}

	private static void smethod_12(ref uint uint_0, ref uint uint_1, ref uint uint_2, ref uint uint_3, ref uint uint_4, int int_0, long long_0)
	{
		uint_0 += (uint)(int)(uint_4 + long_0 + smethod_7(uint_1, uint_2, uint_3));
		uint_0 = smethod_10(uint_0, int_0);
		uint_0 += uint_1;
	}

	private static void smethod_13(ref uint uint_0, ref uint uint_1, ref uint uint_2, ref uint uint_3, ref uint uint_4, int int_0, long long_0)
	{
		uint_0 += (uint)(int)(uint_4 + long_0 + smethod_8(uint_1, uint_2, uint_3));
		uint_0 = smethod_10(uint_0, int_0);
		uint_0 += uint_1;
	}

	private static void smethod_14(ref uint uint_0, ref uint uint_1, ref uint uint_2, ref uint uint_3, ref uint uint_4, int int_0, long long_0)
	{
		uint_0 += (uint)(int)(uint_4 + long_0 + smethod_9(uint_1, uint_2, uint_3));
		uint_0 = smethod_10(uint_0, int_0);
		uint_0 += uint_1;
	}

	private static void smethod_15(uint uint_0, byte[] byte_0, ref uint uint_1)
	{
		byte_0[uint_1++] = (byte)(uint_0 & 0xFFu);
		byte_0[uint_1++] = (byte)((uint_0 >> 8) & 0xFFu);
		byte_0[uint_1++] = (byte)((uint_0 >> 16) & 0xFFu);
		byte_0[uint_1++] = (byte)((uint_0 >> 24) & 0xFFu);
	}
}
