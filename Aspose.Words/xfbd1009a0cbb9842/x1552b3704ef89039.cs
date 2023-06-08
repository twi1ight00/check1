using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x9e34b6f7e9185197;
using xf9a9481c3f63a419;

namespace xfbd1009a0cbb9842;

internal class x1552b3704ef89039 : Field, x6ed66b5cf8da2955
{
	private const string x7c5f1c781d4caa61 = "Calibri";

	private const int x811ead4c1eaef507 = 22;

	private readonly xe2ab94acf964af40 x4e3e7d07b2c5dc8d = new xe2ab94acf964af40();

	private readonly xe2ab94acf964af40 xecf71d7adabb0ab4 = new xe2ab94acf964af40();

	private bool xdf71480185149925;

	private string x280aa8c0c71a9d32;

	private readonly xe2ab94acf964af40 xc9ed4983312a2c17 = new xe2ab94acf964af40();

	private bool x331e0ec9c5bfd0c2;

	private readonly IDictionary x15ee8edf88acef74 = xd51c34d05311eee3.xdb04a310bbb29cff();

	private bool x7893e118d29e1e3d;

	private bool x0617d57f4aa6be5b;

	private bool x6c1c90120947c83c;

	private bool xe8e73ade9b8e9bb2;

	private string xe018669e1584ca76;

	private string x04a355f0e7313f41;

	private readonly Hashtable x23f73d450871ad59 = new Hashtable();

	internal xe2ab94acf964af40 x85f294bff8874c5a => x4e3e7d07b2c5dc8d;

	internal xe2ab94acf964af40 x69f691beb7246b92 => xecf71d7adabb0ab4;

	internal bool x15a2a869ee49e3d9 => x0617d57f4aa6be5b;

	internal bool x53d0a161d1c192c9 => xdf71480185149925;

	internal string x8e990dc466d0c060 => x280aa8c0c71a9d32;

	internal bool x8c3e6f6cd637156f => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\o");

	internal bool x723408eff5c6a235 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\n");

	internal bool xad17dbc959ad3c0f => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\l");

	internal bool x93902cc13041c9d1 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\t");

	internal bool x694a16375b48c186
	{
		get
		{
			if (!base.xb452e2ee706d7a67.xcc2d426b867d703d("\\c"))
			{
				return base.xb452e2ee706d7a67.xcc2d426b867d703d("\\a");
			}
			return true;
		}
	}

	internal string x54c93cd442d54b74 => base.xb452e2ee706d7a67.x6eba61762c5e83d7("\\c");

	internal string x02d7df2fcfcca2f8 => base.xb452e2ee706d7a67.x6eba61762c5e83d7("\\a");

	internal bool xc41474d1214de0c6 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\b");

	internal override void x20aee281977480cf(FieldStart x10aaa7cdfa38f254, FieldSeparator x3de314ab70bbd9bf, FieldEnd xca09b6c2b5b18485)
	{
		base.x20aee281977480cf(x10aaa7cdfa38f254, x3de314ab70bbd9bf, xca09b6c2b5b18485);
		x1f490eac106aee12();
	}

	private void x1f490eac106aee12()
	{
		x985dd08fd338eeea x985dd08fd338eeea2 = base.xb452e2ee706d7a67;
		xdf71480185149925 = x985dd08fd338eeea2.xcc2d426b867d703d("\\f");
		x280aa8c0c71a9d32 = x985dd08fd338eeea2.x6eba61762c5e83d7("\\f");
		x8059eb58ba5f79b3(x985dd08fd338eeea2, x4e3e7d07b2c5dc8d, "\\o");
		x8059eb58ba5f79b3(x985dd08fd338eeea2, xc9ed4983312a2c17, "\\n");
		x8059eb58ba5f79b3(x985dd08fd338eeea2, xecf71d7adabb0ab4, "\\l");
		if (!x53d0a161d1c192c9 && x985dd08fd338eeea2.xd67eea2495e37631("\\l") == null)
		{
			xecf71d7adabb0ab4.x97188a808cff1d41();
		}
		xde99a4cdfc70be9b(x985dd08fd338eeea2.x6eba61762c5e83d7("\\t"));
		x7893e118d29e1e3d = x985dd08fd338eeea2.xcc2d426b867d703d("\\h");
		bool flag = x15ee8edf88acef74.Count != 0;
		x0617d57f4aa6be5b = x985dd08fd338eeea2.xcc2d426b867d703d("\\u") && !flag;
		x6c1c90120947c83c = x985dd08fd338eeea2.xcc2d426b867d703d("\\w");
		xe8e73ade9b8e9bb2 = x985dd08fd338eeea2.xcc2d426b867d703d("\\x");
		xe018669e1584ca76 = x985dd08fd338eeea2.x6eba61762c5e83d7("\\p");
		x04a355f0e7313f41 = x985dd08fd338eeea2.x6eba61762c5e83d7("\\b", xbd96676852fc71de: true);
	}

