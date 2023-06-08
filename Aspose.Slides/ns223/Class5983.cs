using System;
using System.Security.Cryptography;

namespace ns223;

internal class Class5983 : HashAlgorithm
{
	private const uint uint_0 = 3614090360u;

	private const uint uint_1 = 3905402710u;

	private const uint uint_2 = 606105819u;

	private const uint uint_3 = 3250441966u;

	private const uint uint_4 = 4118548399u;

	private const uint uint_5 = 1200080426u;

	private const uint uint_6 = 2821735955u;

	private const uint uint_7 = 4249261313u;

	private const uint uint_8 = 1770035416u;

	private const uint uint_9 = 2336552879u;

	private const uint uint_10 = 4294925233u;

	private const uint uint_11 = 2304563134u;

	private const uint uint_12 = 1804603682u;

	private const uint uint_13 = 4254626195u;

	private const uint uint_14 = 2792965006u;

	private const uint uint_15 = 1236535329u;

	private const uint uint_16 = 4129170786u;

	private const uint uint_17 = 3225465664u;

	private const uint uint_18 = 643717713u;

	private const uint uint_19 = 3921069994u;

	private const uint uint_20 = 3593408605u;

	private const uint uint_21 = 38016083u;

	private const uint uint_22 = 3634488961u;

	private const uint uint_23 = 3889429448u;

	private const uint uint_24 = 568446438u;

	private const uint uint_25 = 3275163606u;

	private const uint uint_26 = 4107603335u;

	private const uint uint_27 = 1163531501u;

	private const uint uint_28 = 2850285829u;

	private const uint uint_29 = 4243563512u;

	private const uint uint_30 = 1735328473u;

	private const uint uint_31 = 2368359562u;

	private const uint uint_32 = 4294588738u;

	private const uint uint_33 = 2272392833u;

	private const uint uint_34 = 1839030562u;

	private const uint uint_35 = 4259657740u;

	private const uint uint_36 = 2763975236u;

	private const uint uint_37 = 1272893353u;

	private const uint uint_38 = 4139469664u;

	private const uint uint_39 = 3200236656u;

	private const uint uint_40 = 681279174u;

	private const uint uint_41 = 3936430074u;

	private const uint uint_42 = 3572445317u;

	private const uint uint_43 = 76029189u;

	private const uint uint_44 = 3654602809u;

	private const uint uint_45 = 3873151461u;

	private const uint uint_46 = 530742520u;

	private const uint uint_47 = 3299628645u;

	private const uint uint_48 = 4096336452u;

	private const uint uint_49 = 1126891415u;

	private const uint uint_50 = 2878612391u;

	private const uint uint_51 = 4237533241u;

	private const uint uint_52 = 1700485571u;

	private const uint uint_53 = 2399980690u;

	private const uint uint_54 = 4293915773u;

	private const uint uint_55 = 2240044497u;

	private const uint uint_56 = 1873313359u;

	private const uint uint_57 = 4264355552u;

	private const uint uint_58 = 2734768916u;

	private const uint uint_59 = 1309151649u;

	private const uint uint_60 = 4149444226u;

	private const uint uint_61 = 3174756917u;

	private const uint uint_62 = 718787259u;

	private const uint uint_63 = 3951481745u;

	private static byte[] byte_0;

	private uint[] uint_64 = new uint[2];

	private uint[] uint_65 = new uint[4];

	private byte[] byte_1 = new byte[64];

	private byte[] byte_2 = new byte[16];

	public byte[] Digest
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	public override void Initialize()
	{
		Array.Clear(uint_64, 0, uint_64.Length);
		uint_65[0] = 1732584193u;
		uint_65[1] = 4023233417u;
		uint_65[2] = 2562383102u;
		uint_65[3] = 271733878u;
	}

	protected override void HashCore(byte[] array, int ibStart, int cbSize)
	{
		method_0(array, ibStart, cbSize);
	}

	protected override byte[] HashFinal()
	{
		method_2();
		return Digest;
	}

