using System;
using System.Text;
using x5f3520a4b31ea90f;
using x6c95d9cf46ff5f25;

namespace x4f4df92b75ba3b67;

internal class x658aebf1ca09b792 : x264ba3b7aca691be
{
	private readonly byte[] x890d29897aa880b5;

	private readonly x005b3497e4ca1670 x6270feb36bdcb1ba;

	private int x2b9004f60742ee23;

	private int x9a77b6d500cad7da;

	private readonly int x6167d3b0ca727d5d;

	private byte[] xa4626f149d970474;

	private byte[] x9c8a9f5a15a79907;

	private byte[] xf18a02a5c254c77f;

	private static readonly byte[] x3813b34ad1a520a6 = new byte[32]
	{
		40, 191, 78, 94, 78, 117, 138, 65, 100, 0,
		78, 86, 255, 250, 1, 8, 46, 46, 0, 182,
		208, 104, 62, 128, 47, 12, 169, 254, 100, 83,
		105, 122
	};

	private static readonly byte[] xe211509c99b7bac5 = new byte[4] { 115, 65, 108, 84 };

	public x658aebf1ca09b792(x4882ae789be6e2ef context, byte[] documentId)
		: base(context)
	{
		x890d29897aa880b5 = new byte[5];
		x6270feb36bdcb1ba = new x005b3497e4ca1670();
		xae3082d123597d93 x9da647d0334b = context.x73979cef1002ed01.x9da647d0334b8864;
		x250934b476efdcf3(x9da647d0334b.xea98c2211cc2e8a1);
		x6167d3b0ca727d5d = x9da647d0334b.x6d951c3fbb07a6c8;
		x6167d3b0ca727d5d |= ((x9a77b6d500cad7da == 3 || x9a77b6d500cad7da == 4) ? (-3904) : (-64));
		x6167d3b0ca727d5d &= -4;
		byte[] x319214f212f6cc = (x0d299f323d241756.x5959bccb67bbf051(x9da647d0334b.x0453ea70f5d72971) ? Encoding.UTF8.GetBytes(x9da647d0334b.x0453ea70f5d72971) : xcd4bd3abd72ff2da.x2b0797e1bb4e840a);
		x166ce60fdd189aa1(x319214f212f6cc, x0d299f323d241756.x5959bccb67bbf051(x9da647d0334b.x0c2c993467f454c3) ? Encoding.UTF8.GetBytes(x9da647d0334b.x0c2c993467f454c3) : documentId);
		x00885e55fa70cd43(documentId, x319214f212f6cc);
		xfd2d2137d45fe718(documentId);
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		writer.x7a67b9beb30292d6(this);
		writer.xafb7e6f79ed43681();
		writer.x6210059f049f0d48("/Filter /Standard");
		writer.xa4dc0ad8886e23a2("/O", $"<{x0d299f323d241756.x482624a13e9e9d98(xa4626f149d970474)}>");
		writer.xa4dc0ad8886e23a2("/U", $"<{x0d299f323d241756.x482624a13e9e9d98(xf18a02a5c254c77f)}>");
		writer.xa4dc0ad8886e23a2("/P", x6167d3b0ca727d5d);
		writer.xa4dc0ad8886e23a2("/R", x9a77b6d500cad7da);
		switch (x9a77b6d500cad7da)
		{
		case 2:
			writer.xa4dc0ad8886e23a2("/V", 1);
			break;
		case 3:
			writer.xa4dc0ad8886e23a2("/V", 2);
			writer.xa4dc0ad8886e23a2("/Length", 128);
			break;
		default:
			throw new InvalidOperationException("Unexpected encryption method.");
		}
		writer.x693a8d6d020474f2();
		writer.x5155d7b9dab28280();
	}

