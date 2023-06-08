using System;
using System.Drawing;
using x6c95d9cf46ff5f25;

namespace x5794c252ba25e723;

internal class x630b5fb239bb4657
{
	private const int x41a5291e549fbf37 = 0;

	private const int x0a8b7f06ae09a22c = 1;

	private const int x69d1b0423ea829bd = 2;

	private const int xb207ae97f1e7e2e6 = 4;

	private const int xfa1441b2514ba23c = 8;

	private const int x564c07feb6189483 = 16;

	private float x8e1e5d7ac41c148a;

	private float xfc7a054ab2ab7fb7;

	private float xa1d5cfe3c1208a67;

	private float x9f4cd63c3b54350f;

	private float x1ba1feec87cdb33c;

	private float x011388a63eb09115;

	private float x5d4e060a8249a1b8;

	private float x07deb838c69230e6;

	private float xbbda52e1bda14713;

	private float x2fb6ade0109b8efa;

	private float x30d8c00588d9a9c9;

	private float x6a91a0503b4c1b0c;

	private float x92e2280d853ec056;

	private float xbb839b8175a76248;

	private float x593568aed8ca3303;

	private float x3729c51f56086fec;

	private int x9b529da35d1032aa;

	public x630b5fb239bb4657()
	{
		x8e1e5d7ac41c148a = (x011388a63eb09115 = (x30d8c00588d9a9c9 = (x3729c51f56086fec = 1f)));
	}

	public x630b5fb239bb4657(float M11, float M12, float M13, float M14, float M21, float M22, float M23, float M24, float M31, float M32, float M33, float M34, float M41, float M42, float M43, float M44)
	{
		x8e1e5d7ac41c148a = M11;
		xfc7a054ab2ab7fb7 = M12;
		xa1d5cfe3c1208a67 = M13;
		x9f4cd63c3b54350f = M14;
		x1ba1feec87cdb33c = M21;
		x011388a63eb09115 = M22;
		x5d4e060a8249a1b8 = M23;
		x07deb838c69230e6 = M24;
		xbbda52e1bda14713 = M31;
		x2fb6ade0109b8efa = M32;
		x30d8c00588d9a9c9 = M33;
		x6a91a0503b4c1b0c = M34;
		x92e2280d853ec056 = M41;
		xbb839b8175a76248 = M42;
		x593568aed8ca3303 = M43;
		x3729c51f56086fec = M44;
		x3da203c4ca1dec38();
	}

	public static x630b5fb239bb4657 x33ef65dee21ac642(xa010107c2168153f xa99c70e73a72f876, PointF x9c3c185e7046dc72)
	{
		float num = x9c3c185e7046dc72.X + xa99c70e73a72f876.x8df91a2f90079e88;
		float num2 = x9c3c185e7046dc72.Y + xa99c70e73a72f876.xc821290d7ecc08bf;
		float num3 = 1f / xa99c70e73a72f876.xe7189024fdf97d87;
		return new x630b5fb239bb4657(1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, num * num3, num2 * num3, 0f, num3, 0f, 0f, 0f, 1f);
	}

	public static x630b5fb239bb4657 xd0795197ba2ca48c(float x2369b594c9a675bb)
	{
		float num = (float)(Math.PI - x15e971129fd80714.xcdc7b29a812dd7df(x2369b594c9a675bb));
		float m = (float)Math.Cos(num) / 2f;
		float m2 = (float)Math.Sin(num) / 2f;
		return new x630b5fb239bb4657(1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, m, m2, 0f, 0f, 0f, 0f, 0f, 1f);
	}

	public void xc69dbc1adc53a5a8(float x3758cf4ee715d797, float x6842879318972d9e, float xfa50dc797b371c8d)
	{
		if ((x9b529da35d1032aa & 1) == 1)
		{
			x92e2280d853ec056 += x3758cf4ee715d797;
			xbb839b8175a76248 += x6842879318972d9e;
			x593568aed8ca3303 += xfa50dc797b371c8d;
		}
		else
		{
			x92e2280d853ec056 = x3758cf4ee715d797;
			xbb839b8175a76248 = x6842879318972d9e;
			x593568aed8ca3303 = xfa50dc797b371c8d;
			x9b529da35d1032aa |= 1;
		}
	}

