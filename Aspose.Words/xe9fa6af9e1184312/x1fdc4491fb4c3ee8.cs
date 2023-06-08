using System.Collections;
using System.Text.RegularExpressions;
using Aspose.Words;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;
using x9b5b1a17490bd5f3;

namespace xe9fa6af9e1184312;

internal class x1fdc4491fb4c3ee8
{
	private readonly Hashtable x6081a14979402662 = new Hashtable();

	private readonly Stack xf8f23af472995af8 = new Stack();

	private readonly Stack x18c770831ef0bf38 = new Stack();

	private readonly x0cd0eeb5ca95cea9 xae0eb86e9881cc46;

	private readonly string x62ff3dabf0a6c41f;

	private readonly IWarningCallback xa056586c1f99e199;

	internal xb8e7e788f6d59708 xc9443bca5b0a56d8
	{
		get
		{
			if (xf8f23af472995af8.Count <= 0)
			{
				return null;
			}
			return (xb8e7e788f6d59708)xf8f23af472995af8.Peek();
		}
	}

	internal x594041ed884dbebb x8194fa1e2b16932f
	{
		get
		{
			if (x18c770831ef0bf38.Count <= 0)
			{
				return null;
			}
			return (x594041ed884dbebb)x18c770831ef0bf38.Peek();
		}
	}

	public x1fdc4491fb4c3ee8(string baseUri, x0cd0eeb5ca95cea9 resourceLoader, IWarningCallback warningCallback)
	{
		x62ff3dabf0a6c41f = baseUri;
		xae0eb86e9881cc46 = ((resourceLoader == null) ? new x0cd0eeb5ca95cea9() : resourceLoader);
		xa056586c1f99e199 = warningCallback;
		xffdeeab52bfac6bd(new xb8e7e788f6d59708());
	}

	internal void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x9f91de645a9fe01a, WarningSource.Unknown, xc2358fbac7da3d45));
		}
	}

	internal void x1fa9148f6731ff24(x4fdf549af9de6b97 xde860fba55c41d76, string xeaf1b27180c0557b)
	{
		xc9443bca5b0a56d8.xd6b6ed77479ef68c(xde860fba55c41d76);
		x957c0b58e06ffb07(xde860fba55c41d76, xeaf1b27180c0557b);
	}

	private void x957c0b58e06ffb07(x4fdf549af9de6b97 x1560a0b5003d54a5, string xeaf1b27180c0557b)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xeaf1b27180c0557b))
		{
			x6081a14979402662[xeaf1b27180c0557b] = x1560a0b5003d54a5;
		}
	}

	internal x4fdf549af9de6b97 x9ab4402f4f72ff94(string x585da4d9795fa783)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x585da4d9795fa783))
		{
			return null;
		}
		if (x585da4d9795fa783.StartsWith("url"))
		{
			Regex regex = new Regex("url\\(([^\\(\\)]+)\\)");
			Match match = regex.Match(x585da4d9795fa783);
			x585da4d9795fa783 = match.Groups[1].Value;
		}
		string key = x0d4d45882065c63e.x358b45b4ddbfa57c(x585da4d9795fa783);
		return (x4fdf549af9de6b97)x6081a14979402662[key];
	}

	internal void x9ef787a55e8ffc34(string x585da4d9795fa783)
	{
		x4fdf549af9de6b97 x4fdf549af9de6b = x9ab4402f4f72ff94(x585da4d9795fa783);
		if (x4fdf549af9de6b != null)
		{
			x1fa9148f6731ff24(x4fdf549af9de6b, null);
		}
	}

	internal void xffdeeab52bfac6bd(xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		xf8f23af472995af8.Push(x08ce8f4769eb3234);
		x594041ed884dbebb obj = ((x8194fa1e2b16932f == null) ? new x594041ed884dbebb(this) : x8194fa1e2b16932f.x8b61531c8ea35b85());
		x18c770831ef0bf38.Push(obj);
	}

	internal void xf5b0b9b6ff7ac462()
	{
		xf8f23af472995af8.Pop();
		x18c770831ef0bf38.Pop();
	}

	internal byte[] x184a537960bc4865(string x8e16834eb9deb839)
	{
		return xae0eb86e9881cc46.x184a537960bc4865(x62ff3dabf0a6c41f, x8e16834eb9deb839);
	}
}
