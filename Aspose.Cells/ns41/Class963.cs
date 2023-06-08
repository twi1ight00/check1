using System;
using System.Runtime.CompilerServices;

namespace ns41;

internal class Class963
{
	internal enum Enum132
	{
		const_0 = -1,
		const_1,
		const_2
	}

	internal class Class964
	{
		private Class963 class963_0;

		private Class963 class963_1;

		internal Class964(Class963 class963_2)
		{
			class963_0 = class963_2;
			uint num = class963_0.uint_0 << 1;
			class963_1 = new Class963(Enum132.const_2, num + 1);
			class963_1.uint_1[num] = 1u;
			class963_1 = smethod_3(class963_1, class963_0);
		}

		internal void method_0(Class963 class963_2)
		{
			Class963 @class = class963_0;
			uint uint_ = @class.uint_0;
			uint num = uint_ + 1;
			uint num2 = uint_ - 1;
			if (class963_2.uint_0 >= uint_)
			{
				if (class963_2.uint_1.Length < class963_2.uint_0)
				{
					throw new IndexOutOfRangeException("x out of range");
				}
				Class963 class2 = new Class963(Enum132.const_2, class963_2.uint_0 - num2 + class963_1.uint_0);
				Class966.smethod_7(class963_2.uint_1, num2, class963_2.uint_0 - num2, class963_1.uint_1, 0u, class963_1.uint_0, class2.uint_1, 0u);
				uint uint_2 = ((class963_2.uint_0 > num) ? num : class963_2.uint_0);
				class963_2.uint_0 = uint_2;
				class963_2.method_3();
				Class963 class3 = new Class963(Enum132.const_2, num);
				Class966.smethod_8(class2.uint_1, (int)num, (int)(class2.uint_0 - num), @class.uint_1, 0, (int)@class.uint_0, class3.uint_1, 0, (int)num);
				class3.method_3();
				if (smethod_9(class3, class963_2))
				{
					Class966.smethod_0(class963_2, class3);
				}
				else
				{
					Class963 class4 = new Class963(Enum132.const_2, num + 1);
					class4.uint_1[num] = 1u;
					Class966.smethod_0(class4, class3);
					Class966.smethod_1(class963_2, class4);
				}
				while (smethod_8(class963_2, @class))
				{
					Class966.smethod_0(class963_2, @class);
				}
			}
		}

		internal Class963 method_1(Class963 class963_2, Class963 class963_3)
		{
			if ((class963_0.uint_1[0] & 1) == 1)
			{
				return method_3(class963_2, class963_3);
			}
			return method_2(class963_2, class963_3);
		}

