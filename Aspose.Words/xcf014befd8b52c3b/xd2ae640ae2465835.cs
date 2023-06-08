using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Aspose;
using Aspose.Words;
using x13f1efc79617a47b;
using x5f3520a4b31ea90f;
using x6c95d9cf46ff5f25;
using xa604c4d210ae0581;
using xf9a9481c3f63a419;

namespace xcf014befd8b52c3b;

internal class xd2ae640ae2465835 : x557c047c56f10b18
{
	private readonly Random xa69bdc19d203240d = new Random();

	public void xcc381ffa3ede662f(Stream xb2068605036a9126, Stream x303b0227e3017b6b, Stream xedc894794186020d, string xe8e4b5871d71a79a)
	{
		xb2068605036a9126.Position = 8L;
		BinaryReader reader = new BinaryReader(xb2068605036a9126);
		x351441d1224241db x351441d1224241db2 = new x351441d1224241db(reader);
		xfcb24ed0e04e3b49 xfcb24ed0e04e3b50 = new xfcb24ed0e04e3b49(reader, isAes: true);
		x256cdb8326ec4d09(x351441d1224241db2);
		x406f09bc1d85feb2 x2440760443f1d7fd = new x406f09bc1d85feb2();
		ICryptoTransform cryptoTransform = x6e7e9d585493eaf1.x2acbb59cffafa5cf(x904960fec10547b1(x351441d1224241db2.xcdfb13d91a75535a, x2440760443f1d7fd, xe8e4b5871d71a79a, xfcb24ed0e04e3b50.x005dbd4d94ca4423));
		x08ed82b1199c4263(cryptoTransform, xfcb24ed0e04e3b50);
		x232cd75eb5343f30(cryptoTransform, x303b0227e3017b6b, xedc894794186020d);
	}

	public void x246b032720dd4c0d(Stream x2fe2b17d7bd979f2, Stream x23cda4cfdf81f2cf, Stream x303b0227e3017b6b, string xe8e4b5871d71a79a)
	{
		x406f09bc1d85feb2 x2440760443f1d7fd = new x406f09bc1d85feb2();
		BinaryWriter xbdfb620b7167944b = new BinaryWriter(x2fe2b17d7bd979f2);
		x34c2fd9630dc4e80(xbdfb620b7167944b);
		byte[] xfe758ab07df158bc = xff897bbc0ce9fc68(16);
		ICryptoTransform x0935153e868dee = x6e7e9d585493eaf1.xdc602ee8a05ba9ef(x904960fec10547b1(128, x2440760443f1d7fd, xe8e4b5871d71a79a, xfe758ab07df158bc));
		xfcb24ed0e04e3b49 xfcb24ed0e04e3b50 = x63d633ab4221d12b(x0935153e868dee, xfe758ab07df158bc);
		xfcb24ed0e04e3b50.x6210059f049f0d48(xbdfb620b7167944b);
		x1cbd67cd9e92d71b(x0935153e868dee, x23cda4cfdf81f2cf, x303b0227e3017b6b);
	}

	[JavaThrows(true)]
	private static void x256cdb8326ec4d09(x351441d1224241db x6b0ad9f73c48ad53)
	{
		if (x6b0ad9f73c48ad53.x586b7652ac7cefe0 != (x483d31a3017e817e.x87c6e8b751d15100 | x483d31a3017e817e.xfde6cf924aec24cd))
		{
			throw new InvalidOperationException("Unexpected encryption flags.");
		}
		if (x6b0ad9f73c48ad53.x4a502afaa8a41dce != x9fbc9ab2fdb5f016.x784a5c9ab7ef4282 && x6b0ad9f73c48ad53.x4a502afaa8a41dce != x9fbc9ab2fdb5f016.xbb343d1fdeb91a03 && x6b0ad9f73c48ad53.x4a502afaa8a41dce != x9fbc9ab2fdb5f016.x563babcd242b571c)
		{
			throw new InvalidOperationException("Unexpected encryption algorithm id.");
		}
		if (x6b0ad9f73c48ad53.xb359f8e393e64393 != x2e723c1a88f20a3b.x5635e6b837b4f331)
		{
			throw new InvalidOperationException("Unexpected encryption algorithm hash id.");
		}
	}

