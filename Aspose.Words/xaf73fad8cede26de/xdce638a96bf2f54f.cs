using System.Collections;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;
using xfc5388ad7dff404f;

namespace xaf73fad8cede26de;

internal class xdce638a96bf2f54f
{
	private int xf51d7fbd0ad7745b = 1;

	private readonly xe965bada78e2d6b1 xb88ed8cce554eb93;

	private x3c74b3c4f21844f9 x0e25413aebc32ec0;

	private x04dfbda002f0cf6a xc4cc21b78abf1fcf;

	private x07f294506d1c9a72 x033fbe67e67fd9a4;

	private readonly ArrayList xdfdca767b8aa5c80 = new ArrayList();

	private readonly ArrayList x3bb434db1f3ba858 = new ArrayList();

	private readonly Hashtable x99596a051af4a8a2 = new Hashtable();

	private SizeF xe3d455fee27c95e0 = SizeF.Empty;

	private int xc2b1f0eb4128a4c0;

	private ArrayList x2f8367b53d747c8d = new ArrayList();

	private int x9d03ce998e923db6;

	public x04dfbda002f0cf6a x38f1a5c6c8faf5b1 => xc4cc21b78abf1fcf;

	public xfaf91ffd88d78c15 xb444c09fa044bbca
	{
		get
		{
			return x033fbe67e67fd9a4.xb444c09fa044bbca;
		}
		set
		{
			x033fbe67e67fd9a4.xb444c09fa044bbca = value;
		}
	}

	public x26efbcdc713eaa49 x73979cef1002ed01
	{
		get
		{
			return x033fbe67e67fd9a4.x73979cef1002ed01;
		}
		set
		{
			x033fbe67e67fd9a4.x73979cef1002ed01 = value;
		}
	}

	public xdce638a96bf2f54f(xe965bada78e2d6b1 xpsPackage, x26efbcdc713eaa49 options)
	{
		xb88ed8cce554eb93 = xpsPackage;
		x033fbe67e67fd9a4 = new x07f294506d1c9a72(xb88ed8cce554eb93, options.x4d2cf6c77ee521cd());
		x73979cef1002ed01 = options;
		xc8b972d76c12678f();
	}

