using System;
using System.Collections;
using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Tables;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x4adf554d20d941a6;
using x6c95d9cf46ff5f25;

namespace x59d6a4fc5007b7a4;

internal class x487cdc969fefe3d6
{
	private readonly Document xd1424e1a0bb4a72b;

	private readonly xdeb77ea37ad74c56 x83d0f75f3858e3a4;

	private readonly Hashtable x4bd039d469a1155d;

	private readonly Stack x5b56be00bfa18d9a = new Stack();

	private readonly Stack x1fe9d199bfe5160a = new Stack();

	private readonly x34b8d86b79df411d x20af2534649969eb;

	private bool x783324369c7d8f45;

	private bool x2ddc466f35bc1e01;

	private ArrayList x1e58f3079b9b34b3;

	private readonly x42f2a218ce59dafb xfec435486c6e6aba;

	private x56410a8dd70087c5 xb01da31da3ec3cd2;

	private x56410a8dd70087c5 x0a9500ca9f7f6a64;

	private x56410a8dd70087c5 x4ae0c63fa3fd8ff1;

	private x56410a8dd70087c5 xba4e0d166e6035dd;

	private x5015a0e79fc04a51 xa3f9b2fd98264390;

	private StoryType x476547a1677d89f7;

	private readonly x151a606008e93e1b xccd27483b5d857a0;

	private bool x7adacf577c3a6e2f;

	private readonly x17dcbf5fe3c0d2d2 x3d3ebc31b37b2a88;

	private Stack xcb81f6e0de90b1bd = new Stack();

	private xa4665f59f0cb55bd x9d0fd2e8c3552ad6;

	internal object x35cfcea4890f4e7d => x56410a8dd70087c5;

	public x56410a8dd70087c5 x56410a8dd70087c5 => xb01da31da3ec3cd2;

	public x5015a0e79fc04a51 xbe1e23e7d5b43370 => xa3f9b2fd98264390;

	private x98739d759efb5fe7 x180f9c8380162d4e => x20af2534649969eb.x180f9c8380162d4e;

	internal x487cdc969fefe3d6(Document document, xdeb77ea37ad74c56 options, x17dcbf5fe3c0d2d2 context, Hashtable bookmarks)
		: this((CompositeNode)document, options, context, bookmarks)
	{
	}

	internal x487cdc969fefe3d6(CompositeNode node, xdeb77ea37ad74c56 options, x17dcbf5fe3c0d2d2 context, Hashtable bookmarks, StoryType storyType)
		: this(node, options, context, bookmarks)
	{
		x476547a1677d89f7 = storyType;
	}

	private x487cdc969fefe3d6(CompositeNode node, xdeb77ea37ad74c56 options, x17dcbf5fe3c0d2d2 context, Hashtable bookmarks)
	{
		xd1424e1a0bb4a72b = node.x357c90b33d6bb8e6();
		x83d0f75f3858e3a4 = options;
		x3d3ebc31b37b2a88 = context;
		x4bd039d469a1155d = bookmarks;
		xfec435486c6e6aba = new x42f2a218ce59dafb(xd1424e1a0bb4a72b, x83d0f75f3858e3a4, x3d3ebc31b37b2a88);
		xccd27483b5d857a0 = new x151a606008e93e1b(null);
		x20af2534649969eb = new x34b8d86b79df411d(new x7e263f21a73a027a(node, node));
		x74f5a1ef3906e23c();
	}