	[JavaThrows(true)]
	private static void x08ed82b1199c4263(ICryptoTransform x4275eb27dd2dc859, xfcb24ed0e04e3b49 x53b293a29acfaaa6)
	{
		x406f09bc1d85feb2 x406f09bc1d85feb = new x406f09bc1d85feb2();
		byte[] xcdaeea7afaf570ff = x4275eb27dd2dc859.TransformFinalBlock(x53b293a29acfaaa6.x904f21ce603bf8df, 0, x53b293a29acfaaa6.x904f21ce603bf8df.Length);
		byte[] xc017801291d6b7c = x4275eb27dd2dc859.TransformFinalBlock(x53b293a29acfaaa6.xfaf76f2db63899a2, 0, x53b293a29acfaaa6.xfaf76f2db63899a2.Length);
		byte[] xf01158a578cec3a = x406f09bc1d85feb.xc6df3c48d7ea1182(xcdaeea7afaf570ff);
		if (!xcd4bd3abd72ff2da.x5fa70910f253aafa(xc017801291d6b7c, xf01158a578cec3a, x53b293a29acfaaa6.xbeb13e55b38b8ba3))
		{
			throw new IncorrectPasswordException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fnlogocpaojpijaajnhabooacnfbbombgndclmkcbnbdenidnhpdkmgeilnehmefemlffmcgkljgklahjkhhcgohikfipkmijfdjpjkjbkbkdjikmjpkmjgljjnljiemeilmcjcnjejn", 1965157249)));
		}
	}

	private static void x232cd75eb5343f30(ICryptoTransform x157bbc1582e03542, Stream x23cda4cfdf81f2cf, Stream xedc894794186020d)
	{
		x23cda4cfdf81f2cf.Position = 0L;
		xedc894794186020d.Position = 0L;
		BinaryReader binaryReader = new BinaryReader(x23cda4cfdf81f2cf);
		long num = binaryReader.ReadInt64();
		xedc894794186020d.SetLength(x0d299f323d241756.x8b2ecf3d830a9342(num, 512));
		x6e7e9d585493eaf1.xaccac17571a8d9fa(x23cda4cfdf81f2cf, xedc894794186020d, x157bbc1582e03542);
		xedc894794186020d.SetLength(num);
		x23cda4cfdf81f2cf.Position = 0L;
		xedc894794186020d.Position = 0L;
	}

	[JavaThrows(true)]
	private xfcb24ed0e04e3b49 x63d633ab4221d12b(ICryptoTransform x0935153e868dee25, byte[] xfe758ab07df158bc)
	{
		x406f09bc1d85feb2 x406f09bc1d85feb = new x406f09bc1d85feb2();
		byte[] array = xff897bbc0ce9fc68(16);
		byte[] array2 = x406f09bc1d85feb.xc6df3c48d7ea1182(array);
		byte[] array3 = new byte[32];
		Array.Copy(array2, array3, array2.Length);
		xfcb24ed0e04e3b49 xfcb24ed0e04e3b50 = new xfcb24ed0e04e3b49();
		xfcb24ed0e04e3b50.x005dbd4d94ca4423 = xfe758ab07df158bc;
		xfcb24ed0e04e3b50.x397a0ed128412c8f = 16;
		xfcb24ed0e04e3b50.xbeb13e55b38b8ba3 = 32;
		xfcb24ed0e04e3b50.x904f21ce603bf8df = x0935153e868dee25.TransformFinalBlock(array, 0, array.Length);
		xfcb24ed0e04e3b50.xfaf76f2db63899a2 = x0935153e868dee25.TransformFinalBlock(array3, 0, array3.Length);
		return xfcb24ed0e04e3b50;
	}

	private static void x34c2fd9630dc4e80(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(131076);
		xbdfb620b7167944b.Write(36);
		xbdfb620b7167944b.Write(140);
		xbdfb620b7167944b.Write(36);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(26126);
		xbdfb620b7167944b.Write(32772);
		xbdfb620b7167944b.Write(128);
		xbdfb620b7167944b.Write(24);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(0);
		x93b05c1ad709a695.x535736a60cc73a33("Microsoft Enhanced RSA and AES Cryptographic Provider", xbdfb620b7167944b);
	}

