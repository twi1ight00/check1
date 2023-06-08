using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Aspose.Words;
using x13f1efc79617a47b;
using x5f3520a4b31ea90f;
using x6c95d9cf46ff5f25;

namespace xcf014befd8b52c3b;

internal class x9c22ad4a98e0ba4b : x557c047c56f10b18
{
	private x367286a96a081506 xd609a31d1c112554;

	private RijndaelManaged x2d4a13e20d7edb7b = new RijndaelManaged();

	private x406f09bc1d85feb2 x2b74de0ea830c87e;

	private byte[] xd29e92b0e19676e9;

	private static readonly byte[] xed6e260f8798c69a = new byte[8] { 254, 167, 210, 118, 59, 75, 158, 121 };

	private static readonly byte[] xe9b9b3a12189146c = new byte[8] { 215, 170, 15, 109, 48, 97, 52, 78 };

	private static readonly byte[] x713bd139991e77bc = new byte[8] { 20, 110, 11, 231, 171, 172, 208, 214 };

	private static readonly byte[] xace3110bda57e964 = new byte[8] { 95, 178, 173, 1, 12, 185, 225, 246 };

	private static readonly byte[] x35c72ef92b33a291 = new byte[8] { 160, 103, 127, 2, 178, 44, 132, 51 };

	private x367286a96a081506 xd457a55deeace435 => xd609a31d1c112554;

	private x52b0c0c800ac794c x53bed1bc076ccb94 => xd609a31d1c112554.x52b0c0c800ac794c;

	public void xcc381ffa3ede662f(Stream xb2068605036a9126, Stream x303b0227e3017b6b, Stream xcf18e5243f8d5fd3, string xe8e4b5871d71a79a)
	{
		xb2068605036a9126.Position = 8L;
		BinaryReader encryptionInfoReader = new BinaryReader(xb2068605036a9126);
		xd609a31d1c112554 = new x367286a96a081506(encryptionInfoReader);
		if (x53bed1bc076ccb94.x44f63c356a0e0a2a != "AES")
		{
			throw new InvalidOperationException("Unsupported cipher algorithm.");
		}
		if (x53bed1bc076ccb94.x3b8b3c175efa9d40 != "SHA1")
		{
			throw new InvalidOperationException("Unsupported hash algorithm.");
		}
		x030399a5de0894f0(xe8e4b5871d71a79a);
		if (!x34c52f11773929a9())
		{
			throw new IncorrectPasswordException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hemkifdlcfklkabmleimdfpmeegndfnnieeondlodecpgejppoppmdhakcoajdfbgdmbhddcmckcmcbdlbidenodkbgebcnelmdfbblfdbcgfajgoaahoahhlaohlpeigplieadjlljj", 1775414259)));
		}
		if (!x373cfa6de28739bf(x303b0227e3017b6b))
		{
			throw new FileCorruptedException("The document integrity is failed.");
		}
		byte[] xe6a886352f5d5d4c = x27d80eaaee4256f4(x53bed1bc076ccb94.x92cd30b311b9f798, x53bed1bc076ccb94.x3e1430718f0a0a3a, x713bd139991e77bc);
		x232cd75eb5343f30(x303b0227e3017b6b, xcf18e5243f8d5fd3, xe6a886352f5d5d4c);
	}

	public void x246b032720dd4c0d(Stream x2fe2b17d7bd979f2, Stream xcf18e5243f8d5fd3, Stream x303b0227e3017b6b, string xe8e4b5871d71a79a)
	{
		throw new NotImplementedException();
	}

	private void x030399a5de0894f0(string xe8e4b5871d71a79a)
	{
		x2d4a13e20d7edb7b = new RijndaelManaged();
		x2b74de0ea830c87e = new x406f09bc1d85feb2();
		x2d4a13e20d7edb7b.BlockSize = x53bed1bc076ccb94.xaf58b56360d8ce2d << 3;
		x2d4a13e20d7edb7b.KeySize = x53bed1bc076ccb94.xebe5541cca97eab4;
		x2d4a13e20d7edb7b.Mode = ((!(x53bed1bc076ccb94.x010a9b7177d08aeb == "ChainingModeCFB")) ? CipherMode.CBC : CipherMode.CFB);
		x2d4a13e20d7edb7b.Padding = PaddingMode.Zeros;
		xd29e92b0e19676e9 = x355f114117106d11(xe8e4b5871d71a79a, x53bed1bc076ccb94.x92cd30b311b9f798, x53bed1bc076ccb94.x182892fe19e15182);
	}