	public Class5983()
	{
		HashSizeValue = 128;
		Initialize();
	}

	private void method_0(byte[] buffer, int offset, int count)
	{
		int num = (int)((uint_64[0] >> 3) & 0x3F);
		if ((uint)((int)uint_64[0] + (count << 3)) < uint_64[0])
		{
			uint_64[1]++;
		}
		uint_64[0] += (uint)(count << 3);
		uint_64[1] += (uint)count >> 29;
		uint[] array = new uint[16];
		while (count > 0)
		{
			byte_1[num++] = buffer[offset];
			if (num == 64)
			{
				int num2 = 0;
				int num3 = 0;
				while (num2 < 16)
				{
					array[num2] = (uint)((byte_1[num3 + 3] << 24) | (byte_1[num3 + 2] << 16) | (byte_1[num3 + 1] << 8) | byte_1[num3]);
					num2++;
					num3 += 4;
				}
				method_4(array);
				num = 0;
			}
			count--;
			offset++;
		}
	}

	public void method_1(byte[] buffer, int length)
	{
		int num = (int)((uint_64[0] >> 3) & 0x3F);
		if ((uint)((int)uint_64[0] + (length << 3)) < uint_64[0])
		{
			uint_64[1]++;
		}
		uint_64[0] += (uint)(length << 3);
		uint_64[1] += (uint)length >> 29;
		uint[] array = new uint[16];
		for (int i = 0; i < length; i++)
		{
			byte_1[num++] = buffer[i];
			if (num == 64)
			{
				int num2 = 0;
				int num3 = 0;
				while (num2 < 16)
				{
					array[num2] = (uint)((byte_1[num3 + 3] << 24) | (byte_1[num3 + 2] << 16) | (byte_1[num3 + 1] << 8) | byte_1[num3]);
					num2++;
					num3 += 4;
				}
				method_4(array);
				num = 0;
			}
		}
	}

	public void method_2()
	{
		uint[] array = new uint[16]
		{
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			uint_64[0],
			uint_64[1]
		};
		int num = (int)((uint_64[0] >> 3) & 0x3F);
		int length = ((num < 56) ? (56 - num) : (120 - num));
		method_1(byte_0, length);
		int num2 = 0;
		int num3 = 0;
		while (num2 < 14)
		{
			array[num2] = (uint)((byte_1[num3 + 3] << 24) | (byte_1[num3 + 2] << 16) | (byte_1[num3 + 1] << 8) | byte_1[num3]);
			num2++;
			num3 += 4;
		}
		method_4(array);
		method_3();
	}

	private void method_3()
	{
		int num = 0;
		int num2 = 0;
		while (num < 4)
		{
			Digest[num2] = (byte)(uint_65[num] & 0xFFu);
			Digest[num2 + 1] = (byte)((uint_65[num] >> 8) & 0xFFu);
			Digest[num2 + 2] = (byte)((uint_65[num] >> 16) & 0xFFu);
			Digest[num2 + 3] = (byte)((uint_65[num] >> 24) & 0xFFu);
			num++;
			num2 += 4;
		}
	}

