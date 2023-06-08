using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Settings;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x4adf554d20d941a6;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;

namespace x59d6a4fc5007b7a4;

internal class x42f2a218ce59dafb : IDisposable
{
	private class xb921d11d77962b8f
	{
		private readonly int[] x390b4411c7482c91;

		internal int x7390fcf53e1bd984 => x390b4411c7482c91[0];

		internal int x71e5b802707a5021 => x390b4411c7482c91[1];

		internal int x92fc60f0af06623f => x390b4411c7482c91[0];

		internal int[] x7eab159619d586e1 => x390b4411c7482c91;

		internal xb921d11d77962b8f(int gridAfter, int gridBefore)
		{
			x390b4411c7482c91 = new int[2] { gridAfter, gridBefore };
		}

		internal xb921d11d77962b8f(int gridSpan)
		{
			x390b4411c7482c91 = new int[1] { gridSpan };
		}

		internal xb921d11d77962b8f(int[] columnWidths)
		{
			x390b4411c7482c91 = columnWidths;
		}
	}

	private Hashtable xb1dd0e98ed9bec1a;

	private Hashtable x4b5d472caf9d8970;

	private xdeb77ea37ad74c56 x83d0f75f3858e3a4;

	private xacc55eb1e4595209 x8ac5a83e483bcc07;

	private readonly Hashtable xa3135d617dea4dc9 = new Hashtable();

	private readonly CompatibilityOptions xb53ae056f09e3965;

	internal bool x4b6d377a3c5aa5e8
	{
		get
		{
			return x8ac5a83e483bcc07.x46db7b5e43464144;
		}
		set
		{
			x8ac5a83e483bcc07.x46db7b5e43464144 = value;
		}
	}

	internal x42f2a218ce59dafb(Document document, xdeb77ea37ad74c56 options, x17dcbf5fe3c0d2d2 context)
	{
		x83d0f75f3858e3a4 = options;
		if (context != null && options != null && options.xa7631b031eaad810)
		{
			context = null;
		}
		x8ac5a83e483bcc07 = new xacc55eb1e4595209(document, context);
		xb53ae056f09e3965 = document.CompatibilityOptions;
		xa9d636b00ff486b7();
	}

	internal x41ac54db4e627dea x705900cecdc6d87e(Node xda5bf54deb817e37)
	{
		x41ac54db4e627dea x41ac54db4e627dea;
		if (NodeType.Row == xda5bf54deb817e37.NodeType)
		{
			x41ac54db4e627dea = x2e5bc8a8aa47e75f((Row)xda5bf54deb817e37);
		}
		else
		{
			Paragraph paragraph = (Paragraph)xda5bf54deb817e37;
			x41ac54db4e627dea = ((paragraph.x16479f42fe4547f2 && (paragraph.IsEndOfHeaderFooter || paragraph.x65c41b4567f1d25e || paragraph.IsEndOfDocument)) ? xd157d8dea55d49e9(paragraph) : ((paragraph.x16479f42fe4547f2 && (paragraph.IsEndOfSection || paragraph.xb1efbf98d540cbda || paragraph.xd9de1b09bd43c824 || paragraph.x591ed656a97f372e)) ? x8810991188d773db(paragraph) : ((!paragraph.IsEndOfCell) ? new x41ac54db4e627dea(21537) : xb8fe14fc671949f3(paragraph))));
		}
		x41ac54db4e627dea.x705ed5f9769744e5 = x396b77a306f83da6.x38758cbbee49e4cb(x8ac5a83e483bcc07.x8b0f145539d078d0(xda5bf54deb817e37));
		x41ac54db4e627dea.xa79651e2f1a1416e = x41ccdd7753312e4f.x38758cbbee49e4cb(x8ac5a83e483bcc07.xa238485187cc1afe(xda5bf54deb817e37));
		x41ac54db4e627dea.x772764427592d4bb = x2b1ee3a87b36a988.xf36c5c9e57c969ad(xda5bf54deb817e37);
		return x41ac54db4e627dea;
	}

