using System;
using System.Runtime.CompilerServices;

namespace ns50;

internal class Class1128
{
	internal enum Enum173
	{
		const_0 = -1,
		const_1,
		const_2
	}

	internal class Class1129
	{
		private Class1128 class1128_0;

		private Class1128 class1128_1;

		internal Class1129(Class1128 modulus)
		{
			class1128_0 = modulus;
			uint num = class1128_0.uint_1 << 1;
			class1128_1 = new Class1128(Enum173.const_2, num + 1);
			class1128_1.uint_2[num] = 1u;
			class1128_1 = smethod_10(class1128_1, class1128_0);
		}

		internal void method_0(Class1128 x)
		{
			Class1128 @class = class1128_0;
			uint uint_ = @class.uint_1;
			uint num = uint_ + 1;
			uint num2 = uint_ - 1;
			if (x.uint_1 >= uint_)
			{
				if (x.uint_2.Length < x.uint_1)
				{
					throw new IndexOutOfRangeException("x out of range");
				}
				Class1128 class2 = new Class1128(Enum173.const_2, x.uint_1 - num2 + class1128_1.uint_1);
				Class1131.smethod_12(x.uint_2, num2, x.uint_1 - num2, class1128_1.uint_2, 0u, class1128_1.uint_1, class2.uint_2, 0u);
				uint uint_2 = ((x.uint_1 > num) ? num : x.uint_1);
				x.uint_1 = uint_2;
				x.method_8();
				Class1128 class3 = new Class1128(Enum173.const_2, num);
				Class1131.smethod_13(class2.uint_2, (int)num, (int)(class2.uint_1 - num), @class.uint_2, 0, (int)@class.uint_1, class3.uint_2, 0, (int)num);
				class3.method_8();
				if (smethod_26(class3, x))
				{
					Class1131.smethod_2(x, class3);
				}
				else
				{
					Class1128 class4 = new Class1128(Enum173.const_2, num + 1);
					class4.uint_2[num] = 1u;
					Class1131.smethod_2(class4, class3);
					Class1131.smethod_3(x, class4);
				}
				while (smethod_25(x, @class))
				{
					Class1131.smethod_2(x, @class);
				}
			}
		}

		internal Class1128 method_1(Class1128 a, Class1128 b)
		{
			if (!(a == 0u) && !(b == 0u))
			{
				if (a.uint_1 >= class1128_0.uint_1 << 1)
				{
					a = smethod_8(a, class1128_0);
				}
				if (b.uint_1 >= class1128_0.uint_1 << 1)
				{
					b = smethod_8(b, class1128_0);
				}
				if (a.uint_1 >= class1128_0.uint_1)
				{
					method_0(a);
				}
				if (b.uint_1 >= class1128_0.uint_1)
				{
					method_0(b);
				}
				Class1128 @class = new Class1128(smethod_11(a, b));
				method_0(@class);
				return @class;
			}
			return smethod_1(0);
		}

		internal Class1128 method_2(Class1128 a, Class1128 b)
		{
			Enum173 @enum = Class1131.Compare(a, b);
			Class1128 @class;
			switch (@enum)
			{
			default:
				throw new Exception();
			case Enum173.const_0:
				@class = smethod_5(b, a);
				break;
			case Enum173.const_1:
				return smethod_1(0);
			case Enum173.const_2:
				@class = smethod_5(a, b);
				break;
			}
			if (smethod_25(@class, class1128_0))
			{
				if (@class.uint_1 >= class1128_0.uint_1 << 1)
				{
					@class = smethod_8(@class, class1128_0);
				}
				else
				{
					method_0(@class);
				}
			}
			if (@enum == Enum173.const_0)
			{
				@class = smethod_5(class1128_0, @class);
			}
			return @class;
		}

		internal Class1128 method_3(Class1128 b, Class1128 exp)
		{
			if ((class1128_0.uint_2[0] & 1) == 1)
			{
				return method_5(b, exp);
			}
			return method_4(b, exp);
		}

		internal Class1128 method_4(Class1128 b, Class1128 exp)
		{
			Class1128 @class = new Class1128(smethod_1(1), class1128_0.uint_1 << 1);
			Class1128 class2 = new Class1128(smethod_8(b, class1128_0), class1128_0.uint_1 << 1);
			uint num = (uint)exp.method_0();
			uint[] wkSpace = new uint[class1128_0.uint_1 << 1];
			uint num2 = 0u;
			while (true)
			{
				if (num2 < num)
				{
					if (exp.method_1(num2))
					{
						Array.Clear(wkSpace, 0, wkSpace.Length);
						Class1131.smethod_12(@class.uint_2, 0u, @class.uint_1, class2.uint_2, 0u, class2.uint_1, wkSpace, 0u);
						@class.uint_1 += class2.uint_1;
						uint[] uint_ = wkSpace;
						wkSpace = @class.uint_2;
						@class.uint_2 = uint_;
						method_0(@class);
					}
					Class1131.smethod_14(class2, ref wkSpace);
					method_0(class2);
					if (class2 == 1u)
					{
						break;
					}
					num2++;
					continue;
				}
				return @class;
			}
			return @class;
		}

		private Class1128 method_5(Class1128 b, Class1128 exp)
		{
			Class1128 @class = new Class1128(Class1130.smethod_1(smethod_1(1), class1128_0), class1128_0.uint_1 << 1);
			Class1128 class2 = new Class1128(Class1130.smethod_1(b, class1128_0), class1128_0.uint_1 << 1);
			uint mPrime = Class1130.smethod_0(class1128_0.uint_2[0]);
			uint num = (uint)exp.method_0();
			uint[] wkSpace = new uint[class1128_0.uint_1 << 1];
			for (uint num2 = 0u; num2 < num; num2++)
			{
				if (exp.method_1(num2))
				{
					Array.Clear(wkSpace, 0, wkSpace.Length);
					Class1131.smethod_12(@class.uint_2, 0u, @class.uint_1, class2.uint_2, 0u, class2.uint_1, wkSpace, 0u);
					@class.uint_1 += class2.uint_1;
					uint[] uint_ = wkSpace;
					wkSpace = @class.uint_2;
					@class.uint_2 = uint_;
					Class1130.smethod_2(@class, class1128_0, mPrime);
				}
				Class1131.smethod_14(class2, ref wkSpace);
				Class1130.smethod_2(class2, class1128_0, mPrime);
			}
			Class1130.smethod_2(@class, class1128_0, mPrime);
			return @class;
		}

		internal Class1128 method_6(uint b, Class1128 exp)
		{
			if ((class1128_0.uint_2[0] & 1) == 1)
			{
				return method_7(b, exp);
			}
			return method_8(b, exp);
		}

