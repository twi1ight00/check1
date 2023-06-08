using System.Text;
using Aspose.Words;
using Aspose.Words.Drawing;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class x50e6e6d123fa4a35
{
	internal static WarningInfo xb5ef8a04e65b87e6(string x1f25abf5fb75e795, object xa860e35844c20ac7)
	{
		return new WarningInfo(WarningType.MinorFormattingLoss, WarningSource.Layout, $"{x1f25abf5fb75e795}{x21e4bd206d6231f8(xa860e35844c20ac7)}");
	}

	private static string x21e4bd206d6231f8(object xa860e35844c20ac7)
	{
		string text = ((xa860e35844c20ac7 is Node) ? x699caa1974f95d1a((Node)xa860e35844c20ac7) : ((xa860e35844c20ac7 is x398b3bd0acd94b61) ? x723b19e9d6c9e1b5((x398b3bd0acd94b61)xa860e35844c20ac7) : ((!(xa860e35844c20ac7 is xc63cc34daaa2e2d9)) ? "" : x7ce09f41347809af((xc63cc34daaa2e2d9)xa860e35844c20ac7))));
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			text = "\r\n\tAt " + text;
		}
		return text;
	}

	private static string x699caa1974f95d1a(Node xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37 == null)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (Node node = xda5bf54deb817e37; node != null; node = node.xdfa6ecc6f742f086)
		{
			if (node.NodeType != NodeType.Body)
			{
				if (node.NodeType == NodeType.Document || node.NodeType == NodeType.GlossaryDocument)
				{
					break;
				}
				if (node != xda5bf54deb817e37)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(x7be41bff00df2c71(node));
			}
		}
		return stringBuilder.ToString();
	}

	private static string x7be41bff00df2c71(Node xda5bf54deb817e37)
	{
		return $"{x3b2a648f6773610c(xda5bf54deb817e37)}{x4469479613bec4d8(xda5bf54deb817e37)}";
	}

	private static string x3b2a648f6773610c(Node xda5bf54deb817e37)
	{
		switch (xda5bf54deb817e37.NodeType)
		{
		case NodeType.Any:
			return "Any";
		case NodeType.Body:
			return "Body";
		case NodeType.BookmarkEnd:
			return "Bookmark End";
		case NodeType.BookmarkStart:
			return "Bookmark Start";
		case NodeType.BuildingBlock:
			return "Building Block";
		case NodeType.Cell:
			return "Cell";
		case NodeType.Comment:
		case NodeType.CommentRangeStart:
		case NodeType.CommentRangeEnd:
			return "Comment";
		case NodeType.CustomXmlMarkup:
			return "Custom Xml Markup";
		case NodeType.Document:
			return "Document";
		case NodeType.DrawingML:
			return "DrawingML Object";
		case NodeType.FieldStart:
		case NodeType.FieldSeparator:
		case NodeType.FieldEnd:
			return "Field";
		case NodeType.Footnote:
		{
			Footnote footnote = (Footnote)xda5bf54deb817e37;
			if (footnote.FootnoteType != 0)
			{
				return "Endnote";
			}
			return "Footnote";
		}
		case NodeType.FormField:
			return "Form Field";
		case NodeType.GlossaryDocument:
			return "Glossary Document";
		case NodeType.GroupShape:
			return "Group Shape";
		case NodeType.HeaderFooter:
			switch (((HeaderFooter)xda5bf54deb817e37).HeaderFooterType)
			{
			case HeaderFooterType.FooterEven:
				return "Even Page Footer";
			case HeaderFooterType.FooterFirst:
				return "First Page Footer";
			case HeaderFooterType.FooterPrimary:
				return "Primary Footer";
			case HeaderFooterType.HeaderEven:
				return "Even Page Header";
			case HeaderFooterType.HeaderFirst:
				return "First Page Header";
			case HeaderFooterType.HeaderPrimary:
				return "Primary Header";
			}
			break;
		case NodeType.Null:
			return "Null";
		case NodeType.OfficeMath:
			return "OfficeMath Object";
		case NodeType.Paragraph:
			return "Paragraph";
		case NodeType.Row:
			return "Row";
		case NodeType.Run:
			return "Run";
		case NodeType.Section:
			return "Section";
		case NodeType.Shape:
			return "Shape";
		case NodeType.SmartTag:
			return "Smart Tag";
		case NodeType.SpecialChar:
			return "Special Character";
		case NodeType.StructuredDocumentTag:
			return "Structured Document Tag";
		case NodeType.System:
			return "System";
		case NodeType.Table:
			return "Table";
		}
		return "Undefined";
	}

	private static string x4469479613bec4d8(Node xda5bf54deb817e37)
	{
		switch (xda5bf54deb817e37.NodeType)
		{
		case NodeType.BookmarkEnd:
		{
			BookmarkEnd bookmarkEnd = (BookmarkEnd)xda5bf54deb817e37;
			return $" '{bookmarkEnd.Name}'";
		}
		case NodeType.BookmarkStart:
		{
			BookmarkStart bookmarkStart = (BookmarkStart)xda5bf54deb817e37;
			return $" '{bookmarkStart.Name}'";
		}
		case NodeType.Section:
		case NodeType.Table:
		case NodeType.Row:
		case NodeType.Cell:
		case NodeType.Paragraph:
			return $" {x71fe83ffb33433f7(xda5bf54deb817e37).ToString()}";
		case NodeType.Comment:
		{
			Comment comment = (Comment)xda5bf54deb817e37;
			return $" Id:{comment.Id} '{x0d299f323d241756.x3b67e683e83cab62(comment.GetText(), 10)}'";
		}
		case NodeType.Run:
			return $" '{x0d299f323d241756.x3b67e683e83cab62(xda5bf54deb817e37.GetText(), 10)}'";
		case NodeType.CommentRangeEnd:
		{
			CommentRangeEnd commentRangeEnd = (CommentRangeEnd)xda5bf54deb817e37;
			return $" Id:{commentRangeEnd.Id}";
		}
		case NodeType.CommentRangeStart:
		{
			CommentRangeStart commentRangeStart = (CommentRangeStart)xda5bf54deb817e37;
			return $" Id:{commentRangeStart.Id}";
		}
		case NodeType.DrawingML:
		{
			DrawingML drawingML = (DrawingML)xda5bf54deb817e37;
			return $" {drawingML.Width}x{drawingML.Height}";
		}
		case NodeType.FieldStart:
		case NodeType.FieldSeparator:
		case NodeType.FieldEnd:
			return "";
		case NodeType.Footnote:
		case NodeType.FormField:
		case NodeType.OfficeMath:
			return "";
		case NodeType.GroupShape:
		case NodeType.Shape:
		{
			ShapeBase shapeBase = (ShapeBase)xda5bf54deb817e37;
			return $" Id:{shapeBase.xea1e81378298fa81} '{shapeBase.Name}'";
		}
		case NodeType.SpecialChar:
		{
			SpecialChar specialChar = (SpecialChar)xda5bf54deb817e37;
			string text = specialChar.GetText();
			byte[] xf9a0d04800d = new byte[2]
			{
				(byte)((uint)((int)text[0] >> 8) & 0xFFu),
				(byte)(text[0] & 0xFFu)
			};
			return $" '\\x{x0d299f323d241756.x482624a13e9e9d98(xf9a0d04800d)}'";
		}
		default:
			return "";
		}
	}

	private static int x71fe83ffb33433f7(Node xda5bf54deb817e37)
	{
		int num = 1;
		Node node = xda5bf54deb817e37.xdfa6ecc6f742f086.xfe93db1ba6e25886;
		while (node != null && node != xda5bf54deb817e37)
		{
			if (node.NodeType == xda5bf54deb817e37.NodeType)
			{
				num++;
			}
			node = node.xa6890a1cb2b8896e;
		}
		return num;
	}

	private static string x723b19e9d6c9e1b5(x398b3bd0acd94b61 xd7e5673853e47af4)
	{
		return "";
	}

	private static string x7ce09f41347809af(xc63cc34daaa2e2d9 x2612f62f94df47de)
	{
		return "";
	}
}
