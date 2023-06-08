using System;
using System.Text;
using Aspose.Words;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x9db5f2e5af3d596e;

namespace x2cc366c8657e2b6a;

internal class x9cee4b6d17a3fda9
{
	private x9cee4b6d17a3fda9()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x782fcf0dc01a8e96 x782fcf0dc01a8e = new x782fcf0dc01a8e96(x3bcd232d01c);
		if (!x782fcf0dc01a8e.xbd2068db29af7264)
		{
			return;
		}
		switch (x782fcf0dc01a8e.x3146d638ec378671)
		{
		case "Word.Bookmark.Start":
		{
			xe134235b3526fa75.x02e97468984a6dfa[x782fcf0dc01a8e.xea1e81378298fa81] = x782fcf0dc01a8e.x759aa16c2016a289;
			BookmarkStart bookmarkStart = new BookmarkStart(xe134235b3526fa75.x2c8c6741422a1298, x782fcf0dc01a8e.x759aa16c2016a289);
			if (x782fcf0dc01a8e.x6aaf4d9b15644fca >= 0 && x782fcf0dc01a8e.x188288b446f5fc96 >= 0)
			{
				bookmarkStart.xb78c16d5f2d4f2f7 = x782fcf0dc01a8e.x6aaf4d9b15644fca;
				bookmarkStart.x279da4adfba57f2d = x782fcf0dc01a8e.x188288b446f5fc96 + 1;
			}
			xe134235b3526fa75.x8c81feb19d9adb77(bookmarkStart);
			break;
		}
		case "Word.Bookmark.End":
		{
			string text = (string)xe134235b3526fa75.x02e97468984a6dfa[x782fcf0dc01a8e.xea1e81378298fa81];
			if (text != null)
			{
				BookmarkEnd xda5bf54deb817e = new BookmarkEnd(xe134235b3526fa75.x2c8c6741422a1298, text);
				xe134235b3526fa75.x8c81feb19d9adb77(xda5bf54deb817e);
				xe134235b3526fa75.x02e97468984a6dfa.Remove(x782fcf0dc01a8e.xea1e81378298fa81);
			}
			break;
		}
		case "Word.Comment.Start":
			xe134235b3526fa75.x8c81feb19d9adb77(new CommentRangeStart(xe134235b3526fa75.x2c8c6741422a1298, x782fcf0dc01a8e.xea1e81378298fa81));
			break;
		case "Word.Comment.End":
			xe134235b3526fa75.x8c81feb19d9adb77(new CommentRangeEnd(xe134235b3526fa75.x2c8c6741422a1298, x782fcf0dc01a8e.xea1e81378298fa81));
			break;
		case "Word.Insertion":
			xe134235b3526fa75.xf0f66a68781cfaa5 = x4bc7f83d1f7d5b09(x782fcf0dc01a8e, x91bb72ac77aa7230.xf059562f878b500e);
			xb0049a36f0a0423c(xe134235b3526fa75);
			xe134235b3526fa75.xf0f66a68781cfaa5 = null;
			break;
		case "Word.Deletion":
			xe134235b3526fa75.xe0ee6c8342da8f38 = x4bc7f83d1f7d5b09(x782fcf0dc01a8e, x91bb72ac77aa7230.x1f522a512716a2ae);
			xb0049a36f0a0423c(xe134235b3526fa75);
			xe134235b3526fa75.xe0ee6c8342da8f38 = null;
			break;
		}
	}

	public static void x51c46e5e6e76d587(x1a78664fa10a3755 x062aae8c9613eeaa, x3c85359e1389ad43 xe134235b3526fa75)
	{
		x782fcf0dc01a8e96 x782fcf0dc01a8e = new x782fcf0dc01a8e96(xe134235b3526fa75);
		if (x782fcf0dc01a8e.xbd2068db29af7264)
		{
			x978620a99b6d5014 x978620a99b6d = new x978620a99b6d5014();
			x978620a99b6d.xb063bbfcfeade526 = x782fcf0dc01a8e.xb063bbfcfeade526;
			x978620a99b6d.x242851e6278ed355 = x782fcf0dc01a8e.x197c47a24c81f695;
			switch (x782fcf0dc01a8e.x3146d638ec378671)
			{
			case "Word.Insertion":
				x978620a99b6d.x55e2dcfc986cb10b = true;
				x062aae8c9613eeaa.x978620a99b6d5014 = x978620a99b6d;
				break;
			case "Word.Numbering":
				xf52d001036f4401e(x978620a99b6d, x782fcf0dc01a8e.x5995f9ab0072f644);
				x978620a99b6d.x713b07324dddc470 = true;
				x062aae8c9613eeaa.x978620a99b6d5014 = x978620a99b6d;
				break;
			}
		}
	}

	internal static void xf52d001036f4401e(x978620a99b6d5014 xc41ca7be73709324, string xfcad4c0a9c5890c6)
	{
		int num = 0;
		int num2 = 0;
		StringBuilder stringBuilder = new StringBuilder();
		while (num < xfcad4c0a9c5890c6.Length && xfcad4c0a9c5890c6[num] == '%')
		{
			num++;
			stringBuilder.Append((char)(xfcad4c0a9c5890c6[num] - 49));
			xc41ca7be73709324.x044891ce086d094b[num2] = (byte)stringBuilder.Length;
			num += 2;
			xc41ca7be73709324.x632f31cdeda76ff9[num2] = xfcad4c0a9c5890c6[num] - 48;
			num += 2;
			xc41ca7be73709324.x7e30db41abd34a71[num2] = (NumberStyle)(xfcad4c0a9c5890c6[num] - 48);
			num += 2;
			if (num < xfcad4c0a9c5890c6.Length && xfcad4c0a9c5890c6[num] != '%')
			{
				stringBuilder.Append(xfcad4c0a9c5890c6[num]);
				num++;
			}
			num2++;
		}
		xc41ca7be73709324.x5051a4a3b273ffce = stringBuilder.ToString();
	}

	public static void x94612d0143ac9d96(xdfce7f4f687956d7 xe134235b3526fa75, x1a78664fa10a3755 x062aae8c9613eeaa, xeedad81aaed42a76 xe429e76576802d76)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x782fcf0dc01a8e96 x782fcf0dc01a8e = new x782fcf0dc01a8e96(x3bcd232d01c);
		string x3146d638ec;
		if (!x782fcf0dc01a8e.xbd2068db29af7264 || (x3146d638ec = x782fcf0dc01a8e.x3146d638ec378671) == null || !(x3146d638ec == "Word.Formatting"))
		{
			return;
		}
		while (x3bcd232d01c.x152cbadbfa8061b1("annotation"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "content")
			{
				while (x3bcd232d01c.x152cbadbfa8061b1("content"))
				{
					string xa66385d80d4d296f2;
					if ((xa66385d80d4d296f2 = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f2 == "pPr")
					{
						x06cbd3584b0394b8.xbd12d1ad296c44a8(xe134235b3526fa75, x062aae8c9613eeaa, xe429e76576802d76, x782fcf0dc01a8e);
					}
					else
					{
						x3bcd232d01c.IgnoreElement();
					}
				}
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
	}

	public static void x23b47cfc315238f5(xfc72d4c9b765cad7 x873e775b892867cf, xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x782fcf0dc01a8e96 x782fcf0dc01a8e = new x782fcf0dc01a8e96(x3bcd232d01c);
		string x3146d638ec;
		if (!x782fcf0dc01a8e.xbd2068db29af7264 || (x3146d638ec = x782fcf0dc01a8e.x3146d638ec378671) == null || !(x3146d638ec == "Word.Formatting"))
		{
			return;
		}
		while (x3bcd232d01c.x152cbadbfa8061b1("annotation"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "content")
			{
				while (x3bcd232d01c.x152cbadbfa8061b1("content"))
				{
					string xa66385d80d4d296f2;
					if ((xa66385d80d4d296f2 = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f2 == "sectPr")
					{
						x7f77ea92be0d9042 x7f77ea92be0d = (x7f77ea92be0d9042)x873e775b892867cf.x8b61531c8ea35b85();
						x873e775b892867cf.ClearAttrs();
						Section xb32f8dd719a105db = (Section)xe134235b3526fa75.x0547ea8ef1ef19b1.GetAncestor(NodeType.Section);
						xc0f8e03cabf3a123.x06b0e25aa6ad68a9(xe134235b3526fa75, xb32f8dd719a105db);
						x7f77ea92be0d.x968eca275aff04e3(x873e775b892867cf);
						x873e775b892867cf.x5fb16e270c21db2e = new x5fb16e270c21db2e(x7f77ea92be0d, x782fcf0dc01a8e.xb063bbfcfeade526, x782fcf0dc01a8e.x197c47a24c81f695);
					}
					else
					{
						x3bcd232d01c.IgnoreElement();
					}
				}
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
	}

	public static void x72c209cf673c0dfb(xf8cef531dae89ea3 x51dd02ffcbaa972d, xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x782fcf0dc01a8e96 x782fcf0dc01a8e = new x782fcf0dc01a8e96(x3bcd232d01c);
		string x3146d638ec;
		if (!x782fcf0dc01a8e.xbd2068db29af7264 || (x3146d638ec = x782fcf0dc01a8e.x3146d638ec378671) == null || !(x3146d638ec == "Word.Formatting"))
		{
			return;
		}
		while (x3bcd232d01c.x152cbadbfa8061b1("annotation"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "content")
			{
				x7f77ea92be0d9042 x7f77ea92be0d = (x7f77ea92be0d9042)x51dd02ffcbaa972d.x8b61531c8ea35b85();
				x51dd02ffcbaa972d.ClearAttrs();
				xfad593021ab5340a.x06b0e25aa6ad68a9(xe134235b3526fa75, x51dd02ffcbaa972d);
				x7f77ea92be0d.x968eca275aff04e3(x51dd02ffcbaa972d);
				x51dd02ffcbaa972d.x5fb16e270c21db2e = new x5fb16e270c21db2e(x7f77ea92be0d, x782fcf0dc01a8e.xb063bbfcfeade526, x782fcf0dc01a8e.x197c47a24c81f695);
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
	}

	internal static void xa74ef6ee0db04174(xdfce7f4f687956d7 xe134235b3526fa75, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		xa74ef6ee0db04174(xe134235b3526fa75, xe193ceb565ecaa0a, x97b4bbf66b3d8bc6: true);
	}

	internal static void x7e6b47bfc114eada(xdfce7f4f687956d7 xe134235b3526fa75, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		xa74ef6ee0db04174(xe134235b3526fa75, xe193ceb565ecaa0a, x97b4bbf66b3d8bc6: false);
	}

	public static void xa74ef6ee0db04174(xdfce7f4f687956d7 xe134235b3526fa75, xedb0eb766e25e0c9 xe193ceb565ecaa0a, bool x97b4bbf66b3d8bc6)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x782fcf0dc01a8e96 x782fcf0dc01a8e = new x782fcf0dc01a8e96(x3bcd232d01c);
		if (!x782fcf0dc01a8e.xbd2068db29af7264)
		{
			return;
		}
		switch (x782fcf0dc01a8e.x3146d638ec378671)
		{
		case "Word.Formatting":
			while (x3bcd232d01c.x152cbadbfa8061b1("annotation"))
			{
				string xa66385d80d4d296f;
				if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "content")
				{
					x959c98cd5d3017e7(xe134235b3526fa75, xe193ceb565ecaa0a, x782fcf0dc01a8e, x97b4bbf66b3d8bc6);
				}
				else
				{
					x3bcd232d01c.IgnoreElement();
				}
			}
			break;
		case "Word.Insertion":
			x54a56194235eead3(xe134235b3526fa75, xe193ceb565ecaa0a, x782fcf0dc01a8e, x91bb72ac77aa7230.xf059562f878b500e);
			break;
		case "Word.Deletion":
			x54a56194235eead3(xe134235b3526fa75, xe193ceb565ecaa0a, x782fcf0dc01a8e, x91bb72ac77aa7230.x1f522a512716a2ae);
			break;
		default:
			xe134235b3526fa75.x3dc950453374051a(x782fcf0dc01a8e.x3146d638ec378671);
			break;
		}
	}

	private static void x959c98cd5d3017e7(xdfce7f4f687956d7 xe134235b3526fa75, xedb0eb766e25e0c9 xe193ceb565ecaa0a, x782fcf0dc01a8e96 x7c809b22b8f9e275, bool x97b4bbf66b3d8bc6)
	{
		x7f77ea92be0d9042 x7f77ea92be0d = (x7f77ea92be0d9042)xe193ceb565ecaa0a.x8b61531c8ea35b85();
		if (x7f77ea92be0d.x0f53f53f15b61ef5)
		{
			x7f77ea92be0d.xcb395027497bc067();
		}
		xe193ceb565ecaa0a.x52b190e626f65140(10010);
		if (x97b4bbf66b3d8bc6)
		{
			xf24b05793143359f.x0fef18e7f16bf0ca(xe193ceb565ecaa0a, xe134235b3526fa75, x37f701492043cfc5: false);
		}
		else
		{
			xbc80cffc72f0de48.x06b0e25aa6ad68a9(xe193ceb565ecaa0a, xe134235b3526fa75);
		}
		x7f77ea92be0d.x968eca275aff04e3(xe193ceb565ecaa0a);
		xe193ceb565ecaa0a.x5fb16e270c21db2e = new x5fb16e270c21db2e(x7f77ea92be0d, x7c809b22b8f9e275.xb063bbfcfeade526, x7c809b22b8f9e275.x197c47a24c81f695);
	}

	private static void x54a56194235eead3(xdfce7f4f687956d7 xe134235b3526fa75, xedb0eb766e25e0c9 xe193ceb565ecaa0a, x782fcf0dc01a8e96 x7c809b22b8f9e275, x91bb72ac77aa7230 x63c8ebbd109dc367)
	{
		switch (x63c8ebbd109dc367)
		{
		case x91bb72ac77aa7230.x1f522a512716a2ae:
			xe193ceb565ecaa0a.x83da691dd3d974a6 = new xc1b2bac943a0f541(x63c8ebbd109dc367, x7c809b22b8f9e275.xb063bbfcfeade526, x7c809b22b8f9e275.x197c47a24c81f695);
			break;
		case x91bb72ac77aa7230.xf059562f878b500e:
			xe193ceb565ecaa0a.x18bb4aa7903ffced = new xc1b2bac943a0f541(x63c8ebbd109dc367, x7c809b22b8f9e275.xb063bbfcfeade526, x7c809b22b8f9e275.x197c47a24c81f695);
			break;
		default:
			throw new ArgumentException("Unexpected revision type.");
		}
	}

	public static void x63e15184a6cf147b(xeedad81aaed42a76 x789564759d365819, xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x782fcf0dc01a8e96 x782fcf0dc01a8e = new x782fcf0dc01a8e96(x3bcd232d01c);
		if (!x782fcf0dc01a8e.xbd2068db29af7264)
		{
			return;
		}
		switch (x782fcf0dc01a8e.x3146d638ec378671)
		{
		default:
			return;
		case "Word.Insertion":
			x789564759d365819.xae20093bed1e48a8(14, x4bc7f83d1f7d5b09(x782fcf0dc01a8e, x91bb72ac77aa7230.xf059562f878b500e));
			return;
		case "Word.Deletion":
			x789564759d365819.xae20093bed1e48a8(12, x4bc7f83d1f7d5b09(x782fcf0dc01a8e, x91bb72ac77aa7230.x1f522a512716a2ae));
			return;
		case "Word.Formatting":
			break;
		}
		while (x3bcd232d01c.x152cbadbfa8061b1("annotation"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "content")
			{
				while (x3bcd232d01c.x152cbadbfa8061b1("content"))
				{
					string xa66385d80d4d296f2;
					if ((xa66385d80d4d296f2 = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f2 == "rPr")
					{
						x06cbd3584b0394b8.x52a6f794e080ea91(xe134235b3526fa75, x789564759d365819, x782fcf0dc01a8e);
					}
					else
					{
						x3bcd232d01c.IgnoreElement();
					}
				}
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
	}

	private static xc1b2bac943a0f541 x4bc7f83d1f7d5b09(x782fcf0dc01a8e96 x7c809b22b8f9e275, x91bb72ac77aa7230 x2015187e820ca555)
	{
		xc1b2bac943a0f541 xc1b2bac943a0f = new xc1b2bac943a0f541(x2015187e820ca555);
		xc1b2bac943a0f.xb063bbfcfeade526 = x7c809b22b8f9e275.xb063bbfcfeade526;
		xc1b2bac943a0f.x242851e6278ed355 = x7c809b22b8f9e275.x197c47a24c81f695;
		return xc1b2bac943a0f;
	}

	private static void xb0049a36f0a0423c(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("annotation"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "content")
			{
				while (x3bcd232d01c.x152cbadbfa8061b1("content"))
				{
					switch (x3bcd232d01c.xa66385d80d4d296f)
					{
					case "r":
						x90c7969a84762ddd.x06b0e25aa6ad68a9(xe134235b3526fa75);
						break;
					case "annotation":
						x06b0e25aa6ad68a9(xe134235b3526fa75);
						break;
					default:
						x3bcd232d01c.IgnoreElement();
						break;
					}
				}
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
	}

	internal static Comment x3e6c33155caa6324(xeedad81aaed42a76 x789564759d365819, xdfce7f4f687956d7 xe134235b3526fa75)
	{
		xc1b2bac943a0f541 xe0ee6c8342da8f = xe134235b3526fa75.xe0ee6c8342da8f38;
		xc1b2bac943a0f541 xf0f66a68781cfaa = xe134235b3526fa75.xf0f66a68781cfaa5;
		xe134235b3526fa75.xe0ee6c8342da8f38 = null;
		xe134235b3526fa75.xf0f66a68781cfaa5 = null;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x782fcf0dc01a8e96 x782fcf0dc01a8e = new x782fcf0dc01a8e96(x3bcd232d01c);
		if (!x782fcf0dc01a8e.xe881e3c2e6bcef53)
		{
			return null;
		}
		Comment comment = new Comment(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819);
		((x8ad0c0863d1cd403)comment).x417a0a94031e7e8b = x782fcf0dc01a8e.xea1e81378298fa81;
		comment.Author = x782fcf0dc01a8e.xb063bbfcfeade526;
		comment.Initial = x782fcf0dc01a8e.xc085e830e777a251;
		comment.DateTime = x782fcf0dc01a8e.x197c47a24c81f695;
		while (x3bcd232d01c.x152cbadbfa8061b1("annotation"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "content")
			{
				x38ecd42e68717d79.x06b0e25aa6ad68a9(xe134235b3526fa75, comment);
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
		xe134235b3526fa75.xe0ee6c8342da8f38 = xe0ee6c8342da8f;
		xe134235b3526fa75.xf0f66a68781cfaa5 = xf0f66a68781cfaa;
		return comment;
	}
}
