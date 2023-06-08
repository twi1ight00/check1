using System;
using Aspose;
using x13f1efc79617a47b;

namespace x5f3520a4b31ea90f;

[JavaManual("This is used for document signatures, not yet fully ported to Java. Do it later")]
internal class xfbab8f66e7836ec4
{
	internal enum x0428c55343267861
	{
		xef19f5be66d2e2e3 = -1,
		x67cf982b3c9c2bb6,
		x7eefbac090024714
	}

	private class xf094e3229d63c9be
	{
		internal static xfbab8f66e7836ec4 xdb56c62f254c0a59(xfbab8f66e7836ec4 x83e17d59cce46549, xfbab8f66e7836ec4 xb6a214d6bebb5fe1)
		{
			uint num = 0u;
			uint[] x4a3f0a05c02f235f;
			uint x961016a387451f;
			uint[] x4a3f0a05c02f235f2;
			uint x961016a387451f2;
			if (x83e17d59cce46549.x961016a387451f05 < xb6a214d6bebb5fe1.x961016a387451f05)
			{
				x4a3f0a05c02f235f = xb6a214d6bebb5fe1.x4a3f0a05c02f235f;
				x961016a387451f = xb6a214d6bebb5fe1.x961016a387451f05;
				x4a3f0a05c02f235f2 = x83e17d59cce46549.x4a3f0a05c02f235f;
				x961016a387451f2 = x83e17d59cce46549.x961016a387451f05;
			}
			else
			{
				x4a3f0a05c02f235f = x83e17d59cce46549.x4a3f0a05c02f235f;
				x961016a387451f = x83e17d59cce46549.x961016a387451f05;
				x4a3f0a05c02f235f2 = xb6a214d6bebb5fe1.x4a3f0a05c02f235f;
				x961016a387451f2 = xb6a214d6bebb5fe1.x961016a387451f05;
			}
			xfbab8f66e7836ec4 xfbab8f66e7836ec5 = new xfbab8f66e7836ec4(x0428c55343267861.x7eefbac090024714, x961016a387451f + 1);
			uint[] x4a3f0a05c02f235f3 = xfbab8f66e7836ec5.x4a3f0a05c02f235f;
			ulong num2 = 0uL;
			do
			{
				num2 = (ulong)((long)x4a3f0a05c02f235f[num] + (long)x4a3f0a05c02f235f2[num]) + num2;
				x4a3f0a05c02f235f3[num] = (uint)num2;
				num2 >>= 32;
			}
			while (++num < x961016a387451f2);
			bool flag = num2 != 0;
			if (flag)
			{
				if (num < x961016a387451f)
				{
					do
					{
						flag = (x4a3f0a05c02f235f3[num] = x4a3f0a05c02f235f[num] + 1) == 0;
					}
					while (++num < x961016a387451f && flag);
				}
				if (flag)
				{
					x4a3f0a05c02f235f3[num] = 1u;
					num = (xfbab8f66e7836ec5.x961016a387451f05 = num + 1);
					return xfbab8f66e7836ec5;
				}
			}
			if (num < x961016a387451f)
			{
				do
				{
					x4a3f0a05c02f235f3[num] = x4a3f0a05c02f235f[num];
				}
				while (++num < x961016a387451f);
			}
			xfbab8f66e7836ec5.x234d65249b8ddf72();
			return xfbab8f66e7836ec5;
		}

		internal static xfbab8f66e7836ec4 xc7c1a5f6d5e982b1(xfbab8f66e7836ec4 x48d3383c98e28230, xfbab8f66e7836ec4 xcdcd086a24567c77)
		{
			xfbab8f66e7836ec4 xfbab8f66e7836ec5 = new xfbab8f66e7836ec4(x0428c55343267861.x7eefbac090024714, x48d3383c98e28230.x961016a387451f05);
			uint[] x4a3f0a05c02f235f = xfbab8f66e7836ec5.x4a3f0a05c02f235f;
			uint[] x4a3f0a05c02f235f2 = x48d3383c98e28230.x4a3f0a05c02f235f;
			uint[] x4a3f0a05c02f235f3 = xcdcd086a24567c77.x4a3f0a05c02f235f;
			uint num = 0u;
			uint num2 = 0u;
			do
			{
				uint num3 = x4a3f0a05c02f235f3[num];
				num2 = ((((num3 += num2) < num2) | ((x4a3f0a05c02f235f[num] = x4a3f0a05c02f235f2[num] - num3) > ~num3)) ? 1u : 0u);
			}
			while (++num < xcdcd086a24567c77.x961016a387451f05);
			if (num != x48d3383c98e28230.x961016a387451f05)
			{
				if (num2 == 1)
				{
					do
					{
						x4a3f0a05c02f235f[num] = x4a3f0a05c02f235f2[num] - 1;
					}
					while (x4a3f0a05c02f235f2[num++] == 0 && num < x48d3383c98e28230.x961016a387451f05);
					if (num == x48d3383c98e28230.x961016a387451f05)
					{
						goto IL_00c0;
					}
				}
				do
				{
					x4a3f0a05c02f235f[num] = x4a3f0a05c02f235f2[num];
				}
				while (++num < x48d3383c98e28230.x961016a387451f05);
			}
			goto IL_00c0;
			IL_00c0:
			xfbab8f66e7836ec5.x234d65249b8ddf72();
			return xfbab8f66e7836ec5;
		}

		internal static void x4fead14d15bab3b0(xfbab8f66e7836ec4 x48d3383c98e28230, xfbab8f66e7836ec4 xcdcd086a24567c77)
		{
			uint[] x4a3f0a05c02f235f = x48d3383c98e28230.x4a3f0a05c02f235f;
			uint[] x4a3f0a05c02f235f2 = xcdcd086a24567c77.x4a3f0a05c02f235f;
			uint num = 0u;
			uint num2 = 0u;
			do
			{
				uint num3 = x4a3f0a05c02f235f2[num];
				num2 = ((((num3 += num2) < num2) | ((x4a3f0a05c02f235f[num] -= num3) > ~num3)) ? 1u : 0u);
			}
			while (++num < xcdcd086a24567c77.x961016a387451f05);
			if (num != x48d3383c98e28230.x961016a387451f05 && num2 == 1)
			{
				do
				{
					x4a3f0a05c02f235f[num]--;
				}
				while (x4a3f0a05c02f235f[num++] == 0 && num < x48d3383c98e28230.x961016a387451f05);
			}
			while (x48d3383c98e28230.x961016a387451f05 != 0 && x48d3383c98e28230.x4a3f0a05c02f235f[x48d3383c98e28230.x961016a387451f05 - 1] == 0)
			{
				x48d3383c98e28230.x961016a387451f05--;
			}
			if (x48d3383c98e28230.x961016a387451f05 == 0)
			{
				x48d3383c98e28230.x961016a387451f05++;
			}
		}

		internal static void xd2474061571ed9e3(xfbab8f66e7836ec4 x83e17d59cce46549, xfbab8f66e7836ec4 xb6a214d6bebb5fe1)
		{
			uint num = 0u;
			bool flag = false;
			uint[] x4a3f0a05c02f235f;
			uint x961016a387451f;
			uint[] x4a3f0a05c02f235f2;
			uint x961016a387451f2;
			if (x83e17d59cce46549.x961016a387451f05 < xb6a214d6bebb5fe1.x961016a387451f05)
			{
				flag = true;
				x4a3f0a05c02f235f = xb6a214d6bebb5fe1.x4a3f0a05c02f235f;
				x961016a387451f = xb6a214d6bebb5fe1.x961016a387451f05;
				x4a3f0a05c02f235f2 = x83e17d59cce46549.x4a3f0a05c02f235f;
				x961016a387451f2 = x83e17d59cce46549.x961016a387451f05;
			}
			else
			{
				x4a3f0a05c02f235f = x83e17d59cce46549.x4a3f0a05c02f235f;
				x961016a387451f = x83e17d59cce46549.x961016a387451f05;
				x4a3f0a05c02f235f2 = xb6a214d6bebb5fe1.x4a3f0a05c02f235f;
				x961016a387451f2 = xb6a214d6bebb5fe1.x961016a387451f05;
			}
			uint[] x4a3f0a05c02f235f3 = x83e17d59cce46549.x4a3f0a05c02f235f;
			ulong num2 = 0uL;
			do
			{
				num2 += (ulong)((long)x4a3f0a05c02f235f[num] + (long)x4a3f0a05c02f235f2[num]);
				x4a3f0a05c02f235f3[num] = (uint)num2;
				num2 >>= 32;
			}
			while (++num < x961016a387451f2);
			bool flag2 = num2 != 0;
			if (flag2)
			{
				if (num < x961016a387451f)
				{
					do
					{
						flag2 = (x4a3f0a05c02f235f3[num] = x4a3f0a05c02f235f[num] + 1) == 0;
					}
					while (++num < x961016a387451f && flag2);
				}
				if (flag2)
				{
					x4a3f0a05c02f235f3[num] = 1u;
					num = (x83e17d59cce46549.x961016a387451f05 = num + 1);
					return;
				}
			}
			if (flag && num < x961016a387451f - 1)
			{
				do
				{
					x4a3f0a05c02f235f3[num] = x4a3f0a05c02f235f[num];
				}
				while (++num < x961016a387451f);
			}
			x83e17d59cce46549.x961016a387451f05 = x961016a387451f + 1;
			x83e17d59cce46549.x234d65249b8ddf72();
		}

