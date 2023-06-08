using System;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using xf9a9481c3f63a419;

namespace x2a6f63b6650e76c4;

internal class xa4690fb61715fc9b
{
	private const char x60a71e2d437b8603 = '*';

	private const char x44558177eb10a1aa = '?';

	private const string x2d13bbc33068b1ec = ".*";

	private const char xd01a03fb5934ce2a = '.';

	private const string x661cef954b07f4ef = "\\u";

	private const string x25e60e3df4b550cf = "\\A";

	private const string x41797f1bc3a2a360 = "\\z";

	private Field x54c413cc80cb99d5;

	private x6f82c326b827643c x8203f6652120ad8a;

	private bool x0eacf27b6afa041a
	{
		get
		{
			switch (x8203f6652120ad8a.x558295ab1f6adc48)
			{
			case "=":
			case "<>":
			case ">":
			case "<":
			case ">=":
			case "<=":
				return true;
			default:
				return false;
			}
		}
	}

	private bool xd70945b037eb0fc9 => x8203f6652120ad8a.x558295ab1f6adc48 == "=";

	private bool xc31fc18ad4d5d85d => x8203f6652120ad8a.x558295ab1f6adc48 == "<>";

	internal static x82e26649b09596bd x308cb2f3483de2a6(Field xe01ae93d9fe5a880, x6f82c326b827643c xbf5efe8743edba7b)
	{
		xa4690fb61715fc9b xa4690fb61715fc9b2 = new xa4690fb61715fc9b();
		return xa4690fb61715fc9b2.x335c6a74b612cfe6(xe01ae93d9fe5a880, xbf5efe8743edba7b);
	}

	internal x82e26649b09596bd x335c6a74b612cfe6(Field xe01ae93d9fe5a880, x6f82c326b827643c xbf5efe8743edba7b)
	{
		x54c413cc80cb99d5 = xe01ae93d9fe5a880;
		x8203f6652120ad8a = xbf5efe8743edba7b;
		if (xbf5efe8743edba7b.x600b4f5dab686c05 == null)
		{
			return new xf7d966ea5d1701b6("Error! Missing test condition.");
		}
		if (xbf5efe8743edba7b.x558295ab1f6adc48 == null)
		{
			return new x21c92e6904024299(value: true);
		}
		if (!x0eacf27b6afa041a)
		{
			return new xf7d966ea5d1701b6("Error! Unknown op code for conditional.");
		}
		if (xbf5efe8743edba7b.x61af7ad436e781d3 == null)
		{
			return new xf7d966ea5d1701b6("Error! Missing second part of test condition.");
		}
		if (xb7dbd7bb3ed97d5b.x06768d79f7751c4d(xbf5efe8743edba7b.x600b4f5dab686c05))
		{
			return new x21c92e6904024299(xa466b137a8c4c463(xbf5efe8743edba7b.x600b4f5dab686c05, xbf5efe8743edba7b.x61af7ad436e781d3));
		}
		x82e26649b09596bd x82e26649b09596bd2 = x6d929209cd800011.x308cb2f3483de2a6(x54c413cc80cb99d5, xb7dbd7bb3ed97d5b.x8ee3644420992dc6(xbf5efe8743edba7b.x600b4f5dab686c05));
		x82e26649b09596bd x82e26649b09596bd3 = x6d929209cd800011.x308cb2f3483de2a6(x54c413cc80cb99d5, xb7dbd7bb3ed97d5b.x8ee3644420992dc6(xbf5efe8743edba7b.x61af7ad436e781d3));
		if (x82e26649b09596bd2.x6b54bdfbc4586f55 || x82e26649b09596bd3.x6b54bdfbc4586f55)
		{
			return new x21c92e6904024299(xa466b137a8c4c463(xbf5efe8743edba7b.x600b4f5dab686c05, xbf5efe8743edba7b.x61af7ad436e781d3));
		}
		return new x21c92e6904024299(x4626862f9f728036(x82e26649b09596bd2.x7ce859afc0c75642, x82e26649b09596bd3.x7ce859afc0c75642));
	}

	private bool xa466b137a8c4c463(string x804f9f766c219266, string x998490d2ae7d4060)
	{
		x804f9f766c219266 = xb7dbd7bb3ed97d5b.x8ee3644420992dc6(x804f9f766c219266);
		x998490d2ae7d4060 = xb7dbd7bb3ed97d5b.x8ee3644420992dc6(x998490d2ae7d4060);
		bool flag = xd70945b037eb0fc9 || xc31fc18ad4d5d85d;
		bool flag2 = x998490d2ae7d4060.IndexOf('?') != -1 || x998490d2ae7d4060.IndexOf('*') != -1;
		if (!flag || !flag2)
		{
			return x4626862f9f728036(x27cd5f9641d9eb15.x33ea5871b3bcc794(x804f9f766c219266, x998490d2ae7d4060), 0.0);
		}
		Regex regex = new Regex(x06febef121e7f53c(x998490d2ae7d4060));
		return regex.IsMatch(x804f9f766c219266) == xd70945b037eb0fc9;
	}

	private static string x06febef121e7f53c(string x9a1e53c2e316b6d2)
	{
		StringBuilder stringBuilder = new StringBuilder("\\A");
		bool flag = false;
		foreach (char c in x9a1e53c2e316b6d2)
		{
			switch (c)
			{
			case '*':
				stringBuilder.Append(".*");
				flag = true;
				break;
			case '?':
				stringBuilder.Append('.');
				break;
			default:
				stringBuilder.Append("\\u");
				stringBuilder.Append(xca004f56614e2431.x7c1a0f9da8274fe8(c));
				break;
			}
			if (flag)
			{
				break;
			}
		}
		stringBuilder.Append("\\z");
		return stringBuilder.ToString();
	}

	private bool x4626862f9f728036(double x804f9f766c219266, double x998490d2ae7d4060)
	{
		return x8203f6652120ad8a.x558295ab1f6adc48 switch
		{
			"=" => x804f9f766c219266 == x998490d2ae7d4060, 
			"<>" => x804f9f766c219266 != x998490d2ae7d4060, 
			">" => x804f9f766c219266 > x998490d2ae7d4060, 
			"<" => x804f9f766c219266 < x998490d2ae7d4060, 
			">=" => x804f9f766c219266 >= x998490d2ae7d4060, 
			"<=" => x804f9f766c219266 <= x998490d2ae7d4060, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}
}
