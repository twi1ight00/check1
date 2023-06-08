using System;
using System.Collections;
using System.IO;
using System.Text;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Lists;
using Aspose.Words.Markup;
using Aspose.Words.Math;
using Aspose.Words.Saving;
using Aspose.Words.Tables;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x556d8f9846e43329;
using x6c95d9cf46ff5f25;
using xa604c4d210ae0581;
using xf989f31a236ff98c;
using xfbd1009a0cbb9842;

namespace x639ad3f66698fe1b;

internal class x93beff1c2303c6fc : DocumentVisitor, x3d2908992e1d1667, x7d1c3cf590044820
{
	private x21f0d20d41203be1 x8cedcaa9a62c6e39;

	private MemoryStream x2741d82719d58153;

	private Stream x59578ef35ed89c46;

	private x660b5ce02cc71bca xc310dfbfd8843d1b;

	private xaa6547801b39e385 x432326848f529fe4;

	private Stack x60dc5b79e3827efc;

	private bool xfcb2f38d2624882c;

	private bool x3c319b64ad5a4399;

	private StringBuilder xd2daee3ef30c2b61;

	private bool x81e8850b427d39a3;

	private FieldStart x98ae5cd4572ef0e8;

	private int x68936f0cacd103a9;

	private IWarningCallback xa056586c1f99e199;

	private readonly Stack xdbbc2c1800d67523 = new Stack();

	private xbfd162a6d47f59a4 xe1410f585439c7d4 => x8cedcaa9a62c6e39.xe1410f585439c7d4;

	private SaveOutputParameters x8cac5adfe79bc025(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		x5ac1382edb7bf2c2.x95f46c00b56409c0();
		xa056586c1f99e199 = x5ac1382edb7bf2c2.xf57de0fd37d5e97d.WarningCallback;
		x59578ef35ed89c46 = x5ac1382edb7bf2c2.xb8a774e0111d0fbe;
		x2741d82719d58153 = new MemoryStream();
		x8cedcaa9a62c6e39 = new x21f0d20d41203be1(x5ac1382edb7bf2c2, this, new x0462f8ecc269ec42(x2741d82719d58153));
		xc310dfbfd8843d1b = new x660b5ce02cc71bca(x8cedcaa9a62c6e39);
		x432326848f529fe4 = new xaa6547801b39e385(x8cedcaa9a62c6e39);
		x60dc5b79e3827efc = new Stack();
		x3c319b64ad5a4399 = false;
		xd2daee3ef30c2b61 = new StringBuilder();
		x5029282bb0fa892a();
		x8cedcaa9a62c6e39.x2c8c6741422a1298.Accept(this);
		return new SaveOutputParameters("application/rtf");
	}

	SaveOutputParameters x3d2908992e1d1667.xa2e0b7f7da663553(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8cac5adfe79bc025
		return this.x8cac5adfe79bc025(x5ac1382edb7bf2c2);
	}

	private void x5029282bb0fa892a()
	{
		foreach (Style style in x8cedcaa9a62c6e39.x2c8c6741422a1298.Styles)
		{
			if (style.Type == StyleType.Paragraph && style.xe709b224f455b863 == 4095)
			{
				style.Font.Size = style.Font.Size;
				style.Font.SizeBi = style.Font.SizeBi;
			}
		}
	}

