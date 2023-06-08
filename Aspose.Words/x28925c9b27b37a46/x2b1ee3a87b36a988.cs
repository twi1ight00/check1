using Aspose.Words;
using Aspose.Words.Markup;
using Aspose.Words.Tables;
using x53eb9320ebbb8395;

namespace x28925c9b27b37a46;

internal class x2b1ee3a87b36a988
{
	private x2b1ee3a87b36a988()
	{
	}

	internal static int x1deebb03a3d03a50(Node xda5bf54deb817e37)
	{
		NodeType nodeType = xda5bf54deb817e37.NodeType;
		if (nodeType == NodeType.Run)
		{
			return xda5bf54deb817e37.GetText().Length;
		}
		if (x0f86e763fa9a14ff(xda5bf54deb817e37))
		{
			return 0;
		}
		return 1;
	}

	internal static bool x1d96b06babfe1068(Node xda5bf54deb817e37, Node xe6faebae794f11cf)
	{
		if (xda5bf54deb817e37 != xe6faebae794f11cf)
		{
			return xda5bf54deb817e37.xd5b26cfce8730b50(xe6faebae794f11cf);
		}
		return true;
	}

	internal static Node x6e7216533ee7db3e(Node xda5bf54deb817e37, NodeType xd080fb3c547ae2bf)
	{
		Node ancestor = xda5bf54deb817e37.GetAncestor(xd080fb3c547ae2bf);
		if (ancestor == null)
		{
			return xda5bf54deb817e37;
		}
		return ancestor;
	}

	internal static int xf36c5c9e57c969ad(Node xda5bf54deb817e37)
	{
		int num = 0;
		while (xda5bf54deb817e37 != null)
		{
			if (NodeType.Table == xda5bf54deb817e37.NodeType)
			{
				num++;
			}
			xda5bf54deb817e37 = xda5bf54deb817e37.ParentNode;
			if (xda5bf54deb817e37 != null)
			{
				switch (xda5bf54deb817e37.NodeType)
				{
				case NodeType.GroupShape:
				case NodeType.Shape:
				case NodeType.Comment:
				case NodeType.Footnote:
					xda5bf54deb817e37 = null;
					break;
				}
			}
		}
		return num;
	}

	internal static bool x0f86e763fa9a14ff(Node xda5bf54deb817e37)
	{
		switch (xda5bf54deb817e37.NodeType)
		{
		case NodeType.BookmarkStart:
		case NodeType.BookmarkEnd:
		case NodeType.SmartTag:
		case NodeType.CustomXmlMarkup:
		case NodeType.StructuredDocumentTag:
		case NodeType.CommentRangeStart:
		case NodeType.CommentRangeEnd:
			return true;
		default:
			return false;
		}
	}

	internal static bool xb871ce087a6d574e(Node xda5bf54deb817e37)
	{
		switch (xda5bf54deb817e37.NodeType)
		{
		case NodeType.Document:
		case NodeType.HeaderFooter:
		case NodeType.GroupShape:
		case NodeType.Shape:
		case NodeType.Comment:
		case NodeType.Footnote:
			return true;
		default:
			return false;
		}
	}

	internal static bool xb6578aa94903986e(Node xda5bf54deb817e37)
	{
		switch (xda5bf54deb817e37.NodeType)
		{
		case NodeType.Table:
		case NodeType.Paragraph:
			return true;
		case NodeType.StructuredDocumentTag:
			return ((StructuredDocumentTag)xda5bf54deb817e37).Level == MarkupLevel.Block;
		case NodeType.CustomXmlMarkup:
			return ((CustomXmlMarkup)xda5bf54deb817e37).Level == MarkupLevel.Block;
		default:
			return false;
		}
	}

	internal static bool x1a81241312e9c0d5(Node xda5bf54deb817e37)
	{
		return xda5bf54deb817e37.NodeType switch
		{
			NodeType.Row => true, 
			NodeType.StructuredDocumentTag => ((StructuredDocumentTag)xda5bf54deb817e37).Level == MarkupLevel.Row, 
			NodeType.CustomXmlMarkup => ((CustomXmlMarkup)xda5bf54deb817e37).Level == MarkupLevel.Row, 
			_ => false, 
		};
	}

	internal static bool x4d9a8ed501b3faff(Node xda5bf54deb817e37)
	{
		return xda5bf54deb817e37.NodeType switch
		{
			NodeType.Cell => true, 
			NodeType.StructuredDocumentTag => ((StructuredDocumentTag)xda5bf54deb817e37).Level == MarkupLevel.Cell, 
			NodeType.CustomXmlMarkup => ((CustomXmlMarkup)xda5bf54deb817e37).Level == MarkupLevel.Cell, 
			_ => false, 
		};
	}

