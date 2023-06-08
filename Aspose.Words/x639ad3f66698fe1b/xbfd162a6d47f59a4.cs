using System;
using System.Collections;
using Aspose.Words.Tables;
using x6c95d9cf46ff5f25;

namespace x639ad3f66698fe1b;

internal class xbfd162a6d47f59a4
{
	private static readonly xbccd339d06be2e61[] x525bf081c2c9aaf5;

	private x43845b10d17efb74 xbe39036341e55b02;

	private readonly bool x425778a970afbc99;

	private bool x2cdd33b12d918549;

	private static readonly Hashtable x1c55a2725674cbd7;

	private static readonly char[] x307f9fd06a46baed;

	internal x43845b10d17efb74 x42f4c234c9358072
	{
		get
		{
			return xbe39036341e55b02;
		}
		set
		{
			xbe39036341e55b02 = value;
		}
	}

	internal xbfd162a6d47f59a4(x43845b10d17efb74 target, bool isExportPrettyFormat)
	{
		xbe39036341e55b02 = target;
		x425778a970afbc99 = isExportPrettyFormat;
	}

	internal void x25d0efbd7848eeb3()
	{
		if (x425778a970afbc99)
		{
			xbe39036341e55b02.x6210059f049f0d48("\r\n");
		}
	}

	internal void x32378e1a3c5fdbcd()
	{
		if (x425778a970afbc99)
		{
			xbe39036341e55b02.x6210059f049f0d48("\r\n\r\n");
		}
	}

	internal void xe7b920de107da0c7()
	{
		xbe39036341e55b02.x6210059f049f0d48(' ');
		x2cdd33b12d918549 = false;
	}

	internal void x80fb22e7844d1324()
	{
		xbe39036341e55b02.x6210059f049f0d48(';');
		x2cdd33b12d918549 = false;
	}

	internal void xa07aa514e9082b3a()
	{
		xbe39036341e55b02.x6210059f049f0d48('{');
		x2cdd33b12d918549 = false;
	}

	internal void x4ecc66ceff7a75c0()
	{
		xbe39036341e55b02.x6210059f049f0d48('}');
		x2cdd33b12d918549 = false;
	}

