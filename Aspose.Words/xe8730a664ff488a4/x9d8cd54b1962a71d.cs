using System;
using Aspose;

namespace xe8730a664ff488a4;

[JavaDelete("Using java zip instead.")]
internal sealed class x9d8cd54b1962a71d
{
	private const int xc9ff9e8dde18ba69 = 0;

	private const int x00b5a6bf59ff2714 = 1;

	private const int x8178f8449cda970e = 2;

	private const int xddbafb868459ac0f = 3;

	private const int xa2f12b8acbc67f33 = 4;

	private const int x17676357531df874 = 5;

	private const int xd2a15e441fae90f1 = 6;

	private const int xbc606a824b3a6f92 = 7;

	private const int xa65c46ac708fe01a = 8;

	private const int xb51247e88b279914 = 9;

	private static readonly int[] xa454a72a9452f39c = new int[17]
	{
		0, 1, 3, 7, 15, 31, 63, 127, 255, 511,
		1023, 2047, 4095, 8191, 16383, 32767, 65535
	};

	internal int xa4aa8b4150b11435;

	internal int xb5964a891b6cf7c3;

	internal int[] x2ab16cc75cbe6a5d;

	internal int xe0abdc1c7bcc1de3;

	internal int xd5842df57f205543;

	internal int x82320407fdba5982;

	internal int get_x1e6ff19d0bd95f26;

	internal int x090bbc85381ea59f;

	internal byte xba9b42a4bfa90f0a;

	internal byte x30ff99281a0547ba;

	internal int[] xa610e856d8921e4c;

	internal int x1c0eeaf0ef0ecebb;

	internal int[] xb5dba6cdb7e854d7;

	internal int x0dd3de676702b5d4;

	internal x9d8cd54b1962a71d()
	{
	}

	internal void xd586e0c16bdae7fc(int x6b631e0009a9deea, int x22e5c75a078dd58b, int[] x1c451fcdeb5e758f, int x19df459d8e394090, int[] xc573ad5708152799, int xbbe38477d7e82abf)
	{
		xa4aa8b4150b11435 = 0;
		xba9b42a4bfa90f0a = (byte)x6b631e0009a9deea;
		x30ff99281a0547ba = (byte)x22e5c75a078dd58b;
		xa610e856d8921e4c = x1c451fcdeb5e758f;
		x1c0eeaf0ef0ecebb = x19df459d8e394090;
		xb5dba6cdb7e854d7 = xc573ad5708152799;
		x0dd3de676702b5d4 = xbbe38477d7e82abf;
		x2ab16cc75cbe6a5d = null;
	}