	public override VisitorAction VisitDocumentStart(Document doc)
	{
		x8cedcaa9a62c6e39.x8b8ab0cf32b35f3c.x9b9ed0109b743e3b(x8cedcaa9a62c6e39);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitDocumentEnd(Document doc)
	{
		xe1410f585439c7d4.xbb7550bbb62a218c();
		xe1410f585439c7d4.x42f4c234c9358072 = new x0462f8ecc269ec42(x59578ef35ed89c46);
		xe1410f585439c7d4.xa07aa514e9082b3a();
		x8eeba9ad0741baa3.x6210059f049f0d48(x8cedcaa9a62c6e39);
		x7c0e51be6f8d5309.x6210059f049f0d48(x8cedcaa9a62c6e39);
		xb64601ac6a949c77();
		x8e7b859f11c80196.x6210059f049f0d48(x8cedcaa9a62c6e39, xa056586c1f99e199);
		x409f6d17d51b0ce0();
		x3a0d6b46377a1bfa();
		xe1410f585439c7d4.xbb7550bbb62a218c();
		x2741d82719d58153.WriteTo(x59578ef35ed89c46);
		xe99b85f44cfd8063.x6210059f049f0d48(x8cedcaa9a62c6e39);
		xe1410f585439c7d4.x4ecc66ceff7a75c0();
		xe1410f585439c7d4.xbb7550bbb62a218c();
		return VisitorAction.Continue;
	}

	private void xb64601ac6a949c77()
	{
		xd345c73dd1b16b74 x688a25acd97815ab = x8cedcaa9a62c6e39.x8556eed81191af11.x688a25acd97815ab;
		if (x688a25acd97815ab.Count == 0)
		{
			return;
		}
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		xe1410f585439c7d4.xee60bff2900a72f2("\\*\\xmlnstbl");
		foreach (DictionaryEntry item in x688a25acd97815ab)
		{
			xe1410f585439c7d4.xa07aa514e9082b3a();
			int xbcea506a33cf = (int)item.Value;
			xe1410f585439c7d4.x4d14ee33f46b5913("\\xmlns", xbcea506a33cf);
			string xb41faee6912a = (string)item.Key;
			xe1410f585439c7d4.x50f5dc167b3269a7(xb41faee6912a);
			xe1410f585439c7d4.x4ecc66ceff7a75c0();
		}
		xe1410f585439c7d4.xc8a13a52db0580ae();
		xe1410f585439c7d4.x25d0efbd7848eeb3();
	}

	private void x409f6d17d51b0ce0()
	{
		Shape backgroundShape = x8cedcaa9a62c6e39.x2c8c6741422a1298.BackgroundShape;
		if (backgroundShape != null)
		{
			xe1410f585439c7d4.x25d0efbd7848eeb3();
			xe1410f585439c7d4.xee60bff2900a72f2("\\*\\background");
			x8cedcaa9a62c6e39.x8b8ab0cf32b35f3c.x409f6d17d51b0ce0(backgroundShape);
			xe1410f585439c7d4.xc8a13a52db0580ae();
			xe1410f585439c7d4.x25d0efbd7848eeb3();
		}
	}

	private void x3a0d6b46377a1bfa()
	{
		if (x8cedcaa9a62c6e39.x2c8c6741422a1298.Variables.Count > 0)
		{
			xe1410f585439c7d4.x25d0efbd7848eeb3();
		}
		foreach (DictionaryEntry variable in x8cedcaa9a62c6e39.x2c8c6741422a1298.Variables)
		{
			xe1410f585439c7d4.xee60bff2900a72f2("\\*\\docvar");
			xe1410f585439c7d4.xa07aa514e9082b3a();
			xe1410f585439c7d4.x50f5dc167b3269a7(variable.Key.ToString());
			xe1410f585439c7d4.x4ecc66ceff7a75c0();
			xe1410f585439c7d4.xa07aa514e9082b3a();
			xe1410f585439c7d4.x50f5dc167b3269a7(variable.Value.ToString());
			xe1410f585439c7d4.x4ecc66ceff7a75c0();
			xe1410f585439c7d4.xc8a13a52db0580ae();
		}
		if (x8cedcaa9a62c6e39.x2c8c6741422a1298.Variables.Count > 0)
		{
			xe1410f585439c7d4.x25d0efbd7848eeb3();
		}
	}

	private void xb036af58ec58fcac()
	{
		x60dc5b79e3827efc.Push(x432326848f529fe4);
		x432326848f529fe4 = new xaa6547801b39e385(x8cedcaa9a62c6e39);
	}

	private void xe52c86ddb3178d95()
	{
		x432326848f529fe4 = (xaa6547801b39e385)x60dc5b79e3827efc.Pop();
	}

	public override VisitorAction VisitSectionStart(Section section)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		x81e8850b427d39a3 = false;
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		xc310dfbfd8843d1b.x6210059f049f0d48(section.xfc72d4c9b765cad7);
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		xfcb2f38d2624882c = section.PageSetup.OddAndEvenPagesHeaderFooter;
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSectionEnd(Section section)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		if (!section.Body.x16479f42fe4547f2)
		{
			section.Body.Accept(this);
		}
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitHeaderFooterStart(HeaderFooter headerFooter)
	{
		x8cedcaa9a62c6e39.xf41b717aaedc8265 = true;
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		xe1410f585439c7d4.xee60bff2900a72f2(x1cf55bf1c1c040ec.xb85473ec132a8393(headerFooter.HeaderFooterType, xfcb2f38d2624882c));
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitHeaderFooterEnd(HeaderFooter headerFooter)
	{
		x8cedcaa9a62c6e39.xf41b717aaedc8265 = false;
		xe1410f585439c7d4.xc8a13a52db0580ae();
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitBodyStart(Body body)
	{
		if (x81e8850b427d39a3)
		{
			return VisitorAction.Continue;
		}
		x81e8850b427d39a3 = true;
		if (!body.x16479f42fe4547f2)
		{
			return VisitorAction.SkipThisNode;
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitParagraphStart(Paragraph para)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		x432326848f529fe4.xbe8a2ee35737311e();
		xe0dcd40792266ce3.xe15b410a3a002f4d(para, this);
		xe1410f585439c7d4.x4d14ee33f46b5913("\\pard");
		xe1410f585439c7d4.x4d14ee33f46b5913("\\plain");
		xe1410f585439c7d4.xb8aea59edd4060ce("\\intbl", x432326848f529fe4.x772764427592d4bb > 0);
		xe1410f585439c7d4.x4d14ee33f46b5913("\\itap", x432326848f529fe4.x772764427592d4bb);
		x1a78664fa10a3755 x062aae8c9613eeaa = para.x2e12c5f9278ae233(xd9bc7f7e70d71e14.x3968babb3b57e478);
		x8cedcaa9a62c6e39.x1e8de05c1565effc.x6210059f049f0d48(x062aae8c9613eeaa, x00ce61b8358bb4cc: true, x02cadcecef04989f: false);
		xeedad81aaed42a76 x789564759d = para.xfcffbd79482d97c7.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226);
		x8cedcaa9a62c6e39.x6fca94e50472ae68.x6210059f049f0d48(x789564759d, x00ce61b8358bb4cc: true);
		if (para.xbc0119d7471ef12e)
		{
			x1469a79b69386321(para);
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitParagraphEnd(Paragraph para)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		xe0dcd40792266ce3.x53ca22156bcc3784(para, this);
		xa2e5fe5057cd7778(para);
		return VisitorAction.Continue;
	}

	private void xa2e5fe5057cd7778(Paragraph x41baca1d6c0c2e8e)
	{
		xf7484ae5f29ce181(x41baca1d6c0c2e8e);
		if (x41baca1d6c0c2e8e.xf858d9730ef207f0)
		{
			x85e29c5f479d34d0((Row)x41baca1d6c0c2e8e.xdfa6ecc6f742f086.xdfa6ecc6f742f086, x41baca1d6c0c2e8e.x3a7e67268c1cb407(xecac24b19ed3a2b7.xe9e531d1a6725226));
		}
		xe1410f585439c7d4.x25d0efbd7848eeb3();
	}

	private void xf7484ae5f29ce181(Paragraph x41baca1d6c0c2e8e)
	{
		if (x41baca1d6c0c2e8e.xb1efbf98d540cbda || x41baca1d6c0c2e8e.xd9de1b09bd43c824)
		{
			return;
		}
		xe1410f585439c7d4.xa07aa514e9082b3a();
		x8cedcaa9a62c6e39.x6fca94e50472ae68.x6210059f049f0d48(x41baca1d6c0c2e8e.x3a7e67268c1cb407(xecac24b19ed3a2b7.xe9e531d1a6725226), x00ce61b8358bb4cc: true);
		if (x41baca1d6c0c2e8e.IsEndOfCell)
		{
			if (x432326848f529fe4.xb11c814ff34244eb)
			{
				xe1410f585439c7d4.x4d14ee33f46b5913("\\nestcell");
				xe1410f585439c7d4.xee60bff2900a72f2("\\nonesttables");
				xe1410f585439c7d4.x6210059f049f0d48("\\par");
				xe1410f585439c7d4.xc8a13a52db0580ae();
			}
			else
			{
				xe1410f585439c7d4.x4d14ee33f46b5913("\\cell");
			}
		}
		else if (x41baca1d6c0c2e8e.IsEndOfSection)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913(x41baca1d6c0c2e8e.IsEndOfDocument ? "\\par" : "\\sect");
		}
		else
		{
			xe1410f585439c7d4.x4d14ee33f46b5913("\\par");
		}
		xe1410f585439c7d4.x4ecc66ceff7a75c0();
	}

	private void x85e29c5f479d34d0(Row xa806b754814b9ae0, xeedad81aaed42a76 x8102b2fd93c845eb)
	{
		if (x432326848f529fe4.xb11c814ff34244eb)
		{
			xe1410f585439c7d4.xee60bff2900a72f2("\\*\\nesttableprops");
			x432326848f529fe4.xbdbbc98113b6b783(xa806b754814b9ae0);
			x8cedcaa9a62c6e39.x6fca94e50472ae68.x6210059f049f0d48(x8102b2fd93c845eb, x00ce61b8358bb4cc: true);
			xe1410f585439c7d4.x4d14ee33f46b5913("\\nestrow");
			xe1410f585439c7d4.xc8a13a52db0580ae();
		}
		else
		{
			xe1410f585439c7d4.xa07aa514e9082b3a();
			x432326848f529fe4.xbdbbc98113b6b783(xa806b754814b9ae0);
			x8cedcaa9a62c6e39.x6fca94e50472ae68.x6210059f049f0d48(x8102b2fd93c845eb, x00ce61b8358bb4cc: true);
			xe1410f585439c7d4.x4d14ee33f46b5913("\\row");
			xe1410f585439c7d4.x4ecc66ceff7a75c0();
		}
	}

	public override VisitorAction VisitTableStart(Table table)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		x432326848f529fe4.x35ee6077b3c26c9f(table);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitTableEnd(Table table)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		x432326848f529fe4.xee69ee8848255726();
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRowStart(Row row)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		x432326848f529fe4.x5e3f44647fcfb8fc(row);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRowEnd(Row row)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitAbsolutePositionTab(AbsolutePositionTab tab)
	{
		xe1410f585439c7d4.xee60bff2900a72f2(xa0d3611565b2a1f2.x3c860eff373e6d44(tab.x312ff11290b951a5));
		xe1410f585439c7d4.x4d14ee33f46b5913(xa0d3611565b2a1f2.x84a6010bcc93313a(tab.x9ba359ff37a3a63b, tab.x7073c129de8d5e65));
		xe1410f585439c7d4.xc8a13a52db0580ae();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldStart(FieldStart fieldStart)
	{
		xdbbc2c1800d67523.Push(fieldStart);
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		switch (fieldStart.FieldType)
		{
		case FieldType.FieldIndexEntry:
		case FieldType.FieldTOCEntry:
		{
			xeedad81aaed42a76 xeedad81aaed42a = fieldStart.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226);
			xe1410f585439c7d4.xa07aa514e9082b3a();
			xeedad81aaed42a.xae20093bed1e48a8(130, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
			x8cedcaa9a62c6e39.x6fca94e50472ae68.xbe6eb989f9cb1a2c(xeedad81aaed42a);
			if (!base.x991897f13cf6aadc)
			{
				x98ae5cd4572ef0e8 = fieldStart;
			}
			x75be698bf0c3a5c5();
			break;
		}
		case FieldType.FieldLink:
			if (xa210713b33d7dd79(fieldStart))
			{
				x3c319b64ad5a4399 = true;
			}
			else
			{
				x8cedcaa9a62c6e39.xf81237e03ccdf47f.x8605874f1b4c6798(fieldStart.IsLocked, fieldStart.x6e94079169d5a06e);
			}
			break;
		default:
			x8cedcaa9a62c6e39.xf81237e03ccdf47f.x8605874f1b4c6798(fieldStart.IsLocked, fieldStart.x6e94079169d5a06e);
			break;
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldSeparator(FieldSeparator fieldSeparator)
	{
		if (fieldSeparator.FieldType == FieldType.FieldIncludePicture)
		{
			x8cedcaa9a62c6e39.x5124b2bcc12d5218 = true;
		}
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		if (x5c29822913be33c1.x4880d896f2583270(fieldSeparator.FieldType))
		{
			string text = x5c29822913be33c1.x130349ecd69ef30b(fieldSeparator);
			if (x0d299f323d241756.x5959bccb67bbf051(text))
			{
				string text2 = x0d299f323d241756.x482624a13e9e9d98(xef515ac4d57187c2.xed1b33c4a41501bf(text));
				x8cedcaa9a62c6e39.xe1410f585439c7d4.xf55384516c165731("\\*\\datafield", text2.ToLower());
			}
		}
		if (fieldSeparator.FieldType != FieldType.FieldLink || (fieldSeparator.FieldType == FieldType.FieldLink && !xa210713b33d7dd79(fieldSeparator)))
		{
			x8cedcaa9a62c6e39.xf81237e03ccdf47f.x8d6cd60f05fc1fe9();
		}
		else
		{
			xb96548915defddcf.xa2764f0584a83dc0(x8cedcaa9a62c6e39, xd2daee3ef30c2b61.ToString(), fieldSeparator.x71d39fdf56861cca);
			x3c319b64ad5a4399 = false;
			xd2daee3ef30c2b61.Length = 0;
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldEnd(FieldEnd fieldEnd)
	{
		if (fieldEnd.FieldType == FieldType.FieldIncludePicture)
		{
			x8cedcaa9a62c6e39.x5124b2bcc12d5218 = false;
		}
		switch (fieldEnd.FieldType)
		{
		case FieldType.FieldTOCEntry:
			x45277e5380a187db();
			x462e1b1a94055adb(fieldEnd);
			xe1410f585439c7d4.x4ecc66ceff7a75c0();
			break;
		case FieldType.FieldIndexEntry:
			x45277e5380a187db();
			x4931e782d015612f(fieldEnd);
			xe1410f585439c7d4.x4ecc66ceff7a75c0();
			break;
		case FieldType.FieldLink:
			if (xa210713b33d7dd79(fieldEnd))
			{
				xb96548915defddcf.xfa1528be622d4031(x8cedcaa9a62c6e39);
			}
			else
			{
				x8cedcaa9a62c6e39.xf81237e03ccdf47f.x98ab27c28fa098eb(fieldEnd.HasSeparator || fieldEnd.IsDeleteRevision);
			}
			break;
		default:
			x8cedcaa9a62c6e39.xf81237e03ccdf47f.x98ab27c28fa098eb(fieldEnd.HasSeparator || fieldEnd.IsDeleteRevision);
			break;
		}
		x70794e43be767541(fieldEnd);
		return VisitorAction.Continue;
	}

	private void x70794e43be767541(FieldEnd xc87e4e475724f9c3)
	{
		FieldStart fieldStart = (FieldStart)xdbbc2c1800d67523.Pop();
		Paragraph paragraph = (Paragraph)fieldStart.GetAncestor(NodeType.Paragraph);
		Paragraph paragraph2 = (Paragraph)xc87e4e475724f9c3.GetAncestor(NodeType.Paragraph);
		if (paragraph != paragraph2)
		{
			VisitParagraphStart(paragraph2);
		}
		Section section = (Section)fieldStart.GetAncestor(NodeType.Section);
		Section section2 = (Section)xc87e4e475724f9c3.GetAncestor(NodeType.Section);
		if (section != section2)
		{
			VisitSectionStart(section2);
		}
	}

	private void x462e1b1a94055adb(FieldEnd xc87e4e475724f9c3)
	{
		if (!base.x991897f13cf6aadc)
		{
			Field xe01ae93d9fe5a = x3759c06a3a4cf5d1.x43fef3435fba7a66(x98ae5cd4572ef0e8, null, xc87e4e475724f9c3);
			x38be5b3ac06e8fad x38be5b3ac06e8fad = x38be5b3ac06e8fad.x1f490eac106aee12(xe01ae93d9fe5a);
			string x1c4259f170c30c = ((!x38be5b3ac06e8fad.x271e0fac991fd9dc) ? "\\tc" : "\\tcn");
			xe1410f585439c7d4.xee60bff2900a72f2(x1c4259f170c30c);
			x38be5b3ac06e8fad.xf9ad6fb78355fe13.x7012609bcdb39574(this, new x78f7ad9d7fd68e82(isTrimDoubleQuotes: true));
			if (x38be5b3ac06e8fad.x504f3d4040b356d7 != 1)
			{
				xe1410f585439c7d4.x4d14ee33f46b5913("\\tcl", x38be5b3ac06e8fad.x504f3d4040b356d7);
			}
			if (x0d299f323d241756.x5959bccb67bbf051(x38be5b3ac06e8fad.xe12071fbe3d25fe5))
			{
				xe1410f585439c7d4.x4d14ee33f46b5913("\\tcf", x38be5b3ac06e8fad.xe12071fbe3d25fe5[0]);
			}
			xe1410f585439c7d4.xc8a13a52db0580ae();
		}
	}

	private void x4931e782d015612f(FieldEnd xc87e4e475724f9c3)
	{
		if (!base.x991897f13cf6aadc)
		{
			Field xe01ae93d9fe5a = x3759c06a3a4cf5d1.x43fef3435fba7a66(x98ae5cd4572ef0e8, null, xc87e4e475724f9c3);
			x613a9df54ef3a436 x613a9df54ef3a = x613a9df54ef3a436.x1f490eac106aee12(xe01ae93d9fe5a);
			xe1410f585439c7d4.xee60bff2900a72f2("\\xe");
			x613a9df54ef3a.xf9ad6fb78355fe13.x7012609bcdb39574(this, new x78f7ad9d7fd68e82(isTrimDoubleQuotes: true));
			if (x613a9df54ef3a.xa143daf3bef8b339)
			{
				xe1410f585439c7d4.x4d14ee33f46b5913("\\bxe");
			}
			if (x613a9df54ef3a.xb65ca9637cc40782)
			{
				xe1410f585439c7d4.x4d14ee33f46b5913("\\ixe");
			}
			if (x0d299f323d241756.x5959bccb67bbf051(x613a9df54ef3a.x2ff6d9d680555933))
			{
				xe1410f585439c7d4.x4d14ee33f46b5913("\\xef", x613a9df54ef3a.x2ff6d9d680555933[0]);
			}
			if (x0d299f323d241756.x5959bccb67bbf051(x613a9df54ef3a.x7155dda3b72cd3e5))
			{
				xe1410f585439c7d4.xee60bff2900a72f2("\\txe");
				xe1410f585439c7d4.x6210059f049f0d48(x613a9df54ef3a.x7155dda3b72cd3e5);
				xe1410f585439c7d4.xc8a13a52db0580ae();
			}
			if (x0d299f323d241756.x5959bccb67bbf051(x613a9df54ef3a.x6fd19cbadc5a23d8))
			{
				xe1410f585439c7d4.xee60bff2900a72f2("\\rxe");
				xe1410f585439c7d4.x6210059f049f0d48(x613a9df54ef3a.x6fd19cbadc5a23d8);
				xe1410f585439c7d4.xc8a13a52db0580ae();
			}
			if (x0d299f323d241756.x5959bccb67bbf051(x613a9df54ef3a.x2f1df7727ae3e869))
			{
				xe1410f585439c7d4.x4d14ee33f46b5913("\\yxe", x613a9df54ef3a.x2f1df7727ae3e869);
			}
			xe1410f585439c7d4.xc8a13a52db0580ae();
		}
	}

	public override VisitorAction VisitFormField(FormField formField)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		if (!x5c29822913be33c1.x7f8b7c1c90735bcf(formField.Type))
		{
			return VisitorAction.SkipThisNode;
		}
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		x8cedcaa9a62c6e39.xf81237e03ccdf47f.x85599597a4d57020(formField);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitShapeStart(Shape shape)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		x8cedcaa9a62c6e39.x8b8ab0cf32b35f3c.x92e9ca271095fc22(shape);
		if (shape.HasChildNodes)
		{
			xb036af58ec58fcac();
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitShapeEnd(Shape shape)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		if (shape.HasChildNodes)
		{
			xe52c86ddb3178d95();
		}
		x8cedcaa9a62c6e39.x8b8ab0cf32b35f3c.xd952c86c26db9330(shape);
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitGroupShapeStart(GroupShape groupShape)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		x8cedcaa9a62c6e39.x8b8ab0cf32b35f3c.x92e9ca271095fc22(groupShape);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitGroupShapeEnd(GroupShape groupShape)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		x8cedcaa9a62c6e39.x8b8ab0cf32b35f3c.xd952c86c26db9330(groupShape);
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitBookmarkStart(BookmarkStart bookmarkStart)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		xe1410f585439c7d4.xee60bff2900a72f2("\\*\\bkmkstart");
		if (bookmarkStart.xf1b59c88b25f8eec)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913("\\bkmkcolf", bookmarkStart.xb78c16d5f2d4f2f7);
			xe1410f585439c7d4.x4d14ee33f46b5913("\\bkmkcoll", bookmarkStart.x279da4adfba57f2d);
		}
		xe1410f585439c7d4.x50f5dc167b3269a7(bookmarkStart.Name);
		xe1410f585439c7d4.xc8a13a52db0580ae();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitBookmarkEnd(BookmarkEnd bookmarkEnd)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		xe1410f585439c7d4.xee60bff2900a72f2("\\*\\bkmkend");
		xe1410f585439c7d4.x50f5dc167b3269a7(bookmarkEnd.Name);
		xe1410f585439c7d4.xc8a13a52db0580ae();
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFootnoteStart(Footnote footnote)
	{
		xb036af58ec58fcac();
		x65284e9656e69eea(footnote);
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		xe1410f585439c7d4.xa07aa514e9082b3a();
		x8cedcaa9a62c6e39.x6fca94e50472ae68.x6210059f049f0d48(footnote.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226), x00ce61b8358bb4cc: true);
		if (footnote.xa72bf798a679c0aa)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913("\\chftn");
		}
		else
		{
			xe1410f585439c7d4.x6210059f049f0d48(footnote.x715a8c5c33fdc1a6.Substring(0, 1));
		}
		xe1410f585439c7d4.xee60bff2900a72f2("\\footnote");
		xe1410f585439c7d4.xb8aea59edd4060ce("\\ftnalt", footnote.FootnoteType == FootnoteType.Endnote);
		return VisitorAction.Continue;
	}

	private void x65284e9656e69eea(Footnote x897ec71a9f9588a0)
	{
		switch (x897ec71a9f9588a0.FootnoteType)
		{
		case FootnoteType.Footnote:
			x8cedcaa9a62c6e39.xc436e8202dc390b0++;
			break;
		case FootnoteType.Endnote:
			x8cedcaa9a62c6e39.x72bc9ec1224ff13e++;
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("heidnfpdhfgehfneffefkflfoecgnpigaeahgehhdeohfefimdmikddjmdkjkcbkcohkddpkfdgljcnllbembokm", 1816410098)));
		}
	}

	public override VisitorAction VisitFootnoteEnd(Footnote footnote)
	{
		xe1410f585439c7d4.xc8a13a52db0580ae();
		if (!footnote.xa72bf798a679c0aa)
		{
			xe1410f585439c7d4.x6210059f049f0d48(footnote.x715a8c5c33fdc1a6.Substring(1, footnote.x715a8c5c33fdc1a6.Length - 1));
		}
		xe1410f585439c7d4.x4ecc66ceff7a75c0();
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		xe52c86ddb3178d95();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentStart(Comment comment)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		xb036af58ec58fcac();
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		xe1410f585439c7d4.xf55384516c165731("\\*\\atnid", comment.Initial);
		xe1410f585439c7d4.xf55384516c165731("\\*\\atnauthor", comment.Author);
		xe1410f585439c7d4.x4d14ee33f46b5913("\\chatn");
		xe1410f585439c7d4.xee60bff2900a72f2("\\*\\annotation");
		if (comment.xad2b66edfff52038)
		{
			xe1410f585439c7d4.xf55384516c165731("\\*\\atnref", comment.Id);
		}
		xe1410f585439c7d4.xf55384516c165731("\\*\\atndate", xed28c1e5772a17ea.x7c734cfcbb14646a(comment.DateTime).ToString());
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentEnd(Comment comment)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		xe1410f585439c7d4.xc8a13a52db0580ae();
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		xe52c86ddb3178d95();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentRangeStart(CommentRangeStart commentRangeStart)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		xe1410f585439c7d4.xf55384516c165731("\\*\\atrfstart", commentRangeStart.Id);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentRangeEnd(CommentRangeEnd commentRangeEnd)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		xe1410f585439c7d4.xf55384516c165731("\\*\\atrfend", commentRangeEnd.Id);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRun(Run run)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		if (x3c319b64ad5a4399)
		{
			xd2daee3ef30c2b61.Append(run.Text);
		}
		else
		{
			x486167d7a74e8e88(run.x856218fd0771d379(xecac24b19ed3a2b7.x2be08ba736aa04f0), run.Text);
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitOfficeMathStart(OfficeMath officeMath)
	{
		if (x68936f0cacd103a9 == 0)
		{
			xe1410f585439c7d4.xee60bff2900a72f2("\\mmath");
		}
		x68936f0cacd103a9++;
		x93df8211dc06e42a.xd29409f2ba9889e2(officeMath, x8cedcaa9a62c6e39);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitOfficeMathEnd(OfficeMath officeMath)
	{
		x93df8211dc06e42a.x685b1e5a342b26d7(xe1410f585439c7d4);
		x68936f0cacd103a9--;
		if (x68936f0cacd103a9 == 0)
		{
			xe1410f585439c7d4.xc8a13a52db0580ae();
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSubDocument(SubDocument subDocument)
	{
		x8cedcaa9a62c6e39.x0f1b548a1d4927cb.Add(subDocument.xa39af5a82860a9a3);
		xe1410f585439c7d4.x4d14ee33f46b5913("\\subdocument", x8cedcaa9a62c6e39.x0f1b548a1d4927cb.Count);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSpecialChar(SpecialChar specialChar)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		x486167d7a74e8e88(specialChar.x856218fd0771d379(xecac24b19ed3a2b7.xe9e531d1a6725226), specialChar.GetText());
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitStructuredDocumentTagStart(StructuredDocumentTag sdt)
	{
		xbbf9a1ead81dd3a1(WarningType.DataLossCategory, "StructuredDocumentTags are not supported by RTF format.");
		return base.VisitStructuredDocumentTagStart(sdt);
	}

	public void x18c776ebc56d8212(CustomXmlMarkup x2f992229ae4fc9a1)
	{
		xec223dea97b156e1(x2f992229ae4fc9a1.Uri, xf315aff449e3b71f: true, x2f992229ae4fc9a1.Level, "\\xmlname", x2f992229ae4fc9a1.Element, x2f992229ae4fc9a1.Placeholder, x2f992229ae4fc9a1.Properties);
	}

	public void x0a79c02b4c66999f(CustomXmlMarkup x2f992229ae4fc9a1)
	{
		xe1410f585439c7d4.xee60bff2900a72f2("\\*\\xmlclose");
		xe1410f585439c7d4.xc8a13a52db0580ae();
	}

	private void x486167d7a74e8e88(xeedad81aaed42a76 x789564759d365819, string xb41faee6912a2313)
	{
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		xe1410f585439c7d4.xa07aa514e9082b3a();
		x8cedcaa9a62c6e39.x6fca94e50472ae68.xbe6eb989f9cb1a2c(x789564759d365819);
		if (x68936f0cacd103a9 > 0)
		{
			xb630b345e4c720f2(x789564759d365819);
		}
		xe1410f585439c7d4.x50f5dc167b3269a7(xb41faee6912a2313);
		if (x68936f0cacd103a9 > 0)
		{
			xe1410f585439c7d4.xc8a13a52db0580ae();
		}
		xe1410f585439c7d4.x4ecc66ceff7a75c0();
	}

	private void xb630b345e4c720f2(xeedad81aaed42a76 x789564759d365819)
	{
		xe1410f585439c7d4.xee60bff2900a72f2("\\mr");
		xe1410f585439c7d4.xb8aea59edd4060ce("\\mnor", x789564759d365819.x60c60b1f72126a4c);
		xe1410f585439c7d4.x4d14ee33f46b5913("\\mscr", (int)x789564759d365819.x1380d412169e361b);
		xe1410f585439c7d4.x4d14ee33f46b5913("\\msty", (int)x789564759d365819.x65251a26aa8f6af1);
		if (x789564759d365819.x488a5f49abd86bb8 != null)
		{
			x93df8211dc06e42a.x324712e3f7868747(x789564759d365819.x488a5f49abd86bb8, xe1410f585439c7d4);
		}
	}

	private void x1469a79b69386321(Paragraph x41baca1d6c0c2e8e)
	{
		xe1410f585439c7d4.xee60bff2900a72f2("\\listtext");
		xe1410f585439c7d4.x4d14ee33f46b5913("\\pard");
		xe1410f585439c7d4.x4d14ee33f46b5913("\\plain");
		ListLevel listLevel = x41baca1d6c0c2e8e.ListFormat.ListLevel;
		if (listLevel.x4a1340b0df048976 != 4095)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913("\\s", listLevel.x4a1340b0df048976);
		}
		x8cedcaa9a62c6e39.x1e8de05c1565effc.x6210059f049f0d48(listLevel.x1a78664fa10a3755, x00ce61b8358bb4cc: false, x02cadcecef04989f: false);
		x8cedcaa9a62c6e39.x6fca94e50472ae68.x6210059f049f0d48(x41baca1d6c0c2e8e.ListLabel.x856218fd0771d379(), x00ce61b8358bb4cc: true);
		xe1410f585439c7d4.x50f5dc167b3269a7(x41baca1d6c0c2e8e.ListLabel.LabelString);
		switch (listLevel.TrailingCharacter)
		{
		case ListTrailingCharacter.Tab:
			xe1410f585439c7d4.x50f5dc167b3269a7(ControlChar.Tab);
			break;
		case ListTrailingCharacter.Space:
			xe1410f585439c7d4.x50f5dc167b3269a7(ControlChar.x3e1feffd8ca6feb2);
			break;
		}
		xe1410f585439c7d4.xc8a13a52db0580ae();
	}

	public override VisitorAction VisitSmartTagStart(SmartTag smartTag)
	{
		xec223dea97b156e1(smartTag.Uri, xf315aff449e3b71f: false, MarkupLevel.Unknown, "\\factoidname", smartTag.Element, null, smartTag.Properties);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSmartTagEnd(SmartTag smartTag)
	{
		xa92e5ac412064f34();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCustomXmlMarkupStart(CustomXmlMarkup customXml)
	{
		if (customXml.Level == MarkupLevel.Inline)
		{
			x18c776ebc56d8212(customXml);
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCustomXmlMarkupEnd(CustomXmlMarkup customXmlMarkup)
	{
		if (customXmlMarkup.Level == MarkupLevel.Inline)
		{
			xa92e5ac412064f34();
		}
		return VisitorAction.Continue;
	}

	internal void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x9f91de645a9fe01a, WarningSource.Rtf, xc2358fbac7da3d45));
		}
	}

	internal void x3dc950453374051a(string xc2358fbac7da3d45)
	{
		xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, xc2358fbac7da3d45);
	}

	private void xec223dea97b156e1(string xbda579af315c6893, bool xf315aff449e3b71f, MarkupLevel x66bbd7ed8c65740d, string xdfe16369d0d9619c, string x121383aa64985888, string x37f3a555926e71c4, CustomXmlPropertyCollection xa5ea04da0b735c3b)
	{
		if (base.x991897f13cf6aadc)
		{
			return;
		}
		xe1410f585439c7d4.xee60bff2900a72f2("\\*\\xmlopen");
		x3dc2bfcd934cac7c("\\xmlns", xbda579af315c6893);
		if (xf315aff449e3b71f)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913(x1cf55bf1c1c040ec.x58e028bc9916ae9f(x66bbd7ed8c65740d));
		}
		xe1410f585439c7d4.xf55384516c165731(xdfe16369d0d9619c, x121383aa64985888);
		foreach (CustomXmlProperty item in xa5ea04da0b735c3b)
		{
			xe6c8c4d67e70e188(item);
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x37f3a555926e71c4))
		{
			xe6c8c4d67e70e188(new CustomXmlProperty("placeholder", "", x37f3a555926e71c4));
		}
		xe1410f585439c7d4.xc8a13a52db0580ae();
	}

	private void xa92e5ac412064f34()
	{
		if (!base.x991897f13cf6aadc)
		{
			xe1410f585439c7d4.xee60bff2900a72f2("\\*\\xmlclose");
			xe1410f585439c7d4.xc8a13a52db0580ae();
		}
	}

	private void xe6c8c4d67e70e188(CustomXmlProperty x5ca6b6e12a4d9043)
	{
		xe1410f585439c7d4.xee60bff2900a72f2("\\xmlattr");
		x3dc2bfcd934cac7c("\\xmlattrns", x5ca6b6e12a4d9043.Uri);
		xe1410f585439c7d4.xf55384516c165731("\\xmlattrname", x5ca6b6e12a4d9043.Name);
		xe1410f585439c7d4.xf55384516c165731("\\xmlattrvalue", x5ca6b6e12a4d9043.Value);
		xe1410f585439c7d4.xc8a13a52db0580ae();
	}

	private void x3dc2bfcd934cac7c(string x010d53cb60a80dd8, string xbda579af315c6893)
	{
		int xbcea506a33cf = (x0d299f323d241756.x5959bccb67bbf051(xbda579af315c6893) ? ((int)x8cedcaa9a62c6e39.x8556eed81191af11.x688a25acd97815ab[xbda579af315c6893]) : 0);
		xe1410f585439c7d4.x4d14ee33f46b5913(x010d53cb60a80dd8, xbcea506a33cf);
	}

	private static bool xa210713b33d7dd79(Node xf8d5403aed98aac4)
	{
		if (xf8d5403aed98aac4.NodeType != NodeType.FieldStart && xf8d5403aed98aac4.NodeType != NodeType.FieldSeparator && xf8d5403aed98aac4.NodeType != NodeType.FieldEnd)
		{
			return false;
		}
		bool flag = xf8d5403aed98aac4.NodeType == NodeType.FieldEnd;
		Node node = xf8d5403aed98aac4;
		while (node != null && node.NodeType != (NodeType)(flag ? 16 : 18))
		{
			if (node.NodeType == NodeType.FieldSeparator)
			{
				return ((FieldSeparator)node).x71d39fdf56861cca != null;
			}
			node = (flag ? node.PreviousSibling : node.NextSibling);
		}
		return false;
	}
}
