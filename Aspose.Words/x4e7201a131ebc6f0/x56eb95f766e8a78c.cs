using System;
using System.IO;
using System.Text;
using x6c95d9cf46ff5f25;

namespace x4e7201a131ebc6f0;

internal class x56eb95f766e8a78c
{
	internal static void xaf3fe0636f87a61e(Stream x0afafccb090df46c, string x337e217cb3ba0627, int x10aaa7cdfa38f254, int x961016a387451f05, string x1807bef890c9b567)
	{
		switch (x1807bef890c9b567)
		{
		case "quoted-printable":
			x30a36efd4976138c(x0afafccb090df46c, x337e217cb3ba0627, x10aaa7cdfa38f254, x961016a387451f05);
			break;
		case "base64":
			xabd317c9e1f583de(x0afafccb090df46c, x337e217cb3ba0627, x10aaa7cdfa38f254, x961016a387451f05);
			break;
		case "7bit":
		case "8bit":
		case "":
			x205467075c459be2(x0afafccb090df46c, x337e217cb3ba0627, x10aaa7cdfa38f254, x961016a387451f05);
			break;
		default:
			throw new InvalidOperationException("Unexpected transfer encoding.");
		}
	}

	internal static void x30a36efd4976138c(Stream x0afafccb090df46c, string x337e217cb3ba0627, int x10aaa7cdfa38f254, int x961016a387451f05)
	{
		int num = x10aaa7cdfa38f254;
		int num2 = x10aaa7cdfa38f254 + x961016a387451f05;
		while (num < num2)
		{
			char c = x337e217cb3ba0627[num];
			if (c != '=')
			{
				x0afafccb090df46c.WriteByte((byte)c);
				num++;
			}
			else
			{
				if (++num >= num2)
				{
					continue;
				}
				c = x337e217cb3ba0627[num];
				if (xaca86282f1134a00(c))
				{
					while (++num < num2 && xaca86282f1134a00(x337e217cb3ba0627[num]))
					{
					}
				}
				else if (++num < num2)
				{
					char xbc30138fc52cbe = x337e217cb3ba0627[num];
					x0afafccb090df46c.WriteByte((byte)(x0d299f323d241756.xe3ec68422266caf1(c) * 16 + x0d299f323d241756.xe3ec68422266caf1(xbc30138fc52cbe)));
					num++;
				}
			}
		}
	}

	internal static void xabd317c9e1f583de(Stream x0afafccb090df46c, string x337e217cb3ba0627, int x10aaa7cdfa38f254, int x961016a387451f05)
	{
		string s = x337e217cb3ba0627.Substring(x10aaa7cdfa38f254, x961016a387451f05);
		byte[] array = Convert.FromBase64String(s);
		x0afafccb090df46c.Write(array, 0, array.Length);
	}

	private static void x205467075c459be2(Stream x0afafccb090df46c, string x337e217cb3ba0627, int x10aaa7cdfa38f254, int x961016a387451f05)
	{
		int num = x10aaa7cdfa38f254;
		int num2 = x10aaa7cdfa38f254 + x961016a387451f05;
		while (num < num2)
		{
			x0afafccb090df46c.WriteByte((byte)x337e217cb3ba0627[num++]);
		}
	}

	private static bool xaca86282f1134a00(char xb867a42da3ae686d)
	{
		if (xb867a42da3ae686d != '\r')
		{
			return xb867a42da3ae686d == '\n';
		}
		return true;
	}

	internal static Encoding xba7d93913e2c1836(string x1ec8d3808cca2695)
	{
		Encoding result = null;
		if (x1ec8d3808cca2695.Length != 0)
		{
			try
			{
				result = Encoding.GetEncoding(x1ec8d3808cca2695);
			}
			catch (ArgumentException)
			{
			}
		}
		return result;
	}
}
