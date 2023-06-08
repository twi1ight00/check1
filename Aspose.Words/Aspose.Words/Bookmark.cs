using System;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace Aspose.Words;

public class Bookmark
{
	internal const string x2d35d2c1a83787f8 = "Error! Bookmark not defined.";

	private readonly BookmarkStart x8408170975a63c2a;

	private BookmarkEnd xd6a7d07cb70f9923;

	public string Name
	{
		get
		{
			return BookmarkStart.Name;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			BookmarkEnd.x54f99ef1e934e59c(value);
			BookmarkStart.x54f99ef1e934e59c(value);
		}
	}

	public string Text
	{
		get
		{
			return x633d57e35b6715a4(x39abdfb3e1bf0b2a: false);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			x4109adf752c7242b();
			x267e63baaf7bc424();
			xeedad81aaed42a76 x789564759d = xf4748c617f94d391();
			x5699f8523a546a42.x52b190e626f65140(BookmarkStart, x4ec19a117bbb0963: false, BookmarkEnd, xead571f03cb4ee1d: false);
			DocumentBuilder documentBuilder = new DocumentBuilder(BookmarkStart.x357c90b33d6bb8e6());
			documentBuilder.MoveTo(BookmarkEnd);
			documentBuilder.x77184348a27ba1e6(x789564759d, x692ced34f50137f2: true);
			documentBuilder.Write(value);
		}
	}

	public BookmarkStart BookmarkStart => x8408170975a63c2a;

	public BookmarkEnd BookmarkEnd
	{
		get
		{
			if (xd6a7d07cb70f9923 == null)
			{
				xd6a7d07cb70f9923 = xfcbee4820570241e.x826809a474c46025(x8408170975a63c2a.Document, Name);
			}
			return xd6a7d07cb70f9923;
		}
	}

	internal Bookmark(BookmarkStart bookmarkStart)
	{
		if (bookmarkStart == null)
		{
			throw new ArgumentNullException("bookmarkStart");
		}
		x8408170975a63c2a = bookmarkStart;
	}

	internal string x633d57e35b6715a4(bool x39abdfb3e1bf0b2a)
	{
		return x9f265cdf86e37e15.x633d57e35b6715a4(BookmarkStart, x579197826ce035a3: false, BookmarkEnd, x230d76aa903b832a: false, x39abdfb3e1bf0b2a);
	}

	private void x4109adf752c7242b()
	{
		if (BookmarkStart != null)
		{
			Node node = BookmarkStart;
			do
			{
				node = node.NextSibling;
			}
			while (node != null && x241b56d731eb66a7(node));
			if (BookmarkStart.NextSibling != node)
			{
				BookmarkStart.xdfa6ecc6f742f086.InsertBefore(BookmarkStart, node);
			}
		}
	}

	private void x267e63baaf7bc424()
	{
		if (BookmarkEnd != null)
		{
			Node node = BookmarkEnd;
			do
			{
				node = node.PreviousSibling;
			}
			while (node != null && x241b56d731eb66a7(node));
			if (BookmarkEnd.PreviousSibling != node)
			{
				BookmarkEnd.xdfa6ecc6f742f086.InsertAfter(BookmarkEnd, node);
			}
		}
	}

	private bool x241b56d731eb66a7(Node xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37 is BookmarkStart bookmarkStart && !x0d299f323d241756.x90637a473b1ceaaa(Name, bookmarkStart.Name))
		{
			return true;
		}
		if (xda5bf54deb817e37 is BookmarkEnd bookmarkEnd && !x0d299f323d241756.x90637a473b1ceaaa(Name, bookmarkEnd.Name))
		{
			return true;
		}
		return false;
	}

	private xeedad81aaed42a76 xf4748c617f94d391()
	{
		Node nextSibling = x8408170975a63c2a.NextSibling;
		while (nextSibling != null && !(nextSibling is Inline))
		{
			nextSibling = nextSibling.NextSibling;
		}
		if (nextSibling != null)
		{
			return ((Inline)nextSibling).xeedad81aaed42a76;
		}
		Paragraph paragraph = (Paragraph)x8408170975a63c2a.xdfa6ecc6f742f086;
		return paragraph.x344511c4e4ce09da;
	}

	public void Remove()
	{
		BookmarkEnd.Remove();
		BookmarkStart.Remove();
	}

	internal x7e263f21a73a027a x451c3f5e0b9f8822()
	{
		int num = 0;
		x7e263f21a73a027a x7e263f21a73a027a = new x7e263f21a73a027a(BookmarkStart, includeStart: false, BookmarkEnd, includeEnd: false);
		foreach (Node item in x7e263f21a73a027a)
		{
			switch (item.NodeType)
			{
			case NodeType.FieldStart:
				num++;
				break;
			case NodeType.FieldSeparator:
				if (num == 0)
				{
					return new x7e263f21a73a027a(item, includeStart: true, BookmarkEnd, includeEnd: false);
				}
				num--;
				break;
			case NodeType.FieldEnd:
				if (!((FieldEnd)item).HasSeparator)
				{
					num--;
				}
				break;
			}
		}
		return new x7e263f21a73a027a(BookmarkStart, includeStart: false, BookmarkEnd, includeEnd: false);
	}
}
