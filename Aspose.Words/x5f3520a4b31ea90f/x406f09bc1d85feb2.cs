using System;

namespace x5f3520a4b31ea90f;

internal class x406f09bc1d85feb2
{
	private const int xaf58b56360d8ce2d = 64;

	private readonly uint[] x7f0aee02ed2da884;

	private readonly byte[] x5ea4b6016ad8f8f2;

	private int x465331627eee1c5b;

	private long x35a5073ffeb125c5;

	private readonly uint[] x4348c96b3a2259b3;

	private byte[] x4bbab25d4494fee8;

	public x406f09bc1d85feb2()
	{
		x7f0aee02ed2da884 = new uint[5];
		x5ea4b6016ad8f8f2 = new byte[64];
		x4348c96b3a2259b3 = new uint[80];
		x20aee281977480cf();
	}

	public byte[] xc6df3c48d7ea1182(byte[] xcdaeea7afaf570ff)
	{
		if (xcdaeea7afaf570ff == null)
		{
			throw new ArgumentNullException("input");
		}
		xc0efebefc3400f25(xcdaeea7afaf570ff, 0, xcdaeea7afaf570ff.Length);
		x4bbab25d4494fee8 = xa575d0d259b0e814();
		x20aee281977480cf();
		return x4bbab25d4494fee8;
	}

	private void xc0efebefc3400f25(byte[] xbaa226133a919244, int x10aaa7cdfa38f254, int x0ceec69a97f73617)
	{
		if (x465331627eee1c5b != 0)
		{
			if (x0ceec69a97f73617 < 64 - x465331627eee1c5b)
			{
				Array.Copy(xbaa226133a919244, x10aaa7cdfa38f254, x5ea4b6016ad8f8f2, x465331627eee1c5b, x0ceec69a97f73617);
				x465331627eee1c5b += x0ceec69a97f73617;
				return;
			}
			int num = 64 - x465331627eee1c5b;
			Array.Copy(xbaa226133a919244, x10aaa7cdfa38f254, x5ea4b6016ad8f8f2, x465331627eee1c5b, num);
			xf4b9fc6f19ffa7eb(x5ea4b6016ad8f8f2, 0);
			x465331627eee1c5b = 0;
			x10aaa7cdfa38f254 += num;
			x0ceec69a97f73617 -= num;
		}
		for (int num = 0; num < x0ceec69a97f73617 - x0ceec69a97f73617 % 64; num += 64)
		{
			xf4b9fc6f19ffa7eb(xbaa226133a919244, x10aaa7cdfa38f254 + num);
		}
		if (x0ceec69a97f73617 % 64 != 0)
		{
			Array.Copy(xbaa226133a919244, x0ceec69a97f73617 - x0ceec69a97f73617 % 64 + x10aaa7cdfa38f254, x5ea4b6016ad8f8f2, 0, x0ceec69a97f73617 % 64);
			x465331627eee1c5b = x0ceec69a97f73617 % 64;
		}
	}