		private Class1128 method_7(uint b, Class1128 exp)
		{
			exp.method_8();
			uint[] wkSpace = new uint[class1128_0.uint_1 << 2];
			Class1128 bi = Class1130.smethod_1(smethod_0(b), class1128_0);
			bi = new Class1128(bi, class1128_0.uint_1 << 2);
			uint mPrime = Class1130.smethod_0(class1128_0.uint_2[0]);
			uint bitNum = (uint)(exp.method_0() - 2);
			do
			{
				Class1131.smethod_14(bi, ref wkSpace);
				bi = Class1130.smethod_2(bi, class1128_0, mPrime);
				if (!exp.method_1(bitNum))
				{
					continue;
				}
				uint[] uint_ = bi.uint_2;
				uint num = 0u;
				ulong num2 = 0uL;
				do
				{
					num2 += (ulong)((long)uint_[num] * (long)b);
					uint_[num] = (uint)num2;
					num2 >>= 32;
				}
				while (++num < bi.uint_1);
				if (bi.uint_1 < class1128_0.uint_1)
				{
					if (num2 != 0L)
					{
						uint_[num] = (uint)num2;
						bi.uint_1++;
						while (smethod_25(bi, class1128_0))
						{
							Class1131.smethod_2(bi, class1128_0);
						}
					}
				}
				else if (num2 != 0L)
				{
					uint num3 = (uint)num2;
					uint num4 = (uint)((class1128_0.uint_2[class1128_0.uint_1 - 1] >= uint.MaxValue) ? ((((ulong)num3 << 32) | uint_[num - 1]) / class1128_0.uint_2[class1128_0.uint_1 - 1]) : ((((ulong)num3 << 32) | uint_[num - 1]) / (class1128_0.uint_2[class1128_0.uint_1 - 1] + 1)));
					num = 0u;
					num2 = 0uL;
					do
					{
						num2 += (ulong)((long)class1128_0.uint_2[num] * (long)num4);
						uint num5 = uint_[num];
						uint_[num] -= (uint)(int)num2;
						num2 >>= 32;
						if (uint_[num] > num5)
						{
							num2++;
						}
						num++;
					}
					while (num < bi.uint_1);
					num3 -= (uint)(int)num2;
					if (num3 != 0)
					{
						uint num6 = 0u;
						uint num7 = 0u;
						uint[] uint_2 = class1128_0.uint_2;
						do
						{
							uint num8 = uint_2[num7];
							num6 = ((((num8 += num6) < num6) | ((uint_[num7] -= num8) > ~num8)) ? 1u : 0u);
							num7++;
						}
						while (num7 < bi.uint_1);
						num3 -= num6;
					}
					while (smethod_25(bi, class1128_0))
					{
						Class1131.smethod_2(bi, class1128_0);
					}
				}
				else
				{
					while (smethod_25(bi, class1128_0))
					{
						Class1131.smethod_2(bi, class1128_0);
					}
				}
			}
			while (bitNum-- != 0);
			return Class1130.smethod_2(bi, class1128_0, mPrime);
		}

		private Class1128 method_8(uint b, Class1128 exp)
		{
			exp.method_8();
			uint[] wkSpace = new uint[class1128_0.uint_1 << 2];
			Class1128 @class = new Class1128(smethod_0(b), class1128_0.uint_1 << 2);
			uint bitNum = (uint)(exp.method_0() - 2);
			do
			{
				Class1131.smethod_14(@class, ref wkSpace);
				if (@class.uint_1 >= class1128_0.uint_1)
				{
					method_0(@class);
				}
				if (!exp.method_1(bitNum))
				{
					continue;
				}
				uint[] uint_ = @class.uint_2;
				uint num = 0u;
				ulong num2 = 0uL;
				do
				{
					num2 += (ulong)((long)uint_[num] * (long)b);
					uint_[num] = (uint)num2;
					num2 >>= 32;
				}
				while (++num < @class.uint_1);
				if (@class.uint_1 < class1128_0.uint_1)
				{
					if (num2 != 0L)
					{
						uint_[num] = (uint)num2;
						@class.uint_1++;
						while (smethod_25(@class, class1128_0))
						{
							Class1131.smethod_2(@class, class1128_0);
						}
					}
				}
				else if (num2 != 0L)
				{
					uint num3 = (uint)num2;
					uint num4 = (uint)((((ulong)num3 << 32) | uint_[num - 1]) / (class1128_0.uint_2[class1128_0.uint_1 - 1] + 1));
					num = 0u;
					num2 = 0uL;
					do
					{
						num2 += (ulong)((long)class1128_0.uint_2[num] * (long)num4);
						uint num5 = uint_[num];
						uint_[num] -= (uint)(int)num2;
						num2 >>= 32;
						if (uint_[num] > num5)
						{
							num2++;
						}
						num++;
					}
					while (num < @class.uint_1);
					num3 -= (uint)(int)num2;
					if (num3 != 0)
					{
						uint num6 = 0u;
						uint num7 = 0u;
						uint[] uint_2 = class1128_0.uint_2;
						do
						{
							uint num8 = uint_2[num7];
							num6 = ((((num8 += num6) < num6) | ((uint_[num7] -= num8) > ~num8)) ? 1u : 0u);
							num7++;
						}
						while (num7 < @class.uint_1);
						num3 -= num6;
					}
					while (smethod_25(@class, class1128_0))
					{
						Class1131.smethod_2(@class, class1128_0);
					}
				}
				else
				{
					while (smethod_25(@class, class1128_0))
					{
						Class1131.smethod_2(@class, class1128_0);
					}
				}
			}
			while (bitNum-- != 0);
			return @class;
		}
	}

	private class Class1131
	{
		internal static Class1128 smethod_0(Class1128 bi1, Class1128 bi2)
		{
			uint num = 0u;
			uint[] uint_;
			uint uint_2;
			uint[] uint_3;
			uint uint_4;
			if (bi1.uint_1 < bi2.uint_1)
			{
				uint_ = bi2.uint_2;
				uint_2 = bi2.uint_1;
				uint_3 = bi1.uint_2;
				uint_4 = bi1.uint_1;
			}
			else
			{
				uint_ = bi1.uint_2;
				uint_2 = bi1.uint_1;
				uint_3 = bi2.uint_2;
				uint_4 = bi2.uint_1;
			}
			Class1128 @class = new Class1128(Enum173.const_2, uint_2 + 1);
			uint[] uint_5 = @class.uint_2;
			ulong num2 = 0uL;
			do
			{
				num2 = (ulong)((long)uint_[num] + (long)uint_3[num]) + num2;
				uint_5[num] = (uint)num2;
				num2 >>= 32;
			}
			while (++num < uint_4);
			bool flag;
			if (flag = num2 != 0L)
			{
				if (num < uint_2)
				{
					do
					{
						flag = (uint_5[num] = uint_[num] + 1) == 0;
					}
					while (++num < uint_2 && flag);
				}
				if (flag)
				{
					uint_5[num] = 1u;
					num = (@class.uint_1 = num + 1);
					return @class;
				}
			}
			if (num < uint_2)
			{
				do
				{
					uint_5[num] = uint_[num];
				}
				while (++num < uint_2);
			}
			@class.method_8();
			return @class;
		}

		internal static Class1128 smethod_1(Class1128 big, Class1128 small)
		{
			Class1128 @class = new Class1128(Enum173.const_2, big.uint_1);
			uint[] uint_ = @class.uint_2;
			uint[] uint_2 = big.uint_2;
			uint[] uint_3 = small.uint_2;
			uint num = 0u;
			uint num2 = 0u;
			do
			{
				uint num3 = uint_3[num];
				num2 = ((((num3 += num2) < num2) | ((uint_[num] = uint_2[num] - num3) > ~num3)) ? 1u : 0u);
			}
			while (++num < small.uint_1);
			if (big.uint_1 != num)
			{
				if (num2 == 1)
				{
					do
					{
						uint_[num] = uint_2[num] - 1;
					}
					while (uint_2[num++] == 0 && num < big.uint_1);
				}
				if (big.uint_1 != num)
				{
					do
					{
						uint_[num] = uint_2[num];
					}
					while (++num < big.uint_1);
				}
			}
			@class.method_8();
			return @class;
		}