		internal Class963 method_2(Class963 class963_2, Class963 class963_3)
		{
			Class963 @class = new Class963(smethod_1(1), class963_0.uint_0 << 1);
			Class963 class2 = new Class963(smethod_2(class963_2, class963_0), class963_0.uint_0 << 1);
			uint num = (uint)class963_3.method_0();
			uint[] uint_ = new uint[class963_0.uint_0 << 1];
			uint num2 = 0u;
			while (true)
			{
				if (num2 < num)
				{
					if (class963_3.method_1(num2))
					{
						Array.Clear(uint_, 0, uint_.Length);
						Class966.smethod_7(@class.uint_1, 0u, @class.uint_0, class2.uint_1, 0u, class2.uint_0, uint_, 0u);
						@class.uint_0 += class2.uint_0;
						uint[] uint_2 = uint_;
						uint_ = @class.uint_1;
						@class.uint_1 = uint_2;
						method_0(@class);
					}
					Class966.smethod_9(class2, ref uint_);
					method_0(class2);
					if (smethod_6(class2, 1u))
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

		private Class963 method_3(Class963 class963_2, Class963 class963_3)
		{
			Class963 @class = new Class963(Class965.smethod_1(smethod_1(1), class963_0), class963_0.uint_0 << 1);
			Class963 class2 = new Class963(Class965.smethod_1(class963_2, class963_0), class963_0.uint_0 << 1);
			uint uint_ = Class965.smethod_0(class963_0.uint_1[0]);
			uint num = (uint)class963_3.method_0();
			uint[] uint_2 = new uint[class963_0.uint_0 << 1];
			for (uint num2 = 0u; num2 < num; num2++)
			{
				if (class963_3.method_1(num2))
				{
					Array.Clear(uint_2, 0, uint_2.Length);
					Class966.smethod_7(@class.uint_1, 0u, @class.uint_0, class2.uint_1, 0u, class2.uint_0, uint_2, 0u);
					@class.uint_0 += class2.uint_0;
					uint[] uint_3 = uint_2;
					uint_2 = @class.uint_1;
					@class.uint_1 = uint_3;
					Class965.smethod_2(@class, class963_0, uint_);
				}
				Class966.smethod_9(class2, ref uint_2);
				Class965.smethod_2(class2, class963_0, uint_);
			}
			Class965.smethod_2(@class, class963_0, uint_);
			return @class;
		}
	}

	private class Class966
	{
		internal static void smethod_0(Class963 class963_0, Class963 class963_1)
		{
			uint[] uint_ = class963_0.uint_1;
			uint[] uint_2 = class963_1.uint_1;
			uint num = 0u;
			uint num2 = 0u;
			do
			{
				uint num3 = uint_2[num];
				num2 = ((((num3 += num2) < num2) | ((uint_[num] -= num3) > ~num3)) ? 1u : 0u);
			}
			while (++num < class963_1.uint_0);
			if (num != class963_0.uint_0 && num2 == 1)
			{
				do
				{
					uint_[num]--;
				}
				while (uint_[num++] == 0 && num < class963_0.uint_0);
			}
			while (class963_0.uint_0 != 0 && class963_0.uint_1[class963_0.uint_0 - 1] == 0)
			{
				class963_0.uint_0--;
			}
			if (class963_0.uint_0 == 0)
			{
				class963_0.uint_0++;
			}
		}

		internal static void smethod_1(Class963 class963_0, Class963 class963_1)
		{
			uint num = 0u;
			bool flag = false;
			uint[] uint_;
			uint uint_2;
			uint[] uint_3;
			uint uint_4;
			if (class963_0.uint_0 < class963_1.uint_0)
			{
				flag = true;
				uint_ = class963_1.uint_1;
				uint_2 = class963_1.uint_0;
				uint_3 = class963_0.uint_1;
				uint_4 = class963_0.uint_0;
			}
			else
			{
				uint_ = class963_0.uint_1;
				uint_2 = class963_0.uint_0;
				uint_3 = class963_1.uint_1;
				uint_4 = class963_1.uint_0;
			}
			uint[] uint_5 = class963_0.uint_1;
			ulong num2 = 0uL;
			do
			{
				num2 += (ulong)((long)uint_[num] + (long)uint_3[num]);
				uint_5[num] = (uint)num2;
				num2 >>= 32;
			}
			while (++num < uint_4);
			bool flag2;
			if (flag2 = num2 != 0)
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
					num = (class963_0.uint_0 = num + 1);
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
			class963_0.uint_0 = uint_2 + 1;
			class963_0.method_3();
		}

		internal static Enum132 Compare(Class963 class963_0, Class963 class963_1)
		{
			uint num = class963_0.uint_0;
			uint num2 = class963_1.uint_0;
			while (num != 0 && class963_0.uint_1[num - 1] == 0)
			{
				num--;
			}
			while (num2 != 0 && class963_1.uint_1[num2 - 1] == 0)
			{
				num2--;
			}
			if (num == 0 && num2 == 0)
			{
				return Enum132.const_1;
			}
			if (num < num2)
			{
				return Enum132.const_0;
			}
			if (num > num2)
			{
				return Enum132.const_2;
			}
			uint num3 = num - 1;
			while (num3 != 0 && class963_0.uint_1[num3] == class963_1.uint_1[num3])
			{
				num3--;
			}
			if (class963_0.uint_1[num3] < class963_1.uint_1[num3])
			{
				return Enum132.const_0;
			}
			if (class963_0.uint_1[num3] > class963_1.uint_1[num3])
			{
				return Enum132.const_2;
			}
			return Enum132.const_1;
		}

		internal static uint smethod_2(Class963 class963_0, uint uint_0)
		{
			ulong num = 0uL;
			uint uint_ = class963_0.uint_0;
			while (uint_-- != 0)
			{
				num <<= 32;
				num |= class963_0.uint_1[uint_];
				class963_0.uint_1[uint_] = (uint)(num / uint_0);
				num %= uint_0;
			}
			class963_0.method_3();
			return (uint)num;
		}

		internal static Class963[] smethod_3(Class963 class963_0, uint uint_0)
		{
			Class963 @class = new Class963(Enum132.const_2, class963_0.uint_0);
			ulong num = 0uL;
			uint uint_ = class963_0.uint_0;
			while (uint_-- != 0)
			{
				num <<= 32;
				num |= class963_0.uint_1[uint_];
				@class.uint_1[uint_] = (uint)(num / uint_0);
				num %= uint_0;
			}
			@class.method_3();
			Class963 class2 = Class963.smethod_0((uint)num);
			return new Class963[2] { @class, class2 };
		}

		internal static Class963[] smethod_4(Class963 class963_0, Class963 class963_1)
		{
			if (Compare(class963_0, class963_1) == Enum132.const_0)
			{
				return new Class963[2]
				{
					Class963.smethod_1(0),
					new Class963(class963_0)
				};
			}
			class963_0.method_3();
			class963_1.method_3();
			if (class963_1.uint_0 == 1)
			{
				return smethod_3(class963_0, class963_1.uint_1[0]);
			}
			uint num = class963_0.uint_0 + 1;
			int num2 = (int)(class963_1.uint_0 + 1);
			uint num3 = 2147483648u;
			uint num4 = class963_1.uint_1[class963_1.uint_0 - 1];
			int num5 = 0;
			int num6 = (int)(class963_0.uint_0 - class963_1.uint_0);
			while (num3 != 0 && (num4 & num3) == 0)
			{
				num5++;
				num3 >>= 1;
			}
			Class963 @class = new Class963(Enum132.const_2, class963_0.uint_0 - class963_1.uint_0 + 1);
			Class963 class2 = Class963.smethod_4(class963_0, num5);
			uint[] uint_ = class2.uint_1;
			class963_1 = Class963.smethod_4(class963_1, num5);
			int num7 = (int)(num - class963_1.uint_0);
			int num8 = (int)(num - 1);
			uint num9 = class963_1.uint_1[class963_1.uint_0 - 1];
			ulong num10 = class963_1.uint_1[class963_1.uint_0 - 2];
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
					num16 += (ulong)((long)class963_1.uint_1[num14] * (long)num17);
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
				if (num16 != 0)
				{
					num17--;
					ulong num19 = 0uL;
					do
					{
						num19 = (ulong)((long)uint_[num15] + (long)class963_1.uint_1[num14]) + num19;
						uint_[num15] = (uint)num19;
						num19 >>= 32;
						num14++;
						num15++;
					}
					while (num14 < num2);
				}
				@class.uint_1[num6--] = num17;
				num8--;
				num7--;
			}
			@class.method_3();
			class2.method_3();
			Class963[] array = new Class963[2] { @class, class2 };
			if (num5 != 0)
			{
				Class963[] array2;
				(array2 = array)[1] = Class963.smethod_5(array2[1], num5);
			}
			return array;
		}

		internal static Class963 smethod_5(Class963 class963_0, int int_0)
		{
			if (int_0 == 0)
			{
				return new Class963(class963_0, class963_0.uint_0 + 1);
			}
			int num = int_0 >> 5;
			int_0 &= 0x1F;
			Class963 @class = new Class963(Enum132.const_2, class963_0.uint_0 + 1 + (uint)num);
			uint num2 = 0u;
			uint uint_ = class963_0.uint_0;
			if (int_0 != 0)
			{
				uint num3 = 0u;
				for (; num2 < uint_; num2++)
				{
					uint num4 = class963_0.uint_1[num2];
					@class.uint_1[num2 + num] = (num4 << int_0) | num3;
					num3 = num4 >> 32 - int_0;
				}
				@class.uint_1[num2 + num] = num3;
			}
			else
			{
				for (; num2 < uint_; num2++)
				{
					@class.uint_1[num2 + num] = class963_0.uint_1[num2];
				}
			}
			@class.method_3();
			return @class;
		}

		internal static Class963 smethod_6(Class963 class963_0, int int_0)
		{
			if (int_0 == 0)
			{
				return new Class963(class963_0);
			}
			int num = int_0 >> 5;
			int num2 = int_0 & 0x1F;
			Class963 @class = new Class963(Enum132.const_2, (uint)((int)class963_0.uint_0 - num + 1));
			uint num3 = (uint)(@class.uint_1.Length - 1);
			if (num2 != 0)
			{
				uint num4 = 0u;
				while (num3-- != 0)
				{
					uint num5 = class963_0.uint_1[num3 + num];
					@class.uint_1[num3] = (num5 >> int_0) | num4;
					num4 = num5 << 32 - int_0;
				}
			}
			else
			{
				while (num3-- != 0)
				{
					@class.uint_1[num3] = class963_0.uint_1[num3 + num];
				}
			}
			@class.method_3();
			return @class;
		}

		internal static void smethod_7(uint[] uint_0, uint uint_1, uint uint_2, uint[] uint_3, uint uint_4, uint uint_5, uint[] uint_6, uint uint_7)
		{
			uint num = uint_1;
			uint num2 = num + uint_2;
			uint num3 = uint_4 + uint_5;
			uint num4 = uint_7;
			while (num < num2)
			{
				if (uint_0[num] != 0)
				{
					ulong num5 = 0uL;
					uint num6 = num4;
					uint num7 = uint_4;
					while (num7 < num3)
					{
						num5 += (ulong)((long)uint_0[num] * (long)uint_3[num7] + uint_6[num6]);
						uint_6[num6] = (uint)num5;
						num5 >>= 32;
						num7++;
						num6++;
					}
					if (num5 != 0)
					{
						uint_6[num6] = (uint)num5;
					}
				}
				num++;
				num4++;
			}
		}

		internal static void smethod_8(uint[] uint_0, int int_0, int int_1, uint[] uint_1, int int_2, int int_3, uint[] uint_2, int int_4, int int_5)
		{
			uint num = (uint)int_0;
			uint num2 = num + (uint)int_1;
			uint num3 = (uint)(int_2 + int_3);
			uint num4 = (uint)int_4;
			uint num5 = num4 + (uint)int_5;
			while (num < num2)
			{
				if (uint_0[num] != 0)
				{
					ulong num6 = 0uL;
					uint num7 = num4;
					uint num8 = (uint)int_2;
					while (num8 < num3 && num7 < num5)
					{
						num6 += (ulong)((long)uint_0[num] * (long)uint_1[num8] + uint_2[num7]);
						uint_2[num7] = (uint)num6;
						num6 >>= 32;
						num8++;
						num7++;
					}
					if (num6 != 0 && num7 < num5)
					{
						uint_2[num7] = (uint)num6;
					}
				}
				num++;
				num4++;
			}
		}

		internal static void smethod_9(Class963 class963_0, ref uint[] uint_0)
		{
			uint[] array = uint_0;
			uint_0 = class963_0.uint_1;
			uint[] uint_ = class963_0.uint_1;
			uint uint_2 = class963_0.uint_0;
			class963_0.uint_1 = array;
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
					if (num6 != 0)
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
			class963_0.uint_0 <<= 1;
			while (array[class963_0.uint_0 - 1] == 0 && class963_0.uint_0 > 1)
			{
				class963_0.uint_0--;
			}
		}
	}

	internal class Class965
	{
		private Class965()
		{
		}

		internal static uint smethod_0(uint uint_0)
		{
			uint num = uint_0;
			uint num2;
			while ((num2 = uint_0 * num) != 1)
			{
				num *= 2 - num2;
			}
			return (uint)(0uL - (ulong)num);
		}

		internal static Class963 smethod_1(Class963 class963_0, Class963 class963_1)
		{
			class963_0.method_3();
			class963_1.method_3();
			class963_0 = smethod_4(class963_0, (int)(class963_1.uint_0 * 32));
			class963_0 = Class963.smethod_2(class963_0, class963_1);
			return class963_0;
		}

		internal static Class963 smethod_2(Class963 class963_0, Class963 class963_1, uint uint_0)
		{
			uint[] uint_ = class963_0.uint_1;
			uint[] uint_2 = class963_1.uint_1;
			for (uint num = 0u; num < class963_1.uint_0; num++)
			{
				uint num2 = uint_[0] * uint_0;
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
				for (num9 = 1u; num9 < class963_1.uint_0; num9++)
				{
					num8 += (ulong)((long)num2 * (long)uint_2[num3++] + uint_[num4++]);
					uint_[num5++] = (uint)num8;
					num8 >>= 32;
				}
				for (; num9 < class963_0.uint_0; num9++)
				{
					num8 += uint_[num4++];
					uint_[num5++] = (uint)num8;
					num8 >>= 32;
					if (num8 == 0)
					{
						num9++;
						break;
					}
				}
				for (; num9 < class963_0.uint_0; num9++)
				{
					uint_[num5++] = uint_[num4++];
				}
				uint_[num5++] = (uint)num8;
			}
			while (class963_0.uint_0 > 1 && uint_[class963_0.uint_0 - 1] == 0)
			{
				class963_0.uint_0--;
			}
			if (smethod_8(class963_0, class963_1))
			{
				Class966.smethod_0(class963_0, class963_1);
			}
			return class963_0;
		}
	}

	private uint uint_0 = 1u;

	private uint[] uint_1;

	internal static readonly uint[] uint_2 = new uint[783]
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

	internal Class963()
	{
		uint_1 = new uint[20];
		uint_0 = 20u;
	}

	internal Class963(Enum132 enum132_0, uint uint_3)
	{
		uint_1 = new uint[uint_3];
		uint_0 = uint_3;
	}

	internal Class963(Class963 class963_0)
	{
		uint_1 = (uint[])class963_0.uint_1.Clone();
		uint_0 = class963_0.uint_0;
	}

	internal Class963(Class963 class963_0, uint uint_3)
	{
		uint_1 = new uint[uint_3];
		for (uint num = 0u; num < class963_0.uint_0; num++)
		{
			uint_1[num] = class963_0.uint_1[num];
		}
		uint_0 = class963_0.uint_0;
	}

	internal Class963(byte[] byte_0)
	{
		uint_0 = (uint)byte_0.Length >> 2;
		int num = byte_0.Length & 3;
		if (num != 0)
		{
			uint_0++;
		}
		uint_1 = new uint[uint_0];
		int num2 = byte_0.Length - 1;
		int num3 = 0;
		while (num2 >= 3)
		{
			uint_1[num3] = (uint)((byte_0[num2 - 3] << 24) | (byte_0[num2 - 2] << 16) | (byte_0[num2 - 1] << 8) | byte_0[num2]);
			num2 -= 4;
			num3++;
		}
		switch (num)
		{
		case 1:
			uint_1[uint_0 - 1] = byte_0[0];
			break;
		case 2:
			uint_1[uint_0 - 1] = (uint)((byte_0[0] << 8) | byte_0[1]);
			break;
		case 3:
			uint_1[uint_0 - 1] = (uint)((byte_0[0] << 16) | (byte_0[1] << 8) | byte_0[2]);
			break;
		}
		method_3();
	}

	internal Class963(uint uint_3)
	{
		uint_1 = new uint[1] { uint_3 };
	}

	[SpecialName]
	public static Class963 smethod_0(uint uint_3)
	{
		return new Class963(uint_3);
	}

	[SpecialName]
	public static Class963 smethod_1(int int_0)
	{
		if (int_0 < 0)
		{
			throw new ArgumentOutOfRangeException("value");
		}
		return new Class963((uint)int_0);
	}

	[SpecialName]
	public static Class963 smethod_2(Class963 class963_0, Class963 class963_1)
	{
		return Class966.smethod_4(class963_0, class963_1)[1];
	}

	[SpecialName]
	public static Class963 smethod_3(Class963 class963_0, Class963 class963_1)
	{
		return Class966.smethod_4(class963_0, class963_1)[0];
	}

	[SpecialName]
	public static Class963 smethod_4(Class963 class963_0, int int_0)
	{
		return Class966.smethod_5(class963_0, int_0);
	}

	[SpecialName]
	public static Class963 smethod_5(Class963 class963_0, int int_0)
	{
		return Class966.smethod_6(class963_0, int_0);
	}

	public int method_0()
	{
		method_3();
		uint num = uint_1[uint_0 - 1];
		uint num2 = 2147483648u;
		uint num3 = 32u;
		while (num3 != 0 && (num & num2) == 0)
		{
			num3--;
			num2 >>= 1;
		}
		return (int)(num3 + (uint_0 - 1 << 5));
	}

	internal bool method_1(uint uint_3)
	{
		uint num = uint_3 >> 5;
		byte b = (byte)(uint_3 & 0x1Fu);
		uint num2 = (uint)(1 << (int)b);
		return (uint_1[num] & num2) != 0;
	}

	internal byte[] method_2()
	{
		if (smethod_6(this, 0u))
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
		for (int num5 = (int)(uint_0 - 1); num5 >= 0; num5--)
		{
			uint num6 = uint_1[num5];
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

	[SpecialName]
	public static bool smethod_6(Class963 class963_0, uint uint_3)
	{
		if (class963_0.uint_0 != 1)
		{
			class963_0.method_3();
		}
		if (class963_0.uint_0 == 1)
		{
			return class963_0.uint_1[0] == uint_3;
		}
		return false;
	}

	[SpecialName]
	public static bool smethod_7(Class963 class963_0, uint uint_3)
	{
		if (class963_0.uint_0 != 1)
		{
			class963_0.method_3();
		}
		if (class963_0.uint_0 == 1)
		{
			return class963_0.uint_1[0] != uint_3;
		}
		return true;
	}

	[SpecialName]
	public static bool smethod_8(Class963 class963_0, Class963 class963_1)
	{
		return Class966.Compare(class963_0, class963_1) >= Enum132.const_1;
	}

	[SpecialName]
	public static bool smethod_9(Class963 class963_0, Class963 class963_1)
	{
		return Class966.Compare(class963_0, class963_1) <= Enum132.const_1;
	}

	internal string ToString(uint uint_3)
	{
		return ToString(uint_3, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ");
	}

	internal string ToString(uint uint_3, string string_0)
	{
		if (string_0.Length < uint_3)
		{
			throw new ArgumentException("charSet length less than radix", "characterSet");
		}
		if (uint_3 == 1)
		{
			throw new ArgumentException("There is no such thing as radix one notation", "radix");
		}
		if (smethod_6(this, 0u))
		{
			return "0";
		}
		if (smethod_6(this, 1u))
		{
			return "1";
		}
		string text = "";
		Class963 class963_ = new Class963(this);
		while (smethod_7(class963_, 0u))
		{
			uint index = Class966.smethod_2(class963_, uint_3);
			text = string_0[(int)index] + text;
		}
		return text;
	}

	private void method_3()
	{
		while (uint_0 != 0 && uint_1[uint_0 - 1] == 0)
		{
			uint_0--;
		}
		if (uint_0 == 0)
		{
			uint_0++;
		}
	}

	internal void Clear()
	{
		for (int i = 0; i < uint_0; i++)
		{
			uint_1[i] = 0u;
		}
	}

	public override int GetHashCode()
	{
		uint num = 0u;
		for (uint num2 = 0u; num2 < uint_0; num2++)
		{
			num ^= uint_1[num2];
		}
		return (int)num;
	}

	public override string ToString()
	{
		return ToString(10u);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is int)
		{
			if ((int)obj >= 0)
			{
				return smethod_6(this, (uint)obj);
			}
			return false;
		}
		return Class966.Compare(this, (Class963)obj) == Enum132.const_1;
	}

	internal Class963 method_4(Class963 class963_0, Class963 class963_1)
	{
		Class964 @class = new Class964(class963_1);
		return @class.method_1(this, class963_0);
	}
}
