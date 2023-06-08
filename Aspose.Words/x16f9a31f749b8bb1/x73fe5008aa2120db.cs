using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Markup;
using Aspose.Words.Tables;
using x011d489fb9df7027;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;
using xf989f31a236ff98c;
using xfbd1009a0cbb9842;

namespace x16f9a31f749b8bb1;

internal class x73fe5008aa2120db : xa3ed3b2cd8f77351
{
	private readonly Document x232be220f517f721;

	private CompositeNode x4cbed795c600d582;

	private CompositeNode xcd0f949340c9a324;

	private Shape xcafc21cdc32e6710;

	private readonly Stack xd48deb218af504df = new Stack();

	private readonly x12d551e21425ffee x04562d8eb06323c7;

	private readonly ArrayList x78b4c9d9b2bebe94 = new ArrayList();

	private readonly LoadOptions xd545ef71ef25db52;

	internal IWarningCallback xf69ca7a9bb4a4a51
	{
		get
		{
			if (xd545ef71ef25db52 == null)
			{
				return null;
			}
			return xd545ef71ef25db52.WarningCallback;
		}
	}

	internal x73fe5008aa2120db(Document doc, LoadOptions loadOptions)
	{
		x232be220f517f721 = doc;
		x4cbed795c600d582 = doc;
		x04562d8eb06323c7 = new x12d551e21425ffee(loadOptions.WarningCallback, WarningSource.Doc);
		xd545ef71ef25db52 = loadOptions;
	}

	private void x86be67b7c50a4901()
	{
		x20eec3666a2dc8d0.xb07a1ad51e61e4f3(x232be220f517f721.Styles, xdd0280d7d3660ad1: false);
	}

