using System;
using Aspose.Words;
using Aspose.Words.BuildingBlocks;
using Aspose.Words.Drawing;
using Aspose.Words.Lists;
using Aspose.Words.Markup;
using Aspose.Words.Math;
using Aspose.Words.Tables;
using x011d489fb9df7027;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x9db5f2e5af3d596e;
using xd2754ae26d400653;

namespace x13cd31bb39e0b7ea;

internal class x9190101bb5c1ce1b : DocumentVisitor
{
	private x3e50ba9028aa4ca7 x1004dc53dfb6ee0b;

	private IWarningCallback xa056586c1f99e199;

	internal void x18dfca7c5fd2402f(Document x6beba47238e0ade6, LoadOptions x27aceb70372bde46)
	{
		xa056586c1f99e199 = x27aceb70372bde46?.WarningCallback;
		x6beba47238e0ade6.Accept(this);
		if (x6beba47238e0ade6.GlossaryDocument != null)
		{
			x6beba47238e0ade6.GlossaryDocument.Accept(this);
		}
		x84eb05aa1ce8e247(x6beba47238e0ade6);
	}

	private static void x84eb05aa1ce8e247(Document x6beba47238e0ade6)
	{
		if ((x6beba47238e0ade6.OriginalLoadFormat == LoadFormat.Docx || x6beba47238e0ade6.OriginalLoadFormat == LoadFormat.Dotx || x6beba47238e0ade6.OriginalLoadFormat == LoadFormat.Docm || x6beba47238e0ade6.OriginalLoadFormat == LoadFormat.Dotm || x6beba47238e0ade6.OriginalLoadFormat == LoadFormat.FlatOpc || x6beba47238e0ade6.OriginalLoadFormat == LoadFormat.FlatOpcMacroEnabled || x6beba47238e0ade6.OriginalLoadFormat == LoadFormat.FlatOpcTemplate || x6beba47238e0ade6.OriginalLoadFormat == LoadFormat.FlatOpcTemplateMacroEnabled) && (!x6beba47238e0ade6.Styles.x3dde3ba6a116b7ee || !x6beba47238e0ade6.Styles.x3dde3ba6a116b7ee))
		{
			StyleCollection styleCollection = StyleCollection.x48416779f53c911f(x6beba47238e0ade6.OriginalLoadFormat);
			if (!x6beba47238e0ade6.Styles.x17edf608baa39956)
			{
				x6beba47238e0ade6.Styles.x27096df7ca0cfe2e.x5406c7dbc2add337(styleCollection.x27096df7ca0cfe2e);
			}
			if (!x6beba47238e0ade6.Styles.x3dde3ba6a116b7ee)
			{
				x6beba47238e0ade6.Styles.xf4eb04b8b9073eeb.x5406c7dbc2add337(styleCollection.xf4eb04b8b9073eeb);
			}
		}
	}

