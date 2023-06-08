using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x2697283ff424107e;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x5f3520a4b31ea90f;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x7c7a1dceb600404e;

internal class x64893267b789fd52
{
	private const double x0b5a4b12b877bfce = 16777216.0;

	private static readonly byte[] xf6bf5f1020ade06d = new byte[10] { 31, 139, 8, 0, 0, 0, 0, 0, 2, 11 };

	internal static string x1b5aabf1ead9cf9a(int xbcea506a33cf9111)
	{
		return xc86b859f104c5de7(x4574ea26106f0edb.xa23e6b6c3169521d(xbcea506a33cf9111));
	}

	internal static string xf25c4a2449a497c8(int xbcea506a33cf9111)
	{
		return x9e4f09321bca6db3(x4574ea26106f0edb.x9e9e006b3108fa4a(xbcea506a33cf9111));
	}

	internal static string xe9a7724568345f89(xa3fc7dcdc8182ff6 x44ecfea61c937b8e)
	{
		return x44ecfea61c937b8e.x9a706f5d15bd6d95(xb39cf349cb3e0d91: false).Replace("; ", ";");
	}

	internal static string x67581c842683a852(ShapeBase x5770cdefd8931aa9)
	{
		return string.Format("_x0000_{0}{1}", x5770cdefd8931aa9.IsInline ? "i" : "s", xca004f56614e2431.xd2bd6588f73f7402(x5770cdefd8931aa9.xea1e81378298fa81));
	}

