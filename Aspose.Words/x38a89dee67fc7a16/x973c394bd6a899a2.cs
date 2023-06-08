using System;
using System.Collections;
using System.IO;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x38a89dee67fc7a16;

internal class x973c394bd6a899a2
{
	internal const int x90947c9ddca106fb = 8;

	private static readonly byte[] xa2801ff886d2fc7c;

	private static readonly Hashtable x59397efededcf610;

	private static readonly object x4690e788455ae5ea;

	private x973c394bd6a899a2()
	{
	}

	static x973c394bd6a899a2()
	{
		x59397efededcf610 = new Hashtable();
		x4690e788455ae5ea = new object();
		using Stream stream = xed747ca236d86aa0.xe1cd764b6fb0d6f6("Aspose.Resources.HatchMasks.dat");
		xa2801ff886d2fc7c = new byte[(int)stream.Length];
		stream.Read(xa2801ff886d2fc7c, 0, xa2801ff886d2fc7c.Length);
	}

	internal static byte[] xb19c72971505e3ca(x5bdb4ba66c23277c xd8f1949f8950238a)
	{
		string key = x412a2117d057945e(xd8f1949f8950238a);
		byte[] array;
		lock (x4690e788455ae5ea)
		{
			array = (byte[])x59397efededcf610[key];
		}
		if (array == null)
		{
			lock (x4690e788455ae5ea)
			{
				array = (byte[])x59397efededcf610[key];
				if (array == null)
				{
					array = xfbc0a66e1e3d38e4(xd8f1949f8950238a);
					x59397efededcf610[key] = array;
				}
			}
		}
		return array;
	}

	private static byte[] xfbc0a66e1e3d38e4(x5bdb4ba66c23277c xd8f1949f8950238a)
	{
		byte[] array = new byte[8];
		Array.Copy(xa2801ff886d2fc7c, (int)xd8f1949f8950238a.xaf9d27b89edd7fea * 8, array, 0, 8);
		using x3cd5d648729cd9b6 x3cd5d648729cd9b = new x3cd5d648729cd9b6(8, 8);
		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				x26d9ecb4bdf0456d x6c50a99faab7d = (((array[i] & (128 >> j)) > 0) ? xd8f1949f8950238a.x8fdbd80e8da6b0e6 : xd8f1949f8950238a.x83729c7ebf48ae24);
				x3cd5d648729cd9b.xd9c8acf0e5a12504(j, 7 - i, x6c50a99faab7d);
			}
		}
		MemoryStream memoryStream = new MemoryStream();
		x3cd5d648729cd9b.x0acd3c2012ea2ee8(memoryStream, xfe2ff3c162b47c70.x6339cdb9e2b512c7);
		return x0d299f323d241756.xa0aed4cd3b3d5d92(memoryStream);
	}

	private static string x412a2117d057945e(x5bdb4ba66c23277c xd8f1949f8950238a)
	{
		return $"{xd8f1949f8950238a.xaf9d27b89edd7fea}{xd8f1949f8950238a.x83729c7ebf48ae24.xb2c94956116ca10a():X}{xd8f1949f8950238a.x8fdbd80e8da6b0e6.xb2c94956116ca10a():X}";
	}
}
