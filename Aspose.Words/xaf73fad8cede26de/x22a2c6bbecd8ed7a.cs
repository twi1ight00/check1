using System;
using System.Collections;
using System.Text;
using Aspose;
using x38a89dee67fc7a16;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;

namespace xaf73fad8cede26de;

internal abstract class x22a2c6bbecd8ed7a
{
	private int x14923784db527ac5;

	private int xb4a8e85ee3a35770;

	private readonly StringBuilder x2beaf5e0f471814f = new StringBuilder();

	private readonly string xa2fff74252bae51d;

	private readonly Hashtable x3e7196286d02fd90 = new Hashtable();

	private readonly Hashtable x5d167f1730caab0b = new Hashtable();

	private readonly xd345c73dd1b16b74 xc0d087858ac2d6fc = new xd345c73dd1b16b74();

	private readonly Hashtable x1c65207a89e0cd8e = new Hashtable();

	private readonly Hashtable x6d202cde29b81c9c = new Hashtable();

	private xfaf91ffd88d78c15 x730a3c5f4afd73ef = new xfaf91ffd88d78c15();

	private x54b98d0096d7251a xa056586c1f99e199;

	private x924900eaa00682cf xe3fe1c34d837bdbf;

	internal xfaf91ffd88d78c15 xb444c09fa044bbca
	{
		get
		{
			return x730a3c5f4afd73ef;
		}
		set
		{
			x730a3c5f4afd73ef = value;
		}
	}

	internal xd345c73dd1b16b74 x39ca55b691f96321 => xc0d087858ac2d6fc;

	internal x924900eaa00682cf x868ce3362de17d74 => xe3fe1c34d837bdbf;

	protected Hashtable xb3bbeebb44588c3a => x3e7196286d02fd90;

	protected x22a2c6bbecd8ed7a(string resourcesFolderAlias, x54b98d0096d7251a warningCallback)
	{
		if (warningCallback == null)
		{
			throw new ArgumentNullException("warningCallback");
		}
		xa2fff74252bae51d = resourcesFolderAlias;
		xa056586c1f99e199 = warningCallback;
		xe3fe1c34d837bdbf = new x924900eaa00682cf(100, warningCallback, x3959df40367ac8a3.x64a7e1d48dfb2e43);
	}

	internal virtual string x68949e659a0029db(x6b1a899052c71a60 x26094932cf7a9139)
	{
		return x7895765729585fbf(x26094932cf7a9139);
	}

	internal virtual xfc4b33756f599219 xa9557f69810d0afe(byte[] x43e181e083db6cdf, x02df97c06afacbf3 x5edc4e0499c937b4)
	{
		x43e181e083db6cdf = xbd6dc546ba542cd8(x43e181e083db6cdf);
		int num = x02df97c06afacbf3.x1c3a4a07dc224a14(x43e181e083db6cdf, x5edc4e0499c937b4);
		xfc4b33756f599219 xfc4b33756f599220 = (xfc4b33756f599219)x3e7196286d02fd90[num];
		if (xfc4b33756f599220 == null)
		{
			x43e181e083db6cdf = xe3fe1c34d837bdbf.xe323925c2800577d(x43e181e083db6cdf, x5edc4e0499c937b4);
			xfc4b33756f599220 = new xfc4b33756f599219(x1fb0e604ffb821ce(x43e181e083db6cdf), xdd1b8f14cc8ba86d.x16a7fb03c627ebfb(x43e181e083db6cdf), x43e181e083db6cdf);
			x3e7196286d02fd90[num] = xfc4b33756f599220;
		}
		return xfc4b33756f599220;
	}

	[JavaThrows(true)]
	internal virtual void xa04e23b676ea0cc9()
	{
	}

	internal string x94f739530d38cc0a(string x65b774b94d53e416)
	{
		string text = (string)x6d202cde29b81c9c[x65b774b94d53e416];
		if (text != null)
		{
			return text;
		}
		text = $"bookmark_{x14923784db527ac5++}";
		x6d202cde29b81c9c[x65b774b94d53e416] = text;
		return text;
	}

