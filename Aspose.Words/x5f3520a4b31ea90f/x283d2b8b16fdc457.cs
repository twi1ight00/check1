using System;
using Aspose;

namespace x5f3520a4b31ea90f;

[JavaManual("Autoporting from .NET results in incorrect and inefficient code. We have a good Java implementation here.")]
internal class x283d2b8b16fdc457
{
	private const byte x458b6850f542212c = 3;

	private const byte x8d477fda4e13ab6b = 7;

	private const byte x5dee3f57c3b7e5d8 = 11;

	private const byte x2b6806f40c252d4e = 19;

	private const byte x3c325b3ac68ab768 = 3;

	private const byte xddf26b6d59002545 = 5;

	private const byte x8d947a87c4cc110f = 9;

	private const byte x5e5c900cfc4c9579 = 13;

	private const byte xdd98077ff1f37441 = 3;

	private const byte x6cf7e0890f0c4b86 = 9;

	private const byte x5a32ad4969d65a6e = 11;

	private const byte x61e7261356b2a429 = 15;

	private uint[] x01b557925841ae51;

	private byte[] x5cafa8d49ea71ea1;

	private uint[] x10f4d88af727adbc;

	private uint[] x08db3aeabb253cb1;

	private byte[] x5bdaca550ea57758;

	public x283d2b8b16fdc457()
	{
		x01b557925841ae51 = new uint[4];
		x10f4d88af727adbc = new uint[2];
		x5cafa8d49ea71ea1 = new byte[64];
		x5bdaca550ea57758 = new byte[16];
		x08db3aeabb253cb1 = new uint[16];
		x20aee281977480cf();
	}

	public byte[] xc6df3c48d7ea1182(byte[] x9d5750eb2d6373bc)
	{
		return xc6df3c48d7ea1182(x9d5750eb2d6373bc, 0, x9d5750eb2d6373bc.Length);
	}

	public byte[] xc6df3c48d7ea1182(byte[] x9d5750eb2d6373bc, int x374ea4fe62468d0f, int x10f4d88af727adbc)
	{
		xc0efebefc3400f25(x9d5750eb2d6373bc, x374ea4fe62468d0f, x10f4d88af727adbc);
		return xa575d0d259b0e814();
	}

	private void x20aee281977480cf()
	{
		x10f4d88af727adbc[0] = 0u;
		x10f4d88af727adbc[1] = 0u;
		x01b557925841ae51[0] = 1732584193u;
		x01b557925841ae51[1] = 4023233417u;
		x01b557925841ae51[2] = 2562383102u;
		x01b557925841ae51[3] = 271733878u;
		Array.Clear(x5cafa8d49ea71ea1, 0, 64);
		Array.Clear(x08db3aeabb253cb1, 0, 16);
	}

	protected void xc0efebefc3400f25(byte[] x9d5750eb2d6373bc, int x424caea8cd0993e9, int x2e94540690ec6f24)
	{
		int num = (int)((x10f4d88af727adbc[0] >> 3) & 0x3F);
		x10f4d88af727adbc[0] += (uint)(x2e94540690ec6f24 << 3);
		if (x10f4d88af727adbc[0] < x2e94540690ec6f24 << 3)
		{
			x10f4d88af727adbc[1]++;
		}
		x10f4d88af727adbc[1] += (uint)(x2e94540690ec6f24 >> 29);
		int num2 = 64 - num;
		int i = 0;
		if (x2e94540690ec6f24 >= num2)
		{
			Array.Copy(x9d5750eb2d6373bc, x424caea8cd0993e9, x5cafa8d49ea71ea1, num, num2);
			x064e221a617dbc64(x01b557925841ae51, x5cafa8d49ea71ea1, 0);
			for (i = num2; i + 63 < x2e94540690ec6f24; i += 64)
			{
				x064e221a617dbc64(x01b557925841ae51, x9d5750eb2d6373bc, i);
			}
			num = 0;
		}
		Array.Copy(x9d5750eb2d6373bc, x424caea8cd0993e9 + i, x5cafa8d49ea71ea1, num, x2e94540690ec6f24 - i);
	}

	protected byte[] xa575d0d259b0e814()
	{
		byte[] array = new byte[8];
		x8291881ef07bb5c7(array, x10f4d88af727adbc);
		uint num = (x10f4d88af727adbc[0] >> 3) & 0x3Fu;
		int num2 = (int)((num < 56) ? (56 - num) : (120 - num));
		xc0efebefc3400f25(x3dcd010ed1e386de(num2), 0, num2);
		xc0efebefc3400f25(array, 0, 8);
		x8291881ef07bb5c7(x5bdaca550ea57758, x01b557925841ae51);
		x20aee281977480cf();
		return x5bdaca550ea57758;
	}

	private byte[] x3dcd010ed1e386de(int x14621e8a08adcefe)
	{
		if (x14621e8a08adcefe > 0)
		{
			byte[] array = new byte[x14621e8a08adcefe];
			array[0] = 128;
			return array;
		}
		return null;
	}

