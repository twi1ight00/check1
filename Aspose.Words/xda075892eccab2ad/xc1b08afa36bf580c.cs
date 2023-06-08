using System.Text;
using Aspose.Words;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xda075892eccab2ad;

internal class xc1b08afa36bf580c
{
	private static readonly char[] xf20568e05633abc9 = new char[1] { '#' };

	private xc1b08afa36bf580c()
	{
	}

	internal static string x0bd71ffeca440ed7(string x2eebe5b22e29f252)
	{
		for (int i = 0; i < 9; i++)
		{
			x2eebe5b22e29f252 = x2eebe5b22e29f252.Replace(((char)i).ToString(), x6d7a6575adf56fd3(i));
		}
		return x2eebe5b22e29f252;
	}

	internal static string xd304ca41be063396(x978620a99b6d5014 xc41ca7be73709324)
	{
		string x5051a4a3b273ffce = xc41ca7be73709324.x5051a4a3b273ffce;
		int[] x632f31cdeda76ff = xc41ca7be73709324.x632f31cdeda76ff9;
		NumberStyle[] x7e30db41abd34a = xc41ca7be73709324.x7e30db41abd34a71;
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		int num2 = 0;
		while (num < x5051a4a3b273ffce.Length)
		{
			stringBuilder.Append(x6d7a6575adf56fd3(x5051a4a3b273ffce[num++]));
			stringBuilder.Append(":");
			stringBuilder.Append(xca004f56614e2431.x754c3a5f03a2ce84(x632f31cdeda76ff[num2]));
			stringBuilder.Append(":");
			stringBuilder.Append(xca004f56614e2431.x754c3a5f03a2ce84((int)x7e30db41abd34a[num2]));
			stringBuilder.Append(":");
			if (num < x5051a4a3b273ffce.Length)
			{
				char c = x5051a4a3b273ffce[num];
				if (c > '\b')
				{
					stringBuilder.Append(c);
					num++;
				}
			}
			num2++;
		}
		return stringBuilder.ToString();
	}

	internal static string x6d7a6575adf56fd3(int xbcea506a33cf9111)
	{
		return $"%{xbcea506a33cf9111 + 1}";
	}