	internal xd14f50a067a58062 xb882a2219ab76498(Node xda5bf54deb817e37)
	{
		Paragraph paragraph = (Paragraph)xda5bf54deb817e37;
		if (!paragraph.IsListItem || xf2b8a68af7902320(paragraph))
		{
			return null;
		}
		xd14f50a067a58062 xd14f50a067a = new xd14f50a067a58062(paragraph);
		xd14f50a067a.x705ed5f9769744e5 = x396b77a306f83da6.x38758cbbee49e4cb(x8ac5a83e483bcc07.x3fe6eca125045a42(paragraph));
		xd14f50a067a.x772764427592d4bb = x2b1ee3a87b36a988.xf36c5c9e57c969ad(xda5bf54deb817e37);
		return xd14f50a067a;
	}

	internal x56410a8dd70087c5 x4a3421bc5d76ce9d(Node xda5bf54deb817e37)
	{
		x56410a8dd70087c5 x56410a8dd70087c;
		switch (xda5bf54deb817e37.NodeType)
		{
		case NodeType.SmartTag:
		case NodeType.CustomXmlMarkup:
		case NodeType.StructuredDocumentTag:
			return null;
		case NodeType.BookmarkStart:
		case NodeType.BookmarkEnd:
			x56410a8dd70087c = new x91e144d65ff41819(xda5bf54deb817e37);
			break;
		case NodeType.CommentRangeStart:
		{
			x06e41c15cb47ffad x06e41c15cb47ffad = x8378a7a7d106b058(((x8ad0c0863d1cd403)xda5bf54deb817e37).x417a0a94031e7e8b);
			x56410a8dd70087c = new xfb0c927634a887df();
			x06e41c15cb47ffad.x2a0cb95ab84ba877((xfb0c927634a887df)x56410a8dd70087c, x6e414db5d060a816.x12cb12b5d2cad53d);
			break;
		}
		case NodeType.CommentRangeEnd:
		{
			x06e41c15cb47ffad x06e41c15cb47ffad = x8378a7a7d106b058(((x8ad0c0863d1cd403)xda5bf54deb817e37).x417a0a94031e7e8b);
			x56410a8dd70087c = new xfb0c927634a887df();
			x06e41c15cb47ffad.x2a0cb95ab84ba877((xfb0c927634a887df)x56410a8dd70087c, x6e414db5d060a816.x9fd888e65466818c);
			break;
		}
		case NodeType.Comment:
		{
			x56410a8dd70087c = new xfb0c927634a887df();
			x06e41c15cb47ffad x06e41c15cb47ffad = x8378a7a7d106b058(((x8ad0c0863d1cd403)xda5bf54deb817e37).x417a0a94031e7e8b);
			x06e41c15cb47ffad.xc085e830e777a251 = ((Comment)xda5bf54deb817e37).Initial;
			x06e41c15cb47ffad.x2a0cb95ab84ba877((xfb0c927634a887df)x56410a8dd70087c, x6e414db5d060a816.x865739e9b580d3cf);
			break;
		}
		case NodeType.Footnote:
			x56410a8dd70087c = new x92361dccfa0347fd((Footnote)xda5bf54deb817e37);
			break;
		case NodeType.FieldStart:
		case NodeType.FieldSeparator:
		case NodeType.FieldEnd:
			x56410a8dd70087c = new x5c28fdcd27dee7d9((FieldChar)xda5bf54deb817e37);
			break;
		case NodeType.FormField:
			x56410a8dd70087c = new xeb20d9a559fa99ca((FormField)xda5bf54deb817e37);
			break;
		case NodeType.GroupShape:
		case NodeType.Shape:
		case NodeType.DrawingML:
		case NodeType.OfficeMath:
			x56410a8dd70087c = new xa67197c42bddc7dc(xda5bf54deb817e37);
			x56410a8dd70087c.x34251722ab416841 = x8ac5a83e483bcc07.x654ab3515de7db76(xda5bf54deb817e37);
			break;
		default:
			throw new ArgumentException("The node cannot be used to generate span.", "node");
		}
		x56410a8dd70087c.x772764427592d4bb = x2b1ee3a87b36a988.xf36c5c9e57c969ad(xda5bf54deb817e37);
		x56410a8dd70087c.x705ed5f9769744e5 = x396b77a306f83da6.x38758cbbee49e4cb(x8ac5a83e483bcc07.x8b0f145539d078d0(xda5bf54deb817e37));
		return x56410a8dd70087c;
	}