	private uint x057e613e3bb3ce77(uint x08db3aeabb253cb1, uint x1e218ceaee1bb583, uint x8cfbc105c29e356f)
	{
		return (x08db3aeabb253cb1 & x1e218ceaee1bb583) | (~x08db3aeabb253cb1 & x8cfbc105c29e356f);
	}

	private uint x26463655896fd90a(uint x08db3aeabb253cb1, uint x1e218ceaee1bb583, uint x8cfbc105c29e356f)
	{
		return (x08db3aeabb253cb1 & x1e218ceaee1bb583) | (x08db3aeabb253cb1 & x8cfbc105c29e356f) | (x1e218ceaee1bb583 & x8cfbc105c29e356f);
	}

	private uint x42ebf511e363e540(uint x08db3aeabb253cb1, uint x1e218ceaee1bb583, uint x8cfbc105c29e356f)
	{
		return x08db3aeabb253cb1 ^ x1e218ceaee1bb583 ^ x8cfbc105c29e356f;
	}

	private uint xedf737b278901f33(uint x08db3aeabb253cb1, byte x57e9faf3ffdc07cc)
	{
		return (x08db3aeabb253cb1 << (int)x57e9faf3ffdc07cc) | (x08db3aeabb253cb1 >> 32 - x57e9faf3ffdc07cc);
	}

	private void x886957dd2f8ac5ac(ref uint x19218ffab70283ef, uint xe7ebe10fa44d8d49, uint x3c4da2980d043c95, uint x73f821c71fe1e676, uint x08db3aeabb253cb1, byte xe4115acdf4fbfccc)
	{
		x19218ffab70283ef += x057e613e3bb3ce77(xe7ebe10fa44d8d49, x3c4da2980d043c95, x73f821c71fe1e676) + x08db3aeabb253cb1;
		x19218ffab70283ef = xedf737b278901f33(x19218ffab70283ef, xe4115acdf4fbfccc);
	}

	private void x026217b7ae5b1df6(ref uint x19218ffab70283ef, uint xe7ebe10fa44d8d49, uint x3c4da2980d043c95, uint x73f821c71fe1e676, uint x08db3aeabb253cb1, byte xe4115acdf4fbfccc)
	{
		x19218ffab70283ef += x26463655896fd90a(xe7ebe10fa44d8d49, x3c4da2980d043c95, x73f821c71fe1e676) + x08db3aeabb253cb1 + 1518500249;
		x19218ffab70283ef = xedf737b278901f33(x19218ffab70283ef, xe4115acdf4fbfccc);
	}

	private void x06773de03c3fd777(ref uint x19218ffab70283ef, uint xe7ebe10fa44d8d49, uint x3c4da2980d043c95, uint x73f821c71fe1e676, uint x08db3aeabb253cb1, byte xe4115acdf4fbfccc)
	{
		x19218ffab70283ef += x42ebf511e363e540(xe7ebe10fa44d8d49, x3c4da2980d043c95, x73f821c71fe1e676) + x08db3aeabb253cb1 + 1859775393;
		x19218ffab70283ef = xedf737b278901f33(x19218ffab70283ef, xe4115acdf4fbfccc);
	}

	private void x8291881ef07bb5c7(byte[] x9c13656d94fc62d0, uint[] xcdaeea7afaf570ff)
	{
		int num = 0;
		for (int i = 0; i < x9c13656d94fc62d0.Length; i += 4)
		{
			x9c13656d94fc62d0[i] = (byte)xcdaeea7afaf570ff[num];
			x9c13656d94fc62d0[i + 1] = (byte)(xcdaeea7afaf570ff[num] >> 8);
			x9c13656d94fc62d0[i + 2] = (byte)(xcdaeea7afaf570ff[num] >> 16);
			x9c13656d94fc62d0[i + 3] = (byte)(xcdaeea7afaf570ff[num] >> 24);
			num++;
		}
	}

	private void xf76803be5e9ee2aa(uint[] x9c13656d94fc62d0, byte[] xcdaeea7afaf570ff, int xc0c4c459c6ccbd00)
	{
		int num = 0;
		int num2 = xc0c4c459c6ccbd00;
		while (num < x9c13656d94fc62d0.Length)
		{
			x9c13656d94fc62d0[num] = (uint)(xcdaeea7afaf570ff[num2] | (xcdaeea7afaf570ff[num2 + 1] << 8) | (xcdaeea7afaf570ff[num2 + 2] << 16) | (xcdaeea7afaf570ff[num2 + 3] << 24));
			num++;
			num2 += 4;
		}
	}