	public void x829c563f8b08f11b(float x2c32eaf56c62000c, float x4e001158953172b8)
	{
		if (x4e001158953172b8 != 0f)
		{
			xbdd0ebbf68bbad51(x4e001158953172b8);
		}
		if (x2c32eaf56c62000c != 0f)
		{
			x2a4c00107b2b635b(x2c32eaf56c62000c);
		}
	}

	private void x2a4c00107b2b635b(float xcb83cdf6822fc99d)
	{
		double num = x15e971129fd80714.xcdc7b29a812dd7df(xcb83cdf6822fc99d);
		double num2 = Math.Sin(num);
		double num3 = Math.Cos(num);
		if (num3 != 1.0)
		{
			float num4 = xfc7a054ab2ab7fb7;
			float num5 = xa1d5cfe3c1208a67;
			xfc7a054ab2ab7fb7 = (float)(num3 * (double)num4 - num2 * (double)num5);
			xa1d5cfe3c1208a67 = (float)(num2 * (double)num4 + num3 * (double)num5);
			num4 = x011388a63eb09115;
			num5 = x5d4e060a8249a1b8;
			x011388a63eb09115 = (float)(num3 * (double)num4 - num2 * (double)num5);
			x5d4e060a8249a1b8 = (float)(num2 * (double)num4 + num3 * (double)num5);
			num4 = x2fb6ade0109b8efa;
			num5 = x30d8c00588d9a9c9;
			x2fb6ade0109b8efa = (float)(num3 * (double)num4 - num2 * (double)num5);
			x30d8c00588d9a9c9 = (float)(num2 * (double)num4 + num3 * (double)num5);
			num4 = xbb839b8175a76248;
			num5 = x593568aed8ca3303;
			xbb839b8175a76248 = (float)(num3 * (double)num4 - num2 * (double)num5);
			x593568aed8ca3303 = (float)(num2 * (double)num4 + num3 * (double)num5);
			x3da203c4ca1dec38();
		}
	}

	private void xbdd0ebbf68bbad51(float xcb83cdf6822fc99d)
	{
		double num = x15e971129fd80714.xcdc7b29a812dd7df(xcb83cdf6822fc99d);
		double num2 = Math.Sin(num);
		double num3 = Math.Cos(num);
		if (num3 != 1.0)
		{
			float num4 = x8e1e5d7ac41c148a;
			float num5 = xa1d5cfe3c1208a67;
			x8e1e5d7ac41c148a = (float)(num3 * (double)num4 + num2 * (double)num5);
			xa1d5cfe3c1208a67 = (float)((0.0 - num2) * (double)num4 + num3 * (double)num5);
			num4 = x1ba1feec87cdb33c;
			num5 = x5d4e060a8249a1b8;
			x1ba1feec87cdb33c = (float)(num3 * (double)num4 + num2 * (double)num5);
			x5d4e060a8249a1b8 = (float)((0.0 - num2) * (double)num4 + num3 * (double)num5);
			num4 = xbbda52e1bda14713;
			num5 = x30d8c00588d9a9c9;
			xbbda52e1bda14713 = (float)(num3 * (double)num4 + num2 * (double)num5);
			x30d8c00588d9a9c9 = (float)((0.0 - num2) * (double)num4 + num3 * (double)num5);
			num4 = x92e2280d853ec056;
			num5 = x593568aed8ca3303;
			x92e2280d853ec056 = (float)(num3 * (double)num4 + num2 * (double)num5);
			x593568aed8ca3303 = (float)((0.0 - num2) * (double)num4 + num3 * (double)num5);
			x3da203c4ca1dec38();
		}
	}

	public void xa4b699bd47eb7372(xa010107c2168153f[] x6fa2570084b2ad39, int xd4f974c06ffa392b, int x9e0157add3830c36)
	{
		int num = xd4f974c06ffa392b + x9e0157add3830c36;
		if (num > x6fa2570084b2ad39.Length)
		{
			num = x6fa2570084b2ad39.Length;
		}
		for (int i = xd4f974c06ffa392b; i < num; i++)
		{
			x6fa2570084b2ad39[i] = x5c785f1d561da269(x6fa2570084b2ad39[i]);
		}
	}