	internal ArrayList xbd6559e9bd341cd6(Inline xda5bf54deb817e37, string x22398320e75d8e92)
	{
		if (!x8165e1be5f685fca(xda5bf54deb817e37, x22398320e75d8e92))
		{
			return null;
		}
		string text = ((x22398320e75d8e92 != null) ? x22398320e75d8e92 : xda5bf54deb817e37.GetText());
		int x772764427592d4bb = x2b1ee3a87b36a988.xf36c5c9e57c969ad(xda5bf54deb817e37);
		ArrayList arrayList = new ArrayList();
		x4f38812d0d5e7231 x4f38812d0d5e7232 = new x4f38812d0d5e7231(xda5bf54deb817e37, text, x7b6f036f72c7e4b9(xda5bf54deb817e37.Font), x8ac5a83e483bcc07, xb53ae056f09e3965, x83d0f75f3858e3a4.x515e84b3fc4c5959);
		while (x4f38812d0d5e7232.x47f176deff0d42e2())
		{
			x56410a8dd70087c5 x56410a8dd70087c = xdcfd21791420d827(x4f38812d0d5e7232.x5566e2d2acbd1fbe, x4f38812d0d5e7232.xf9ad6fb78355fe13, xda5bf54deb817e37);
			x56410a8dd70087c.x626efc37c410c502 = x4f38812d0d5e7232.x0be68579badf5b2b(x56410a8dd70087c.x4a1a6d8b0aafa0fe);
			bool x9faa7f8a5d7090ee = x769ea5e930af2cbc.x4c57b971f1a8d64d(x56410a8dd70087c.x626efc37c410c502);
			x56410a8dd70087c.x705ed5f9769744e5 = x396b77a306f83da6.x38758cbbee49e4cb(x8ac5a83e483bcc07.x8b0f145539d078d0(xda5bf54deb817e37, x4f38812d0d5e7232, x9faa7f8a5d7090ee));
			x56410a8dd70087c.x772764427592d4bb = x772764427592d4bb;
			arrayList.Add(x56410a8dd70087c);
		}
		return arrayList;
	}

	internal static x56410a8dd70087c5 xdcfd21791420d827(int x5620391b595d8955, string xff8c5091e045feee, Inline xda5bf54deb817e37)
	{
		switch (x5620391b595d8955)
		{
		case 12803:
			return xc0e747af79894e12.xa7195540a6abf044(xda5bf54deb817e37);
		case 10754:
			return new xee65f8567b84ecd3(xff8c5091e045feee.Length);
		case 21514:
		case 21537:
			return new x41ac54db4e627dea(21514);
		case 21513:
			return new x41ac54db4e627dea(21513);
		case 21779:
			return new x41ac54db4e627dea(21779);
		case 21788:
			return new x41ac54db4e627dea(21788);
		case 9238:
		case 9747:
		case 9752:
		case 9753:
		case 9754:
		case 9755:
		case 10768:
		case 10769:
		case 10770:
		case 10782:
		case 11284:
		case 11285:
		case 11799:
			return new x98ad66692671593f(x5620391b595d8955);
		case 9217:
		{
			char c = xff8c5091e045feee[0];
			if (c == '\u0002' || c == '\u0005')
			{
				return new x577d2faf9a871f11(xda5bf54deb817e37);
			}
			return new xf543de5d109f4fda(xff8c5091e045feee);
		}
		case 9244:
			return new x0bfb52319d26d342();
		case 9245:
			return new x11d4ec1af8f7c53d();
		default:
			throw new InvalidOperationException("Unrecognized span type, " + x5620391b595d8955);
		}
	}

	public void Dispose()
	{
		xb1dd0e98ed9bec1a = null;
		x83d0f75f3858e3a4 = null;
		x8ac5a83e483bcc07 = null;
		x4b5d472caf9d8970 = null;
	}