		internal static x0428c55343267861 x65a184a150825e58(xfbab8f66e7836ec4 x83e17d59cce46549, xfbab8f66e7836ec4 xb6a214d6bebb5fe1)
		{
			uint num = x83e17d59cce46549.x961016a387451f05;
			uint num2 = xb6a214d6bebb5fe1.x961016a387451f05;
			while (num != 0 && x83e17d59cce46549.x4a3f0a05c02f235f[num - 1] == 0)
			{
				num--;
			}
			while (num2 != 0 && xb6a214d6bebb5fe1.x4a3f0a05c02f235f[num2 - 1] == 0)
			{
				num2--;
			}
			if (num == 0 && num2 == 0)
			{
				return x0428c55343267861.x67cf982b3c9c2bb6;
			}
			if (num < num2)
			{
				return x0428c55343267861.xef19f5be66d2e2e3;
			}
			if (num > num2)
			{
				return x0428c55343267861.x7eefbac090024714;
			}
			uint num3 = num - 1;
			while (num3 != 0 && x83e17d59cce46549.x4a3f0a05c02f235f[num3] == xb6a214d6bebb5fe1.x4a3f0a05c02f235f[num3])
			{
				num3--;
			}
			if (x83e17d59cce46549.x4a3f0a05c02f235f[num3] < xb6a214d6bebb5fe1.x4a3f0a05c02f235f[num3])
			{
				return x0428c55343267861.xef19f5be66d2e2e3;
			}
			if (x83e17d59cce46549.x4a3f0a05c02f235f[num3] > xb6a214d6bebb5fe1.x4a3f0a05c02f235f[num3])
			{
				return x0428c55343267861.x7eefbac090024714;
			}
			return x0428c55343267861.x67cf982b3c9c2bb6;
		}

		internal static uint xd7b5ea34a8142968(xfbab8f66e7836ec4 x57e9faf3ffdc07cc, uint x73f821c71fe1e676)
		{
			ulong num = 0uL;
			uint x961016a387451f = x57e9faf3ffdc07cc.x961016a387451f05;
			while (x961016a387451f-- != 0)
			{
				num <<= 32;
				num |= x57e9faf3ffdc07cc.x4a3f0a05c02f235f[x961016a387451f];
				x57e9faf3ffdc07cc.x4a3f0a05c02f235f[x961016a387451f] = (uint)(num / x73f821c71fe1e676);
				num %= x73f821c71fe1e676;
			}
			x57e9faf3ffdc07cc.x234d65249b8ddf72();
			return (uint)num;
		}

		internal static uint xd9bce5ef71e883b0(xfbab8f66e7836ec4 x57e9faf3ffdc07cc, uint x73f821c71fe1e676)
		{
			ulong num = 0uL;
			uint x961016a387451f = x57e9faf3ffdc07cc.x961016a387451f05;
			while (x961016a387451f-- != 0)
			{
				num <<= 32;
				num |= x57e9faf3ffdc07cc.x4a3f0a05c02f235f[x961016a387451f];
				num %= x73f821c71fe1e676;
			}
			return (uint)num;
		}

		internal static xfbab8f66e7836ec4 xfc4adf10bba1aee3(xfbab8f66e7836ec4 x57e9faf3ffdc07cc, uint x73f821c71fe1e676)
		{
			xfbab8f66e7836ec4 xfbab8f66e7836ec5 = new xfbab8f66e7836ec4(x0428c55343267861.x7eefbac090024714, x57e9faf3ffdc07cc.x961016a387451f05);
			ulong num = 0uL;
			uint x961016a387451f = x57e9faf3ffdc07cc.x961016a387451f05;
			while (x961016a387451f-- != 0)
			{
				num <<= 32;
				num |= x57e9faf3ffdc07cc.x4a3f0a05c02f235f[x961016a387451f];
				xfbab8f66e7836ec5.x4a3f0a05c02f235f[x961016a387451f] = (uint)(num / x73f821c71fe1e676);
				num %= x73f821c71fe1e676;
			}
			xfbab8f66e7836ec5.x234d65249b8ddf72();
			return xfbab8f66e7836ec5;
		}

		internal static xfbab8f66e7836ec4[] xf7a471d0787a2d87(xfbab8f66e7836ec4 x57e9faf3ffdc07cc, uint x73f821c71fe1e676)
		{
			xfbab8f66e7836ec4 xfbab8f66e7836ec5 = new xfbab8f66e7836ec4(x0428c55343267861.x7eefbac090024714, x57e9faf3ffdc07cc.x961016a387451f05);
			ulong num = 0uL;
			uint x961016a387451f = x57e9faf3ffdc07cc.x961016a387451f05;
			while (x961016a387451f-- != 0)
			{
				num <<= 32;
				num |= x57e9faf3ffdc07cc.x4a3f0a05c02f235f[x961016a387451f];
				xfbab8f66e7836ec5.x4a3f0a05c02f235f[x961016a387451f] = (uint)(num / x73f821c71fe1e676);
				num %= x73f821c71fe1e676;
			}
			xfbab8f66e7836ec5.x234d65249b8ddf72();
			xfbab8f66e7836ec4 xfbab8f66e7836ec6 = (uint)num;
			return new xfbab8f66e7836ec4[2] { xfbab8f66e7836ec5, xfbab8f66e7836ec6 };
		}