	public xa010107c2168153f x5c785f1d561da269(xa010107c2168153f x2f7096dac971d6ec)
	{
		xa010107c2168153f xa010107c2168153f2 = new xa010107c2168153f(x2f7096dac971d6ec.x8df91a2f90079e88, x2f7096dac971d6ec.xc821290d7ecc08bf, x2f7096dac971d6ec.xe7189024fdf97d87);
		int num = x9b529da35d1032aa;
		float x8df91a2f90079e = xa010107c2168153f2.x8df91a2f90079e88;
		float xc821290d7ecc08bf = xa010107c2168153f2.xc821290d7ecc08bf;
		float xe7189024fdf97d = xa010107c2168153f2.xe7189024fdf97d87;
		float num2 = (((num & 0x18) == 0) ? 1f : (x8df91a2f90079e * x9f4cd63c3b54350f + xc821290d7ecc08bf * x07deb838c69230e6 + xe7189024fdf97d * x6a91a0503b4c1b0c + x3729c51f56086fec));
		if (num2 == 0f)
		{
			return new xa010107c2168153f(x8df91a2f90079e, xc821290d7ecc08bf, xe7189024fdf97d);
		}
		switch (num & 7)
		{
		case 7:
			xa010107c2168153f2 = new xa010107c2168153f(x8df91a2f90079e * x8e1e5d7ac41c148a + xc821290d7ecc08bf * x1ba1feec87cdb33c + xe7189024fdf97d * xbbda52e1bda14713 + x92e2280d853ec056, x8df91a2f90079e * xfc7a054ab2ab7fb7 + xc821290d7ecc08bf * x011388a63eb09115 + xe7189024fdf97d * x2fb6ade0109b8efa + xbb839b8175a76248, x8df91a2f90079e * xa1d5cfe3c1208a67 + xc821290d7ecc08bf * x5d4e060a8249a1b8 + xe7189024fdf97d * x30d8c00588d9a9c9 + x593568aed8ca3303);
			break;
		case 6:
			xa010107c2168153f2 = new xa010107c2168153f(x8df91a2f90079e * x8e1e5d7ac41c148a + xc821290d7ecc08bf * x1ba1feec87cdb33c + xe7189024fdf97d * xbbda52e1bda14713, x8df91a2f90079e * xfc7a054ab2ab7fb7 + xc821290d7ecc08bf * x011388a63eb09115 + xe7189024fdf97d * x2fb6ade0109b8efa, x8df91a2f90079e * xa1d5cfe3c1208a67 + xc821290d7ecc08bf * x5d4e060a8249a1b8 + xe7189024fdf97d * x30d8c00588d9a9c9);
			break;
		case 5:
			xa010107c2168153f2 = new xa010107c2168153f(xc821290d7ecc08bf * x1ba1feec87cdb33c + xe7189024fdf97d * xbbda52e1bda14713 + x92e2280d853ec056, x8df91a2f90079e * xfc7a054ab2ab7fb7 + xe7189024fdf97d * x2fb6ade0109b8efa + xbb839b8175a76248, x8df91a2f90079e * xa1d5cfe3c1208a67 + xc821290d7ecc08bf * x5d4e060a8249a1b8 + x593568aed8ca3303);
			break;
		case 4:
			xa010107c2168153f2 = new xa010107c2168153f(xc821290d7ecc08bf * x1ba1feec87cdb33c + xe7189024fdf97d * xbbda52e1bda14713, x8df91a2f90079e * xfc7a054ab2ab7fb7 + xe7189024fdf97d * x2fb6ade0109b8efa, x8df91a2f90079e * xa1d5cfe3c1208a67 + xc821290d7ecc08bf * x5d4e060a8249a1b8);
			break;
		case 3:
			xa010107c2168153f2 = new xa010107c2168153f(x8df91a2f90079e * x8e1e5d7ac41c148a + x92e2280d853ec056, xc821290d7ecc08bf * x011388a63eb09115 + xbb839b8175a76248, xe7189024fdf97d * x30d8c00588d9a9c9 + x593568aed8ca3303);
			break;
		case 2:
			xa010107c2168153f2 = new xa010107c2168153f(x8df91a2f90079e * x8e1e5d7ac41c148a, xc821290d7ecc08bf * x011388a63eb09115, xe7189024fdf97d * x30d8c00588d9a9c9);
			break;
		case 1:
			xa010107c2168153f2 = new xa010107c2168153f(x8df91a2f90079e + x92e2280d853ec056, xc821290d7ecc08bf + xbb839b8175a76248, xe7189024fdf97d + x593568aed8ca3303);
			break;
		default:
			x938f936af1a8b91c();
			break;
		case 0:
			break;
		}
		xa010107c2168153f2.x8df91a2f90079e88 /= num2;
		xa010107c2168153f2.xc821290d7ecc08bf /= num2;
		xa010107c2168153f2.xe7189024fdf97d87 /= num2;
		return xa010107c2168153f2;
	}

