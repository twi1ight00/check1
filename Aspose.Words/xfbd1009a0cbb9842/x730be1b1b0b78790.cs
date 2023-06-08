using System.Text;
using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Lists;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xd2754ae26d400653;

namespace xfbd1009a0cbb9842;

internal class x730be1b1b0b78790 : Field, x6ed66b5cf8da2955
{
	private const string xc1bb3d98fe414524 = "above";

	private const string xfe0059cd1ee622f3 = "below";

	internal string x0e99a2a20bc3c647 => base.xb452e2ee706d7a67.x642e37025c67edab(0);

	internal bool x7ed59aa9825cfe0a => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\n");

	internal bool x72a9ca80a9b7f658 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\r");

	internal bool x53d17e1647f72ed6 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\w");

	internal bool x79f894c2d49aca64 => base.xb452e2ee706d7a67.xcc2d426b867d703d("\\p");

	internal override x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		string text = base.xb452e2ee706d7a67.x642e37025c67edab(0);
		if (!x0d299f323d241756.x5959bccb67bbf051(text))
		{
			return new xd5801a931e010963(this, "Error! No bookmark name given.");
		}
		Bookmark bookmark = x357c90b33d6bb8e6().Range.Bookmarks[text];
		if (bookmark == null)
		{
			return new xd5801a931e010963(this, "Error! Reference source not found.");
		}
		base.x6edce55dcd2d335b.xdd53735657fe1b6b();
		Paragraph paragraph = (Paragraph)bookmark.BookmarkStart.xdfa6ecc6f742f086;
		base.x34a4695711b84f85.x874035a07982e6e7(new xb424217efe68741a(x357c90b33d6bb8e6()), xcf417e2db4fe9ed3.x5a360e1cee7f2c61);
		if (x7ed59aa9825cfe0a)
		{
			string x8b36775962dd81f = x42f7238db039e795(paragraph);
			return x77d9178889eb19e5(bookmark, x8b36775962dd81f);
		}
		if (x72a9ca80a9b7f658)
		{
			string x8b36775962dd81f2 = x2d418f17c2a87afd(paragraph, base.Start.ParentParagraph);
			return x77d9178889eb19e5(bookmark, x8b36775962dd81f2);
		}
		if (x53d17e1647f72ed6)
		{
			string x8b36775962dd81f3 = xd57b1e0d28032d64(paragraph);
			return x77d9178889eb19e5(bookmark, x8b36775962dd81f3);
		}
		if (x79f894c2d49aca64)
		{
			string result = xe7d3712adc448b3e(bookmark);
			return new xca592a476766b11a(this, result);
		}
		x7e263f21a73a027a x7e263f21a73a027a = bookmark.x451c3f5e0b9f8822();
		if (xe165ee0923ac1f65(x7e263f21a73a027a))
		{
			return new xd5801a931e010963(this, "Error! Not a valid bookmark self-reference.");
		}
		foreach (Node item in x7e263f21a73a027a)
		{
			if (item.NodeType == NodeType.FieldStart)
			{
				base.x34a4695711b84f85.xcf4268d5a79e653b(this, xcf417e2db4fe9ed3.x5a360e1cee7f2c61);
				break;
			}
		}
		x0a28863c804404d7.x5af2763689ebe731(x7e263f21a73a027a, base.End, null);
		base.x6edce55dcd2d335b.xac51c2571643df46();
		if (bookmark.BookmarkStart.xdfa6ecc6f742f086 != bookmark.BookmarkEnd.xdfa6ecc6f742f086)
		{
			base.Start.ParentParagraph.x1a78664fa10a3755 = (x1a78664fa10a3755)paragraph.x1a78664fa10a3755.x8b61531c8ea35b85();
		}
		return new xbd727e2aafbfe2ad(this);
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\f":
		case "\\h":
		case "\\n":
		case "\\p":
		case "\\r":
		case "\\t":
		case "\\w":
			return x9f6b815e19fa8f62.x8416ed4b8ffb3e34;
		case "\\d":
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