		internal static xfbab8f66e7836ec4[] x8b0176a5091f95ec(xfbab8f66e7836ec4 x83e17d59cce46549, xfbab8f66e7836ec4 xb6a214d6bebb5fe1)
		{
			if (x65a184a150825e58(x83e17d59cce46549, xb6a214d6bebb5fe1) == x0428c55343267861.xef19f5be66d2e2e3)
			{
				return new xfbab8f66e7836ec4[2]
				{
					0,
					new xfbab8f66e7836ec4(x83e17d59cce46549)
				};
			}
			x83e17d59cce46549.x234d65249b8ddf72();
			xb6a214d6bebb5fe1.x234d65249b8ddf72();
			if (xb6a214d6bebb5fe1.x961016a387451f05 == 1)
			{
				return xf7a471d0787a2d87(x83e17d59cce46549, xb6a214d6bebb5fe1.x4a3f0a05c02f235f[0]);
			}
			uint num = x83e17d59cce46549.x961016a387451f05 + 1;
			int num2 = (int)(xb6a214d6bebb5fe1.x961016a387451f05 + 1);
			uint num3 = 2147483648u;
			uint num4 = xb6a214d6bebb5fe1.x4a3f0a05c02f235f[xb6a214d6bebb5fe1.x961016a387451f05 - 1];
			int num5 = 0;
			int num6 = (int)(x83e17d59cce46549.x961016a387451f05 - xb6a214d6bebb5fe1.x961016a387451f05);
			while (num3 != 0 && (num4 & num3) == 0)
			{
				num5++;
				num3 >>= 1;
			}
			xfbab8f66e7836ec4 xfbab8f66e7836ec5 = new xfbab8f66e7836ec4(x0428c55343267861.x7eefbac090024714, x83e17d59cce46549.x961016a387451f05 - xb6a214d6bebb5fe1.x961016a387451f05 + 1);
			xfbab8f66e7836ec4 xfbab8f66e7836ec6 = x83e17d59cce46549 << num5;
			uint[] x4a3f0a05c02f235f = xfbab8f66e7836ec6.x4a3f0a05c02f235f;
			xb6a214d6bebb5fe1 <<= num5;
			int num7 = (int)(num - xb6a214d6bebb5fe1.x961016a387451f05);
			int num8 = (int)(num - 1);
			uint num9 = xb6a214d6bebb5fe1.x4a3f0a05c02f235f[xb6a214d6bebb5fe1.x961016a387451f05 - 1];
			ulong num10 = xb6a214d6bebb5fe1.x4a3f0a05c02f235f[xb6a214d6bebb5fe1.x961016a387451f05 - 2];
			while (num7 > 0)
			{
				ulong num11 = ((ulong)x4a3f0a05c02f235f[num8] << 32) + x4a3f0a05c02f235f[num8 - 1];
				ulong num12 = num11 / num9;
				ulong num13 = num11 % num9;
				while (num12 == 4294967296L || num12 * num10 > (num13 << 32) + x4a3f0a05c02f235f[num8 - 2])
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
					num16 += (ulong)((long)xb6a214d6bebb5fe1.x4a3f0a05c02f235f[num14] * (long)num17);
					uint num18 = x4a3f0a05c02f235f[num15];
					x4a3f0a05c02f235f[num15] -= (uint)(int)num16;
					num16 >>= 32;
					if (x4a3f0a05c02f235f[num15] > num18)
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
						num19 = (ulong)((long)x4a3f0a05c02f235f[num15] + (long)xb6a214d6bebb5fe1.x4a3f0a05c02f235f[num14]) + num19;
						x4a3f0a05c02f235f[num15] = (uint)num19;
						num19 >>= 32;
						num14++;
						num15++;
					}
					while (num14 < num2);
				}
				xfbab8f66e7836ec5.x4a3f0a05c02f235f[num6--] = num17;
				num8--;
				num7--;
			}
			xfbab8f66e7836ec5.x234d65249b8ddf72();
			xfbab8f66e7836ec6.x234d65249b8ddf72();
			xfbab8f66e7836ec4[] array = new xfbab8f66e7836ec4[2] { xfbab8f66e7836ec5, xfbab8f66e7836ec6 };
			if (num5 != 0)
			{
				xfbab8f66e7836ec4[] array2;
				(array2 = array)[1] = array2[1] >> num5;
			}
			return array;
		}

		internal static xfbab8f66e7836ec4 x4fb449897de89253(xfbab8f66e7836ec4 x964c723926ccb863, int x57e9faf3ffdc07cc)
		{
			if (x57e9faf3ffdc07cc == 0)
			{
				return new xfbab8f66e7836ec4(x964c723926ccb863, x964c723926ccb863.x961016a387451f05 + 1);
			}
			int num = x57e9faf3ffdc07cc >> 5;
			x57e9faf3ffdc07cc &= 0x1F;
			xfbab8f66e7836ec4 xfbab8f66e7836ec5 = new xfbab8f66e7836ec4(x0428c55343267861.x7eefbac090024714, x964c723926ccb863.x961016a387451f05 + 1 + (uint)num);
			uint num2 = 0u;
			uint x961016a387451f = x964c723926ccb863.x961016a387451f05;
			if (x57e9faf3ffdc07cc != 0)
			{
				uint num3 = 0u;
				for (; num2 < x961016a387451f; num2++)
				{
					uint num4 = x964c723926ccb863.x4a3f0a05c02f235f[num2];
					xfbab8f66e7836ec5.x4a3f0a05c02f235f[num2 + num] = (num4 << x57e9faf3ffdc07cc) | num3;
					num3 = num4 >> 32 - x57e9faf3ffdc07cc;
				}
				xfbab8f66e7836ec5.x4a3f0a05c02f235f[num2 + num] = num3;
			}
			else
			{
				for (; num2 < x961016a387451f; num2++)
				{
					xfbab8f66e7836ec5.x4a3f0a05c02f235f[num2 + num] = x964c723926ccb863.x4a3f0a05c02f235f[num2];
				}
			}
			xfbab8f66e7836ec5.x234d65249b8ddf72();
			return xfbab8f66e7836ec5;
		}

		internal static xfbab8f66e7836ec4 xae826207151e41b5(xfbab8f66e7836ec4 x964c723926ccb863, int x57e9faf3ffdc07cc)
		{
			if (x57e9faf3ffdc07cc == 0)
			{
				return new xfbab8f66e7836ec4(x964c723926ccb863);
			}
			int num = x57e9faf3ffdc07cc >> 5;
			int num2 = x57e9faf3ffdc07cc & 0x1F;
			xfbab8f66e7836ec4 xfbab8f66e7836ec5 = new xfbab8f66e7836ec4(x0428c55343267861.x7eefbac090024714, (uint)((int)x964c723926ccb863.x961016a387451f05 - num + 1));
			uint num3 = (uint)(xfbab8f66e7836ec5.x4a3f0a05c02f235f.Length - 1);
			if (num2 != 0)
			{
				uint num4 = 0u;
				while (num3-- != 0)
				{
					uint num5 = x964c723926ccb863.x4a3f0a05c02f235f[num3 + num];
					xfbab8f66e7836ec5.x4a3f0a05c02f235f[num3] = (num5 >> x57e9faf3ffdc07cc) | num4;
					num4 = num5 << 32 - x57e9faf3ffdc07cc;
				}
			}
			else
			{
				while (num3-- != 0)
				{
					xfbab8f66e7836ec5.x4a3f0a05c02f235f[num3] = x964c723926ccb863.x4a3f0a05c02f235f[num3 + num];
				}
			}
			xfbab8f66e7836ec5.x234d65249b8ddf72();
			return xfbab8f66e7836ec5;
		}

		internal static xfbab8f66e7836ec4 x097f7d3fb1f122b6(xfbab8f66e7836ec4 x57e9faf3ffdc07cc, uint x0078185e1040c523)
		{
			xfbab8f66e7836ec4 xfbab8f66e7836ec5 = new xfbab8f66e7836ec4(x0428c55343267861.x7eefbac090024714, x57e9faf3ffdc07cc.x961016a387451f05 + 1);
			uint num = 0u;
			ulong num2 = 0uL;
			do
			{
				num2 += (ulong)((long)x57e9faf3ffdc07cc.x4a3f0a05c02f235f[num] * (long)x0078185e1040c523);
				xfbab8f66e7836ec5.x4a3f0a05c02f235f[num] = (uint)num2;
				num2 >>= 32;
			}
			while (++num < x57e9faf3ffdc07cc.x961016a387451f05);
			xfbab8f66e7836ec5.x4a3f0a05c02f235f[num] = (uint)num2;
			xfbab8f66e7836ec5.x234d65249b8ddf72();
			return xfbab8f66e7836ec5;
		}

		internal static void x490e30087768649f(uint[] x08db3aeabb253cb1, uint xf79f95b297b243b5, uint x583b6f4f8dd40701, uint[] x1e218ceaee1bb583, uint x77628737d203d4ed, uint x7410b7d3d0ded557, uint[] x73f821c71fe1e676, uint x761870faa889ee7e)
		{
			uint num = xf79f95b297b243b5;
			uint num2 = num + x583b6f4f8dd40701;
			uint num3 = x77628737d203d4ed + x7410b7d3d0ded557;
			uint num4 = x761870faa889ee7e;
			while (num < num2)
			{
				if (x08db3aeabb253cb1[num] != 0)
				{
					ulong num5 = 0uL;
					uint num6 = num4;
					uint num7 = x77628737d203d4ed;
					while (num7 < num3)
					{
						num5 += (ulong)((long)x08db3aeabb253cb1[num] * (long)x1e218ceaee1bb583[num7] + x73f821c71fe1e676[num6]);
						x73f821c71fe1e676[num6] = (uint)num5;
						num5 >>= 32;
						num7++;
						num6++;
					}
					if (num5 != 0)
					{
						x73f821c71fe1e676[num6] = (uint)num5;
					}
				}
				num++;
				num4++;
			}
		}

		internal static void x38eb6984d015b78b(uint[] x08db3aeabb253cb1, int xf79f95b297b243b5, int x583b6f4f8dd40701, uint[] x1e218ceaee1bb583, int x050aedc828fd6dd5, int x7410b7d3d0ded557, uint[] x73f821c71fe1e676, int x761870faa889ee7e, int xd898a9899e5968e9)
		{
			uint num = (uint)xf79f95b297b243b5;
			uint num2 = num + (uint)x583b6f4f8dd40701;
			uint num3 = (uint)(x050aedc828fd6dd5 + x7410b7d3d0ded557);
			uint num4 = (uint)x761870faa889ee7e;
			uint num5 = num4 + (uint)xd898a9899e5968e9;
			while (num < num2)
			{
				if (x08db3aeabb253cb1[num] != 0)
				{
					ulong num6 = 0uL;
					uint num7 = num4;
					uint num8 = (uint)x050aedc828fd6dd5;
					while (num8 < num3 && num7 < num5)
					{
						num6 += (ulong)((long)x08db3aeabb253cb1[num] * (long)x1e218ceaee1bb583[num8] + x73f821c71fe1e676[num7]);
						x73f821c71fe1e676[num7] = (uint)num6;
						num6 >>= 32;
						num8++;
						num7++;
					}
					if (num6 != 0 && num7 < num5)
					{
						x73f821c71fe1e676[num7] = (uint)num6;
					}
				}
				num++;
				num4++;
			}
		}

		internal static void x17f371c79aa1b0e5(xfbab8f66e7836ec4 x964c723926ccb863, ref uint[] x3dc6e5e61b7653fc)
		{
			uint[] array = x3dc6e5e61b7653fc;
			x3dc6e5e61b7653fc = x964c723926ccb863.x4a3f0a05c02f235f;
			uint[] x4a3f0a05c02f235f = x964c723926ccb863.x4a3f0a05c02f235f;
			uint x961016a387451f = x964c723926ccb863.x961016a387451f05;
			x964c723926ccb863.x4a3f0a05c02f235f = array;
			uint num = (uint)array.Length;
			for (uint num2 = 0u; num2 < num; num2++)
			{
				array[num2] = 0u;
			}
			uint num3 = 0u;
			uint num4 = 0u;
			uint num5 = 0u;
			while (num5 < x961016a387451f)
			{
				if (x4a3f0a05c02f235f[num3] != 0)
				{
					ulong num6 = 0uL;
					uint num7 = x4a3f0a05c02f235f[num3];
					uint num8 = num3 + 1;
					uint num9 = num4 + 2 * num5 + 1;
					uint num10 = num5 + 1;
					while (num10 < x961016a387451f)
					{
						num6 += (ulong)((long)num7 * (long)x4a3f0a05c02f235f[num8] + array[num9]);
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
			uint num13 = num3 + x961016a387451f;
			while (num3 < num13)
			{
				ulong num14 = (ulong)((long)x4a3f0a05c02f235f[num3] * (long)x4a3f0a05c02f235f[num3] + array[num4]);
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
			x964c723926ccb863.x961016a387451f05 <<= 1;
			while (array[x964c723926ccb863.x961016a387451f05 - 1] == 0 && x964c723926ccb863.x961016a387451f05 > 1)
			{
				x964c723926ccb863.x961016a387451f05--;
			}
		}

		internal static xfbab8f66e7836ec4 x96c37bb6e3c6d2ab(xfbab8f66e7836ec4 x19218ffab70283ef, xfbab8f66e7836ec4 xe7ebe10fa44d8d49)
		{
			xfbab8f66e7836ec4 xfbab8f66e7836ec5 = x19218ffab70283ef;
			xfbab8f66e7836ec4 xfbab8f66e7836ec6 = xe7ebe10fa44d8d49;
			xfbab8f66e7836ec4 xfbab8f66e7836ec7 = xfbab8f66e7836ec6;
			while (xfbab8f66e7836ec5.x961016a387451f05 > 1)
			{
				xfbab8f66e7836ec7 = xfbab8f66e7836ec5;
				xfbab8f66e7836ec5 = xfbab8f66e7836ec6 % xfbab8f66e7836ec5;
				xfbab8f66e7836ec6 = xfbab8f66e7836ec7;
			}
			if (xfbab8f66e7836ec5 == 0u)
			{
				return xfbab8f66e7836ec7;
			}
			uint num = xfbab8f66e7836ec5.x4a3f0a05c02f235f[0];
			uint num2 = xfbab8f66e7836ec6 % num;
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
			return num << num3;
		}

		internal static uint xfdbbb9032ceea877(xfbab8f66e7836ec4 x964c723926ccb863, uint xa6a81c8dae265da2)
		{
			uint num = xa6a81c8dae265da2;
			uint num2 = x964c723926ccb863 % xa6a81c8dae265da2;
			uint num3 = 0u;
			uint num4 = 1u;
			while (true)
			{
				switch (num2)
				{
				case 1u:
					return num4;
				default:
					num3 += num / num2 * num4;
					num %= num2;
					switch (num)
					{
					case 1u:
						return xa6a81c8dae265da2 - num3;
					default:
						goto IL_002d;
					case 0u:
						break;
					}
					break;
				case 0u:
					break;
				}
				break;
				IL_002d:
				num4 += num2 / num * num3;
				num2 %= num;
			}
			return 0u;
		}

		internal static xfbab8f66e7836ec4 xfdbbb9032ceea877(xfbab8f66e7836ec4 x964c723926ccb863, xfbab8f66e7836ec4 xa6a81c8dae265da2)
		{
			if (xa6a81c8dae265da2.x961016a387451f05 == 1)
			{
				return xfdbbb9032ceea877(x964c723926ccb863, xa6a81c8dae265da2.x4a3f0a05c02f235f[0]);
			}
			xfbab8f66e7836ec4[] array = new xfbab8f66e7836ec4[2] { 0, 1 };
			xfbab8f66e7836ec4[] array2 = new xfbab8f66e7836ec4[2];
			xfbab8f66e7836ec4[] array3 = new xfbab8f66e7836ec4[2] { 0, 0 };
			int num = 0;
			xfbab8f66e7836ec4 x83e17d59cce = xa6a81c8dae265da2;
			xfbab8f66e7836ec4 xfbab8f66e7836ec5 = x964c723926ccb863;
			xb8d5596088d00dcf xb8d5596088d00dcf = new xb8d5596088d00dcf(xa6a81c8dae265da2);
			while (xfbab8f66e7836ec5 != 0u)
			{
				if (num > 1)
				{
					xfbab8f66e7836ec4 xfbab8f66e7836ec6 = xb8d5596088d00dcf.x1b8503421974b759(array[0], array[1] * array2[0]);
					array[0] = array[1];
					array[1] = xfbab8f66e7836ec6;
				}
				xfbab8f66e7836ec4[] array4 = x8b0176a5091f95ec(x83e17d59cce, xfbab8f66e7836ec5);
				array2[0] = array2[1];
				array2[1] = array4[0];
				array3[0] = array3[1];
				array3[1] = array4[1];
				x83e17d59cce = xfbab8f66e7836ec5;
				xfbab8f66e7836ec5 = array4[1];
				num++;
			}
			if (array3[0] != 1u)
			{
				throw new ArithmeticException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jhnohjepfelplicanijacjabohhbiiobgifcfhmcocdd", 1770253611)));
			}
			return xb8d5596088d00dcf.x1b8503421974b759(array[0], array[1] * array2[0]);
		}
	}

	internal class xb8d5596088d00dcf
	{
		private xfbab8f66e7836ec4 xd898a9899e5968e9;

		private xfbab8f66e7836ec4 xb4480c8b340110b9;

		internal xb8d5596088d00dcf(xfbab8f66e7836ec4 modulus)
		{
			xd898a9899e5968e9 = modulus;
			uint num = xd898a9899e5968e9.x961016a387451f05 << 1;
			xb4480c8b340110b9 = new xfbab8f66e7836ec4(x0428c55343267861.x7eefbac090024714, num + 1);
			xb4480c8b340110b9.x4a3f0a05c02f235f[num] = 1u;
			xb4480c8b340110b9 /= xd898a9899e5968e9;
		}

		internal void x3b98b3ef59bad1ac(xfbab8f66e7836ec4 x08db3aeabb253cb1)
		{
			xfbab8f66e7836ec4 xfbab8f66e7836ec5 = xd898a9899e5968e9;
			uint x961016a387451f = xfbab8f66e7836ec5.x961016a387451f05;
			uint num = x961016a387451f + 1;
			uint num2 = x961016a387451f - 1;
			if (x08db3aeabb253cb1.x961016a387451f05 >= x961016a387451f)
			{
				if (x08db3aeabb253cb1.x4a3f0a05c02f235f.Length < x08db3aeabb253cb1.x961016a387451f05)
				{
					throw new IndexOutOfRangeException("x out of range");
				}
				xfbab8f66e7836ec4 xfbab8f66e7836ec6 = new xfbab8f66e7836ec4(x0428c55343267861.x7eefbac090024714, x08db3aeabb253cb1.x961016a387451f05 - num2 + xb4480c8b340110b9.x961016a387451f05);
				xf094e3229d63c9be.x490e30087768649f(x08db3aeabb253cb1.x4a3f0a05c02f235f, num2, x08db3aeabb253cb1.x961016a387451f05 - num2, xb4480c8b340110b9.x4a3f0a05c02f235f, 0u, xb4480c8b340110b9.x961016a387451f05, xfbab8f66e7836ec6.x4a3f0a05c02f235f, 0u);
				uint x961016a387451f2 = ((x08db3aeabb253cb1.x961016a387451f05 > num) ? num : x08db3aeabb253cb1.x961016a387451f05);
				x08db3aeabb253cb1.x961016a387451f05 = x961016a387451f2;
				x08db3aeabb253cb1.x234d65249b8ddf72();
				xfbab8f66e7836ec4 xfbab8f66e7836ec7 = new xfbab8f66e7836ec4(x0428c55343267861.x7eefbac090024714, num);
				xf094e3229d63c9be.x38eb6984d015b78b(xfbab8f66e7836ec6.x4a3f0a05c02f235f, (int)num, (int)(xfbab8f66e7836ec6.x961016a387451f05 - num), xfbab8f66e7836ec5.x4a3f0a05c02f235f, 0, (int)xfbab8f66e7836ec5.x961016a387451f05, xfbab8f66e7836ec7.x4a3f0a05c02f235f, 0, (int)num);
				xfbab8f66e7836ec7.x234d65249b8ddf72();
				if (xfbab8f66e7836ec7 <= x08db3aeabb253cb1)
				{
					xf094e3229d63c9be.x4fead14d15bab3b0(x08db3aeabb253cb1, xfbab8f66e7836ec7);
				}
				else
				{
					xfbab8f66e7836ec4 xfbab8f66e7836ec8 = new xfbab8f66e7836ec4(x0428c55343267861.x7eefbac090024714, num + 1);
					xfbab8f66e7836ec8.x4a3f0a05c02f235f[num] = 1u;
					xf094e3229d63c9be.x4fead14d15bab3b0(xfbab8f66e7836ec8, xfbab8f66e7836ec7);
					xf094e3229d63c9be.xd2474061571ed9e3(x08db3aeabb253cb1, xfbab8f66e7836ec8);
				}
				while (x08db3aeabb253cb1 >= xfbab8f66e7836ec5)
				{
					xf094e3229d63c9be.x4fead14d15bab3b0(x08db3aeabb253cb1, xfbab8f66e7836ec5);
				}
			}
		}

		internal xfbab8f66e7836ec4 x490e30087768649f(xfbab8f66e7836ec4 x19218ffab70283ef, xfbab8f66e7836ec4 xe7ebe10fa44d8d49)
		{
			if (x19218ffab70283ef == 0u || xe7ebe10fa44d8d49 == 0u)
			{
				return 0;
			}
			if (x19218ffab70283ef.x961016a387451f05 >= xd898a9899e5968e9.x961016a387451f05 << 1)
			{
				x19218ffab70283ef %= xd898a9899e5968e9;
			}
			if (xe7ebe10fa44d8d49.x961016a387451f05 >= xd898a9899e5968e9.x961016a387451f05 << 1)
			{
				xe7ebe10fa44d8d49 %= xd898a9899e5968e9;
			}
			if (x19218ffab70283ef.x961016a387451f05 >= xd898a9899e5968e9.x961016a387451f05)
			{
				x3b98b3ef59bad1ac(x19218ffab70283ef);
			}
			if (xe7ebe10fa44d8d49.x961016a387451f05 >= xd898a9899e5968e9.x961016a387451f05)
			{
				x3b98b3ef59bad1ac(xe7ebe10fa44d8d49);
			}
			xfbab8f66e7836ec4 xfbab8f66e7836ec5 = new xfbab8f66e7836ec4(x19218ffab70283ef * xe7ebe10fa44d8d49);
			x3b98b3ef59bad1ac(xfbab8f66e7836ec5);
			return xfbab8f66e7836ec5;
		}

		internal xfbab8f66e7836ec4 x1b8503421974b759(xfbab8f66e7836ec4 x19218ffab70283ef, xfbab8f66e7836ec4 xe7ebe10fa44d8d49)
		{
			x0428c55343267861 x0428c55343267861 = xf094e3229d63c9be.x65a184a150825e58(x19218ffab70283ef, xe7ebe10fa44d8d49);
			xfbab8f66e7836ec4 xfbab8f66e7836ec5;
			switch (x0428c55343267861)
			{
			case x0428c55343267861.x67cf982b3c9c2bb6:
				return 0;
			case x0428c55343267861.x7eefbac090024714:
				xfbab8f66e7836ec5 = x19218ffab70283ef - xe7ebe10fa44d8d49;
				break;
			case x0428c55343267861.xef19f5be66d2e2e3:
				xfbab8f66e7836ec5 = xe7ebe10fa44d8d49 - x19218ffab70283ef;
				break;
			default:
				throw new InvalidOperationException();
			}
			if (xfbab8f66e7836ec5 >= xd898a9899e5968e9)
			{
				if (xfbab8f66e7836ec5.x961016a387451f05 >= xd898a9899e5968e9.x961016a387451f05 << 1)
				{
					xfbab8f66e7836ec5 %= xd898a9899e5968e9;
				}
				else
				{
					x3b98b3ef59bad1ac(xfbab8f66e7836ec5);
				}
			}
			if (x0428c55343267861 == x0428c55343267861.xef19f5be66d2e2e3)
			{
				xfbab8f66e7836ec5 = xd898a9899e5968e9 - xfbab8f66e7836ec5;
			}
			return xfbab8f66e7836ec5;
		}

		internal xfbab8f66e7836ec4 xde4af47ac20ddf00(xfbab8f66e7836ec4 xe7ebe10fa44d8d49, xfbab8f66e7836ec4 xd0072e8aa8c1411e)
		{
			if ((xd898a9899e5968e9.x4a3f0a05c02f235f[0] & 1) == 1)
			{
				return x394fc4154aba7257(xe7ebe10fa44d8d49, xd0072e8aa8c1411e);
			}
			return xf6f1f6aadf400835(xe7ebe10fa44d8d49, xd0072e8aa8c1411e);
		}

		internal xfbab8f66e7836ec4 xf6f1f6aadf400835(xfbab8f66e7836ec4 xe7ebe10fa44d8d49, xfbab8f66e7836ec4 xd0072e8aa8c1411e)
		{
			xfbab8f66e7836ec4 xfbab8f66e7836ec5 = new xfbab8f66e7836ec4(1, xd898a9899e5968e9.x961016a387451f05 << 1);
			xfbab8f66e7836ec4 xfbab8f66e7836ec6 = new xfbab8f66e7836ec4(xe7ebe10fa44d8d49 % xd898a9899e5968e9, xd898a9899e5968e9.x961016a387451f05 << 1);
			uint num = (uint)xd0072e8aa8c1411e.xce53a4f2835cab70();
			uint[] x3dc6e5e61b7653fc = new uint[xd898a9899e5968e9.x961016a387451f05 << 1];
			for (uint num2 = 0u; num2 < num; num2++)
			{
				if (xd0072e8aa8c1411e.xa81774f8089149a3(num2))
				{
					Array.Clear(x3dc6e5e61b7653fc, 0, x3dc6e5e61b7653fc.Length);
					xf094e3229d63c9be.x490e30087768649f(xfbab8f66e7836ec5.x4a3f0a05c02f235f, 0u, xfbab8f66e7836ec5.x961016a387451f05, xfbab8f66e7836ec6.x4a3f0a05c02f235f, 0u, xfbab8f66e7836ec6.x961016a387451f05, x3dc6e5e61b7653fc, 0u);
					xfbab8f66e7836ec5.x961016a387451f05 += xfbab8f66e7836ec6.x961016a387451f05;
					uint[] x4a3f0a05c02f235f = x3dc6e5e61b7653fc;
					x3dc6e5e61b7653fc = xfbab8f66e7836ec5.x4a3f0a05c02f235f;
					xfbab8f66e7836ec5.x4a3f0a05c02f235f = x4a3f0a05c02f235f;
					x3b98b3ef59bad1ac(xfbab8f66e7836ec5);
				}
				xf094e3229d63c9be.x17f371c79aa1b0e5(xfbab8f66e7836ec6, ref x3dc6e5e61b7653fc);
				x3b98b3ef59bad1ac(xfbab8f66e7836ec6);
				if (xfbab8f66e7836ec6 == 1u)
				{
					return xfbab8f66e7836ec5;
				}
			}
			return xfbab8f66e7836ec5;
		}

		private xfbab8f66e7836ec4 x394fc4154aba7257(xfbab8f66e7836ec4 xe7ebe10fa44d8d49, xfbab8f66e7836ec4 xd0072e8aa8c1411e)
		{
			xfbab8f66e7836ec4 xfbab8f66e7836ec5 = new xfbab8f66e7836ec4(x22a46bee8ab1684d.x58e8ab61356bb84d(1, xd898a9899e5968e9), xd898a9899e5968e9.x961016a387451f05 << 1);
			xfbab8f66e7836ec4 xfbab8f66e7836ec6 = new xfbab8f66e7836ec4(x22a46bee8ab1684d.x58e8ab61356bb84d(xe7ebe10fa44d8d49, xd898a9899e5968e9), xd898a9899e5968e9.x961016a387451f05 << 1);
			uint x1f67e69de6ee550a = x22a46bee8ab1684d.xa41fedd4c438435d(xd898a9899e5968e9.x4a3f0a05c02f235f[0]);
			uint num = (uint)xd0072e8aa8c1411e.xce53a4f2835cab70();
			uint[] x3dc6e5e61b7653fc = new uint[xd898a9899e5968e9.x961016a387451f05 << 1];
			for (uint num2 = 0u; num2 < num; num2++)
			{
				if (xd0072e8aa8c1411e.xa81774f8089149a3(num2))
				{
					Array.Clear(x3dc6e5e61b7653fc, 0, x3dc6e5e61b7653fc.Length);
					xf094e3229d63c9be.x490e30087768649f(xfbab8f66e7836ec5.x4a3f0a05c02f235f, 0u, xfbab8f66e7836ec5.x961016a387451f05, xfbab8f66e7836ec6.x4a3f0a05c02f235f, 0u, xfbab8f66e7836ec6.x961016a387451f05, x3dc6e5e61b7653fc, 0u);
					xfbab8f66e7836ec5.x961016a387451f05 += xfbab8f66e7836ec6.x961016a387451f05;
					uint[] x4a3f0a05c02f235f = x3dc6e5e61b7653fc;
					x3dc6e5e61b7653fc = xfbab8f66e7836ec5.x4a3f0a05c02f235f;
					xfbab8f66e7836ec5.x4a3f0a05c02f235f = x4a3f0a05c02f235f;
					x22a46bee8ab1684d.xfd0f13bde0e1e0ba(xfbab8f66e7836ec5, xd898a9899e5968e9, x1f67e69de6ee550a);
				}
				xf094e3229d63c9be.x17f371c79aa1b0e5(xfbab8f66e7836ec6, ref x3dc6e5e61b7653fc);
				x22a46bee8ab1684d.xfd0f13bde0e1e0ba(xfbab8f66e7836ec6, xd898a9899e5968e9, x1f67e69de6ee550a);
			}
			x22a46bee8ab1684d.xfd0f13bde0e1e0ba(xfbab8f66e7836ec5, xd898a9899e5968e9, x1f67e69de6ee550a);
			return xfbab8f66e7836ec5;
		}

		internal xfbab8f66e7836ec4 xde4af47ac20ddf00(uint xe7ebe10fa44d8d49, xfbab8f66e7836ec4 xd0072e8aa8c1411e)
		{
			if ((xd898a9899e5968e9.x4a3f0a05c02f235f[0] & 1) == 1)
			{
				return x394fc4154aba7257(xe7ebe10fa44d8d49, xd0072e8aa8c1411e);
			}
			return xf6f1f6aadf400835(xe7ebe10fa44d8d49, xd0072e8aa8c1411e);
		}

		private xfbab8f66e7836ec4 x394fc4154aba7257(uint xe7ebe10fa44d8d49, xfbab8f66e7836ec4 xd0072e8aa8c1411e)
		{
			xd0072e8aa8c1411e.x234d65249b8ddf72();
			uint[] x3dc6e5e61b7653fc = new uint[xd898a9899e5968e9.x961016a387451f05 << 2];
			xfbab8f66e7836ec4 bi = x22a46bee8ab1684d.x58e8ab61356bb84d(xe7ebe10fa44d8d49, xd898a9899e5968e9);
			bi = new xfbab8f66e7836ec4(bi, xd898a9899e5968e9.x961016a387451f05 << 2);
			uint x1f67e69de6ee550a = x22a46bee8ab1684d.xa41fedd4c438435d(xd898a9899e5968e9.x4a3f0a05c02f235f[0]);
			uint x44805ecd38ad2dab = (uint)(xd0072e8aa8c1411e.xce53a4f2835cab70() - 2);
			do
			{
				xf094e3229d63c9be.x17f371c79aa1b0e5(bi, ref x3dc6e5e61b7653fc);
				bi = x22a46bee8ab1684d.xfd0f13bde0e1e0ba(bi, xd898a9899e5968e9, x1f67e69de6ee550a);
				if (!xd0072e8aa8c1411e.xa81774f8089149a3(x44805ecd38ad2dab))
				{
					continue;
				}
				uint[] x4a3f0a05c02f235f = bi.x4a3f0a05c02f235f;
				uint num = 0u;
				ulong num2 = 0uL;
				do
				{
					num2 += (ulong)((long)x4a3f0a05c02f235f[num] * (long)xe7ebe10fa44d8d49);
					x4a3f0a05c02f235f[num] = (uint)num2;
					num2 >>= 32;
				}
				while (++num < bi.x961016a387451f05);
				if (bi.x961016a387451f05 < xd898a9899e5968e9.x961016a387451f05)
				{
					if (num2 != 0)
					{
						x4a3f0a05c02f235f[num] = (uint)num2;
						bi.x961016a387451f05++;
						while (bi >= xd898a9899e5968e9)
						{
							xf094e3229d63c9be.x4fead14d15bab3b0(bi, xd898a9899e5968e9);
						}
					}
				}
				else if (num2 != 0)
				{
					uint num3 = (uint)num2;
					uint num4 = (uint)((xd898a9899e5968e9.x4a3f0a05c02f235f[xd898a9899e5968e9.x961016a387451f05 - 1] >= uint.MaxValue) ? ((((ulong)num3 << 32) | x4a3f0a05c02f235f[num - 1]) / xd898a9899e5968e9.x4a3f0a05c02f235f[xd898a9899e5968e9.x961016a387451f05 - 1]) : ((((ulong)num3 << 32) | x4a3f0a05c02f235f[num - 1]) / (xd898a9899e5968e9.x4a3f0a05c02f235f[xd898a9899e5968e9.x961016a387451f05 - 1] + 1)));
					num = 0u;
					num2 = 0uL;
					do
					{
						num2 += (ulong)((long)xd898a9899e5968e9.x4a3f0a05c02f235f[num] * (long)num4);
						uint num5 = x4a3f0a05c02f235f[num];
						x4a3f0a05c02f235f[num] -= (uint)(int)num2;
						num2 >>= 32;
						if (x4a3f0a05c02f235f[num] > num5)
						{
							num2++;
						}
						num++;
					}
					while (num < bi.x961016a387451f05);
					num3 -= (uint)(int)num2;
					if (num3 != 0)
					{
						uint num6 = 0u;
						uint num7 = 0u;
						uint[] x4a3f0a05c02f235f2 = xd898a9899e5968e9.x4a3f0a05c02f235f;
						do
						{
							uint num8 = x4a3f0a05c02f235f2[num7];
							num6 = ((((num8 += num6) < num6) | ((x4a3f0a05c02f235f[num7] -= num8) > ~num8)) ? 1u : 0u);
							num7++;
						}
						while (num7 < bi.x961016a387451f05);
						num3 -= num6;
					}
					while (bi >= xd898a9899e5968e9)
					{
						xf094e3229d63c9be.x4fead14d15bab3b0(bi, xd898a9899e5968e9);
					}
				}
				else
				{
					while (bi >= xd898a9899e5968e9)
					{
						xf094e3229d63c9be.x4fead14d15bab3b0(bi, xd898a9899e5968e9);
					}
				}
			}
			while (x44805ecd38ad2dab-- != 0);
			return x22a46bee8ab1684d.xfd0f13bde0e1e0ba(bi, xd898a9899e5968e9, x1f67e69de6ee550a);
		}

		private xfbab8f66e7836ec4 xf6f1f6aadf400835(uint xe7ebe10fa44d8d49, xfbab8f66e7836ec4 xd0072e8aa8c1411e)
		{
			xd0072e8aa8c1411e.x234d65249b8ddf72();
			uint[] x3dc6e5e61b7653fc = new uint[xd898a9899e5968e9.x961016a387451f05 << 2];
			xfbab8f66e7836ec4 xfbab8f66e7836ec5 = new xfbab8f66e7836ec4(xe7ebe10fa44d8d49, xd898a9899e5968e9.x961016a387451f05 << 2);
			uint x44805ecd38ad2dab = (uint)(xd0072e8aa8c1411e.xce53a4f2835cab70() - 2);
			do
			{
				xf094e3229d63c9be.x17f371c79aa1b0e5(xfbab8f66e7836ec5, ref x3dc6e5e61b7653fc);
				if (xfbab8f66e7836ec5.x961016a387451f05 >= xd898a9899e5968e9.x961016a387451f05)
				{
					x3b98b3ef59bad1ac(xfbab8f66e7836ec5);
				}
				if (!xd0072e8aa8c1411e.xa81774f8089149a3(x44805ecd38ad2dab))
				{
					continue;
				}
				uint[] x4a3f0a05c02f235f = xfbab8f66e7836ec5.x4a3f0a05c02f235f;
				uint num = 0u;
				ulong num2 = 0uL;
				do
				{
					num2 += (ulong)((long)x4a3f0a05c02f235f[num] * (long)xe7ebe10fa44d8d49);
					x4a3f0a05c02f235f[num] = (uint)num2;
					num2 >>= 32;
				}
				while (++num < xfbab8f66e7836ec5.x961016a387451f05);
				if (xfbab8f66e7836ec5.x961016a387451f05 < xd898a9899e5968e9.x961016a387451f05)
				{
					if (num2 != 0)
					{
						x4a3f0a05c02f235f[num] = (uint)num2;
						xfbab8f66e7836ec5.x961016a387451f05++;
						while (xfbab8f66e7836ec5 >= xd898a9899e5968e9)
						{
							xf094e3229d63c9be.x4fead14d15bab3b0(xfbab8f66e7836ec5, xd898a9899e5968e9);
						}
					}
				}
				else if (num2 != 0)
				{
					uint num3 = (uint)num2;
					uint num4 = (uint)((((ulong)num3 << 32) | x4a3f0a05c02f235f[num - 1]) / (xd898a9899e5968e9.x4a3f0a05c02f235f[xd898a9899e5968e9.x961016a387451f05 - 1] + 1));
					num = 0u;
					num2 = 0uL;
					do
					{
						num2 += (ulong)((long)xd898a9899e5968e9.x4a3f0a05c02f235f[num] * (long)num4);
						uint num5 = x4a3f0a05c02f235f[num];
						x4a3f0a05c02f235f[num] -= (uint)(int)num2;
						num2 >>= 32;
						if (x4a3f0a05c02f235f[num] > num5)
						{
							num2++;
						}
						num++;
					}
					while (num < xfbab8f66e7836ec5.x961016a387451f05);
					num3 -= (uint)(int)num2;
					if (num3 != 0)
					{
						uint num6 = 0u;
						uint num7 = 0u;
						uint[] x4a3f0a05c02f235f2 = xd898a9899e5968e9.x4a3f0a05c02f235f;
						do
						{
							uint num8 = x4a3f0a05c02f235f2[num7];
							num6 = ((((num8 += num6) < num6) | ((x4a3f0a05c02f235f[num7] -= num8) > ~num8)) ? 1u : 0u);
							num7++;
						}
						while (num7 < xfbab8f66e7836ec5.x961016a387451f05);
						num3 -= num6;
					}
					while (xfbab8f66e7836ec5 >= xd898a9899e5968e9)
					{
						xf094e3229d63c9be.x4fead14d15bab3b0(xfbab8f66e7836ec5, xd898a9899e5968e9);
					}
				}
				else
				{
					while (xfbab8f66e7836ec5 >= xd898a9899e5968e9)
					{
						xf094e3229d63c9be.x4fead14d15bab3b0(xfbab8f66e7836ec5, xd898a9899e5968e9);
					}
				}
			}
			while (x44805ecd38ad2dab-- != 0);
			return xfbab8f66e7836ec5;
		}
	}

	internal class x22a46bee8ab1684d
	{
		private x22a46bee8ab1684d()
		{
		}

		internal static uint xa41fedd4c438435d(uint x57e9faf3ffdc07cc)
		{
			uint num = x57e9faf3ffdc07cc;
			uint num2;
			while ((num2 = x57e9faf3ffdc07cc * num) != 1)
			{
				num *= 2 - num2;
			}
			return (uint)(0uL - (ulong)num);
		}

		internal static xfbab8f66e7836ec4 x58e8ab61356bb84d(xfbab8f66e7836ec4 x57e9faf3ffdc07cc, xfbab8f66e7836ec4 x6088325dec1baa2a)
		{
			x57e9faf3ffdc07cc.x234d65249b8ddf72();
			x6088325dec1baa2a.x234d65249b8ddf72();
			x57e9faf3ffdc07cc <<= (int)(x6088325dec1baa2a.x961016a387451f05 * 32);
			x57e9faf3ffdc07cc %= x6088325dec1baa2a;
			return x57e9faf3ffdc07cc;
		}

		internal static xfbab8f66e7836ec4 xfd0f13bde0e1e0ba(xfbab8f66e7836ec4 x57e9faf3ffdc07cc, xfbab8f66e7836ec4 x6088325dec1baa2a, uint x1f67e69de6ee550a)
		{
			uint[] x4a3f0a05c02f235f = x57e9faf3ffdc07cc.x4a3f0a05c02f235f;
			uint[] x4a3f0a05c02f235f2 = x6088325dec1baa2a.x4a3f0a05c02f235f;
			for (uint num = 0u; num < x6088325dec1baa2a.x961016a387451f05; num++)
			{
				uint num2 = x4a3f0a05c02f235f[0] * x1f67e69de6ee550a;
				uint num3 = 0u;
				uint num4 = 0u;
				uint num5 = 0u;
				ulong num6 = (ulong)((long)num2 * (long)x4a3f0a05c02f235f2[num3++] + x4a3f0a05c02f235f[num4++]);
				num6 >>= 32;
				uint num7;
				for (num7 = 1u; num7 < x6088325dec1baa2a.x961016a387451f05; num7++)
				{
					num6 += (ulong)((long)num2 * (long)x4a3f0a05c02f235f2[num3++] + x4a3f0a05c02f235f[num4++]);
					x4a3f0a05c02f235f[num5++] = (uint)num6;
					num6 >>= 32;
				}
				for (; num7 < x57e9faf3ffdc07cc.x961016a387451f05; num7++)
				{
					num6 += x4a3f0a05c02f235f[num4++];
					x4a3f0a05c02f235f[num5++] = (uint)num6;
					num6 >>= 32;
					if (num6 == 0)
					{
						num7++;
						break;
					}
				}
				for (; num7 < x57e9faf3ffdc07cc.x961016a387451f05; num7++)
				{
					x4a3f0a05c02f235f[num5++] = x4a3f0a05c02f235f[num4++];
				}
				x4a3f0a05c02f235f[num5++] = (uint)num6;
			}
			while (x57e9faf3ffdc07cc.x961016a387451f05 > 1 && x4a3f0a05c02f235f[x57e9faf3ffdc07cc.x961016a387451f05 - 1] == 0)
			{
				x57e9faf3ffdc07cc.x961016a387451f05--;
			}
			if (x57e9faf3ffdc07cc >= x6088325dec1baa2a)
			{
				xf094e3229d63c9be.x4fead14d15bab3b0(x57e9faf3ffdc07cc, x6088325dec1baa2a);
			}
			return x57e9faf3ffdc07cc;
		}
	}

	private const uint x6d3d98329d6d189f = 20u;

	private const string x7e3abf487f8e7bc0 = "Operation would return a negative value";

	private uint x961016a387451f05 = 1u;

	private uint[] x4a3f0a05c02f235f;

	internal static readonly uint[] x62e7316e25cd3e4b = new uint[783]
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

	internal xfbab8f66e7836ec4()
	{
		x4a3f0a05c02f235f = new uint[20];
		x961016a387451f05 = 20u;
	}

	internal xfbab8f66e7836ec4(x0428c55343267861 sign, uint len)
	{
		x4a3f0a05c02f235f = new uint[len];
		x961016a387451f05 = len;
	}

	internal xfbab8f66e7836ec4(xfbab8f66e7836ec4 bi)
	{
		x4a3f0a05c02f235f = (uint[])bi.x4a3f0a05c02f235f.Clone();
		x961016a387451f05 = bi.x961016a387451f05;
	}

	internal xfbab8f66e7836ec4(xfbab8f66e7836ec4 bi, uint len)
	{
		x4a3f0a05c02f235f = new uint[len];
		for (uint num = 0u; num < bi.x961016a387451f05; num++)
		{
			x4a3f0a05c02f235f[num] = bi.x4a3f0a05c02f235f[num];
		}
		x961016a387451f05 = bi.x961016a387451f05;
	}

	internal xfbab8f66e7836ec4(byte[] inData)
	{
		x961016a387451f05 = (uint)inData.Length >> 2;
		int num = inData.Length & 3;
		if (num != 0)
		{
			x961016a387451f05++;
		}
		x4a3f0a05c02f235f = new uint[x961016a387451f05];
		int num2 = inData.Length - 1;
		int num3 = 0;
		while (num2 >= 3)
		{
			x4a3f0a05c02f235f[num3] = (uint)((inData[num2 - 3] << 24) | (inData[num2 - 2] << 16) | (inData[num2 - 1] << 8) | inData[num2]);
			num2 -= 4;
			num3++;
		}
		switch (num)
		{
		case 1:
			x4a3f0a05c02f235f[x961016a387451f05 - 1] = inData[0];
			break;
		case 2:
			x4a3f0a05c02f235f[x961016a387451f05 - 1] = (uint)((inData[0] << 8) | inData[1]);
			break;
		case 3:
			x4a3f0a05c02f235f[x961016a387451f05 - 1] = (uint)((inData[0] << 16) | (inData[1] << 8) | inData[2]);
			break;
		}
		x234d65249b8ddf72();
	}

	internal xfbab8f66e7836ec4(uint[] inData)
	{
		x961016a387451f05 = (uint)inData.Length;
		x4a3f0a05c02f235f = new uint[x961016a387451f05];
		int num = (int)(x961016a387451f05 - 1);
		int num2 = 0;
		while (num >= 0)
		{
			x4a3f0a05c02f235f[num2] = inData[num];
			num--;
			num2++;
		}
		x234d65249b8ddf72();
	}

	internal xfbab8f66e7836ec4(uint ui)
	{
		x4a3f0a05c02f235f = new uint[1] { ui };
	}

	internal xfbab8f66e7836ec4(ulong ul)
	{
		x4a3f0a05c02f235f = new uint[2]
		{
			(uint)ul,
			(uint)(ul >> 32)
		};
		x961016a387451f05 = 2u;
		x234d65249b8ddf72();
	}

	public static implicit operator xfbab8f66e7836ec4(uint value)
	{
		return new xfbab8f66e7836ec4(value);
	}

	public static implicit operator xfbab8f66e7836ec4(int value)
	{
		if (value < 0)
		{
			throw new ArgumentOutOfRangeException("value");
		}
		return new xfbab8f66e7836ec4((uint)value);
	}

	public static implicit operator xfbab8f66e7836ec4(ulong value)
	{
		return new xfbab8f66e7836ec4(value);
	}

	internal static xfbab8f66e7836ec4 x1f490eac106aee12(string x78b0a0bc28459535)
	{
		if (x78b0a0bc28459535 == null)
		{
			throw new ArgumentNullException("number");
		}
		int i = 0;
		int length = x78b0a0bc28459535.Length;
		bool flag = false;
		xfbab8f66e7836ec4 xfbab8f66e7836ec5 = new xfbab8f66e7836ec4(0u);
		if (x78b0a0bc28459535[i] == '+')
		{
			i++;
		}
		else if (x78b0a0bc28459535[i] == '-')
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cfleahcfcgjfmgagifhgigogkffhnfmhjfdiiakimfbjbfijefpjiegkndnkgpdlfellfdcmbejmpdanjdhncdonboeopbmolncpgckpkbbajbiaabpaacgbcbnbmbecialcambddbjdlppddahejaoegpef", 1338657539)));
		}
		for (; i < length; i++)
		{
			char c = x78b0a0bc28459535[i];
			switch (c)
			{
			case '\0':
				i = length;
				continue;
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
				xfbab8f66e7836ec5 = xfbab8f66e7836ec5 * 10 + (c - 48);
				flag = true;
				continue;
			}
			if (char.IsWhiteSpace(c))
			{
				for (i++; i < length; i++)
				{
					if (!char.IsWhiteSpace(x78b0a0bc28459535[i]))
					{
						throw new FormatException();
					}
				}
				break;
			}
			throw new FormatException();
		}
		if (!flag)
		{
			throw new FormatException();
		}
		return xfbab8f66e7836ec5;
	}

	public static xfbab8f66e7836ec4 operator +(xfbab8f66e7836ec4 bi1, xfbab8f66e7836ec4 bi2)
	{
		if (bi1 == 0u)
		{
			return new xfbab8f66e7836ec4(bi2);
		}
		if (bi2 == 0u)
		{
			return new xfbab8f66e7836ec4(bi1);
		}
		return xf094e3229d63c9be.xdb56c62f254c0a59(bi1, bi2);
	}

	public static xfbab8f66e7836ec4 operator -(xfbab8f66e7836ec4 bi1, xfbab8f66e7836ec4 bi2)
	{
		if (bi2 == 0u)
		{
			return new xfbab8f66e7836ec4(bi1);
		}
		if (bi1 == 0u)
		{
			throw new ArithmeticException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jickhkjkjjaldkhlpiolpjfmbjmmejdnajknpdbodjioiipoligpphnpeheanclamhcbmgjbihacghhcahocjgfdibmdgfdecbkenfbfbfifafpfhegghfngjeehdflhpdcihpiikeajcdhjkdojaefkncmk", 65643066)));
		}
		return xf094e3229d63c9be.x65a184a150825e58(bi1, bi2) switch
		{
			x0428c55343267861.x67cf982b3c9c2bb6 => 0, 
			x0428c55343267861.x7eefbac090024714 => xf094e3229d63c9be.xc7c1a5f6d5e982b1(bi1, bi2), 
			x0428c55343267861.xef19f5be66d2e2e3 => throw new ArithmeticException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("phlcnjcdpijdjjaefihefjoehiffkimfgidgfdkgjibhohihbiphfhgikgnidcejchljcgckogjkmgalgghlpfoloafmmemmiadndfknhebogeiondponegppdnpjeeafdlanobbaejbicacadhcgdocdcfd", 1505700656))), 
			_ => throw new InvalidOperationException(), 
		};
	}

	public static int operator %(xfbab8f66e7836ec4 bi, int i)
	{
		if (i > 0)
		{
			return (int)xf094e3229d63c9be.xd9bce5ef71e883b0(bi, (uint)i);
		}
		return (int)(0 - xf094e3229d63c9be.xd9bce5ef71e883b0(bi, (uint)(-i)));
	}

	public static uint operator %(xfbab8f66e7836ec4 bi, uint ui)
	{
		return xf094e3229d63c9be.xd9bce5ef71e883b0(bi, ui);
	}

	public static xfbab8f66e7836ec4 operator %(xfbab8f66e7836ec4 bi1, xfbab8f66e7836ec4 bi2)
	{
		return xf094e3229d63c9be.x8b0176a5091f95ec(bi1, bi2)[1];
	}

	public static xfbab8f66e7836ec4 operator /(xfbab8f66e7836ec4 bi, int i)
	{
		if (i > 0)
		{
			return xf094e3229d63c9be.xfc4adf10bba1aee3(bi, (uint)i);
		}
		throw new ArithmeticException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bklkplclbljlllamhkhmhlomjkfnmkmnikdohfkolkbpakipdkpphjgaminafeebejlbeiccajjcoiadiihdbiodadfeogmekcdffhkfjgbgigigpfpgpgghbgnhlgeihflipacjcgjjkeakcfhkifokfefl", 1699588946)));
	}

	public static xfbab8f66e7836ec4 operator /(xfbab8f66e7836ec4 bi1, xfbab8f66e7836ec4 bi2)
	{
		return xf094e3229d63c9be.x8b0176a5091f95ec(bi1, bi2)[0];
	}

	public static xfbab8f66e7836ec4 operator *(xfbab8f66e7836ec4 bi1, xfbab8f66e7836ec4 bi2)
	{
		if (bi1 == 0u || bi2 == 0u)
		{
			return 0;
		}
		if (bi1.x4a3f0a05c02f235f.Length < bi1.x961016a387451f05)
		{
			throw new IndexOutOfRangeException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mjnbakecfglcbfcdnjjdakaemjhefeoebjfffimfmddglikghhbhbiihhhphchgi", 1540037946)));
		}
		if (bi2.x4a3f0a05c02f235f.Length < bi2.x961016a387451f05)
		{
			throw new IndexOutOfRangeException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("pgdodhkojdbpecipahppdhgapgnaibebeglbifccpajcofadkehdefodkefefeme", 154329869)));
		}
		xfbab8f66e7836ec4 xfbab8f66e7836ec5 = new xfbab8f66e7836ec4(x0428c55343267861.x7eefbac090024714, bi1.x961016a387451f05 + bi2.x961016a387451f05);
		xf094e3229d63c9be.x490e30087768649f(bi1.x4a3f0a05c02f235f, 0u, bi1.x961016a387451f05, bi2.x4a3f0a05c02f235f, 0u, bi2.x961016a387451f05, xfbab8f66e7836ec5.x4a3f0a05c02f235f, 0u);
		xfbab8f66e7836ec5.x234d65249b8ddf72();
		return xfbab8f66e7836ec5;
	}

	public static xfbab8f66e7836ec4 operator *(xfbab8f66e7836ec4 bi, int i)
	{
		if (i < 0)
		{
			throw new ArithmeticException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mghfkiofmhfggimgchdhcikhehbihhiidhpiccgjghnjlgekoglkcgclhfjlabampfhmpeomlffnjfmndfdomekolpapjdipfpopaegaednaddebkclbkdccmcjcgdadcchdknndncfefbmenbdfdckfabbg", 995120925)));
		}
		return i switch
		{
			0 => 0, 
			1 => new xfbab8f66e7836ec4(bi), 
			_ => xf094e3229d63c9be.x097f7d3fb1f122b6(bi, (uint)i), 
		};
	}

	public static xfbab8f66e7836ec4 operator <<(xfbab8f66e7836ec4 bi1, int shiftVal)
	{
		return xf094e3229d63c9be.x4fb449897de89253(bi1, shiftVal);
	}

	public static xfbab8f66e7836ec4 operator >>(xfbab8f66e7836ec4 bi1, int shiftVal)
	{
		return xf094e3229d63c9be.xae826207151e41b5(bi1, shiftVal);
	}

	internal static xfbab8f66e7836ec4 xd6b6ed77479ef68c(xfbab8f66e7836ec4 x83e17d59cce46549, xfbab8f66e7836ec4 xb6a214d6bebb5fe1)
	{
		return x83e17d59cce46549 + xb6a214d6bebb5fe1;
	}

	internal static xfbab8f66e7836ec4 xc7c1a5f6d5e982b1(xfbab8f66e7836ec4 x83e17d59cce46549, xfbab8f66e7836ec4 xb6a214d6bebb5fe1)
	{
		return x83e17d59cce46549 - xb6a214d6bebb5fe1;
	}

	internal static int x02f2e920b8f411d0(xfbab8f66e7836ec4 x964c723926ccb863, int x7b28e8a789372508)
	{
		return x964c723926ccb863 % x7b28e8a789372508;
	}

	internal static uint x02f2e920b8f411d0(xfbab8f66e7836ec4 x964c723926ccb863, uint x1ef0b706f8cf40e0)
	{
		return x964c723926ccb863 % x1ef0b706f8cf40e0;
	}

	internal static xfbab8f66e7836ec4 x02f2e920b8f411d0(xfbab8f66e7836ec4 x83e17d59cce46549, xfbab8f66e7836ec4 xb6a214d6bebb5fe1)
	{
		return x83e17d59cce46549 % xb6a214d6bebb5fe1;
	}

	internal static xfbab8f66e7836ec4 xc4fafc5c844e1097(xfbab8f66e7836ec4 x964c723926ccb863, int x7b28e8a789372508)
	{
		return x964c723926ccb863 / x7b28e8a789372508;
	}

	internal static xfbab8f66e7836ec4 xc4fafc5c844e1097(xfbab8f66e7836ec4 x83e17d59cce46549, xfbab8f66e7836ec4 xb6a214d6bebb5fe1)
	{
		return x83e17d59cce46549 / xb6a214d6bebb5fe1;
	}

	internal static xfbab8f66e7836ec4 x490e30087768649f(xfbab8f66e7836ec4 x83e17d59cce46549, xfbab8f66e7836ec4 xb6a214d6bebb5fe1)
	{
		return x83e17d59cce46549 * xb6a214d6bebb5fe1;
	}

	internal static xfbab8f66e7836ec4 x490e30087768649f(xfbab8f66e7836ec4 x964c723926ccb863, int x7b28e8a789372508)
	{
		return x964c723926ccb863 * x7b28e8a789372508;
	}

	public int xce53a4f2835cab70()
	{
		x234d65249b8ddf72();
		uint num = x4a3f0a05c02f235f[x961016a387451f05 - 1];
		uint num2 = 2147483648u;
		uint num3 = 32u;
		while (num3 != 0 && (num & num2) == 0)
		{
			num3--;
			num2 >>= 1;
		}
		return (int)(num3 + (x961016a387451f05 - 1 << 5));
	}

	internal bool xa81774f8089149a3(uint x44805ecd38ad2dab)
	{
		uint num = x44805ecd38ad2dab >> 5;
		byte b = (byte)(x44805ecd38ad2dab & 0x1Fu);
		uint num2 = (uint)(1 << (int)b);
		return (x4a3f0a05c02f235f[num] & num2) != 0;
	}

	internal bool xa81774f8089149a3(int x44805ecd38ad2dab)
	{
		if (x44805ecd38ad2dab < 0)
		{
			throw new IndexOutOfRangeException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gljoklapcmhpjjopnlfaclmacgdbokkbblbcnkicgfpcckgdgjndneeemjleiicfcjjfiiagdihg", 1399384404)));
		}
		uint num = (uint)x44805ecd38ad2dab >> 5;
		byte b = (byte)((uint)x44805ecd38ad2dab & 0x1Fu);
		uint num2 = (uint)(1 << (int)b);
		return (x4a3f0a05c02f235f[num] | num2) == x4a3f0a05c02f235f[num];
	}

	internal void x5ef51986c8da8183(uint x44805ecd38ad2dab)
	{
		x5ef51986c8da8183(x44805ecd38ad2dab, xbcea506a33cf9111: true);
	}

	internal void x71570a360a10f51e(uint x44805ecd38ad2dab)
	{
		x5ef51986c8da8183(x44805ecd38ad2dab, xbcea506a33cf9111: false);
	}

	internal void x5ef51986c8da8183(uint x44805ecd38ad2dab, bool xbcea506a33cf9111)
	{
		uint num = x44805ecd38ad2dab >> 5;
		if (num < x961016a387451f05)
		{
			uint num2 = (uint)(1 << (int)(x44805ecd38ad2dab & 0x1F));
			if (xbcea506a33cf9111)
			{
				x4a3f0a05c02f235f[num] |= num2;
			}
			else
			{
				x4a3f0a05c02f235f[num] &= ~num2;
			}
		}
	}

	internal int x2210961bb50856c6()
	{
		if (this == 0u)
		{
			return -1;
		}
		int i;
		for (i = 0; !xa81774f8089149a3(i); i++)
		{
		}
		return i;
	}

	internal byte[] xd7256284d8a56f03()
	{
		if (this == 0u)
		{
			return new byte[1];
		}
		int num = xce53a4f2835cab70();
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
		for (int num5 = (int)(x961016a387451f05 - 1); num5 >= 0; num5--)
		{
			uint num6 = x4a3f0a05c02f235f[num5];
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

	public static bool operator ==(xfbab8f66e7836ec4 bi1, uint ui)
	{
		if (bi1.x961016a387451f05 != 1)
		{
			bi1.x234d65249b8ddf72();
		}
		if (bi1.x961016a387451f05 == 1)
		{
			return bi1.x4a3f0a05c02f235f[0] == ui;
		}
		return false;
	}

	public static bool operator !=(xfbab8f66e7836ec4 bi1, uint ui)
	{
		if (bi1.x961016a387451f05 != 1)
		{
			bi1.x234d65249b8ddf72();
		}
		if (bi1.x961016a387451f05 == 1)
		{
			return bi1.x4a3f0a05c02f235f[0] != ui;
		}
		return true;
	}

	public static bool operator ==(xfbab8f66e7836ec4 bi1, xfbab8f66e7836ec4 bi2)
	{
		if ((object)bi1 == bi2)
		{
			return true;
		}
		if (null == bi1 || null == bi2)
		{
			return false;
		}
		return xf094e3229d63c9be.x65a184a150825e58(bi1, bi2) == x0428c55343267861.x67cf982b3c9c2bb6;
	}

	public static bool operator !=(xfbab8f66e7836ec4 bi1, xfbab8f66e7836ec4 bi2)
	{
		if ((object)bi1 == bi2)
		{
			return false;
		}
		if (null == bi1 || null == bi2)
		{
			return true;
		}
		return xf094e3229d63c9be.x65a184a150825e58(bi1, bi2) != x0428c55343267861.x67cf982b3c9c2bb6;
	}

	public static bool operator >(xfbab8f66e7836ec4 bi1, xfbab8f66e7836ec4 bi2)
	{
		return xf094e3229d63c9be.x65a184a150825e58(bi1, bi2) > x0428c55343267861.x67cf982b3c9c2bb6;
	}

	public static bool operator <(xfbab8f66e7836ec4 bi1, xfbab8f66e7836ec4 bi2)
	{
		return xf094e3229d63c9be.x65a184a150825e58(bi1, bi2) < x0428c55343267861.x67cf982b3c9c2bb6;
	}

	public static bool operator >=(xfbab8f66e7836ec4 bi1, xfbab8f66e7836ec4 bi2)
	{
		return xf094e3229d63c9be.x65a184a150825e58(bi1, bi2) >= x0428c55343267861.x67cf982b3c9c2bb6;
	}

	public static bool operator <=(xfbab8f66e7836ec4 bi1, xfbab8f66e7836ec4 bi2)
	{
		return xf094e3229d63c9be.x65a184a150825e58(bi1, bi2) <= x0428c55343267861.x67cf982b3c9c2bb6;
	}

	internal x0428c55343267861 x65a184a150825e58(xfbab8f66e7836ec4 x964c723926ccb863)
	{
		return xf094e3229d63c9be.x65a184a150825e58(this, x964c723926ccb863);
	}

	internal string ToString(uint radix)
	{
		return ToString(radix, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ");
	}

	internal string ToString(uint radix, string characterSet)
	{
		if (characterSet.Length < radix)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dldeflkelkbfjlifhjpfgkggclnglfeheklhkjciakjigjajakhjbjojgefkpimkfidlajklnibmhdimiipmjhgnpgnnjheoiclohhcpdgjpdgaafghabhoa", 35406672)), "characterSet");
		}
		if (radix == 1)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fmlcgncdanjdknaekmhecioeimffpmmfjhdgemkgcmbhahihamphplgikknimkejbgljclckdkjkbkaldkhljjolpefmnimmmjdngeknfjbobiiobipodigppinpedeaailamhcbahjbicacdhhcbhocdhfdnfmdngdepfkecgbfofif", 804727665)), "radix");
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
		xfbab8f66e7836ec4 xfbab8f66e7836ec5 = new xfbab8f66e7836ec4(this);
		while (xfbab8f66e7836ec5 != 0u)
		{
			uint index = xf094e3229d63c9be.xd7b5ea34a8142968(xfbab8f66e7836ec5, radix);
			text = characterSet[(int)index] + text;
		}
		return text;
	}

	private void x234d65249b8ddf72()
	{
		while (x961016a387451f05 != 0 && x4a3f0a05c02f235f[x961016a387451f05 - 1] == 0)
		{
			x961016a387451f05--;
		}
		if (x961016a387451f05 == 0)
		{
			x961016a387451f05++;
		}
	}

	internal void xa9d636b00ff486b7()
	{
		for (int i = 0; i < x961016a387451f05; i++)
		{
			x4a3f0a05c02f235f[i] = 0u;
		}
	}

	public override int GetHashCode()
	{
		uint num = 0u;
		for (uint num2 = 0u; num2 < x961016a387451f05; num2++)
		{
			num ^= x4a3f0a05c02f235f[num2];
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
		return xf094e3229d63c9be.x65a184a150825e58(this, (xfbab8f66e7836ec4)o) == x0428c55343267861.x67cf982b3c9c2bb6;
	}

	internal xfbab8f66e7836ec4 xf61b1f0294b5e17f(xfbab8f66e7836ec4 x964c723926ccb863)
	{
		return xf094e3229d63c9be.x96c37bb6e3c6d2ab(this, x964c723926ccb863);
	}

	internal xfbab8f66e7836ec4 xf18a1ab8cc1be8f7(xfbab8f66e7836ec4 xa6a81c8dae265da2)
	{
		return xf094e3229d63c9be.xfdbbb9032ceea877(this, xa6a81c8dae265da2);
	}

	internal xfbab8f66e7836ec4 xe66bb648cc583eb8(xfbab8f66e7836ec4 xd0072e8aa8c1411e, xfbab8f66e7836ec4 x57e9faf3ffdc07cc)
	{
		xb8d5596088d00dcf xb8d5596088d00dcf = new xb8d5596088d00dcf(x57e9faf3ffdc07cc);
		return xb8d5596088d00dcf.xde4af47ac20ddf00(this, xd0072e8aa8c1411e);
	}
}