	private void x064e221a617dbc64(uint[] x01b557925841ae51, byte[] xe413319369b234aa, int xc0c4c459c6ccbd00)
	{
		uint x19218ffab70283ef = x01b557925841ae51[0];
		uint x19218ffab70283ef2 = x01b557925841ae51[1];
		uint x19218ffab70283ef3 = x01b557925841ae51[2];
		uint x19218ffab70283ef4 = x01b557925841ae51[3];
		xf76803be5e9ee2aa(x08db3aeabb253cb1, xe413319369b234aa, xc0c4c459c6ccbd00);
		x886957dd2f8ac5ac(ref x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x08db3aeabb253cb1[0], 3);
		x886957dd2f8ac5ac(ref x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x08db3aeabb253cb1[1], 7);
		x886957dd2f8ac5ac(ref x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x08db3aeabb253cb1[2], 11);
		x886957dd2f8ac5ac(ref x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x08db3aeabb253cb1[3], 19);
		x886957dd2f8ac5ac(ref x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x08db3aeabb253cb1[4], 3);
		x886957dd2f8ac5ac(ref x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x08db3aeabb253cb1[5], 7);
		x886957dd2f8ac5ac(ref x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x08db3aeabb253cb1[6], 11);
		x886957dd2f8ac5ac(ref x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x08db3aeabb253cb1[7], 19);
		x886957dd2f8ac5ac(ref x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x08db3aeabb253cb1[8], 3);
		x886957dd2f8ac5ac(ref x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x08db3aeabb253cb1[9], 7);
		x886957dd2f8ac5ac(ref x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x08db3aeabb253cb1[10], 11);
		x886957dd2f8ac5ac(ref x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x08db3aeabb253cb1[11], 19);
		x886957dd2f8ac5ac(ref x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x08db3aeabb253cb1[12], 3);
		x886957dd2f8ac5ac(ref x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x08db3aeabb253cb1[13], 7);
		x886957dd2f8ac5ac(ref x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x08db3aeabb253cb1[14], 11);
		x886957dd2f8ac5ac(ref x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x08db3aeabb253cb1[15], 19);
		x026217b7ae5b1df6(ref x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x08db3aeabb253cb1[0], 3);
		x026217b7ae5b1df6(ref x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x08db3aeabb253cb1[4], 5);
		x026217b7ae5b1df6(ref x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x08db3aeabb253cb1[8], 9);
		x026217b7ae5b1df6(ref x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x08db3aeabb253cb1[12], 13);
		x026217b7ae5b1df6(ref x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x08db3aeabb253cb1[1], 3);
		x026217b7ae5b1df6(ref x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x08db3aeabb253cb1[5], 5);
		x026217b7ae5b1df6(ref x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x08db3aeabb253cb1[9], 9);
		x026217b7ae5b1df6(ref x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x08db3aeabb253cb1[13], 13);
		x026217b7ae5b1df6(ref x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x08db3aeabb253cb1[2], 3);
		x026217b7ae5b1df6(ref x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x08db3aeabb253cb1[6], 5);
		x026217b7ae5b1df6(ref x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x08db3aeabb253cb1[10], 9);
		x026217b7ae5b1df6(ref x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x08db3aeabb253cb1[14], 13);
		x026217b7ae5b1df6(ref x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x08db3aeabb253cb1[3], 3);
		x026217b7ae5b1df6(ref x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x08db3aeabb253cb1[7], 5);
		x026217b7ae5b1df6(ref x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x08db3aeabb253cb1[11], 9);
		x026217b7ae5b1df6(ref x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x08db3aeabb253cb1[15], 13);
		x06773de03c3fd777(ref x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x08db3aeabb253cb1[0], 3);
		x06773de03c3fd777(ref x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x08db3aeabb253cb1[8], 9);
		x06773de03c3fd777(ref x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x08db3aeabb253cb1[4], 11);
		x06773de03c3fd777(ref x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x08db3aeabb253cb1[12], 15);
		x06773de03c3fd777(ref x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x08db3aeabb253cb1[2], 3);
		x06773de03c3fd777(ref x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x08db3aeabb253cb1[10], 9);
		x06773de03c3fd777(ref x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x08db3aeabb253cb1[6], 11);
		x06773de03c3fd777(ref x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x08db3aeabb253cb1[14], 15);
		x06773de03c3fd777(ref x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x08db3aeabb253cb1[1], 3);
		x06773de03c3fd777(ref x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x08db3aeabb253cb1[9], 9);
		x06773de03c3fd777(ref x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x08db3aeabb253cb1[5], 11);
		x06773de03c3fd777(ref x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x08db3aeabb253cb1[13], 15);
		x06773de03c3fd777(ref x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x08db3aeabb253cb1[3], 3);
		x06773de03c3fd777(ref x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x19218ffab70283ef3, x08db3aeabb253cb1[11], 9);
		x06773de03c3fd777(ref x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x19218ffab70283ef2, x08db3aeabb253cb1[7], 11);
		x06773de03c3fd777(ref x19218ffab70283ef2, x19218ffab70283ef3, x19218ffab70283ef4, x19218ffab70283ef, x08db3aeabb253cb1[15], 15);
		x01b557925841ae51[0] += x19218ffab70283ef;
		x01b557925841ae51[1] += x19218ffab70283ef2;
		x01b557925841ae51[2] += x19218ffab70283ef3;
		x01b557925841ae51[3] += x19218ffab70283ef4;
	}
}
