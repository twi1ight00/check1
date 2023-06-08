using Aspose.Words;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x7c4557e104065fc9;
using xbe73d5820f7f4ae3;
using xf989f31a236ff98c;

namespace xce0136f05681c5e9;

internal class xe98f79ab11a30ea7
{
	private readonly xe2ff3c3cd396cfd9 x18ddd758cd8495e3;

	private readonly DocumentBase xd1424e1a0bb4a72b;

	private readonly bool x44e08e1e3b512a35;

	private int x2e24dfe93fbd8f34;

	private x1eec46d494a92718 x87f9a89cb2e49e74;

	private Node x63697a664fc2cf25;

	private bool xb76dae958eba8b2b;

	internal xe98f79ab11a30ea7(DocumentBase document, bool exportLanguageInformation, xe2ff3c3cd396cfd9 htmlWriterCommon)
	{
		x18ddd758cd8495e3 = htmlWriterCommon;
		xd1424e1a0bb4a72b = document;
		x44e08e1e3b512a35 = exportLanguageInformation;
	}

	internal void xb63df339721c535a(Paragraph xefceefc9504671df, x1a78664fa10a3755 x9e5248b49f0df7e8)
	{
		xb63df339721c535a(xefceefc9504671df, x9e5248b49f0df7e8?.xcedf9c82728ad579 ?? xefceefc9504671df.x1a78664fa10a3755.xcedf9c82728ad579);
	}

	internal void xb63df339721c535a(Table x1ec770899c98a268)
	{
		xb63df339721c535a(x1ec770899c98a268, x1ec770899c98a268.FirstRow.xedb0eb766e25e0c9.xcedf9c82728ad579);
	}

	internal void xb63df339721c535a(Section x7468108b15101a6d)
	{
		xb63df339721c535a(x7468108b15101a6d, x7468108b15101a6d.xfc72d4c9b765cad7.xcedf9c82728ad579);
	}

	internal void xeded1061813a0ab1(Font x26094932cf7a9139)
	{
		int num = xfadbc42ac88b6911(x26094932cf7a9139);
		if (num != x2e24dfe93fbd8f34)
		{
			xa4f96e21f8e70152(num, x463bb7c715da7434: true);
		}
		if (x26094932cf7a9139.Bidi || x63697a664fc2cf25 != null || xb76dae958eba8b2b)
		{
			x26a6db151ba1ab3b(x26094932cf7a9139.Bidi, x63697a664fc2cf25 != null);
			xb76dae958eba8b2b = x26094932cf7a9139.Bidi && x63697a664fc2cf25 == null;
		}
	}

	internal void x83da4d952172728a()
	{
		x2e24dfe93fbd8f34 = 1033;
		Style style = xd1424e1a0bb4a72b.Styles[0];
		if (style != null)
		{
			x2e24dfe93fbd8f34 = xfadbc42ac88b6911(style.Font);
		}
		xa4f96e21f8e70152(x2e24dfe93fbd8f34, x463bb7c715da7434: false);
	}

	private void xb63df339721c535a(Node xda5bf54deb817e37, bool x4d21032b3ed37672)
	{
		if (!x495fdb45f3d92b70.xfd054898a6589135(x63697a664fc2cf25, xda5bf54deb817e37))
		{
			x63697a664fc2cf25 = (x4d21032b3ed37672 ? xda5bf54deb817e37 : null);
		}
		if (x495fdb45f3d92b70.xfd054898a6589135(x63697a664fc2cf25, xda5bf54deb817e37))
		{
			x18ddd758cd8495e3.xe1410f585439c7d4.x943f6be3acf634db("dir", x4d21032b3ed37672 ? "rtl" : "ltr");
		}
		xb76dae958eba8b2b = false;
		x87f9a89cb2e49e74 = x1eec46d494a92718.x236cb0a4295bc034;
	}

	private void x26a6db151ba1ab3b(bool x370968c2ea974ce4, bool x95b50d6ccd2774d1)
	{
		string arg = (x370968c2ea974ce4 ? "rtl" : "ltr");
		if (x370968c2ea974ce4 != x95b50d6ccd2774d1)
		{
			x18ddd758cd8495e3.xe1410f585439c7d4.xd52401bdf5aacef6($" dir=\"{arg}\" ");
		}
		if (x66e380552fbb6266(x87f9a89cb2e49e74, x370968c2ea974ce4))
		{
			x18ddd758cd8495e3.xe1410f585439c7d4.xd52401bdf5aacef6($"><span dir=\"{arg}\"></span");
		}
		x87f9a89cb2e49e74 = ((!x370968c2ea974ce4) ? x1eec46d494a92718.x12642456c7bf0815 : x1eec46d494a92718.xbbad6bbe73c6b1dc);
	}

	private static bool x66e380552fbb6266(x1eec46d494a92718 x1aaf2701f60885f0, bool x800acdf561096bc4)
	{
		if (x1aaf2701f60885f0 != 0)
		{
			return x1aaf2701f60885f0 == x1eec46d494a92718.xbbad6bbe73c6b1dc != x800acdf561096bc4;
		}
		return false;
	}

	private static int xfadbc42ac88b6911(Font x26094932cf7a9139)
	{
		if (x26094932cf7a9139.Bidi)
		{
			return x26094932cf7a9139.LocaleIdBi;
		}
		if (x26094932cf7a9139.LocaleIdFarEast == 1024)
		{
			return x26094932cf7a9139.LocaleId;
		}
		return x26094932cf7a9139.LocaleIdFarEast;
	}

	private void xa4f96e21f8e70152(int x4e8144106c5bf176, bool x463bb7c715da7434)
	{
		if (!x44e08e1e3b512a35)
		{
			return;
		}
		string text = x0eb9a864413f34de.xef1c76b0fb2ec874(x4e8144106c5bf176);
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			if (x463bb7c715da7434)
			{
				x18ddd758cd8495e3.xe1410f585439c7d4.xd52401bdf5aacef6(" lang=\"" + text + "\" ");
			}
			else
			{
				x18ddd758cd8495e3.xe1410f585439c7d4.x943f6be3acf634db("lang", text);
			}
		}
	}
}