		internal static void smethod_2(Class1128 big, Class1128 small)
		{
			uint[] uint_ = big.uint_2;
			uint[] uint_2 = small.uint_2;
			uint num = 0u;
			uint num2 = 0u;
			do
			{
				uint num3 = uint_2[num];
				num2 = ((((num3 += num2) < num2) | ((uint_[num] -= num3) > ~num3)) ? 1u : 0u);
			}
			while (++num < small.uint_1);
			if (big.uint_1 != num && num2 == 1)
			{
				do
				{
					uint_[num]--;
				}
				while (uint_[num++] == 0 && num < big.uint_1);
			}
			while (big.uint_1 != 0 && big.uint_2[big.uint_1 - 1] == 0)
			{
				big.uint_1--;
			}
			if (big.uint_1 == 0)
			{
				big.uint_1++;
			}
		}

		internal static void smethod_3(Class1128 bi1, Class1128 bi2)
		{
			uint num = 0u;
			bool flag = false;
			uint[] uint_;
			uint uint_2;
			uint[] uint_3;
			uint uint_4;
			if (bi1.uint_1 < bi2.uint_1)
			{
				flag = true;
				uint_ = bi2.uint_2;
				uint_2 = bi2.uint_1;
				uint_3 = bi1.uint_2;
				uint_4 = bi1.uint_1;
			}
			else
			{
				uint_ = bi1.uint_2;
				uint_2 = bi1.uint_1;
				uint_3 = bi2.uint_2;
				uint_4 = bi2.uint_1;
			}
			uint[] uint_5 = bi1.uint_2;
			ulong num2 = 0uL;
			do
			{
				num2 += (ulong)((long)uint_[num] + (long)uint_3[num]);
				uint_5[num] = (uint)num2;
				num2 >>= 32;
			}
			while (++num < uint_4);
			bool flag2;
			if (flag2 = num2 != 0L)
			{
				if (num < uint_2)
				{
					do
					{
						flag2 = (uint_5[num] = uint_[num] + 1) == 0;
					}
					while (++num < uint_2 && flag2);
				}
				if (flag2)
				{
					uint_5[num] = 1u;
					num = (bi1.uint_1 = num + 1);
					return;
				}
			}
			if (flag && num < uint_2 - 1)
			{
				do
				{
					uint_5[num] = uint_[num];
				}
				while (++num < uint_2);
			}
			bi1.uint_1 = uint_2 + 1;
			bi1.method_8();
		}

		internal static Enum173 Compare(Class1128 bi1, Class1128 bi2)
		{
			uint num = bi1.uint_1;
			uint num2 = bi2.uint_1;
			while (num != 0 && bi1.uint_2[num - 1] == 0)
			{
				num--;
			}
			while (num2 != 0 && bi2.uint_2[num2 - 1] == 0)
			{
				num2--;
			}
			if (num == 0 && num2 == 0)
			{
				return Enum173.const_1;
			}
			if (num < num2)
			{
				return Enum173.const_0;
			}
			if (num > num2)
			{
				return Enum173.const_2;
			}
			uint num3 = num - 1;
			while (num3 != 0 && bi1.uint_2[num3] == bi2.uint_2[num3])
			{
				num3--;
			}
			if (bi1.uint_2[num3] < bi2.uint_2[num3])
			{
				return Enum173.const_0;
			}
			if (bi1.uint_2[num3] > bi2.uint_2[num3])
			{
				return Enum173.const_2;
			}
			return Enum173.const_1;
		}

		internal static uint smethod_4(Class1128 n, uint d)
		{
			ulong num = 0uL;
			uint uint_ = n.uint_1;
			while (uint_-- != 0)
			{
				num <<= 32;
				num |= n.uint_2[uint_];
				n.uint_2[uint_] = (uint)(num / d);
				num %= d;
			}
			n.method_8();
			return (uint)num;
		}

		internal static uint smethod_5(Class1128 n, uint d)
		{
			ulong num = 0uL;
			uint uint_ = n.uint_1;
			while (uint_-- != 0)
			{
				num <<= 32;
				num |= n.uint_2[uint_];
				num %= d;
			}
			return (uint)num;
		}

		internal static Class1128 smethod_6(Class1128 n, uint d)
		{
			Class1128 @class = new Class1128(Enum173.const_2, n.uint_1);
			ulong num = 0uL;
			uint uint_ = n.uint_1;
			while (uint_-- != 0)
			{
				num <<= 32;
				num |= n.uint_2[uint_];
				@class.uint_2[uint_] = (uint)(num / d);
				num %= d;
			}
			@class.method_8();
			return @class;
		}

		internal static Class1128[] smethod_7(Class1128 n, uint d)
		{
			Class1128 @class = new Class1128(Enum173.const_2, n.uint_1);
			ulong num = 0uL;
			uint uint_ = n.uint_1;
			while (uint_-- != 0)
			{
				num <<= 32;
				num |= n.uint_2[uint_];
				@class.uint_2[uint_] = (uint)(num / d);
				num %= d;
			}
			@class.method_8();
			Class1128 class2 = Class1128.smethod_0((uint)num);
			return new Class1128[2] { @class, class2 };
		}

		internal static Class1128[] smethod_8(Class1128 bi1, Class1128 bi2)
		{
			if (Compare(bi1, bi2) == Enum173.const_0)
			{
				return new Class1128[2]
				{
					Class1128.smethod_1(0),
					new Class1128(bi1)
				};
			}
			bi1.method_8();
			bi2.method_8();
			if (bi2.uint_1 == 1)
			{
				return smethod_7(bi1, bi2.uint_2[0]);
			}
			uint num = bi1.uint_1 + 1;
			int num2 = (int)(bi2.uint_1 + 1);
			uint num3 = 2147483648u;
			uint num4 = bi2.uint_2[bi2.uint_1 - 1];
			int num5 = 0;
			int num6 = (int)(bi1.uint_1 - bi2.uint_1);
			while (num3 != 0 && (num4 & num3) == 0)
			{
				num5++;
				num3 >>= 1;
			}
			Class1128 @class = new Class1128(Enum173.const_2, bi1.uint_1 - bi2.uint_1 + 1);
			Class1128 class2 = Class1128.smethod_13(bi1, num5);
			uint[] uint_ = class2.uint_2;
			bi2 = Class1128.smethod_13(bi2, num5);
			int num7 = (int)(num - bi2.uint_1);
			int num8 = (int)(num - 1);
			uint num9 = bi2.uint_2[bi2.uint_1 - 1];
			ulong num10 = bi2.uint_2[bi2.uint_1 - 2];
			while (num7 > 0)
			{
				ulong num11 = ((ulong)uint_[num8] << 32) + uint_[num8 - 1];
				ulong num12 = num11 / num9;
				ulong num13 = num11 % num9;
				while (num12 == 4294967296L || num12 * num10 > (num13 << 32) + uint_[num8 - 2])
				{
					num12--;
					num13 += num9;
					if (num13 >= 4294967296L)
					{
						break;
					}
				}
				uint num14 = 0u;
				int num15 = num8 - num2 + 1;
				ulong num16 = 0uL;
				uint num17 = (uint)num12;
				do
				{
					num16 += (ulong)((long)bi2.uint_2[num14] * (long)num17);
					uint num18 = uint_[num15];
					uint_[num15] -= (uint)(int)num16;
					num16 >>= 32;
					if (uint_[num15] > num18)
					{
						num16++;
					}
					num14++;
					num15++;
				}
				while (num14 < num2);
				num15 = num8 - num2 + 1;
				num14 = 0u;
				if (num16 != 0L)
				{
					num17--;
					ulong num19 = 0uL;
					do
					{
						num19 = (ulong)((long)uint_[num15] + (long)bi2.uint_2[num14]) + num19;
						uint_[num15] = (uint)num19;
						num19 >>= 32;
						num14++;
						num15++;
					}
					while (num14 < num2);
				}
				@class.uint_2[num6--] = num17;
				num8--;
				num7--;
			}
			@class.method_8();
			class2.method_8();
			Class1128[] array = new Class1128[2] { @class, class2 };
			if (num5 != 0)
			{
				Class1128[] array2;
				(array2 = array)[1] = Class1128.smethod_14(array2[1], num5);
			}
			return array;
		}

