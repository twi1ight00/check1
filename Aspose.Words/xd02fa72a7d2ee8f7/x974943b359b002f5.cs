using System.IO;
using xb92b7270f78a4e8d;
using xcf014befd8b52c3b;

namespace xd02fa72a7d2ee8f7;

internal class x974943b359b002f5 : x7eeece7aa20be881
{
	private const char xc735b74031a6b876 = '/';

	private readonly xd8c3135513b9115b x435daba16a6b8f42;

	internal x974943b359b002f5(xd8c3135513b9115b fs)
	{
		x435daba16a6b8f42 = fs;
	}

	public Stream x79f7fd8368ae8a71(x465c7a263669f01c xa860e35844c20ac7)
	{
		string text = xa860e35844c20ac7.x759aa16c2016a289.Substring(1);
		xe7be411416cfcd54 xe7be411416cfcd = x435daba16a6b8f42.x29e7ace4c90f74cd;
		while (text.IndexOf('/') > 0)
		{
			int num = text.IndexOf('/');
			xe7be411416cfcd = xe7be411416cfcd.x03c5de1b1357f136(text.Substring(0, num));
			text = text.Substring(num + 1);
		}
		return xe7be411416cfcd.xb3b34047219bdc2a(text);
	}
}
