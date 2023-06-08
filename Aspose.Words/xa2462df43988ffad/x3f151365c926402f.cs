using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Tables;
using x6c95d9cf46ff5f25;

namespace xa2462df43988ffad;

internal class x3f151365c926402f
{
	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	private readonly x560f0e9efcf5b9b1 x6962cbeae4129aa3;

	internal x3f151365c926402f(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
		x6962cbeae4129aa3 = new x560f0e9efcf5b9b1(x9b287b671d592594);
	}

	internal VisitorAction x57a5d79d9b9d67f5(Paragraph x31e6518f5e08db6c, bool x8251c6c98b26412e)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		x9b287b671d592594.xc907f222971a2a50 = true;
		if (x0ade0826c987879b(x31e6518f5e08db6c, x9b287b671d592594.x1f3ed48ef81a3a47))
		{
			return VisitorAction.Continue;
		}
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		char c = x9349a0a90c7fc32f(x31e6518f5e08db6c);
		char c2 = x6eeec9da668234a4(x9b287b671d592594.x1f3ed48ef81a3a47);
		bool flag = c == '\f' || c2 == '\f';
		bool flag2 = c == '\u000e' || c2 == '\u000e';
		if (x9b287b671d592594.xb872fbc83a2cb9a6)
		{
			if ((flag || flag2) && x9b287b671d592594.x1f3ed48ef81a3a47 == null)
			{
				x6962cbeae4129aa3.xaedce5725e456ac5(x31e6518f5e08db6c, x9509445ad0c3e86a: false, xabdcf516a31c311c: false);
			}
			x6962cbeae4129aa3.xaedce5725e456ac5(x31e6518f5e08db6c, flag, flag2);
		}
		else if ((x9b287b671d592594.x05ee8ce4d7312eb5 != x14bf6f47128e4438.x9a173dcac29488ce || x8251c6c98b26412e) && x9b287b671d592594.x05ee8ce4d7312eb5 != x14bf6f47128e4438.x3231bc142724c8b3 && x9b287b671d592594.x05ee8ce4d7312eb5 != x14bf6f47128e4438.x62896619d90ad964)
		{
			x9b287b671d592594.x84e55246091c35af = 0;
			x9b287b671d592594.xa0c811de7638c8b1 = 0;
			string x121383aa = ((x31e6518f5e08db6c.ParagraphFormat.IsHeading && (!(x31e6518f5e08db6c.ParentNode is Shape) || !x00718c1b6df413d3.xa3bfa3d00a716e76(x31e6518f5e08db6c.ParentNode as Shape))) ? "text:h" : "text:p");
			if ((flag || flag2) && x9b287b671d592594.x1f3ed48ef81a3a47 == null)
			{
				x1b08a07a3132f8bc(x31e6518f5e08db6c, x121383aa);
				xe1410f585439c7d.x2dfde153f4ef96d0(x121383aa);
			}
			if (x2e7a2ea5da15ce85(x31e6518f5e08db6c))
			{
				xf34a2e745397ca05(x31e6518f5e08db6c);
			}
			x1b08a07a3132f8bc(x31e6518f5e08db6c, x121383aa);
		}
		return VisitorAction.Continue;
	}

	internal void x1b08a07a3132f8bc(Paragraph x9c79b5ad7b769b12, string x121383aa64985888)
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x2307058321cdb62f(x121383aa64985888);
		xe1410f585439c7d.x943f6be3acf634db("text:style-name", x6962cbeae4129aa3.x738231306863c7ae());
		if (x121383aa64985888 == "text:h")
		{
			xe1410f585439c7d.x943f6be3acf634db("text:outline-level", (int)(x9c79b5ad7b769b12.ParagraphFormat.OutlineLevel + 1));
		}
	}

	internal VisitorAction x57a5d79d9b9d67f5(Paragraph x31e6518f5e08db6c)
	{
		return x57a5d79d9b9d67f5(x31e6518f5e08db6c, x8251c6c98b26412e: false);
	}

	internal VisitorAction x250b22e8996b97fb(Paragraph x31e6518f5e08db6c, bool x8251c6c98b26412e)
	{
		if (!x0ade0826c987879b(x31e6518f5e08db6c, x31e6518f5e08db6c) && !x9b287b671d592594.xb872fbc83a2cb9a6 && x9b287b671d592594.x05ee8ce4d7312eb5 != x14bf6f47128e4438.x3231bc142724c8b3 && x9b287b671d592594.x05ee8ce4d7312eb5 != x14bf6f47128e4438.x62896619d90ad964 && (x9b287b671d592594.x05ee8ce4d7312eb5 != x14bf6f47128e4438.x9a173dcac29488ce || x8251c6c98b26412e))
		{
			string x121383aa = ((x31e6518f5e08db6c.ParagraphFormat.IsHeading && (!(x31e6518f5e08db6c.ParentNode is Shape) || !x00718c1b6df413d3.xa3bfa3d00a716e76(x31e6518f5e08db6c.ParentNode as Shape))) ? "text:h" : "text:p");
			x9b287b671d592594.xe1410f585439c7d4.x2dfde153f4ef96d0(x121383aa);
			if (x2e7a2ea5da15ce85(x31e6518f5e08db6c))
			{
				xb1b971951f4f2247(x31e6518f5e08db6c);
			}
		}
		x9b287b671d592594.xef47796674b8012f = x31e6518f5e08db6c;
		x9b287b671d592594.x3460ec740e098e72(x31e6518f5e08db6c, x31e6518f5e08db6c.ParentSection);
		return VisitorAction.Continue;
	}

	internal VisitorAction x250b22e8996b97fb(Paragraph x31e6518f5e08db6c)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		return x250b22e8996b97fb(x31e6518f5e08db6c, x8251c6c98b26412e: false);
	}

	private bool x2e7a2ea5da15ce85(Paragraph x31e6518f5e08db6c)
	{
		if (x31e6518f5e08db6c.IsListItem && !(x31e6518f5e08db6c.ParentNode is Comment))
		{
			return !x9b287b671d592594.x8197188ddb6f93d3;
		}
		return false;
	}

	private bool x0ade0826c987879b(Paragraph x31e6518f5e08db6c, Node x4001c24862bb3da0)
	{
		if (x31e6518f5e08db6c.ParentNode is Shape)
		{
			Shape shape = (Shape)x31e6518f5e08db6c.ParentNode;
			if (shape.ChildNodes.Count == 1 && shape.ChildNodes[0] is Paragraph && ((Paragraph)shape.ChildNodes[0]).ChildNodes.Count == 1 && ((Paragraph)shape.ChildNodes[0]).ChildNodes[0] is Shape && ((Shape)((Paragraph)shape.ChildNodes[0]).ChildNodes[0]).IsImage && shape.ParentNode is GroupShape)
			{
				return true;
			}
		}
		if (!x31e6518f5e08db6c.xc8d1bb1390d5266d && x9b287b671d592594.x68e1404b914783c1)
		{
			return true;
		}
		if (xedb3bed043cdda7a(x31e6518f5e08db6c))
		{
			return true;
		}
		if (x1b00a9cefdb5b344(x31e6518f5e08db6c, x4001c24862bb3da0))
		{
			return true;
		}
		return false;
	}

	private static bool xedb3bed043cdda7a(Paragraph x31e6518f5e08db6c)
	{
		if (!x31e6518f5e08db6c.HasChildNodes && x31e6518f5e08db6c.IsEndOfSection && !x31e6518f5e08db6c.IsEndOfDocument)
		{
			return !x31e6518f5e08db6c.ParentStory.x74f5d3c8c1c169b6;
		}
		return false;
	}

	private void xf34a2e745397ca05(Paragraph x31e6518f5e08db6c)
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		int num = x31e6518f5e08db6c.ListFormat.ListLevelNumber;
		Paragraph xef47796674b8012f = x9b287b671d592594.xef47796674b8012f;
		Paragraph xdac25484c1d1b = x44aa0d7982a5f237();
		int num2 = x2a82c262e9a14b5f(x31e6518f5e08db6c, xef47796674b8012f, xdac25484c1d1b);
		if (x7ca09dcbf9266b1e(x31e6518f5e08db6c))
		{
			xe1410f585439c7d.x2307058321cdb62f("text:list");
			xe1410f585439c7d.x943f6be3acf634db("text:style-name", $"LS{x31e6518f5e08db6c.ListFormat.List.ListId}");
			if (!x9b287b671d592594.xf57de0fd37d5e97d.IsStrictSchema11)
			{
				xe1410f585439c7d.x943f6be3acf634db("xml:id", x84815acd0510c334(x9b287b671d592594.x883eea81d91d4029.Count));
			}
			string xbcea506a33cf = xb961f9bba5281078(x31e6518f5e08db6c);
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
			{
				if (x9b287b671d592594.xf57de0fd37d5e97d.IsStrictSchema11)
				{
					xe1410f585439c7d.x943f6be3acf634db("text:continue-numbering", "true");
				}
				if (!x9b287b671d592594.xf57de0fd37d5e97d.IsStrictSchema11)
				{
					xe1410f585439c7d.x943f6be3acf634db("text:continue-list", xbcea506a33cf);
				}
			}
			xe1410f585439c7d.x2307058321cdb62f("text:list-item");
		}
		if (xe378b11c294a85fc(x31e6518f5e08db6c))
		{
			xe1410f585439c7d.x2307058321cdb62f("text:list-item");
		}
		while (num > num2)
		{
			xe1410f585439c7d.x2307058321cdb62f("text:list");
			xe1410f585439c7d.x2307058321cdb62f("text:list-item");
			num--;
		}
	}

	private bool xc02f2d8d0c167e7f(Paragraph x54acfcf5460fb360, Paragraph x08eef91ccd7eb033)
	{
		if (xedb3bed043cdda7a(x08eef91ccd7eb033) || x54acfcf5460fb360.IsEndOfSection)
		{
			return x9b287b671d592594.x10d7a1cae426b158.NextSibling != null;
		}
		return false;
	}

	private static string x84815acd0510c334(int xbd8cc02a6046c012)
	{
		if (xbd8cc02a6046c012 == -1)
		{
			return null;
		}
		return $"list{xbd8cc02a6046c012}";
	}

	private string xb961f9bba5281078(Paragraph x31e6518f5e08db6c)
	{
		if (x31e6518f5e08db6c.ListFormat.ListLevel.NumberStyle == NumberStyle.Bullet)
		{
			return null;
		}
		for (int i = 0; i < x9b287b671d592594.x883eea81d91d4029.Count; i++)
		{
			Paragraph paragraph = x9b287b671d592594.x883eea81d91d4029.get_xe6d4b1b411ed94b5(i);
			if (paragraph.IsListItem && x31e6518f5e08db6c.ListFormat.x71c63f7e57f7ede5 == paragraph.ListFormat.x71c63f7e57f7ede5)
			{
				if (!x9b287b671d592594.xf57de0fd37d5e97d.IsStrictSchema11)
				{
					return x84815acd0510c334(i);
				}
				if (i == x9b287b671d592594.x883eea81d91d4029.Count - 1)
				{
					return x84815acd0510c334(i);
				}
			}
		}
		return null;
	}

	private void xb1b971951f4f2247(Paragraph x31e6518f5e08db6c)
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		int num = x31e6518f5e08db6c.ListFormat.ListLevelNumber;
		Paragraph xe732ec52c = x31e6518f5e08db6c.NextSibling as Paragraph;
		Paragraph xb5aa55ee6006d9ab = xbad72f67e1ff6656(x31e6518f5e08db6c);
		int num2 = x4b1c77efc62db72a(x31e6518f5e08db6c, xe732ec52c, xb5aa55ee6006d9ab);
		if (x122e06670f638314(x31e6518f5e08db6c))
		{
			xe1410f585439c7d.x2dfde153f4ef96d0();
			xe1410f585439c7d.x2dfde153f4ef96d0();
		}
		if (x13253233d939b72f(x31e6518f5e08db6c))
		{
			xe1410f585439c7d.x2dfde153f4ef96d0();
		}
		while (num > num2)
		{
			xe1410f585439c7d.x2dfde153f4ef96d0();
			xe1410f585439c7d.x2dfde153f4ef96d0();
			num--;
		}
		x9b287b671d592594.x883eea81d91d4029.Add(x31e6518f5e08db6c);
	}

	private bool x7ca09dcbf9266b1e(Paragraph x31e6518f5e08db6c)
	{
		int x71c63f7e57f7ede = x31e6518f5e08db6c.ListFormat.x71c63f7e57f7ede5;
		Paragraph paragraph = x9b287b671d592594.x1f3ed48ef81a3a47 as Paragraph;
		int num = x44aa0d7982a5f237()?.ListFormat.x71c63f7e57f7ede5 ?? (-1);
		if (paragraph != null && paragraph.IsListItem && num == x71c63f7e57f7ede && !(x9b287b671d592594.x1f3ed48ef81a3a47 is Table))
		{
			if (x31e6518f5e08db6c.IsInCell || x31e6518f5e08db6c.ParentNode is Footnote)
			{
				return x31e6518f5e08db6c.x65c77554c620f590;
			}
			return false;
		}
		return true;
	}

	private bool xe378b11c294a85fc(Paragraph x31e6518f5e08db6c)
	{
		int x71c63f7e57f7ede = x31e6518f5e08db6c.ListFormat.x71c63f7e57f7ede5;
		int listLevelNumber = x31e6518f5e08db6c.ListFormat.ListLevelNumber;
		Paragraph paragraph = x9b287b671d592594.x1f3ed48ef81a3a47 as Paragraph;
		Paragraph paragraph2 = x44aa0d7982a5f237();
		int num = paragraph2?.ListFormat.x71c63f7e57f7ede5 ?? (-1);
		int num2 = x2a82c262e9a14b5f(x31e6518f5e08db6c, paragraph, paragraph2);
		if (paragraph != null && paragraph.IsListItem && num == x71c63f7e57f7ede && listLevelNumber <= num2)
		{
			if (x31e6518f5e08db6c.IsInCell)
			{
				return !x31e6518f5e08db6c.x65c77554c620f590;
			}
			return true;
		}
		return false;
	}

	private int x2a82c262e9a14b5f(Paragraph x31e6518f5e08db6c, Paragraph x797cd175ec46376f, Paragraph xdac25484c1d1b154)
	{
		if (xdac25484c1d1b154 != null && (x797cd175ec46376f == null || (x797cd175ec46376f.IsListItem && !x31e6518f5e08db6c.x7f316d7196a18aa6 && !x797cd175ec46376f.IsEndOfCell && !x797cd175ec46376f.x65c41b4567f1d25e && !x797cd175ec46376f.IsEndOfSection && (!(x31e6518f5e08db6c.ParentNode is Footnote) || !x31e6518f5e08db6c.x65c77554c620f590) && ((!xedb3bed043cdda7a(x797cd175ec46376f) && !x797cd175ec46376f.IsEndOfSection) || x9b287b671d592594.x10d7a1cae426b158.NextSibling == null))))
		{
			return xdac25484c1d1b154.ListFormat.ListLevelNumber;
		}
		return 0;
	}

	private int x4b1c77efc62db72a(Paragraph x31e6518f5e08db6c, Paragraph xe732ec52c8262568, Paragraph xb5aa55ee6006d9ab)
	{
		if (xb5aa55ee6006d9ab != null && (xe732ec52c8262568 == null || (xe732ec52c8262568.IsListItem && !x31e6518f5e08db6c.IsEndOfCell && !xe732ec52c8262568.x7f316d7196a18aa6 && !x31e6518f5e08db6c.IsEndOfCell && !x31e6518f5e08db6c.IsEndOfSection && (!(x31e6518f5e08db6c.ParentNode is Footnote) || !x31e6518f5e08db6c.x16479f42fe4547f2) && ((!xedb3bed043cdda7a(x31e6518f5e08db6c) && !x31e6518f5e08db6c.IsEndOfSection) || x9b287b671d592594.x10d7a1cae426b158.NextSibling == null))))
		{
			return xb5aa55ee6006d9ab.ListFormat.ListLevelNumber;
		}
		return 0;
	}

	private bool x122e06670f638314(Paragraph x31e6518f5e08db6c)
	{
		int x71c63f7e57f7ede = x31e6518f5e08db6c.ListFormat.x71c63f7e57f7ede5;
		Paragraph paragraph = x31e6518f5e08db6c.NextSibling as Paragraph;
		int num = xbad72f67e1ff6656(x31e6518f5e08db6c)?.ListFormat.x71c63f7e57f7ede5 ?? (-1);
		if (paragraph != null && paragraph.IsListItem && num == x71c63f7e57f7ede && !(x31e6518f5e08db6c.xa6890a1cb2b8896e is Table) && (!x31e6518f5e08db6c.IsInCell || !x31e6518f5e08db6c.x16479f42fe4547f2))
		{
			return xc02f2d8d0c167e7f(x31e6518f5e08db6c, paragraph);
		}
		return true;
	}

	private bool x13253233d939b72f(Paragraph x31e6518f5e08db6c)
	{
		int x71c63f7e57f7ede = x31e6518f5e08db6c.ListFormat.x71c63f7e57f7ede5;
		int listLevelNumber = x31e6518f5e08db6c.ListFormat.ListLevelNumber;
		Paragraph paragraph = x31e6518f5e08db6c.NextSibling as Paragraph;
		Paragraph paragraph2 = xbad72f67e1ff6656(x31e6518f5e08db6c);
		int num = paragraph2?.ListFormat.x71c63f7e57f7ede5 ?? (-1);
		int num2 = x4b1c77efc62db72a(x31e6518f5e08db6c, paragraph, paragraph2);
		if (paragraph != null && paragraph.IsListItem && num == x71c63f7e57f7ede && listLevelNumber >= num2 && (!x31e6518f5e08db6c.IsInCell || !x31e6518f5e08db6c.x16479f42fe4547f2))
		{
			return !xc02f2d8d0c167e7f(x31e6518f5e08db6c, paragraph);
		}
		return false;
	}

	private Paragraph x44aa0d7982a5f237()
	{
		if (x9b287b671d592594.x883eea81d91d4029.Count <= 0)
		{
			return null;
		}
		return x9b287b671d592594.x883eea81d91d4029.get_xe6d4b1b411ed94b5(x9b287b671d592594.x883eea81d91d4029.Count - 1);
	}

	private static Paragraph xbad72f67e1ff6656(Paragraph x31e6518f5e08db6c)
	{
		Paragraph paragraph = x31e6518f5e08db6c.xa6890a1cb2b8896e as Paragraph;
		if (x31e6518f5e08db6c.x16479f42fe4547f2 || (paragraph != null && xedb3bed043cdda7a(paragraph)))
		{
			return null;
		}
		Node node = (x31e6518f5e08db6c.IsEndOfCell ? x31e6518f5e08db6c.xc5464084edc8e226.xa6890a1cb2b8896e : x31e6518f5e08db6c.xa6890a1cb2b8896e);
		while (node != null && !(node is Table))
		{
			if (node is Paragraph)
			{
				Paragraph paragraph2 = (Paragraph)node;
				if (paragraph2.IsListItem)
				{
					return paragraph2;
				}
			}
			node = node.xa6890a1cb2b8896e as Paragraph;
		}
		return null;
	}

	internal void x2bba81f7e198efaa(Paragraph x31e6518f5e08db6c)
	{
		x9b287b671d592594.x8197188ddb6f93d3 = true;
		x250b22e8996b97fb(x31e6518f5e08db6c);
		x57a5d79d9b9d67f5(x31e6518f5e08db6c);
		x9b287b671d592594.x8197188ddb6f93d3 = false;
	}

	internal static char x9349a0a90c7fc32f(Paragraph x31e6518f5e08db6c)
	{
		if (x31e6518f5e08db6c != null && x31e6518f5e08db6c.x38453dde2dc1ee92 != null)
		{
			string text = x31e6518f5e08db6c.x38453dde2dc1ee92.Text;
			if (x0d299f323d241756.x5959bccb67bbf051(text))
			{
				return text[0];
			}
		}
		return '\0';
	}

	internal static char x6eeec9da668234a4(Node xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37 != null && xda5bf54deb817e37 is Paragraph)
		{
			Paragraph paragraph = xda5bf54deb817e37 as Paragraph;
			if (paragraph.Runs.Count > 0)
			{
				Run run = paragraph.xf562da51e0b3c429();
				if (run != null)
				{
					string text = run.Text;
					if (x0d299f323d241756.x5959bccb67bbf051(text) && text.Length > 1)
					{
						return text[text.Length - 1];
					}
				}
			}
		}
		return '\0';
	}

	internal static bool x1b00a9cefdb5b344(Paragraph xa82250af367d9f87, Node x4001c24862bb3da0)
	{
		if (x4001c24862bb3da0 == null || !(x4001c24862bb3da0 is Paragraph))
		{
			return false;
		}
		Paragraph paragraph = (Paragraph)x4001c24862bb3da0;
		if (!paragraph.IsInCell && !xa82250af367d9f87.xd2c86fb8ed7b1331)
		{
			if (!paragraph.x1a78664fa10a3755.x263d579af1d0d43f(1450))
			{
				return paragraph.x1a78664fa10a3755.x263d579af1d0d43f(1440);
			}
			return true;
		}
		return false;
	}

	internal static bool x1b00a9cefdb5b344(Paragraph x4001c24862bb3da0)
	{
		return x1b00a9cefdb5b344(x4001c24862bb3da0, x4001c24862bb3da0);
	}
}