	internal static string x6d02c598a7b8fc1f(ShapeBase x5770cdefd8931aa9)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x5770cdefd8931aa9.Name))
		{
			return x67581c842683a852(x5770cdefd8931aa9);
		}
		return x5770cdefd8931aa9.Name;
	}

	internal static string xc3b86f9c2e8b19e4(Hashtable xa5ea04da0b735c3b)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 129; i <= 132; i++)
		{
			if (xa5ea04da0b735c3b[i] != null)
			{
				stringBuilder.Append(xc86b859f104c5de7(x4574ea26106f0edb.xa23e6b6c3169521d((int)xa5ea04da0b735c3b[i])));
			}
			stringBuilder.Append(',');
		}
		return stringBuilder.ToString().TrimEnd(',');
	}

	internal static string x19523ee23bbcf67d(object xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == null)
		{
			return null;
		}
		int xbcea506a33cf9112 = (int)xbcea506a33cf9111;
		return x19523ee23bbcf67d(xbcea506a33cf9112);
	}

	internal static string x19523ee23bbcf67d(int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == 0)
		{
			return "0";
		}
		if (xbcea506a33cf9111 % 16384 == 0)
		{
			return xca004f56614e2431.xdbca7a004e2d3753((double)xbcea506a33cf9111 / 65536.0);
		}
		return xbcea506a33cf9111 + "f";
	}

	internal static string xdd13b76d78255522(object xbcea506a33cf9111, bool xc6e85c82d0d89508)
	{
		bool flag = (bool)xbcea506a33cf9111;
		if (flag != xc6e85c82d0d89508)
		{
			return xdd13b76d78255522(flag);
		}
		return null;
	}

	internal static string xdd13b76d78255522(object xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == null)
		{
			return null;
		}
		bool xbcea506a33cf9112 = (bool)xbcea506a33cf9111;
		return xdd13b76d78255522(xbcea506a33cf9112);
	}

	internal static string xdd13b76d78255522(bool xbcea506a33cf9111)
	{
		if (!xbcea506a33cf9111)
		{
			return "f";
		}
		return "t";
	}

	internal static string x933e1cb72ce52a40(int xbcea506a33cf9111)
	{
		double num = x4574ea26106f0edb.x97ab502db0c0e5c2(xbcea506a33cf9111);
		if (num == Math.Round(num))
		{
			return xca004f56614e2431.x754c3a5f03a2ce84((int)num);
		}
		return xca004f56614e2431.x754c3a5f03a2ce84(xbcea506a33cf9111) + "fd";
	}

	internal static string x0420a2578180e329(x9fb6ff04f20b10d0[] xa70c7ccd3278240f)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < xa70c7ccd3278240f.Length; i++)
		{
			if (i == 0)
			{
				stringBuilder.Append($"{0} {xd76179d16486fd56.xbe7cce711e45fa32(xa70c7ccd3278240f[i].x9b41425268471380)};");
			}
			else if (i == xa70c7ccd3278240f.Length - 1)
			{
				stringBuilder.Append($"{1} {xd76179d16486fd56.xbe7cce711e45fa32(xa70c7ccd3278240f[i].x9b41425268471380)};");
			}
			else
			{
				stringBuilder.Append($"{x19523ee23bbcf67d(xa70c7ccd3278240f[i].x12cb12b5d2cad53d)} {xd76179d16486fd56.xbe7cce711e45fa32(xa70c7ccd3278240f[i].x9b41425268471380)};");
			}
		}
		if (stringBuilder.Length > 0)
		{
			return stringBuilder.ToString(0, stringBuilder.Length - 1);
		}
		return "";
	}

	internal static string xb174242678100558(Point x2f7096dac971d6ec)
	{
		return $"{xca004f56614e2431.x754c3a5f03a2ce84(x2f7096dac971d6ec.X)},{xca004f56614e2431.x754c3a5f03a2ce84(x2f7096dac971d6ec.Y)}";
	}

	internal static string xb174242678100558(double x08db3aeabb253cb1, double x1e218ceaee1bb583, bool x44c75ba56852f87a)
	{
		return $"{xc86b859f104c5de7(x08db3aeabb253cb1, x44c75ba56852f87a)},{xc86b859f104c5de7(x1e218ceaee1bb583, x44c75ba56852f87a)}";
	}

	internal static string xc86b859f104c5de7(object xbcea506a33cf9111, bool x44c75ba56852f87a)
	{
		if (xbcea506a33cf9111 == null)
		{
			return null;
		}
		double xbcea506a33cf9112 = (double)xbcea506a33cf9111;
		return xc86b859f104c5de7(xbcea506a33cf9112, x44c75ba56852f87a);
	}

	internal static string xc86b859f104c5de7(double xbcea506a33cf9111, bool x44c75ba56852f87a)
	{
		if (x44c75ba56852f87a)
		{
			return xc86b859f104c5de7(xbcea506a33cf9111);
		}
		return xca004f56614e2431.x754c3a5f03a2ce84(x15e971129fd80714.x43fcc3f62534530b(xbcea506a33cf9111));
	}

	internal static string xc86b859f104c5de7(double xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == 0.0)
		{
			return "0";
		}
		if (xbcea506a33cf9111 % 72.0 == 0.0)
		{
			return xca004f56614e2431.xdbca7a004e2d3753(xbcea506a33cf9111 / 72.0) + "in";
		}
		return xca004f56614e2431.xdbca7a004e2d3753(xbcea506a33cf9111) + "pt";
	}

	internal static string x9e4f09321bca6db3(double xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == 0.0)
		{
			return "0";
		}
		return xca004f56614e2431.xcadee4aea45827c2(xbcea506a33cf9111) + "mm";
	}

	internal static string x61c9626b6c3326e9(int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == 0)
		{
			return "0";
		}
		return xca004f56614e2431.x754c3a5f03a2ce84(xbcea506a33cf9111) + "%";
	}

	internal static string x2a162e0e073f78e7(Border xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != null && xbcea506a33cf9111.IsVisible)
		{
			x26d9ecb4bdf0456d x63b1a7c31a = xbcea506a33cf9111.x63b1a7c31a962459;
			return xd76179d16486fd56.xbe7cce711e45fa32(x63b1a7c31a);
		}
		return "";
	}

	internal static string xabfe6d71167aee98(int xbcea506a33cf9111)
	{
		double x37cf7043760b312e = (double)xbcea506a33cf9111 / 16777216.0;
		return xca004f56614e2431.x97cefc6d2c90b1bc(x37cf7043760b312e);
	}

	internal static int xaacec4c76837bf85(string xbcea506a33cf9111)
	{
		return x15e971129fd80714.x43fcc3f62534530b(xca004f56614e2431.xec25d08a2af152f0(xbcea506a33cf9111) * 16777216.0);
	}

	internal static int x650d90d2e073ca99(string x339202c751057f71)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(x339202c751057f71.Trim('#'));
		x96c391b35001fd69 x96c391b35001fd = new x96c391b35001fd69();
		return x96c391b35001fd.xf4513182b4682707(bytes);
	}

	internal static byte[] x7b2ace3ecba130d8(byte[] x43e181e083db6cdf)
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		string text = "MSOFFICE9.0";
		for (int i = 0; i < text.Length; i++)
		{
			binaryWriter.Write((byte)text[i]);
		}
		binaryWriter.Write((uint)x43e181e083db6cdf.Length);
		xa2745adfabe0c674 xa2745adfabe0c = xdd1b8f14cc8ba86d.x50da520b0fc223ec(x43e181e083db6cdf);
		binaryWriter.Write(xa2745adfabe0c.x72d92bd1aff02e37);
		binaryWriter.Write(xa2745adfabe0c.xe360b1885d8d4a41);
		binaryWriter.Write(xa2745adfabe0c.x419ba17a5322627b);
		binaryWriter.Write(xa2745adfabe0c.x9bcb07e204e30218);
		binaryWriter.Write(xa2745adfabe0c.xf0dac309e0310811);
		binaryWriter.Write(xa2745adfabe0c.x46df0eb1a743eced);
		binaryWriter.Write(0u);
		binaryWriter.Write((ushort)65024);
		for (int j = 0; j < 467; j++)
		{
			binaryWriter.Write((byte)0);
		}
		binaryWriter.Write(x43e181e083db6cdf);
		return xda9a45260aafce5e(memoryStream.ToArray());
	}

	internal static byte[] x0824a1a655b79c17(byte[] xbbf76a12e4d7d2d7)
	{
		byte[] array = x8724fdc4dc7fc92f(xbbf76a12e4d7d2d7);
		byte[] array2 = new byte[array.Length - 512];
		Array.Copy(array, 512, array2, 0, array2.Length);
		return array2;
	}

	internal static byte[] xda9a45260aafce5e(byte[] x43e181e083db6cdf)
	{
		x43e181e083db6cdf = xf1da3993f05a75b7.x575db3fedeadea6b(x43e181e083db6cdf, x2e6ebe7013ab34b9.x575db3fedeadea6b);
		byte[] array = new byte[x43e181e083db6cdf.Length + xf6bf5f1020ade06d.Length];
		x43e181e083db6cdf.CopyTo(array, xf6bf5f1020ade06d.Length);
		for (int i = 0; i < xf6bf5f1020ade06d.Length; i++)
		{
			array[i] = xf6bf5f1020ade06d[i];
		}
		return array;
	}

	internal static byte[] x8724fdc4dc7fc92f(byte[] x43e181e083db6cdf)
	{
		if (xf8bcc5af77e4533e(x43e181e083db6cdf))
		{
			MemoryStream x23cda4cfdf81f2cf = new MemoryStream(x43e181e083db6cdf, 10, x43e181e083db6cdf.Length - 10);
			return xf1da3993f05a75b7.x4671919d08389f8e(x23cda4cfdf81f2cf, 0, x2e6ebe7013ab34b9.x575db3fedeadea6b);
		}
		return x43e181e083db6cdf;
	}

	private static bool xf8bcc5af77e4533e(byte[] x43e181e083db6cdf)
	{
		for (int i = 0; i < 4; i++)
		{
			if (x43e181e083db6cdf[i] != xf6bf5f1020ade06d[i])
			{
				return false;
			}
		}
		return true;
	}
}