	private x41ac54db4e627dea xd157d8dea55d49e9(Paragraph xda5bf54deb817e37)
	{
		x41ac54db4e627dea x41ac54db4e627dea = new x41ac54db4e627dea(21639);
		if (xda5bf54deb817e37.xdfa6ecc6f742f086 is Body)
		{
			x41ac54db4e627dea.xc02a1028e62dfaf7 = x5d30045af3da9a92.x38758cbbee49e4cb(x8ac5a83e483bcc07.x6ff815c88c784807(xda5bf54deb817e37.x357c90b33d6bb8e6()));
			x41ac54db4e627dea.xa70fedcedcd0e1da = xacf1bb6be5092987.x38758cbbee49e4cb(x8ac5a83e483bcc07.x9a1aaa840ab94f2c((Section)xda5bf54deb817e37.xdfa6ecc6f742f086.ParentNode));
		}
		return x41ac54db4e627dea;
	}

	private x41ac54db4e627dea x8810991188d773db(Paragraph xda5bf54deb817e37)
	{
		x41ac54db4e627dea x41ac54db4e627dea = new x41ac54db4e627dea(21857);
		if (xda5bf54deb817e37.xdfa6ecc6f742f086.NodeType == NodeType.Body)
		{
			x41ac54db4e627dea.xa70fedcedcd0e1da = xacf1bb6be5092987.x38758cbbee49e4cb(x8ac5a83e483bcc07.x9a1aaa840ab94f2c((Section)xda5bf54deb817e37.xdfa6ecc6f742f086.ParentNode));
		}
		return x41ac54db4e627dea;
	}

	private x41ac54db4e627dea x2e5bc8a8aa47e75f(Row xda5bf54deb817e37)
	{
		x41ac54db4e627dea x41ac54db4e627dea = new x41ac54db4e627dea(xda5bf54deb817e37.IsLastRow ? 21595 : 21586);
		x41ac54db4e627dea.x768f9befb545345a = x8ac5a83e483bcc07.x52548ab50cc290b7(xda5bf54deb817e37);
		xb921d11d77962b8f xb921d11d77962b8f = xb3e4a5cb10f594bd(xda5bf54deb817e37);
		x41ac54db4e627dea.x768f9befb545345a.x851fcfc17df82b1b = xb921d11d77962b8f.x7390fcf53e1bd984;
		x41ac54db4e627dea.x768f9befb545345a.x0364c07ad4dcfe0c = xb921d11d77962b8f.x71e5b802707a5021;
		x41ac54db4e627dea.x768f9befb545345a = xe20e20657f464768.x38758cbbee49e4cb(x41ac54db4e627dea.x768f9befb545345a);
		if (xda5bf54deb817e37.IsLastRow)
		{
			x8f0e2f0364ae18aa x8f0e2f0364ae18aa = x8ac5a83e483bcc07.xc5a510a39e9d580f((Table)xda5bf54deb817e37.xdfa6ecc6f742f086);
			if (x83d0f75f3858e3a4 == null || !x83d0f75f3858e3a4.xd74e03b277432e5e)
			{
				int[] x7eab159619d586e = xb3e4a5cb10f594bd(xda5bf54deb817e37.ParentTable).x7eab159619d586e1;
				int num = x7eab159619d586e.Length;
				x8f0e2f0364ae18aa.x78427d61ba29da6a = new int[num];
				for (int i = 0; i < num; i++)
				{
					x8f0e2f0364ae18aa.x78427d61ba29da6a[i] = x4574ea26106f0edb.x370502bb60141209(x7eab159619d586e[i]);
				}
			}
			else
			{
				x8f0e2f0364ae18aa.x78427d61ba29da6a = new int[0];
			}
			x41ac54db4e627dea.xeb54885ba753f70e = x8f0e2f0364ae18aa.x38758cbbee49e4cb(x8f0e2f0364ae18aa);
		}
		return x41ac54db4e627dea;
	}

	private x41ac54db4e627dea xb8fe14fc671949f3(Paragraph xda5bf54deb817e37)
	{
		x41ac54db4e627dea x41ac54db4e627dea = new x41ac54db4e627dea(21577);
		x41ac54db4e627dea.xdfd0c9de0b4aa96a = x8ac5a83e483bcc07.x7f16e49c9b5b8c38(xda5bf54deb817e37);
		xb921d11d77962b8f xb921d11d77962b8f = xb3e4a5cb10f594bd(xda5bf54deb817e37.xc5464084edc8e226);
		int x92fc60f0af06623f = xb921d11d77962b8f.x92fc60f0af06623f;
		x41ac54db4e627dea.xdfd0c9de0b4aa96a.x6e1eb96b81362ebc = x92fc60f0af06623f;
		x41ac54db4e627dea.xdfd0c9de0b4aa96a = x71a4a9bfdf7899a6.x38758cbbee49e4cb(x41ac54db4e627dea.xdfd0c9de0b4aa96a);
		return x41ac54db4e627dea;
	}