	internal static string x2d418f17c2a87afd(Paragraph xa204f7f903d1cbd7, Paragraph xaaa3b15bde9c4330)
	{
		xd269993cc48a63d2 x4ededf5feccc72f = xa204f7f903d1cbd7.ListLabel.x4ededf5feccc72f8;
		if (x4ededf5feccc72f == null)
		{
			return x83e9de6bbe7679e4(xa204f7f903d1cbd7.ListLabel.LabelString);
		}
		xd269993cc48a63d2 xd269993cc48a63d = xd50c36673f5fea7d(x4ededf5feccc72f, xaaa3b15bde9c4330);
		int num = 0;
		if (xd269993cc48a63d != null)
		{
			for (int i = 0; i < x4ededf5feccc72f.x51e5bb947db89a97; i++)
			{
				ListLevel listLevel = xd269993cc48a63d.x1b66e22d28c087af(i);
				ListLevel listLevel2 = x4ededf5feccc72f.x1b66e22d28c087af(i);
				int num2 = xd269993cc48a63d.x043aafba68f5c559(i);
				int num3 = x4ededf5feccc72f.x043aafba68f5c559(i);
				if (listLevel != listLevel2 || num2 != num3)
				{
					break;
				}
				num++;
			}
		}
		string x337e217cb3ba = xcb0a3bdf6cb11198.xf81712d779b52fd1(x4ededf5feccc72f, num);
		return x83e9de6bbe7679e4(x337e217cb3ba);
	}

	private static xd269993cc48a63d2 xd50c36673f5fea7d(xd269993cc48a63d2 xc2641f1da40510de, Paragraph xbee57e1dc5d7d569)
	{
		ListLevel listLevel = xc2641f1da40510de.x1b66e22d28c087af(0);
		xd269993cc48a63d2 result = null;
		NodeCollection childNodes = xbee57e1dc5d7d569.x357c90b33d6bb8e6().GetChildNodes(NodeType.Paragraph, isDeep: true);
		foreach (Paragraph item in childNodes)
		{
			xd269993cc48a63d2 x4ededf5feccc72f = item.ListLabel.x4ededf5feccc72f8;
			if (x4ededf5feccc72f != null && x4ededf5feccc72f.x1b66e22d28c087af(0) == listLevel)
			{
				result = x4ededf5feccc72f;
			}
			if (item == xbee57e1dc5d7d569)
			{
				break;
			}
		}
		return result;
	}

	internal static string x42f7238db039e795(Paragraph xa204f7f903d1cbd7)
	{
		return x83e9de6bbe7679e4(xa204f7f903d1cbd7.ListLabel.LabelString);
	}

	internal static string xd57b1e0d28032d64(Paragraph xa204f7f903d1cbd7)
	{
		xd269993cc48a63d2 x4ededf5feccc72f = xa204f7f903d1cbd7.ListLabel.x4ededf5feccc72f8;
		string x337e217cb3ba = ((x4ededf5feccc72f != null) ? xcb0a3bdf6cb11198.xf81712d779b52fd1(x4ededf5feccc72f) : xa204f7f903d1cbd7.ListLabel.LabelString);
		return x83e9de6bbe7679e4(x337e217cb3ba);
	}

	private xca592a476766b11a x77d9178889eb19e5(Bookmark xa490ad5ef1682691, string x8b36775962dd81f9)
	{
		string result = x8b36775962dd81f9;
		if (x79f894c2d49aca64)
		{
			StringBuilder stringBuilder = new StringBuilder(x8b36775962dd81f9.Length + "above".Length + 1);
			stringBuilder.Append(x8b36775962dd81f9);
			stringBuilder.Append(' ');
			stringBuilder.Append(xe7d3712adc448b3e(xa490ad5ef1682691));
			result = stringBuilder.ToString();
		}
		return new xca592a476766b11a(this, result);
	}

	private string xe7d3712adc448b3e(Bookmark xa5b3260e9de20fa8)
	{
		if (xa5b3260e9de20fa8 != null)
		{
			if (!xa5b3260e9de20fa8.BookmarkStart.x026dc2547516c59d(base.Start))
			{
				return "below";
			}
			return "above";
		}
		return string.Empty;
	}

	private static string x83e9de6bbe7679e4(string x337e217cb3ba0627)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x337e217cb3ba0627) || x337e217cb3ba0627[x337e217cb3ba0627.Length - 1] != '.')
		{
			return x337e217cb3ba0627;
		}
		return x337e217cb3ba0627.Remove(x337e217cb3ba0627.Length - 1, 1);
	}

	private bool xe165ee0923ac1f65(x7e263f21a73a027a x11a5c6be4dc60ee3)
	{
		foreach (Node item in x11a5c6be4dc60ee3)
		{
			NodeType nodeType = item.NodeType;
			if (nodeType == NodeType.FieldStart && base.Start == item)
			{
				return true;
			}
		}
		return false;
	}
}