	private byte[] xa575d0d259b0e814()
	{
		byte[] array = new byte[20];
		x5da16c7c8d5a5bb7(x5ea4b6016ad8f8f2, 0, x465331627eee1c5b);
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				array[i * 4 + j] = (byte)(x7f0aee02ed2da884[i] >> 8 * (3 - j));
			}
		}
		return array;
	}

	private void x20aee281977480cf()
	{
		x35a5073ffeb125c5 = 0L;
		x465331627eee1c5b = 0;
		x7f0aee02ed2da884[0] = 1732584193u;
		x7f0aee02ed2da884[1] = 4023233417u;
		x7f0aee02ed2da884[2] = 2562383102u;
		x7f0aee02ed2da884[3] = 271733878u;
		x7f0aee02ed2da884[4] = 3285377520u;
	}

	private void xf4b9fc6f19ffa7eb(byte[] x4135a713035b4164, int xece9e0b508f44464)
	{
		x35a5073ffeb125c5 += 64L;
		for (int i = 0; i < 16; i++)
		{
			int num = xece9e0b508f44464 + 4 * i;
			x4348c96b3a2259b3[i] = (uint)((x4135a713035b4164[num] << 24) | (x4135a713035b4164[num + 1] << 16) | (x4135a713035b4164[num + 2] << 8) | x4135a713035b4164[num + 3]);
		}
		for (int i = 16; i < 80; i++)
		{
			uint num2 = x4348c96b3a2259b3[i - 3] ^ x4348c96b3a2259b3[i - 8] ^ x4348c96b3a2259b3[i - 14] ^ x4348c96b3a2259b3[i - 16];
			uint num3 = num2 << 1;
			uint num4 = num2 >> 31;
			x4348c96b3a2259b3[i] = num3 | num4;
		}
		uint num5 = x7f0aee02ed2da884[0];
		uint num6 = x7f0aee02ed2da884[1];
		uint num7 = x7f0aee02ed2da884[2];
		uint num8 = x7f0aee02ed2da884[3];
		uint num9 = x7f0aee02ed2da884[4];
		num9 += ((num5 << 5) | (num5 >> 27)) + (((num7 ^ num8) & num6) ^ num8) + 1518500249 + x4348c96b3a2259b3[0];
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += ((num9 << 5) | (num9 >> 27)) + (((num6 ^ num7) & num5) ^ num7) + 1518500249 + x4348c96b3a2259b3[1];
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += ((num8 << 5) | (num8 >> 27)) + (((num5 ^ num6) & num9) ^ num6) + 1518500249 + x4348c96b3a2259b3[2];
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += ((num7 << 5) | (num7 >> 27)) + (((num9 ^ num5) & num8) ^ num5) + 1518500249 + x4348c96b3a2259b3[3];
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += ((num6 << 5) | (num6 >> 27)) + (((num8 ^ num9) & num7) ^ num9) + 1518500249 + x4348c96b3a2259b3[4];
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += ((num5 << 5) | (num5 >> 27)) + (((num7 ^ num8) & num6) ^ num8) + 1518500249 + x4348c96b3a2259b3[5];
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += ((num9 << 5) | (num9 >> 27)) + (((num6 ^ num7) & num5) ^ num7) + 1518500249 + x4348c96b3a2259b3[6];
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += ((num8 << 5) | (num8 >> 27)) + (((num5 ^ num6) & num9) ^ num6) + 1518500249 + x4348c96b3a2259b3[7];
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += ((num7 << 5) | (num7 >> 27)) + (((num9 ^ num5) & num8) ^ num5) + 1518500249 + x4348c96b3a2259b3[8];
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += ((num6 << 5) | (num6 >> 27)) + (((num8 ^ num9) & num7) ^ num9) + 1518500249 + x4348c96b3a2259b3[9];
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += ((num5 << 5) | (num5 >> 27)) + (((num7 ^ num8) & num6) ^ num8) + 1518500249 + x4348c96b3a2259b3[10];
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += ((num9 << 5) | (num9 >> 27)) + (((num6 ^ num7) & num5) ^ num7) + 1518500249 + x4348c96b3a2259b3[11];
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += ((num8 << 5) | (num8 >> 27)) + (((num5 ^ num6) & num9) ^ num6) + 1518500249 + x4348c96b3a2259b3[12];
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += ((num7 << 5) | (num7 >> 27)) + (((num9 ^ num5) & num8) ^ num5) + 1518500249 + x4348c96b3a2259b3[13];
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += ((num6 << 5) | (num6 >> 27)) + (((num8 ^ num9) & num7) ^ num9) + 1518500249 + x4348c96b3a2259b3[14];
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += ((num5 << 5) | (num5 >> 27)) + (((num7 ^ num8) & num6) ^ num8) + 1518500249 + x4348c96b3a2259b3[15];
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += ((num9 << 5) | (num9 >> 27)) + (((num6 ^ num7) & num5) ^ num7) + 1518500249 + x4348c96b3a2259b3[16];
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += ((num8 << 5) | (num8 >> 27)) + (((num5 ^ num6) & num9) ^ num6) + 1518500249 + x4348c96b3a2259b3[17];
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += ((num7 << 5) | (num7 >> 27)) + (((num9 ^ num5) & num8) ^ num5) + 1518500249 + x4348c96b3a2259b3[18];
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += ((num6 << 5) | (num6 >> 27)) + (((num8 ^ num9) & num7) ^ num9) + 1518500249 + x4348c96b3a2259b3[19];
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += ((num5 << 5) | (num5 >> 27)) + (num6 ^ num7 ^ num8) + 1859775393 + x4348c96b3a2259b3[20];
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += ((num9 << 5) | (num9 >> 27)) + (num5 ^ num6 ^ num7) + 1859775393 + x4348c96b3a2259b3[21];
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += ((num8 << 5) | (num8 >> 27)) + (num9 ^ num5 ^ num6) + 1859775393 + x4348c96b3a2259b3[22];
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += ((num7 << 5) | (num7 >> 27)) + (num8 ^ num9 ^ num5) + 1859775393 + x4348c96b3a2259b3[23];
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += ((num6 << 5) | (num6 >> 27)) + (num7 ^ num8 ^ num9) + 1859775393 + x4348c96b3a2259b3[24];
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += ((num5 << 5) | (num5 >> 27)) + (num6 ^ num7 ^ num8) + 1859775393 + x4348c96b3a2259b3[25];
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += ((num9 << 5) | (num9 >> 27)) + (num5 ^ num6 ^ num7) + 1859775393 + x4348c96b3a2259b3[26];
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += ((num8 << 5) | (num8 >> 27)) + (num9 ^ num5 ^ num6) + 1859775393 + x4348c96b3a2259b3[27];
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += ((num7 << 5) | (num7 >> 27)) + (num8 ^ num9 ^ num5) + 1859775393 + x4348c96b3a2259b3[28];
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += ((num6 << 5) | (num6 >> 27)) + (num7 ^ num8 ^ num9) + 1859775393 + x4348c96b3a2259b3[29];
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += ((num5 << 5) | (num5 >> 27)) + (num6 ^ num7 ^ num8) + 1859775393 + x4348c96b3a2259b3[30];
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += ((num9 << 5) | (num9 >> 27)) + (num5 ^ num6 ^ num7) + 1859775393 + x4348c96b3a2259b3[31];
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += ((num8 << 5) | (num8 >> 27)) + (num9 ^ num5 ^ num6) + 1859775393 + x4348c96b3a2259b3[32];
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += ((num7 << 5) | (num7 >> 27)) + (num8 ^ num9 ^ num5) + 1859775393 + x4348c96b3a2259b3[33];
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += ((num6 << 5) | (num6 >> 27)) + (num7 ^ num8 ^ num9) + 1859775393 + x4348c96b3a2259b3[34];
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += ((num5 << 5) | (num5 >> 27)) + (num6 ^ num7 ^ num8) + 1859775393 + x4348c96b3a2259b3[35];
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += ((num9 << 5) | (num9 >> 27)) + (num5 ^ num6 ^ num7) + 1859775393 + x4348c96b3a2259b3[36];
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += ((num8 << 5) | (num8 >> 27)) + (num9 ^ num5 ^ num6) + 1859775393 + x4348c96b3a2259b3[37];
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += ((num7 << 5) | (num7 >> 27)) + (num8 ^ num9 ^ num5) + 1859775393 + x4348c96b3a2259b3[38];
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += ((num6 << 5) | (num6 >> 27)) + (num7 ^ num8 ^ num9) + 1859775393 + x4348c96b3a2259b3[39];
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + ((num6 & num7) | (num6 & num8) | (num7 & num8))) + -1894007588 + (int)x4348c96b3a2259b3[40]);
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += (uint)((int)(((num9 << 5) | (num9 >> 27)) + ((num5 & num6) | (num5 & num7) | (num6 & num7))) + -1894007588 + (int)x4348c96b3a2259b3[41]);
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + ((num9 & num5) | (num9 & num6) | (num5 & num6))) + -1894007588 + (int)x4348c96b3a2259b3[42]);
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += (uint)((int)(((num7 << 5) | (num7 >> 27)) + ((num8 & num9) | (num8 & num5) | (num9 & num5))) + -1894007588 + (int)x4348c96b3a2259b3[43]);
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + ((num7 & num8) | (num7 & num9) | (num8 & num9))) + -1894007588 + (int)x4348c96b3a2259b3[44]);
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + ((num6 & num7) | (num6 & num8) | (num7 & num8))) + -1894007588 + (int)x4348c96b3a2259b3[45]);
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += (uint)((int)(((num9 << 5) | (num9 >> 27)) + ((num5 & num6) | (num5 & num7) | (num6 & num7))) + -1894007588 + (int)x4348c96b3a2259b3[46]);
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + ((num9 & num5) | (num9 & num6) | (num5 & num6))) + -1894007588 + (int)x4348c96b3a2259b3[47]);
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += (uint)((int)(((num7 << 5) | (num7 >> 27)) + ((num8 & num9) | (num8 & num5) | (num9 & num5))) + -1894007588 + (int)x4348c96b3a2259b3[48]);
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + ((num7 & num8) | (num7 & num9) | (num8 & num9))) + -1894007588 + (int)x4348c96b3a2259b3[49]);
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + ((num6 & num7) | (num6 & num8) | (num7 & num8))) + -1894007588 + (int)x4348c96b3a2259b3[50]);
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += (uint)((int)(((num9 << 5) | (num9 >> 27)) + ((num5 & num6) | (num5 & num7) | (num6 & num7))) + -1894007588 + (int)x4348c96b3a2259b3[51]);
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + ((num9 & num5) | (num9 & num6) | (num5 & num6))) + -1894007588 + (int)x4348c96b3a2259b3[52]);
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += (uint)((int)(((num7 << 5) | (num7 >> 27)) + ((num8 & num9) | (num8 & num5) | (num9 & num5))) + -1894007588 + (int)x4348c96b3a2259b3[53]);
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + ((num7 & num8) | (num7 & num9) | (num8 & num9))) + -1894007588 + (int)x4348c96b3a2259b3[54]);
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + ((num6 & num7) | (num6 & num8) | (num7 & num8))) + -1894007588 + (int)x4348c96b3a2259b3[55]);
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += (uint)((int)(((num9 << 5) | (num9 >> 27)) + ((num5 & num6) | (num5 & num7) | (num6 & num7))) + -1894007588 + (int)x4348c96b3a2259b3[56]);
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + ((num9 & num5) | (num9 & num6) | (num5 & num6))) + -1894007588 + (int)x4348c96b3a2259b3[57]);
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += (uint)((int)(((num7 << 5) | (num7 >> 27)) + ((num8 & num9) | (num8 & num5) | (num9 & num5))) + -1894007588 + (int)x4348c96b3a2259b3[58]);
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + ((num7 & num8) | (num7 & num9) | (num8 & num9))) + -1894007588 + (int)x4348c96b3a2259b3[59]);
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + (num6 ^ num7 ^ num8)) + -899497514 + (int)x4348c96b3a2259b3[60]);
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += (uint)((int)(((num9 << 5) | (num9 >> 27)) + (num5 ^ num6 ^ num7)) + -899497514 + (int)x4348c96b3a2259b3[61]);
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + (num9 ^ num5 ^ num6)) + -899497514 + (int)x4348c96b3a2259b3[62]);
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += (uint)((int)(((num7 << 5) | (num7 >> 27)) + (num8 ^ num9 ^ num5)) + -899497514 + (int)x4348c96b3a2259b3[63]);
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + (num7 ^ num8 ^ num9)) + -899497514 + (int)x4348c96b3a2259b3[64]);
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + (num6 ^ num7 ^ num8)) + -899497514 + (int)x4348c96b3a2259b3[65]);
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += (uint)((int)(((num9 << 5) | (num9 >> 27)) + (num5 ^ num6 ^ num7)) + -899497514 + (int)x4348c96b3a2259b3[66]);
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + (num9 ^ num5 ^ num6)) + -899497514 + (int)x4348c96b3a2259b3[67]);
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += (uint)((int)(((num7 << 5) | (num7 >> 27)) + (num8 ^ num9 ^ num5)) + -899497514 + (int)x4348c96b3a2259b3[68]);
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + (num7 ^ num8 ^ num9)) + -899497514 + (int)x4348c96b3a2259b3[69]);
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + (num6 ^ num7 ^ num8)) + -899497514 + (int)x4348c96b3a2259b3[70]);
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += (uint)((int)(((num9 << 5) | (num9 >> 27)) + (num5 ^ num6 ^ num7)) + -899497514 + (int)x4348c96b3a2259b3[71]);
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + (num9 ^ num5 ^ num6)) + -899497514 + (int)x4348c96b3a2259b3[72]);
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += (uint)((int)(((num7 << 5) | (num7 >> 27)) + (num8 ^ num9 ^ num5)) + -899497514 + (int)x4348c96b3a2259b3[73]);
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + (num7 ^ num8 ^ num9)) + -899497514 + (int)x4348c96b3a2259b3[74]);
		num7 = (num7 << 30) | (num7 >> 2);
		num9 += (uint)((int)(((num5 << 5) | (num5 >> 27)) + (num6 ^ num7 ^ num8)) + -899497514 + (int)x4348c96b3a2259b3[75]);
		num6 = (num6 << 30) | (num6 >> 2);
		num8 += (uint)((int)(((num9 << 5) | (num9 >> 27)) + (num5 ^ num6 ^ num7)) + -899497514 + (int)x4348c96b3a2259b3[76]);
		num5 = (num5 << 30) | (num5 >> 2);
		num7 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + (num9 ^ num5 ^ num6)) + -899497514 + (int)x4348c96b3a2259b3[77]);
		num9 = (num9 << 30) | (num9 >> 2);
		num6 += (uint)((int)(((num7 << 5) | (num7 >> 27)) + (num8 ^ num9 ^ num5)) + -899497514 + (int)x4348c96b3a2259b3[78]);
		num8 = (num8 << 30) | (num8 >> 2);
		num5 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + (num7 ^ num8 ^ num9)) + -899497514 + (int)x4348c96b3a2259b3[79]);
		num7 = (num7 << 30) | (num7 >> 2);
		x7f0aee02ed2da884[0] += num5;
		x7f0aee02ed2da884[1] += num6;
		x7f0aee02ed2da884[2] += num7;
		x7f0aee02ed2da884[3] += num8;
		x7f0aee02ed2da884[4] += num9;
	}

	private void x5da16c7c8d5a5bb7(byte[] x4135a713035b4164, int xece9e0b508f44464, int x43f451310e815b76)
	{
		long num = x35a5073ffeb125c5 + x43f451310e815b76;
		int num2 = 56 - (int)(num % 64);
		if (num2 < 1)
		{
			num2 += 64;
		}
		byte[] array = new byte[x43f451310e815b76 + num2 + 8];
		for (int i = 0; i < x43f451310e815b76; i++)
		{
			array[i] = x4135a713035b4164[i + xece9e0b508f44464];
		}
		array[x43f451310e815b76] = 128;
		for (int j = x43f451310e815b76 + 1; j < x43f451310e815b76 + num2; j++)
		{
			array[j] = 0;
		}
		long x961016a387451f = num << 3;
		xf886426cc36a5377(x961016a387451f, array, x43f451310e815b76 + num2);
		xf4b9fc6f19ffa7eb(array, 0);
		if (x43f451310e815b76 + num2 + 8 == 128)
		{
			xf4b9fc6f19ffa7eb(array, 64);
		}
	}

	internal void xf886426cc36a5377(long x961016a387451f05, byte[] x5cafa8d49ea71ea1, int x13d4cb8d1bd20347)
	{
		x5cafa8d49ea71ea1[x13d4cb8d1bd20347++] = (byte)(x961016a387451f05 >> 56);
		x5cafa8d49ea71ea1[x13d4cb8d1bd20347++] = (byte)(x961016a387451f05 >> 48);
		x5cafa8d49ea71ea1[x13d4cb8d1bd20347++] = (byte)(x961016a387451f05 >> 40);
		x5cafa8d49ea71ea1[x13d4cb8d1bd20347++] = (byte)(x961016a387451f05 >> 32);
		x5cafa8d49ea71ea1[x13d4cb8d1bd20347++] = (byte)(x961016a387451f05 >> 24);
		x5cafa8d49ea71ea1[x13d4cb8d1bd20347++] = (byte)(x961016a387451f05 >> 16);
		x5cafa8d49ea71ea1[x13d4cb8d1bd20347++] = (byte)(x961016a387451f05 >> 8);
		x5cafa8d49ea71ea1[x13d4cb8d1bd20347] = (byte)x961016a387451f05;
	}
}
