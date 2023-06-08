using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class x6d232feca81d2281 : xe25d778fe9f1252a
{
	private readonly x1552b3704ef89039 x8ea780730cc1dd22;

	private readonly ArrayList x80ba758147b2f286 = new ArrayList();

	private readonly Bookmark x9e2ec238101d57ab;

	private bool x3f59dd524d3ce0ec;

	private Paragraph xfbafc9ec77be999c;

	internal ArrayList xe81b07db02efab86 => x80ba758147b2f286;

	private x6d232feca81d2281(x1552b3704ef89039 fieldToc)
	{
		x8ea780730cc1dd22 = fieldToc;
		if (x8ea780730cc1dd22.xc41474d1214de0c6)
		{
			x9e2ec238101d57ab = x8ea780730cc1dd22.x3fb2df8a80e0ef08();
		}
		else
		{
			x3f59dd524d3ce0ec = true;
		}
	}

	internal static ArrayList xae29c9998cc24c8a(x1552b3704ef89039 xe01ae93d9fe5a880)
	{
		x6d232feca81d2281 x6d232feca81d2282 = new x6d232feca81d2281(xe01ae93d9fe5a880);
		x6d232feca81d2282.xae29c9998cc24c8a();
		return x6d232feca81d2282.xe81b07db02efab86;
	}

	private void xae29c9998cc24c8a()
	{
		Document document = x8ea780730cc1dd22.x357c90b33d6bb8e6();
		foreach (Section section in document.Sections)
		{
			if (!section.Body.Accept(this))
			{
				break;
			}
		}
	}

	protected override void OnFieldExtracted(Field field)
	{
		switch (field.Type)
		{
		case FieldType.FieldTOCEntry:
			xad0223c5bb81f66c((x4724ed988e1000da)field);
			break;
		case FieldType.FieldSequence:
			x9b2fc77a71680f7d((x811d4618e5f42dc7)field);
			break;
		}
	}

	private void xad0223c5bb81f66c(x4724ed988e1000da xe01ae93d9fe5a880)
	{
		if ((x8ea780730cc1dd22.x53d0a161d1c192c9 || x8ea780730cc1dd22.xad17dbc959ad3c0f) && x8ea780730cc1dd22.x69f691beb7246b92.x53ab91850c4897b0(xe01ae93d9fe5a880.x504f3d4040b356d7) && (!x0d299f323d241756.x5959bccb67bbf051(x8ea780730cc1dd22.x8e990dc466d0c060) || x0d299f323d241756.x90637a473b1ceaaa(xe01ae93d9fe5a880.xe12071fbe3d25fe5, x8ea780730cc1dd22.x8e990dc466d0c060)))
		{
			x80ba758147b2f286.Add(xe01ae93d9fe5a880);
		}
	}

	private void x9b2fc77a71680f7d(x811d4618e5f42dc7 xe01ae93d9fe5a880)
	{
		if (x8ea780730cc1dd22.x694a16375b48c186 && (x0d299f323d241756.x90637a473b1ceaaa(xe01ae93d9fe5a880.x70c9403957f529f2, x8ea780730cc1dd22.x54c93cd442d54b74) || x0d299f323d241756.x90637a473b1ceaaa(xe01ae93d9fe5a880.x70c9403957f529f2, x8ea780730cc1dd22.x02d7df2fcfcca2f8)))
		{
			Paragraph parentParagraph = xe01ae93d9fe5a880.Start.ParentParagraph;
			Node firstNode = ((!x0d299f323d241756.x5959bccb67bbf051(x8ea780730cc1dd22.x02d7df2fcfcca2f8)) ? parentParagraph.FirstChild : xe01ae93d9fe5a880.End.NextSibling);
			Node lastChild = parentParagraph.LastChild;
			xbc8b4f5f5b519144(parentParagraph, new x5f0e8a959fb1463f(0, firstNode, lastChild));
		}
	}

	public override VisitorAction VisitBookmarkStart(BookmarkStart bookmarkStart)
	{
		x3f59dd524d3ce0ec = x3f59dd524d3ce0ec || x5ff20b6bdb51f75a(bookmarkStart);
		return VisitorAction.Continue;
	}

	private bool x5ff20b6bdb51f75a(Node xda5bf54deb817e37)
	{
		if (x9e2ec238101d57ab != null)
		{
			return xda5bf54deb817e37 == x9e2ec238101d57ab.BookmarkStart;
		}
		return false;
	}

	public override VisitorAction VisitBookmarkEnd(BookmarkEnd bookmarkEnd)
	{
		if (!x49545e1e2e61e51c(bookmarkEnd))
		{
			return VisitorAction.Continue;
		}
		return VisitorAction.Stop;
	}

	private bool x49545e1e2e61e51c(Node xda5bf54deb817e37)
	{
		if (x9e2ec238101d57ab != null)
		{
			return xda5bf54deb817e37 == x9e2ec238101d57ab.BookmarkEnd;
		}
		return false;
	}

	public override VisitorAction VisitParagraphStart(Paragraph paragraph)
	{
		x250990cab00959fa(paragraph);
		return VisitorAction.Continue;
	}

	private void x250990cab00959fa(Paragraph x31e6518f5e08db6c)
	{
		bool flag = xf0cc86f5541cec0f(x31e6518f5e08db6c);
		if (!flag)
		{
			flag = x66d009abe101e9b4(x31e6518f5e08db6c);
		}
		if (!flag)
		{
			xe1ed215e30022fa4(x31e6518f5e08db6c);
		}
	}

	private void xbc8b4f5f5b519144(Paragraph x31e6518f5e08db6c, x5f0e8a959fb1463f xff5656a420791c2a)
	{
		if (xfbafc9ec77be999c == x31e6518f5e08db6c)
		{
			return;
		}
		xfbafc9ec77be999c = x31e6518f5e08db6c;
		Node node = ((xff5656a420791c2a.xe98eb74983649df0 != null) ? xff5656a420791c2a.xe98eb74983649df0 : x31e6518f5e08db6c.xfe93db1ba6e25886);
		Node node2 = ((xff5656a420791c2a.x1f63ab34d720cabb != null) ? xff5656a420791c2a.x1f63ab34d720cabb : x31e6518f5e08db6c.xc0f45b01af564b77);
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		if (node != null && node2 != null)
		{
			x7e263f21a73a027a x7e263f21a73a027a = new x7e263f21a73a027a(node, node2);
			foreach (Node item in x7e263f21a73a027a)
			{
				if (item == node)
				{
					flag = true;
				}
				if (item == x8ea780730cc1dd22.End)
				{
					flag2 = true;
				}
				if (item == x8ea780730cc1dd22.Start && item != node && flag)
				{
					x831b041b50a6d834(x31e6518f5e08db6c, xff5656a420791c2a.x504f3d4040b356d7, node, x8ea780730cc1dd22.Start.PreviousSibling);
					flag3 = true;
				}
				else if (item == node2 && item != x8ea780730cc1dd22.End && flag2)
				{
					x831b041b50a6d834(x31e6518f5e08db6c, xff5656a420791c2a.x504f3d4040b356d7, x8ea780730cc1dd22.End.NextSibling, node2);
					flag3 = true;
				}
			}
		}
		if (!flag3)
		{
			x831b041b50a6d834(x31e6518f5e08db6c, xff5656a420791c2a);
		}
	}

	private void x831b041b50a6d834(Paragraph x31e6518f5e08db6c, x5f0e8a959fb1463f xff5656a420791c2a)
	{
		x80ba758147b2f286.Add(new x7eda97d1ce06039c(x8ea780730cc1dd22, x31e6518f5e08db6c, xff5656a420791c2a));
	}

	private void x831b041b50a6d834(Paragraph x31e6518f5e08db6c, int xecf86884efc78f9d, Node x8816abba0e9cc621, Node x8ed068294dc65f8b)
	{
		x831b041b50a6d834(x31e6518f5e08db6c, new x5f0e8a959fb1463f(xecf86884efc78f9d, x8816abba0e9cc621, x8ed068294dc65f8b));
	}

	private bool xdfb7a27fcdfff83e(Paragraph x31e6518f5e08db6c, int x66bbd7ed8c65740d)
	{
		x5f0e8a959fb1463f x5f0e8a959fb1463f2 = null;
		if (xe2ab94acf964af40.x451fe5122b35ec1f(x66bbd7ed8c65740d))
		{
			if (x3f59dd524d3ce0ec)
			{
				x5f0e8a959fb1463f2 = new x5f0e8a959fb1463f(x66bbd7ed8c65740d);
			}
			else if (x9e2ec238101d57ab != null && x9e2ec238101d57ab.BookmarkStart.ParentNode == x31e6518f5e08db6c)
			{
				x5f0e8a959fb1463f2 = new x5f0e8a959fb1463f(x66bbd7ed8c65740d, x9e2ec238101d57ab.BookmarkStart, null);
			}
		}
		bool flag = x5f0e8a959fb1463f2 != null;
		if (flag)
		{
			xbc8b4f5f5b519144(x31e6518f5e08db6c, x5f0e8a959fb1463f2);
		}
		return flag;
	}

	private bool xf0cc86f5541cec0f(Paragraph x31e6518f5e08db6c)
	{
		if (!x8ea780730cc1dd22.x93902cc13041c9d1)
		{
			return false;
		}
		if (xdfb7a27fcdfff83e(x31e6518f5e08db6c, x8ea780730cc1dd22.xa67a34cfefd7d4cd(x31e6518f5e08db6c.xfcffbd79482d97c7.Name)))
		{
			return true;
		}
		return x1d56b86e3f7f06a7(x31e6518f5e08db6c, xe2ab94acf964af40.xffb68b1ddc32f0fd);
	}

	private bool x66d009abe101e9b4(Paragraph x31e6518f5e08db6c)
	{
		if (x434509fc81c70bef(x31e6518f5e08db6c))
		{
			return false;
		}
		bool result = false;
		if (x8ea780730cc1dd22.x15a2a869ee49e3d9)
		{
			int x66bbd7ed8c65740d = xb78ae87d3b92c603(x31e6518f5e08db6c.ParagraphFormat.OutlineLevel);
			if (x8ea780730cc1dd22.x85f294bff8874c5a.x53ab91850c4897b0(x66bbd7ed8c65740d))
			{
				result = xdfb7a27fcdfff83e(x31e6518f5e08db6c, x66bbd7ed8c65740d);
			}
		}
		return result;
	}

	private void xe1ed215e30022fa4(Paragraph x31e6518f5e08db6c)
	{
		if (!x8ea780730cc1dd22.x694a16375b48c186 && (!x8ea780730cc1dd22.x93902cc13041c9d1 || x8ea780730cc1dd22.x8c3e6f6cd637156f) && !xdfb7a27fcdfff83e(x31e6518f5e08db6c, xecadba242733f924(x31e6518f5e08db6c.xfcffbd79482d97c7)))
		{
			x1d56b86e3f7f06a7(x31e6518f5e08db6c, x8ea780730cc1dd22.x85f294bff8874c5a);
		}
	}

	private bool x1d56b86e3f7f06a7(Paragraph x31e6518f5e08db6c, xe2ab94acf964af40 x81c82ecbde80d03d)
	{
		xb5986aa209d01503 x4f2988228eb3d = new xb5986aa209d01503(this, x81c82ecbde80d03d);
		bool flag = false;
		bool result = false;
		foreach (Node childNode in x31e6518f5e08db6c.ChildNodes)
		{
			NodeType nodeType = childNode.NodeType;
			switch (nodeType)
			{
			case NodeType.FieldStart:
				if (((FieldStart)childNode).FieldType == FieldType.FieldTOC)
				{
					flag = true;
				}
				break;
			case NodeType.FieldEnd:
				if (((FieldEnd)childNode).FieldType == FieldType.FieldTOC)
				{
					flag = false;
				}
				break;
			}
			if (flag)
			{
				continue;
			}
			if (childNode.IsComposite)
			{
				if (xe9e3385f05c5c6f9((CompositeNode)childNode))
				{
					break;
				}
				continue;
			}
			switch (nodeType)
			{
			case NodeType.Run:
				if (x67c955c68c7f7566(x4f2988228eb3d, (Run)childNode))
				{
					result = true;
				}
				break;
			case NodeType.BookmarkStart:
				if (x5ff20b6bdb51f75a(childNode))
				{
					x3f59dd524d3ce0ec = true;
				}
				break;
			case NodeType.BookmarkEnd:
				if (x49545e1e2e61e51c(childNode))
				{
					goto end_IL_00c5;
				}
				break;
			}
			continue;
			end_IL_00c5:
			break;
		}
		return result;
	}

	private bool xe9e3385f05c5c6f9(CompositeNode xb6a159a84cb992d6)
	{
		if (x9e2ec238101d57ab == null)
		{
			return false;
		}
		bool flag = false;
		foreach (Node childNode in xb6a159a84cb992d6.ChildNodes)
		{
			if (childNode.IsComposite)
			{
				flag = xe9e3385f05c5c6f9((CompositeNode)childNode);
			}
			else if (childNode.NodeType == NodeType.BookmarkStart)
			{
				x3f59dd524d3ce0ec = x3f59dd524d3ce0ec || childNode == x9e2ec238101d57ab.BookmarkStart;
			}
			else if (childNode.NodeType == NodeType.BookmarkEnd)
			{
				flag = childNode == x9e2ec238101d57ab.BookmarkEnd;
			}
			if (flag)
			{
				break;
			}
		}
		return flag;
	}

	private bool x67c955c68c7f7566(xb5986aa209d01503 x4f2988228eb3d078, Run xb0e5d73738e62f9e)
	{
		if (!x3f59dd524d3ce0ec)
		{
			return false;
		}
		int num = x4f2988228eb3d078.x0d965722d540053e(xb0e5d73738e62f9e);
		if (xe2ab94acf964af40.x451fe5122b35ec1f(num))
		{
			Node lastNode = xd8c9eeac61b8b14b(xb0e5d73738e62f9e, num);
			x5f0e8a959fb1463f xff5656a420791c2a = new x5f0e8a959fb1463f(num, xb0e5d73738e62f9e, lastNode);
			xbc8b4f5f5b519144(xb0e5d73738e62f9e.ParentParagraph, xff5656a420791c2a);
			return true;
		}
		return false;
	}

	private Node xd8c9eeac61b8b14b(Run x4c4038616518ba48, int x66bbd7ed8c65740d)
	{
		if (x4c4038616518ba48 == null)
		{
			return null;
		}
		Run result = x4c4038616518ba48;
		for (Node nextSibling = x4c4038616518ba48.NextSibling; nextSibling != null; nextSibling = nextSibling.NextSibling)
		{
			switch (nextSibling.NodeType)
			{
			case NodeType.Run:
			{
				Run run = (Run)nextSibling;
				if (x66bbd7ed8c65740d == x5aee3a86e72f3836(run))
				{
					result = run;
					continue;
				}
				break;
			}
			default:
				continue;
			case NodeType.CommentRangeEnd:
				break;
			}
			break;
		}
		return result;
	}

	private int xecadba242733f924(Style x44ecfea61c937b8e)
	{
		bool flag = x8ea780730cc1dd22.xad17dbc959ad3c0f || x8ea780730cc1dd22.x53d0a161d1c192c9;
		if (!x8ea780730cc1dd22.x8c3e6f6cd637156f && flag)
		{
			return -1;
		}
		return xecadba242733f924(x44ecfea61c937b8e, x8ea780730cc1dd22.x85f294bff8874c5a);
	}

	private int xecadba242733f924(Style x44ecfea61c937b8e, xe2ab94acf964af40 x0b7246f0bf2a3e3a)
	{
		if (x44ecfea61c937b8e.ParagraphFormat == null)
		{
			return -1;
		}
		int num = xb78ae87d3b92c603(x44ecfea61c937b8e.ParagraphFormat.OutlineLevel);
		if (x0b7246f0bf2a3e3a.x53ab91850c4897b0(num))
		{
			return num;
		}
		return x8ea780730cc1dd22.xa67a34cfefd7d4cd(x44ecfea61c937b8e.Name);
	}

	private static int xb78ae87d3b92c603(OutlineLevel x6c68b2da2a479251)
	{
		return x6c68b2da2a479251 switch
		{
			OutlineLevel.Level1 => 1, 
			OutlineLevel.Level2 => 2, 
			OutlineLevel.Level3 => 3, 
			OutlineLevel.Level4 => 4, 
			OutlineLevel.Level5 => 5, 
			OutlineLevel.Level6 => 6, 
			OutlineLevel.Level7 => 7, 
			OutlineLevel.Level8 => 8, 
			OutlineLevel.Level9 => 9, 
			_ => -1, 
		};
	}

	private int x5aee3a86e72f3836(xcf3b0f04424de818 x31545d7c306a55e4)
	{
		return x5aee3a86e72f3836(x31545d7c306a55e4, x8ea780730cc1dd22.x85f294bff8874c5a);
	}

	internal int x5aee3a86e72f3836(xcf3b0f04424de818 x31545d7c306a55e4, xe2ab94acf964af40 x0b7246f0bf2a3e3a)
	{
		xeedad81aaed42a76 xc87649c48f7756d = x31545d7c306a55e4.xc87649c48f7756d2;
		StyleCollection styles = x31545d7c306a55e4.xbcf7b328881df2ae.Styles;
		Style style = styles.xf194004582627ed5(xc87649c48f7756d.x8301ab10c226b0c2, 10);
		Style style2 = styles.x1976fb6958cf7237(style.x4cf1854ef833220f, x988fcf605f8efa7e: false);
		if (style2 == null)
		{
			return -1;
		}
		return xecadba242733f924(style2, x0b7246f0bf2a3e3a);
	}

	private bool x434509fc81c70bef(Paragraph x31e6518f5e08db6c)
	{
		if (x31e6518f5e08db6c != x8ea780730cc1dd22.Start.ParentParagraph)
		{
			return x31e6518f5e08db6c == x8ea780730cc1dd22.End.ParentParagraph;
		}
		return true;
	}
}
