using Aspose;

namespace x5f3520a4b31ea90f;

[JavaManual("Autoported version works good enough but contains too many masks to emulate unsigned arithmetics.")]
internal class x1e72f71e14224f7d
{
	private const uint x32956dee44ede026 = 3614090360u;

	private const uint x9af0967b46ea4ffd = 3905402710u;

	private const uint x0563992fa36d1409 = 606105819u;

	private const uint x8bb6499eff97ca52 = 3250441966u;

	private const uint x758618a08fb4e7bc = 4118548399u;

	private const uint xe7f6898fecc94bd9 = 1200080426u;

	private const uint x879e496cb9e3803b = 2821735955u;

	private const uint x7edcb8a0a8d88f0d = 4249261313u;

	private const uint xeda3266560337f26 = 1770035416u;

	private const uint xf583ef5e47003e8e = 2336552879u;

	private const uint x01000f23bda8d69a = 4294925233u;

	private const uint x6ece24df989c2246 = 2304563134u;

	private const uint x1eb599868f4ace11 = 1804603682u;

	private const uint x83ad80e6a43720b0 = 4254626195u;

	private const uint xd71120949ef01112 = 2792965006u;

	private const uint xb53dc680ebaa197e = 1236535329u;

	private const uint xee703b0f16d4c502 = 4129170786u;

	private const uint x5ce07a7e100147fb = 3225465664u;

	private const uint xd51a265568a87721 = 643717713u;

	private const uint x048f0cde94e75d0a = 3921069994u;

	private const uint x12e598ba87c9bcff = 3593408605u;

	private const uint x57308bb75f6ce160 = 38016083u;

	private const uint x99d7a576afb4532e = 3634488961u;

	private const uint xb65a68a413f72111 = 3889429448u;

	private const uint xe2fe445787518cf1 = 568446438u;

	private const uint x2cb2242f5e0d5b6e = 3275163606u;

	private const uint xa9dd7d6c8599726c = 4107603335u;

	private const uint x8b6b83486fe7c98b = 1163531501u;

	private const uint x62bc47fd1e3b23e4 = 2850285829u;

	private const uint x4fa4f59aa1ac82ae = 4243563512u;

	private const uint xd6d7c0c0fb7201e5 = 1735328473u;

	private const uint xf91ad9d1617d6920 = 2368359562u;

	private const uint xb92e2beadfa776d1 = 4294588738u;

	private const uint x8badec60ed9c8a85 = 2272392833u;

	private const uint x9e02027733b63958 = 1839030562u;

	private const uint x9996798549a66be9 = 4259657740u;

	private const uint x9d1477f76200fe53 = 2763975236u;

	private const uint x4671b814b43d4729 = 1272893353u;

	private const uint xbab1843eb054389a = 4139469664u;

	private const uint x9a7064735e6d7f46 = 3200236656u;

	private const uint x6a2611b9a5ac94ef = 681279174u;

	private const uint xfb85916910189a3e = 3936430074u;

	private const uint x0238857debc9f925 = 3572445317u;

	private const uint x31c85714dd042905 = 76029189u;

	private const uint x4936a5edfc999bc5 = 3654602809u;

	private const uint x9f4faf8124e4f645 = 3873151461u;

	private const uint xdacdd58ea7b8e246 = 530742520u;

	private const uint x6fb69911beacb6be = 3299628645u;

	private const uint x8a8937b9e842d3e2 = 4096336452u;

	private const uint xffc826ba18875b19 = 1126891415u;

	private const uint x7610527e2c45f292 = 2878612391u;

	private const uint x2de06d01b6f34fc4 = 4237533241u;

	private const uint xc874241acaaa5510 = 1700485571u;

	private const uint x5257022c85b46b2b = 2399980690u;

	private const uint x8d792132841b7d82 = 4293915773u;

	private const uint x2f51776355598b17 = 2240044497u;

	private const uint x02baaf373cfb1c6b = 1873313359u;

	private const uint x54d4b9a88f07c873 = 4264355552u;

	private const uint x4dde7eda64517c9b = 2734768916u;

	private const uint xc86a85c46fdda0c2 = 1309151649u;

	private const uint x8653014a0723d47c = 4149444226u;

	private const uint x9b846c0b82b861ef = 3174756917u;

	private const uint xc2875361e2795d50 = 718787259u;

	private const uint xe4a9326d0dc280d7 = 3951481745u;

	private static byte[] x01554da503bf7e81;

	private uint[] x94872e839688ee0c = new uint[2];