	public void xb0882cca5e6880d3()
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xb88ed8cce554eb93.xd6abb2ab950b4d22.get_xe6d4b1b411ed94b5("/Documents/1/FixedDocument.fdoc");
		foreach (DictionaryEntry item in x033fbe67e67fd9a4.x39ca55b691f96321)
		{
			x6b1a899052c71a60 x29f65b3e7616f6b = ((xcd986872cf3bcf68)item.Value).x29f65b3e7616f6b3;
			if (x29f65b3e7616f6b.xc8040096b176b4af)
			{
				xa2f1c3dcbd86f20a.xadb7000bed559a9a.xd6b6ed77479ef68c("http://schemas.microsoft.com/xps/2005/06/restricted-font", (string)item.Key, x1bc1cc5e4fd586bf: false);
			}
		}
		x0e25413aebc32ec0.xa0dfc102c691b11f();
		xc4f1ccec920f4c51();
		xa7a70aba59bc1409();
		x812fc993738822ab();
		x033fbe67e67fd9a4.xa04e23b676ea0cc9();
		x37e34a3456bf5150.x6210059f049f0d48(xb88ed8cce554eb93, x5b792b12c6888eeb: false);
		x2819edc79dd3a61d.x6210059f049f0d48(xb88ed8cce554eb93, x5b792b12c6888eeb: false);
	}

	public void x804b2039ae4e9b33(float x9b0739496f8b5475, float x4d5aabc7a55b12ba)
	{
		x0e25413aebc32ec0.x2307058321cdb62f("PageContent");
		x0e25413aebc32ec0.xff520a0047c27122("Source", $"Pages/{xf51d7fbd0ad7745b}.fpage");
		x033fbe67e67fd9a4.xed34dd38c3f5b36e(xf51d7fbd0ad7745b);
		xc4cc21b78abf1fcf = new x04dfbda002f0cf6a(x033fbe67e67fd9a4, new x49c255776a98e55d(x033fbe67e67fd9a4.x189ff6a60062fbf5.xb8a774e0111d0fbe, isPrettyFormat: true), isXps: true);
		xc4cc21b78abf1fcf.x804b2039ae4e9b33(xf51d7fbd0ad7745b, x9b0739496f8b5475, x4d5aabc7a55b12ba);
	}

	public void xa0cf4a18229be519()
	{
		if (xdfdca767b8aa5c80 != null && xdfdca767b8aa5c80.Count > 0)
		{
			x0e25413aebc32ec0.x2307058321cdb62f("PageContent.LinkTargets");
			foreach (string item in xdfdca767b8aa5c80)
			{
				x0e25413aebc32ec0.x2307058321cdb62f("LinkTarget");
				x0e25413aebc32ec0.xff520a0047c27122("Name", item);
				x0e25413aebc32ec0.x2dfde153f4ef96d0();
			}
			xdfdca767b8aa5c80.Clear();
			x0e25413aebc32ec0.x2dfde153f4ef96d0();
		}
		x0e25413aebc32ec0.x2dfde153f4ef96d0();
		xc4cc21b78abf1fcf.xa0cf4a18229be519();
		xf51d7fbd0ad7745b++;
	}

	public void x7db09d025a6abf05(x9a66d03de2ff27e1 xa490ad5ef1682691)
	{
		string xc15bd84e = x7db09d025a6abf05(xa490ad5ef1682691.x759aa16c2016a289, xa490ad5ef1682691.xc22eade24b085d91);
		if (x73979cef1002ed01.x9b6007a17b33a42b > 0 && !xa490ad5ef1682691.x4b8f3649c1a3071c)
		{
			xdac50776b1d359d8(x73979cef1002ed01.x9b6007a17b33a42b, xa490ad5ef1682691.x759aa16c2016a289, xc15bd84e);
		}
	}

	public void x4f1c165c82126a3e(x2e5b68a308682b82 xccb63ca5f63dc470)
	{
		if (xccb63ca5f63dc470.x504f3d4040b356d7 < x73979cef1002ed01.xcaedf7c40a4ec358)
		{
			string xd17ec8f278d25c = $"outline_{xc2b1f0eb4128a4c0++}";
			string xc15bd84e = x7db09d025a6abf05(xd17ec8f278d25c, xccb63ca5f63dc470.xc22eade24b085d91);
			xdac50776b1d359d8(xccb63ca5f63dc470.x504f3d4040b356d7 + 1, xccb63ca5f63dc470.x238bf167ccfdd282, xc15bd84e);
		}
	}

	internal void xdac50776b1d359d8(int x66bbd7ed8c65740d, string x37a96021dbbe3532, string xc15bd84e01929885)
	{
		if (x66bbd7ed8c65740d > x9d03ce998e923db6)
		{
			x66bbd7ed8c65740d = x9d03ce998e923db6 + 1;
		}
		x0e00a75758bdebbd value = new x0e00a75758bdebbd(x66bbd7ed8c65740d, x37a96021dbbe3532, xc15bd84e01929885);
		x2f8367b53d747c8d.Add(value);
		x9d03ce998e923db6 = x66bbd7ed8c65740d;
	}

	private string x7db09d025a6abf05(string xd17ec8f278d25c87, PointF x0c16b19696d9614b)
	{
		if (!x3bb434db1f3ba858.Contains(xd17ec8f278d25c87))
		{
			string text = x033fbe67e67fd9a4.x94f739530d38cc0a(xd17ec8f278d25c87);
			xc4cc21b78abf1fcf.x7db09d025a6abf05(text, x0c16b19696d9614b);
			xdfdca767b8aa5c80.Add(text);
			x3bb434db1f3ba858.Add(xd17ec8f278d25c87);
			return text;
		}
		return "";
	}

	public void x0f61a94153870e81(SizeF x278780fb19a87271)
	{
		if (xf51d7fbd0ad7745b == 1)
		{
			xe3d455fee27c95e0 = x278780fb19a87271;
		}
		string key = $"{x278780fb19a87271.Width}{x278780fb19a87271.Height}";
		string text = (string)x99596a051af4a8a2[key];
		if (text == null)
		{
			text = $"/Documents/1/Metadata/Page{xf51d7fbd0ad7745b}_PT.xml";
			x99596a051af4a8a2[key] = text;
			xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = new xa2f1c3dcbd86f20a(text, "application/vnd.ms-printing.printticket+xml");
			xb88ed8cce554eb93.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xa2f1c3dcbd86f20a);
			x7027e340f3453942.x6210059f049f0d48(new x3c74b3c4f21844f9(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe, isPrettyFormat: true), x278780fb19a87271, x65278395acd43d58: true);
		}
		x033fbe67e67fd9a4.x189ff6a60062fbf5.xadb7000bed559a9a.xd6b6ed77479ef68c("http://schemas.microsoft.com/xps/2005/06/printticket", text, x1bc1cc5e4fd586bf: false);
	}

	private void xea4c767231680ddb(xa2f1c3dcbd86f20a x63912ed318af9aac)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = new xa2f1c3dcbd86f20a("/Metadata/MXDC_Empty_PT.xml", "application/vnd.ms-printing.printticket+xml");
		xb88ed8cce554eb93.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xa2f1c3dcbd86f20a);
		x7027e340f3453942.x473cc59a91f47b0d(new x3c74b3c4f21844f9(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe, isPrettyFormat: true));
		x63912ed318af9aac.xadb7000bed559a9a.xd6b6ed77479ef68c("http://schemas.microsoft.com/xps/2005/06/printticket", xa2f1c3dcbd86f20a.x759aa16c2016a289, x1bc1cc5e4fd586bf: false);
	}

	private void xb31a55ab4d854812(xa2f1c3dcbd86f20a x13334e86495243a4)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = new xa2f1c3dcbd86f20a("/Metadata/Job_PT.xml", "application/vnd.ms-printing.printticket+xml");
		xb88ed8cce554eb93.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xa2f1c3dcbd86f20a);
		x7027e340f3453942.x6210059f049f0d48(new x3c74b3c4f21844f9(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe, isPrettyFormat: true), xe3d455fee27c95e0, x65278395acd43d58: false);
		x13334e86495243a4.xadb7000bed559a9a.xd6b6ed77479ef68c("http://schemas.microsoft.com/xps/2005/06/printticket", xa2f1c3dcbd86f20a.x759aa16c2016a289, x1bc1cc5e4fd586bf: false);
	}

	private void xc8b972d76c12678f()
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = new xa2f1c3dcbd86f20a("/Documents/1/FixedDocument.fdoc", "application/vnd.ms-package.xps-fixeddocument+xml");
		xb88ed8cce554eb93.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xa2f1c3dcbd86f20a);
		x0e25413aebc32ec0 = new x3c74b3c4f21844f9(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe, isPrettyFormat: false);
		x0e25413aebc32ec0.x9b9ed0109b743e3b("FixedDocument");
		x0e25413aebc32ec0.xff520a0047c27122("xmlns", "http://schemas.microsoft.com/xps/2005/06");
		xea4c767231680ddb(xa2f1c3dcbd86f20a);
	}

	private void xc4f1ccec920f4c51()
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = new xa2f1c3dcbd86f20a("/FixedDocumentSequence.fdseq", "application/vnd.ms-package.xps-fixeddocumentsequence+xml");
		xb88ed8cce554eb93.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xa2f1c3dcbd86f20a);
		x3c74b3c4f21844f9 x3c74b3c4f21844f = new x3c74b3c4f21844f9(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe, isPrettyFormat: false);
		x3c74b3c4f21844f.x9b9ed0109b743e3b("FixedDocumentSequence");
		x3c74b3c4f21844f.xff520a0047c27122("xmlns", "http://schemas.microsoft.com/xps/2005/06");
		x3c74b3c4f21844f.x2307058321cdb62f("DocumentReference");
		x3c74b3c4f21844f.xff520a0047c27122("Source", "Documents/1/FixedDocument.fdoc");
		x3c74b3c4f21844f.x2dfde153f4ef96d0();
		x3c74b3c4f21844f.xa0dfc102c691b11f();
		xb88ed8cce554eb93.xadb7000bed559a9a.xd6b6ed77479ef68c("http://schemas.microsoft.com/xps/2005/06/fixedrepresentation", "/FixedDocumentSequence.fdseq", x1bc1cc5e4fd586bf: false);
		xb31a55ab4d854812(xa2f1c3dcbd86f20a);
	}

	private void xa7a70aba59bc1409()
	{
		x033fbe67e67fd9a4.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x42daab0e7e499260, "Only built-in document properties will be output to XPS. All custom document properties will be lost");
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = new xa2f1c3dcbd86f20a("/docProps/core.xml", "application/vnd.openxmlformats-package.core-properties+xml");
		xb88ed8cce554eb93.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xa2f1c3dcbd86f20a);
		x3c74b3c4f21844f9 xd07ce4b74c5774a = new x3c74b3c4f21844f9(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe, isPrettyFormat: false);
		xce0a9cd40869484e.x6210059f049f0d48(xd07ce4b74c5774a, x033fbe67e67fd9a4.xb444c09fa044bbca.x238bf167ccfdd282, x033fbe67e67fd9a4.xb444c09fa044bbca.x191dcb88c409b8dd, x033fbe67e67fd9a4.xb444c09fa044bbca.x1d3fdaa19c46dec0, x033fbe67e67fd9a4.xb444c09fa044bbca.x514c0ea24ce40ef0, x033fbe67e67fd9a4.xb444c09fa044bbca.x3d235fc95c355365, x033fbe67e67fd9a4.xb444c09fa044bbca.xc1cc5daecf136be2, x033fbe67e67fd9a4.xb444c09fa044bbca.x8de74e31564e64c5, x033fbe67e67fd9a4.xb444c09fa044bbca.x0ce1fa538aa7937f, x033fbe67e67fd9a4.xb444c09fa044bbca.x01fda47aa971692d, x033fbe67e67fd9a4.xb444c09fa044bbca.xdd48db0e1a80d624, x033fbe67e67fd9a4.xb444c09fa044bbca.x9ee8adcec1e2f351);
		xb88ed8cce554eb93.xadb7000bed559a9a.xd6b6ed77479ef68c("http://schemas.openxmlformats.org/package/2006/relationships/metadata/core-properties", "/docProps/core.xml", x1bc1cc5e4fd586bf: false);
	}

	private void x812fc993738822ab()
	{
		if (x2f8367b53d747c8d.Count <= 0)
		{
			return;
		}
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = new xa2f1c3dcbd86f20a("/Documents/1/Structure/DocStructure.struct", "application/vnd.ms-package.xps-documentstructure+xml");
		xb88ed8cce554eb93.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xa2f1c3dcbd86f20a);
		x3c74b3c4f21844f9 x3c74b3c4f21844f = new x3c74b3c4f21844f9(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe, isPrettyFormat: false);
		x3c74b3c4f21844f.x9b9ed0109b743e3b("DocumentStructure");
		x3c74b3c4f21844f.xff520a0047c27122("xmlns", "http://schemas.microsoft.com/xps/2005/06/documentstructure");
		x3c74b3c4f21844f.x2307058321cdb62f("DocumentStructure.Outline");
		x3c74b3c4f21844f.x2307058321cdb62f("DocumentOutline");
		x3c74b3c4f21844f.xff520a0047c27122("xml:lang", "en-US");
		foreach (x0e00a75758bdebbd item in x2f8367b53d747c8d)
		{
			x3c74b3c4f21844f.x2307058321cdb62f("OutlineEntry");
			x3c74b3c4f21844f.xff520a0047c27122("OutlineLevel", item.x504f3d4040b356d7.ToString());
			x3c74b3c4f21844f.xff520a0047c27122("Description", item.x238bf167ccfdd282);
			x3c74b3c4f21844f.xff520a0047c27122("OutlineTarget", $"../../../FixedDocumentSequence.fdseq#{item.x0e99a2a20bc3c647}");
			x3c74b3c4f21844f.x2dfde153f4ef96d0();
		}
		x3c74b3c4f21844f.x2dfde153f4ef96d0();
		x3c74b3c4f21844f.x2dfde153f4ef96d0();
		x3c74b3c4f21844f.xa0dfc102c691b11f();
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a2 = xb88ed8cce554eb93.xd6abb2ab950b4d22.get_xe6d4b1b411ed94b5("/Documents/1/FixedDocument.fdoc");
		xa2f1c3dcbd86f20a2.xadb7000bed559a9a.xd6b6ed77479ef68c("http://schemas.microsoft.com/xps/2005/06/documentstructure", "/Documents/1/Structure/DocStructure.struct", x1bc1cc5e4fd586bf: false);
	}
}
