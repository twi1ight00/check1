using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Markup;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using xf9a9481c3f63a419;

namespace x53eb9320ebbb8395;

internal class xb267219cbd6be42f
{
	internal static void x2fb01e788b713cac(StructuredDocumentTag xabd8f8a3b7f099d3)
	{
		if (xabd8f8a3b7f099d3.Placeholder != null)
		{
			x205fb4d7c60816a3(xabd8f8a3b7f099d3);
			return;
		}
		SdtType sdtType = xabd8f8a3b7f099d3.SdtType;
		if (sdtType == SdtType.Picture)
		{
			x5f5a6f6c744f1b5c(xabd8f8a3b7f099d3);
			return;
		}
		throw new InvalidOperationException("Unknown sdt type. Please report exception.");
	}

	internal static void x5c752e32f2d4a6b2(StructuredDocumentTag xabd8f8a3b7f099d3, Node xd1d55a56253db2df)
	{
		if (xd1d55a56253db2df.NodeType == NodeType.Run)
		{
			((Run)xd1d55a56253db2df).xeedad81aaed42a76 = (xeedad81aaed42a76)xabd8f8a3b7f099d3.xde86b50786169450.x8b61531c8ea35b85();
		}
		xabd8f8a3b7f099d3.RemoveAllChildren();
		switch (xabd8f8a3b7f099d3.Level)
		{
		case MarkupLevel.Inline:
			x24ea84e1862e2f91(xabd8f8a3b7f099d3, xd1d55a56253db2df);
			break;
		case MarkupLevel.Block:
			x45d9f27464b29c0b(xabd8f8a3b7f099d3, xabd8f8a3b7f099d3.Document.ImportNode(xd1d55a56253db2df, isImportChildren: true));
			break;
		case MarkupLevel.Cell:
			x59b7e4d28a359f80(xabd8f8a3b7f099d3, xabd8f8a3b7f099d3.Document.ImportNode(xd1d55a56253db2df, isImportChildren: true), x584d4af0df3a69f0: false);
			break;
		case MarkupLevel.Row:
			x59b7e4d28a359f80(xabd8f8a3b7f099d3, xabd8f8a3b7f099d3.Document.ImportNode(xd1d55a56253db2df, isImportChildren: true), x584d4af0df3a69f0: true);
			break;
		default:
			throw new InvalidOperationException("Unknown markup level.");
		}
	}

	private static void x205fb4d7c60816a3(StructuredDocumentTag xabd8f8a3b7f099d3)
	{
		x5c752e32f2d4a6b2(xabd8f8a3b7f099d3, xabd8f8a3b7f099d3.Placeholder.FirstSection.Body.FirstParagraph);
	}

	private static void x5f5a6f6c744f1b5c(StructuredDocumentTag xabd8f8a3b7f099d3)
	{
		Paragraph paragraph = new Paragraph(xabd8f8a3b7f099d3.Document);
		paragraph.AppendChild(xabd8f8a3b7f099d3.Document.ImportNode(x69ebca85be220407(), isImportChildren: true));
		x5c752e32f2d4a6b2(xabd8f8a3b7f099d3, paragraph);
	}

	private static void x24ea84e1862e2f91(StructuredDocumentTag xabd8f8a3b7f099d3, Node xd1d55a56253db2df)
	{
		if (x2b1ee3a87b36a988.xb6578aa94903986e(xd1d55a56253db2df))
		{
			CompositeNode compositeNode = (CompositeNode)xd1d55a56253db2df;
			xabd8f8a3b7f099d3.AppendChild(xabd8f8a3b7f099d3.Document.ImportNode(compositeNode.FirstChild, isImportChildren: false));
			return;
		}
		if (x2b1ee3a87b36a988.x15bc008974f7d712(xd1d55a56253db2df))
		{
			xabd8f8a3b7f099d3.AppendChild(xabd8f8a3b7f099d3.Document.ImportNode(xd1d55a56253db2df, isImportChildren: false));
			return;
		}
		throw new InvalidOperationException("Can not insert such node at Inline level.");
	}

	private static void x45d9f27464b29c0b(StructuredDocumentTag xabd8f8a3b7f099d3, Node xd1d55a56253db2df)
	{
		if (x2b1ee3a87b36a988.xb6578aa94903986e(xd1d55a56253db2df))
		{
			xabd8f8a3b7f099d3.AppendChild(xd1d55a56253db2df);
			return;
		}
		if (x2b1ee3a87b36a988.x15bc008974f7d712(xd1d55a56253db2df))
		{
			Paragraph paragraph = new Paragraph(xabd8f8a3b7f099d3.Document);
			xabd8f8a3b7f099d3.AppendChild(paragraph);
			paragraph.AppendChild(xd1d55a56253db2df);
			return;
		}
		throw new InvalidOperationException("Can not insert such node at Block level.");
	}

	private static void x59b7e4d28a359f80(StructuredDocumentTag xabd8f8a3b7f099d3, Node xd1d55a56253db2df, bool x584d4af0df3a69f0)
	{
		if ((x584d4af0df3a69f0 && x2b1ee3a87b36a988.x1a81241312e9c0d5(xd1d55a56253db2df)) || (!x584d4af0df3a69f0 && x2b1ee3a87b36a988.x4d9a8ed501b3faff(xd1d55a56253db2df)))
		{
			xabd8f8a3b7f099d3.AppendChild(xd1d55a56253db2df);
		}
		else if (x2b1ee3a87b36a988.xb6578aa94903986e(xd1d55a56253db2df))
		{
			CompositeNode compositeNode = (x584d4af0df3a69f0 ? ((CompositeNode)new Row(xabd8f8a3b7f099d3.Document)) : ((CompositeNode)new Cell(xabd8f8a3b7f099d3.Document)));
			xabd8f8a3b7f099d3.AppendChild(compositeNode);
			if (x584d4af0df3a69f0 && !x2b1ee3a87b36a988.x4d9a8ed501b3faff(xd1d55a56253db2df))
			{
				Cell cell = new Cell(xabd8f8a3b7f099d3.Document);
				compositeNode.AppendChild(cell);
				compositeNode = cell;
			}
			compositeNode.AppendChild(xd1d55a56253db2df);
		}
		else
		{
			if (!x2b1ee3a87b36a988.x15bc008974f7d712(xd1d55a56253db2df))
			{
				throw new InvalidOperationException(string.Format("Can not insert such node at {0} level", x584d4af0df3a69f0 ? "Row" : "Cell"));
			}
			Paragraph paragraph = new Paragraph(xabd8f8a3b7f099d3.Document);
			paragraph.AppendChild(xd1d55a56253db2df);
			x59b7e4d28a359f80(xabd8f8a3b7f099d3, paragraph, x584d4af0df3a69f0);
		}
	}

	private static DrawingML x69ebca85be220407()
	{
		using Stream stream = xed747ca236d86aa0.xe1cd764b6fb0d6f6("Aspose.Words.Resources.SdtImageDefaultContent.docx");
		Document document = new Document(stream);
		return (DrawingML)document.GetChild(NodeType.DrawingML, 0, isDeep: true);
	}
}