	private uint[] x79c46b700210cab0 = new uint[4];

	private byte[] x4550d6a43baa8db7 = new byte[64];

	private byte[] x926924f84a0a6f1b = new byte[16];

	public byte[] x7a569e28d68fded6
	{
		get
		{
			return x926924f84a0a6f1b;
		}
		set
		{
			x926924f84a0a6f1b = value;
		}
	}

	public static byte[] xc6df3c48d7ea1182(byte[] xe7ebe10fa44d8d49)
	{
		return xc6df3c48d7ea1182(xe7ebe10fa44d8d49, xe7ebe10fa44d8d49.Length);
	}

	public static byte[] xc6df3c48d7ea1182(byte[] xe7ebe10fa44d8d49, int x961016a387451f05)
	{
		x1e72f71e14224f7d x1e72f71e14224f7d2 = new x1e72f71e14224f7d();
		x1e72f71e14224f7d2.x295cb4a1df7a5add(xe7ebe10fa44d8d49, x961016a387451f05);
		x1e72f71e14224f7d2.x20098fa15e62301f();
		return x1e72f71e14224f7d2.x7a569e28d68fded6;
	}

	public x1e72f71e14224f7d()
	{
		x79c46b700210cab0[0] = 1732584193u;
		x79c46b700210cab0[1] = 4023233417u;
		x79c46b700210cab0[2] = 2562383102u;
		x79c46b700210cab0[3] = 271733878u;
	}

	public void x295cb4a1df7a5add(byte[] x5cafa8d49ea71ea1, int x961016a387451f05)
	{
		int num = (int)((x94872e839688ee0c[0] >> 3) & 0x3F);
		if ((uint)((int)x94872e839688ee0c[0] + (x961016a387451f05 << 3)) < x94872e839688ee0c[0])
		{
			x94872e839688ee0c[1]++;
		}
		x94872e839688ee0c[0] += (uint)(x961016a387451f05 << 3);
		x94872e839688ee0c[1] += (uint)x961016a387451f05 >> 29;
		uint[] array = new uint[16];
		for (int i = 0; i < x961016a387451f05; i++)
		{
			x4550d6a43baa8db7[num++] = x5cafa8d49ea71ea1[i];
			if (num == 64)
			{
				int num2 = 0;
				int num3 = 0;
				while (num2 < 16)
				{
					array[num2] = (uint)((x4550d6a43baa8db7[num3 + 3] << 24) | (x4550d6a43baa8db7[num3 + 2] << 16) | (x4550d6a43baa8db7[num3 + 1] << 8) | x4550d6a43baa8db7[num3]);
					num2++;
					num3 += 4;
				}
				xaccac17571a8d9fa(array);
				num = 0;
			}
		}
	}

