using System;
using System.Collections;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Saving;
using x011d489fb9df7027;
using x2697283ff424107e;
using x28925c9b27b37a46;
using x381fb081d11d6275;
using x38d3ef1c1d247e82;
using x6c95d9cf46ff5f25;
using x7c4557e104065fc9;
using xe9865c3fb834da49;
using xf989f31a236ff98c;

namespace xce0136f05681c5e9;

internal class x754017e579b6a8ff : x611b52a649966359, xe2ff3c3cd396cfd9
{
	private Hashtable x40e8e6689fbdf4b4;

	private readonly Document x232be220f517f721;

	private readonly HtmlSaveOptions x1cb867f3d40f3203;

	private readonly Stream x83c94614e752b228;

	private readonly string xb60ae86f79aa8262;

	private x515d2f71e3e1988e x800085dd555f7711;

	private x3172fc8167520602 x9af56536cdcf0ffc;

	private x5b7780c99f08ae18 x37e6e1a37491c5a2;

	private x08802e9e984cd3ee x5a7a1d229173bf5d;

	private x202941c978357b4f x7e0bc249ae734293;

	private xe194915df8ce65e3 xc29926e1aeb3165a;

	private readonly IDictionary x15637d65c176fc79;

	private xe98f79ab11a30ea7 xbf77f1b25eb10db0;

	private xd3ee97bb1871dd1b x999b74020ae6bd49;

	private x9df536d98415d2d0 xa737d500a7554634;

	private x9e83e90818260fa5 x230c333abfdbfccd;

	private xae2987b4c36ffe56 x91c6898086a7eed1;

	private x0ce95024f2f68661 x05b7e725c9a2cde4;

	private x5eb7cf03e9047d8b x4b265686fe13f600;

	private readonly x1cfc9afea06d5324 xb4ae0d7648678478;

	private readonly xb388353c23101505 x9def3467b18564d5;

	private xd810889f5d4addbd xa056586c1f99e199;

	private x934b8a992f1985f7 xb9e6b034b22e403e;

	private x4eefe5e664198999 x12954a224495d3c0;

	private xaafc79486ac2fb8d xedb7a9026cef05ce;

	private bool xb42f2f2b9987ee29;

	private bool xef7fce0b1aeaeef2;

	x515d2f71e3e1988e xe2ff3c3cd396cfd9.x10c4d907e2ce11da => x800085dd555f7711;

	string xe2ff3c3cd396cfd9.x64b65291d3bfc528
	{
		get
		{
			if (xc29926e1aeb3165a == null)
			{
				return string.Empty;
			}
			return xc29926e1aeb3165a.x87530f3910ac4212.xfc6140fa15b50714;
		}
	}

	internal x754017e579b6a8ff(Document document, Stream stream, string fileName, HtmlSaveOptions saveOptions, x1e9b3e0e8864e135 bookmarkSet, xb388353c23101505 subsidiaryContentPartsCollector, x1cfc9afea06d5324 navigationPointCollector)
	{
		x232be220f517f721 = document;
		x83c94614e752b228 = stream;
		xb60ae86f79aa8262 = fileName;
		x1cb867f3d40f3203 = saveOptions;
		x9def3467b18564d5 = subsidiaryContentPartsCollector;
		xb4ae0d7648678478 = navigationPointCollector;
		x15637d65c176fc79 = x3c74b3c4f21844f9.x43dbf3137e50f2b1(bookmarkSet);
	}

	internal void xa2e0b7f7da663553()
	{
		xb42f2f2b9987ee29 = false;
		xc692ca1025d5045e();
		try
		{
			xe3d2f5ee6867cec8();
		}
		finally
		{
			x4d69f1dd43b92bfe();
		}
	}

	internal void x9409daed2a2588c0(Node xda5bf54deb817e37)
	{
		xb42f2f2b9987ee29 = true;
		xc692ca1025d5045e();
		try
		{
			switch (xda5bf54deb817e37.NodeType)
			{
			case NodeType.Document:
				xe3d2f5ee6867cec8();
				break;
			case NodeType.Section:
			{
				x0961d4960608be76();
				Section section = (Section)xda5bf54deb817e37;
				xf3872ac762335fc9(section);
				x1e54fa3a59f86a2a(section.Body);
				xa5b0133917c792bb(section);
				break;
			}
			case NodeType.GlossaryDocument:
				throw new InvalidOperationException("GlossaryDocument isn't supported!");
			case NodeType.BuildingBlock:
				throw new InvalidOperationException("BuildingBlock isn't supported!");
			case NodeType.Any:
			case NodeType.Body:
			case NodeType.HeaderFooter:
			case NodeType.Table:
			case NodeType.Row:
			case NodeType.Cell:
			case NodeType.Paragraph:
			case NodeType.BookmarkStart:
			case NodeType.BookmarkEnd:
			case NodeType.GroupShape:
			case NodeType.Shape:
			case NodeType.Comment:
			case NodeType.Footnote:
			case NodeType.Run:
			case NodeType.FieldStart:
			case NodeType.FieldSeparator:
			case NodeType.FieldEnd:
			case NodeType.FormField:
			case NodeType.SpecialChar:
			case NodeType.SmartTag:
			case NodeType.CustomXmlMarkup:
			case NodeType.StructuredDocumentTag:
			case NodeType.CommentRangeStart:
			case NodeType.CommentRangeEnd:
			case NodeType.DrawingML:
			case NodeType.OfficeMath:
			case NodeType.SubDocument:
			case NodeType.System:
			case NodeType.Null:
				x0961d4960608be76();
				xc8a4a99b169d7951(xda5bf54deb817e37);
				break;
			default:
				throw new InvalidOperationException("Unexpected node type.");
			}
			x800085dd555f7711.x5222f4285e37d66b.Flush();
		}
		finally
		{
			x4d69f1dd43b92bfe();
		}
	}