	internal x487cdc969fefe3d6(x7e263f21a73a027a nodes, x56410a8dd70087c5 first)
	{
		xd1424e1a0bb4a72b = nodes.x12cb12b5d2cad53d.x40212106aad8a8b0.x357c90b33d6bb8e6();
		x83d0f75f3858e3a4 = first.x2c8c6741422a1298.xdeb77ea37ad74c56;
		x3d3ebc31b37b2a88 = first.x2c8c6741422a1298.x17dcbf5fe3c0d2d2;
		x4bd039d469a1155d = first.x2c8c6741422a1298.xeafe18c850ae3127;
		xfec435486c6e6aba = new x42f2a218ce59dafb(xd1424e1a0bb4a72b, x83d0f75f3858e3a4, x3d3ebc31b37b2a88);
		xccd27483b5d857a0 = new x151a606008e93e1b(first);
		x20af2534649969eb = new x34b8d86b79df411d(nodes);
		x9d0fd2e8c3552ad6 = new xa4665f59f0cb55bd(new x91866f79774c2b6a(nodes));
		x74f5a1ef3906e23c();
		xf3f447691ab38eee xf3f447691ab38eee = first.x53111d6596d16a99.xb3a79d506b0e2f7f.x8b61531c8ea35b85();
		if (!xf3f447691ab38eee.xd8b11076ff837685(first))
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gaaibchilcoiicfjgcmjicdkbnjklbblkbilobplkagmanmm", 571506627)));
		}
		xb01da31da3ec3cd2 = (xf3f447691ab38eee.x355eaee82ffc1f46() ? ((x56410a8dd70087c5)xf3f447691ab38eee.x35cfcea4890f4e7d) : null);
		x2ddc466f35bc1e01 = first.x53111d6596d16a99 is xb1f375aa1b12d10f;
		x9f53aa0242429602(first);
		xfec435486c6e6aba.x4b6d377a3c5aa5e8 = first.x73ce1c9078892ff3(false, FieldType.FieldTOC) != null;
	}

	internal bool x47f176deff0d42e2()
	{
		x7632937e3bef5cd8();
		if (xd284c348c423b930())
		{
			return true;
		}
		bool flag = false;
		bool result = true;
		while (!flag)
		{
			if (!x7adacf577c3a6e2f)
			{
				result = false;
				break;
			}
			switch (x180f9c8380162d4e.x40212106aad8a8b0.NodeType)
			{
			case NodeType.Document:
				result = !(flag = xc15d7b025464327d());
				break;
			case NodeType.Section:
				flag = x8810991188d773db();
				break;
			case NodeType.HeaderFooter:
				flag = xc2bbf1463ef5659c();
				break;
			case NodeType.Body:
				flag = x79ddf512b76f4062();
				break;
			case NodeType.Paragraph:
				flag = xb61b92627231b7a8();
				break;
			case NodeType.Table:
				flag = x5b7cc3ed4565d299();
				break;
			case NodeType.Row:
				flag = x2e5bc8a8aa47e75f();
				break;
			case NodeType.Cell:
				flag = xb8fe14fc671949f3();
				break;
			case NodeType.BookmarkEnd:
				flag = x85760ef70219c76f();
				break;
			case NodeType.BookmarkStart:
				flag = x86225b1548fac515();
				break;
			case NodeType.Comment:
				flag = xf3a1cfbffa44728c();
				break;
			case NodeType.CommentRangeStart:
			case NodeType.CommentRangeEnd:
				flag = xa4fbea35671a9649();
				break;
			case NodeType.Footnote:
				flag = x69d502aaca08ee16();
				break;
			case NodeType.FieldEnd:
				flag = x221bac6efb19ed4e();
				break;
			case NodeType.FieldSeparator:
				flag = x22ac2c766ffad352();
				break;
			case NodeType.FieldStart:
				flag = xe0e68c1b48884a8c();
				break;
			case NodeType.FormField:
				flag = x0ba9d5116fc4c47f();
				break;
			case NodeType.GroupShape:
				flag = xfcbc4da25426445a();
				break;
			case NodeType.Shape:
				flag = x5f90ceadefcc8b28();
				break;
			case NodeType.DrawingML:
				flag = x5d261db5e578d7f7();
				break;
			case NodeType.SmartTag:
				flag = xdc95524e147bd488();
				break;
			case NodeType.Run:
			case NodeType.SpecialChar:
				flag = x4e33137198fdb9ca();
				break;
			case NodeType.StructuredDocumentTag:
				flag = xf2e8c7878f23ec54();
				break;
			case NodeType.CustomXmlMarkup:
				flag = xc0ef66ea9669ffe4();
				break;
			case NodeType.OfficeMath:
				flag = x2d8656628e32b923();
				break;
			case NodeType.System:
				flag = xf4e58ceef25b6041();
				break;
			default:
				throw new InvalidOperationException("Unrecognized node type.");
			}
		}
		return result;
	}

	internal void x74f5a1ef3906e23c()
	{
		x20af2534649969eb.x74f5a1ef3906e23c();
		x7adacf577c3a6e2f = x20af2534649969eb.x47f176deff0d42e2();
	}

	internal bool x83f07df6a659e05b()
	{
		return x47f176deff0d42e2();
	}

	private void x7632937e3bef5cd8()
	{
		if (x783324369c7d8f45)
		{
			x783324369c7d8f45 = false;
		}
		else
		{
			x0a9500ca9f7f6a64 = xb01da31da3ec3cd2;
		}
	}

	private bool xc15d7b025464327d()
	{
		if (!x180f9c8380162d4e.x375e8189a5358be0)
		{
			return x33e810b9652b60a3();
		}
		return true;
	}

	private bool x8810991188d773db()
	{
		if (x180f9c8380162d4e.x375e8189a5358be0)
		{
			if (x2ddc466f35bc1e01)
			{
				x38049f0ee2892d0d();
				x2ddc466f35bc1e01 = false;
			}
			else
			{
				xe4beb7df913905b9(StoryType.MainText);
				x2ddc466f35bc1e01 = true;
				x180f9c8380162d4e.xac0bfd155c704ff8();
			}
		}
		return x33e810b9652b60a3();
	}

	private bool xc2bbf1463ef5659c()
	{
		StoryType storyType = ((HeaderFooter)x180f9c8380162d4e.x40212106aad8a8b0).StoryType;
		if (x180f9c8380162d4e.x83f9d074410e5abf)
		{
			if (x2ddc466f35bc1e01)
			{
				x0a9500ca9f7f6a64 = null;
				x476547a1677d89f7 = storyType;
				x4ae0c63fa3fd8ff1 = xba4e0d166e6035dd;
			}
			else
			{
				x180f9c8380162d4e.x8a92b04b9d325900();
			}
		}
		else
		{
			x0a9500ca9f7f6a64 = null;
			x476547a1677d89f7 = StoryType.MainText;
			x4ae0c63fa3fd8ff1 = null;
		}
		return x33e810b9652b60a3();
	}

	private bool x79ddf512b76f4062()
	{
		if (x180f9c8380162d4e.x83f9d074410e5abf)
		{
			if (x2ddc466f35bc1e01)
			{
				x180f9c8380162d4e.x8a92b04b9d325900();
			}
			else
			{
				x476547a1677d89f7 = StoryType.MainText;
				x4ae0c63fa3fd8ff1 = null;
			}
		}
		return x33e810b9652b60a3();
	}

	private bool xb61b92627231b7a8()
	{
		Paragraph paragraph = (Paragraph)x180f9c8380162d4e.x40212106aad8a8b0;
		if (x180f9c8380162d4e.x83f9d074410e5abf)
		{
			if (paragraph.ParagraphFormat.Alignment == ParagraphAlignment.Distributed)
			{
				xbbf9a1ead81dd3a1("Distributed paragraph alignment is not supported. Justified will be used instead. The paragraph text could be aligned differently.", paragraph);
			}
			xcb81f6e0de90b1bd.Push(x9d0fd2e8c3552ad6);
			if (x003de8f63ee87b30(paragraph))
			{
				x9d0fd2e8c3552ad6 = new xa4665f59f0cb55bd(new x91866f79774c2b6a(paragraph.Runs));
			}
			if (x46ed25080dd0b98f())
			{
				return true;
			}
			return x33e810b9652b60a3();
		}
		if (xcb81f6e0de90b1bd.Count > 0)
		{
			x9d0fd2e8c3552ad6 = (xa4665f59f0cb55bd)xcb81f6e0de90b1bd.Pop();
		}
		x41ac54db4e627dea x41ac54db4e627dea = xfec435486c6e6aba.x705900cecdc6d87e(paragraph);
		if (paragraph.IsEndOfSection)
		{
			xba4e0d166e6035dd = x41ac54db4e627dea;
		}
		if (paragraph.xd9de1b09bd43c824 || paragraph.xb1efbf98d540cbda)
		{
			switch (x476547a1677d89f7)
			{
			case StoryType.Footnotes:
			case StoryType.Endnotes:
			case StoryType.Comments:
				xccd27483b5d857a0.x16e153a4334eabbe(x476547a1677d89f7, x41ac54db4e627dea);
				break;
			}
			x41ac54db4e627dea.x897301f2e0967b6d = x4ae0c63fa3fd8ff1;
			x4ae0c63fa3fd8ff1.x897301f2e0967b6d = x41ac54db4e627dea;
		}
		return xb9d5236172ce4c6c(x41ac54db4e627dea);
	}

	private static bool x003de8f63ee87b30(Paragraph xda5bf54deb817e37)
	{
		return xda5bf54deb817e37.x38453dde2dc1ee92 != null;
	}

	private bool x5b7cc3ed4565d299()
	{
		return x33e810b9652b60a3();
	}

	private bool x2e5bc8a8aa47e75f()
	{
		if (x180f9c8380162d4e.x83f9d074410e5abf)
		{
			return x33e810b9652b60a3();
		}
		x41ac54db4e627dea x5906905c888d3d = xfec435486c6e6aba.x705900cecdc6d87e(x180f9c8380162d4e.x40212106aad8a8b0);
		xb9e41ad4cee380df(x5906905c888d3d);
		return xb9d5236172ce4c6c(x5906905c888d3d);
	}

	private void xb9e41ad4cee380df(x41ac54db4e627dea x5906905c888d3d98)
	{
		if (x5906905c888d3d98.x5566e2d2acbd1fbe == 21595)
		{
			Table table = (Table)x180f9c8380162d4e.x40212106aad8a8b0.GetAncestor(NodeType.Table);
			if (table.FirstRow.xedb0eb766e25e0c9.xd2905906dc0619f2 != 0)
			{
				xbbf9a1ead81dd3a1("Cell spacing is not supported. The table will be rendered without cell spacing.", table);
			}
			if (x5906905c888d3d98.xeb54885ba753f70e.xc61c6fcfb0c6e3c3 || x5906905c888d3d98.xeb54885ba753f70e.x6e1eb96b81362ebc <= 0)
			{
				xbbf9a1ead81dd3a1("Table column widths may need to be calculated. Rendered column widths could differ.", table);
			}
			if (x5906905c888d3d98.xeb54885ba753f70e.x109e3389933c23a8.x6f6877b222ed4153 && !x5906905c888d3d98.xeb54885ba753f70e.x109e3389933c23a8.xed344a170caf7ac3)
			{
				xbbf9a1ead81dd3a1("Option \"Allow overlap\" is not supported. Floating object could be positioned differently.", table);
			}
		}
	}

	private bool xb8fe14fc671949f3()
	{
		if (x180f9c8380162d4e.x83f9d074410e5abf && ((Cell)x180f9c8380162d4e.x40212106aad8a8b0).xf8cef531dae89ea3.xfeaa4e4323026cd8)
		{
			xbbf9a1ead81dd3a1("Option \"Fit text\" is not supported. Table could be rendered differently.", x180f9c8380162d4e.x40212106aad8a8b0);
		}
		return x33e810b9652b60a3();
	}

	private bool x85760ef70219c76f()
	{
		BookmarkEnd bookmarkEnd = (BookmarkEnd)x180f9c8380162d4e.x40212106aad8a8b0;
		x56410a8dd70087c5 x56410a8dd70087c = (x56410a8dd70087c5)x4bd039d469a1155d[bookmarkEnd.Name];
		if (x56410a8dd70087c == null)
		{
			return x33e810b9652b60a3();
		}
		x91e144d65ff41819 x91e144d65ff = (x91e144d65ff41819)xfec435486c6e6aba.x4a3421bc5d76ce9d(bookmarkEnd);
		x91e144d65ff.x53819c070f6c4652 = x56410a8dd70087c;
		x56410a8dd70087c.x53819c070f6c4652 = x91e144d65ff;
		return xb9d5236172ce4c6c(x91e144d65ff);
	}

	private bool x86225b1548fac515()
	{
		x91e144d65ff41819 x91e144d65ff = (x91e144d65ff41819)xfec435486c6e6aba.x4a3421bc5d76ce9d(x180f9c8380162d4e.x40212106aad8a8b0);
		if (!x4bd039d469a1155d.ContainsKey(x91e144d65ff.x759aa16c2016a289))
		{
			x4bd039d469a1155d.Add(x91e144d65ff.x759aa16c2016a289, x91e144d65ff);
		}
		return xb9d5236172ce4c6c(x91e144d65ff);
	}

	private bool xa4fbea35671a9649()
	{
		if (x180f9c8380162d4e.x83f9d074410e5abf)
		{
			xfb0c927634a887df x5906905c888d3d = (xfb0c927634a887df)xfec435486c6e6aba.x4a3421bc5d76ce9d(x180f9c8380162d4e.x40212106aad8a8b0);
			return xb9d5236172ce4c6c(x5906905c888d3d);
		}
		return x33e810b9652b60a3();
	}

	private bool xf3a1cfbffa44728c()
	{
		if (x180f9c8380162d4e.x83f9d074410e5abf)
		{
			xfb0c927634a887df xfb0c927634a887df = (xfb0c927634a887df)xfec435486c6e6aba.x4a3421bc5d76ce9d(x180f9c8380162d4e.x40212106aad8a8b0);
			if (xfb0c927634a887df.x705ed5f9769744e5.x24385217e0d88ab8)
			{
				x180f9c8380162d4e.x8a92b04b9d325900();
				return x33e810b9652b60a3();
			}
			xf543de5d109f4fda xf543de5d109f4fda = new xf543de5d109f4fda($"{xccf2c2d79dc4b57a.xe3a971b1346dd230()} [{xfb0c927634a887df.xc085e830e777a251}]: ");
			x396b77a306f83da6 x396b77a306f83da = new x396b77a306f83da6(xfb0c927634a887df.x705ed5f9769744e5.x17dcbf5fe3c0d2d2);
			x396b77a306f83da.xfe2178c1f916f36c = FontStyle.Bold;
			xf543de5d109f4fda.x705ed5f9769744e5 = x396b77a306f83da6.x38758cbbee49e4cb(x396b77a306f83da);
			x1e58f3079b9b34b3 = new ArrayList();
			x1e58f3079b9b34b3.Add(xf543de5d109f4fda);
			return xccdd323e49321bd7(xfb0c927634a887df, StoryType.Comments);
		}
		xbbf9a1ead81dd3a1("Comments are partially supported. Appearance and position could be different.", x180f9c8380162d4e.x40212106aad8a8b0);
		x38049f0ee2892d0d();
		return x33e810b9652b60a3();
	}

	private bool x69d502aaca08ee16()
	{
		return x59d45bd53ceb92ee(((Footnote)x180f9c8380162d4e.x40212106aad8a8b0).StoryType);
	}

	private bool x221bac6efb19ed4e()
	{
		if (xc3726f7b4fcad07f())
		{
			return false;
		}
		x5c28fdcd27dee7d9 x5c28fdcd27dee7d = (x5c28fdcd27dee7d9)xfec435486c6e6aba.x4a3421bc5d76ce9d(x180f9c8380162d4e.x40212106aad8a8b0);
		x5c28fdcd27dee7d9 x5c28fdcd27dee7d2 = (x5c28fdcd27dee7d9)x5b56be00bfa18d9a.Pop();
		if (x5c28fdcd27dee7d2.xb7c4cf9f30ad5f2a.NodeType == NodeType.FieldSeparator)
		{
			x5c28fdcd27dee7d.x275cb4c2185b2177 = x5c28fdcd27dee7d2;
			x5c28fdcd27dee7d2 = (x5c28fdcd27dee7d9)x5b56be00bfa18d9a.Pop();
		}
		x5c28fdcd27dee7d.x9a05d8dab0f0619f = x5c28fdcd27dee7d2;
		if (x5c28fdcd27dee7d2.xc96d173d58dd8a20 == FieldType.FieldTOC)
		{
			xfec435486c6e6aba.x4b6d377a3c5aa5e8 = false;
		}
		return xb9d5236172ce4c6c(x5c28fdcd27dee7d);
	}

	private bool xc3726f7b4fcad07f()
	{
		bool flag = x180f9c8380162d4e.x40212106aad8a8b0 is Inline && ((Inline)x180f9c8380162d4e.x40212106aad8a8b0).IsDeleteRevision;
		if (flag)
		{
			x33e810b9652b60a3();
		}
		return flag;
	}

	private bool xe0e68c1b48884a8c()
	{
		return x229e0931c739ee5b(xcd31b50c43a96e21: true);
	}

	private bool x22ac2c766ffad352()
	{
		return x229e0931c739ee5b(xcd31b50c43a96e21: false);
	}

	private bool x0ba9d5116fc4c47f()
	{
		xeb20d9a559fa99ca x5906905c888d3d = (xeb20d9a559fa99ca)xfec435486c6e6aba.x4a3421bc5d76ce9d(x180f9c8380162d4e.x40212106aad8a8b0);
		return xb9d5236172ce4c6c(x5906905c888d3d);
	}

	private bool xfcbc4da25426445a()
	{
		return x000353e328daf213(xcd31b50c43a96e21: true);
	}

	private bool x5f90ceadefcc8b28()
	{
		return x000353e328daf213(xcd31b50c43a96e21: false);
	}

	private bool x5d261db5e578d7f7()
	{
		xbbf9a1ead81dd3a1("DrawingML shapes are not fully supported. Object could be rendered differently.", x180f9c8380162d4e.x40212106aad8a8b0);
		return x000353e328daf213(xcd31b50c43a96e21: false);
	}

	private bool xdc95524e147bd488()
	{
		return x33e810b9652b60a3();
	}

	private bool xf2e8c7878f23ec54()
	{
		return x33e810b9652b60a3();
	}

	private bool xc0ef66ea9669ffe4()
	{
		return x33e810b9652b60a3();
	}

	private bool x2d8656628e32b923()
	{
		return xe33a09626c32cbb0(xcd31b50c43a96e21: false);
	}

	private bool xf4e58ceef25b6041()
	{
		if (x180f9c8380162d4e.x83f9d074410e5abf && x180f9c8380162d4e.x40212106aad8a8b0 is xa1e2a8ed32a026dd)
		{
			return xa659282abfb37049();
		}
		return x33e810b9652b60a3();
	}

	private bool xa659282abfb37049()
	{
		return x33e810b9652b60a3();
	}

	private bool x46ed25080dd0b98f()
	{
		_ = (Paragraph)x180f9c8380162d4e.x40212106aad8a8b0;
		xd14f50a067a58062 xd14f50a067a = xfec435486c6e6aba.xb882a2219ab76498(x180f9c8380162d4e.x40212106aad8a8b0);
		if (xd14f50a067a == null)
		{
			return false;
		}
		return xb9d5236172ce4c6c(xd14f50a067a);
	}

	private bool x59d45bd53ceb92ee(StoryType xdbbf47b5e620c262)
	{
		if (x180f9c8380162d4e.x83f9d074410e5abf)
		{
			x56410a8dd70087c5 x56410a8dd70087c = xfec435486c6e6aba.x4a3421bc5d76ce9d(x180f9c8380162d4e.x40212106aad8a8b0);
			if (x56410a8dd70087c.x705ed5f9769744e5.x24385217e0d88ab8)
			{
				x180f9c8380162d4e.x8a92b04b9d325900();
				return x33e810b9652b60a3();
			}
			return xccdd323e49321bd7(x56410a8dd70087c, xdbbf47b5e620c262);
		}
		x38049f0ee2892d0d();
		return x33e810b9652b60a3();
	}

	private bool x4e33137198fdb9ca()
	{
		if (x084ca902a0f3029b(x180f9c8380162d4e.x40212106aad8a8b0))
		{
			return x33e810b9652b60a3();
		}
		x1e58f3079b9b34b3 = xfec435486c6e6aba.xbd6559e9bd341cd6((Inline)x180f9c8380162d4e.x40212106aad8a8b0, x3967c58a4c5cb5ba());
		if (x1e58f3079b9b34b3 == null)
		{
			return x33e810b9652b60a3();
		}
		x33e810b9652b60a3();
		return xd284c348c423b930();
	}

	private string x3967c58a4c5cb5ba()
	{
		string text = (x57b6fed82e94b37a() ? x9d0fd2e8c3552ad6.x35cfcea4890f4e7d : null);
		if (text != null)
		{
			x9d0fd2e8c3552ad6.x47f176deff0d42e2();
		}
		return text;
	}

	private bool x57b6fed82e94b37a()
	{
		if (x9d0fd2e8c3552ad6 != null)
		{
			return x180f9c8380162d4e.x40212106aad8a8b0.NodeType == NodeType.Run;
		}
		return false;
	}

	private bool x229e0931c739ee5b(bool xcd31b50c43a96e21)
	{
		if (xc3726f7b4fcad07f())
		{
			return false;
		}
		x5c28fdcd27dee7d9 x5c28fdcd27dee7d = (x5c28fdcd27dee7d9)xfec435486c6e6aba.x4a3421bc5d76ce9d(x180f9c8380162d4e.x40212106aad8a8b0);
		if (x5c28fdcd27dee7d.xb7c4cf9f30ad5f2a.NodeType == NodeType.FieldStart && x5c28fdcd27dee7d.xb7c4cf9f30ad5f2a.FieldType == FieldType.FieldTOC)
		{
			xfec435486c6e6aba.x4b6d377a3c5aa5e8 = true;
		}
		x5b56be00bfa18d9a.Push(x5c28fdcd27dee7d);
		return xb9d5236172ce4c6c(x5c28fdcd27dee7d);
	}

	private bool x000353e328daf213(bool xcd31b50c43a96e21)
	{
		bool flag = x180f9c8380162d4e.x40212106aad8a8b0 is CompositeNode && ((CompositeNode)x180f9c8380162d4e.x40212106aad8a8b0).x73db39780c76cb8d;
		if (x180f9c8380162d4e.x375e8189a5358be0)
		{
			if (flag)
			{
				x38049f0ee2892d0d();
			}
			return x33e810b9652b60a3();
		}
		xa67197c42bddc7dc xa67197c42bddc7dc = (xa67197c42bddc7dc)xfec435486c6e6aba.x4a3421bc5d76ce9d(x180f9c8380162d4e.x40212106aad8a8b0);
		x246d27925b9b3d00(xa67197c42bddc7dc.x34251722ab416841.x109e3389933c23a8);
		if (!flag)
		{
			return xb9d5236172ce4c6c(xa67197c42bddc7dc);
		}
		return xccdd323e49321bd7(xa67197c42bddc7dc, StoryType.Textbox);
	}

	private bool xe33a09626c32cbb0(bool xcd31b50c43a96e21)
	{
		if (x084ca902a0f3029b(x180f9c8380162d4e.x40212106aad8a8b0))
		{
			return x33e810b9652b60a3();
		}
		if (x180f9c8380162d4e.x375e8189a5358be0)
		{
			return x33e810b9652b60a3();
		}
		xa67197c42bddc7dc xa67197c42bddc7dc = (xa67197c42bddc7dc)xfec435486c6e6aba.x4a3421bc5d76ce9d(x180f9c8380162d4e.x40212106aad8a8b0);
		x246d27925b9b3d00(xa67197c42bddc7dc.x34251722ab416841.x109e3389933c23a8);
		return xb9d5236172ce4c6c(xa67197c42bddc7dc);
	}

	private static bool x084ca902a0f3029b(Node xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37 != null && xda5bf54deb817e37.ParentNode != null)
		{
			return xda5bf54deb817e37.ParentNode.NodeType == NodeType.OfficeMath;
		}
		return false;
	}

	private void x246d27925b9b3d00(x8e3db3d2a7fdbd41 xb9c28c08633c4745)
	{
		if (!x180f9c8380162d4e.x83f9d074410e5abf || x180f9c8380162d4e.x40212106aad8a8b0.xdfa6ecc6f742f086.NodeType == NodeType.GroupShape || !xb9c28c08633c4745.x6f6877b222ed4153)
		{
			return;
		}
		switch (xb9c28c08633c4745.xab6edfb47ff0b74c)
		{
		case WrapType.Through:
			xbbf9a1ead81dd3a1("Through wrapping of a floating shape is not supported. Square wrapping will be used instead. Wrapped content could be rendered differently.", x180f9c8380162d4e.x40212106aad8a8b0);
			break;
		case WrapType.Tight:
			xbbf9a1ead81dd3a1("Tight wrapping of a floating shape is not supported. Square wrapping will be used instead. Wrapped content could be rendered differently.", x180f9c8380162d4e.x40212106aad8a8b0);
			break;
		}
		switch (xb9c28c08633c4745.x400dff62c6cef57f)
		{
		case WrapSide.Left:
		case WrapSide.Right:
		case WrapSide.Largest:
			xbbf9a1ead81dd3a1("Option \"Wrap side\" is not supported. Floating object could be wrapped differently by content.", x180f9c8380162d4e.x40212106aad8a8b0);
			break;
		}
		if (!xb9c28c08633c4745.xed344a170caf7ac3)
		{
			xbbf9a1ead81dd3a1("Option \"Allow overlap\" is not supported. Floating object could be positioned differently.", x180f9c8380162d4e.x40212106aad8a8b0);
		}
		if (xb9c28c08633c4745.x0fcdf9c7f9f2eb9e == RelativeHorizontalPosition.Column && x180f9c8380162d4e.x40212106aad8a8b0.GetAncestor(NodeType.Cell) != null)
		{
			Paragraph paragraph = (Paragraph)x180f9c8380162d4e.x40212106aad8a8b0.GetAncestor(NodeType.Paragraph);
			if (paragraph.ParagraphFormat.LeftIndent < 0.0)
			{
				xbbf9a1ead81dd3a1("Combination of paragraph indents and relative position of the nested floating object could result in unexpected rendered position.", x180f9c8380162d4e.x40212106aad8a8b0);
			}
		}
		if (x180f9c8380162d4e.x40212106aad8a8b0.NodeType == NodeType.Shape)
		{
			Shape shape = (Shape)x180f9c8380162d4e.x40212106aad8a8b0;
			if (shape.GetChild(NodeType.Paragraph, 0, isDeep: true) != null && shape.xdf3d5f8941ea27a6 != 0)
			{
				xbbf9a1ead81dd3a1("Linked text boxes are not supported. All content will be rendered inside the first text box in a chain, remaining text boxes will appear empty.", shape);
			}
		}
	}

	private bool xd284c348c423b930()
	{
		if (x1e58f3079b9b34b3 == null)
		{
			return false;
		}
		x56410a8dd70087c5 x56410a8dd70087c = (x56410a8dd70087c5)x1e58f3079b9b34b3[0];
		xe439e504e1fb9840(x56410a8dd70087c);
		if (x0d299f323d241756.x90637a473b1ceaaa("Arial Unicode MS", x56410a8dd70087c.x705ed5f9769744e5.x759aa16c2016a289))
		{
			xbbf9a1ead81dd3a1("Arial Unicode MS font is used in the document. Line spacing could be rendered differently.", x56410a8dd70087c);
		}
		if (1 == x1e58f3079b9b34b3.Count)
		{
			x1e58f3079b9b34b3 = null;
		}
		else
		{
			x1e58f3079b9b34b3.RemoveAt(0);
		}
		return true;
	}

	private void x9f53aa0242429602(x56410a8dd70087c5 x62584df2cb5d40dd)
	{
		x476547a1677d89f7 = x62584df2cb5d40dd.x53111d6596d16a99.xfe6cdb7c00822bd9;
		switch (x476547a1677d89f7)
		{
		case StoryType.MainText:
			x4ae0c63fa3fd8ff1 = null;
			break;
		case StoryType.Comments:
			x4ae0c63fa3fd8ff1 = ((x12f4230247e4ca42)x62584df2cb5d40dd.x332a8eedb847940d.x2cbc0fc707d2e1eb()).x465c7a263669f01c;
			break;
		case StoryType.Footnotes:
		case StoryType.Endnotes:
			x4ae0c63fa3fd8ff1 = ((x16dabaa37d19a5ec)x62584df2cb5d40dd.x332a8eedb847940d.x2cbc0fc707d2e1eb()).x465c7a263669f01c;
			break;
		case StoryType.Textbox:
			x4ae0c63fa3fd8ff1 = ((x3ee7f5c70fde3f94)x62584df2cb5d40dd.x53111d6596d16a99).x1452024de1251c74;
			break;
		default:
			x4ae0c63fa3fd8ff1 = ((xf6937c72cebe4ad1)((xb1f375aa1b12d10f)x62584df2cb5d40dd.x53111d6596d16a99).x7249fe3d61a20125.x88fee64dba8223f9.x7e2e5dd40daabc3b).x028068b313735e89;
			break;
		}
	}

	private bool x33e810b9652b60a3()
	{
		x7adacf577c3a6e2f = x20af2534649969eb.x47f176deff0d42e2(x4283b4e6c57a1853: true);
		return false;
	}

	private bool xb9d5236172ce4c6c(x56410a8dd70087c5 x5906905c888d3d98)
	{
		xe439e504e1fb9840(x5906905c888d3d98);
		x7adacf577c3a6e2f = x20af2534649969eb.x47f176deff0d42e2(x4283b4e6c57a1853: false);
		return true;
	}

	private bool xccdd323e49321bd7(x56410a8dd70087c5 x5906905c888d3d98, StoryType xdbbf47b5e620c262)
	{
		xe439e504e1fb9840(x5906905c888d3d98);
		xe4beb7df913905b9(xdbbf47b5e620c262);
		x7adacf577c3a6e2f = x20af2534649969eb.x47f176deff0d42e2(x4283b4e6c57a1853: false);
		return true;
	}

	private void xe439e504e1fb9840(x56410a8dd70087c5 x5906905c888d3d98)
	{
		xb01da31da3ec3cd2 = x5906905c888d3d98;
		xa3f9b2fd98264390 = new x5015a0e79fc04a51(x0a9500ca9f7f6a64, x476547a1677d89f7, x4ae0c63fa3fd8ff1);
	}

	private void xe4beb7df913905b9(StoryType xdbbf47b5e620c262)
	{
		x5015a0e79fc04a51 obj = new x5015a0e79fc04a51(xb01da31da3ec3cd2, x476547a1677d89f7, x4ae0c63fa3fd8ff1);
		x1fe9d199bfe5160a.Push(obj);
		x4ae0c63fa3fd8ff1 = xb01da31da3ec3cd2;
		x476547a1677d89f7 = xdbbf47b5e620c262;
		x783324369c7d8f45 = x476547a1677d89f7 != StoryType.MainText;
		switch (x476547a1677d89f7)
		{
		case StoryType.Footnotes:
		case StoryType.Endnotes:
		case StoryType.Comments:
			x0a9500ca9f7f6a64 = xccd27483b5d857a0.xda0d8384ac6ee2cb(x476547a1677d89f7, (x61ebdec02c254c25)x4ae0c63fa3fd8ff1);
			break;
		default:
			x0a9500ca9f7f6a64 = null;
			break;
		}
	}

	private void x38049f0ee2892d0d()
	{
		x5015a0e79fc04a51 x5015a0e79fc04a = (x5015a0e79fc04a51)x1fe9d199bfe5160a.Pop();
		x0a9500ca9f7f6a64 = x5015a0e79fc04a.x3e8d56eefc6dfdad;
		x4ae0c63fa3fd8ff1 = x5015a0e79fc04a.xc9476e3b4aa0e174;
		x476547a1677d89f7 = x5015a0e79fc04a.xfe6cdb7c00822bd9;
	}

	private void xbbf9a1ead81dd3a1(string x1f25abf5fb75e795, object xa860e35844c20ac7)
	{
		if (x83d0f75f3858e3a4 != null)
		{
			x83d0f75f3858e3a4.xbbf9a1ead81dd3a1(x1f25abf5fb75e795, xa860e35844c20ac7);
		}
	}
}