	private void x8059eb58ba5f79b3(x985dd08fd338eeea x0e59413709b18038, xe2ab94acf964af40 x3130ec246b82498e, string x724fbd227bfb6eda)
	{
		if (x0e59413709b18038.xcc2d426b867d703d(x724fbd227bfb6eda))
		{
			x64629b07e6a0cb07 x64629b07e6a0cb8 = x0e59413709b18038.xd67eea2495e37631(x724fbd227bfb6eda);
			if (x64629b07e6a0cb8 != null)
			{
				x331e0ec9c5bfd0c2 = x331e0ec9c5bfd0c2 || !x3130ec246b82498e.x19890931227f0f56(x64629b07e6a0cb8.xd961adf06ad48c3f());
			}
		}
	}

	private void xde99a4cdfc70be9b(string x4b57b29f8abf80a8)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x4b57b29f8abf80a8))
		{
			return;
		}
		string[] array = x4b57b29f8abf80a8.Split(x0d299f323d241756.x644019557e120d6e());
		for (int i = 0; i < array.Length; i += 2)
		{
			string key = array[i].Trim();
			int num = 1;
			if (i < array.Length - 1)
			{
				string xe4115acdf4fbfccc = array[i + 1].Trim();
				int num2 = xca004f56614e2431.x912616ee70b2d94d(xe4115acdf4fbfccc);
				if (num2 != int.MinValue)
				{
					num = num2;
				}
			}
			if (x15ee8edf88acef74[key] == null)
			{
				x15ee8edf88acef74.Add(key, num);
			}
		}
	}

	internal int xa67a34cfefd7d4cd(string xbd5a2e7a4ff749c9)
	{
		object obj = x15ee8edf88acef74[xbd5a2e7a4ff749c9];
		if (obj == null)
		{
			return -1;
		}
		return (int)obj;
	}

	internal override x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		x23f73d450871ad59.Clear();
		base.x6edce55dcd2d335b.xdd53735657fe1b6b();
		DocumentBuilder documentBuilder = new DocumentBuilder(x357c90b33d6bb8e6());
		documentBuilder.MoveTo(base.End);
		if (!base.Start.x56657e375c13f7e3)
		{
			documentBuilder.Writeln();
		}
		if (x331e0ec9c5bfd0c2)
		{
			return new xd5801a931e010963(this, "Error! Not a valid heading level range.");
		}
		ArrayList arrayList = x6d232feca81d2281.xae29c9998cc24c8a(this);
		if (arrayList.Count == 0)
		{
			return new xd5801a931e010963(this, x31eab832fbdedd5b());
		}
		base.x34a4695711b84f85.x874035a07982e6e7(new xb424217efe68741a(x357c90b33d6bb8e6()));
		base.x34a4695711b84f85.x874035a07982e6e7(new x2de8d443b21560d5(x357c90b33d6bb8e6()), xcf417e2db4fe9ed3.x290a7f421b080483);
		xc182f06dd19f76f2(documentBuilder, arrayList);
		base.x6edce55dcd2d335b.xac51c2571643df46();
		x0e3ce54510ac3fb6();
		return null;
	}

	private void xc182f06dd19f76f2(DocumentBuilder xd07ce4b74c5774a7, ArrayList x8d54381b90e4e4be)
	{
		ArrayList x41a83ec97f0f68da = base.x2c8c6741422a1298.Range.x157b3e02606f681a();
		foreach (x40276702cac1d5f7 item in x8d54381b90e4e4be)
		{
			x2bfe48de881aa447(xd07ce4b74c5774a7, x41a83ec97f0f68da, item);
		}
	}

	private void x2bfe48de881aa447(DocumentBuilder xd07ce4b74c5774a7, ArrayList x41a83ec97f0f68da, x40276702cac1d5f7 xa85f9dbcec37a9e8)
	{
		string xd17ec8f278d25c = xb688e78ebea02c31(x41a83ec97f0f68da);
		Bookmark bookmark = xa85f9dbcec37a9e8.x7db09d025a6abf05(xd17ec8f278d25c);
		if (bookmark != null)
		{
			xf7e76a47de45a3c9(xd07ce4b74c5774a7, xa85f9dbcec37a9e8);
			xd07ce4b74c5774a7.Font.ClearFormatting();
			Node node = new Run(base.x2c8c6741422a1298);
			xd07ce4b74c5774a7.CurrentParagraph.AppendChild(node);
			Node node2 = xd1f083ffc72ae389(node, xd07ce4b74c5774a7, bookmark);
			xd07ce4b74c5774a7.MoveTo(node2);
			xa85f9dbcec37a9e8.xff2bb2b3436f4d08(xd07ce4b74c5774a7);
			xcb2e772a6945aa05(bookmark, xa85f9dbcec37a9e8, node2);
			xd07ce4b74c5774a7.MoveTo(node2);
			xd07ce4b74c5774a7.Font.ClearFormatting();
			x700f7f49840fd572(xd07ce4b74c5774a7, xa85f9dbcec37a9e8, bookmark);
			node.Remove();
		}
	}

	private void xf7e76a47de45a3c9(DocumentBuilder xd07ce4b74c5774a7, x40276702cac1d5f7 xa85f9dbcec37a9e8)
	{
		xd07ce4b74c5774a7.MoveTo(base.End);
		xd07ce4b74c5774a7.Writeln();
		xd07ce4b74c5774a7.MoveTo(xd07ce4b74c5774a7.CurrentParagraph.PreviousSibling);
		xd07ce4b74c5774a7.ParagraphFormat.ClearFormatting();
		xd07ce4b74c5774a7.ParagraphFormat.StyleIdentifier = ((!x694a16375b48c186) ? x84a48c5d2367b712(xa85f9dbcec37a9e8.x504f3d4040b356d7) : StyleIdentifier.TableOfFigures);
		xd07ce4b74c5774a7.CurrentParagraph.ParagraphBreakFont.ClearFormatting();
		x1b24870b1de870e4(x357c90b33d6bb8e6(), xd07ce4b74c5774a7.CurrentParagraph);
	}

	private Node xd1f083ffc72ae389(Node x22bff10c3dd1f70f, DocumentBuilder xd07ce4b74c5774a7, Bookmark x244e98b0dd99e560)
	{
		if (x7893e118d29e1e3d)
		{
			xd07ce4b74c5774a7.MoveTo(x22bff10c3dd1f70f);
			Field field = xd07ce4b74c5774a7.InsertField($" HYPERLINK \\l \"{x244e98b0dd99e560.Name}\" ", "");
			return field.End;
		}
		return x22bff10c3dd1f70f;
	}

	private void xcb2e772a6945aa05(Bookmark x244e98b0dd99e560, x40276702cac1d5f7 xa85f9dbcec37a9e8, Node x22bff10c3dd1f70f)
	{
		xa7b97711dc4bfc97 xa7b97711dc4bfc = new xa7b97711dc4bfc97();
		if (xa85f9dbcec37a9e8 is x4724ed988e1000da)
		{
			xa7b97711dc4bfc.xf054c9e7ce73c305(new x78f7ad9d7fd68e82(isTrimDoubleQuotes: true));
		}
		xa7b97711dc4bfc.xf054c9e7ce73c305(new x625382dc98be392e(x6c1c90120947c83c, xe8e73ade9b8e9bb2));
		xa7b97711dc4bfc.xf054c9e7ce73c305(xa835b299e2f442a9(xa85f9dbcec37a9e8));
		x0a28863c804404d7.x5af2763689ebe731(x244e98b0dd99e560.x451c3f5e0b9f8822(), x22bff10c3dd1f70f, xa7b97711dc4bfc, x29c774879be75f66: true);
	}

	private void x700f7f49840fd572(DocumentBuilder xd07ce4b74c5774a7, x40276702cac1d5f7 xa85f9dbcec37a9e8, Bookmark x244e98b0dd99e560)
	{
		if ((x723408eff5c6a235 && xc9ed4983312a2c17.x53ab91850c4897b0(xa85f9dbcec37a9e8.x504f3d4040b356d7)) || xa85f9dbcec37a9e8.x5c35225eba240e1a)
		{
			return;
		}
		if (x0d299f323d241756.x5959bccb67bbf051(xe018669e1584ca76))
		{
			xd07ce4b74c5774a7.Write(xe018669e1584ca76[0].ToString());
		}
		else
		{
			x1a78664fa10a3755 x1a78664fa10a = xd07ce4b74c5774a7.CurrentParagraph.x2e12c5f9278ae233(xd9bc7f7e70d71e14.xe9e531d1a6725226);
			TabStopCollection x8df6f6ca274123b = x1a78664fa10a.x8df6f6ca274123b0;
			if (x8df6f6ca274123b == null || x8df6f6ca274123b.Count == 0 || x8df6f6ca274123b[x8df6f6ca274123b.Count - 1].Alignment != TabAlignment.Right)
			{
				PageSetup pageSetup = xd07ce4b74c5774a7.PageSetup;
				double x13d4cb8d1bd = pageSetup.PageWidth - (pageSetup.LeftMargin + pageSetup.RightMargin) - 0.5;
				xca94f9a608ff4a9f(xd07ce4b74c5774a7, x13d4cb8d1bd, TabAlignment.Right, TabLeader.Dots);
			}
			xd07ce4b74c5774a7.Write(ControlChar.Tab);
		}
		xd07ce4b74c5774a7.InsertField($" PAGEREF {x244e98b0dd99e560.Name} \\h ", "??");
	}

	private string x31eab832fbdedd5b()
	{
		if (xc41474d1214de0c6 && x3fb2df8a80e0ef08() == null)
		{
			x64629b07e6a0cb07 x64629b07e6a0cb8 = base.xb452e2ee706d7a67.xd67eea2495e37631("\\b");
			return (x64629b07e6a0cb8 != null && !x64629b07e6a0cb8.x7d2e50686d249839.x30d6662e83251ab4) ? "Error! Bookmark not defined." : "Error! No bookmark name given.";
		}
		return (!x694a16375b48c186) ? "No table of contents entries found." : "No table of figures entries found.";
	}

	internal xe83a6b069ec8efc2 xa835b299e2f442a9(x40276702cac1d5f7 xa85f9dbcec37a9e8)
	{
		StyleIdentifier styleIdentifier = x84a48c5d2367b712(xa85f9dbcec37a9e8.x504f3d4040b356d7);
		if (x23f73d450871ad59[styleIdentifier] == null)
		{
			x23f73d450871ad59[styleIdentifier] = x99591af092599bad.xbdd431120301ba2e(styleIdentifier, base.x2c8c6741422a1298.Styles, x7893e118d29e1e3d);
		}
		return (xe83a6b069ec8efc2)x23f73d450871ad59[styleIdentifier];
	}

	private void x0e3ce54510ac3fb6()
	{
		if (!x7893e118d29e1e3d)
		{
			return;
		}
		foreach (Node item in xabae4fa6681a6afd(x7d5e2f34b6651bf4.xf8d31d196ccd74c4))
		{
			if (item.NodeType == NodeType.Run)
			{
				Run run = (Run)item;
				run.Font.StyleIdentifier = StyleIdentifier.Hyperlink;
			}
		}
	}

	internal string xb688e78ebea02c31(ArrayList x41a83ec97f0f68da)
	{
		string text;
		do
		{
			text = $"_Toc{x357c90b33d6bb8e6().xdebf548a9003abc2()}";
		}
		while (x41a83ec97f0f68da.IndexOf(text) != -1);
		return text;
	}

	internal static StyleIdentifier x84a48c5d2367b712(int xecf86884efc78f9d)
	{
		return xecf86884efc78f9d switch
		{
			1 => StyleIdentifier.Toc1, 
			2 => StyleIdentifier.Toc2, 
			3 => StyleIdentifier.Toc3, 
			4 => StyleIdentifier.Toc4, 
			5 => StyleIdentifier.Toc5, 
			6 => StyleIdentifier.Toc6, 
			7 => StyleIdentifier.Toc7, 
			8 => StyleIdentifier.Toc8, 
			9 => StyleIdentifier.Toc9, 
			_ => StyleIdentifier.Toc1, 
		};
	}

	internal static void xca94f9a608ff4a9f(DocumentBuilder xd07ce4b74c5774a7, double x13d4cb8d1bd20347, TabAlignment x4ec4022180cbf8f4, TabLeader xb6842aa1e60562e1)
	{
		ParagraphFormat paragraphFormat = xd07ce4b74c5774a7.CurrentParagraph.ParagraphFormat;
		if (paragraphFormat.Style.ParagraphFormat.TabStops[x13d4cb8d1bd20347] == null)
		{
			paragraphFormat.TabStops.Add(x13d4cb8d1bd20347, x4ec4022180cbf8f4, xb6842aa1e60562e1);
		}
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\h":
		case "\\u":
		case "\\w":
		case "\\x":
		case "\\z":
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
		case "\\f":
		case "\\o":
		case "\\n":
		case "\\t":
		case "\\l":
		case "\\p":
		case "\\a":
		case "\\c":
		case "\\b":
		case "\\d":
		case "\\s":
			return x9f6b815e19fa8f62.x47e3e032f7bd5d28;
		default:
			return x9f6b815e19fa8f62.xf6c17f648b65c793;
		}
	}

	x9f6b815e19fa8f62 x6ed66b5cf8da2955.x3ecf81e56889c4af(string x724fbd227bfb6eda)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6b9dc5b8ca4335e3
		return this.x6b9dc5b8ca4335e3(x724fbd227bfb6eda);
	}

	internal static void xad88d3aca1ae1e9e(Node xb6a159a84cb992d6)
	{
		x6435b7bbb0879a04 x6435b7bbb0879a5 = xe25d778fe9f1252a.x105bab38d511372f(xb6a159a84cb992d6);
		foreach (Field item in x6435b7bbb0879a5)
		{
			if (item.Type == FieldType.FieldTOC)
			{
				x1552b3704ef89039 x1552b3704ef89040 = (x1552b3704ef89039)item;
				x1552b3704ef89040.xad88d3aca1ae1e9e();
			}
		}
	}

	private void xad88d3aca1ae1e9e()
	{
		xb56968f92e308c8a xb56968f92e308c8a = new xb56968f92e308c8a(xabae4fa6681a6afd(x7d5e2f34b6651bf4.xf8d31d196ccd74c4));
		while (xb56968f92e308c8a.x1ef2c3be187f37a2())
		{
			if (xb56968f92e308c8a.x3387295f12854dfd is Inline)
			{
				Inline inline = (Inline)xb56968f92e308c8a.x3387295f12854dfd;
				if (inline.Font.Style.x28c6c3680e11266a == StyleIdentifier.Hyperlink)
				{
					inline.Font.StyleIdentifier = StyleIdentifier.Hyperlink;
				}
			}
		}
	}

	internal Bookmark x3fb2df8a80e0ef08()
	{
		Document document = x357c90b33d6bb8e6();
		Bookmark bookmark = document.Range.Bookmarks[x04a355f0e7313f41];
		if (bookmark != null && (bookmark.BookmarkStart.GetAncestor(NodeType.Body) == null || bookmark.BookmarkEnd.GetAncestor(NodeType.Body) == null))
		{
			bookmark = null;
		}
		return bookmark;
	}

	internal static void x1b24870b1de870e4(Document x3664041d21d73fdc, xf5ecf429e74b1c04 x9048853884fb76f5)
	{
		if (x3664041d21d73fdc.x9bb3f6e28fa55f34() != null)
		{
			x9048853884fb76f5.xd00aa8389522ce53(530, xd0fe745f27933c97.xb5416fb0ca9c28ab);
			x9048853884fb76f5.xd00aa8389522ce53(540, xd0fe745f27933c97.xb5416fb0ca9c28ab);
		}
		else
		{
			x9048853884fb76f5.xd00aa8389522ce53(230, "Calibri");
			x9048853884fb76f5.xd00aa8389522ce53(240, "Calibri");
		}
		x9048853884fb76f5.xd00aa8389522ce53(190, 22);
		x9048853884fb76f5.xd00aa8389522ce53(440, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
	}
}