	void xa3ed3b2cd8f77351.xf3a409990d06c568()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x86be67b7c50a4901
		this.x86be67b7c50a4901();
	}

	private void xa8fa8d621233728d(bool x41a4b8e6ac87eea5)
	{
		x232be220f517f721.x6cb2cfca19c7adb6 = x41a4b8e6ac87eea5;
		x04562d8eb06323c7.x79f7fd8368ae8a71();
	}

	void xa3ed3b2cd8f77351.x3c06113138282067(bool x41a4b8e6ac87eea5)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa8fa8d621233728d
		this.xa8fa8d621233728d(x41a4b8e6ac87eea5);
	}

	private void xb63a99fb8add7a78(xfc72d4c9b765cad7 x873e775b892867cf)
	{
		x490834a62c46f14d(new Section(x232be220f517f721, x873e775b892867cf));
	}

	void xa3ed3b2cd8f77351.xe95664527db59e6e(xfc72d4c9b765cad7 x873e775b892867cf)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xb63a99fb8add7a78
		this.xb63a99fb8add7a78(x873e775b892867cf);
	}

	private void x07cd158dc5021924()
	{
		if (x4cbed795c600d582.NodeType != NodeType.Section)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kakgadbhdcihmnohicgimbnidndjdcljcbcknajklbalnahlabolmafmlllmbadniaknclaoophobaponpfpgkmpcpdagokanjbbnoibappbcogcenncmjed", 15231429)));
		}
		xf5b0b9b6ff7ac462();
	}

	void xa3ed3b2cd8f77351.xfdbe40d109da78d3()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x07cd158dc5021924
		this.x07cd158dc5021924();
	}

	private void xd76a2a8f09062500()
	{
		x490834a62c46f14d(new Body(x232be220f517f721));
	}

	void xa3ed3b2cd8f77351.xbaeac8c4c56306fe()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xd76a2a8f09062500
		this.xd76a2a8f09062500();
	}

	private void x357df64c6f6df73f()
	{
		xbd4725ff9d257810(NodeType.Body);
		xf5b0b9b6ff7ac462();
	}

	void xa3ed3b2cd8f77351.xa5e2284bda2bc317()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x357df64c6f6df73f
		this.x357df64c6f6df73f();
	}

	private void x5d27b75565fce1b2(HeaderFooterType xa685fef1a31f5d4d)
	{
		x490834a62c46f14d(new HeaderFooter(x232be220f517f721, xa685fef1a31f5d4d));
	}

	void xa3ed3b2cd8f77351.xe7d4c5256fad03b7(HeaderFooterType xa685fef1a31f5d4d)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x5d27b75565fce1b2
		this.x5d27b75565fce1b2(xa685fef1a31f5d4d);
	}

	private void xf2a92fd4e4c01209()
	{
		xbd4725ff9d257810(NodeType.HeaderFooter);
		xf5b0b9b6ff7ac462();
	}

	void xa3ed3b2cd8f77351.xac2ccec47108f993()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xf2a92fd4e4c01209
		this.xf2a92fd4e4c01209();
	}

	private void xbd4725ff9d257810(NodeType x10b2f85e4d520fe8)
	{
		if (x4cbed795c600d582.NodeType == x10b2f85e4d520fe8)
		{
			if (x10b2f85e4d520fe8 == NodeType.HeaderFooter || x10b2f85e4d520fe8 == NodeType.Shape)
			{
				x2986325c567dc69d(x4cbed795c600d582);
			}
		}
		else if (x4cbed795c600d582.NodeType == NodeType.Cell)
		{
			xf5b0b9b6ff7ac462();
			Row row = (Row)x4cbed795c600d582;
			xf5b0b9b6ff7ac462();
			xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, "EndStory occurred in a cell, row will be deleted.");
			row.Remove();
			Table x1ec770899c98a = (Table)x4cbed795c600d582;
			x5d3aa187f40ade65(x1ec770899c98a);
			xf5b0b9b6ff7ac462();
		}
		else if (x4cbed795c600d582.NodeType == NodeType.Row)
		{
			Row row2 = (Row)x4cbed795c600d582;
			xf5b0b9b6ff7ac462();
			xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, "EndStory occurred in row, row will be deleted.");
			row2.Remove();
			xf5b0b9b6ff7ac462();
		}
		else
		{
			if (x4cbed795c600d582.NodeType != NodeType.Table)
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jjhfplofclfglgmghldhlkkhcgbicliialpiikgjiknjmkekaflkgjclnjjlheamdjhmgjomcjfnldmnhidolhkocdbpciipfipphhgajgnabdeb", 1569412948)));
			}
			xf5b0b9b6ff7ac462();
		}
	}

	private void x49b94fead3ff510c(x101cddc73c4f8cc2 x781135a02d5b7a22)
	{
		if (x4cbed795c600d582 != x232be220f517f721)
		{
			throw new InvalidOperationException("Footnote separators are expected to be processed at the document level.");
		}
		xa1e2a8ed32a026dd xbcea506a33cf = new xa1e2a8ed32a026dd(x232be220f517f721, x781135a02d5b7a22);
		x232be220f517f721.x245aa7750b4a8072.set_xe6d4b1b411ed94b5(x781135a02d5b7a22, xbcea506a33cf);
		x4cbed795c600d582 = xbcea506a33cf;
	}

	void xa3ed3b2cd8f77351.x18f818c15e0066f1(x101cddc73c4f8cc2 x781135a02d5b7a22)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x49b94fead3ff510c
		this.x49b94fead3ff510c(x781135a02d5b7a22);
	}

	private void xc155257384b383af()
	{
		x2986325c567dc69d(x4cbed795c600d582);
		x4cbed795c600d582 = x232be220f517f721;
	}

	void xa3ed3b2cd8f77351.x4365e55d32fd2636()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xc155257384b383af
		this.xc155257384b383af();
	}

	private static void x2986325c567dc69d(CompositeNode x8b2c3c076d5a7daf)
	{
		Node lastChild = x8b2c3c076d5a7daf.LastChild;
		if (lastChild is Paragraph && !((Paragraph)lastChild).HasChildNodes)
		{
			lastChild.Remove();
		}
	}

	private void x584c3899e69f3c3f()
	{
		x490834a62c46f14d(new Paragraph(x232be220f517f721));
	}

	void xa3ed3b2cd8f77351.x9df170cae7684fe6()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x584c3899e69f3c3f
		this.x584c3899e69f3c3f();
	}

	private void xdf7171e99a62215c(x1a78664fa10a3755 x062aae8c9613eeaa, xeedad81aaed42a76 x789564759d365819)
	{
		while (x4cbed795c600d582.NodeType == NodeType.SmartTag)
		{
			xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, $"Smart tag '{((SmartTag)x4cbed795c600d582).Element}' ends after paragraph mark.");
			xc798bb83e23f6a08();
		}
		while (x4cbed795c600d582.NodeType == NodeType.CustomXmlMarkup)
		{
			xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, $"Inline custom XML '{((CustomXmlMarkup)x4cbed795c600d582).Element}' ends after paragraph mark.");
			x7eac7e2ac5d4302b();
		}
		if (x4cbed795c600d582.NodeType != NodeType.Paragraph)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gkdimmkiplbjihijempjilgkpgnkmlelkkllilcmekjmhkanpkhnljonhkfomjmobfdphjkpojbaieiaejpahjgbdjnbmdeciilcmhcdddjddiaegiheihoekgffcdmf", 547849057)));
		}
		Paragraph paragraph = (Paragraph)x4cbed795c600d582;
		paragraph.x1a78664fa10a3755 = x062aae8c9613eeaa;
		paragraph.x344511c4e4ce09da = (xeedad81aaed42a76)x789564759d365819.x8b61531c8ea35b85();
		x20eec3666a2dc8d0.xb07a1ad51e61e4f3(paragraph);
		xf5b0b9b6ff7ac462();
	}

	void xa3ed3b2cd8f77351.xa1237507e66611c4(x1a78664fa10a3755 x062aae8c9613eeaa, xeedad81aaed42a76 x789564759d365819)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xdf7171e99a62215c
		this.xdf7171e99a62215c(x062aae8c9613eeaa, x789564759d365819);
	}

	private void x47895ebe9d58f5f9(string xb41faee6912a2313, xeedad81aaed42a76 x789564759d365819)
	{
		x4cbed795c600d582.xdf7453d9fdf3f262(new Run(x232be220f517f721, xb41faee6912a2313, x789564759d365819));
	}

	void xa3ed3b2cd8f77351.x93a8c149d218a60f(string xb41faee6912a2313, xeedad81aaed42a76 x789564759d365819)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x47895ebe9d58f5f9
		this.x47895ebe9d58f5f9(xb41faee6912a2313, x789564759d365819);
	}

	private void x67c4615df4adf3b0(char x12f11d52c2c4d003, xeedad81aaed42a76 x789564759d365819)
	{
		if (!xac96e79d313bc59c(x12f11d52c2c4d003, x789564759d365819))
		{
			x4cbed795c600d582.xdf7453d9fdf3f262(new SpecialChar(x232be220f517f721, x12f11d52c2c4d003, x789564759d365819));
		}
	}

	void xa3ed3b2cd8f77351.x27442410230d2b1f(char x12f11d52c2c4d003, xeedad81aaed42a76 x789564759d365819)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x67c4615df4adf3b0
		this.x67c4615df4adf3b0(x12f11d52c2c4d003, x789564759d365819);
	}

	private bool xac96e79d313bc59c(char x12f11d52c2c4d003, xeedad81aaed42a76 x789564759d365819)
	{
		bool result = false;
		if (x12f11d52c2c4d003 == '\0')
		{
			Node[] array = x558767d34a146386.x2163dabd23663d1e(x232be220f517f721, x789564759d365819);
			for (int i = 0; i < array.Length; i++)
			{
				x4cbed795c600d582.xdf7453d9fdf3f262(array[i]);
			}
			result = true;
		}
		return result;
	}

	private void xd5506b1d20e56c46(x58bf2a36f9adf9a9 x3db8cf25c83af70b, xeedad81aaed42a76 x789564759d365819)
	{
		x4cbed795c600d582.xdf7453d9fdf3f262(new FormField(x232be220f517f721, x3db8cf25c83af70b, x789564759d365819));
	}

	void xa3ed3b2cd8f77351.xd438a3a8968e57e1(x58bf2a36f9adf9a9 x3db8cf25c83af70b, xeedad81aaed42a76 x789564759d365819)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xd5506b1d20e56c46
		this.xd5506b1d20e56c46(x3db8cf25c83af70b, x789564759d365819);
	}

	private void x1f191d6e017d4fff(xeedad81aaed42a76 x789564759d365819, FieldType x43163d22e8cd5a71)
	{
		FieldStart fieldStart = new FieldStart(x232be220f517f721, x789564759d365819, x43163d22e8cd5a71);
		x4cbed795c600d582.xdf7453d9fdf3f262(fieldStart);
		if (!fieldStart.IsDeleteRevision)
		{
			xd48deb218af504df.Push(fieldStart);
		}
	}

	void xa3ed3b2cd8f77351.xcf72734b7092bebe(xeedad81aaed42a76 x789564759d365819, FieldType x43163d22e8cd5a71)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x1f191d6e017d4fff
		this.x1f191d6e017d4fff(x789564759d365819, x43163d22e8cd5a71);
	}

	private void xd71464bade8fbcf7(xeedad81aaed42a76 x789564759d365819, x71d39fdf56861cca xb7b1409b12ce2ee3)
	{
		FieldSeparator fieldSeparator = new FieldSeparator(x232be220f517f721, x789564759d365819, FieldType.FieldNone, xb7b1409b12ce2ee3);
		if (!fieldSeparator.IsDeleteRevision && !xfd11b32344386bfa(NodeType.FieldStart))
		{
			xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, "Invalid field separator without field start occurred.");
			return;
		}
		x4cbed795c600d582.xdf7453d9fdf3f262(fieldSeparator);
		if (!fieldSeparator.IsDeleteRevision)
		{
			xd48deb218af504df.Push(fieldSeparator);
		}
	}

	void xa3ed3b2cd8f77351.x094e1db5f87bb62b(xeedad81aaed42a76 x789564759d365819, x71d39fdf56861cca xb7b1409b12ce2ee3)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xd71464bade8fbcf7
		this.xd71464bade8fbcf7(x789564759d365819, xb7b1409b12ce2ee3);
	}

	private void xc5e6fd753162ab42(xeedad81aaed42a76 x789564759d365819, bool x0c07ecaa89906059, bool x549b1a1bab8624ee)
	{
		FieldEnd fieldEnd = new FieldEnd(x232be220f517f721, x789564759d365819, FieldType.FieldNone, hasSeparator: false);
		fieldEnd.x6e94079169d5a06e = x549b1a1bab8624ee;
		fieldEnd.IsLocked = x0c07ecaa89906059;
		x4cbed795c600d582.xdf7453d9fdf3f262(fieldEnd);
		if (fieldEnd.IsDeleteRevision)
		{
			return;
		}
		x928b31adb20d5cc6 xe01ae93d9fe5a = xa52828dc23fddd4d(fieldEnd);
		if (xe01ae93d9fe5a.x12cb12b5d2cad53d == null)
		{
			xe01ae93d9fe5a.x45aed43ab4f2045c();
			return;
		}
		FieldType fieldType = x5c29822913be33c1.x338a5159d9aa7162(xe01ae93d9fe5a.x29815ca66d57cfae());
		if (fieldType != 0 && fieldType != xe01ae93d9fe5a.x12cb12b5d2cad53d.FieldType)
		{
			x98b0e09ccece0a5a.x3dc950453374051a(xf69ca7a9bb4a4a51, WarningSource.Doc, "Invalid field type specified while reading DOC file.");
		}
		else
		{
			fieldType = xe01ae93d9fe5a.x12cb12b5d2cad53d.FieldType;
		}
		if (fieldType == FieldType.FieldCannotParse)
		{
			fieldType = FieldType.FieldNone;
		}
		if (xe01ae93d9fe5a.x43604484a3deae4f == null && x5c29822913be33c1.xd668adf9377c05ee(fieldType) == x5576a2206c3fc746.xd4d82c4665f71358)
		{
			xe01ae93d9fe5a.x43604484a3deae4f = new FieldSeparator(x232be220f517f721, (xeedad81aaed42a76)x789564759d365819.x8b61531c8ea35b85(), fieldType);
			x4cbed795c600d582.InsertBefore(xe01ae93d9fe5a.x43604484a3deae4f, xe01ae93d9fe5a.x9fd888e65466818c);
		}
		xe01ae93d9fe5a.x8fdbe5468986594f(fieldType);
		xe01ae93d9fe5a.x6e0f5b69ee5c3db9();
		xe01ae93d9fe5a.x9fd888e65466818c.x254cab982e9946b2(xe01ae93d9fe5a.x43604484a3deae4f != null);
		Shape shape = xa8c3566f95fa8995(xe01ae93d9fe5a.x43604484a3deae4f);
		x3f78a18d30ea7a7f.x55c809ab6c9605c7(xe01ae93d9fe5a, shape, xd545ef71ef25db52);
		if (shape != null && shape.ShapeType == ShapeType.OleControl)
		{
			shape.xf7125312c7ee115c.xae20093bed1e48a8(508, false);
		}
	}

	void xa3ed3b2cd8f77351.x3bb349c77392b35c(xeedad81aaed42a76 x789564759d365819, bool x0c07ecaa89906059, bool x549b1a1bab8624ee)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xc5e6fd753162ab42
		this.xc5e6fd753162ab42(x789564759d365819, x0c07ecaa89906059, x549b1a1bab8624ee);
	}

	private x928b31adb20d5cc6 xa52828dc23fddd4d(FieldEnd xc87e4e475724f9c3)
	{
		x928b31adb20d5cc6 result = default(x928b31adb20d5cc6);
		result.x9fd888e65466818c = xc87e4e475724f9c3;
		if (xfd11b32344386bfa(NodeType.FieldSeparator))
		{
			result.x43604484a3deae4f = (FieldSeparator)xd48deb218af504df.Pop();
		}
		if (xfd11b32344386bfa(NodeType.FieldStart))
		{
			result.x12cb12b5d2cad53d = (FieldStart)xd48deb218af504df.Pop();
		}
		return result;
	}

	private bool xfd11b32344386bfa(NodeType x1a523190ff9254e6)
	{
		if (xd48deb218af504df.Count == 0)
		{
			return false;
		}
		Node node = (Node)xd48deb218af504df.Peek();
		return node.NodeType == x1a523190ff9254e6;
	}

	private Shape xa8c3566f95fa8995(FieldSeparator xed9a565596a6ae3f)
	{
		if (xcafc21cdc32e6710 != null)
		{
			return xcafc21cdc32e6710;
		}
		if (xed9a565596a6ae3f == null)
		{
			return null;
		}
		return xed9a565596a6ae3f.NextSibling as Shape;
	}

	private void xdae2cd5f466f9f61(ShapeBase x5770cdefd8931aa9)
	{
		if (!x5770cdefd8931aa9.IsGroup && x5770cdefd8931aa9.xd06a0f106e67d743)
		{
			x232be220f517f721.Lists.x2c0e9f8fa1946281((Shape)x5770cdefd8931aa9);
		}
		else
		{
			x4cbed795c600d582.xdf7453d9fdf3f262(x5770cdefd8931aa9);
		}
	}

	void xa3ed3b2cd8f77351.xa9993ed2e0c64574(ShapeBase x5770cdefd8931aa9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xdae2cd5f466f9f61
		this.xdae2cd5f466f9f61(x5770cdefd8931aa9);
	}

	private void x0892d190f0de149f(Shape x5770cdefd8931aa9)
	{
		xcd0f949340c9a324 = x4cbed795c600d582;
		x4cbed795c600d582 = x5770cdefd8931aa9;
		if (x5770cdefd8931aa9.xa170cce2bc40bdf5)
		{
			xcafc21cdc32e6710 = x5770cdefd8931aa9;
		}
	}

	void xa3ed3b2cd8f77351.xb2930715346a6867(Shape x5770cdefd8931aa9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x0892d190f0de149f
		this.x0892d190f0de149f(x5770cdefd8931aa9);
	}

	private void xdf118ad80206ffff(Shape x5770cdefd8931aa9)
	{
		xbd4725ff9d257810(NodeType.Shape);
		x4cbed795c600d582 = xcd0f949340c9a324;
		xcd0f949340c9a324 = null;
		if (xcafc21cdc32e6710 != null)
		{
			xcafc21cdc32e6710.RemoveAllChildren();
			if (xcafc21cdc32e6710.xa170cce2bc40bdf5 && !x0d299f323d241756.x5959bccb67bbf051(xcafc21cdc32e6710.OleFormat.ProgId))
			{
				xcafc21cdc32e6710.x88d1b78392d1a0ab(ShapeType.Image);
			}
			xcafc21cdc32e6710 = null;
		}
	}

	void xa3ed3b2cd8f77351.x6c71b8bd0c5c4b9a(Shape x5770cdefd8931aa9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xdf118ad80206ffff
		this.xdf118ad80206ffff(x5770cdefd8931aa9);
	}

	private void xbff4370367dcbfbe(FootnoteType x43163d22e8cd5a71, bool x2b420b6d36637389, string x28b93a6f10c14440, xeedad81aaed42a76 x789564759d365819)
	{
		x490834a62c46f14d(new Footnote(x232be220f517f721, x43163d22e8cd5a71, x2b420b6d36637389, x28b93a6f10c14440, x789564759d365819));
	}

	void xa3ed3b2cd8f77351.x1f4dededb9314c98(FootnoteType x43163d22e8cd5a71, bool x2b420b6d36637389, string x28b93a6f10c14440, xeedad81aaed42a76 x789564759d365819)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xbff4370367dcbfbe
		this.xbff4370367dcbfbe(x43163d22e8cd5a71, x2b420b6d36637389, x28b93a6f10c14440, x789564759d365819);
	}

	private void x1124f21199c7b454()
	{
		if (x4cbed795c600d582.NodeType != NodeType.Footnote)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cmoeiofflnmfejdgaokgenbhliihomphengibnnidnejkmljimckkmjkilalahhlglolnlfmhgmmdldnglknclbolfiohkpoljgpcfnpckeafklahjcbjijbbfac", 1419988605)));
		}
		xf5b0b9b6ff7ac462();
	}

	void xa3ed3b2cd8f77351.x08d6c67017518c71()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x1124f21199c7b454
		this.x1124f21199c7b454();
	}

	private void x52833fb70d17df32(int xeaf1b27180c0557b, string xab756a671f0c2b92, string x984160c7f0248924, DateTime xb21f13a9707ad954, xeedad81aaed42a76 x789564759d365819)
	{
		Comment comment = new Comment(x232be220f517f721, x789564759d365819);
		((x8ad0c0863d1cd403)comment).x417a0a94031e7e8b = xeaf1b27180c0557b;
		comment.Initial = xab756a671f0c2b92;
		comment.Author = x984160c7f0248924;
		comment.DateTime = xb21f13a9707ad954;
		x490834a62c46f14d(comment);
	}

	void xa3ed3b2cd8f77351.x508bedf5d0984ae8(int xeaf1b27180c0557b, string xab756a671f0c2b92, string x984160c7f0248924, DateTime xb21f13a9707ad954, xeedad81aaed42a76 x789564759d365819)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x52833fb70d17df32
		this.x52833fb70d17df32(xeaf1b27180c0557b, xab756a671f0c2b92, x984160c7f0248924, xb21f13a9707ad954, x789564759d365819);
	}

	private void x50cc4c6458a0a4c3()
	{
		while (x4cbed795c600d582.NodeType != NodeType.Comment)
		{
			if (x4cbed795c600d582.NodeType == NodeType.Row)
			{
				Row row = (Row)x4cbed795c600d582;
				if (row.xedb0eb766e25e0c9 == null)
				{
					row.xedb0eb766e25e0c9 = xedb0eb766e25e0c9.xf5b6851196debf5a();
				}
				xf5b0b9b6ff7ac462();
			}
			else if (x4cbed795c600d582.NodeType == NodeType.Cell)
			{
				Cell cell = (Cell)x4cbed795c600d582;
				if (cell.xf8cef531dae89ea3 == null)
				{
					cell.xf8cef531dae89ea3 = new xf8cef531dae89ea3();
				}
				xf5b0b9b6ff7ac462();
			}
			else if (x4cbed795c600d582.NodeType == NodeType.Table)
			{
				xf5b0b9b6ff7ac462();
			}
		}
		xf5b0b9b6ff7ac462();
	}

	void xa3ed3b2cd8f77351.x0d5864f2522edf7f()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x50cc4c6458a0a4c3
		this.x50cc4c6458a0a4c3();
	}

	private void xdafbf6c195b17656(int xeaf1b27180c0557b)
	{
		x8c81feb19d9adb77(new CommentRangeStart(x232be220f517f721, xeaf1b27180c0557b));
	}

	void xa3ed3b2cd8f77351.xb2aa25f342d8a7ea(int xeaf1b27180c0557b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xdafbf6c195b17656
		this.xdafbf6c195b17656(xeaf1b27180c0557b);
	}

	private void x4a7ad5d4461ec2a9(int xeaf1b27180c0557b)
	{
		x8c81feb19d9adb77(new CommentRangeEnd(x232be220f517f721, xeaf1b27180c0557b));
	}

	void xa3ed3b2cd8f77351.x84b5a4e4bf2cce0d(int xeaf1b27180c0557b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x4a7ad5d4461ec2a9
		this.x4a7ad5d4461ec2a9(xeaf1b27180c0557b);
	}

	private void xefaa7c691049c58a(string xc15bd84e01929885, int xebf45bdcaa1fd1e1)
	{
		if (xc15bd84e01929885 != "_PictureBullets")
		{
			x8c81feb19d9adb77(new BookmarkStart(x232be220f517f721, xc15bd84e01929885, xebf45bdcaa1fd1e1));
		}
	}

	void xa3ed3b2cd8f77351.x724e8b0eb9767138(string xc15bd84e01929885, int xebf45bdcaa1fd1e1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xefaa7c691049c58a
		this.xefaa7c691049c58a(xc15bd84e01929885, xebf45bdcaa1fd1e1);
	}

	private void xdf6ccd9d4123cf33(string xc15bd84e01929885)
	{
		if (xc15bd84e01929885 != "_PictureBullets")
		{
			x8c81feb19d9adb77(new BookmarkEnd(x232be220f517f721, xc15bd84e01929885));
		}
	}

	void xa3ed3b2cd8f77351.x1148fa1778bbfd56(string xc15bd84e01929885)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xdf6ccd9d4123cf33
		this.xdf6ccd9d4123cf33(xc15bd84e01929885);
	}

	private void x8dab1a3d6a6d53b0()
	{
		x490834a62c46f14d(new Table(x232be220f517f721));
	}

	void xa3ed3b2cd8f77351.x751f41e8113776ff()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8dab1a3d6a6d53b0
		this.x8dab1a3d6a6d53b0();
	}

	private void x4bb7c72917389bd2()
	{
		if (x4cbed795c600d582.NodeType != NodeType.Table)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jgknpibociioldpohigplhnpcdeadilangcblgjbchacighcacocggfdngmdhbdedgkeggbfcgiflapfhfgglengcaehcflhffcihejijdajbahj", 1752095268)));
		}
		Table x1ec770899c98a = (Table)x4cbed795c600d582;
		x5d3aa187f40ade65(x1ec770899c98a);
		xb919b8b9539d871d(x1ec770899c98a);
		if (x1ff7e2e08d97e6d9(x1ec770899c98a))
		{
			x3edcbda53e2e35b4(x1ec770899c98a);
		}
		xf5b0b9b6ff7ac462();
	}

	void xa3ed3b2cd8f77351.x48bcfa796334770b()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x4bb7c72917389bd2
		this.x4bb7c72917389bd2();
	}

	private static bool x1ff7e2e08d97e6d9(Table x1ec770899c98a268)
	{
		if (x1ec770899c98a268.Rows.Count == 0)
		{
			return false;
		}
		return x1ec770899c98a268.Rows[0].xedb0eb766e25e0c9.x263d579af1d0d43f(5102);
	}

	private static void x3edcbda53e2e35b4(Table x1ec770899c98a268)
	{
		Row row = x1ec770899c98a268.Rows[0];
		int num = (int)row.xedb0eb766e25e0c9.xf7866f89640a29a3(5102);
		foreach (Row row4 in x1ec770899c98a268.Rows)
		{
			int num2 = (int)row4.xedb0eb766e25e0c9.xf7866f89640a29a3(5102);
			if (num2 < num)
			{
				num = num2;
				row = row4;
			}
		}
		int num3 = ((row.FirstCell != null && row.FirstCell.xf8cef531dae89ea3.x263d579af1d0d43f(3090)) ? row.FirstCell.xf8cef531dae89ea3.xcad2e59522947ede : row.xedb0eb766e25e0c9.xcad2e59522947ede);
		int num4 = num3 + (int)row.xedb0eb766e25e0c9.xf7866f89640a29a3(5102);
		foreach (Row row5 in x1ec770899c98a268.Rows)
		{
			xedb0eb766e25e0c9 xedb0eb766e25e0c = row5.xedb0eb766e25e0c9;
			int num5 = (int)xedb0eb766e25e0c.xf7866f89640a29a3(5102) - num;
			if (num5 != 0)
			{
				xedb0eb766e25e0c.x90aab2cbd2f48623 = num5;
			}
			if (!xedb0eb766e25e0c.x263d579af1d0d43f(4340) && num4 != 0)
			{
				xedb0eb766e25e0c.xc0741c7ff92cf1aa = num4;
			}
			xedb0eb766e25e0c.x52b190e626f65140(5102);
		}
	}

	private static void xb919b8b9539d871d(Table x1ec770899c98a268)
	{
		if (x1ec770899c98a268.FirstRow == null)
		{
			return;
		}
		xedb0eb766e25e0c9 xedb0eb766e25e0c = x1ec770899c98a268.Rows[0].xedb0eb766e25e0c9;
		object obj = xedb0eb766e25e0c.xf7866f89640a29a3(4020);
		object obj2 = xedb0eb766e25e0c.xf7866f89640a29a3(4320);
		foreach (Row row in x1ec770899c98a268.Rows)
		{
			xedb0eb766e25e0c9 xedb0eb766e25e0c2 = row.xedb0eb766e25e0c9;
			if (obj != null && xedb0eb766e25e0c2.xf7866f89640a29a3(4020) == null)
			{
				xedb0eb766e25e0c2.xcad2e59522947ede = 108;
			}
			if (obj2 != null && xedb0eb766e25e0c2.xf7866f89640a29a3(4320) == null)
			{
				xedb0eb766e25e0c2.x41c99cca24bc80be = 108;
			}
		}
	}

	private static void x5d3aa187f40ade65(Table x1ec770899c98a268)
	{
		Row row = null;
		Row row2 = x1ec770899c98a268.FirstRow;
		while (row2 != null)
		{
			if (row != null && !x709cda68cb4640ba(row, row2))
			{
				x1ec770899c98a268 = xc4afbf418adfed0a(row2);
				row = null;
				row2 = x1ec770899c98a268.FirstRow;
			}
			else
			{
				row = row2;
				row2 = row2.xebb8ac1152da9a1f;
			}
		}
	}

	private static bool x709cda68cb4640ba(Row xcae1a0532505c99e, Row x833fe507cf6b00e0)
	{
		if (!xcae1a0532505c99e.xedb0eb766e25e0c9.x44552e9e0078b0ae(x833fe507cf6b00e0.xedb0eb766e25e0c9))
		{
			return false;
		}
		if (!xcae1a0532505c99e.xedb0eb766e25e0c9.x6f6877b222ed4153)
		{
			Paragraph paragraph = (Paragraph)xcae1a0532505c99e.GetChild(NodeType.Paragraph, 0, isDeep: true);
			Paragraph paragraph2 = (Paragraph)x833fe507cf6b00e0.GetChild(NodeType.Paragraph, 0, isDeep: true);
			if (paragraph == null || paragraph2 == null)
			{
				return true;
			}
			return paragraph.x44552e9e0078b0ae(paragraph2);
		}
		return true;
	}

	private static Table xc4afbf418adfed0a(Row x788c9c27e809f956)
	{
		Table parentTable = x788c9c27e809f956.ParentTable;
		Table table = new Table(parentTable.Document);
		parentTable.ParentNode.InsertAfter(table, parentTable);
		Node node = x788c9c27e809f956;
		while (node != null)
		{
			Node nextSibling = node.NextSibling;
			node.Remove();
			table.xdf7453d9fdf3f262(node);
			node = nextSibling;
		}
		return table;
	}

	private void x6230d11d26d4e543()
	{
		x490834a62c46f14d(new Row(x232be220f517f721, null));
	}

	void xa3ed3b2cd8f77351.x2640a8e9621a900d()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6230d11d26d4e543
		this.x6230d11d26d4e543();
	}

	private void x7ff16728bead840d(xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		if (x4cbed795c600d582.NodeType != NodeType.Row)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ifbgohigbhpgkcghghnhkgeibcliahcjkgjjpgakfbhklfokcgflmamlifdmlfkmhfbnaainmepnaegohpmoheepkelpmdcaocjagppa", 1237344531)));
		}
		Row row = (Row)x4cbed795c600d582;
		if (xe193ceb565ecaa0a.xeeac8c23df57dd1d != null)
		{
			row.xedb0eb766e25e0c9 = xe193ceb565ecaa0a;
			x079628a2d66cebda(row);
			x3bd914c1d934af81(row);
			row.xedb0eb766e25e0c9.xd835e6f8c37a91bb();
			x20eec3666a2dc8d0.x945c00cb2f79f4ea(row.xedb0eb766e25e0c9);
			xee5211f6b1be16ef(row);
			row.x47ab0b351d6caf1e();
			xf5b0b9b6ff7ac462();
		}
		else
		{
			xf5b0b9b6ff7ac462();
			row.Remove();
		}
	}

	void xa3ed3b2cd8f77351.xda9f27edd6acffc8(xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x7ff16728bead840d
		this.x7ff16728bead840d(xe193ceb565ecaa0a);
	}

	private void xee5211f6b1be16ef(Row xa806b754814b9ae0)
	{
		foreach (Cell item in xa806b754814b9ae0)
		{
			if (item.xf8cef531dae89ea3.x338a5e6ab7c5595e != CellMerge.Previous)
			{
				continue;
			}
			if (item.ChildNodes.Count == 1 && item.ChildNodes[0].NodeType == NodeType.Paragraph)
			{
				Paragraph paragraph = (Paragraph)item.ChildNodes[0];
				if (paragraph.HasChildNodes)
				{
					paragraph.ChildNodes.Clear();
				}
			}
			else if (item.HasChildNodes)
			{
				item.ChildNodes.Clear();
				item.AppendChild(new Paragraph(x232be220f517f721));
			}
		}
	}

	private static void x079628a2d66cebda(Row xa806b754814b9ae0)
	{
		xdb4d596cc6b8659f xeeac8c23df57dd1d = xa806b754814b9ae0.xedb0eb766e25e0c9.xeeac8c23df57dd1d;
		Cell cell = xa806b754814b9ae0.FirstCell;
		int num = 0;
		while (cell != null && num < xeeac8c23df57dd1d.Count)
		{
			cell.xf8cef531dae89ea3 = xeeac8c23df57dd1d.get_xe6d4b1b411ed94b5(num);
			cell = cell.xb2e852052ab1c1be;
			num++;
		}
		if (cell != null)
		{
			x5699f8523a546a42.x7088fd15062d931f(cell, null);
		}
	}

	private static void x3bd914c1d934af81(Row xa806b754814b9ae0)
	{
		if (!xa806b754814b9ae0.xedb0eb766e25e0c9.x0f53f53f15b61ef5)
		{
			return;
		}
		x5fb16e270c21db2e x5fb16e270c21db2e = xa806b754814b9ae0.xedb0eb766e25e0c9.x5fb16e270c21db2e;
		xedb0eb766e25e0c9 xedb0eb766e25e0c = (xedb0eb766e25e0c9)x5fb16e270c21db2e.xdf4bcc85da8f85b2;
		xdb4d596cc6b8659f xeeac8c23df57dd1d = xedb0eb766e25e0c.xeeac8c23df57dd1d;
		if (xeeac8c23df57dd1d == null)
		{
			xa806b754814b9ae0.xedb0eb766e25e0c9.x097e4f3c708bd29c();
			return;
		}
		int num = 0;
		for (Cell cell = xa806b754814b9ae0.FirstCell; cell != null; cell = cell.xb2e852052ab1c1be)
		{
			xf8cef531dae89ea3 revPr = xeeac8c23df57dd1d.get_xe6d4b1b411ed94b5(num);
			x5fb16e270c21db2e x5fb16e270c21db2e2 = new x5fb16e270c21db2e(revPr, x5fb16e270c21db2e.xb063bbfcfeade526, x5fb16e270c21db2e.x242851e6278ed355);
			cell.xf8cef531dae89ea3.x5fb16e270c21db2e = x5fb16e270c21db2e2;
			num++;
		}
		if (num == xeeac8c23df57dd1d.Count)
		{
			return;
		}
		throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("nddabgkagfbbieibiepbcfgcnpmcjeedndldepbeedjeddafhdhfedofidfgcolgdcdhlckhobbijciidnoiobgjmbnjobekhmkkbbclcajlcbamopgmaaomflengamnhpcobpjojkapephpipopnofapnmapndbjokbejbcaoicenpcligdlmndkmeeomlelmcfpmjfjhaggmhgfmogplfhnlmhpkdijlkiilbjkkijdkpjokgkggnk", 474219247)));
	}

	private void x84038bbf4c8e4605()
	{
		x490834a62c46f14d(new Cell(x232be220f517f721, null));
	}

	void xa3ed3b2cd8f77351.x87e79416bec3e451()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x84038bbf4c8e4605
		this.x84038bbf4c8e4605();
	}

	private void xf13b078577b1ff92()
	{
		if (x4cbed795c600d582.NodeType != NodeType.Cell)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lhgmbknmejennelnjjconijoeeapeihpdiophifaeimafddblhkbcibcmcicihpclhgdhhndaceemgleagcfhbjfhgagkghgmfogoefhgbmh", 1953416758)));
		}
		xf5b0b9b6ff7ac462();
	}

	void xa3ed3b2cd8f77351.x1faff6adf1093081()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xf13b078577b1ff92
		this.xf13b078577b1ff92();
	}

	private SmartTag xb7de6aa2687498f8()
	{
		SmartTag smartTag = new SmartTag(x232be220f517f721);
		x490834a62c46f14d(smartTag);
		return smartTag;
	}

	SmartTag xa3ed3b2cd8f77351.xdd43764a658cd8b8()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xb7de6aa2687498f8
		return this.xb7de6aa2687498f8();
	}

	public void xc798bb83e23f6a08()
	{
		if (x4cbed795c600d582.NodeType == NodeType.SmartTag)
		{
			xf5b0b9b6ff7ac462();
		}
	}

	private void x2ce316733ba7b8cf(CustomXmlMarkup x2f992229ae4fc9a1)
	{
		if (!x04562d8eb06323c7.xa5f46b37320268ac(x2f992229ae4fc9a1, x4cbed795c600d582))
		{
			x490834a62c46f14d(x2f992229ae4fc9a1);
		}
	}

	void xa3ed3b2cd8f77351.xb595d21dbff3629b(CustomXmlMarkup x2f992229ae4fc9a1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x2ce316733ba7b8cf
		this.x2ce316733ba7b8cf(x2f992229ae4fc9a1);
	}

	public void x7eac7e2ac5d4302b()
	{
		if (!x04562d8eb06323c7.x8d4abec08bebbd61(x4cbed795c600d582) && x4cbed795c600d582.NodeType == NodeType.CustomXmlMarkup)
		{
			xf5b0b9b6ff7ac462();
		}
	}

	public void xb5d34e6ee4c0fad1(SubDocument x099a571ab336faf8)
	{
		x4cbed795c600d582.xdf7453d9fdf3f262(x099a571ab336faf8);
	}

	private FieldType xb094495379061fb9()
	{
		if (xd48deb218af504df.Count > 0)
		{
			FieldChar fieldChar = (FieldChar)xd48deb218af504df.Peek();
			return fieldChar.FieldType;
		}
		return FieldType.FieldNone;
	}

	FieldType xa3ed3b2cd8f77351.x58c29d68a9c691d9()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xb094495379061fb9
		return this.xb094495379061fb9();
	}

	public void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		if (xd545ef71ef25db52.WarningCallback != null)
		{
			xd545ef71ef25db52.WarningCallback.Warning(new WarningInfo(x9f91de645a9fe01a, WarningSource.Doc, xc2358fbac7da3d45));
		}
	}

	private void x490834a62c46f14d(CompositeNode x1abafc112c220cac)
	{
		x4cbed795c600d582.xdf7453d9fdf3f262(x1abafc112c220cac);
		x4cbed795c600d582 = x1abafc112c220cac;
		x58bdab3825959912();
	}

	private void xf5b0b9b6ff7ac462()
	{
		x58bdab3825959912();
		x4cbed795c600d582 = x4cbed795c600d582.ParentNode;
	}

	private void x8c81feb19d9adb77(Node xda5bf54deb817e37)
	{
		if (x4cbed795c600d582.x8a4414b7d9d4073f(xda5bf54deb817e37))
		{
			x4cbed795c600d582.xdf7453d9fdf3f262(xda5bf54deb817e37);
		}
		else
		{
			x78b4c9d9b2bebe94.Add(xda5bf54deb817e37);
		}
	}

	private void x58bdab3825959912()
	{
		if (x78b4c9d9b2bebe94.Count == 0)
		{
			return;
		}
		Node node = ((x4cbed795c600d582.NodeType == NodeType.Paragraph) ? x4cbed795c600d582 : x4cbed795c600d582.LastChild);
		if (!(node is Paragraph))
		{
			return;
		}
		foreach (Node item in x78b4c9d9b2bebe94)
		{
			((Paragraph)node).xdf7453d9fdf3f262(item);
		}
		x78b4c9d9b2bebe94.Clear();
	}
}