	private void method_4(uint[] inputBuffer)
	{
		uint num = uint_65[0];
		uint num2 = uint_65[1];
		uint num3 = uint_65[2];
		uint num4 = uint_65[3];
		num += (uint)((int)(((num3 ^ num4) & num2) ^ num4) + -680876936 + (int)inputBuffer[0]);
		num = (num << 7) | (num >> 25);
		num += num2;
		num4 += (uint)((int)(((num2 ^ num3) & num) ^ num3) + -389564586 + (int)inputBuffer[1]);
		num4 = (num4 << 12) | (num4 >> 20);
		num4 += num;
		num3 += (((num ^ num2) & num4) ^ num2) + 606105819 + inputBuffer[2];
		num3 = (num3 << 17) | (num3 >> 15);
		num3 += num4;
		num2 += (uint)((int)(((num4 ^ num) & num3) ^ num) + -1044525330 + (int)inputBuffer[3]);
		num2 = (num2 << 22) | (num2 >> 10);
		num2 += num3;
		num += (uint)((int)(((num3 ^ num4) & num2) ^ num4) + -176418897 + (int)inputBuffer[4]);
		num = (num << 7) | (num >> 25);
		num += num2;
		num4 += (((num2 ^ num3) & num) ^ num3) + 1200080426 + inputBuffer[5];
		num4 = (num4 << 12) | (num4 >> 20);
		num4 += num;
		num3 += (uint)((int)(((num ^ num2) & num4) ^ num2) + -1473231341 + (int)inputBuffer[6]);
		num3 = (num3 << 17) | (num3 >> 15);
		num3 += num4;
		num2 += (uint)((int)(((num4 ^ num) & num3) ^ num) + -45705983 + (int)inputBuffer[7]);
		num2 = (num2 << 22) | (num2 >> 10);
		num2 += num3;
		num += (((num3 ^ num4) & num2) ^ num4) + 1770035416 + inputBuffer[8];
		num = (num << 7) | (num >> 25);
		num += num2;
		num4 += (uint)((int)(((num2 ^ num3) & num) ^ num3) + -1958414417 + (int)inputBuffer[9]);
		num4 = (num4 << 12) | (num4 >> 20);
		num4 += num;
		num3 += (uint)((int)(((num ^ num2) & num4) ^ num2) + -42063 + (int)inputBuffer[10]);
		num3 = (num3 << 17) | (num3 >> 15);
		num3 += num4;
		num2 += (uint)((int)(((num4 ^ num) & num3) ^ num) + -1990404162 + (int)inputBuffer[11]);
		num2 = (num2 << 22) | (num2 >> 10);
		num2 += num3;
		num += (((num3 ^ num4) & num2) ^ num4) + 1804603682 + inputBuffer[12];
		num = (num << 7) | (num >> 25);
		num += num2;
		num4 += (uint)((int)(((num2 ^ num3) & num) ^ num3) + -40341101 + (int)inputBuffer[13]);
		num4 = (num4 << 12) | (num4 >> 20);
		num4 += num;
		num3 += (uint)((int)(((num ^ num2) & num4) ^ num2) + -1502002290 + (int)inputBuffer[14]);
		num3 = (num3 << 17) | (num3 >> 15);
		num3 += num4;
		num2 += (((num4 ^ num) & num3) ^ num) + 1236535329 + inputBuffer[15];
		num2 = (num2 << 22) | (num2 >> 10);
		num2 += num3;
		num += (uint)((int)(((num2 ^ num3) & num4) ^ num3) + -165796510 + (int)inputBuffer[1]);
		num = (num << 5) | (num >> 27);
		num += num2;
		num4 += (uint)((int)(((num ^ num2) & num3) ^ num2) + -1069501632 + (int)inputBuffer[6]);
		num4 = (num4 << 9) | (num4 >> 23);
		num4 += num;
		num3 += (((num4 ^ num) & num2) ^ num) + 643717713 + inputBuffer[11];
		num3 = (num3 << 14) | (num3 >> 18);
		num3 += num4;
		num2 += (uint)((int)(((num3 ^ num4) & num) ^ num4) + -373897302 + (int)inputBuffer[0]);
		num2 = (num2 << 20) | (num2 >> 12);
		num2 += num3;
		num += (uint)((int)(((num2 ^ num3) & num4) ^ num3) + -701558691 + (int)inputBuffer[5]);
		num = (num << 5) | (num >> 27);
		num += num2;
		num4 += (((num ^ num2) & num3) ^ num2) + 38016083 + inputBuffer[10];
		num4 = (num4 << 9) | (num4 >> 23);
		num4 += num;
		num3 += (uint)((int)(((num4 ^ num) & num2) ^ num) + -660478335 + (int)inputBuffer[15]);
		num3 = (num3 << 14) | (num3 >> 18);
		num3 += num4;
		num2 += (uint)((int)(((num3 ^ num4) & num) ^ num4) + -405537848 + (int)inputBuffer[4]);
		num2 = (num2 << 20) | (num2 >> 12);
		num2 += num3;
		num += (((num2 ^ num3) & num4) ^ num3) + 568446438 + inputBuffer[9];
		num = (num << 5) | (num >> 27);
		num += num2;
		num4 += (uint)((int)(((num ^ num2) & num3) ^ num2) + -1019803690 + (int)inputBuffer[14]);
		num4 = (num4 << 9) | (num4 >> 23);
		num4 += num;
		num3 += (uint)((int)(((num4 ^ num) & num2) ^ num) + -187363961 + (int)inputBuffer[3]);
		num3 = (num3 << 14) | (num3 >> 18);
		num3 += num4;
		num2 += (((num3 ^ num4) & num) ^ num4) + 1163531501 + inputBuffer[8];
		num2 = (num2 << 20) | (num2 >> 12);
		num2 += num3;
		num += (uint)((int)(((num2 ^ num3) & num4) ^ num3) + -1444681467 + (int)inputBuffer[13]);
		num = (num << 5) | (num >> 27);
		num += num2;
		num4 += (uint)((int)(((num ^ num2) & num3) ^ num2) + -51403784 + (int)inputBuffer[2]);
		num4 = (num4 << 9) | (num4 >> 23);
		num4 += num;
		num3 += (((num4 ^ num) & num2) ^ num) + 1735328473 + inputBuffer[7];
		num3 = (num3 << 14) | (num3 >> 18);
		num3 += num4;
		num2 += (uint)((int)(((num3 ^ num4) & num) ^ num4) + -1926607734 + (int)inputBuffer[12]);
		num2 = (num2 << 20) | (num2 >> 12);
		num2 += num3;
		num += (uint)((int)(num2 ^ num3 ^ num4) + -378558 + (int)inputBuffer[5]);
		num = (num << 4) | (num >> 28);
		num += num2;
		num4 += (uint)((int)(num ^ num2 ^ num3) + -2022574463 + (int)inputBuffer[8]);
		num4 = (num4 << 11) | (num4 >> 21);
		num4 += num;
		num3 += (num4 ^ num ^ num2) + 1839030562 + inputBuffer[11];
		num3 = (num3 << 16) | (num3 >> 16);
		num3 += num4;
		num2 += (uint)((int)(num3 ^ num4 ^ num) + -35309556 + (int)inputBuffer[14]);
		num2 = (num2 << 23) | (num2 >> 9);
		num2 += num3;
		num += (uint)((int)(num2 ^ num3 ^ num4) + -1530992060 + (int)inputBuffer[1]);
		num = (num << 4) | (num >> 28);
		num += num2;
		num4 += (num ^ num2 ^ num3) + 1272893353 + inputBuffer[4];
		num4 = (num4 << 11) | (num4 >> 21);
		num4 += num;
		num3 += (uint)((int)(num4 ^ num ^ num2) + -155497632 + (int)inputBuffer[7]);
		num3 = (num3 << 16) | (num3 >> 16);
		num3 += num4;
		num2 += (uint)((int)(num3 ^ num4 ^ num) + -1094730640 + (int)inputBuffer[10]);
		num2 = (num2 << 23) | (num2 >> 9);
		num2 += num3;
		num += (num2 ^ num3 ^ num4) + 681279174 + inputBuffer[13];
		num = (num << 4) | (num >> 28);
		num += num2;
		num4 += (uint)((int)(num ^ num2 ^ num3) + -358537222 + (int)inputBuffer[0]);
		num4 = (num4 << 11) | (num4 >> 21);
		num4 += num;
		num3 += (uint)((int)(num4 ^ num ^ num2) + -722521979 + (int)inputBuffer[3]);
		num3 = (num3 << 16) | (num3 >> 16);
		num3 += num4;
		num2 += (num3 ^ num4 ^ num) + 76029189 + inputBuffer[6];
		num2 = (num2 << 23) | (num2 >> 9);
		num2 += num3;
		num += (uint)((int)(num2 ^ num3 ^ num4) + -640364487 + (int)inputBuffer[9]);
		num = (num << 4) | (num >> 28);
		num += num2;
		num4 += (uint)((int)(num ^ num2 ^ num3) + -421815835 + (int)inputBuffer[12]);
		num4 = (num4 << 11) | (num4 >> 21);
		num4 += num;
		num3 += (num4 ^ num ^ num2) + 530742520 + inputBuffer[15];
		num3 = (num3 << 16) | (num3 >> 16);
		num3 += num4;
		num2 += (uint)((int)(num3 ^ num4 ^ num) + -995338651 + (int)inputBuffer[2]);
		num2 = (num2 << 23) | (num2 >> 9);
		num2 += num3;
		num += (uint)((int)((~num4 | num2) ^ num3) + -198630844 + (int)inputBuffer[0]);
		num = (num << 6) | (num >> 26);
		num += num2;
		num4 += ((~num3 | num) ^ num2) + 1126891415 + inputBuffer[7];
		num4 = (num4 << 10) | (num4 >> 22);
		num4 += num;
		num3 += (uint)((int)((~num2 | num4) ^ num) + -1416354905 + (int)inputBuffer[14]);
		num3 = (num3 << 15) | (num3 >> 17);
		num3 += num4;
		num2 += (uint)((int)((~num | num3) ^ num4) + -57434055 + (int)inputBuffer[5]);
		num2 = (num2 << 21) | (num2 >> 11);
		num2 += num3;
		num += ((~num4 | num2) ^ num3) + 1700485571 + inputBuffer[12];
		num = (num << 6) | (num >> 26);
		num += num2;
		num4 += (uint)((int)((~num3 | num) ^ num2) + -1894986606 + (int)inputBuffer[3]);
		num4 = (num4 << 10) | (num4 >> 22);
		num4 += num;
		num3 += (uint)((int)((~num2 | num4) ^ num) + -1051523 + (int)inputBuffer[10]);
		num3 = (num3 << 15) | (num3 >> 17);
		num3 += num4;
		num2 += (uint)((int)((~num | num3) ^ num4) + -2054922799 + (int)inputBuffer[1]);
		num2 = (num2 << 21) | (num2 >> 11);
		num2 += num3;
		num += ((~num4 | num2) ^ num3) + 1873313359 + inputBuffer[8];
		num = (num << 6) | (num >> 26);
		num += num2;
		num4 += (uint)((int)((~num3 | num) ^ num2) + -30611744 + (int)inputBuffer[15]);
		num4 = (num4 << 10) | (num4 >> 22);
		num4 += num;
		num3 += (uint)((int)((~num2 | num4) ^ num) + -1560198380 + (int)inputBuffer[6]);
		num3 = (num3 << 15) | (num3 >> 17);
		num3 += num4;
		num2 += ((~num | num3) ^ num4) + 1309151649 + inputBuffer[13];
		num2 = (num2 << 21) | (num2 >> 11);
		num2 += num3;
		num += (uint)((int)((~num4 | num2) ^ num3) + -145523070 + (int)inputBuffer[4]);
		num = (num << 6) | (num >> 26);
		num += num2;
		num4 += (uint)((int)((~num3 | num) ^ num2) + -1120210379 + (int)inputBuffer[11]);
		num4 = (num4 << 10) | (num4 >> 22);
		num4 += num;
		num3 += ((~num2 | num4) ^ num) + 718787259 + inputBuffer[2];
		num3 = (num3 << 15) | (num3 >> 17);
		num3 += num4;
		num2 += (uint)((int)((~num | num3) ^ num4) + -343485551 + (int)inputBuffer[9]);
		num2 = (num2 << 21) | (num2 >> 11);
		num2 += num3;
		uint_65[0] += num;
		uint_65[1] += num2;
		uint_65[2] += num3;
		uint_65[3] += num4;
	}

	static Class5983()
	{
		byte[] array = new byte[64];
		array[0] = 128;
		byte_0 = array;
	}
}