	internal static string x6f4063730e81a2f6(int xddd12ddd8b1e4a90)
	{
		return xddd12ddd8b1e4a90 switch
		{
			1 => "h1", 
			2 => "h2", 
			3 => "h3", 
			4 => "h4", 
			5 => "h5", 
			6 => "h6", 
			_ => "p", 
		};
	}

	internal override VisitorAction x1b08a07a3132f8bc(Paragraph x41baca1d6c0c2e8e)
	{
		if (xc29926e1aeb3165a != null)
		{
			x49ab465c82380c81 x87530f3910ac = xc29926e1aeb3165a.x87530f3910ac4212;
			if (x87530f3910ac.x623e5421ca876274 == x41baca1d6c0c2e8e)
			{
				if (!xc29926e1aeb3165a.xb96865188f6d0634())
				{
					x999b74020ae6bd49.x75be698bf0c3a5c5();
					return VisitorAction.SkipThisNode;
				}
				x9af56536cdcf0ffc.xd7696af0a28b1b06();
				xa5b0133917c792bb(x41baca1d6c0c2e8e.ParentSection);
				x1f7c9091b1efd598();
				x800085dd555f7711.x718c3268815fe948();
				xc29926e1aeb3165a.xa16cce94188a69d4();
				x87530f3910ac = xc29926e1aeb3165a.x87530f3910ac4212;
				x800085dd555f7711 = new x515d2f71e3e1988e(x87530f3910ac.x3d213ffad4d30370.x59aa197935be8c77(), x1cb867f3d40f3203);
				x800085dd555f7711.x6737a86fba7f7993();
				xe632fc3303375cb6();
				x6b4c82286d3fd913();
				xf3872ac762335fc9(x41baca1d6c0c2e8e.ParentSection);
			}
		}
		x1a78664fa10a3755 x1a78664fa10a = x41baca1d6c0c2e8e.x2e12c5f9278ae233(xd9bc7f7e70d71e14.x2be08ba736aa04f0 | xd9bc7f7e70d71e14.x3968babb3b57e478);
		x4b265686fe13f600.x4bf36104951aa017(x41baca1d6c0c2e8e, x1a78664fa10a, x1cb867f3d40f3203.AllowNegativeIndent);
		if (!x41baca1d6c0c2e8e.HasChildNodes && x41baca1d6c0c2e8e.IsEndOfSection && !x41baca1d6c0c2e8e.IsEndOfDocument && !x41baca1d6c0c2e8e.ParentStory.x74f5d3c8c1c169b6)
		{
			x4b265686fe13f600.x7557112ace708bcd(x41baca1d6c0c2e8e);
			return VisitorAction.SkipThisNode;
		}
		if (x41baca1d6c0c2e8e.xefd689c2d1a39911)
		{
			if (x41baca1d6c0c2e8e.LastChild is Shape)
			{
				Shape shape = (Shape)x41baca1d6c0c2e8e.LastChild;
				if (shape.IsHorizontalRule)
				{
					shape.Accept(x999b74020ae6bd49);
					x4b265686fe13f600.x7557112ace708bcd(x41baca1d6c0c2e8e);
					return VisitorAction.SkipThisNode;
				}
			}
			else if (x41baca1d6c0c2e8e.LastChild is Run)
			{
				Run run = (Run)x41baca1d6c0c2e8e.LastChild;
				string text = run.Text;
				if (text.Length != 0 && x0d299f323d241756.x0fb62ca630231ea1(text))
				{
					Paragraph paragraph = (Paragraph)x41baca1d6c0c2e8e.Clone(isCloneChildren: true);
					((Run)paragraph.LastChild).Text = ControlChar.NonBreakingSpace;
					paragraph.Accept(x999b74020ae6bd49);
					x4b265686fe13f600.x7557112ace708bcd(x41baca1d6c0c2e8e);
					return VisitorAction.SkipThisNode;
				}
			}
		}
		xa737d500a7554634.x00149f2495b0f026(x41baca1d6c0c2e8e.x1a78664fa10a3755.x554aca059bdf6d48);
		if (x41baca1d6c0c2e8e.xbc0119d7471ef12e)
		{
			x4d0bcf7689303f7e(x41baca1d6c0c2e8e);
			x9af56536cdcf0ffc.x18dd6bff0a34aaf3(x41baca1d6c0c2e8e, x1a78664fa10a, x4b265686fe13f600.xd34a71082d00660c);
		}
		else
		{
			x9af56536cdcf0ffc.xd7696af0a28b1b06();
			x800085dd555f7711.x2307058321cdb62f(x6f4063730e81a2f6(x1a78664fa10a.x8301ab10c226b0c2));
			if (xb4ae0d7648678478 != null)
			{
				xb4ae0d7648678478.x84bc62e29f758549(x094308e428eb5b33: false, x41baca1d6c0c2e8e, x1a78664fa10a);
			}
			x7e0bc249ae734293.x23c8b7ad9bfc5719(x41baca1d6c0c2e8e, x1a78664fa10a, x1ebf5501f9a725fb: false, x4b265686fe13f600.xd34a71082d00660c);
			xbf77f1b25eb10db0.xb63df339721c535a(x41baca1d6c0c2e8e, x1a78664fa10a);
		}
		x37e6e1a37491c5a2.x57a5d79d9b9d67f5();
		x230c333abfdbfccd.x7e7f331e0d5f065a();
		return VisitorAction.Continue;
	}

