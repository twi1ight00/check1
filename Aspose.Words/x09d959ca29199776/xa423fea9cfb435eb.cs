using System.IO;
using x6c95d9cf46ff5f25;

namespace x09d959ca29199776;

internal class xa423fea9cfb435eb
{
	private x38b354f22d4b5b8a x9b529da35d1032aa;

	private byte xe16399364209fd51;

	private int x35a5073ffeb125c5;

	public xa423fea9cfb435eb()
	{
		x9b529da35d1032aa = x38b354f22d4b5b8a.x660adf533ba4edef;
	}

	public byte[] x3e5eb325bb7cca3c(byte xbcea506a33cf9111)
	{
		switch (x9b529da35d1032aa)
		{
		case x38b354f22d4b5b8a.x660adf533ba4edef:
			xe16399364209fd51 = xbcea506a33cf9111;
			x9b529da35d1032aa = x38b354f22d4b5b8a.xe9e531d1a6725226;
			return xcd4bd3abd72ff2da.x2b0797e1bb4e840a;
		case x38b354f22d4b5b8a.xe9e531d1a6725226:
			if (xbcea506a33cf9111 == xe16399364209fd51)
			{
				x9b529da35d1032aa = x38b354f22d4b5b8a.x122857a1918ec00a;
				return xcd4bd3abd72ff2da.x2b0797e1bb4e840a;
			}
			return x5acac2dbc1ec8206(xbcea506a33cf9111, 1);
		case x38b354f22d4b5b8a.x122857a1918ec00a:
			if (xbcea506a33cf9111 == 0)
			{
				x9b529da35d1032aa = x38b354f22d4b5b8a.xe9e531d1a6725226;
				return x5acac2dbc1ec8206(xe16399364209fd51, 1);
			}
			x35a5073ffeb125c5 = xbcea506a33cf9111;
			x9b529da35d1032aa = x38b354f22d4b5b8a.x177b110b1cc897f2;
			return xcd4bd3abd72ff2da.x2b0797e1bb4e840a;
		case x38b354f22d4b5b8a.x177b110b1cc897f2:
			x9b529da35d1032aa = x38b354f22d4b5b8a.xe9e531d1a6725226;
			return x5acac2dbc1ec8206(xbcea506a33cf9111, x35a5073ffeb125c5);
		default:
			return xcd4bd3abd72ff2da.x2b0797e1bb4e840a;
		}
	}

	private byte[] x5acac2dbc1ec8206(byte xbcea506a33cf9111, int x961016a387451f05)
	{
		byte[] array = new byte[x961016a387451f05];
		for (int i = 0; i < x961016a387451f05; i++)
		{
			array[i] = xbcea506a33cf9111;
		}
		return array;
	}

	public static byte[] xf76803be5e9ee2aa(byte[] x4a3f0a05c02f235f)
	{
		using MemoryStream memoryStream = new MemoryStream();
		xa423fea9cfb435eb xa423fea9cfb435eb2 = new xa423fea9cfb435eb();
		for (int i = 0; i < x4a3f0a05c02f235f.Length; i++)
		{
			byte[] array = xa423fea9cfb435eb2.x3e5eb325bb7cca3c(x4a3f0a05c02f235f[i]);
			if (array.Length > 0)
			{
				memoryStream.Write(array, 0, array.Length);
			}
		}
		return memoryStream.ToArray();
	}
}
