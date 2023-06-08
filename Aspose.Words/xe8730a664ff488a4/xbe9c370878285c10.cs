using System;
using Aspose;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal sealed class xbe9c370878285c10
{
	private const int x68030072f56721e5 = 1440;

	private const int x41176bdf0768a0c8 = 0;

	private const int xbb8e8a46454f480f = 1;

	private const int xb53480f80474b263 = 2;

	private const int x06bb92bf0433f292 = 3;

	private const int x88c21a05e329dc12 = 4;

	private const int xeae57f6e8990dcd0 = 5;

	private const int xaf76c77399e26fc2 = 6;

	private const int x45597484bd39edbf = 7;

	private const int x18a50ec04fea77d4 = 8;

	private const int x0a94a84af9b21075 = 9;

	private static readonly int[] xa454a72a9452f39c = new int[17]
	{
		0, 1, 3, 7, 15, 31, 63, 127, 255, 511,
		1023, 2047, 4095, 8191, 16383, 32767, 65535
	};

	internal static readonly int[] x14cf9593b86ecbaa = new int[19]
	{
		16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
		11, 4, 12, 3, 13, 2, 14, 1, 15
	};

	internal int xa4aa8b4150b11435;

	internal int xa447fc54e41dfe06;

	internal int x1ec770899c98a268;

	internal int xc0c4c459c6ccbd00;

	internal int[] xd80c151cb6289894;

	internal int[] xa8599b40401c5d34 = new int[1];

	internal int[] xa5886b2a445f53f4 = new int[1];

	internal x9d8cd54b1962a71d xcdff170dbac909bf = new x9d8cd54b1962a71d();

	internal int x2aa5114a5da7d6c8;

	internal x5a92807060bc6079 _x75d376891c19d365;

	internal int x9bc58d3ebc0c6301;

	internal int x81ab2bc14c781288;

	internal int[] x2a1ba593d4ab15ba;

	internal byte[] x76b3d9d2638e5ecd;

	internal int xca09b6c2b5b18485;

	internal int x5586b6ed3aa176aa;

	internal int xe95ef630fef0a7ff;

	internal object xddded55f98ca3594;

	internal long xb48f46f4fb07ae5f;

	internal x5d955d4b6f952045 xf0216b28ecfe25dd = new x5d955d4b6f952045();

	internal xbe9c370878285c10(x5a92807060bc6079 codec, object checkfn, int w)
	{
		_x75d376891c19d365 = codec;
		x2a1ba593d4ab15ba = new int[4320];
		x76b3d9d2638e5ecd = new byte[w];
		xca09b6c2b5b18485 = w;
		xddded55f98ca3594 = checkfn;
		xa4aa8b4150b11435 = 0;
		x74f5a1ef3906e23c(null);
	}

	internal void x74f5a1ef3906e23c(long[] x3c4da2980d043c95)
	{
		if (x3c4da2980d043c95 != null)
		{
			x3c4da2980d043c95[0] = xb48f46f4fb07ae5f;
		}
		if (xa4aa8b4150b11435 != 4)
		{
			_ = xa4aa8b4150b11435;
			_ = 5;
		}
		_ = xa4aa8b4150b11435;
		_ = 6;
		xa4aa8b4150b11435 = 0;
		x9bc58d3ebc0c6301 = 0;
		x81ab2bc14c781288 = 0;
		x5586b6ed3aa176aa = (xe95ef630fef0a7ff = 0);
		if (xddded55f98ca3594 != null)
		{
			_x75d376891c19d365._x7ab4a0dd1a2efc16 = (xb48f46f4fb07ae5f = xb23dc957c3e5bff6.x7ab4a0dd1a2efc16(0L, null, 0, 0));
		}
	}

	internal int x5d3a1f6283012a22(int xb55b340ae3a3e4e0)
	{
		int num = _x75d376891c19d365.x564ec8a071685a21;
		int num2 = _x75d376891c19d365.x3401b50873ad59be;
		int num3 = x81ab2bc14c781288;
		int i = x9bc58d3ebc0c6301;
		int num4 = xe95ef630fef0a7ff;
		int num5 = ((num4 < x5586b6ed3aa176aa) ? (x5586b6ed3aa176aa - num4 - 1) : (xca09b6c2b5b18485 - num4));
		while (true)
		{
			switch (xa4aa8b4150b11435)
			{
			case 0:
			{
				for (; i < 3; i += 8)
				{
					if (num2 != 0)
					{
						xb55b340ae3a3e4e0 = 0;
						num2--;
						num3 |= (_x75d376891c19d365.x44c6db5b64538d67[num++] & 0xFF) << i;
						continue;
					}
					x81ab2bc14c781288 = num3;
					x9bc58d3ebc0c6301 = i;
					_x75d376891c19d365.x3401b50873ad59be = num2;
					_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
					_x75d376891c19d365.x564ec8a071685a21 = num;
					xe95ef630fef0a7ff = num4;
					return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				}
				int num6 = num3 & 7;
				x2aa5114a5da7d6c8 = num6 & 1;
				switch (x71e71339e29fbf2b.x708a60ec8cfa708b(num6, 1))
				{
				case 0:
					num3 = x71e71339e29fbf2b.x708a60ec8cfa708b(num3, 3);
					i -= 3;
					num6 = i & 7;
					num3 = x71e71339e29fbf2b.x708a60ec8cfa708b(num3, num6);
					i -= num6;
					xa4aa8b4150b11435 = 1;
					break;
				case 1:
				{
					int[] array = new int[1];
					int[] array2 = new int[1];
					int[][] array3 = new int[1][];
					int[][] array4 = new int[1][];
					x5d955d4b6f952045.x47f4c90a5db5e34f(array, array2, array3, array4, _x75d376891c19d365);
					xcdff170dbac909bf.xd586e0c16bdae7fc(array[0], array2[0], array3[0], 0, array4[0], 0);
					num3 = x71e71339e29fbf2b.x708a60ec8cfa708b(num3, 3);
					i -= 3;
					xa4aa8b4150b11435 = 6;
					break;
				}
				case 2:
					num3 = x71e71339e29fbf2b.x708a60ec8cfa708b(num3, 3);
					i -= 3;
					xa4aa8b4150b11435 = 3;
					break;
				case 3:
					num3 = x71e71339e29fbf2b.x708a60ec8cfa708b(num3, 3);
					i -= 3;
					xa4aa8b4150b11435 = 9;
					_x75d376891c19d365.xd397bb1e465ce45e = "invalid block type";
					xb55b340ae3a3e4e0 = -3;
					x81ab2bc14c781288 = num3;
					x9bc58d3ebc0c6301 = i;
					_x75d376891c19d365.x3401b50873ad59be = num2;
					_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
					_x75d376891c19d365.x564ec8a071685a21 = num;
					xe95ef630fef0a7ff = num4;
					return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				}
				break;
			}
			case 1:
				for (; i < 32; i += 8)
				{
					if (num2 != 0)
					{
						xb55b340ae3a3e4e0 = 0;
						num2--;
						num3 |= (_x75d376891c19d365.x44c6db5b64538d67[num++] & 0xFF) << i;
						continue;
					}
					x81ab2bc14c781288 = num3;
					x9bc58d3ebc0c6301 = i;
					_x75d376891c19d365.x3401b50873ad59be = num2;
					_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
					_x75d376891c19d365.x564ec8a071685a21 = num;
					xe95ef630fef0a7ff = num4;
					return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				}
				if ((x71e71339e29fbf2b.x708a60ec8cfa708b(~num3, 16) & 0xFFFF) != (num3 & 0xFFFF))
				{
					xa4aa8b4150b11435 = 9;
					_x75d376891c19d365.xd397bb1e465ce45e = "invalid stored block lengths";
					xb55b340ae3a3e4e0 = -3;
					x81ab2bc14c781288 = num3;
					x9bc58d3ebc0c6301 = i;
					_x75d376891c19d365.x3401b50873ad59be = num2;
					_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
					_x75d376891c19d365.x564ec8a071685a21 = num;
					xe95ef630fef0a7ff = num4;
					return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				}
				xa447fc54e41dfe06 = num3 & 0xFFFF;
				num3 = (i = 0);
				xa4aa8b4150b11435 = ((xa447fc54e41dfe06 != 0) ? 2 : ((x2aa5114a5da7d6c8 != 0) ? 7 : 0));
				break;
			case 2:
			{
				if (num2 == 0)
				{
					x81ab2bc14c781288 = num3;
					x9bc58d3ebc0c6301 = i;
					_x75d376891c19d365.x3401b50873ad59be = num2;
					_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
					_x75d376891c19d365.x564ec8a071685a21 = num;
					xe95ef630fef0a7ff = num4;
					return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				}
				if (num5 == 0)
				{
					if (num4 == xca09b6c2b5b18485 && x5586b6ed3aa176aa != 0)
					{
						num4 = 0;
						num5 = ((num4 < x5586b6ed3aa176aa) ? (x5586b6ed3aa176aa - num4 - 1) : (xca09b6c2b5b18485 - num4));
					}
					if (num5 == 0)
					{
						xe95ef630fef0a7ff = num4;
						xb55b340ae3a3e4e0 = xbb7550bbb62a218c(xb55b340ae3a3e4e0);
						num4 = xe95ef630fef0a7ff;
						num5 = ((num4 < x5586b6ed3aa176aa) ? (x5586b6ed3aa176aa - num4 - 1) : (xca09b6c2b5b18485 - num4));
						if (num4 == xca09b6c2b5b18485 && x5586b6ed3aa176aa != 0)
						{
							num4 = 0;
							num5 = ((num4 < x5586b6ed3aa176aa) ? (x5586b6ed3aa176aa - num4 - 1) : (xca09b6c2b5b18485 - num4));
						}
						if (num5 == 0)
						{
							x81ab2bc14c781288 = num3;
							x9bc58d3ebc0c6301 = i;
							_x75d376891c19d365.x3401b50873ad59be = num2;
							_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
							_x75d376891c19d365.x564ec8a071685a21 = num;
							xe95ef630fef0a7ff = num4;
							return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
						}
					}
				}
				xb55b340ae3a3e4e0 = 0;
				int num6 = xa447fc54e41dfe06;
				if (num6 > num2)
				{
					num6 = num2;
				}
				if (num6 > num5)
				{
					num6 = num5;
				}
				Array.Copy(_x75d376891c19d365.x44c6db5b64538d67, num, x76b3d9d2638e5ecd, num4, num6);
				num += num6;
				num2 -= num6;
				num4 += num6;
				num5 -= num6;
				if ((xa447fc54e41dfe06 -= num6) == 0)
				{
					xa4aa8b4150b11435 = ((x2aa5114a5da7d6c8 != 0) ? 7 : 0);
				}
				break;
			}
			case 3:
			{
				for (; i < 14; i += 8)
				{
					if (num2 != 0)
					{
						xb55b340ae3a3e4e0 = 0;
						num2--;
						num3 |= (_x75d376891c19d365.x44c6db5b64538d67[num++] & 0xFF) << i;
						continue;
					}
					x81ab2bc14c781288 = num3;
					x9bc58d3ebc0c6301 = i;
					_x75d376891c19d365.x3401b50873ad59be = num2;
					_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
					_x75d376891c19d365.x564ec8a071685a21 = num;
					xe95ef630fef0a7ff = num4;
					return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				}
				int num6 = (x1ec770899c98a268 = num3 & 0x3FFF);
				if ((num6 & 0x1F) > 29 || ((num6 >> 5) & 0x1F) > 29)
				{
					xa4aa8b4150b11435 = 9;
					_x75d376891c19d365.xd397bb1e465ce45e = "too many length or distance symbols";
					xb55b340ae3a3e4e0 = -3;
					x81ab2bc14c781288 = num3;
					x9bc58d3ebc0c6301 = i;
					_x75d376891c19d365.x3401b50873ad59be = num2;
					_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
					_x75d376891c19d365.x564ec8a071685a21 = num;
					xe95ef630fef0a7ff = num4;
					return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				}
				num6 = 258 + (num6 & 0x1F) + ((num6 >> 5) & 0x1F);
				if (xd80c151cb6289894 == null || xd80c151cb6289894.Length < num6)
				{
					xd80c151cb6289894 = new int[num6];
				}
				else
				{
					for (int j = 0; j < num6; j++)
					{
						xd80c151cb6289894[j] = 0;
					}
				}
				num3 = x71e71339e29fbf2b.x708a60ec8cfa708b(num3, 14);
				i -= 14;
				xc0c4c459c6ccbd00 = 0;
				xa4aa8b4150b11435 = 4;
				goto case 4;
			}
			case 4:
			{
				while (xc0c4c459c6ccbd00 < 4 + x71e71339e29fbf2b.x708a60ec8cfa708b(x1ec770899c98a268, 10))
				{
					for (; i < 3; i += 8)
					{
						if (num2 != 0)
						{
							xb55b340ae3a3e4e0 = 0;
							num2--;
							num3 |= (_x75d376891c19d365.x44c6db5b64538d67[num++] & 0xFF) << i;
							continue;
						}
						x81ab2bc14c781288 = num3;
						x9bc58d3ebc0c6301 = i;
						_x75d376891c19d365.x3401b50873ad59be = num2;
						_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
						_x75d376891c19d365.x564ec8a071685a21 = num;
						xe95ef630fef0a7ff = num4;
						return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
					}
					xd80c151cb6289894[x14cf9593b86ecbaa[xc0c4c459c6ccbd00++]] = num3 & 7;
					num3 = x71e71339e29fbf2b.x708a60ec8cfa708b(num3, 3);
					i -= 3;
				}
				while (xc0c4c459c6ccbd00 < 19)
				{
					xd80c151cb6289894[x14cf9593b86ecbaa[xc0c4c459c6ccbd00++]] = 0;
				}
				xa8599b40401c5d34[0] = 7;
				int num6 = xf0216b28ecfe25dd.x8773aa98dd3dd9b3(xd80c151cb6289894, xa8599b40401c5d34, xa5886b2a445f53f4, x2a1ba593d4ab15ba, _x75d376891c19d365);
				if (num6 != 0)
				{
					xb55b340ae3a3e4e0 = num6;
					if (xb55b340ae3a3e4e0 == -3)
					{
						xd80c151cb6289894 = null;
						xa4aa8b4150b11435 = 9;
					}
					x81ab2bc14c781288 = num3;
					x9bc58d3ebc0c6301 = i;
					_x75d376891c19d365.x3401b50873ad59be = num2;
					_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
					_x75d376891c19d365.x564ec8a071685a21 = num;
					xe95ef630fef0a7ff = num4;
					return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				}
				xc0c4c459c6ccbd00 = 0;
				xa4aa8b4150b11435 = 5;
				goto case 5;
			}
			case 5:
			{
				int num6;
				while (true)
				{
					num6 = x1ec770899c98a268;
					if (xc0c4c459c6ccbd00 >= 258 + (num6 & 0x1F) + ((num6 >> 5) & 0x1F))
					{
						break;
					}
					for (num6 = xa8599b40401c5d34[0]; i < num6; i += 8)
					{
						if (num2 != 0)
						{
							xb55b340ae3a3e4e0 = 0;
							num2--;
							num3 |= (_x75d376891c19d365.x44c6db5b64538d67[num++] & 0xFF) << i;
							continue;
						}
						x81ab2bc14c781288 = num3;
						x9bc58d3ebc0c6301 = i;
						_x75d376891c19d365.x3401b50873ad59be = num2;
						_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
						_x75d376891c19d365.x564ec8a071685a21 = num;
						xe95ef630fef0a7ff = num4;
						return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
					}
					_ = xa5886b2a445f53f4[0];
					_ = -1;
					num6 = x2a1ba593d4ab15ba[(xa5886b2a445f53f4[0] + (num3 & xa454a72a9452f39c[num6])) * 3 + 1];
					int num7 = x2a1ba593d4ab15ba[(xa5886b2a445f53f4[0] + (num3 & xa454a72a9452f39c[num6])) * 3 + 2];
					if (num7 < 16)
					{
						num3 = x71e71339e29fbf2b.x708a60ec8cfa708b(num3, num6);
						i -= num6;
						xd80c151cb6289894[xc0c4c459c6ccbd00++] = num7;
						continue;
					}
					int num8 = ((num7 == 18) ? 7 : (num7 - 14));
					int num9 = ((num7 == 18) ? 11 : 3);
					for (; i < num6 + num8; i += 8)
					{
						if (num2 != 0)
						{
							xb55b340ae3a3e4e0 = 0;
							num2--;
							num3 |= (_x75d376891c19d365.x44c6db5b64538d67[num++] & 0xFF) << i;
							continue;
						}
						x81ab2bc14c781288 = num3;
						x9bc58d3ebc0c6301 = i;
						_x75d376891c19d365.x3401b50873ad59be = num2;
						_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
						_x75d376891c19d365.x564ec8a071685a21 = num;
						xe95ef630fef0a7ff = num4;
						return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
					}
					num3 = x71e71339e29fbf2b.x708a60ec8cfa708b(num3, num6);
					i -= num6;
					num9 += num3 & xa454a72a9452f39c[num8];
					num3 = x71e71339e29fbf2b.x708a60ec8cfa708b(num3, num8);
					i -= num8;
					num8 = xc0c4c459c6ccbd00;
					num6 = x1ec770899c98a268;
					if (num8 + num9 > 258 + (num6 & 0x1F) + ((num6 >> 5) & 0x1F) || (num7 == 16 && num8 < 1))
					{
						xd80c151cb6289894 = null;
						xa4aa8b4150b11435 = 9;
						_x75d376891c19d365.xd397bb1e465ce45e = "invalid bit length repeat";
						xb55b340ae3a3e4e0 = -3;
						x81ab2bc14c781288 = num3;
						x9bc58d3ebc0c6301 = i;
						_x75d376891c19d365.x3401b50873ad59be = num2;
						_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
						_x75d376891c19d365.x564ec8a071685a21 = num;
						xe95ef630fef0a7ff = num4;
						return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
					}
					num7 = ((num7 == 16) ? xd80c151cb6289894[num8 - 1] : 0);
					do
					{
						xd80c151cb6289894[num8++] = num7;
					}
					while (--num9 != 0);
					xc0c4c459c6ccbd00 = num8;
				}
				xa5886b2a445f53f4[0] = -1;
				int[] array5 = new int[1] { 9 };
				int[] array6 = new int[1] { 6 };
				int[] array7 = new int[1];
				int[] array8 = new int[1];
				num6 = x1ec770899c98a268;
				num6 = xf0216b28ecfe25dd.x33814d6c67554cf7(257 + (num6 & 0x1F), 1 + ((num6 >> 5) & 0x1F), xd80c151cb6289894, array5, array6, array7, array8, x2a1ba593d4ab15ba, _x75d376891c19d365);
				if (num6 != 0)
				{
					if (num6 == -3)
					{
						xd80c151cb6289894 = null;
						xa4aa8b4150b11435 = 9;
					}
					xb55b340ae3a3e4e0 = num6;
					x81ab2bc14c781288 = num3;
					x9bc58d3ebc0c6301 = i;
					_x75d376891c19d365.x3401b50873ad59be = num2;
					_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
					_x75d376891c19d365.x564ec8a071685a21 = num;
					xe95ef630fef0a7ff = num4;
					return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				}
				xcdff170dbac909bf.xd586e0c16bdae7fc(array5[0], array6[0], x2a1ba593d4ab15ba, array7[0], x2a1ba593d4ab15ba, array8[0]);
				xa4aa8b4150b11435 = 6;
				goto case 6;
			}
			case 6:
				x81ab2bc14c781288 = num3;
				x9bc58d3ebc0c6301 = i;
				_x75d376891c19d365.x3401b50873ad59be = num2;
				_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
				_x75d376891c19d365.x564ec8a071685a21 = num;
				xe95ef630fef0a7ff = num4;
				if ((xb55b340ae3a3e4e0 = xcdff170dbac909bf.x5d3a1f6283012a22(this, xb55b340ae3a3e4e0)) != 1)
				{
					return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				}
				xb55b340ae3a3e4e0 = 0;
				num = _x75d376891c19d365.x564ec8a071685a21;
				num2 = _x75d376891c19d365.x3401b50873ad59be;
				num3 = x81ab2bc14c781288;
				i = x9bc58d3ebc0c6301;
				num4 = xe95ef630fef0a7ff;
				num5 = ((num4 < x5586b6ed3aa176aa) ? (x5586b6ed3aa176aa - num4 - 1) : (xca09b6c2b5b18485 - num4));
				if (x2aa5114a5da7d6c8 == 0)
				{
					xa4aa8b4150b11435 = 0;
					break;
				}
				xa4aa8b4150b11435 = 7;
				goto case 7;
			case 7:
				xe95ef630fef0a7ff = num4;
				xb55b340ae3a3e4e0 = xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				num4 = xe95ef630fef0a7ff;
				num5 = ((num4 < x5586b6ed3aa176aa) ? (x5586b6ed3aa176aa - num4 - 1) : (xca09b6c2b5b18485 - num4));
				if (x5586b6ed3aa176aa != xe95ef630fef0a7ff)
				{
					x81ab2bc14c781288 = num3;
					x9bc58d3ebc0c6301 = i;
					_x75d376891c19d365.x3401b50873ad59be = num2;
					_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
					_x75d376891c19d365.x564ec8a071685a21 = num;
					xe95ef630fef0a7ff = num4;
					return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				}
				xa4aa8b4150b11435 = 8;
				goto case 8;
			case 8:
				xb55b340ae3a3e4e0 = 1;
				x81ab2bc14c781288 = num3;
				x9bc58d3ebc0c6301 = i;
				_x75d376891c19d365.x3401b50873ad59be = num2;
				_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
				_x75d376891c19d365.x564ec8a071685a21 = num;
				xe95ef630fef0a7ff = num4;
				return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
			case 9:
				xb55b340ae3a3e4e0 = -3;
				x81ab2bc14c781288 = num3;
				x9bc58d3ebc0c6301 = i;
				_x75d376891c19d365.x3401b50873ad59be = num2;
				_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
				_x75d376891c19d365.x564ec8a071685a21 = num;
				xe95ef630fef0a7ff = num4;
				return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
			default:
				xb55b340ae3a3e4e0 = -2;
				x81ab2bc14c781288 = num3;
				x9bc58d3ebc0c6301 = i;
				_x75d376891c19d365.x3401b50873ad59be = num2;
				_x75d376891c19d365.x4898fcfa8d5dd0b2 += num - _x75d376891c19d365.x564ec8a071685a21;
				_x75d376891c19d365.x564ec8a071685a21 = num;
				xe95ef630fef0a7ff = num4;
				return xbb7550bbb62a218c(xb55b340ae3a3e4e0);
			}
		}
	}

	internal void xd2cd64b1e950d3dc()
	{
		x74f5a1ef3906e23c(null);
		x76b3d9d2638e5ecd = null;
		x2a1ba593d4ab15ba = null;
	}

	internal void xc2e30ed258f46b33(byte[] x73f821c71fe1e676, int x10aaa7cdfa38f254, int x57e9faf3ffdc07cc)
	{
		Array.Copy(x73f821c71fe1e676, x10aaa7cdfa38f254, x76b3d9d2638e5ecd, 0, x57e9faf3ffdc07cc);
		x5586b6ed3aa176aa = (xe95ef630fef0a7ff = x57e9faf3ffdc07cc);
	}

	internal int xb9d7575e60b25f5c()
	{
		if (xa4aa8b4150b11435 != 1)
		{
			return 0;
		}
		return 1;
	}

	internal int xbb7550bbb62a218c(int xb55b340ae3a3e4e0)
	{
		int xb5375db3326c5e6d = _x75d376891c19d365.xb5375db3326c5e6d;
		int num = x5586b6ed3aa176aa;
		int num2 = ((num <= xe95ef630fef0a7ff) ? xe95ef630fef0a7ff : xca09b6c2b5b18485) - num;
		if (num2 > _x75d376891c19d365.x3ce290765cb44316)
		{
			num2 = _x75d376891c19d365.x3ce290765cb44316;
		}
		if (xb55b340ae3a3e4e0 == -5)
		{
			xb55b340ae3a3e4e0 = 0;
		}
		_x75d376891c19d365.x3ce290765cb44316 -= num2;
		_x75d376891c19d365.x8d79d7f35d1df930 += num2;
		if (xddded55f98ca3594 != null)
		{
			_x75d376891c19d365._x7ab4a0dd1a2efc16 = (xb48f46f4fb07ae5f = xb23dc957c3e5bff6.x7ab4a0dd1a2efc16(xb48f46f4fb07ae5f, x76b3d9d2638e5ecd, num, num2));
		}
		Array.Copy(x76b3d9d2638e5ecd, num, _x75d376891c19d365.x77ba06e5be4d4d72, xb5375db3326c5e6d, num2);
		xb5375db3326c5e6d += num2;
		num += num2;
		if (num == xca09b6c2b5b18485)
		{
			num = 0;
			if (xe95ef630fef0a7ff == xca09b6c2b5b18485)
			{
				xe95ef630fef0a7ff = 0;
			}
			num2 = xe95ef630fef0a7ff - num;
			if (num2 > _x75d376891c19d365.x3ce290765cb44316)
			{
				num2 = _x75d376891c19d365.x3ce290765cb44316;
			}
			if (num2 != 0 && xb55b340ae3a3e4e0 == -5)
			{
				xb55b340ae3a3e4e0 = 0;
			}
			_x75d376891c19d365.x3ce290765cb44316 -= num2;
			_x75d376891c19d365.x8d79d7f35d1df930 += num2;
			if (xddded55f98ca3594 != null)
			{
				_x75d376891c19d365._x7ab4a0dd1a2efc16 = (xb48f46f4fb07ae5f = xb23dc957c3e5bff6.x7ab4a0dd1a2efc16(xb48f46f4fb07ae5f, x76b3d9d2638e5ecd, num, num2));
			}
			Array.Copy(x76b3d9d2638e5ecd, num, _x75d376891c19d365.x77ba06e5be4d4d72, xb5375db3326c5e6d, num2);
			xb5375db3326c5e6d += num2;
			num += num2;
		}
		_x75d376891c19d365.xb5375db3326c5e6d = xb5375db3326c5e6d;
		x5586b6ed3aa176aa = num;
		return xb55b340ae3a3e4e0;
	}
}