	public x5babd393421dd91d xbfbb1719d4106af2(int x78b0a0bc28459535, int xeb322a3a813e8267)
	{
		x890d29897aa880b5[0] = (byte)x78b0a0bc28459535;
		x890d29897aa880b5[1] = (byte)(x78b0a0bc28459535 >> 8);
		x890d29897aa880b5[2] = (byte)(x78b0a0bc28459535 >> 16);
		x890d29897aa880b5[3] = (byte)xeb322a3a813e8267;
		x890d29897aa880b5[4] = (byte)(xeb322a3a813e8267 >> 8);
		x1e72f71e14224f7d x1e72f71e14224f7d = new x1e72f71e14224f7d();
		x1e72f71e14224f7d.x295cb4a1df7a5add(x9c8a9f5a15a79907, x9c8a9f5a15a79907.Length);
		x1e72f71e14224f7d.x295cb4a1df7a5add(x890d29897aa880b5, x890d29897aa880b5.Length);
		if (x9a77b6d500cad7da == 4)
		{
			x1e72f71e14224f7d.x295cb4a1df7a5add(xe211509c99b7bac5, x890d29897aa880b5.Length);
		}
		x1e72f71e14224f7d.x20098fa15e62301f();
		byte[] x7a569e28d68fded = x1e72f71e14224f7d.x7a569e28d68fded6;
		int num = x9c8a9f5a15a79907.Length + 5;
		if (num > 16)
		{
			num = 16;
		}
		return new x5babd393421dd91d(x7a569e28d68fded, num);
	}

	private void x250934b476efdcf3(xae64597a81f290fa xc96fe572918903a0)
	{
		switch (xc96fe572918903a0)
		{
		case xae64597a81f290fa.x6c80807a35e7b5ed:
			x2b9004f60742ee23 = 40;
			x9a77b6d500cad7da = 2;
			break;
		case xae64597a81f290fa.x66f7285a02a95d2c:
			x2b9004f60742ee23 = 128;
			x9a77b6d500cad7da = 3;
			break;
		default:
			throw new ArgumentException("Invalid encryption mode.");
		}
	}

	private void x166ce60fdd189aa1(byte[] x319214f212f6cc99, byte[] x682935b2be2ef7d8)
	{
		xa4626f149d970474 = new byte[32];
		byte[] xe7ebe10fa44d8d = x7922f3c186c0a485(x682935b2be2ef7d8);
		if (x682935b2be2ef7d8 == null || x682935b2be2ef7d8.Length == 0)
		{
			xe7ebe10fa44d8d = x7922f3c186c0a485(x319214f212f6cc99);
		}
		byte[] array = x1e72f71e14224f7d.xc6df3c48d7ea1182(xe7ebe10fa44d8d);
		byte[] array2 = x7922f3c186c0a485(x319214f212f6cc99);
		if (x9a77b6d500cad7da == 3 || x9a77b6d500cad7da == 4)
		{
			byte[] array3 = new byte[x2b9004f60742ee23 / 8];
			for (int i = 0; i < 50; i++)
			{
				Array.Copy(x1e72f71e14224f7d.xc6df3c48d7ea1182(array, array3.Length), 0, array, 0, array3.Length);
			}
			Array.Copy(array2, 0, xa4626f149d970474, 0, 32);
			for (int j = 0; j < 20; j++)
			{
				for (int k = 0; k < array3.Length; k++)
				{
					array3[k] = (byte)(array[k] ^ j);
				}
				x6270feb36bdcb1ba.xb04c56f3a10310d3(array3);
				x6270feb36bdcb1ba.x246b032720dd4c0d(xa4626f149d970474);
			}
		}
		else
		{
			x6270feb36bdcb1ba.xb04c56f3a10310d3(array, 0, 5);
			x6270feb36bdcb1ba.x246b032720dd4c0d(array2, xa4626f149d970474);
		}
	}