	public void xa4b699bd47eb7372(xa010107c2168153f[] x6fa2570084b2ad39)
	{
		xa4b699bd47eb7372(x6fa2570084b2ad39, 0, x6fa2570084b2ad39.Length);
	}

	public void x2262d45deed5f60d(x630b5fb239bb4657 x470ecea91abfd1aa)
	{
		if (x470ecea91abfd1aa != null)
		{
			int num = x9b529da35d1032aa;
			int num2 = x470ecea91abfd1aa.x9b529da35d1032aa;
			float num3 = x470ecea91abfd1aa.x8e1e5d7ac41c148a;
			float num4 = x470ecea91abfd1aa.x1ba1feec87cdb33c;
			float num5 = x470ecea91abfd1aa.xbbda52e1bda14713;
			float num6 = x470ecea91abfd1aa.x92e2280d853ec056;
			float num7 = x470ecea91abfd1aa.xfc7a054ab2ab7fb7;
			float num8 = x470ecea91abfd1aa.x011388a63eb09115;
			float num9 = x470ecea91abfd1aa.x2fb6ade0109b8efa;
			float num10 = x470ecea91abfd1aa.xbb839b8175a76248;
			float num11 = x470ecea91abfd1aa.xa1d5cfe3c1208a67;
			float num12 = x470ecea91abfd1aa.x5d4e060a8249a1b8;
			float num13 = x470ecea91abfd1aa.x30d8c00588d9a9c9;
			float num14 = x470ecea91abfd1aa.x593568aed8ca3303;
			float num15 = x470ecea91abfd1aa.x9f4cd63c3b54350f;
			float num16 = x470ecea91abfd1aa.x07deb838c69230e6;
			float num17 = x470ecea91abfd1aa.x6a91a0503b4c1b0c;
			float num18 = x470ecea91abfd1aa.x3729c51f56086fec;
			if (((uint)num & 0x11u) != 0)
			{
				float num19 = x92e2280d853ec056;
				float num20 = xbb839b8175a76248;
				float num21 = x593568aed8ca3303;
				float num22 = x3729c51f56086fec;
				x92e2280d853ec056 = num19 * num3 + num20 * num4 + num21 * num5 + num22 * num6;
				xbb839b8175a76248 = num19 * num7 + num20 * num8 + num21 * num9 + num22 * num10;
				x593568aed8ca3303 = num19 * num11 + num20 * num12 + num21 * num13 + num22 * num14;
				x3729c51f56086fec = num19 * num15 + num20 * num16 + num21 * num17 + num22 * num18;
			}
			else
			{
				x92e2280d853ec056 = num6;
				xbb839b8175a76248 = num10;
				x593568aed8ca3303 = num14;
				x3729c51f56086fec = num18;
			}
			switch (num & 6)
			{
			case 14:
			{
				float num19 = x8e1e5d7ac41c148a;
				float num20 = xfc7a054ab2ab7fb7;
				float num21 = xa1d5cfe3c1208a67;
				float num22 = x9f4cd63c3b54350f;
				x8e1e5d7ac41c148a = num19 * num3 + num20 * num4 + num21 * num5 + num22 * num6;
				xfc7a054ab2ab7fb7 = num19 * num7 + num20 * num8 + num21 * num9 + num22 * num10;
				xa1d5cfe3c1208a67 = num19 * num11 + num20 * num12 + num21 * num13 + num22 * num14;
				x9f4cd63c3b54350f = num19 * num15 + num20 * num16 + num21 * num17 + num22 * num18;
				num19 = x1ba1feec87cdb33c;
				num20 = x011388a63eb09115;
				num21 = x5d4e060a8249a1b8;
				num22 = x07deb838c69230e6;
				x1ba1feec87cdb33c = num19 * num3 + num20 * num4 + num21 * num5 + num22 * num6;
				x011388a63eb09115 = num19 * num7 + num20 * num8 + num21 * num9 + num22 * num10;
				x5d4e060a8249a1b8 = num19 * num11 + num20 * num12 + num21 * num13 + num22 * num14;
				x07deb838c69230e6 = num19 * num15 + num20 * num16 + num21 * num17 + num22 * num18;
				num19 = xbbda52e1bda14713;
				num20 = x2fb6ade0109b8efa;
				num21 = x30d8c00588d9a9c9;
				num22 = x6a91a0503b4c1b0c;
				xbbda52e1bda14713 = num19 * num3 + num20 * num4 + num21 * num5 + num22 * num6;
				x2fb6ade0109b8efa = num19 * num7 + num20 * num8 + num21 * num9 + num22 * num10;
				x30d8c00588d9a9c9 = num19 * num11 + num20 * num12 + num21 * num13 + num22 * num14;
				x6a91a0503b4c1b0c = num19 * num15 + num20 * num16 + num21 * num17 + num22 * num18;
				break;
			}
			case 6:
			{
				float num19 = x8e1e5d7ac41c148a;
				float num20 = xfc7a054ab2ab7fb7;
				float num21 = xa1d5cfe3c1208a67;
				x8e1e5d7ac41c148a = num19 * num3 + num20 * num4 + num21 * num5;
				xfc7a054ab2ab7fb7 = num19 * num7 + num20 * num8 + num21 * num9;
				xa1d5cfe3c1208a67 = num19 * num11 + num20 * num12 + num21 * num13;
				x9f4cd63c3b54350f = num19 * num15 + num20 * num16 + num21 * num17;
				num19 = x1ba1feec87cdb33c;
				num20 = x011388a63eb09115;
				num21 = x5d4e060a8249a1b8;
				x1ba1feec87cdb33c = num19 * num3 + num20 * num4 + num21 * num5;
				x011388a63eb09115 = num19 * num7 + num20 * num8 + num21 * num9;
				x5d4e060a8249a1b8 = num19 * num11 + num20 * num12 + num21 * num13;
				x07deb838c69230e6 = num19 * num15 + num20 * num16 + num21 * num17;
				num19 = xbbda52e1bda14713;
				num20 = x2fb6ade0109b8efa;
				num21 = x30d8c00588d9a9c9;
				xbbda52e1bda14713 = num19 * num3 + num20 * num4 + num21 * num5;
				x2fb6ade0109b8efa = num19 * num7 + num20 * num8 + num21 * num9;
				x30d8c00588d9a9c9 = num19 * num11 + num20 * num12 + num21 * num13;
				x6a91a0503b4c1b0c = num19 * num15 + num20 * num16 + num21 * num17;
				break;
			}
			case 12:
			{
				float num20 = xfc7a054ab2ab7fb7;
				float num21 = xa1d5cfe3c1208a67;
				float num22 = x9f4cd63c3b54350f;
				x8e1e5d7ac41c148a = num20 * num4 + num21 * num5 + num22 * num6;
				xfc7a054ab2ab7fb7 = num20 * num8 + num21 * num9 + num22 * num10;
				xa1d5cfe3c1208a67 = num20 * num12 + num21 * num13 + num22 * num14;
				x9f4cd63c3b54350f = num20 * num16 + num21 * num17 + num22 * num18;
				float num19 = x1ba1feec87cdb33c;
				num21 = x5d4e060a8249a1b8;
				num22 = x07deb838c69230e6;
				x1ba1feec87cdb33c = num19 * num3 + num21 * num5 + num22 * num6;
				x011388a63eb09115 = num19 * num7 + num21 * num9 + num22 * num10;
				x5d4e060a8249a1b8 = num19 * num11 + num21 * num13 + num22 * num14;
				x07deb838c69230e6 = num19 * num15 + num21 * num17 + num22 * num18;
				num19 = xbbda52e1bda14713;
				num20 = x2fb6ade0109b8efa;
				num22 = x6a91a0503b4c1b0c;
				xbbda52e1bda14713 = num19 * num3 + num20 * num4 + num22 * num6;
				x2fb6ade0109b8efa = num19 * num7 + num20 * num8 + num22 * num10;
				x30d8c00588d9a9c9 = num19 * num11 + num20 * num12 + num22 * num14;
				x6a91a0503b4c1b0c = num19 * num15 + num20 * num16 + num22 * num18;
				break;
			}
			case 4:
			{
				float num20 = xfc7a054ab2ab7fb7;
				float num21 = xa1d5cfe3c1208a67;
				x8e1e5d7ac41c148a = num20 * num4 + num21 * num5;
				xfc7a054ab2ab7fb7 = num20 * num8 + num21 * num9;
				xa1d5cfe3c1208a67 = num20 * num12 + num21 * num13;
				x9f4cd63c3b54350f = num20 * num16 + num21 * num17;
				float num19 = x1ba1feec87cdb33c;
				num21 = x5d4e060a8249a1b8;
				x1ba1feec87cdb33c = num19 * num3 + num21 * num5;
				x011388a63eb09115 = num19 * num7 + num21 * num9;
				x5d4e060a8249a1b8 = num19 * num11 + num21 * num13;
				x07deb838c69230e6 = num19 * num15 + num21 * num17;
				num19 = xbbda52e1bda14713;
				num20 = x2fb6ade0109b8efa;
				xbbda52e1bda14713 = num19 * num3 + num20 * num4;
				x2fb6ade0109b8efa = num19 * num7 + num20 * num8;
				x30d8c00588d9a9c9 = num19 * num11 + num20 * num12;
				x6a91a0503b4c1b0c = num19 * num15 + num20 * num16;
				break;
			}
			case 10:
			{
				float num19 = x8e1e5d7ac41c148a;
				float num22 = x9f4cd63c3b54350f;
				x8e1e5d7ac41c148a = num19 * num3 + num22 * num6;
				xfc7a054ab2ab7fb7 = num19 * num7 + num22 * num10;
				xa1d5cfe3c1208a67 = num19 * num11 + num22 * num14;
				x9f4cd63c3b54350f = num19 * num15 + num22 * num18;
				num19 = x011388a63eb09115;
				num22 = x07deb838c69230e6;
				x1ba1feec87cdb33c = num19 * num4 + num22 * num6;
				x011388a63eb09115 = num19 * num8 + num22 * num10;
				x5d4e060a8249a1b8 = num19 * num12 + num22 * num14;
				x07deb838c69230e6 = num19 * num16 + num22 * num18;
				num19 = x30d8c00588d9a9c9;
				num22 = x6a91a0503b4c1b0c;
				xbbda52e1bda14713 = num19 * num5 + num22 * num6;
				x2fb6ade0109b8efa = num19 * num9 + num22 * num10;
				x30d8c00588d9a9c9 = num19 * num13 + num22 * num14;
				x6a91a0503b4c1b0c = num19 * num17 + num22 * num18;
				break;
			}
			case 2:
			{
				float num19 = x8e1e5d7ac41c148a;
				x8e1e5d7ac41c148a = num19 * num3;
				xfc7a054ab2ab7fb7 = num19 * num7;
				xa1d5cfe3c1208a67 = num19 * num11;
				x9f4cd63c3b54350f = num19 * num15;
				num19 = x011388a63eb09115;
				x1ba1feec87cdb33c = num19 * num4;
				x011388a63eb09115 = num19 * num8;
				x5d4e060a8249a1b8 = num19 * num12;
				x07deb838c69230e6 = num19 * num16;
				num19 = x30d8c00588d9a9c9;
				xbbda52e1bda14713 = num19 * num5;
				x2fb6ade0109b8efa = num19 * num9;
				x30d8c00588d9a9c9 = num19 * num13;
				x6a91a0503b4c1b0c = num19 * num17;
				break;
			}
			case 0:
				x8e1e5d7ac41c148a = num3;
				xfc7a054ab2ab7fb7 = num7;
				xa1d5cfe3c1208a67 = num11;
				x9f4cd63c3b54350f = num15;
				x1ba1feec87cdb33c = num4;
				x011388a63eb09115 = num8;
				x5d4e060a8249a1b8 = num12;
				x07deb838c69230e6 = num16;
				xbbda52e1bda14713 = num5;
				x2fb6ade0109b8efa = num9;
				x30d8c00588d9a9c9 = num13;
				x6a91a0503b4c1b0c = num17;
				x9b529da35d1032aa |= num2;
				return;
			default:
				x938f936af1a8b91c();
				break;
			}
			x3da203c4ca1dec38();
		}
	}