	internal static bool x15bc008974f7d712(Node xda5bf54deb817e37)
	{
		switch (xda5bf54deb817e37.NodeType)
		{
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
		case NodeType.CommentRangeStart:
		case NodeType.CommentRangeEnd:
		case NodeType.DrawingML:
		case NodeType.OfficeMath:
		case NodeType.SubDocument:
			return true;
		case NodeType.StructuredDocumentTag:
			return ((StructuredDocumentTag)xda5bf54deb817e37).Level == MarkupLevel.Inline;
		case NodeType.CustomXmlMarkup:
			return ((CustomXmlMarkup)xda5bf54deb817e37).Level == MarkupLevel.Inline;
		default:
			return false;
		}
	}

	internal static bool x7a452479f1ce15c7(x55997ac957018945 xe7df797fcd76809c, Node x40e458b3a58f5782)
	{
		if (x40e458b3a58f5782 is x55997ac957018945)
		{
			return xe7df797fcd76809c.x57b60ae60739c9b5 == ((x55997ac957018945)x40e458b3a58f5782).x57b60ae60739c9b5;
		}
		return xe7df797fcd76809c.x57b60ae60739c9b5 switch
		{
			MarkupLevel.Block => xb6578aa94903986e(x40e458b3a58f5782), 
			MarkupLevel.Cell => x4d9a8ed501b3faff(x40e458b3a58f5782), 
			MarkupLevel.Inline => x15bc008974f7d712(x40e458b3a58f5782), 
			MarkupLevel.Row => x1a81241312e9c0d5(x40e458b3a58f5782), 
			_ => false, 
		};
	}

	internal static bool xd601422bf435ea8c(NodeType x558c88d8389dcfcf)
	{
		if (x558c88d8389dcfcf != 0)
		{
			return !x0302c7317ec57e52(x558c88d8389dcfcf);
		}
		return false;
	}

	internal static bool x0302c7317ec57e52(NodeType x558c88d8389dcfcf)
	{
		if (x558c88d8389dcfcf != NodeType.StructuredDocumentTag && x558c88d8389dcfcf != NodeType.CustomXmlMarkup)
		{
			return x558c88d8389dcfcf == NodeType.SmartTag;
		}
		return true;
	}

	internal static bool x0302c7317ec57e52(Node xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37 != null)
		{
			return x0302c7317ec57e52(xda5bf54deb817e37.NodeType);
		}
		return false;
	}

	internal static Node xd5642c127a31bf8a(Node x4606b15cf4290d0f)
	{
		Node node = null;
		Node node2 = x4606b15cf4290d0f;
		while (node2 != null && node == null)
		{
			if (x0302c7317ec57e52(node2))
			{
				CompositeNode compositeNode = (CompositeNode)node2;
				node = compositeNode.xfe93db1ba6e25886;
			}
			else
			{
				node = node2;
			}
			node2 = node2.NextSibling;
		}
		return node;
	}

	internal static Node x006ee30bbb04e012(Node x5c5e8cc77d6b48b2)
	{
		Node node = null;
		Node node2 = x5c5e8cc77d6b48b2;
		while (node2 != null && node == null)
		{
			if (x0302c7317ec57e52(node2))
			{
				CompositeNode compositeNode = (CompositeNode)node2;
				node = compositeNode.xc0f45b01af564b77;
			}
			else
			{
				node = node2;
			}
			node2 = node2.PreviousSibling;
		}
		return node;
	}

	internal static Table x01d3b14e93659fbe(Node xda5bf54deb817e37)
	{
		return (Table)((xda5bf54deb817e37.NodeType == NodeType.Table) ? xda5bf54deb817e37 : ((Table)xda5bf54deb817e37.xbf2f86e9a68ae8e6(NodeType.Table)));
	}

	internal static int x30eaba2971e72614(Node xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37.ParentNode == null)
		{
			return 0;
		}
		int num = 0;
		for (Node node = xda5bf54deb817e37.ParentNode.FirstChild; node != xda5bf54deb817e37; node = node.NextSibling)
		{
			num++;
		}
		return num;
	}

	internal static int x2af57cfa111d1019(Node xda5bf54deb817e37)
	{
		int num = 0;
		while (xda5bf54deb817e37 != null)
		{
			xda5bf54deb817e37 = xda5bf54deb817e37.ParentNode;
			num++;
		}
		return num;
	}

	internal static Node x9b358cd73ee85ee5(Node xda5bf54deb817e37, int x57e9faf3ffdc07cc)
	{
		while (x57e9faf3ffdc07cc > 0 && xda5bf54deb817e37 != null)
		{
			x57e9faf3ffdc07cc--;
			xda5bf54deb817e37 = xda5bf54deb817e37.ParentNode;
		}
		return xda5bf54deb817e37;
	}
}