		internal static Class1128 smethod_9(Class1128 bi, int n)
		{
			if (n == 0)
			{
				return new Class1128(bi, bi.uint_1 + 1);
			}
			int num = n >> 5;
			n &= 0x1F;
			Class1128 @class = new Class1128(Enum173.const_2, bi.uint_1 + 1 + (uint)num);
			uint num2 = 0u;
			uint uint_ = bi.uint_1;
			if (n != 0)
			{
				uint num3 = 0u;
				for (; num2 < uint_; num2++)
				{
					uint num4 = bi.uint_2[num2];
					@class.uint_2[num2 + num] = (num4 << n) | num3;
					num3 = num4 >> 32 - n;
				}
				@class.uint_2[num2 + num] = num3;
			}
			else
			{
				for (; num2 < uint_; num2++)
				{
					@class.uint_2[num2 + num] = bi.uint_2[num2];
				}
			}
			@class.method_8();
			return @class;
		}

		internal static Class1128 smethod_10(Class1128 bi, int n)
		{
			if (n == 0)
			{
				return new Class1128(bi);
			}
			int num = n >> 5;
			int num2 = n & 0x1F;
			Class1128 @class = new Class1128(Enum173.const_2, (uint)((int)bi.uint_1 - num + 1));
			uint num3 = (uint)(@class.uint_2.Length - 1);
			if (num2 != 0)
			{
				uint num4 = 0u;
				while (num3-- != 0)
				{
					uint num5 = bi.uint_2[num3 + num];
					@class.uint_2[num3] = (num5 >> n) | num4;
					num4 = num5 << 32 - n;
				}
			}
			else
			{
				while (num3-- != 0)
				{
					@class.uint_2[num3] = bi.uint_2[num3 + num];
				}
			}
			@class.method_8();
			return @class;
		}

		internal static Class1128 smethod_11(Class1128 n, uint f)
		{
			Class1128 @class = new Class1128(Enum173.const_2, n.uint_1 + 1);
			uint num = 0u;
			ulong num2 = 0uL;
			do
			{
				num2 += (ulong)((long)n.uint_2[num] * (long)f);
				@class.uint_2[num] = (uint)num2;
				num2 >>= 32;
			}
			while (++num < n.uint_1);
			@class.uint_2[num] = (uint)num2;
			@class.method_8();
			return @class;
		}

		internal static void smethod_12(uint[] x, uint xOffset, uint xLen, uint[] y, uint yOffset, uint yLen, uint[] d, uint dOffset)
		{
			uint num = xOffset;
			uint num2 = num + xLen;
			uint num3 = yOffset + yLen;
			uint num4 = dOffset;
			while (num < num2)
			{
				if (x[num] != 0)
				{
					ulong num5 = 0uL;
					uint num6 = num4;
					uint num7 = yOffset;
					while (num7 < num3)
					{
						num5 += (ulong)((long)x[num] * (long)y[num7] + d[num6]);
						d[num6] = (uint)num5;
						num5 >>= 32;
						num7++;
						num6++;
					}
					if (num5 != 0L)
					{
						d[num6] = (uint)num5;
					}
				}
				num++;
				num4++;
			}
		}

		internal static void smethod_13(uint[] x, int xOffset, int xLen, uint[] y, int yOffest, int yLen, uint[] d, int dOffset, int mod)
		{
			uint num = (uint)xOffset;
			uint num2 = num + (uint)xLen;
			uint num3 = (uint)(yOffest + yLen);
			uint num4 = (uint)dOffset;
			uint num5 = num4 + (uint)mod;
			while (num < num2)
			{
				if (x[num] != 0)
				{
					ulong num6 = 0uL;
					uint num7 = num4;
					uint num8 = (uint)yOffest;
					while (num8 < num3 && num7 < num5)
					{
						num6 += (ulong)((long)x[num] * (long)y[num8] + d[num7]);
						d[num7] = (uint)num6;
						num6 >>= 32;
						num8++;
						num7++;
					}
					if (num6 != 0L && num7 < num5)
					{
						d[num7] = (uint)num6;
					}
				}
				num++;
				num4++;
			}
		}

		internal static void smethod_14(Class1128 bi, ref uint[] wkSpace)
		{
			uint[] array = wkSpace;
			wkSpace = bi.uint_2;
			uint[] uint_ = bi.uint_2;
			uint uint_2 = bi.uint_1;
			bi.uint_2 = array;
			uint num = (uint)array.Length;
			for (uint num2 = 0u; num2 < num; num2++)
			{
				array[num2] = 0u;
			}
			uint num3 = 0u;
			uint num4 = 0u;
			uint num5 = 0u;
			while (num5 < uint_2)
			{
				if (uint_[num3] != 0)
				{
					ulong num6 = 0uL;
					uint num7 = uint_[num3];
					uint num8 = num3 + 1;
					uint num9 = num4 + 2 * num5 + 1;
					uint num10 = num5 + 1;
					while (num10 < uint_2)
					{
						num6 += (ulong)((long)num7 * (long)uint_[num8] + array[num9]);
						array[num9] = (uint)num6;
						num6 >>= 32;
						num10++;
						num9++;
						num8++;
					}
					if (num6 != 0L)
					{
						array[num9] = (uint)num6;
					}
				}
				num5++;
				num3++;
			}
			num4 = 0u;
			uint num11 = 0u;
			for (; num4 < num; num4++)
			{
				uint num12 = array[num4];
				array[num4] = (num12 << 1) | num11;
				num11 = num12 >> 31;
			}
			if (num11 != 0)
			{
				array[num4] = num11;
			}
			num3 = 0u;
			num4 = 0u;
			uint num13 = 0 + uint_2;
			while (num3 < num13)
			{
				ulong num14 = (ulong)((long)uint_[num3] * (long)uint_[num3] + array[num4]);
				array[num4] = (uint)num14;
				num14 >>= 32;
				array[++num4] += (uint)(int)num14;
				if (array[num4] < (uint)num14)
				{
					uint num15 = num4;
					array[++num15]++;
					while (array[num15++] == 0)
					{
						array[num15]++;
					}
				}
				num3++;
				num4++;
			}
			bi.uint_1 <<= 1;
			while (array[bi.uint_1 - 1] == 0 && bi.uint_1 > 1)
			{
				bi.uint_1--;
			}
		}