	public x630b5fb239bb4657 x8b61531c8ea35b85()
	{
		x630b5fb239bb4657 x630b5fb239bb4658 = new x630b5fb239bb4657(x8e1e5d7ac41c148a, xfc7a054ab2ab7fb7, xa1d5cfe3c1208a67, x9f4cd63c3b54350f, x1ba1feec87cdb33c, x011388a63eb09115, x5d4e060a8249a1b8, x07deb838c69230e6, xbbda52e1bda14713, x2fb6ade0109b8efa, x30d8c00588d9a9c9, x6a91a0503b4c1b0c, x92e2280d853ec056, xbb839b8175a76248, x593568aed8ca3303, x3729c51f56086fec);
		x630b5fb239bb4658.x9b529da35d1032aa = x9b529da35d1032aa;
		return x630b5fb239bb4658;
	}

	private void x3da203c4ca1dec38()
	{
		x9b529da35d1032aa = 0;
		if (x92e2280d853ec056 != 0f || xbb839b8175a76248 != 0f || x593568aed8ca3303 != 0f)
		{
			x9b529da35d1032aa |= 1;
		}
		if (x9f4cd63c3b54350f != 0f || x07deb838c69230e6 != 0f || x6a91a0503b4c1b0c != 0f)
		{
			x9b529da35d1032aa |= 8;
		}
		if (x3729c51f56086fec != 1f)
		{
			x9b529da35d1032aa |= 16;
		}
		if (x1ba1feec87cdb33c == 0f && xbbda52e1bda14713 == 0f && xfc7a054ab2ab7fb7 == 0f && x2fb6ade0109b8efa == 0f && xa1d5cfe3c1208a67 == 0f && x5d4e060a8249a1b8 == 0f)
		{
			if (x8e1e5d7ac41c148a != 1f || x011388a63eb09115 != 1f || x30d8c00588d9a9c9 != 1f)
			{
				x9b529da35d1032aa |= 2;
			}
		}
		else if (x8e1e5d7ac41c148a == 0f && x011388a63eb09115 == 0f && x30d8c00588d9a9c9 == 0f)
		{
			x9b529da35d1032aa |= 4;
		}
		else
		{
			x9b529da35d1032aa |= 6;
		}
		if (x9b529da35d1032aa == 0)
		{
			x9b529da35d1032aa = 0;
		}
	}

	public void x74f5a1ef3906e23c()
	{
		x8e1e5d7ac41c148a = (x011388a63eb09115 = (x30d8c00588d9a9c9 = (x3729c51f56086fec = 1f)));
		x1ba1feec87cdb33c = (xbbda52e1bda14713 = (x92e2280d853ec056 = (xfc7a054ab2ab7fb7 = (x2fb6ade0109b8efa = (xbb839b8175a76248 = (xa1d5cfe3c1208a67 = (x5d4e060a8249a1b8 = (x593568aed8ca3303 = (x9f4cd63c3b54350f = (x07deb838c69230e6 = (x6a91a0503b4c1b0c = 0f)))))))))));
		x9b529da35d1032aa = 0;
	}

	private void x938f936af1a8b91c()
	{
		throw new ExecutionEngineException("missing case in transform state switch");
	}
}