	internal override VisitorAction xa2e5fe5057cd7778(Paragraph x41baca1d6c0c2e8e)
	{
		xa737d500a7554634.xbcd358ebb8d4e95e();
		x5a7a1d229173bf5d.x4870ccdb67430ef1(x41baca1d6c0c2e8e);
		x230c333abfdbfccd.xd5a7d506e4113f23();
		if (xef7fce0b1aeaeef2)
		{
			xef7fce0b1aeaeef2 = false;
		}
		else
		{
			x800085dd555f7711.x538f0e0fb2bf15ab();
		}
		x4b265686fe13f600.x7557112ace708bcd(x41baca1d6c0c2e8e);
		return VisitorAction.Continue;
	}

	internal override VisitorAction x9a7ad1735553086c(Inline x31545d7c306a55e4)
	{
		bool flag = false;
		if (xc29926e1aeb3165a != null)
		{
			x49ab465c82380c81 x87530f3910ac = xc29926e1aeb3165a.x87530f3910ac4212;
			int num = 0;
			while (x87530f3910ac.x623e5421ca876274 == x31545d7c306a55e4)
			{
				flag = true;
				string text = x31545d7c306a55e4.GetText();
				if (x87530f3910ac.x71a8a0811812e457 > num)
				{
					string xb41faee6912a = text.Substring(num, x87530f3910ac.x71a8a0811812e457 - num);
					x5a7a1d229173bf5d.xd22cb714335f8d2c(xb41faee6912a, x31545d7c306a55e4.Font);
				}
				if (!xc29926e1aeb3165a.xb96865188f6d0634())
				{
					x999b74020ae6bd49.x75be698bf0c3a5c5();
					return VisitorAction.SkipThisNode;
				}
				x800085dd555f7711.x538f0e0fb2bf15ab();
				x9af56536cdcf0ffc.xd7696af0a28b1b06();
				xa5b0133917c792bb(x31545d7c306a55e4.ParentParagraph.ParentSection);
				x1f7c9091b1efd598();
				x800085dd555f7711.x718c3268815fe948();
				xc29926e1aeb3165a.xa16cce94188a69d4();
				x87530f3910ac = xc29926e1aeb3165a.x87530f3910ac4212;
				x800085dd555f7711 = new x515d2f71e3e1988e(x87530f3910ac.x3d213ffad4d30370.x59aa197935be8c77(), x1cb867f3d40f3203);
				x800085dd555f7711.x6737a86fba7f7993();
				xe632fc3303375cb6();
				x6b4c82286d3fd913();
				xf3872ac762335fc9(x31545d7c306a55e4.ParentParagraph.ParentSection);
				Node node = x87530f3910ac.x7276106b7b402510;
				while (node != null && !(node is Inline))
				{
					node = node.NextSibling;
				}
				if (node is Inline)
				{
					xef7fce0b1aeaeef2 = false;
					Paragraph parentParagraph = ((Inline)node).ParentParagraph;
					x1a78664fa10a3755 x1a78664fa10a = parentParagraph.x2e12c5f9278ae233(xd9bc7f7e70d71e14.x2be08ba736aa04f0 | xd9bc7f7e70d71e14.x3968babb3b57e478);
					x800085dd555f7711.x2307058321cdb62f(x6f4063730e81a2f6(x1a78664fa10a.x8301ab10c226b0c2));
					x7e0bc249ae734293.x23c8b7ad9bfc5719(parentParagraph, x1a78664fa10a, x1ebf5501f9a725fb: false, x4ef6b4f19b033b48.x526d6c6f824cda87);
				}
				else
				{
					xef7fce0b1aeaeef2 = true;
				}
				if (x87530f3910ac.x7276106b7b402510 == x31545d7c306a55e4)
				{
					num = x87530f3910ac.xe4790ba9e7571be3;
					if (x87530f3910ac.x623e5421ca876274 != x31545d7c306a55e4)
					{
						string xb41faee6912a2 = text.Substring(num);
						x5a7a1d229173bf5d.xd22cb714335f8d2c(xb41faee6912a2, x31545d7c306a55e4.Font);
					}
				}
			}
		}
		if (!flag)
		{
			bool x0392c0938d22c = x31545d7c306a55e4.xeedad81aaed42a76.x0392c0938d22c790;
			bool xba4e1d8a3e3316c = x31545d7c306a55e4.xeedad81aaed42a76.xba4e1d8a3e3316c8;
			if (x0392c0938d22c)
			{
				x800085dd555f7711.x2307058321cdb62f("del");
			}
			if (xba4e1d8a3e3316c)
			{
				x800085dd555f7711.x2307058321cdb62f("ins");
			}
			xa737d500a7554634.x00149f2495b0f026(x31545d7c306a55e4.xeedad81aaed42a76.x554aca059bdf6d48);
			x5a7a1d229173bf5d.x5c6f8dca650ee955(x31545d7c306a55e4);
			xa737d500a7554634.xbcd358ebb8d4e95e();
			if (xba4e1d8a3e3316c)
			{
				x800085dd555f7711.x2dfde153f4ef96d0();
			}
			if (x0392c0938d22c)
			{
				x800085dd555f7711.x2dfde153f4ef96d0();
			}
		}
		return VisitorAction.Continue;
	}