	internal static string xd3289958406a0272(int[] x0788cd5a9865fc16)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < x0788cd5a9865fc16.Length; i++)
		{
			stringBuilder.Append(xca004f56614e2431.x754c3a5f03a2ce84(x0788cd5a9865fc16[i]));
			stringBuilder.Append(',');
		}
		if (stringBuilder.Length > 0)
		{
			stringBuilder.Length--;
		}
		return stringBuilder.ToString();
	}

	internal static string x0d28bf60e577f9e5(byte[] xf9a0d04800d70471, int xd4f974c06ffa392b)
	{
		return x0d299f323d241756.x482624a13e9e9d98(xf9a0d04800d70471, xd4f974c06ffa392b, 4, x2e6b322d68dfff21: true);
	}

	internal static string x0d28bf60e577f9e5(int xbcea506a33cf9111)
	{
		return xca004f56614e2431.xaa4e6020773f88bc(xbcea506a33cf9111);
	}

	internal static string x0d28bf60e577f9e5(object xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 is int)
		{
			return xca004f56614e2431.xaa4e6020773f88bc((int)xbcea506a33cf9111);
		}
		return null;
	}

	internal static int x2a2d5f8dcb4bf0c9(string xbcea506a33cf9111)
	{
		return xca004f56614e2431.x4bbd62ec225a0240(xbcea506a33cf9111);
	}

	internal static int x5c612ff105e66e13(string xbcea506a33cf9111)
	{
		return xca004f56614e2431.xadcf75bfc0bf31e3(xbcea506a33cf9111);
	}

	internal static int xce5e5e71983ae08f(string xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111.Length == 8)
		{
			return x5c612ff105e66e13(xbcea506a33cf9111);
		}
		if (x0d299f323d241756.xff96b3c50e8ffc1f(xbcea506a33cf9111))
		{
			return (int)(xca004f56614e2431.x71505bb121b63b5e(xbcea506a33cf9111) & 0xFFFFFFFFu);
		}
		return x5c612ff105e66e13(xbcea506a33cf9111);
	}

	internal static void xa9aaee2edd3cd025(string x971e83bc97861294, byte[] xf9a0d04800d70471, int x10aaa7cdfa38f254)
	{
		for (int i = 0; i < x971e83bc97861294.Length; i += 2)
		{
			xf9a0d04800d70471[x10aaa7cdfa38f254++] = (byte)xca004f56614e2431.xadcf75bfc0bf31e3(x971e83bc97861294.Substring(i, 2));
		}
	}

	internal static void xe0cee8cc226d674a(string x971e83bc97861294, byte[] xf9a0d04800d70471, int x10aaa7cdfa38f254)
	{
		x10aaa7cdfa38f254 = x10aaa7cdfa38f254 + x971e83bc97861294.Length / 2 - 1;
		for (int i = 0; i < x971e83bc97861294.Length; i += 2)
		{
			xf9a0d04800d70471[x10aaa7cdfa38f254--] = (byte)xca004f56614e2431.xadcf75bfc0bf31e3(x971e83bc97861294.Substring(i, 2));
		}
	}

	internal static string xfb8d75f850ffd0e7(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		if (x6c50a99faab7d741.x7149c962c02931b3)
		{
			return "auto";
		}
		return xca004f56614e2431.xaa4e6020773f88bc(x6c50a99faab7d741.xb2c94956116ca10a()).Substring(2);
	}

	internal static x26d9ecb4bdf0456d x5e71f16a78faf353(string xbcea506a33cf9111)
	{
		xbcea506a33cf9111 = xbcea506a33cf9111.ToLower();
		if (xbcea506a33cf9111 == "auto")
		{
			return x26d9ecb4bdf0456d.x45260ad4b94166f2;
		}
		xbcea506a33cf9111 = xbcea506a33cf9111.Trim(xf20568e05633abc9);
		if (xacdda9cc6e3074ad(xbcea506a33cf9111))
		{
			return x6a5493c18121bf87(xbcea506a33cf9111);
		}
		return xe27aaa947ea63911.x4fc015c0cc57fa75(xbcea506a33cf9111);
	}

	private static x26d9ecb4bdf0456d x6a5493c18121bf87(string xbcea506a33cf9111)
	{
		int num = x5c612ff105e66e13(xbcea506a33cf9111);
		int r = (num & 0xFF0000) >> 16;
		int g = (num & 0xFF00) >> 8;
		int b = num & 0xFF;
		return new x26d9ecb4bdf0456d(r, g, b);
	}

	private static bool xacdda9cc6e3074ad(string xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111.Length != 6)
		{
			return false;
		}
		for (int i = 0; i < xbcea506a33cf9111.Length; i++)
		{
			if (!x0d299f323d241756.xb8f085ba3fb39f54(xbcea506a33cf9111[i]))
			{
				return false;
			}
		}
		return true;
	}

	internal static string xe60ec335a4cca083(int xe0b0c294d3f088b0)
	{
		int xbcea506a33cf = xe0b0c294d3f088b0 >> 16;
		int x37cf7043760b312e = xe0b0c294d3f088b0 % 65536;
		string arg = xca004f56614e2431.x754c3a5f03a2ce84(xbcea506a33cf);
		return $"{arg}.{xca004f56614e2431.xd2bd6588f73f7402(x37cf7043760b312e)}";
	}

	internal static int x059ac2aa14131725(string x272bc993a9d89cb6)
	{
		int result = 0;
		if (x0d299f323d241756.x5959bccb67bbf051(x272bc993a9d89cb6))
		{
			string[] array = x272bc993a9d89cb6.Split('.');
			int num = xca004f56614e2431.x59884ab46dd0d856(array[0]);
			int num2 = 0;
			if (array.Length > 1)
			{
				num2 = xca004f56614e2431.x59884ab46dd0d856(array[1]);
			}
			result = (num << 16) | num2;
		}
		return result;
	}

	internal static string x5f36f04871c53347(byte[] xbcea506a33cf9111)
	{
		return x8523dbdcd67276f2.x5b81632e5b71b64c(xbcea506a33cf9111, "\n");
	}

	internal static int xe46f9c7779fac076(string xeaf1b27180c0557b)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xeaf1b27180c0557b))
		{
			return int.MinValue;
		}
		int num = xeaf1b27180c0557b.Length - 1;
		while (num >= 0 && xeaf1b27180c0557b[num] >= '0' && xeaf1b27180c0557b[num] <= '9')
		{
			num--;
		}
		return xca004f56614e2431.x912616ee70b2d94d(xeaf1b27180c0557b.Substring(num + 1));
	}
}