	private void x232cd75eb5343f30(Stream x23cda4cfdf81f2cf, Stream xedc894794186020d, byte[] xe6a886352f5d5d4c)
	{
		x23cda4cfdf81f2cf.Position = 0L;
		xedc894794186020d.Position = 0L;
		BinaryReader binaryReader = new BinaryReader(x23cda4cfdf81f2cf);
		long num = binaryReader.ReadInt64();
		xedc894794186020d.SetLength(x0d299f323d241756.x8b2ecf3d830a9342(num, 512));
		byte[] array = new byte[4096];
		int num2 = 0;
		while (x23cda4cfdf81f2cf.Position < x23cda4cfdf81f2cf.Length)
		{
			int count = Math.Min((int)(x23cda4cfdf81f2cf.Length - x23cda4cfdf81f2cf.Position), 4096);
			x23cda4cfdf81f2cf.Read(array, 0, count);
			byte[] xb401c917e47dcb = xc6df3c48d7ea1182(xd457a55deeace435.x92cd30b311b9f798, BitConverter.GetBytes(num2), xd457a55deeace435.xaf58b56360d8ce2d, 54);
			byte[] buffer = xcc381ffa3ede662f(xe6a886352f5d5d4c, xb401c917e47dcb, array);
			xedc894794186020d.Write(buffer, 0, count);
			num2++;
		}
		xedc894794186020d.SetLength(num);
		xedc894794186020d.Position = 0L;
	}

	private bool x34c52f11773929a9()
	{
		byte[] x92cd30b311b9f = x53bed1bc076ccb94.x92cd30b311b9f798;
		int x1f875ed86e20ee9a = x53bed1bc076ccb94.x1f875ed86e20ee9a;
		byte[] xc017801291d6b7c = x18ad9149890f096d(x27d80eaaee4256f4(x92cd30b311b9f, x53bed1bc076ccb94.x1984b0f5258978fb, xe9b9b3a12189146c), x1f875ed86e20ee9a, 0);
		byte[] xf01158a578cec3a = x2b74de0ea830c87e.xc6df3c48d7ea1182(x27d80eaaee4256f4(x92cd30b311b9f, x53bed1bc076ccb94.x2620fb93ab4c44e6, xed6e260f8798c69a));
		return xcd4bd3abd72ff2da.xf920f15ca6067ada(xc017801291d6b7c, xf01158a578cec3a);
	}

	private bool x373cfa6de28739bf(Stream x23cda4cfdf81f2cf)
	{
		byte[] x92cd30b311b9f = x53bed1bc076ccb94.x92cd30b311b9f798;
		byte[] x92cd30b311b9f2 = xd457a55deeace435.x92cd30b311b9f798;
		int x1f875ed86e20ee9a = xd457a55deeace435.x1f875ed86e20ee9a;
		int xaf58b56360d8ce2d = xd457a55deeace435.xaf58b56360d8ce2d;
		byte[] xae8ee8b61c3f1ef = x27d80eaaee4256f4(x92cd30b311b9f, x53bed1bc076ccb94.x3e1430718f0a0a3a, x713bd139991e77bc);
		byte[] xb401c917e47dcb = xc6df3c48d7ea1182(x92cd30b311b9f2, xace3110bda57e964, xaf58b56360d8ce2d, 0);
		KeyedHashAlgorithm keyedHashAlgorithm = KeyedHashAlgorithm.Create("HMAC" + xd457a55deeace435.x3b8b3c175efa9d40);
		keyedHashAlgorithm.Key = x91b1324a0d22dc1f(xae8ee8b61c3f1ef, xb401c917e47dcb, xd457a55deeace435.x8a8292fae8b05ecb, x1f875ed86e20ee9a, 0);
		byte[] xc017801291d6b7c = keyedHashAlgorithm.ComputeHash(x23cda4cfdf81f2cf);
		byte[] xb401c917e47dcb2 = xc6df3c48d7ea1182(x92cd30b311b9f2, x35c72ef92b33a291, xaf58b56360d8ce2d, 0);
		byte[] xf01158a578cec3a = x91b1324a0d22dc1f(xae8ee8b61c3f1ef, xb401c917e47dcb2, xd457a55deeace435.xf0c1fbb5b7540bc3, x1f875ed86e20ee9a, 0);
		return xcd4bd3abd72ff2da.xf920f15ca6067ada(xc017801291d6b7c, xf01158a578cec3a);
	}