	internal override VisitorAction x1b12ad7e0ad0df34(Footnote x897ec71a9f9588a0)
	{
		return x37e6e1a37491c5a2.x1b12ad7e0ad0df34(x897ec71a9f9588a0);
	}

	internal override VisitorAction x29a51827c03d354b(Footnote x897ec71a9f9588a0)
	{
		x9af56536cdcf0ffc.xd7696af0a28b1b06();
		return x37e6e1a37491c5a2.xee9310aa5d10b7e3(x897ec71a9f9588a0);
	}

	internal override void x27335b788ad093c5(Shape x5770cdefd8931aa9, ShapeBase x8739b0dd3627f37e, bool x43fd17e7d75faf32, string x50a18ad2656e7181, double x9b0739496f8b5475, double x4d5aabc7a55b12ba, string x916e73d84a52710c)
	{
		x800085dd555f7711.x2307058321cdb62f("img");
		x800085dd555f7711.xff520a0047c27122("src", x50a18ad2656e7181);
		x800085dd555f7711.x55b893148f746a6f("width", x4574ea26106f0edb.xdbd829479885762d(x9b0739496f8b5475));
		x800085dd555f7711.x55b893148f746a6f("height", x4574ea26106f0edb.xdbd829479885762d(x4d5aabc7a55b12ba));
		x800085dd555f7711.xff520a0047c27122("alt", x8739b0dd3627f37e.AlternativeText);
		x7e0bc249ae734293.x9566076cef3a2874(x5770cdefd8931aa9, x8739b0dd3627f37e, x43fd17e7d75faf32);
		x800085dd555f7711.x2dfde153f4ef96d0();
		if (x5770cdefd8931aa9 != null && x8739b0dd3627f37e.WrapType == WrapType.TopBottom)
		{
			x800085dd555f7711.xd52401bdf5aacef6("<br />");
		}
	}

	internal override void x51ff2e1c5d5075fd(Shape x5770cdefd8931aa9)
	{
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
		x6c285a52cba39f1f x6c285a52cba39f1f = x5770cdefd8931aa9.x6c285a52cba39f1f;
		if (x6c285a52cba39f1f.x9472539ef71e166c != 0.0)
		{
			xa3fc7dcdc8182ff.xb2275198aa955331("width", x6c285a52cba39f1f.x9472539ef71e166c);
		}
		else
		{
			xa3fc7dcdc8182ff.xd6d0700e6673d965("width", x4574ea26106f0edb.xdbd829479885762d(x5770cdefd8931aa9.Width), x0ec035c4a2d07fb6.x6dff714fed7f3a8a);
		}
		xa3fc7dcdc8182ff.xd6d0700e6673d965("height", x4574ea26106f0edb.xdbd829479885762d(x5770cdefd8931aa9.Height), x0ec035c4a2d07fb6.x6dff714fed7f3a8a);
		xa3fc7dcdc8182ff.xf0ca15702ca7498c("text-align", x495fdb45f3d92b70.x083645b9ab54da6f(x6c285a52cba39f1f.xceaa36575b797b5b));
		if (x6c285a52cba39f1f.xeba9aeb9e91e933a)
		{
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("border", "none");
			xa3fc7dcdc8182ff.xf4868abd18f579a7("color", x5770cdefd8931aa9.Fill.x63b1a7c31a962459);
		}
		x91c6898086a7eed1.x785e6a97c5e8f7ca(xa3fc7dcdc8182ff.x9a706f5d15bd6d95(x1cb867f3d40f3203.PrettyFormat));
	}

