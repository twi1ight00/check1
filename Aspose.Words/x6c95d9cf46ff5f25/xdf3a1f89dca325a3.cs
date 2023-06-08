using System;
using System.Text;

namespace x6c95d9cf46ff5f25;

internal class xdf3a1f89dca325a3
{
	private const int x3cf8db7bf2981360 = 55296;

	private const int xf2fabf5904274c11 = 56319;

	private const int x608c9f64b7627979 = 56320;

	private const int x449041af2bb348b6 = 57343;

	private const int x7033c9438b57e360 = 65536;

	private const int x3e08b0e3bede3ac8 = 1114111;

	public static string x251dbcb3221739c5(int x0730d42ae0e1c701)
	{
		if (!xf3410f5d67f5b05a(x0730d42ae0e1c701))
		{
			throw new ArgumentOutOfRangeException("utf32Char");
		}
		if (x3a26b5f116985446(x0730d42ae0e1c701))
		{
			char c = (char)((x0730d42ae0e1c701 - 65536) / 1024 + 55296);
			char c2 = (char)((x0730d42ae0e1c701 - 65536) % 1024 + 56320);
			return new string(new char[2] { c, c2 });
		}
		return new string((char)x0730d42ae0e1c701, 1);
	}

	public static int xee6b5ee7b01be5bb(char x0dcae6b5fb853821, char x338923eb0e03656e)
	{
		if (!xdb64158ac3f729be(x0dcae6b5fb853821))
		{
			throw new ArgumentOutOfRangeException("leadSurrogate");
		}
		if (!x95d02dd984236015(x338923eb0e03656e))
		{
			throw new ArgumentOutOfRangeException("tailSurrogate");
		}
		return (x0dcae6b5fb853821 - 55296) * 1024 + (x338923eb0e03656e - 56320) + 65536;
	}

	public static int xee6b5ee7b01be5bb(string xe4115acdf4fbfccc, int x13d4cb8d1bd20347)
	{
		if (xe4115acdf4fbfccc == null)
		{
			throw new ArgumentNullException("s");
		}
		if (x13d4cb8d1bd20347 < 0 || x13d4cb8d1bd20347 >= xe4115acdf4fbfccc.Length)
		{
			throw new ArgumentOutOfRangeException("position");
		}
		if (!xbab69c51caae7f16(xe4115acdf4fbfccc[x13d4cb8d1bd20347]))
		{
			return xe4115acdf4fbfccc[x13d4cb8d1bd20347];
		}
		if (xe47befda53dc8577(xe4115acdf4fbfccc, x13d4cb8d1bd20347))
		{
			return xee6b5ee7b01be5bb(xe4115acdf4fbfccc[x13d4cb8d1bd20347], xe4115acdf4fbfccc[x13d4cb8d1bd20347 + 1]);
		}
		throw new ArgumentException("Characters at specified position doesn't form a valid surrogate pair.");
	}

	public static bool xe47befda53dc8577(string xe4115acdf4fbfccc, int x13d4cb8d1bd20347)
	{
		if (xe4115acdf4fbfccc == null)
		{
			throw new ArgumentNullException("s");
		}
		if (x13d4cb8d1bd20347 < 0 || x13d4cb8d1bd20347 >= xe4115acdf4fbfccc.Length)
		{
			throw new ArgumentOutOfRangeException("position");
		}
		if (x13d4cb8d1bd20347 == xe4115acdf4fbfccc.Length - 1)
		{
			return false;
		}
		if (xdb64158ac3f729be(xe4115acdf4fbfccc[x13d4cb8d1bd20347]))
		{
			return x95d02dd984236015(xe4115acdf4fbfccc[x13d4cb8d1bd20347 + 1]);
		}
		return false;
	}

	public static bool xf3410f5d67f5b05a(int x0730d42ae0e1c701)
	{
		if (x0730d42ae0e1c701 < 0 || x0730d42ae0e1c701 >= 55296)
		{
			if (x0730d42ae0e1c701 > 57343)
			{
				return x0730d42ae0e1c701 <= 1114111;
			}
			return false;
		}
		return true;
	}

	public static bool x3a26b5f116985446(int x0730d42ae0e1c701)
	{
		if (x0730d42ae0e1c701 >= 65536)
		{
			return x0730d42ae0e1c701 <= 1114111;
		}
		return false;
	}

	public static bool xbab69c51caae7f16(char x805cf26ce8317e72)
	{
		if (!xdb64158ac3f729be(x805cf26ce8317e72))
		{
			return x95d02dd984236015(x805cf26ce8317e72);
		}
		return true;
	}

	public static bool xdb64158ac3f729be(char x805cf26ce8317e72)
	{
		if (x805cf26ce8317e72 >= '\ud800')
		{
			return x805cf26ce8317e72 <= '\udbff';
		}
		return false;
	}

	public static bool x95d02dd984236015(char x805cf26ce8317e72)
	{
		if (x805cf26ce8317e72 >= '\udc00')
		{
			return x805cf26ce8317e72 <= '\udfff';
		}
		return false;
	}

	public static string x251dbcb3221739c5(int[] xf47480ba909e9ede)
	{
		if (xf47480ba909e9ede == null || xf47480ba909e9ede.Length < 1)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (int x0730d42ae0e1c in xf47480ba909e9ede)
		{
			stringBuilder.Append(x251dbcb3221739c5(x0730d42ae0e1c));
		}
		return stringBuilder.ToString();
	}

	public static int[] xee6b5ee7b01be5bb(string xb41faee6912a2313)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xb41faee6912a2313))
		{
			return new int[0];
		}
		xd8cce4761dc846ee xd8cce4761dc846ee2 = new xd8cce4761dc846ee();
		foreach (int item in new x115139807e6482f7(xb41faee6912a2313))
		{
			xd8cce4761dc846ee2.xd6b6ed77479ef68c(item);
		}
		return xd8cce4761dc846ee2.x543681a74a4a8026();
	}

	public static string x251dbcb3221739c5(int[] xf47480ba909e9ede, int x10aaa7cdfa38f254, int xca09b6c2b5b18485)
	{
		if (xf47480ba909e9ede == null || xf47480ba909e9ede.Length < 1)
		{
			return "";
		}
		if (x10aaa7cdfa38f254 < 0 || x10aaa7cdfa38f254 >= xf47480ba909e9ede.Length)
		{
			throw new ArgumentOutOfRangeException("start");
		}
		if (xca09b6c2b5b18485 < x10aaa7cdfa38f254 || xca09b6c2b5b18485 > xf47480ba909e9ede.Length)
		{
			throw new ArgumentOutOfRangeException("end");
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = x10aaa7cdfa38f254; i < xca09b6c2b5b18485; i++)
		{
			stringBuilder.Append(x251dbcb3221739c5(xf47480ba909e9ede[i]));
		}
		return stringBuilder.ToString();
	}
}
