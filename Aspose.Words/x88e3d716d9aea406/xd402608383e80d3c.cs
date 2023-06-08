using System;
using System.IO;
using Aspose;
using x13f1efc79617a47b;
using x5f3520a4b31ea90f;

namespace x88e3d716d9aea406;

[JavaDelete("This is antihacking code, not yet ported to Java. Maybe in the future.")]
internal class xd402608383e80d3c
{
	private byte[] x5c8780fe7aa5ad5c;

	private byte[] xe7d06cb218ed4487;

	internal xd402608383e80d3c(byte[] modulus, byte[] exponent)
	{
		x5c8780fe7aa5ad5c = modulus;
		xe7d06cb218ed4487 = exponent;
	}

	internal void x2057a6404e6c2b4c(byte[] x1f25abf5fb75e795, byte[] x8ebde9a98df80374)
	{
		x98e1674350d747bd(x5c8780fe7aa5ad5c, xe7d06cb218ed4487, x1f25abf5fb75e795, x8ebde9a98df80374);
	}

	private static void x98e1674350d747bd(byte[] x44c8221654ea66c6, byte[] xfd97c8b131ef865e, byte[] x1f25abf5fb75e795, byte[] x8ebde9a98df80374)
	{
		if (x8ebde9a98df80374.Length != x44c8221654ea66c6.Length)
		{
			x653127678ccafb25.xd3d1e0b7118994e1 = 1;
		}
		byte[] array = x2cf87a031823314d.xc99bf7542a430c74(x8ebde9a98df80374);
		x0c2c2ec0e5dfca9c x0c2c2ec0e5dfca9c = new x0c2c2ec0e5dfca9c(x44c8221654ea66c6, xfd97c8b131ef865e);
		byte[] array2 = x2cf87a031823314d.x1add485e7984b4a9(x0c2c2ec0e5dfca9c, array);
		byte[] array3 = x2cf87a031823314d.xdf0b52945cea7d94(array2, x0c2c2ec0e5dfca9c.x02f2e920b8f411d0.xce53a4f2835cab70() >> 3);
		byte[] array4 = xfeca13b8f144757c(x1f25abf5fb75e795, array3.Length);
		x2025b81d9343aee4 x2025b81d9343aee5 = new x2025b81d9343aee4(array2);
		x2025b81d9343aee5.x938a7a6f8392b250(array.Length, array4.Length, x5a818e5ab6be4054: false);
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array2, 0, array2.Length);
		x2025b81d9343aee5.xc26e588e0a52d8e6(memoryStream, array4, array.Length);
		if (x2025b81d9343aee5.x957a9b2db4bbd52f)
		{
			array[0] = 0;
			array[1] = 17;
		}
		xc2daff3d6b415a63 xc2daff3d6b415a64 = new xc2daff3d6b415a63(x2025b81d9343aee5, array3, dummyParam2: true, x2025b81d9343aee5.x957a9b2db4bbd52f);
		int[] array5 = new int[array2.Length];
		Array.Copy(array2, 0, array5, 0, array2.Length);
		xc2daff3d6b415a64.x182c6bcb7141d988(array5, x2025b81d9343aee5);
		xc2daff3d6b415a64.xb1b48efc4b4a3e62(null, xaf63715de47092c6: true);
		xc2daff3d6b415a64.xd050c99e95ccff3a(xd0a397c1f04ae76e: true);
		x2025b81d9343aee5.x957a9b2db4bbd52f = true;
		string xd0a397c1f04ae76e = string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mclokccpicjpgcaaechaccoaacfbobmbmbdcabkcobbdmbidkbpdibgegbneebef", 7400187));
		xc2daff3d6b415a64.xb1b48efc4b4a3e62(xd0a397c1f04ae76e, xaf63715de47092c6: false);
		xc2daff3d6b415a64.x216052479859c96a(array2, string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ljfdkmmdemdeamkebmbfalifghpfmjggblngblehaklhmkci", 1100690778)));
	}

	internal static byte[] xfeca13b8f144757c(byte[] x1f25abf5fb75e795, int x5054f5c20f32d0f0)
	{
		x406f09bc1d85feb2 x406f09bc1d85feb = new x406f09bc1d85feb2();
		byte[] array = x406f09bc1d85feb.xc6df3c48d7ea1182(x1f25abf5fb75e795);
		MemoryStream memoryStream = new MemoryStream();
		byte[] array2 = new byte[15]
		{
			48, 33, 48, 9, 6, 5, 43, 14, 3, 2,
			26, 5, 0, 4, 20
		};
		memoryStream.Write(array2, 0, array2.Length);
		memoryStream.Write(array, 0, array.Length);
		if (x5054f5c20f32d0f0 < memoryStream.Length + 11)
		{
			x653127678ccafb25.xd3d1e0b7118994e1 = 11;
		}
		MemoryStream memoryStream2 = new MemoryStream();
		memoryStream2.WriteByte(0);
		memoryStream2.WriteByte(1);
		int num = x5054f5c20f32d0f0 - (int)memoryStream.Length - 3;
		for (int i = 0; i < num; i++)
		{
			memoryStream2.WriteByte(byte.MaxValue);
		}
		memoryStream2.WriteByte(0);
		memoryStream.WriteTo(memoryStream2);
		return memoryStream2.ToArray();
	}
}