	internal override void xb5fb564b7a85b58c(AbsolutePositionTab x067d6ddeefb41622)
	{
		xa056586c1f99e199.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, "Absolute position tabs are not supported in HTML, using regular tab character.");
	}

	internal override void x7b60b74ac6a53b3f(Font x26094932cf7a9139, bool xf544375d86767c28)
	{
		x12954a224495d3c0.x7e87e53a0ba2f770(x26094932cf7a9139, "&#xa0;", x000f21cbda739311.x175297738c8b8d1e, x07532f30a274f493: false, xf544375d86767c28);
	}

	private string x239fd56832a10dba(string x585da4d9795fa783)
	{
		if (x0d4d45882065c63e.xbf8774d82d777b9e(x585da4d9795fa783))
		{
			string text = x585da4d9795fa783.Substring(1);
			if (x15637d65c176fc79 != null)
			{
				object obj = x15637d65c176fc79[text];
				if (obj != null)
				{
					x585da4d9795fa783 = '#' + (string)obj;
				}
			}
			if (xc29926e1aeb3165a != null)
			{
				x49ab465c82380c81 x49ab465c82380c82 = xc29926e1aeb3165a.xc928e65fed6bfe21(text);
				if (x49ab465c82380c82 != null && x49ab465c82380c82 != xc29926e1aeb3165a.x87530f3910ac4212)
				{
					x585da4d9795fa783 = x49ab465c82380c82.xfc6140fa15b50714 + x585da4d9795fa783;
				}
			}
		}
		return x585da4d9795fa783;
	}

	string xe2ff3c3cd396cfd9.xb3b0ef5bb7f5a407(string x585da4d9795fa783)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x239fd56832a10dba
		return this.x239fd56832a10dba(x585da4d9795fa783);
	}

	private void x75df67695a23e766(Node xda5bf54deb817e37)
	{
		xda5bf54deb817e37.Accept(x999b74020ae6bd49);
	}

	void xe2ff3c3cd396cfd9.xc93e761169bf41b6(Node xda5bf54deb817e37)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x75df67695a23e766
		this.x75df67695a23e766(xda5bf54deb817e37);
	}

	private void xc692ca1025d5045e()
	{
		x40e8e6689fbdf4b4 = new Hashtable();
		xa056586c1f99e199 = new xd810889f5d4addbd(x1cb867f3d40f3203.WarningCallback);
		xa737d500a7554634 = new x9df536d98415d2d0();
		x91c6898086a7eed1 = new xae2987b4c36ffe56(this);
		xbf77f1b25eb10db0 = new xe98f79ab11a30ea7(x232be220f517f721, x1cb867f3d40f3203.ExportLanguageInformation, this);
		x230c333abfdbfccd = new x9e83e90818260fa5(x232be220f517f721, x1cb867f3d40f3203.x4e3c1d16eaf20ef3, this);
		x0de10523530ef89b bookmarkWriter = new x0de10523530ef89b(x230c333abfdbfccd, this, x15637d65c176fc79, x1cb867f3d40f3203.xa0d41f9ce07d80f7);
		x37e6e1a37491c5a2 = new x5b7780c99f08ae18(x232be220f517f721, this, x230c333abfdbfccd, x91c6898086a7eed1, bookmarkWriter);
		x05b7e725c9a2cde4 = new x0ce95024f2f68661(this, x230c333abfdbfccd, x1cb867f3d40f3203.xcd1c64d43058619d, x82205aaa78b9d3c8());
		x7e0bc249ae734293 = xe6fc89acab97079a();
		x12954a224495d3c0 = new x4eefe5e664198999(x232be220f517f721, this, x7e0bc249ae734293, xbf77f1b25eb10db0);
		xb9e6b034b22e403e = new x934b8a992f1985f7(this, x7e0bc249ae734293, xbf77f1b25eb10db0, x1cb867f3d40f3203.ExportXhtmlTransitional, xb42f2f2b9987ee29);
		xedb7a9026cef05ce = new xaafc79486ac2fb8d(x12954a224495d3c0, this, xb9e6b034b22e403e);
		x5a7a1d229173bf5d = new x08802e9e984cd3ee(xedb7a9026cef05ce, x232be220f517f721.CompatibilityOptions);
		x9af56536cdcf0ffc = new x3172fc8167520602(x232be220f517f721, x1cb867f3d40f3203, xbf77f1b25eb10db0, this, x5a7a1d229173bf5d, x7e0bc249ae734293, xb4ae0d7648678478);
		x4b265686fe13f600 = new x5eb7cf03e9047d8b(this);
		xce89a940b8f5ff3f fieldWriter = new xce89a940b8f5ff3f(x232be220f517f721, x1cb867f3d40f3203, x5a7a1d229173bf5d, x230c333abfdbfccd, this, x12954a224495d3c0);
		x3d213ffad4d30370 x3d213ffad4d = new x3d213ffad4d30370(x83c94614e752b228, keepStreamOpen: true);
		if (x1cb867f3d40f3203.DocumentSplitCriteria != 0)
		{
			xc29926e1aeb3165a = new xe194915df8ce65e3(x232be220f517f721, xb60ae86f79aa8262, x83c94614e752b228, x1cb867f3d40f3203, fieldWriter, xb4ae0d7648678478, x9def3467b18564d5);
			xc29926e1aeb3165a.xa16cce94188a69d4();
			x3d213ffad4d = xc29926e1aeb3165a.x87530f3910ac4212.x3d213ffad4d30370;
		}
		x800085dd555f7711 = new x515d2f71e3e1988e(x3d213ffad4d.x59aa197935be8c77(), x1cb867f3d40f3203);
		x999b74020ae6bd49 = new xd3ee97bb1871dd1b(x232be220f517f721, x9af56536cdcf0ffc, this, fieldWriter, bookmarkWriter, xb9e6b034b22e403e, xa056586c1f99e199, xa737d500a7554634, x05b7e725c9a2cde4);
		if (xb4ae0d7648678478 != null)
		{
			xb4ae0d7648678478.xd586e0c16bdae7fc(this);
		}
	}

	private void x4d69f1dd43b92bfe()
	{
		if (xc29926e1aeb3165a != null)
		{
			xc29926e1aeb3165a.x259ca409802dc39e();
		}
		else if (xb4ae0d7648678478 != null)
		{
			xb4ae0d7648678478.x8617c5c184975779(null);
		}
	}

	private void x4d0bcf7689303f7e(Paragraph x41baca1d6c0c2e8e)
	{
		if (xb9e6b034b22e403e.xf7499ae99c6308ad)
		{
			return;
		}
		for (Node node = x41baca1d6c0c2e8e.FirstChild; node != null; node = node.NextSibling)
		{
			if (node is Inline)
			{
				string text = node.GetText();
				for (int i = 0; i < text.Length; i++)
				{
					switch (text[i])
					{
					default:
						return;
					case '\f':
						x3040533267161e7e(x1a0fa6de95012f15: false);
						break;
					case '\u000e':
						x3040533267161e7e(x1a0fa6de95012f15: true);
						break;
					case '\r':
						return;
					}
				}
			}
		}
	}

	private x8aa64ac02744cab2 x82205aaa78b9d3c8()
	{
		return new x8aa64ac02744cab2(xb60ae86f79aa8262, x9def3467b18564d5, x1cb867f3d40f3203.ImagesFolder, x1cb867f3d40f3203.ImagesFolderAlias, xb42f2f2b9987ee29 ? "Image file cannot be written to disk. When saving the node ImagesFolder should be specified or custom streams should be provided via ImageSavingCallback or ExportImagesAsBase64 option should be true. Please see documentation for details." : "Image file cannot be written to disk. When saving the document to a stream either ImagesFolder should be specified or custom streams should be provided via ImageSavingCallback. Please see documentation for details.", x1cb867f3d40f3203.x4e3c1d16eaf20ef3);
	}

	private x202941c978357b4f xe6fc89acab97079a()
	{
		return x1cb867f3d40f3203.CssStyleSheetType switch
		{
			CssStyleSheetType.Inline => new x3614a6a114a0765e(x232be220f517f721, xb42f2f2b9987ee29, x1cb867f3d40f3203, xa737d500a7554634, this, x05b7e725c9a2cde4, xa056586c1f99e199), 
			CssStyleSheetType.Embedded => new x26a1fc363fa95c48(x232be220f517f721, xb42f2f2b9987ee29, x1cb867f3d40f3203, xa737d500a7554634, this, x05b7e725c9a2cde4, xa056586c1f99e199), 
			CssStyleSheetType.External => new xd266699f0c70692c(x232be220f517f721, xb42f2f2b9987ee29, x1cb867f3d40f3203, xb60ae86f79aa8262, xa737d500a7554634, this, x05b7e725c9a2cde4, x9def3467b18564d5, xa056586c1f99e199), 
			_ => throw new InvalidOperationException("Unknown CSS style sheet type."), 
		};
	}

	private x0b5dc0975ab4c286 x655d2b002758d749()
	{
		return new x0b5dc0975ab4c286(xb60ae86f79aa8262, x9def3467b18564d5, x1cb867f3d40f3203.FontsFolder, x1cb867f3d40f3203.FontsFolderAlias, xb42f2f2b9987ee29 ? "Font file cannot be written to disk. When saving the node either FontsFolder should be specified or custom streams should be provided via FontSavingCallback. Please see documentation for details." : "Font file cannot be written to disk. When saving the document to a stream either FontsFolder should be specified or custom streams should be provided via FontSavingCallback. Please see documentation for details.");
	}

	private void xe3d2f5ee6867cec8()
	{
		x800085dd555f7711.x6737a86fba7f7993();
		xe632fc3303375cb6();
		xd7560e2140c6338f();
		x800085dd555f7711.x718c3268815fe948();
	}

	private void xe632fc3303375cb6()
	{
		x800085dd555f7711.x2307058321cdb62f("head");
		x800085dd555f7711.x2307058321cdb62f("meta");
		x800085dd555f7711.xff520a0047c27122("http-equiv", "Content-Type");
		string arg = (x0d299f323d241756.x5959bccb67bbf051(x1cb867f3d40f3203.xea0d040d38d75a91) ? x1cb867f3d40f3203.xea0d040d38d75a91 : "text/html");
		x800085dd555f7711.xff520a0047c27122("content", $"{arg}; charset={x1cb867f3d40f3203.Encoding.HeaderName}");
		x800085dd555f7711.x2dfde153f4ef96d0();
		x800085dd555f7711.x2307058321cdb62f("meta");
		x800085dd555f7711.xff520a0047c27122("http-equiv", "Content-Style-Type");
		x800085dd555f7711.xff520a0047c27122("content", "text/css");
		x800085dd555f7711.x2dfde153f4ef96d0("meta");
		x800085dd555f7711.x7b7fba84e16aed73("description", x232be220f517f721.BuiltInDocumentProperties.Subject);
		x800085dd555f7711.x7b7fba84e16aed73("keywords", x232be220f517f721.BuiltInDocumentProperties.Keywords);
		if (x1cb867f3d40f3203.xbfa4c2c3efbf56fd)
		{
			x800085dd555f7711.x7b7fba84e16aed73("generator", "Aspose.Words for .NET 11.9.0.0");
		}
		x800085dd555f7711.x2307058321cdb62f("title");
		x800085dd555f7711.x3d1be38abe5723e3(x232be220f517f721.BuiltInDocumentProperties.Title);
		x800085dd555f7711.x538f0e0fb2bf15ab("title");
		x0961d4960608be76();
		if (x1cb867f3d40f3203.ExportDocumentProperties)
		{
			x800085dd555f7711.xd52401bdf5aacef6("\r\n<!--[if gte mso 9]><xml>\r\n");
			x311bb10d5871a09f.xfb2c8e68dcdb7b29(x232be220f517f721, x800085dd555f7711, x5060af8676e106e7: true);
			x800085dd555f7711.xd52401bdf5aacef6("\r\n</xml><![endif]-->\r\n");
		}
		x800085dd555f7711.x538f0e0fb2bf15ab("head");
	}

	private ArrayList x1de552288b8d7264()
	{
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(x1fa178e5b1a6f2e6());
		arrayList.AddRange(x7e0bc249ae734293.xdbfcc0f818df30a4());
		arrayList.AddRange(xf2a9b9d01176fba8());
		return arrayList;
	}

	private ArrayList xf2a9b9d01176fba8()
	{
		ArrayList arrayList = new ArrayList();
		if (!x1cb867f3d40f3203.ExportPageSetup)
		{
			return arrayList;
		}
		for (int i = 0; i < x232be220f517f721.Sections.Count; i++)
		{
			xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
			x015eb412e40a664b.x4d70d8740f6f39fa(x232be220f517f721.Sections[i].PageSetup, xa3fc7dcdc8182ff);
			arrayList.Add(new x63101ab0f6a74e8f($"@page Section{i + 1}", xa3fc7dcdc8182ff));
			xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff2 = new xa3fc7dcdc8182ff6();
			xa3fc7dcdc8182ff2.x566936ceeb951bac("page", $"Section{i + 1}");
			arrayList.Add(new x63101ab0f6a74e8f($"div.Section{i + 1}", xa3fc7dcdc8182ff2));
		}
		return arrayList;
	}

	private ArrayList x1fa178e5b1a6f2e6()
	{
		ArrayList arrayList = new ArrayList();
		if (x1cb867f3d40f3203.ExportFontResources)
		{
			x0b5dc0975ab4c286 x0b5dc0975ab4c287 = x655d2b002758d749();
			arrayList.AddRange(x0b5dc0975ab4c287.xddf78efd6737dab2(x232be220f517f721, x1cb867f3d40f3203));
		}
		return arrayList;
	}

	private void x0961d4960608be76()
	{
		ArrayList xa35f58bbe907c = x1de552288b8d7264();
		x7e0bc249ae734293.x0961d4960608be76(xa35f58bbe907c);
	}

	private void xd7560e2140c6338f()
	{
		x6b4c82286d3fd913();
		for (Node node = x232be220f517f721.FirstChild; node != null; node = node.NextSibling)
		{
			x51ee56decc29a9da((Section)node);
		}
		x1f7c9091b1efd598();
	}

	private void x6b4c82286d3fd913()
	{
		x800085dd555f7711.x2307058321cdb62f("body");
		xbf77f1b25eb10db0.x83da4d952172728a();
		x1ff2babc66863cc4();
	}

	private void x1f7c9091b1efd598()
	{
		x37e6e1a37491c5a2.xcc50320bd895cb0a();
		x800085dd555f7711.x538f0e0fb2bf15ab();
	}

	private void x1ff2babc66863cc4()
	{
		if (x232be220f517f721.ViewOptions.DisplayBackgroundShape)
		{
			Shape backgroundShape = x232be220f517f721.BackgroundShape;
			if (backgroundShape != null && backgroundShape.Filled)
			{
				xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
				xa3fc7dcdc8182ff.xf4868abd18f579a7("background", backgroundShape.Fill.x63b1a7c31a962459);
				x800085dd555f7711.xff520a0047c27122("style", xa3fc7dcdc8182ff.x9a706f5d15bd6d95(x1cb867f3d40f3203.PrettyFormat));
				Shading shading = new Shading();
				shading.x0e18178ac4b2272f = backgroundShape.Fill.x63b1a7c31a962459;
				xa737d500a7554634.x00149f2495b0f026(shading);
			}
		}
	}

	private void x51ee56decc29a9da(Section xb32f8dd719a105db)
	{
		bool flag = false;
		if (xc29926e1aeb3165a != null)
		{
			x49ab465c82380c81 x87530f3910ac = xc29926e1aeb3165a.x87530f3910ac4212;
			if (x87530f3910ac.x623e5421ca876274 == xb32f8dd719a105db)
			{
				x9af56536cdcf0ffc.xd7696af0a28b1b06();
				x1f7c9091b1efd598();
				x800085dd555f7711.x718c3268815fe948();
				flag = xc29926e1aeb3165a.xa16cce94188a69d4();
				x87530f3910ac = xc29926e1aeb3165a.x87530f3910ac4212;
				x800085dd555f7711 = new x515d2f71e3e1988e(x87530f3910ac.x3d213ffad4d30370.x59aa197935be8c77(), x1cb867f3d40f3203);
				x800085dd555f7711.x6737a86fba7f7993();
				xe632fc3303375cb6();
				x6b4c82286d3fd913();
			}
		}
		if (!x999b74020ae6bd49.x991897f13cf6aadc)
		{
			if (!flag && !xb32f8dd719a105db.x65c77554c620f590 && !x1cb867f3d40f3203.x4e3c1d16eaf20ef3)
			{
				x800085dd555f7711.x2307058321cdb62f("br");
				xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
				x015eb412e40a664b.x1932c9c786040b85(xb32f8dd719a105db.PageSetup.SectionStart, xa3fc7dcdc8182ff);
				x800085dd555f7711.xff520a0047c27122("style", xa3fc7dcdc8182ff.x9a706f5d15bd6d95(x1cb867f3d40f3203.PrettyFormat));
				x800085dd555f7711.x2dfde153f4ef96d0();
			}
			xf3872ac762335fc9(xb32f8dd719a105db);
		}
		x1e54fa3a59f86a2a(xb32f8dd719a105db.Body);
		if (!x999b74020ae6bd49.x991897f13cf6aadc)
		{
			xa5b0133917c792bb(xb32f8dd719a105db);
		}
	}

	private void xf3872ac762335fc9(Section xb32f8dd719a105db)
	{
		x800085dd555f7711.x2307058321cdb62f("div");
		x7e0bc249ae734293.xf567f5aadd93f9a8(xb32f8dd719a105db);
		xbf77f1b25eb10db0.xb63df339721c535a(xb32f8dd719a105db);
		x6075c9125351e131(xb32f8dd719a105db, HeaderFooterType.HeaderPrimary);
	}

	private void xa5b0133917c792bb(Section xb32f8dd719a105db)
	{
		x6075c9125351e131(xb32f8dd719a105db, HeaderFooterType.FooterPrimary);
		x800085dd555f7711.x538f0e0fb2bf15ab();
	}

	private void x1e54fa3a59f86a2a(Body x721b2192f9b85c66)
	{
		if (x721b2192f9b85c66 != null)
		{
			xc8a4a99b169d7951(x721b2192f9b85c66);
		}
	}

	private void x6075c9125351e131(Section xb32f8dd719a105db, HeaderFooterType xa685fef1a31f5d4d)
	{
		HeaderFooter headerFooter = null;
		switch (x1cb867f3d40f3203.ExportHeadersFootersMode)
		{
		case ExportHeadersFootersMode.PerSection:
			headerFooter = xbfa03c1f542da4fb(xb32f8dd719a105db, xa685fef1a31f5d4d);
			break;
		case ExportHeadersFootersMode.FirstSectionHeaderLastSectionFooter:
			headerFooter = xbfa03c1f542da4fb(xb32f8dd719a105db, xa685fef1a31f5d4d);
			if ((xa685fef1a31f5d4d == HeaderFooterType.HeaderPrimary && !xb32f8dd719a105db.x65c77554c620f590) || (xa685fef1a31f5d4d == HeaderFooterType.FooterPrimary && !xb32f8dd719a105db.x16479f42fe4547f2))
			{
				headerFooter = null;
			}
			break;
		}
		if (headerFooter != null)
		{
			xc8a4a99b169d7951(headerFooter);
		}
	}

	private HeaderFooter xbfa03c1f542da4fb(Section xb32f8dd719a105db, HeaderFooterType xa685fef1a31f5d4d)
	{
		HeaderFooter headerFooter = xb32f8dd719a105db.HeadersFooters[xa685fef1a31f5d4d];
		if (headerFooter != null && !headerFooter.IsLinkedToPrevious)
		{
			x40e8e6689fbdf4b4[xa685fef1a31f5d4d] = headerFooter;
		}
		else
		{
			headerFooter = (HeaderFooter)x40e8e6689fbdf4b4[xa685fef1a31f5d4d];
		}
		return headerFooter;
	}

	private void xc8a4a99b169d7951(Node xda5bf54deb817e37)
	{
		xda5bf54deb817e37.Accept(x999b74020ae6bd49);
		x9af56536cdcf0ffc.xd7696af0a28b1b06();
	}

	private void x3040533267161e7e(bool x1a0fa6de95012f15)
	{
		xedb7a9026cef05ce.x7f14e8973965e158();
		x9af56536cdcf0ffc.xd7696af0a28b1b06();
		string xbcea506a33cf = (x1a0fa6de95012f15 ? "mso-column-break-before:always; clear:both" : "page-break-before:always; clear:both");
		x800085dd555f7711.x2307058321cdb62f("br");
		x800085dd555f7711.xff520a0047c27122("style", xbcea506a33cf);
		x800085dd555f7711.x2dfde153f4ef96d0();
	}
}