	internal string x312d56bccab33f07(x6b1a899052c71a60 x26094932cf7a9139, string xb41faee6912a2313)
	{
		xcd986872cf3bcf68 xcd986872cf3bcf = x5fa376febd884803(x26094932cf7a9139);
		x2beaf5e0f471814f.Length = 0;
		foreach (int item in new x115139807e6482f7(xb41faee6912a2313))
		{
			if (xcd986872cf3bcf.x3452aa488cc9006d(item) >= 0)
			{
				x2beaf5e0f471814f.Append(xdf3a1f89dca325a3.x251dbcb3221739c5(item));
			}
		}
		return x2beaf5e0f471814f.ToString();
	}

	internal string x1a95937351d48673(x6b1a899052c71a60 x26094932cf7a9139, string xb41faee6912a2313)
	{
		xcd986872cf3bcf68 xcd986872cf3bcf = x5fa376febd884803(x26094932cf7a9139);
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		foreach (int item in new x115139807e6482f7(xb41faee6912a2313))
		{
			if (xdf3a1f89dca325a3.x3a26b5f116985446(item))
			{
				stringBuilder.AppendFormat("(2:1){0}", xcd986872cf3bcf.x3452aa488cc9006d(item));
				flag = true;
			}
			stringBuilder.Append(";");
		}
		if (stringBuilder.Length > 0)
		{
			stringBuilder.Length--;
		}
		if (!flag)
		{
			return "";
		}
		return stringBuilder.ToString();
	}

	internal void xbbf9a1ead81dd3a1(x6d058fdf61831c39 x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		xa056586c1f99e199.xbbf9a1ead81dd3a1(x9f91de645a9fe01a, x3959df40367ac8a3.x64a7e1d48dfb2e43, xc2358fbac7da3d45);
	}

	private byte[] xbd6dc546ba542cd8(byte[] x43e181e083db6cdf)
	{
		int hashCode = x43e181e083db6cdf.GetHashCode();
		byte[] array = (byte[])x5d167f1730caab0b[hashCode];
		if (array == null)
		{
			array = xe3fe1c34d837bdbf.x601e9a2243ca6720(x43e181e083db6cdf);
			x5d167f1730caab0b[hashCode] = array;
		}
		return array;
	}

	private xcd986872cf3bcf68 x5fa376febd884803(x6b1a899052c71a60 x26094932cf7a9139)
	{
		string key = x7895765729585fbf(x26094932cf7a9139);
		xcd986872cf3bcf68 xcd986872cf3bcf = (xcd986872cf3bcf68)xc0d087858ac2d6fc[key];
		if (xcd986872cf3bcf == null)
		{
			xcd986872cf3bcf = x26094932cf7a9139.x78789688b9fe78d2(x4867e759695b4319: false);
			xc0d087858ac2d6fc[key] = xcd986872cf3bcf;
		}
		return xcd986872cf3bcf;
	}

	private string x1fb0e604ffb821ce(byte[] x43e181e083db6cdf)
	{
		xfe2ff3c162b47c70 x4e17f25eeff90cf = xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(x43e181e083db6cdf);
		string xafe2f3653ee64ebc = $"image{x6bdb5f9a7aff5750()}.{xb9015fe823e7e228.xac88cb4f794761a9(x4e17f25eeff90cf)}";
		return x7ae9bc7c84132e22(xafe2f3653ee64ebc);
	}

	private string x7895765729585fbf(x6b1a899052c71a60 x26094932cf7a9139)
	{
		string text = (string)x1c65207a89e0cd8e[x26094932cf7a9139.x6b73aa01aa019d3a];
		if (text == null)
		{
			string arg = xa19c1513d8b80a8b.xdf7c5a607de91fb9(x26094932cf7a9139.x6054c4379c01a50d, x26094932cf7a9139.xfe2178c1f916f36c).ToString("D");
			text = x7ae9bc7c84132e22(string.Format("{0}.{1}", arg, "odttf"));
			x1c65207a89e0cd8e.Add(x26094932cf7a9139.x6b73aa01aa019d3a, text);
		}
		return text;
	}

	private string x7ae9bc7c84132e22(string xafe2f3653ee64ebc)
	{
		return x0d4d45882065c63e.xda76dc634eb9b4f6(xa2fff74252bae51d, xafe2f3653ee64ebc);
	}

	private int x6bdb5f9a7aff5750()
	{
		return ++xb4a8e85ee3a35770;
	}
}