	public void x20098fa15e62301f()
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
			x94872e839688ee0c[0],
			x94872e839688ee0c[1]
		};
		int num = (int)((x94872e839688ee0c[0] >> 3) & 0x3F);
		int x961016a387451f = ((num < 56) ? (56 - num) : (120 - num));
		x295cb4a1df7a5add(x01554da503bf7e81, x961016a387451f);
		int num2 = 0;
		int num3 = 0;
		while (num2 < 14)
		{
			array[num2] = (uint)((x4550d6a43baa8db7[num3 + 3] << 24) | (x4550d6a43baa8db7[num3 + 2] << 16) | (x4550d6a43baa8db7[num3 + 1] << 8) | x4550d6a43baa8db7[num3]);
			num2++;
			num3 += 4;
		}
		xaccac17571a8d9fa(array);
		x89b3e060b265c7f5();
	}

	public void x89b3e060b265c7f5()
	{
		int num = 0;
		int num2 = 0;
		while (num < 4)
		{
			x7a569e28d68fded6[num2] = (byte)(x79c46b700210cab0[num] & 0xFFu);
			x7a569e28d68fded6[num2 + 1] = (byte)((x79c46b700210cab0[num] >> 8) & 0xFFu);
			x7a569e28d68fded6[num2 + 2] = (byte)((x79c46b700210cab0[num] >> 16) & 0xFFu);
			x7a569e28d68fded6[num2 + 3] = (byte)((x79c46b700210cab0[num] >> 24) & 0xFFu);
			num++;
			num2 += 4;
		}
	}

	private void xaccac17571a8d9fa(uint[] x4135a713035b4164)
	{
		uint num = x79c46b700210cab0[0];
		uint num2 = x79c46b700210cab0[1];
		uint num3 = x79c46b700210cab0[2];
		uint num4 = x79c46b700210cab0[3];
		num += (uint)((int)(((num3 ^ num4) & num2) ^ num4) + -680876936 + (int)x4135a713035b4164[0]);
		num = (num << 7) | (num >> 25);
		num += num2;
		num4 += (uint)((int)(((num2 ^ num3) & num) ^ num3) + -389564586 + (int)x4135a713035b4164[1]);
		num4 = (num4 << 12) | (num4 >> 20);
		num4 += num;
		num3 += (((num ^ num2) & num4) ^ num2) + 606105819 + x4135a713035b4164[2];
		num3 = (num3 << 17) | (num3 >> 15);
		num3 += num4;
		num2 += (uint)((int)(((num4 ^ num) & num3) ^ num) + -1044525330 + (int)x4135a713035b4164[3]);
		num2 = (num2 << 22) | (num2 >> 10);
		num2 += num3;
		num += (uint)((int)(((num3 ^ num4) & num2) ^ num4) + -176418897 + (int)x4135a713035b4164[4]);
		num = (num << 7) | (num >> 25);
		num += num2;
		num4 += (((num2 ^ num3) & num) ^ num3) + 1200080426 + x4135a713035b4164[5];
		num4 = (num4 << 12) | (num4 >> 20);
		num4 += num;
		num3 += (uint)((int)(((num ^ num2) & num4) ^ num2) + -1473231341 + (int)x4135a713035b4164[6]);
		num3 = (num3 << 17) | (num3 >> 15);
		num3 += num4;
		num2 += (uint)((int)(((num4 ^ num) & num3) ^ num) + -45705983 + (int)x4135a713035b4164[7]);
		num2 = (num2 << 22) | (num2 >> 10);
		num2 += num3;
		num += (((num3 ^ num4) & num2) ^ num4) + 1770035416 + x4135a713035b4164[8];
		num = (num << 7) | (num >> 25);
		num += num2;
		num4 += (uint)((int)(((num2 ^ num3) & num) ^ num3) + -1958414417 + (int)x4135a713035b4164[9]);
		num4 = (num4 << 12) | (num4 >> 20);
		num4 += num;
		num3 += (uint)((int)(((num ^ num2) & num4) ^ num2) + -42063 + (int)x4135a713035b4164[10]);
		num3 = (num3 << 17) | (num3 >> 15);
		num3 += num4;
		num2 += (uint)((int)(((num4 ^ num) & num3) ^ num) + -1990404162 + (int)x4135a713035b4164[11]);
		num2 = (num2 << 22) | (num2 >> 10);
		num2 += num3;
		num += (((num3 ^ num4) & num2) ^ num4) + 1804603682 + x4135a713035b4164[12];
		num = (num << 7) | (num >> 25);
		num += num2;
		num4 += (uint)((int)(((num2 ^ num3) & num) ^ num3) + -40341101 + (int)x4135a713035b4164[13]);
		num4 = (num4 << 12) | (num4 >> 20);
		num4 += num;
		num3 += (uint)((int)(((num ^ num2) & num4) ^ num2) + -1502002290 + (int)x4135a713035b4164[14]);
		num3 = (num3 << 17) | (num3 >> 15);
		num3 += num4;
		num2 += (((num4 ^ num) & num3) ^ num) + 1236535329 + x4135a713035b4164[15];
		num2 = (num2 << 22) | (num2 >> 10);
		num2 += num3;
		num += (uint)((int)(((num2 ^ num3) & num4) ^ num3) + -165796510 + (int)x4135a713035b4164[1]);
		num = (num << 5) | (num >> 27);
		num += num2;
		num4 += (uint)((int)(((num ^ num2) & num3) ^ num2) + -1069501632 + (int)x4135a713035b4164[6]);
		num4 = (num4 << 9) | (num4 >> 23);
		num4 += num;
		num3 += (((num4 ^ num) & num2) ^ num) + 643717713 + x4135a713035b4164[11];
		num3 = (num3 << 14) | (num3 >> 18);
		num3 += num4;
		num2 += (uint)((int)(((num3 ^ num4) & num) ^ num4) + -373897302 + (int)x4135a713035b4164[0]);
		num2 = (num2 << 20) | (num2 >> 12);
		num2 += num3;
		num += (uint)((int)(((num2 ^ num3) & num4) ^ num3) + -701558691 + (int)x4135a713035b4164[5]);
		num = (num << 5) | (num >> 27);
		num += num2;
		num4 += (((num ^ num2) & num3) ^ num2) + 38016083 + x4135a713035b4164[10];
		num4 = (num4 << 9) | (num4 >> 23);
		num4 += num;
		num3 += (uint)((int)(((num4 ^ num) & num2) ^ num) + -660478335 + (int)x4135a713035b4164[15]);
		num3 = (num3 << 14) | (num3 >> 18);
		num3 += num4;
		num2 += (uint)((int)(((num3 ^ num4) & num) ^ num4) + -405537848 + (int)x4135a713035b4164[4]);
		num2 = (num2 << 20) | (num2 >> 12);
		num2 += num3;
		num += (((num2 ^ num3) & num4) ^ num3) + 568446438 + x4135a713035b4164[9];
		num = (num << 5) | (num >> 27);
		num += num2;
		num4 += (uint)((int)(((num ^ num2) & num3) ^ num2) + -1019803690 + (int)x4135a713035b4164[14]);
		num4 = (num4 << 9) | (num4 >> 23);
		num4 += num;
		num3 += (uint)((int)(((num4 ^ num) & num2) ^ num) + -187363961 + (int)x4135a713035b4164[3]);
		num3 = (num3 << 14) | (num3 >> 18);
		num3 += num4;
		num2 += (((num3 ^ num4) & num) ^ num4) + 1163531501 + x4135a713035b4164[8];
		num2 = (num2 << 20) | (num2 >> 12);
		num2 += num3;
		num += (uint)((int)(((num2 ^ num3) & num4) ^ num3) + -1444681467 + (int)x4135a713035b4164[13]);
		num = (num << 5) | (num >> 27);
		num += num2;
		num4 += (uint)((int)(((num ^ num2) & num3) ^ num2) + -51403784 + (int)x4135a713035b4164[2]);
		num4 = (num4 << 9) | (num4 >> 23);
		num4 += num;
		num3 += (((num4 ^ num) & num2) ^ num) + 1735328473 + x4135a713035b4164[7];
		num3 = (num3 << 14) | (num3 >> 18);
		num3 += num4;
		num2 += (uint)((int)(((num3 ^ num4) & num) ^ num4) + -1926607734 + (int)x4135a713035b4164[12]);
		num2 = (num2 << 20) | (num2 >> 12);
		num2 += num3;
		num += (uint)((int)(num2 ^ num3 ^ num4) + -378558 + (int)x4135a713035b4164[5]);
		num = (num << 4) | (num >> 28);
		num += num2;
		num4 += (uint)((int)(num ^ num2 ^ num3) + -2022574463 + (int)x4135a713035b4164[8]);
		num4 = (num4 << 11) | (num4 >> 21);
		num4 += num;
		num3 += (num4 ^ num ^ num2) + 1839030562 + x4135a713035b4164[11];
		num3 = (num3 << 16) | (num3 >> 16);
		num3 += num4;
		num2 += (uint)((int)(num3 ^ num4 ^ num) + -35309556 + (int)x4135a713035b4164[14]);
		num2 = (num2 << 23) | (num2 >> 9);
		num2 += num3;
		num += (uint)((int)(num2 ^ num3 ^ num4) + -1530992060 + (int)x4135a713035b4164[1]);
		num = (num << 4) | (num >> 28);
		num += num2;
		num4 += (num ^ num2 ^ num3) + 1272893353 + x4135a713035b4164[4];
		num4 = (num4 << 11) | (num4 >> 21);
		num4 += num;
		num3 += (uint)((int)(num4 ^ num ^ num2) + -155497632 + (int)x4135a713035b4164[7]);
		num3 = (num3 << 16) | (num3 >> 16);
		num3 += num4;
		num2 += (uint)((int)(num3 ^ num4 ^ num) + -1094730640 + (int)x4135a713035b4164[10]);
		num2 = (num2 << 23) | (num2 >> 9);
		num2 += num3;
		num += (num2 ^ num3 ^ num4) + 681279174 + x4135a713035b4164[13];
		num = (num << 4) | (num >> 28);
		num += num2;
		num4 += (uint)((int)(num ^ num2 ^ num3) + -358537222 + (int)x4135a713035b4164[0]);
		num4 = (num4 << 11) | (num4 >> 21);
		num4 += num;
		num3 += (uint)((int)(num4 ^ num ^ num2) + -722521979 + (int)x4135a713035b4164[3]);
		num3 = (num3 << 16) | (num3 >> 16);
		num3 += num4;
		num2 += (num3 ^ num4 ^ num) + 76029189 + x4135a713035b4164[6];
		num2 = (num2 << 23) | (num2 >> 9);
		num2 += num3;
		num += (uint)((int)(num2 ^ num3 ^ num4) + -640364487 + (int)x4135a713035b4164[9]);
		num = (num << 4) | (num >> 28);
		num += num2;
		num4 += (uint)((int)(num ^ num2 ^ num3) + -421815835 + (int)x4135a713035b4164[12]);
		num4 = (num4 << 11) | (num4 >> 21);
		num4 += num;
		num3 += (num4 ^ num ^ num2) + 530742520 + x4135a713035b4164[15];
		num3 = (num3 << 16) | (num3 >> 16);
		num3 += num4;
		num2 += (uint)((int)(num3 ^ num4 ^ num) + -995338651 + (int)x4135a713035b4164[2]);
		num2 = (num2 << 23) | (num2 >> 9);
		num2 += num3;
		num += (uint)((int)((~num4 | num2) ^ num3) + -198630844 + (int)x4135a713035b4164[0]);
		num = (num << 6) | (num >> 26);
		num += num2;
		num4 += ((~num3 | num) ^ num2) + 1126891415 + x4135a713035b4164[7];
		num4 = (num4 << 10) | (num4 >> 22);
		num4 += num;
		num3 += (uint)((int)((~num2 | num4) ^ num) + -1416354905 + (int)x4135a713035b4164[14]);
		num3 = (num3 << 15) | (num3 >> 17);
		num3 += num4;
		num2 += (uint)((int)((~num | num3) ^ num4) + -57434055 + (int)x4135a713035b4164[5]);
		num2 = (num2 << 21) | (num2 >> 11);
		num2 += num3;
		num += ((~num4 | num2) ^ num3) + 1700485571 + x4135a713035b4164[12];
		num = (num << 6) | (num >> 26);
		num += num2;
		num4 += (uint)((int)((~num3 | num) ^ num2) + -1894986606 + (int)x4135a713035b4164[3]);
		num4 = (num4 << 10) | (num4 >> 22);
		num4 += num;
		num3 += (uint)((int)((~num2 | num4) ^ num) + -1051523 + (int)x4135a713035b4164[10]);
		num3 = (num3 << 15) | (num3 >> 17);
		num3 += num4;
		num2 += (uint)((int)((~num | num3) ^ num4) + -2054922799 + (int)x4135a713035b4164[1]);
		num2 = (num2 << 21) | (num2 >> 11);
		num2 += num3;
		num += ((~num4 | num2) ^ num3) + 1873313359 + x4135a713035b4164[8];
		num = (num << 6) | (num >> 26);
		num += num2;
		num4 += (uint)((int)((~num3 | num) ^ num2) + -30611744 + (int)x4135a713035b4164[15]);
		num4 = (num4 << 10) | (num4 >> 22);
		num4 += num;
		num3 += (uint)((int)((~num2 | num4) ^ num) + -1560198380 + (int)x4135a713035b4164[6]);
		num3 = (num3 << 15) | (num3 >> 17);
		num3 += num4;
		num2 += ((~num | num3) ^ num4) + 1309151649 + x4135a713035b4164[13];
		num2 = (num2 << 21) | (num2 >> 11);
		num2 += num3;
		num += (uint)((int)((~num4 | num2) ^ num3) + -145523070 + (int)x4135a713035b4164[4]);
		num = (num << 6) | (num >> 26);
		num += num2;
		num4 += (uint)((int)((~num3 | num) ^ num2) + -1120210379 + (int)x4135a713035b4164[11]);
		num4 = (num4 << 10) | (num4 >> 22);
		num4 += num;
		num3 += ((~num2 | num4) ^ num) + 718787259 + x4135a713035b4164[2];
		num3 = (num3 << 15) | (num3 >> 17);
		num3 += num4;
		num2 += (uint)((int)((~num | num3) ^ num4) + -343485551 + (int)x4135a713035b4164[9]);
		num2 = (num2 << 21) | (num2 >> 11);
		num2 += num3;
		x79c46b700210cab0[0] += num;
		x79c46b700210cab0[1] += num2;
		x79c46b700210cab0[2] += num3;
		x79c46b700210cab0[3] += num4;
	}

	static x1e72f71e14224f7d()
	{
		byte[] array = new byte[64];
		array[0] = 128;
		x01554da503bf7e81 = array;
	}
}