	internal int x5d3a1f6283012a22(xbe9c370878285c10 xd2f7a26499207fdd, int xb55b340ae3a3e4e0)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		x5a92807060bc6079 x75d376891c19d = xd2f7a26499207fdd._x75d376891c19d365;
		num3 = x75d376891c19d.x564ec8a071685a21;
		int num4 = x75d376891c19d.x3401b50873ad59be;
		num = xd2f7a26499207fdd.x81ab2bc14c781288;
		num2 = xd2f7a26499207fdd.x9bc58d3ebc0c6301;
		int num5 = xd2f7a26499207fdd.xe95ef630fef0a7ff;
		int num6 = ((num5 < xd2f7a26499207fdd.x5586b6ed3aa176aa) ? (xd2f7a26499207fdd.x5586b6ed3aa176aa - num5 - 1) : (xd2f7a26499207fdd.xca09b6c2b5b18485 - num5));
		while (true)
		{
			switch (xa4aa8b4150b11435)
			{
			case 0:
				if (num6 >= 258 && num4 >= 10)
				{
					xd2f7a26499207fdd.x81ab2bc14c781288 = num;
					xd2f7a26499207fdd.x9bc58d3ebc0c6301 = num2;
					x75d376891c19d.x3401b50873ad59be = num4;
					x75d376891c19d.x4898fcfa8d5dd0b2 += num3 - x75d376891c19d.x564ec8a071685a21;
					x75d376891c19d.x564ec8a071685a21 = num3;
					xd2f7a26499207fdd.xe95ef630fef0a7ff = num5;
					xb55b340ae3a3e4e0 = xd935062dcc26eadf(xba9b42a4bfa90f0a, x30ff99281a0547ba, xa610e856d8921e4c, x1c0eeaf0ef0ecebb, xb5dba6cdb7e854d7, x0dd3de676702b5d4, xd2f7a26499207fdd, x75d376891c19d);
					num3 = x75d376891c19d.x564ec8a071685a21;
					num4 = x75d376891c19d.x3401b50873ad59be;
					num = xd2f7a26499207fdd.x81ab2bc14c781288;
					num2 = xd2f7a26499207fdd.x9bc58d3ebc0c6301;
					num5 = xd2f7a26499207fdd.xe95ef630fef0a7ff;
					num6 = ((num5 < xd2f7a26499207fdd.x5586b6ed3aa176aa) ? (xd2f7a26499207fdd.x5586b6ed3aa176aa - num5 - 1) : (xd2f7a26499207fdd.xca09b6c2b5b18485 - num5));
					if (xb55b340ae3a3e4e0 != 0)
					{
						xa4aa8b4150b11435 = ((xb55b340ae3a3e4e0 == 1) ? 7 : 9);
						break;
					}
				}
				xd5842df57f205543 = xba9b42a4bfa90f0a;
				x2ab16cc75cbe6a5d = xa610e856d8921e4c;
				xe0abdc1c7bcc1de3 = x1c0eeaf0ef0ecebb;
				xa4aa8b4150b11435 = 1;
				goto case 1;
			case 1:
			{
				int num7;
				for (num7 = xd5842df57f205543; num2 < num7; num2 += 8)
				{
					if (num4 != 0)
					{
						xb55b340ae3a3e4e0 = 0;
						num4--;
						num |= (x75d376891c19d.x44c6db5b64538d67[num3++] & 0xFF) << num2;
						continue;
					}
					xd2f7a26499207fdd.x81ab2bc14c781288 = num;
					xd2f7a26499207fdd.x9bc58d3ebc0c6301 = num2;
					x75d376891c19d.x3401b50873ad59be = num4;
					x75d376891c19d.x4898fcfa8d5dd0b2 += num3 - x75d376891c19d.x564ec8a071685a21;
					x75d376891c19d.x564ec8a071685a21 = num3;
					xd2f7a26499207fdd.xe95ef630fef0a7ff = num5;
					return xd2f7a26499207fdd.xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				}
				int num8 = (xe0abdc1c7bcc1de3 + (num & xa454a72a9452f39c[num7])) * 3;
				num = x71e71339e29fbf2b.x708a60ec8cfa708b(num, x2ab16cc75cbe6a5d[num8 + 1]);
				num2 -= x2ab16cc75cbe6a5d[num8 + 1];
				int num9 = x2ab16cc75cbe6a5d[num8];
				if (num9 == 0)
				{
					x82320407fdba5982 = x2ab16cc75cbe6a5d[num8 + 2];
					xa4aa8b4150b11435 = 6;
					break;
				}
				if (((uint)num9 & 0x10u) != 0)
				{
					get_x1e6ff19d0bd95f26 = num9 & 0xF;
					xb5964a891b6cf7c3 = x2ab16cc75cbe6a5d[num8 + 2];
					xa4aa8b4150b11435 = 2;
					break;
				}
				if ((num9 & 0x40) == 0)
				{
					xd5842df57f205543 = num9;
					xe0abdc1c7bcc1de3 = num8 / 3 + x2ab16cc75cbe6a5d[num8 + 2];
					break;
				}
				if (((uint)num9 & 0x20u) != 0)
				{
					xa4aa8b4150b11435 = 7;
					break;
				}
				xa4aa8b4150b11435 = 9;
				x75d376891c19d.xd397bb1e465ce45e = "invalid literal/length code";
				xb55b340ae3a3e4e0 = -3;
				xd2f7a26499207fdd.x81ab2bc14c781288 = num;
				xd2f7a26499207fdd.x9bc58d3ebc0c6301 = num2;
				x75d376891c19d.x3401b50873ad59be = num4;
				x75d376891c19d.x4898fcfa8d5dd0b2 += num3 - x75d376891c19d.x564ec8a071685a21;
				x75d376891c19d.x564ec8a071685a21 = num3;
				xd2f7a26499207fdd.xe95ef630fef0a7ff = num5;
				return xd2f7a26499207fdd.xbb7550bbb62a218c(xb55b340ae3a3e4e0);
			}
			case 2:
			{
				int num7;
				for (num7 = get_x1e6ff19d0bd95f26; num2 < num7; num2 += 8)
				{
					if (num4 != 0)
					{
						xb55b340ae3a3e4e0 = 0;
						num4--;
						num |= (x75d376891c19d.x44c6db5b64538d67[num3++] & 0xFF) << num2;
						continue;
					}
					xd2f7a26499207fdd.x81ab2bc14c781288 = num;
					xd2f7a26499207fdd.x9bc58d3ebc0c6301 = num2;
					x75d376891c19d.x3401b50873ad59be = num4;
					x75d376891c19d.x4898fcfa8d5dd0b2 += num3 - x75d376891c19d.x564ec8a071685a21;
					x75d376891c19d.x564ec8a071685a21 = num3;
					xd2f7a26499207fdd.xe95ef630fef0a7ff = num5;
					return xd2f7a26499207fdd.xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				}
				xb5964a891b6cf7c3 += num & xa454a72a9452f39c[num7];
				num >>= num7;
				num2 -= num7;
				xd5842df57f205543 = x30ff99281a0547ba;
				x2ab16cc75cbe6a5d = xb5dba6cdb7e854d7;
				xe0abdc1c7bcc1de3 = x0dd3de676702b5d4;
				xa4aa8b4150b11435 = 3;
				goto case 3;
			}
			case 3:
			{
				int num7;
				for (num7 = xd5842df57f205543; num2 < num7; num2 += 8)
				{
					if (num4 != 0)
					{
						xb55b340ae3a3e4e0 = 0;
						num4--;
						num |= (x75d376891c19d.x44c6db5b64538d67[num3++] & 0xFF) << num2;
						continue;
					}
					xd2f7a26499207fdd.x81ab2bc14c781288 = num;
					xd2f7a26499207fdd.x9bc58d3ebc0c6301 = num2;
					x75d376891c19d.x3401b50873ad59be = num4;
					x75d376891c19d.x4898fcfa8d5dd0b2 += num3 - x75d376891c19d.x564ec8a071685a21;
					x75d376891c19d.x564ec8a071685a21 = num3;
					xd2f7a26499207fdd.xe95ef630fef0a7ff = num5;
					return xd2f7a26499207fdd.xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				}
				int num8 = (xe0abdc1c7bcc1de3 + (num & xa454a72a9452f39c[num7])) * 3;
				num >>= x2ab16cc75cbe6a5d[num8 + 1];
				num2 -= x2ab16cc75cbe6a5d[num8 + 1];
				int num9 = x2ab16cc75cbe6a5d[num8];
				if (((uint)num9 & 0x10u) != 0)
				{
					get_x1e6ff19d0bd95f26 = num9 & 0xF;
					x090bbc85381ea59f = x2ab16cc75cbe6a5d[num8 + 2];
					xa4aa8b4150b11435 = 4;
					break;
				}
				if ((num9 & 0x40) == 0)
				{
					xd5842df57f205543 = num9;
					xe0abdc1c7bcc1de3 = num8 / 3 + x2ab16cc75cbe6a5d[num8 + 2];
					break;
				}
				xa4aa8b4150b11435 = 9;
				x75d376891c19d.xd397bb1e465ce45e = "invalid distance code";
				xb55b340ae3a3e4e0 = -3;
				xd2f7a26499207fdd.x81ab2bc14c781288 = num;
				xd2f7a26499207fdd.x9bc58d3ebc0c6301 = num2;
				x75d376891c19d.x3401b50873ad59be = num4;
				x75d376891c19d.x4898fcfa8d5dd0b2 += num3 - x75d376891c19d.x564ec8a071685a21;
				x75d376891c19d.x564ec8a071685a21 = num3;
				xd2f7a26499207fdd.xe95ef630fef0a7ff = num5;
				return xd2f7a26499207fdd.xbb7550bbb62a218c(xb55b340ae3a3e4e0);
			}
			case 4:
			{
				int num7;
				for (num7 = get_x1e6ff19d0bd95f26; num2 < num7; num2 += 8)
				{
					if (num4 != 0)
					{
						xb55b340ae3a3e4e0 = 0;
						num4--;
						num |= (x75d376891c19d.x44c6db5b64538d67[num3++] & 0xFF) << num2;
						continue;
					}
					xd2f7a26499207fdd.x81ab2bc14c781288 = num;
					xd2f7a26499207fdd.x9bc58d3ebc0c6301 = num2;
					x75d376891c19d.x3401b50873ad59be = num4;
					x75d376891c19d.x4898fcfa8d5dd0b2 += num3 - x75d376891c19d.x564ec8a071685a21;
					x75d376891c19d.x564ec8a071685a21 = num3;
					xd2f7a26499207fdd.xe95ef630fef0a7ff = num5;
					return xd2f7a26499207fdd.xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				}
				x090bbc85381ea59f += num & xa454a72a9452f39c[num7];
				num >>= num7;
				num2 -= num7;
				xa4aa8b4150b11435 = 5;
				goto case 5;
			}
			case 5:
			{
				int i;
				for (i = num5 - x090bbc85381ea59f; i < 0; i += xd2f7a26499207fdd.xca09b6c2b5b18485)
				{
				}
				while (xb5964a891b6cf7c3 != 0)
				{
					if (num6 == 0)
					{
						if (num5 == xd2f7a26499207fdd.xca09b6c2b5b18485 && xd2f7a26499207fdd.x5586b6ed3aa176aa != 0)
						{
							num5 = 0;
							num6 = ((num5 < xd2f7a26499207fdd.x5586b6ed3aa176aa) ? (xd2f7a26499207fdd.x5586b6ed3aa176aa - num5 - 1) : (xd2f7a26499207fdd.xca09b6c2b5b18485 - num5));
						}
						if (num6 == 0)
						{
							xd2f7a26499207fdd.xe95ef630fef0a7ff = num5;
							xb55b340ae3a3e4e0 = xd2f7a26499207fdd.xbb7550bbb62a218c(xb55b340ae3a3e4e0);
							num5 = xd2f7a26499207fdd.xe95ef630fef0a7ff;
							num6 = ((num5 < xd2f7a26499207fdd.x5586b6ed3aa176aa) ? (xd2f7a26499207fdd.x5586b6ed3aa176aa - num5 - 1) : (xd2f7a26499207fdd.xca09b6c2b5b18485 - num5));
							if (num5 == xd2f7a26499207fdd.xca09b6c2b5b18485 && xd2f7a26499207fdd.x5586b6ed3aa176aa != 0)
							{
								num5 = 0;
								num6 = ((num5 < xd2f7a26499207fdd.x5586b6ed3aa176aa) ? (xd2f7a26499207fdd.x5586b6ed3aa176aa - num5 - 1) : (xd2f7a26499207fdd.xca09b6c2b5b18485 - num5));
							}
							if (num6 == 0)
							{
								xd2f7a26499207fdd.x81ab2bc14c781288 = num;
								xd2f7a26499207fdd.x9bc58d3ebc0c6301 = num2;
								x75d376891c19d.x3401b50873ad59be = num4;
								x75d376891c19d.x4898fcfa8d5dd0b2 += num3 - x75d376891c19d.x564ec8a071685a21;
								x75d376891c19d.x564ec8a071685a21 = num3;
								xd2f7a26499207fdd.xe95ef630fef0a7ff = num5;
								return xd2f7a26499207fdd.xbb7550bbb62a218c(xb55b340ae3a3e4e0);
							}
						}
					}
					xd2f7a26499207fdd.x76b3d9d2638e5ecd[num5++] = xd2f7a26499207fdd.x76b3d9d2638e5ecd[i++];
					num6--;
					if (i == xd2f7a26499207fdd.xca09b6c2b5b18485)
					{
						i = 0;
					}
					xb5964a891b6cf7c3--;
				}
				xa4aa8b4150b11435 = 0;
				break;
			}
			case 6:
				if (num6 == 0)
				{
					if (num5 == xd2f7a26499207fdd.xca09b6c2b5b18485 && xd2f7a26499207fdd.x5586b6ed3aa176aa != 0)
					{
						num5 = 0;
						num6 = ((num5 < xd2f7a26499207fdd.x5586b6ed3aa176aa) ? (xd2f7a26499207fdd.x5586b6ed3aa176aa - num5 - 1) : (xd2f7a26499207fdd.xca09b6c2b5b18485 - num5));
					}
					if (num6 == 0)
					{
						xd2f7a26499207fdd.xe95ef630fef0a7ff = num5;
						xb55b340ae3a3e4e0 = xd2f7a26499207fdd.xbb7550bbb62a218c(xb55b340ae3a3e4e0);
						num5 = xd2f7a26499207fdd.xe95ef630fef0a7ff;
						num6 = ((num5 < xd2f7a26499207fdd.x5586b6ed3aa176aa) ? (xd2f7a26499207fdd.x5586b6ed3aa176aa - num5 - 1) : (xd2f7a26499207fdd.xca09b6c2b5b18485 - num5));
						if (num5 == xd2f7a26499207fdd.xca09b6c2b5b18485 && xd2f7a26499207fdd.x5586b6ed3aa176aa != 0)
						{
							num5 = 0;
							num6 = ((num5 < xd2f7a26499207fdd.x5586b6ed3aa176aa) ? (xd2f7a26499207fdd.x5586b6ed3aa176aa - num5 - 1) : (xd2f7a26499207fdd.xca09b6c2b5b18485 - num5));
						}
						if (num6 == 0)
						{
							xd2f7a26499207fdd.x81ab2bc14c781288 = num;
							xd2f7a26499207fdd.x9bc58d3ebc0c6301 = num2;
							x75d376891c19d.x3401b50873ad59be = num4;
							x75d376891c19d.x4898fcfa8d5dd0b2 += num3 - x75d376891c19d.x564ec8a071685a21;
							x75d376891c19d.x564ec8a071685a21 = num3;
							xd2f7a26499207fdd.xe95ef630fef0a7ff = num5;
							return xd2f7a26499207fdd.xbb7550bbb62a218c(xb55b340ae3a3e4e0);
						}
					}
				}
				xb55b340ae3a3e4e0 = 0;
				xd2f7a26499207fdd.x76b3d9d2638e5ecd[num5++] = (byte)x82320407fdba5982;
				num6--;
				xa4aa8b4150b11435 = 0;
				break;
			case 7:
				if (num2 > 7)
				{
					num2 -= 8;
					num4++;
					num3--;
				}
				xd2f7a26499207fdd.xe95ef630fef0a7ff = num5;
				xb55b340ae3a3e4e0 = xd2f7a26499207fdd.xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				num5 = xd2f7a26499207fdd.xe95ef630fef0a7ff;
				num6 = ((num5 < xd2f7a26499207fdd.x5586b6ed3aa176aa) ? (xd2f7a26499207fdd.x5586b6ed3aa176aa - num5 - 1) : (xd2f7a26499207fdd.xca09b6c2b5b18485 - num5));
				if (xd2f7a26499207fdd.x5586b6ed3aa176aa != xd2f7a26499207fdd.xe95ef630fef0a7ff)
				{
					xd2f7a26499207fdd.x81ab2bc14c781288 = num;
					xd2f7a26499207fdd.x9bc58d3ebc0c6301 = num2;
					x75d376891c19d.x3401b50873ad59be = num4;
					x75d376891c19d.x4898fcfa8d5dd0b2 += num3 - x75d376891c19d.x564ec8a071685a21;
					x75d376891c19d.x564ec8a071685a21 = num3;
					xd2f7a26499207fdd.xe95ef630fef0a7ff = num5;
					return xd2f7a26499207fdd.xbb7550bbb62a218c(xb55b340ae3a3e4e0);
				}
				xa4aa8b4150b11435 = 8;
				goto case 8;
			case 8:
				xb55b340ae3a3e4e0 = 1;
				xd2f7a26499207fdd.x81ab2bc14c781288 = num;
				xd2f7a26499207fdd.x9bc58d3ebc0c6301 = num2;
				x75d376891c19d.x3401b50873ad59be = num4;
				x75d376891c19d.x4898fcfa8d5dd0b2 += num3 - x75d376891c19d.x564ec8a071685a21;
				x75d376891c19d.x564ec8a071685a21 = num3;
				xd2f7a26499207fdd.xe95ef630fef0a7ff = num5;
				return xd2f7a26499207fdd.xbb7550bbb62a218c(xb55b340ae3a3e4e0);
			case 9:
				xb55b340ae3a3e4e0 = -3;
				xd2f7a26499207fdd.x81ab2bc14c781288 = num;
				xd2f7a26499207fdd.x9bc58d3ebc0c6301 = num2;
				x75d376891c19d.x3401b50873ad59be = num4;
				x75d376891c19d.x4898fcfa8d5dd0b2 += num3 - x75d376891c19d.x564ec8a071685a21;
				x75d376891c19d.x564ec8a071685a21 = num3;
				xd2f7a26499207fdd.xe95ef630fef0a7ff = num5;
				return xd2f7a26499207fdd.xbb7550bbb62a218c(xb55b340ae3a3e4e0);
			default:
				xb55b340ae3a3e4e0 = -2;
				xd2f7a26499207fdd.x81ab2bc14c781288 = num;
				xd2f7a26499207fdd.x9bc58d3ebc0c6301 = num2;
				x75d376891c19d.x3401b50873ad59be = num4;
				x75d376891c19d.x4898fcfa8d5dd0b2 += num3 - x75d376891c19d.x564ec8a071685a21;
				x75d376891c19d.x564ec8a071685a21 = num3;
				xd2f7a26499207fdd.xe95ef630fef0a7ff = num5;
				return xd2f7a26499207fdd.xbb7550bbb62a218c(xb55b340ae3a3e4e0);
			}
		}
	}

	internal int xd935062dcc26eadf(int x6b631e0009a9deea, int x22e5c75a078dd58b, int[] x1c451fcdeb5e758f, int x19df459d8e394090, int[] xc573ad5708152799, int xbbe38477d7e82abf, xbe9c370878285c10 xe4115acdf4fbfccc, x5a92807060bc6079 x8cfbc105c29e356f)
	{
		int x564ec8a071685a = x8cfbc105c29e356f.x564ec8a071685a21;
		int num = x8cfbc105c29e356f.x3401b50873ad59be;
		int num2 = xe4115acdf4fbfccc.x81ab2bc14c781288;
		int num3 = xe4115acdf4fbfccc.x9bc58d3ebc0c6301;
		int num4 = xe4115acdf4fbfccc.xe95ef630fef0a7ff;
		int num5 = ((num4 < xe4115acdf4fbfccc.x5586b6ed3aa176aa) ? (xe4115acdf4fbfccc.x5586b6ed3aa176aa - num4 - 1) : (xe4115acdf4fbfccc.xca09b6c2b5b18485 - num4));
		int num6 = xa454a72a9452f39c[x6b631e0009a9deea];
		int num7 = xa454a72a9452f39c[x22e5c75a078dd58b];
		int num12;
		while (true)
		{
			if (num3 < 20)
			{
				num--;
				num2 |= (x8cfbc105c29e356f.x44c6db5b64538d67[x564ec8a071685a++] & 0xFF) << num3;
				num3 += 8;
				continue;
			}
			int num8 = num2 & num6;
			int[] array = x1c451fcdeb5e758f;
			int num9 = x19df459d8e394090;
			int num10 = (num9 + num8) * 3;
			int num11;
			if ((num11 = array[num10]) == 0)
			{
				num2 >>= array[num10 + 1];
				num3 -= array[num10 + 1];
				xe4115acdf4fbfccc.x76b3d9d2638e5ecd[num4++] = (byte)array[num10 + 2];
				num5--;
			}
			else
			{
				while (true)
				{
					num2 >>= array[num10 + 1];
					num3 -= array[num10 + 1];
					if (((uint)num11 & 0x10u) != 0)
					{
						num11 &= 0xF;
						num12 = array[num10 + 2] + (num2 & xa454a72a9452f39c[num11]);
						num2 >>= num11;
						for (num3 -= num11; num3 < 15; num3 += 8)
						{
							num--;
							num2 |= (x8cfbc105c29e356f.x44c6db5b64538d67[x564ec8a071685a++] & 0xFF) << num3;
						}
						num8 = num2 & num7;
						array = xc573ad5708152799;
						num9 = xbbe38477d7e82abf;
						num10 = (num9 + num8) * 3;
						num11 = array[num10];
						while (true)
						{
							num2 >>= array[num10 + 1];
							num3 -= array[num10 + 1];
							if (((uint)num11 & 0x10u) != 0)
							{
								break;
							}
							if ((num11 & 0x40) == 0)
							{
								num8 += array[num10 + 2];
								num8 += num2 & xa454a72a9452f39c[num11];
								num10 = (num9 + num8) * 3;
								num11 = array[num10];
								continue;
							}
							x8cfbc105c29e356f.xd397bb1e465ce45e = "invalid distance code";
							num12 = x8cfbc105c29e356f.x3401b50873ad59be - num;
							num12 = ((num3 >> 3 < num12) ? (num3 >> 3) : num12);
							num += num12;
							x564ec8a071685a -= num12;
							num3 -= num12 << 3;
							xe4115acdf4fbfccc.x81ab2bc14c781288 = num2;
							xe4115acdf4fbfccc.x9bc58d3ebc0c6301 = num3;
							x8cfbc105c29e356f.x3401b50873ad59be = num;
							x8cfbc105c29e356f.x4898fcfa8d5dd0b2 += x564ec8a071685a - x8cfbc105c29e356f.x564ec8a071685a21;
							x8cfbc105c29e356f.x564ec8a071685a21 = x564ec8a071685a;
							xe4115acdf4fbfccc.xe95ef630fef0a7ff = num4;
							return -3;
						}
						for (num11 &= 0xF; num3 < num11; num3 += 8)
						{
							num--;
							num2 |= (x8cfbc105c29e356f.x44c6db5b64538d67[x564ec8a071685a++] & 0xFF) << num3;
						}
						int num13 = array[num10 + 2] + (num2 & xa454a72a9452f39c[num11]);
						num2 >>= num11;
						num3 -= num11;
						num5 -= num12;
						int num14;
						if (num4 >= num13)
						{
							num14 = num4 - num13;
							if (num4 - num14 > 0 && 2 > num4 - num14)
							{
								xe4115acdf4fbfccc.x76b3d9d2638e5ecd[num4++] = xe4115acdf4fbfccc.x76b3d9d2638e5ecd[num14++];
								xe4115acdf4fbfccc.x76b3d9d2638e5ecd[num4++] = xe4115acdf4fbfccc.x76b3d9d2638e5ecd[num14++];
								num12 -= 2;
							}
							else
							{
								Array.Copy(xe4115acdf4fbfccc.x76b3d9d2638e5ecd, num14, xe4115acdf4fbfccc.x76b3d9d2638e5ecd, num4, 2);
								num4 += 2;
								num14 += 2;
								num12 -= 2;
							}
						}
						else
						{
							num14 = num4 - num13;
							do
							{
								num14 += xe4115acdf4fbfccc.xca09b6c2b5b18485;
							}
							while (num14 < 0);
							num11 = xe4115acdf4fbfccc.xca09b6c2b5b18485 - num14;
							if (num12 > num11)
							{
								num12 -= num11;
								if (num4 - num14 > 0 && num11 > num4 - num14)
								{
									do
									{
										xe4115acdf4fbfccc.x76b3d9d2638e5ecd[num4++] = xe4115acdf4fbfccc.x76b3d9d2638e5ecd[num14++];
									}
									while (--num11 != 0);
								}
								else
								{
									Array.Copy(xe4115acdf4fbfccc.x76b3d9d2638e5ecd, num14, xe4115acdf4fbfccc.x76b3d9d2638e5ecd, num4, num11);
									num4 += num11;
									num14 += num11;
									num11 = 0;
								}
								num14 = 0;
							}
						}
						if (num4 - num14 > 0 && num12 > num4 - num14)
						{
							do
							{
								xe4115acdf4fbfccc.x76b3d9d2638e5ecd[num4++] = xe4115acdf4fbfccc.x76b3d9d2638e5ecd[num14++];
							}
							while (--num12 != 0);
							break;
						}
						Array.Copy(xe4115acdf4fbfccc.x76b3d9d2638e5ecd, num14, xe4115acdf4fbfccc.x76b3d9d2638e5ecd, num4, num12);
						num4 += num12;
						num14 += num12;
						num12 = 0;
						break;
					}
					if ((num11 & 0x40) == 0)
					{
						num8 += array[num10 + 2];
						num8 += num2 & xa454a72a9452f39c[num11];
						num10 = (num9 + num8) * 3;
						if ((num11 = array[num10]) == 0)
						{
							num2 >>= array[num10 + 1];
							num3 -= array[num10 + 1];
							xe4115acdf4fbfccc.x76b3d9d2638e5ecd[num4++] = (byte)array[num10 + 2];
							num5--;
							break;
						}
						continue;
					}
					if (((uint)num11 & 0x20u) != 0)
					{
						num12 = x8cfbc105c29e356f.x3401b50873ad59be - num;
						num12 = ((num3 >> 3 < num12) ? (num3 >> 3) : num12);
						num += num12;
						x564ec8a071685a -= num12;
						num3 -= num12 << 3;
						xe4115acdf4fbfccc.x81ab2bc14c781288 = num2;
						xe4115acdf4fbfccc.x9bc58d3ebc0c6301 = num3;
						x8cfbc105c29e356f.x3401b50873ad59be = num;
						x8cfbc105c29e356f.x4898fcfa8d5dd0b2 += x564ec8a071685a - x8cfbc105c29e356f.x564ec8a071685a21;
						x8cfbc105c29e356f.x564ec8a071685a21 = x564ec8a071685a;
						xe4115acdf4fbfccc.xe95ef630fef0a7ff = num4;
						return 1;
					}
					x8cfbc105c29e356f.xd397bb1e465ce45e = "invalid literal/length code";
					num12 = x8cfbc105c29e356f.x3401b50873ad59be - num;
					num12 = ((num3 >> 3 < num12) ? (num3 >> 3) : num12);
					num += num12;
					x564ec8a071685a -= num12;
					num3 -= num12 << 3;
					xe4115acdf4fbfccc.x81ab2bc14c781288 = num2;
					xe4115acdf4fbfccc.x9bc58d3ebc0c6301 = num3;
					x8cfbc105c29e356f.x3401b50873ad59be = num;
					x8cfbc105c29e356f.x4898fcfa8d5dd0b2 += x564ec8a071685a - x8cfbc105c29e356f.x564ec8a071685a21;
					x8cfbc105c29e356f.x564ec8a071685a21 = x564ec8a071685a;
					xe4115acdf4fbfccc.xe95ef630fef0a7ff = num4;
					return -3;
				}
			}
			if (num5 < 258 || num < 10)
			{
				break;
			}
		}
		num12 = x8cfbc105c29e356f.x3401b50873ad59be - num;
		num12 = ((num3 >> 3 < num12) ? (num3 >> 3) : num12);
		num += num12;
		x564ec8a071685a -= num12;
		num3 -= num12 << 3;
		xe4115acdf4fbfccc.x81ab2bc14c781288 = num2;
		xe4115acdf4fbfccc.x9bc58d3ebc0c6301 = num3;
		x8cfbc105c29e356f.x3401b50873ad59be = num;
		x8cfbc105c29e356f.x4898fcfa8d5dd0b2 += x564ec8a071685a - x8cfbc105c29e356f.x564ec8a071685a21;
		x8cfbc105c29e356f.x564ec8a071685a21 = x564ec8a071685a;
		xe4115acdf4fbfccc.xe95ef630fef0a7ff = num4;
		return 0;
	}
}