	private void x00885e55fa70cd43(byte[] x3f2641ea795bab10, byte[] x319214f212f6cc99)
	{
		x9c8a9f5a15a79907 = new byte[x2b9004f60742ee23 / 8];
		x1e72f71e14224f7d x1e72f71e14224f7d = new x1e72f71e14224f7d();
		byte[] array = x7922f3c186c0a485(x319214f212f6cc99);
		x1e72f71e14224f7d.x295cb4a1df7a5add(array, array.Length);
		x1e72f71e14224f7d.x295cb4a1df7a5add(xa4626f149d970474, xa4626f149d970474.Length);
		byte[] x5cafa8d49ea71ea = new byte[4]
		{
			(byte)x6167d3b0ca727d5d,
			(byte)(x6167d3b0ca727d5d >> 8),
			(byte)(x6167d3b0ca727d5d >> 16),
			(byte)(x6167d3b0ca727d5d >> 24)
		};
		x1e72f71e14224f7d.x295cb4a1df7a5add(x5cafa8d49ea71ea, 4);
		if (x3f2641ea795bab10 != null)
		{
			x1e72f71e14224f7d.x295cb4a1df7a5add(x3f2641ea795bab10, x3f2641ea795bab10.Length);
		}
		x1e72f71e14224f7d.x20098fa15e62301f();
		byte[] x7a569e28d68fded = x1e72f71e14224f7d.x7a569e28d68fded6;
		byte[] array2 = new byte[x9c8a9f5a15a79907.Length];
		Array.Copy(x7a569e28d68fded, 0, array2, 0, x9c8a9f5a15a79907.Length);
		if (x9a77b6d500cad7da == 3 || x9a77b6d500cad7da == 4)
		{
			for (int i = 0; i < 50; i++)
			{
				Array.Copy(x1e72f71e14224f7d.xc6df3c48d7ea1182(array2), 0, array2, 0, x9c8a9f5a15a79907.Length);
			}
		}
		Array.Copy(array2, 0, x9c8a9f5a15a79907, 0, x9c8a9f5a15a79907.Length);
	}

	private void xfd2d2137d45fe718(byte[] x3f2641ea795bab10)
	{
		xf18a02a5c254c77f = new byte[32];
		if (x9a77b6d500cad7da == 3 || x9a77b6d500cad7da == 4)
		{
			x1e72f71e14224f7d x1e72f71e14224f7d = new x1e72f71e14224f7d();
			x1e72f71e14224f7d.x295cb4a1df7a5add(x3813b34ad1a520a6, x3813b34ad1a520a6.Length);
			x1e72f71e14224f7d.x295cb4a1df7a5add(x3f2641ea795bab10, x3f2641ea795bab10.Length);
			x1e72f71e14224f7d.x20098fa15e62301f();
			byte[] x7a569e28d68fded = x1e72f71e14224f7d.x7a569e28d68fded6;
			Array.Copy(x7a569e28d68fded, 0, xf18a02a5c254c77f, 0, 16);
			for (int i = 16; i < 32; i++)
			{
				xf18a02a5c254c77f[i] = 0;
			}
			for (int j = 0; j < 20; j++)
			{
				for (int k = 0; k < x9c8a9f5a15a79907.Length; k++)
				{
					x7a569e28d68fded[k] = (byte)(x9c8a9f5a15a79907[k] ^ j);
				}
				x6270feb36bdcb1ba.xb04c56f3a10310d3(x7a569e28d68fded, 0, x9c8a9f5a15a79907.Length);
				x6270feb36bdcb1ba.x246b032720dd4c0d(xf18a02a5c254c77f, 0, 16);
			}
		}
		else
		{
			x6270feb36bdcb1ba.xb04c56f3a10310d3(x9c8a9f5a15a79907);
			x6270feb36bdcb1ba.x246b032720dd4c0d(x3813b34ad1a520a6, xf18a02a5c254c77f);
		}
	}

	private static byte[] x7922f3c186c0a485(byte[] xe8e4b5871d71a79a)
	{
		byte[] array = new byte[32];
		if (xe8e4b5871d71a79a == null || xe8e4b5871d71a79a.Length == 0)
		{
			Array.Copy(x3813b34ad1a520a6, 0, array, 0, 32);
			return array;
		}
		Array.Copy(xe8e4b5871d71a79a, 0, array, 0, Math.Min(xe8e4b5871d71a79a.Length, 32));
		if (xe8e4b5871d71a79a.Length < 32)
		{
			Array.Copy(x3813b34ad1a520a6, 0, array, xe8e4b5871d71a79a.Length, 32 - xe8e4b5871d71a79a.Length);
		}
		return array;
	}
}