	internal void x4d14ee33f46b5913(string x1c4259f170c30c43)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(x1c4259f170c30c43))
		{
			xbe39036341e55b02.x6210059f049f0d48(x1c4259f170c30c43);
			x2cdd33b12d918549 = true;
		}
	}

	internal void x4d14ee33f46b5913(string x1c4259f170c30c43, int xbcea506a33cf9111)
	{
		xbe39036341e55b02.x6210059f049f0d48(x1c4259f170c30c43);
		x6210059f049f0d48(xbcea506a33cf9111);
		x2cdd33b12d918549 = true;
	}

	internal void x4d14ee33f46b5913(string x1c4259f170c30c43, int xbcea506a33cf9111, int xc6e85c82d0d89508)
	{
		x4d14ee33f46b5913(x1c4259f170c30c43, xbcea506a33cf9111, xc6e85c82d0d89508, x5d8c4035db711113: false);
	}

	internal void x4d14ee33f46b5913(string x1c4259f170c30c43, int xbcea506a33cf9111, int xc6e85c82d0d89508, bool x5d8c4035db711113)
	{
		if (xbcea506a33cf9111 != xc6e85c82d0d89508 && (!x5d8c4035db711113 || xbcea506a33cf9111 != 0))
		{
			x4d14ee33f46b5913(x1c4259f170c30c43, xbcea506a33cf9111);
		}
	}

	internal void x4d14ee33f46b5913(string x1c4259f170c30c43, string xbcea506a33cf9111)
	{
		xbe39036341e55b02.x6210059f049f0d48(x1c4259f170c30c43);
		xbe39036341e55b02.x6210059f049f0d48(xbcea506a33cf9111);
		x2cdd33b12d918549 = true;
	}

	internal void xcdbc678d36159c69(string x8256d15cdc66739e, string xa29b2e5f9e99b1a0, PreferredWidth x961016a387451f05)
	{
		if (!x961016a387451f05.xa72bf798a679c0aa)
		{
			x4d14ee33f46b5913(x8256d15cdc66739e, x961016a387451f05.x7680505e84ce0354);
		}
		x4d14ee33f46b5913(xa29b2e5f9e99b1a0, Convert.ToInt32(x961016a387451f05.Type));
	}

	internal void xb8aea59edd4060ce(string x1c4259f170c30c43, bool xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111)
		{
			x4d14ee33f46b5913(x1c4259f170c30c43);
		}
	}

	internal void xaf432784cda9acfa(string x1c4259f170c30c43, bool xbcea506a33cf9111)
	{
		xbe39036341e55b02.x6210059f049f0d48(x1c4259f170c30c43);
		if (!xbcea506a33cf9111)
		{
			xbe39036341e55b02.x6210059f049f0d48('0');
		}
		x2cdd33b12d918549 = true;
	}

	internal void x5fdd0595d40cfe6d(string x1c4259f170c30c43, bool xbcea506a33cf9111)
	{
		x4d14ee33f46b5913(x1c4259f170c30c43, xbcea506a33cf9111 ? "1" : "0");
	}

	internal void xee60bff2900a72f2(string x1c4259f170c30c43)
	{
		xa07aa514e9082b3a();
		x4d14ee33f46b5913(x1c4259f170c30c43);
	}

	internal void xc8a13a52db0580ae()
	{
		x4ecc66ceff7a75c0();
	}

	internal void xf55384516c165731(string x1c4259f170c30c43, string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			xee60bff2900a72f2(x1c4259f170c30c43);
			x50f5dc167b3269a7(xbcea506a33cf9111);
			xc8a13a52db0580ae();
		}
	}

	internal void xf55384516c165731(string x1c4259f170c30c43, int xbcea506a33cf9111)
	{
		xee60bff2900a72f2(x1c4259f170c30c43);
		xe7b920de107da0c7();
		x6210059f049f0d48(xbcea506a33cf9111);
		xc8a13a52db0580ae();
	}

	internal void x65e60a21b3a69631(string x1c4259f170c30c43, string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			xee60bff2900a72f2(x1c4259f170c30c43);
			x50f5dc167b3269a7(xbcea506a33cf9111);
			x80fb22e7844d1324();
			xc8a13a52db0580ae();
		}
	}

	internal void x6210059f049f0d48(int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == 0)
		{
			xbe39036341e55b02.x6210059f049f0d48('0');
			return;
		}
		if (xbcea506a33cf9111 == int.MinValue)
		{
			xbe39036341e55b02.x6210059f049f0d48("-2147483648");
			return;
		}
		if (xbcea506a33cf9111 < 0)
		{
			xbe39036341e55b02.x6210059f049f0d48('-');
			xbcea506a33cf9111 = -xbcea506a33cf9111;
		}
		x6ff7c65ed4805c27(xbcea506a33cf9111);
	}

	private void x6ff7c65ed4805c27(int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != 0)
		{
			x6ff7c65ed4805c27(xbcea506a33cf9111 / 10);
			xbe39036341e55b02.x6210059f049f0d48((char)(48 + xbcea506a33cf9111 % 10));
		}
	}

	internal void x6210059f049f0d48(string xbcea506a33cf9111)
	{
		xe0c2f6926be99852();
		xbe39036341e55b02.x6210059f049f0d48(xbcea506a33cf9111);
	}

	internal void x50f5dc167b3269a7(string xb41faee6912a2313)
	{
		xe0c2f6926be99852();
		foreach (char c in xb41faee6912a2313)
		{
			xbccd339d06be2e61 xbccd339d06be2e62 = null;
			if (!char.IsLetterOrDigit(c))
			{
				xbccd339d06be2e62 = x897399da4ef8f54a(c);
			}
			if (xbccd339d06be2e62 != null)
			{
				x6210059f049f0d48(xbccd339d06be2e62.x5896ed36f2cf9162);
				if (xbccd339d06be2e62.xd2951b54633c1292)
				{
					xe7b920de107da0c7();
				}
			}
			else
			{
				x53aca8e5315885a2(c);
			}
		}
	}

	private void x53aca8e5315885a2(char x3c4da2980d043c95)
	{
		xe0c2f6926be99852();
		if (x3c4da2980d043c95 < ' ')
		{
			xae8ee99c2d2310b7(x3c4da2980d043c95);
			return;
		}
		if (x3c4da2980d043c95 < '\u0080')
		{
			xbe39036341e55b02.x6210059f049f0d48(x3c4da2980d043c95);
			return;
		}
		if (x3c4da2980d043c95 < 'Ā')
		{
			xae8ee99c2d2310b7(x3c4da2980d043c95);
			return;
		}
		x4d14ee33f46b5913("\\u", (short)x3c4da2980d043c95);
		xe7b920de107da0c7();
	}

	internal void xae8ee99c2d2310b7(char x3c4da2980d043c95)
	{
		xe0c2f6926be99852();
		xbe39036341e55b02.x6210059f049f0d48("\\'");
		xdbcb927f00cc0ee3((byte)x3c4da2980d043c95);
	}

	internal void xf7f536bd531211e3(byte[] xbcea506a33cf9111)
	{
		xe0c2f6926be99852();
		for (int i = 0; i < xbcea506a33cf9111.Length; i++)
		{
			xdbcb927f00cc0ee3(xbcea506a33cf9111[i]);
		}
	}

	internal void xfb9a91e8308b9cbc(short xbcea506a33cf9111)
	{
		xe0c2f6926be99852();
		xdbcb927f00cc0ee3((byte)((uint)xbcea506a33cf9111 & 0xFFu));
		xdbcb927f00cc0ee3((byte)((uint)(xbcea506a33cf9111 >> 8) & 0xFFu));
	}

	internal void xb6c076f287274764(int xbcea506a33cf9111)
	{
		xe0c2f6926be99852();
		xdbcb927f00cc0ee3((byte)((uint)xbcea506a33cf9111 & 0xFFu));
		xdbcb927f00cc0ee3((byte)((uint)(xbcea506a33cf9111 >> 8) & 0xFFu));
		xdbcb927f00cc0ee3((byte)((uint)(xbcea506a33cf9111 >> 16) & 0xFFu));
		xdbcb927f00cc0ee3((byte)((uint)(xbcea506a33cf9111 >> 24) & 0xFFu));
	}

	internal void x94d9025f53df9132(string xbcea506a33cf9111)
	{
		xe0c2f6926be99852();
		for (int i = 0; i < xbcea506a33cf9111.Length; i++)
		{
			xdbcb927f00cc0ee3((byte)xbcea506a33cf9111[i]);
		}
	}

	internal void xdbcb927f00cc0ee3(byte xbcea506a33cf9111)
	{
		xbe39036341e55b02.x6210059f049f0d48(x307f9fd06a46baed[(xbcea506a33cf9111 >> 4) & 0xF]);
		xbe39036341e55b02.x6210059f049f0d48(x307f9fd06a46baed[xbcea506a33cf9111 & 0xF]);
	}

	private void xe0c2f6926be99852()
	{
		if (x2cdd33b12d918549)
		{
			xe7b920de107da0c7();
			x2cdd33b12d918549 = false;
		}
	}

	internal void xbb7550bbb62a218c()
	{
		xbe39036341e55b02.xbb7550bbb62a218c();
	}

	private static xbccd339d06be2e61 x897399da4ef8f54a(char x3c4da2980d043c95)
	{
		return (xbccd339d06be2e61)x1c55a2725674cbd7[x3c4da2980d043c95];
	}

	static xbfd162a6d47f59a4()
	{
		x525bf081c2c9aaf5 = new xbccd339d06be2e61[16]
		{
			new xbccd339d06be2e61('\\', "\\\\", isSpace: false),
			new xbccd339d06be2e61('{', "\\{", isSpace: false),
			new xbccd339d06be2e61('}', "\\}", isSpace: false),
			new xbccd339d06be2e61('\v', "\\line", isSpace: true),
			new xbccd339d06be2e61('\u000e', "\\column", isSpace: true),
			new xbccd339d06be2e61('\f', "\\page", isSpace: true),
			new xbccd339d06be2e61('\t', "\\tab", isSpace: true),
			new xbccd339d06be2e61('\u2005', "\\qmspace", isSpace: true),
			new xbccd339d06be2e61('\u00a0', "\\~", isSpace: false),
			new xbccd339d06be2e61('\u001f', "\\-", isSpace: false),
			new xbccd339d06be2e61('\u001e', "\\_", isSpace: false),
			new xbccd339d06be2e61('\u0005', "\\chatn", isSpace: true),
			new xbccd339d06be2e61('\u0002', "\\chftn", isSpace: true),
			new xbccd339d06be2e61('\u0003', "\\chftnsep", isSpace: true),
			new xbccd339d06be2e61('\u0004', "\\chftnsepc", isSpace: true),
			new xbccd339d06be2e61('\0', "\\chpgn", isSpace: true)
		};
		x1c55a2725674cbd7 = new Hashtable();
		x307f9fd06a46baed = new char[16]
		{
			'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
			'a', 'b', 'c', 'd', 'e', 'f'
		};
		xbccd339d06be2e61[] array = x525bf081c2c9aaf5;
		foreach (xbccd339d06be2e61 xbccd339d06be2e62 in array)
		{
			x1c55a2725674cbd7.Add(xbccd339d06be2e62.xfb1fc02db7c42694, xbccd339d06be2e62);
		}
	}
}