	private static void x1cbd67cd9e92d71b(ICryptoTransform x0935153e868dee25, Stream x23cda4cfdf81f2cf, Stream xedc894794186020d)
	{
		x23cda4cfdf81f2cf.Position = 0L;
		xedc894794186020d.Position = 0L;
		long length = x23cda4cfdf81f2cf.Length;
		x23cda4cfdf81f2cf.SetLength(x0d299f323d241756.x8b2ecf3d830a9342(x23cda4cfdf81f2cf.Length, 16));
		BinaryWriter binaryWriter = new BinaryWriter(xedc894794186020d);
		binaryWriter.Write(length);
		xedc894794186020d.SetLength(x0d299f323d241756.x8b2ecf3d830a9342(length, 16) + 8);
		x6e7e9d585493eaf1.xaccac17571a8d9fa(x23cda4cfdf81f2cf, xedc894794186020d, x0935153e868dee25);
		x23cda4cfdf81f2cf.Position = 0L;
		xedc894794186020d.Position = 0L;
	}

	private static byte[] x904960fec10547b1(int xc66814dd5c4c3675, x406f09bc1d85feb2 x2440760443f1d7fd, string xe8e4b5871d71a79a, byte[] xfe758ab07df158bc)
	{
		byte[] x326b5d6503ca9dce = xb85a871176de8dab(x2440760443f1d7fd, xe8e4b5871d71a79a, xfe758ab07df158bc);
		byte[] array = x6a9039a6261545a5(x2440760443f1d7fd, 54, x326b5d6503ca9dce);
		byte[] array2 = x6a9039a6261545a5(x2440760443f1d7fd, 92, x326b5d6503ca9dce);
		byte[] array3 = new byte[array.Length + array2.Length];
		array.CopyTo(array3, 0);
		array2.CopyTo(array3, array.Length);
		byte[] array4 = new byte[xc66814dd5c4c3675 / 8];
		Array.Copy(array3, 0, array4, 0, array4.Length);
		return array4;
	}

	private static byte[] xb85a871176de8dab(x406f09bc1d85feb2 x2440760443f1d7fd, string xe8e4b5871d71a79a, byte[] xfe758ab07df158bc)
	{
		if (xe8e4b5871d71a79a == null)
		{
			xe8e4b5871d71a79a = "";
		}
		byte[] bytes = Encoding.Unicode.GetBytes(xe8e4b5871d71a79a);
		byte[] array = new byte[xfe758ab07df158bc.Length + bytes.Length];
		xfe758ab07df158bc.CopyTo(array, 0);
		bytes.CopyTo(array, xfe758ab07df158bc.Length);
		byte[] array2 = x2440760443f1d7fd.xc6df3c48d7ea1182(array);
		byte[] array3 = new byte[4 + array2.Length];
		for (int i = 0; i < 50000; i++)
		{
			x0d299f323d241756.x3ae29f473f29ef2a(i, array3, 0);
			array2.CopyTo(array3, 4);
			array2 = x2440760443f1d7fd.xc6df3c48d7ea1182(array3);
		}
		array2.CopyTo(array3, 0);
		x0d299f323d241756.x3ae29f473f29ef2a(0, array3, array2.Length);
		return x2440760443f1d7fd.xc6df3c48d7ea1182(array3);
	}

	private static byte[] x6a9039a6261545a5(x406f09bc1d85feb2 x2440760443f1d7fd, byte xbcea506a33cf9111, byte[] x326b5d6503ca9dce)
	{
		byte[] array = new byte[64];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = xbcea506a33cf9111;
		}
		for (int j = 0; j < x326b5d6503ca9dce.Length; j++)
		{
			array[j] = (byte)(array[j] ^ x326b5d6503ca9dce[j]);
		}
		return x2440760443f1d7fd.xc6df3c48d7ea1182(array);
	}

	private byte[] xff897bbc0ce9fc68(int x10f4d88af727adbc)
	{
		byte[] array = new byte[x10f4d88af727adbc];
		xa69bdc19d203240d.NextBytes(array);
		return array;
	}
}