	internal void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, WarningSource x697d2859ebdde9ec, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x9f91de645a9fe01a, x697d2859ebdde9ec, xc2358fbac7da3d45));
		}
	}

	public override VisitorAction VisitDocumentStart(Document doc)
	{
		x03fd3121305b7e22(doc);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitGlossaryDocumentStart(GlossaryDocument glossary)
	{
		x03fd3121305b7e22(glossary);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitDocumentEnd(Document doc)
	{
		x16505750e02b9056();
		xb7dbd7bb3ed97d5b.x7feaa17f5d673c47(doc);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitGlossaryDocumentEnd(GlossaryDocument glossary)
	{
		x16505750e02b9056();
		return VisitorAction.Continue;
	}

	private void x03fd3121305b7e22(DocumentBase x6beba47238e0ade6)
	{
		x18bd1b7586fda648(x6beba47238e0ade6.Lists);
		x9823f6d9ebe7bcb3(x6beba47238e0ade6.Styles);
		x1004dc53dfb6ee0b = new x3e50ba9028aa4ca7(x6beba47238e0ade6, xa056586c1f99e199);
	}

	private void x16505750e02b9056()
	{
		x1004dc53dfb6ee0b.x648a8aa88d1bbe19();
	}

	private static void x18bd1b7586fda648(ListCollection x7d45a69b707b1582)
	{
		int xddf1da3d = x7d45a69b707b1582.xddf1da3d36406847;
		for (int i = 0; i < xddf1da3d; i++)
		{
			x178ff6dcbf808c38 x178ff6dcbf808c = x7d45a69b707b1582.x3bfa6064d69ac0da(i);
			x178ff6dcbf808c.x438a2a8db4b2d07b.xa3ba3a1106a23933(x178ff6dcbf808c.x902c8ac86fbaf048, x7d45a69b707b1582.Document);
		}
	}

	private void x9823f6d9ebe7bcb3(StyleCollection x3fa6ecdd18b2ff6e)
	{
		x3fa6ecdd18b2ff6e.x0fdd6762da0945d8();
		foreach (Style item in x3fa6ecdd18b2ff6e)
		{
			x0dc600c756e91831(item);
			xc1f743c481b6eec2(item);
			xa3c9b23bdda97b52(item);
			x1aeb358e0211068b(item);
			xc08d87389722996c(item);
		}
	}

	private void x0dc600c756e91831(Style x44ecfea61c937b8e)
	{
		if (x44ecfea61c937b8e.Type == StyleType.Paragraph && x44ecfea61c937b8e.xeedad81aaed42a76.x8301ab10c226b0c2 == x44ecfea61c937b8e.x8301ab10c226b0c2)
		{
			x3dc950453374051a("Paragraph style '{0}' has incorrect Istd set.", x44ecfea61c937b8e.Name);
			x44ecfea61c937b8e.xeedad81aaed42a76.x52b190e626f65140(50);
		}
	}

	private void xc1f743c481b6eec2(Style x44ecfea61c937b8e)
	{
		if (x44ecfea61c937b8e.x4cf1854ef833220f != 4095 && x44ecfea61c937b8e.Styles.x1976fb6958cf7237(x44ecfea61c937b8e.x4cf1854ef833220f, x988fcf605f8efa7e: false) == null)
		{
			x3dc950453374051a("Style '{0}' refers to non-existent style, removed invalid reference.", x44ecfea61c937b8e.Name);
			x44ecfea61c937b8e.x4cf1854ef833220f = 4095;
		}
	}

	private static void xa3c9b23bdda97b52(Style x44ecfea61c937b8e)
	{
		x44ecfea61c937b8e.x1a78664fa10a3755.x52b190e626f65140(1125);
	}

	private static void x1aeb358e0211068b(Style x44ecfea61c937b8e)
	{
		x1aeb358e0211068b(x44ecfea61c937b8e.xeedad81aaed42a76, 190);
		x1aeb358e0211068b(x44ecfea61c937b8e.xeedad81aaed42a76, 350);
	}

	private static void x1aeb358e0211068b(xeedad81aaed42a76 x789564759d365819, int xba08ce632055a1d9)
	{
		object obj = x789564759d365819.xf7866f89640a29a3(xba08ce632055a1d9);
		if (obj != null && (int)obj == 3276)
		{
			x789564759d365819.x52b190e626f65140(xba08ce632055a1d9);
		}
	}

	private void xc08d87389722996c(Style x44ecfea61c937b8e)
	{
		if (x44ecfea61c937b8e.x8301ab10c226b0c2 == 0 && x44ecfea61c937b8e.StyleIdentifier != 0)
		{
			xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, WarningSource.Validator, string.Format("Style index reserved for built-in style '{0}' is used in style '{1}'.", "Normal", x44ecfea61c937b8e.Name));
		}
		if (x44ecfea61c937b8e.x8301ab10c226b0c2 == 10 && x44ecfea61c937b8e.StyleIdentifier != StyleIdentifier.DefaultParagraphFont)
		{
			xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, WarningSource.Validator, string.Format("Style index reserved for built-in style '{0}' is used in style '{1}'.", "DefaultParagraphFont", x44ecfea61c937b8e.Name));
		}
	}

	public override VisitorAction VisitSectionStart(Section section)
	{
		section.xfc72d4c9b765cad7.xdda230e06503e5e8(xa056586c1f99e199);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitShapeStart(Shape shape)
	{
		x0485638e766d68d8(shape);
		x6de43ef0e3db22a3(shape);
		if (shape.xf7125312c7ee115c.x263d579af1d0d43f(780))
		{
			byte[] xde89b10d4ff89f = (byte[])shape.xf7125312c7ee115c.xf7866f89640a29a3(780);
			OfficeMath officeMath = xab9c9832b2867cea.x30e76621c2448675(xde89b10d4ff89f);
			if (officeMath != null)
			{
				Node newChild = shape.Document.ImportNode(officeMath, isImportChildren: true);
				shape.ParentNode.InsertBefore(newChild, shape);
				shape.Remove();
			}
		}
		return VisitorAction.Continue;
	}

	private void x0485638e766d68d8(Shape x5770cdefd8931aa9)
	{
		if (!x5770cdefd8931aa9.xa170cce2bc40bdf5)
		{
			return;
		}
		switch (x5770cdefd8931aa9.x1ba6afab4f42a0ee)
		{
		case x1ba6afab4f42a0ee.xc24de6454f8b0f37:
		case x1ba6afab4f42a0ee.xd5a7a92b8cfb14b3:
			if (x5770cdefd8931aa9.OleFormat.x58932c7e6fa3b905 == null)
			{
				x3dc950453374051a("Embedded OLE object without data found, converted to image.");
				x5770cdefd8931aa9.x88d1b78392d1a0ab(ShapeType.Image);
			}
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ijnnokeockloclcphkjpjjaaejhackoaajfbmimbfedcbhkclgbdbgidjdpdfigefhnekhefchlfngcglhjgecahfhhhhhohlgfinfmidcdj", 1954995523)));
		case x1ba6afab4f42a0ee.x1891c445b78b044b:
			break;
		}
	}

	private void x6de43ef0e3db22a3(Shape x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.HasImage && x5770cdefd8931aa9.Width == 0.0 && x5770cdefd8931aa9.Height == 0.0)
		{
			x3dc950453374051a("Image has zero dimensions, used defaults.");
			x5770cdefd8931aa9.Width = 216.0;
			x5770cdefd8931aa9.Height = 216.0;
		}
	}

	public override VisitorAction VisitCellStart(Cell cell)
	{
		if (cell.xf8cef531dae89ea3 == null)
		{
			cell.xf8cef531dae89ea3 = new xf8cef531dae89ea3();
		}
		cell.xf8cef531dae89ea3.xdca73a32969a2272();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitParagraphStart(Paragraph para)
	{
		if (x28ffd3f2cb5ad293(para))
		{
			x3dc950453374051a("Invalid number revision found, removed.");
			para.x1a78664fa10a3755.xb55a99e2e1381d7f(1125);
		}
		return VisitorAction.Continue;
	}

	private static bool x28ffd3f2cb5ad293(Paragraph x41baca1d6c0c2e8e)
	{
		x978620a99b6d5014 x978620a99b6d = x41baca1d6c0c2e8e.x1a78664fa10a3755.x978620a99b6d5014;
		if (x978620a99b6d != null)
		{
			if (!x978620a99b6d.x55e2dcfc986cb10b && !x978620a99b6d.x713b07324dddc470)
			{
				return true;
			}
			if (!x978620a99b6d.x55e2dcfc986cb10b && x978620a99b6d.x713b07324dddc470 && x41baca1d6c0c2e8e.IsListItem)
			{
				return true;
			}
			if (x978620a99b6d.x55e2dcfc986cb10b && !x978620a99b6d.x713b07324dddc470 && !x41baca1d6c0c2e8e.IsListItem)
			{
				return true;
			}
		}
		return false;
	}

	public override VisitorAction VisitSmartTagStart(SmartTag smartTag)
	{
		x0067ae889fa64f26(smartTag);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitStructuredDocumentTagStart(StructuredDocumentTag sdt)
	{
		sdt.x3c0af6fbd91b1638(x2e5cc5728d3cf72d: false);
		sdt.x626c3c1ff90f6f44();
		x3e154a9e959847e4(sdt);
		return VisitorAction.Continue;
	}

	private void x3e154a9e959847e4(StructuredDocumentTag xabd8f8a3b7f099d3)
	{
		if ((xabd8f8a3b7f099d3.SdtType != SdtType.DropDownList && xabd8f8a3b7f099d3.SdtType != SdtType.ComboBox) || xabd8f8a3b7f099d3.ListItems.SelectedValue != null)
		{
			return;
		}
		string text = xabd8f8a3b7f099d3.GetText().Trim('\a', '\r', '\f');
		for (int i = 0; i < xabd8f8a3b7f099d3.ListItems.Count; i++)
		{
			if (xabd8f8a3b7f099d3.ListItems[i].DisplayText == text)
			{
				xabd8f8a3b7f099d3.ListItems.SelectedValue = xabd8f8a3b7f099d3.ListItems[i];
				return;
			}
		}
		xbbf9a1ead81dd3a1(WarningType.MinorFormattingLoss, WarningSource.WordML, "Structured Document Tag content is messed up.");
	}

	private static void x0067ae889fa64f26(SmartTag xdc6161a296532e34)
	{
		Node firstChild = xdc6161a296532e34.FirstChild;
		if (firstChild is SmartTag)
		{
			SmartTag smartTag = (SmartTag)firstChild;
			if (smartTag.Element == "address" || smartTag.Element == "PersonName" || smartTag.Element == "place")
			{
				xdc6161a296532e34.xbc843e6d2f8d6fe7(smartTag);
			}
		}
	}

	public override VisitorAction VisitCommentStart(Comment comment)
	{
		return x1004dc53dfb6ee0b.x0a2f96470b05c54f(comment);
	}

	public override VisitorAction VisitCommentRangeStart(CommentRangeStart commentRangeStart)
	{
		return x1004dc53dfb6ee0b.x66511c5e952e5fcb(commentRangeStart);
	}

	public override VisitorAction VisitCommentRangeEnd(CommentRangeEnd commentRangeEnd)
	{
		return x1004dc53dfb6ee0b.x057ef68b6193f0b3(commentRangeEnd);
	}

	private void x3dc950453374051a(string xc2358fbac7da3d45, params object[] xce8d8c7e3c2c2426)
	{
		x98b0e09ccece0a5a.x3dc950453374051a(xa056586c1f99e199, xc2358fbac7da3d45, xce8d8c7e3c2c2426);
	}
}