	private byte[] x27d80eaaee4256f4(byte[] xb401c917e47dcb30, byte[] x8c83199efd9d7e88, byte[] xe413319369b234aa)
	{
		return xcc381ffa3ede662f(xa25bf57728e7b97d(xe413319369b234aa), xb401c917e47dcb30, x8c83199efd9d7e88);
	}

	private byte[] x91b1324a0d22dc1f(byte[] xae8ee8b61c3f1ef0, byte[] xb401c917e47dcb30, byte[] x8c83199efd9d7e88, int x0ceec69a97f73617, byte xcaf2e4729806e32b)
	{
		return x18ad9149890f096d(xcc381ffa3ede662f(xae8ee8b61c3f1ef0, xb401c917e47dcb30, x8c83199efd9d7e88), x0ceec69a97f73617, xcaf2e4729806e32b);
	}

	private byte[] xcc381ffa3ede662f(byte[] xae8ee8b61c3f1ef0, byte[] xb401c917e47dcb30, byte[] x8c83199efd9d7e88)
	{
		ICryptoTransform transform = x2d4a13e20d7edb7b.CreateDecryptor(xae8ee8b61c3f1ef0, xb401c917e47dcb30);
		byte[] array = null;
		using MemoryStream stream = new MemoryStream(x8c83199efd9d7e88, 0, x8c83199efd9d7e88.Length);
		using CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Read);
		array = new byte[x8c83199efd9d7e88.Length];
		cryptoStream.Read(array, 0, array.Length);
		return array;
	}

	private byte[] x355f114117106d11(string xe8e4b5871d71a79a, byte[] xfe758ab07df158bc, int xbcf9ae42f3d8f88e)
	{
		byte[] bytes = Encoding.Unicode.GetBytes((xe8e4b5871d71a79a != null) ? xe8e4b5871d71a79a : "");
		byte[] array = xc6df3c48d7ea1182(xfe758ab07df158bc, bytes);
		byte[] array2 = new byte[array.Length + 4];
		for (int i = 0; i < xbcf9ae42f3d8f88e; i++)
		{
			x0d299f323d241756.x3ae29f473f29ef2a(i, array2, 0);
			array.CopyTo(array2, 4);
			array = x2b74de0ea830c87e.xc6df3c48d7ea1182(array2);
		}
		return array;
	}

	private byte[] xa25bf57728e7b97d(byte[] x080d32584f1d4af3)
	{
		return xc6df3c48d7ea1182(xd29e92b0e19676e9, x080d32584f1d4af3, x53bed1bc076ccb94.xebe5541cca97eab4 >> 3, 54);
	}

	private byte[] xc6df3c48d7ea1182(byte[] x4a3f0a05c02f235f, byte[] xe413319369b234aa, int x0ceec69a97f73617, byte xcaf2e4729806e32b)
	{
		return x18ad9149890f096d(xc6df3c48d7ea1182(x4a3f0a05c02f235f, xe413319369b234aa), x0ceec69a97f73617, xcaf2e4729806e32b);
	}

	private byte[] xc6df3c48d7ea1182(byte[] x4a3f0a05c02f235f, byte[] xe413319369b234aa)
	{
		byte[] array = new byte[x4a3f0a05c02f235f.Length + xe413319369b234aa.Length];
		x4a3f0a05c02f235f.CopyTo(array, 0);
		xe413319369b234aa.CopyTo(array, x4a3f0a05c02f235f.Length);
		return x2b74de0ea830c87e.xc6df3c48d7ea1182(array);
	}

	private static byte[] x18ad9149890f096d(byte[] x4a3f0a05c02f235f, int x0ceec69a97f73617, byte xcaf2e4729806e32b)
	{
		byte[] array = new byte[x0ceec69a97f73617];
		for (int i = 0; i < x0ceec69a97f73617; i++)
		{
			array[i] = ((i < Math.Min(x0ceec69a97f73617, x4a3f0a05c02f235f.Length)) ? x4a3f0a05c02f235f[i] : xcaf2e4729806e32b);
		}
		return array;
	}
}