		internal static Class1128 smethod_15(Class1128 a, Class1128 b)
		{
			Class1128 @class = a;
			Class1128 class2 = b;
			Class1128 class3 = class2;
			while (@class.uint_1 > 1)
			{
				class3 = @class;
				@class = Class1128.smethod_8(class2, @class);
				class2 = class3;
			}
			if (@class == 0u)
			{
				return class3;
			}
			uint num = @class.uint_2[0];
			uint num2 = Class1128.smethod_7(class2, num);
			int num3 = 0;
			while (((num2 | num) & 1) == 0)
			{
				num2 >>= 1;
				num >>= 1;
				num3++;
			}
			while (num2 != 0)
			{
				while ((num2 & 1) == 0)
				{
					num2 >>= 1;
				}
				while ((num & 1) == 0)
				{
					num >>= 1;
				}
				if (num2 >= num)
				{
					num2 = num2 - num >> 1;
				}
				else
				{
					num = num - num2 >> 1;
				}
			}
			return Class1128.smethod_0(num << num3);
		}

		internal static uint smethod_16(Class1128 bi, uint modulus)
		{
			uint num = modulus;
			uint num2 = Class1128.smethod_7(bi, modulus);
			uint num3 = 0u;
			uint num4 = 1u;
			while (true)
			{
				switch (num2)
				{
				default:
					num3 += num / num2 * num4;
					num %= num2;
					switch (num)
					{
					default:
						goto IL_002b;
					case 1u:
						return modulus - num3;
					case 0u:
						break;
					}
					break;
				case 1u:
					return num4;
				case 0u:
					break;
				}
				break;
				IL_002b:
				num4 += num2 / num * num3;
				num2 %= num;
			}
			return 0u;
		}

		internal static Class1128 smethod_17(Class1128 bi, Class1128 modulus)
		{
			if (modulus.uint_1 == 1)
			{
				return Class1128.smethod_0(smethod_16(bi, modulus.uint_2[0]));
			}
			Class1128[] array = new Class1128[2]
			{
				Class1128.smethod_1(0),
				Class1128.smethod_1(1)
			};
			Class1128[] array2 = new Class1128[2];
			Class1128[] array3 = new Class1128[2]
			{
				Class1128.smethod_1(0),
				Class1128.smethod_1(0)
			};
			int num = 0;
			Class1128 bi2 = modulus;
			Class1128 @class = bi;
			Class1129 class2 = new Class1129(modulus);
			while (@class != 0u)
			{
				if (num > 1)
				{
					Class1128 class3 = class2.method_2(array[0], Class1128.smethod_11(array[1], array2[0]));
					array[0] = array[1];
					array[1] = class3;
				}
				Class1128[] array4 = smethod_8(bi2, @class);
				array2[0] = array2[1];
				array2[1] = array4[0];
				array3[0] = array3[1];
				array3[1] = array4[1];
				bi2 = @class;
				@class = array4[1];
				num++;
			}
			if (array3[0] != 1u)
			{
				throw new ArithmeticException("No inverse!");
			}
			return class2.method_2(array[0], Class1128.smethod_11(array[1], array2[0]));
		}
	}

	internal class Class1130
	{
		private Class1130()
		{
		}

		internal static uint smethod_0(uint n)
		{
			uint num = n;
			uint num2;
			while ((num2 = n * num) != 1)
			{
				num *= 2 - num2;
			}
			return (uint)(0uL - (ulong)num);
		}

		internal static Class1128 smethod_1(Class1128 n, Class1128 m)
		{
			n.method_8();
			m.method_8();
			n = smethod_13(n, (int)(m.uint_1 * 32));
			n = smethod_8(n, m);
			return n;
		}

		internal static Class1128 smethod_2(Class1128 n, Class1128 m, uint mPrime)
		{
			uint[] uint_ = n.uint_2;
			uint[] uint_2 = m.uint_2;
			for (uint num = 0u; num < m.uint_1; num++)
			{
				uint num2 = uint_[0] * mPrime;
				uint num3 = 0u;
				uint num4 = 0u;
				uint num5 = 0u;
				long num6 = num2;
				num3 = 1u;
				long num7 = num6 * uint_2[0];
				num4 = 1u;
				ulong num8 = (ulong)(num7 + uint_[0]);
				num8 >>= 32;
				uint num9;
				for (num9 = 1u; num9 < m.uint_1; num9++)
				{
					num8 += (ulong)((long)num2 * (long)uint_2[num3++] + uint_[num4++]);
					uint_[num5++] = (uint)num8;
					num8 >>= 32;
				}
				for (; num9 < n.uint_1; num9++)
				{
					num8 += uint_[num4++];
					uint_[num5++] = (uint)num8;
					num8 >>= 32;
					if (num8 == 0L)
					{
						num9++;
						break;
					}
				}
				for (; num9 < n.uint_1; num9++)
				{
					uint_[num5++] = uint_[num4++];
				}
				uint_[num5++] = (uint)num8;
			}
			while (n.uint_1 > 1 && uint_[n.uint_1 - 1] == 0)
			{
				n.uint_1--;
			}
			if (smethod_25(n, m))
			{
				Class1131.smethod_2(n, m);
			}
			return n;
		}
	}

	private const uint uint_0 = 20u;

	private const string string_0 = "Operation would return a negative value";

	private uint uint_1 = 1u;

	private uint[] uint_2;

