using System.Collections;
using System.IO;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x7c4557e104065fc9;

namespace x611adfb9b9d21a97;

internal class xbcc7e93175c9b621 : xb00f4ba8788bbec8
{
	private readonly ArrayList xcb24734d87e68ca7;

	private string xae806a2b5be362a1;

	internal xbcc7e93175c9b621(string documentBaseName, x8556eed81191af11 saveInfo, ArrayList navigationPoints)
		: base(xb00f4ba8788bbec8.xc40d5fe84864cc92(documentBaseName, x6c20b1df8047763a: false), documentBaseName, saveInfo)
	{
		xcb24734d87e68ca7 = navigationPoints;
	}

	internal void x95d1f647e5465823()
	{
		base.x5222f4285e37d66b.WriteStartDocument();
		base.x5222f4285e37d66b.WriteDocType("ncx", "-//NISO//DTD ncx 2005-1//EN", "http://www.daisy.org/z3986/2005/ncx-2005-1.dtd", null);
		x2307058321cdb62f("ncx");
		xff520a0047c27122("xmlns", "http://www.daisy.org/z3986/2005/ncx/");
		xff520a0047c27122("version", "2005-1");
		xff520a0047c27122("xml:lang", x0a758a5b915637a6());
		x2307058321cdb62f("head");
		x4495d55170e56e28("dtb:uid", "uid");
		x4495d55170e56e28("dtb:depth", "1");
		if (base.xf57de0fd37d5e97d.xbfa4c2c3efbf56fd)
		{
			x4495d55170e56e28("dtb:generator", "Aspose.Words for .NET 11.9.0.0");
		}
		x4495d55170e56e28("dtb:totalPageCount", "0");
		x4495d55170e56e28("dtb:maxPageNumber", "0");
		x2dfde153f4ef96d0();
		string x76ff03912924ece = xb00f4ba8788bbec8.x4f579785e809375e(base.xbd43463cc8d073a3.BuiltInDocumentProperties.Title);
		x17a38ec751c4ad58("docTitle", x76ff03912924ece);
		x17a38ec751c4ad58("docAuthor", base.xbd43463cc8d073a3.BuiltInDocumentProperties.Author);
		xae806a2b5be362a1 = xb00f4ba8788bbec8.xe6ef738f4b633cf2(base.xf1929ebebc6226d4, x6c20b1df8047763a: true);
		x2307058321cdb62f("navMap");
		x26f37ad62288df17();
		x2dfde153f4ef96d0();
		xa0dfc102c691b11f();
	}

	private void x26f37ad62288df17()
	{
		int num = 0;
		int num2 = 0;
		int xe1a45a387139cc3b = 1;
		foreach (x3b71b4b4a316ac7f item in xcb24734d87e68ca7)
		{
			string text = ((item.xf1597f82d8591ad4 != null) ? item.xf1597f82d8591ad4 : xae806a2b5be362a1);
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
			string xd1d55a56253db2df = ((item.xcd25f8502121b335 != null) ? $"{text}#{item.xcd25f8502121b335}" : text);
			string xeaf1b27180c0557b = $"level{item.x504f3d4040b356d7}-{((item.xcd25f8502121b335 != null) ? item.xcd25f8502121b335 : fileNameWithoutExtension)}";
			string xf9b06c19a78c = ((item.xabbaab6f446c47aa != null) ? item.xabbaab6f446c47aa : fileNameWithoutExtension);
			for (int i = num + 1; i < item.x504f3d4040b356d7; i++)
			{
				xa1d0567e87b3dd28($"level{i}-unnamed{++num2}", xe1a45a387139cc3b, "***", xd1d55a56253db2df);
			}
			for (int num3 = num; num3 >= item.x504f3d4040b356d7; num3--)
			{
				xc4eaad191bbfad48();
			}
			xa1d0567e87b3dd28(xeaf1b27180c0557b, xe1a45a387139cc3b++, xf9b06c19a78c, xd1d55a56253db2df);
			num = item.x504f3d4040b356d7;
		}
		while (num-- > 0)
		{
			xc4eaad191bbfad48();
		}
	}

	private void xa1d0567e87b3dd28(string xeaf1b27180c0557b, int xe1a45a387139cc3b, string xf9b06c19a78c9845, string xd1d55a56253db2df)
	{
		x2307058321cdb62f("navPoint");
		xff520a0047c27122("id", xeaf1b27180c0557b);
		x943f6be3acf634db("playOrder", xe1a45a387139cc3b);
		x17a38ec751c4ad58("navLabel", xf9b06c19a78c9845);
		x2307058321cdb62f("content");
		xff520a0047c27122("src", xd1d55a56253db2df);
		x2dfde153f4ef96d0();
	}

	private void xc4eaad191bbfad48()
	{
		x2dfde153f4ef96d0();
	}

	private void x17a38ec751c4ad58(string x121383aa64985888, string x76ff03912924ece4)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(x76ff03912924ece4))
		{
			x2307058321cdb62f(x121383aa64985888);
			x2307058321cdb62f("text");
			x3d1be38abe5723e3(x76ff03912924ece4);
			x538f0e0fb2bf15ab();
			x538f0e0fb2bf15ab();
		}
	}
}
