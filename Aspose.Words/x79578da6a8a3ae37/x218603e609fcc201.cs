using System.Collections;
using System.Text;
using x5f3520a4b31ea90f;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x79578da6a8a3ae37;

internal class x218603e609fcc201
{
	internal const int xe05c10fca18d12df = 50000;

	internal const int x9200ef4b35aa3815 = 4;

	internal const int x89d2e0570a176bd5 = 15;

	internal byte[] xf35aae0fa4a217a4;

	internal byte[] x005dbd4d94ca4423;

	internal int xc69c1bca8baaf933;

	internal int xe45f03ec1cfa61ea;

	internal static readonly byte[] xb78fde03513a3d49;

	private static readonly Hashtable xa7a46ecbc0ef51b5;

	private static readonly Hashtable x076e589ce2f1485b;

	private static readonly object[] xa5a6ee0fd405962b;

	internal bool x7149c962c02931b3 => xf35aae0fa4a217a4 == null;

	static x218603e609fcc201()
	{
		xb78fde03513a3d49 = new byte[16]
		{
			132, 138, 142, 151, 223, 100, 34, 191, 254, 55,
			72, 114, 162, 241, 42, 237
		};
		xa7a46ecbc0ef51b5 = new Hashtable();
		x076e589ce2f1485b = new Hashtable();
		xa5a6ee0fd405962b = new object[20]
		{
			"MD2", 1, "MD4", 2, "MD5", 3, "RIPEMD-128", 6, "RIPEMD-160", 7,
			"SHA-1", 4, "SHA-256", 12, "SHA-384", 13, "SHA-512", 14, "WHIRLPOOL", 15
		};
		x682712679dbc585a.x70fa1602ceccddee(xa5a6ee0fd405962b, xa7a46ecbc0ef51b5, x076e589ce2f1485b);
	}

	internal void x129b0b54f12e8dff(int x43670b9bd933f74b)
	{
		xc69c1bca8baaf933 = 4;
		xe45f03ec1cfa61ea = 50000;
		x005dbd4d94ca4423 = xb78fde03513a3d49;
		byte[] array = new byte[32];
		x005dbd4d94ca4423.CopyTo(array, 0);
		string s = xca004f56614e2431.xaa4e6020773f88bc(x26000ce44ebda9ea.xc44c58d0078e5f2e(x43670b9bd933f74b));
		byte[] bytes = Encoding.Unicode.GetBytes(s);
		bytes.CopyTo(array, 16);
		xf35aae0fa4a217a4 = x784b313ca787a2e4(array, xe45f03ec1cfa61ea);
	}

	internal void x94322bb2aaf0dbfe(string xe8e4b5871d71a79a)
	{
		xc69c1bca8baaf933 = 4;
		xe45f03ec1cfa61ea = 50000;
		x005dbd4d94ca4423 = xb78fde03513a3d49;
		byte[] bytes = Encoding.Unicode.GetBytes(xe8e4b5871d71a79a);
		byte[] array = new byte[16 + bytes.Length];
		x005dbd4d94ca4423.CopyTo(array, 0);
		bytes.CopyTo(array, 16);
		xf35aae0fa4a217a4 = x784b313ca787a2e4(array, xe45f03ec1cfa61ea);
	}

	internal x218603e609fcc201 x8b61531c8ea35b85()
	{
		return (x218603e609fcc201)MemberwiseClone();
	}

	internal static int x33df0e9a6206a982(string xc15bd84e01929885)
	{
		return (int)x682712679dbc585a.xce92de628aa023cf(xa7a46ecbc0ef51b5, xc15bd84e01929885, 15);
	}

	internal static string x1d1e9feed236150f(int x8587e439fdabc3eb)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x076e589ce2f1485b, x8587e439fdabc3eb);
	}

	private static byte[] x784b313ca787a2e4(byte[] x1a5841d6377fb797, int xbcf9ae42f3d8f88e)
	{
		x406f09bc1d85feb2 x406f09bc1d85feb = new x406f09bc1d85feb2();
		byte[] array = x406f09bc1d85feb.xc6df3c48d7ea1182(x1a5841d6377fb797);
		byte[] array2 = new byte[24];
		for (int i = 0; i < xbcf9ae42f3d8f88e; i++)
		{
			array.CopyTo(array2, 0);
			x0d299f323d241756.x3ae29f473f29ef2a(i, array2, 20);
			array = x406f09bc1d85feb.xc6df3c48d7ea1182(array2);
		}
		return array;
	}
}