	internal static readonly uint[] uint_3 = new uint[783]
	{
		2u, 3u, 5u, 7u, 11u, 13u, 17u, 19u, 23u, 29u,
		31u, 37u, 41u, 43u, 47u, 53u, 59u, 61u, 67u, 71u,
		73u, 79u, 83u, 89u, 97u, 101u, 103u, 107u, 109u, 113u,
		127u, 131u, 137u, 139u, 149u, 151u, 157u, 163u, 167u, 173u,
		179u, 181u, 191u, 193u, 197u, 199u, 211u, 223u, 227u, 229u,
		233u, 239u, 241u, 251u, 257u, 263u, 269u, 271u, 277u, 281u,
		283u, 293u, 307u, 311u, 313u, 317u, 331u, 337u, 347u, 349u,
		353u, 359u, 367u, 373u, 379u, 383u, 389u, 397u, 401u, 409u,
		419u, 421u, 431u, 433u, 439u, 443u, 449u, 457u, 461u, 463u,
		467u, 479u, 487u, 491u, 499u, 503u, 509u, 521u, 523u, 541u,
		547u, 557u, 563u, 569u, 571u, 577u, 587u, 593u, 599u, 601u,
		607u, 613u, 617u, 619u, 631u, 641u, 643u, 647u, 653u, 659u,
		661u, 673u, 677u, 683u, 691u, 701u, 709u, 719u, 727u, 733u,
		739u, 743u, 751u, 757u, 761u, 769u, 773u, 787u, 797u, 809u,
		811u, 821u, 823u, 827u, 829u, 839u, 853u, 857u, 859u, 863u,
		877u, 881u, 883u, 887u, 907u, 911u, 919u, 929u, 937u, 941u,
		947u, 953u, 967u, 971u, 977u, 983u, 991u, 997u, 1009u, 1013u,
		1019u, 1021u, 1031u, 1033u, 1039u, 1049u, 1051u, 1061u, 1063u, 1069u,
		1087u, 1091u, 1093u, 1097u, 1103u, 1109u, 1117u, 1123u, 1129u, 1151u,
		1153u, 1163u, 1171u, 1181u, 1187u, 1193u, 1201u, 1213u, 1217u, 1223u,
		1229u, 1231u, 1237u, 1249u, 1259u, 1277u, 1279u, 1283u, 1289u, 1291u,
		1297u, 1301u, 1303u, 1307u, 1319u, 1321u, 1327u, 1361u, 1367u, 1373u,
		1381u, 1399u, 1409u, 1423u, 1427u, 1429u, 1433u, 1439u, 1447u, 1451u,
		1453u, 1459u, 1471u, 1481u, 1483u, 1487u, 1489u, 1493u, 1499u, 1511u,
		1523u, 1531u, 1543u, 1549u, 1553u, 1559u, 1567u, 1571u, 1579u, 1583u,
		1597u, 1601u, 1607u, 1609u, 1613u, 1619u, 1621u, 1627u, 1637u, 1657u,
		1663u, 1667u, 1669u, 1693u, 1697u, 1699u, 1709u, 1721u, 1723u, 1733u,
		1741u, 1747u, 1753u, 1759u, 1777u, 1783u, 1787u, 1789u, 1801u, 1811u,
		1823u, 1831u, 1847u, 1861u, 1867u, 1871u, 1873u, 1877u, 1879u, 1889u,
		1901u, 1907u, 1913u, 1931u, 1933u, 1949u, 1951u, 1973u, 1979u, 1987u,
		1993u, 1997u, 1999u, 2003u, 2011u, 2017u, 2027u, 2029u, 2039u, 2053u,
		2063u, 2069u, 2081u, 2083u, 2087u, 2089u, 2099u, 2111u, 2113u, 2129u,
		2131u, 2137u, 2141u, 2143u, 2153u, 2161u, 2179u, 2203u, 2207u, 2213u,
		2221u, 2237u, 2239u, 2243u, 2251u, 2267u, 2269u, 2273u, 2281u, 2287u,
		2293u, 2297u, 2309u, 2311u, 2333u, 2339u, 2341u, 2347u, 2351u, 2357u,
		2371u, 2377u, 2381u, 2383u, 2389u, 2393u, 2399u, 2411u, 2417u, 2423u,
		2437u, 2441u, 2447u, 2459u, 2467u, 2473u, 2477u, 2503u, 2521u, 2531u,
		2539u, 2543u, 2549u, 2551u, 2557u, 2579u, 2591u, 2593u, 2609u, 2617u,
		2621u, 2633u, 2647u, 2657u, 2659u, 2663u, 2671u, 2677u, 2683u, 2687u,
		2689u, 2693u, 2699u, 2707u, 2711u, 2713u, 2719u, 2729u, 2731u, 2741u,
		2749u, 2753u, 2767u, 2777u, 2789u, 2791u, 2797u, 2801u, 2803u, 2819u,
		2833u, 2837u, 2843u, 2851u, 2857u, 2861u, 2879u, 2887u, 2897u, 2903u,
		2909u, 2917u, 2927u, 2939u, 2953u, 2957u, 2963u, 2969u, 2971u, 2999u,
		3001u, 3011u, 3019u, 3023u, 3037u, 3041u, 3049u, 3061u, 3067u, 3079u,
		3083u, 3089u, 3109u, 3119u, 3121u, 3137u, 3163u, 3167u, 3169u, 3181u,
		3187u, 3191u, 3203u, 3209u, 3217u, 3221u, 3229u, 3251u, 3253u, 3257u,
		3259u, 3271u, 3299u, 3301u, 3307u, 3313u, 3319u, 3323u, 3329u, 3331u,
		3343u, 3347u, 3359u, 3361u, 3371u, 3373u, 3389u, 3391u, 3407u, 3413u,
		3433u, 3449u, 3457u, 3461u, 3463u, 3467u, 3469u, 3491u, 3499u, 3511u,
		3517u, 3527u, 3529u, 3533u, 3539u, 3541u, 3547u, 3557u, 3559u, 3571u,
		3581u, 3583u, 3593u, 3607u, 3613u, 3617u, 3623u, 3631u, 3637u, 3643u,
		3659u, 3671u, 3673u, 3677u, 3691u, 3697u, 3701u, 3709u, 3719u, 3727u,
		3733u, 3739u, 3761u, 3767u, 3769u, 3779u, 3793u, 3797u, 3803u, 3821u,
		3823u, 3833u, 3847u, 3851u, 3853u, 3863u, 3877u, 3881u, 3889u, 3907u,
		3911u, 3917u, 3919u, 3923u, 3929u, 3931u, 3943u, 3947u, 3967u, 3989u,
		4001u, 4003u, 4007u, 4013u, 4019u, 4021u, 4027u, 4049u, 4051u, 4057u,
		4073u, 4079u, 4091u, 4093u, 4099u, 4111u, 4127u, 4129u, 4133u, 4139u,
		4153u, 4157u, 4159u, 4177u, 4201u, 4211u, 4217u, 4219u, 4229u, 4231u,
		4241u, 4243u, 4253u, 4259u, 4261u, 4271u, 4273u, 4283u, 4289u, 4297u,
		4327u, 4337u, 4339u, 4349u, 4357u, 4363u, 4373u, 4391u, 4397u, 4409u,
		4421u, 4423u, 4441u, 4447u, 4451u, 4457u, 4463u, 4481u, 4483u, 4493u,
		4507u, 4513u, 4517u, 4519u, 4523u, 4547u, 4549u, 4561u, 4567u, 4583u,
		4591u, 4597u, 4603u, 4621u, 4637u, 4639u, 4643u, 4649u, 4651u, 4657u,
		4663u, 4673u, 4679u, 4691u, 4703u, 4721u, 4723u, 4729u, 4733u, 4751u,
		4759u, 4783u, 4787u, 4789u, 4793u, 4799u, 4801u, 4813u, 4817u, 4831u,
		4861u, 4871u, 4877u, 4889u, 4903u, 4909u, 4919u, 4931u, 4933u, 4937u,
		4943u, 4951u, 4957u, 4967u, 4969u, 4973u, 4987u, 4993u, 4999u, 5003u,
		5009u, 5011u, 5021u, 5023u, 5039u, 5051u, 5059u, 5077u, 5081u, 5087u,
		5099u, 5101u, 5107u, 5113u, 5119u, 5147u, 5153u, 5167u, 5171u, 5179u,
		5189u, 5197u, 5209u, 5227u, 5231u, 5233u, 5237u, 5261u, 5273u, 5279u,
		5281u, 5297u, 5303u, 5309u, 5323u, 5333u, 5347u, 5351u, 5381u, 5387u,
		5393u, 5399u, 5407u, 5413u, 5417u, 5419u, 5431u, 5437u, 5441u, 5443u,
		5449u, 5471u, 5477u, 5479u, 5483u, 5501u, 5503u, 5507u, 5519u, 5521u,
		5527u, 5531u, 5557u, 5563u, 5569u, 5573u, 5581u, 5591u, 5623u, 5639u,
		5641u, 5647u, 5651u, 5653u, 5657u, 5659u, 5669u, 5683u, 5689u, 5693u,
		5701u, 5711u, 5717u, 5737u, 5741u, 5743u, 5749u, 5779u, 5783u, 5791u,
		5801u, 5807u, 5813u, 5821u, 5827u, 5839u, 5843u, 5849u, 5851u, 5857u,
		5861u, 5867u, 5869u, 5879u, 5881u, 5897u, 5903u, 5923u, 5927u, 5939u,
		5953u, 5981u, 5987u
	};

	internal Class1128()
	{
		uint_2 = new uint[20];
		uint_1 = 20u;
	}

	internal Class1128(Enum173 sign, uint len)
	{
		uint_2 = new uint[len];
		uint_1 = len;
	}