	private xb921d11d77962b8f xb3e4a5cb10f594bd(Node xda5bf54deb817e37)
	{
		x8d50ffb749ffb60d(x2b1ee3a87b36a988.x01d3b14e93659fbe(xda5bf54deb817e37));
		return (xb921d11d77962b8f)xb1dd0e98ed9bec1a[xda5bf54deb817e37];
	}

	private void x8d50ffb749ffb60d(Table x1ec770899c98a268)
	{
		if (xb1dd0e98ed9bec1a.ContainsKey(x1ec770899c98a268))
		{
			return;
		}
		x66f2271ac271c2df x66f2271ac271c2df = new x66f2271ac271c2df(x1ec770899c98a268);
		for (Row row = x1ec770899c98a268.FirstRow; row != null; row = row.xebb8ac1152da9a1f)
		{
			x66f2271ac271c2df.xebb8ac1152da9a1f(row);
			xb1dd0e98ed9bec1a.Add(row, new xb921d11d77962b8f(x66f2271ac271c2df.x7390fcf53e1bd984, x66f2271ac271c2df.x71e5b802707a5021));
			for (Cell cell = row.FirstCell; cell != null; cell = cell.xb2e852052ab1c1be)
			{
				xb1dd0e98ed9bec1a.Add(cell, new xb921d11d77962b8f(x66f2271ac271c2df.xb2e852052ab1c1be()));
			}
		}
		xb1dd0e98ed9bec1a.Add(x1ec770899c98a268, new xb921d11d77962b8f(x66f2271ac271c2df.x7eab159619d586e1));
	}

	private static bool xf2b8a68af7902320(Paragraph x31e6518f5e08db6c)
	{
		for (Node node = x31e6518f5e08db6c.xfe93db1ba6e25886; node != null; node = node.xa6890a1cb2b8896e)
		{
			if (!x2b1ee3a87b36a988.x0f86e763fa9a14ff(node))
			{
				return false;
			}
		}
		if (x31e6518f5e08db6c.IsEndOfSection)
		{
			return !x31e6518f5e08db6c.IsEndOfDocument;
		}
		return false;
	}

	internal void xa9d636b00ff486b7()
	{
		xb1dd0e98ed9bec1a = new Hashtable();
		x4b5d472caf9d8970 = new Hashtable();
	}

	private x1d1dd20018fcde10 x7b6f036f72c7e4b9(Font x26094932cf7a9139)
	{
		object obj = x4b5d472caf9d8970[x26094932cf7a9139];
		if (obj == null)
		{
			obj = new x1d1dd20018fcde10(x26094932cf7a9139);
			x4b5d472caf9d8970.Add(x26094932cf7a9139, obj);
		}
		return (x1d1dd20018fcde10)obj;
	}

	private x06e41c15cb47ffad x8378a7a7d106b058(int xeaf1b27180c0557b)
	{
		x06e41c15cb47ffad x06e41c15cb47ffad = (x06e41c15cb47ffad)xa3135d617dea4dc9[xeaf1b27180c0557b];
		if (x06e41c15cb47ffad == null)
		{
			x06e41c15cb47ffad = new x06e41c15cb47ffad();
			xa3135d617dea4dc9.Add(xeaf1b27180c0557b, x06e41c15cb47ffad);
		}
		return x06e41c15cb47ffad;
	}

	private static bool x8165e1be5f685fca(Inline xda5bf54deb817e37, string x22398320e75d8e92)
	{
		if (xda5bf54deb817e37.NodeType != NodeType.Run || !x0d299f323d241756.x5959bccb67bbf051(x22398320e75d8e92))
		{
			if (xda5bf54deb817e37.NodeType != NodeType.Run)
			{
				return xda5bf54deb817e37.x2e39a445d52f6ea8() > 0;
			}
			return false;
		}
		return true;
	}
}
