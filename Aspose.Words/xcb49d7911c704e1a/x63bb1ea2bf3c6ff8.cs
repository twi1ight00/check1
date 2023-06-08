using System;
using x4f4df92b75ba3b67;

namespace xcb49d7911c704e1a;

internal class x63bb1ea2bf3c6ff8 : x51cac7d4fb6e03c1
{
	private readonly string x85672ef2a158d360;

	private readonly bool x7725c22f8fbf9eae;

	internal override string x88f840ce39508ae1 => "URI";

	internal x63bb1ea2bf3c6ff8(string uri)
		: this(uri, isMap: false)
	{
	}

	internal x63bb1ea2bf3c6ff8(string uri, bool isMap)
	{
		if (uri == null)
		{
			throw new ArgumentNullException("uri");
		}
		x85672ef2a158d360 = x962a25a7f6b41411(uri);
		x7725c22f8fbf9eae = isMap;
	}

	internal override void x429b8154f413e67d(xcd769e39c0788209 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.xe8d35135edabe74c("/URI", x85672ef2a158d360, xf9aaf5b23109516c: true);
		if (x7725c22f8fbf9eae)
		{
			xbdfb620b7167944b.xa4dc0ad8886e23a2("/IsMap", xbcea506a33cf9111: true);
		}
	}

	private static string x962a25a7f6b41411(string xbda579af315c6893)
	{
		try
		{
			Uri uri = new Uri(xbda579af315c6893);
			return uri.AbsoluteUri;
		}
		catch
		{
			return xbda579af315c6893;
		}
	}
}