	internal Class1128(Class1128 bi)
	{
		uint_2 = (uint[])bi.uint_2.Clone();
		uint_1 = bi.uint_1;
	}

	internal Class1128(Class1128 bi, uint len)
	{
		uint_2 = new uint[len];
		for (uint num = 0u; num < bi.uint_1; num++)
		{
			uint_2[num] = bi.uint_2[num];
		}
		uint_1 = bi.uint_1;
	}

	internal Class1128(byte[] inData)
	{
		uint_1 = (uint)inData.Length >> 2;
		int num = inData.Length & 3;
		if (num != 0)
		{
			uint_1++;
		}
		uint_2 = new uint[uint_1];
		int num2 = inData.Length - 1;
		int num3 = 0;
		while (num2 >= 3)
		{
			uint_2[num3] = (uint)((inData[num2 - 3] << 24) | (inData[num2 - 2] << 16) | (inData[num2 - 1] << 8) | inData[num2]);
			num2 -= 4;
			num3++;
		}
		switch (num)
		{
		case 1:
			uint_2[uint_1 - 1] = inData[0];
			break;
		case 2:
			uint_2[uint_1 - 1] = (uint)((inData[0] << 8) | inData[1]);
			break;
		case 3:
			uint_2[uint_1 - 1] = (uint)((inData[0] << 16) | (inData[1] << 8) | inData[2]);
			break;
		}
		method_8();
	}

	internal Class1128(uint[] inData)
	{
		uint_1 = (uint)inData.Length;
		uint_2 = new uint[uint_1];
		int num = (int)(uint_1 - 1);
		int num2 = 0;
		while (num >= 0)
		{
			uint_2[num2] = inData[num];
			num--;
			num2++;
		}
		method_8();
	}

	internal Class1128(uint ui)
	{
		uint_2 = new uint[1] { ui };
	}

	internal Class1128(ulong ul)
	{
		uint_2 = new uint[2]
		{
			(uint)ul,
			(uint)(ul >> 32)
		};
		uint_1 = 2u;
		method_8();
	}

	[SpecialName]
	public static Class1128 smethod_0(uint value)
	{
		return new Class1128(value);
	}

	[SpecialName]
	public static Class1128 smethod_1(int value)
	{
		if (value < 0)
		{
			throw new ArgumentOutOfRangeException("value");
		}
		return new Class1128((uint)value);
	}

	[SpecialName]
	public static Class1128 smethod_2(ulong value)
	{
		return new Class1128(value);
	}

	internal static Class1128 smethod_3(string number)
	{
		if (number == null)
		{
			throw new ArgumentNullException("number");
		}
		int num = 0;
		int length = number.Length;
		bool flag = false;
		Class1128 @class = new Class1128(0u);
		if (number[0] == '+')
		{
			num++;
		}
		else if (number[num] == '-')
		{
			throw new FormatException("Operation would return a negative value");
		}
		while (true)
		{
			if (num < length)
			{
				char c = number[num];
				switch (c)
				{
				case '\0':
					num = length;
					goto IL_007c;
				case '0':
				case '1':
				case '2':
				case '3':
				case '4':
				case '5':
				case '6':
				case '7':
				case '8':
				case '9':
					@class = smethod_4(smethod_12(@class, 10), smethod_1(c - 48));
					flag = true;
					goto IL_007c;
				}
				if (!char.IsWhiteSpace(c))
				{
					break;
				}
				for (num++; num < length; num++)
				{
					if (!char.IsWhiteSpace(number[num]))
					{
						throw new FormatException();
					}
				}
			}
			if (!flag)
			{
				throw new FormatException();
			}
			return @class;
			IL_007c:
			num++;
		}
		throw new FormatException();
	}

	[SpecialName]
	public static Class1128 smethod_4(Class1128 bi1, Class1128 bi2)
	{
		if (bi1 == 0u)
		{
			return new Class1128(bi2);
		}
		if (bi2 == 0u)
		{
			return new Class1128(bi1);
		}
		return Class1131.smethod_0(bi1, bi2);
	}

	[SpecialName]
	public static Class1128 smethod_5(Class1128 bi1, Class1128 bi2)
	{
		if (bi2 == 0u)
		{
			return new Class1128(bi1);
		}
		if (bi1 == 0u)
		{
			throw new ArithmeticException("Operation would return a negative value");
		}
		return Class1131.Compare(bi1, bi2) switch
		{
			Enum173.const_0 => throw new ArithmeticException("Operation would return a negative value"), 
			Enum173.const_1 => smethod_1(0), 
			Enum173.const_2 => Class1131.smethod_1(bi1, bi2), 
			_ => throw new Exception(), 
		};
	}

	[SpecialName]
	public static int smethod_6(Class1128 bi, int i)
	{
		if (i > 0)
		{
			return (int)Class1131.smethod_5(bi, (uint)i);
		}
		return (int)(0 - Class1131.smethod_5(bi, (uint)(-i)));
	}

	[SpecialName]
	public static uint smethod_7(Class1128 bi, uint ui)
	{
		return Class1131.smethod_5(bi, ui);
	}

	[SpecialName]
	public static Class1128 smethod_8(Class1128 bi1, Class1128 bi2)
	{
		return Class1131.smethod_8(bi1, bi2)[1];
	}

	[SpecialName]
	public static Class1128 smethod_9(Class1128 bi, int i)
	{
		if (i <= 0)
		{
			throw new ArithmeticException("Operation would return a negative value");
		}
		return Class1131.smethod_6(bi, (uint)i);
	}

	[SpecialName]
	public static Class1128 smethod_10(Class1128 bi1, Class1128 bi2)
	{
		return Class1131.smethod_8(bi1, bi2)[0];
	}

	[SpecialName]
	public static Class1128 smethod_11(Class1128 bi1, Class1128 bi2)
	{
		if (!(bi1 == 0u) && !(bi2 == 0u))
		{
			if (bi1.uint_2.Length < bi1.uint_1)
			{
				throw new IndexOutOfRangeException("bi1 out of range");
			}
			if (bi2.uint_2.Length < bi2.uint_1)
			{
				throw new IndexOutOfRangeException("bi2 out of range");
			}
			Class1128 @class = new Class1128(Enum173.const_2, bi1.uint_1 + bi2.uint_1);
			Class1131.smethod_12(bi1.uint_2, 0u, bi1.uint_1, bi2.uint_2, 0u, bi2.uint_1, @class.uint_2, 0u);
			@class.method_8();
			return @class;
		}
		return smethod_1(0);
	}

	[SpecialName]
	public static Class1128 smethod_12(Class1128 bi, int i)
	{
		if (i < 0)
		{
			throw new ArithmeticException("Operation would return a negative value");
		}
		return i switch
		{
			0 => smethod_1(0), 
			1 => new Class1128(bi), 
			_ => Class1131.smethod_11(bi, (uint)i), 
		};
	}

	[SpecialName]
	public static Class1128 smethod_13(Class1128 bi1, int shiftVal)
	{
		return Class1131.smethod_9(bi1, shiftVal);
	}

	[SpecialName]
	public static Class1128 smethod_14(Class1128 bi1, int shiftVal)
	{
		return Class1131.smethod_10(bi1, shiftVal);
	}

	internal static Class1128 Add(Class1128 bi1, Class1128 bi2)
	{
		return smethod_4(bi1, bi2);
	}

	internal static Class1128 smethod_15(Class1128 bi1, Class1128 bi2)
	{
		return smethod_5(bi1, bi2);
	}

	internal static int smethod_16(Class1128 bi, int i)
	{
		return smethod_6(bi, i);
	}

	internal static uint smethod_17(Class1128 bi, uint ui)
	{
		return smethod_7(bi, ui);
	}

	internal static Class1128 smethod_18(Class1128 bi1, Class1128 bi2)
	{
		return smethod_8(bi1, bi2);
	}

	internal static Class1128 smethod_19(Class1128 bi, int i)
	{
		return smethod_9(bi, i);
	}

	internal static Class1128 smethod_20(Class1128 bi1, Class1128 bi2)
	{
		return smethod_10(bi1, bi2);
	}

	internal static Class1128 smethod_21(Class1128 bi1, Class1128 bi2)
	{
		return smethod_11(bi1, bi2);
	}

	internal static Class1128 smethod_22(Class1128 bi, int i)
	{
		return smethod_12(bi, i);
	}

	internal int method_0()
	{
		method_8();
		uint num = uint_2[uint_1 - 1];
		uint num2 = 2147483648u;
		uint num3 = 32u;
		while (num3 != 0 && (num & num2) == 0)
		{
			num3--;
			num2 >>= 1;
		}
		return (int)(num3 + (uint_1 - 1 << 5));
	}

	internal bool method_1(uint bitNum)
	{
		uint num = bitNum >> 5;
		byte b = (byte)(bitNum & 0x1Fu);
		uint num2 = (uint)(1 << (int)b);
		return (uint_2[num] & num2) != 0;
	}

	internal bool method_2(int bitNum)
	{
		if (bitNum < 0)
		{
			throw new IndexOutOfRangeException("bitNum out of range");
		}
		uint num = (uint)bitNum >> 5;
		byte b = (byte)((uint)bitNum & 0x1Fu);
		uint num2 = (uint)(1 << (int)b);
		return (uint_2[num] | num2) == uint_2[num];
	}

	internal void method_3(uint bitNum)
	{
		method_5(bitNum, value: true);
	}

	internal void method_4(uint bitNum)
	{
		method_5(bitNum, value: false);
	}

	internal void method_5(uint bitNum, bool value)
	{
		uint num = bitNum >> 5;
		if (num < uint_1)
		{
			uint num2 = (uint)(1 << (int)(bitNum & 0x1F));
			if (value)
			{
				uint_2[num] |= num2;
			}
			else
			{
				uint_2[num] &= ~num2;
			}
		}
	}

	internal int method_6()
	{
		if (this == 0u)
		{
			return -1;
		}
		int i;
		for (i = 0; !method_2(i); i++)
		{
		}
		return i;
	}

	internal byte[] method_7()
	{
		if (this == 0u)
		{
			return new byte[1];
		}
		int num = method_0();
		int num2 = num >> 3;
		if (((uint)num & 7u) != 0)
		{
			num2++;
		}
		byte[] array = new byte[num2];
		int num3 = num2 & 3;
		if (num3 == 0)
		{
			num3 = 4;
		}
		int num4 = 0;
		for (int num5 = (int)(uint_1 - 1); num5 >= 0; num5--)
		{
			uint num6 = uint_2[num5];
			for (int num7 = num3 - 1; num7 >= 0; num7--)
			{
				array[num4 + num7] = (byte)(num6 & 0xFFu);
				num6 >>= 8;
			}
			num4 += num3;
			num3 = 4;
		}
		return array;
	}

	public static bool operator ==(Class1128 bi1, uint ui)
	{
		if (bi1.uint_1 != 1)
		{
			bi1.method_8();
		}
		if (bi1.uint_1 == 1)
		{
			return bi1.uint_2[0] == ui;
		}
		return false;
	}

	public static bool operator !=(Class1128 bi1, uint ui)
	{
		if (bi1.uint_1 != 1)
		{
			bi1.method_8();
		}
		if (bi1.uint_1 == 1)
		{
			return bi1.uint_2[0] != ui;
		}
		return true;
	}

	public static bool operator ==(Class1128 bi1, Class1128 bi2)
	{
		if ((object)bi1 == bi2)
		{
			return true;
		}
		if (!(null == bi1) && !(null == bi2))
		{
			return Class1131.Compare(bi1, bi2) == Enum173.const_1;
		}
		return false;
	}

	public static bool operator !=(Class1128 bi1, Class1128 bi2)
	{
		if ((object)bi1 == bi2)
		{
			return false;
		}
		if (!(null == bi1) && !(null == bi2))
		{
			return Class1131.Compare(bi1, bi2) != Enum173.const_1;
		}
		return true;
	}

	[SpecialName]
	public static bool smethod_23(Class1128 bi1, Class1128 bi2)
	{
		return Class1131.Compare(bi1, bi2) > Enum173.const_1;
	}

	[SpecialName]
	public static bool smethod_24(Class1128 bi1, Class1128 bi2)
	{
		return Class1131.Compare(bi1, bi2) < Enum173.const_1;
	}

	[SpecialName]
	public static bool smethod_25(Class1128 bi1, Class1128 bi2)
	{
		return Class1131.Compare(bi1, bi2) >= Enum173.const_1;
	}

	[SpecialName]
	public static bool smethod_26(Class1128 bi1, Class1128 bi2)
	{
		return Class1131.Compare(bi1, bi2) <= Enum173.const_1;
	}

	internal Enum173 Compare(Class1128 bi)
	{
		return Class1131.Compare(this, bi);
	}

	internal string ToString(uint radix)
	{
		return ToString(radix, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ");
	}

	internal string ToString(uint radix, string characterSet)
	{
		if (characterSet.Length < radix)
		{
			throw new ArgumentException("charSet length less than radix", "characterSet");
		}
		if (radix == 1)
		{
			throw new ArgumentException("There is no such thing as radix one notation", "radix");
		}
		if (this == 0u)
		{
			return "0";
		}
		if (this == 1u)
		{
			return "1";
		}
		string text = "";
		Class1128 @class = new Class1128(this);
		while (@class != 0u)
		{
			uint index = Class1131.smethod_4(@class, radix);
			text = characterSet[(int)index] + text;
		}
		return text;
	}

	private void method_8()
	{
		while (uint_1 != 0 && uint_2[uint_1 - 1] == 0)
		{
			uint_1--;
		}
		if (uint_1 == 0)
		{
			uint_1++;
		}
	}

	internal void Clear()
	{
		for (int i = 0; i < uint_1; i++)
		{
			uint_2[i] = 0u;
		}
	}

	public override int GetHashCode()
	{
		uint num = 0u;
		for (uint num2 = 0u; num2 < uint_1; num2++)
		{
			num ^= uint_2[num2];
		}
		return (int)num;
	}

	public override string ToString()
	{
		return ToString(10u);
	}

	public override bool Equals(object o)
	{
		if (o == null)
		{
			return false;
		}
		if (o is int)
		{
			if ((int)o >= 0)
			{
				return this == (uint)o;
			}
			return false;
		}
		return Class1131.Compare(this, (Class1128)o) == Enum173.const_1;
	}

	internal Class1128 method_9(Class1128 bi)
	{
		return Class1131.smethod_15(this, bi);
	}

	internal Class1128 method_10(Class1128 modulus)
	{
		return Class1131.smethod_17(this, modulus);
	}

	internal Class1128 method_11(Class1128 exp, Class1128 n)
	{
		Class1129 @class = new Class1129(n);
		return @class.method_3(this, exp);
	}
}
