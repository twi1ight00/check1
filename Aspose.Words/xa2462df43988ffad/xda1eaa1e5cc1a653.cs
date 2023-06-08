using Aspose.Words;

namespace xa2462df43988ffad;

internal class xda1eaa1e5cc1a653
{
	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	internal xda1eaa1e5cc1a653(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
	}

	internal VisitorAction xa2b18804731061bd(BookmarkStart xf602e1acaabe9019)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		if (x9b287b671d592594.x52320ec9c1034d1f && !x9b287b671d592594.x1339fb7786d0cc44 && x9b287b671d592594.xb872fbc83a2cb9a6)
		{
			x9b287b671d592594.x7bbab8fe28f5c2f0.Add(xf602e1acaabe9019);
		}
		if (xbe3f1f8817949ab5(xf602e1acaabe9019))
		{
			return VisitorAction.Continue;
		}
		if (xb946cae2fa332a30(xf602e1acaabe9019))
		{
			x334f73a0b642051d("text:bookmark-start", xf602e1acaabe9019.Name);
			if (xb1d086732c88c6fa(xf602e1acaabe9019) || !xa19f8f070cece1d2(xf602e1acaabe9019.Bookmark.BookmarkEnd))
			{
				x334f73a0b642051d("text:bookmark-end", xf602e1acaabe9019.Name);
			}
		}
		else
		{
			x334f73a0b642051d("text:bookmark-start", xf602e1acaabe9019.Name);
			x334f73a0b642051d("text:bookmark-end", xf602e1acaabe9019.Name);
		}
		return VisitorAction.Continue;
	}

	internal VisitorAction x3c82d5a325e3a429(BookmarkEnd x4413c2b27218d7b7)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		if (x9b287b671d592594.x52320ec9c1034d1f && !x9b287b671d592594.x1339fb7786d0cc44 && x9b287b671d592594.xb872fbc83a2cb9a6)
		{
			x9b287b671d592594.x7bbab8fe28f5c2f0.Add(x4413c2b27218d7b7);
		}
		if (xbe3f1f8817949ab5(x4413c2b27218d7b7))
		{
			return VisitorAction.Continue;
		}
		if (xa19f8f070cece1d2(x4413c2b27218d7b7))
		{
			if (x5d55077f70a31ace(x4413c2b27218d7b7))
			{
				x334f73a0b642051d("text:bookmark-start", x4413c2b27218d7b7.Name);
			}
			x334f73a0b642051d("text:bookmark-end", x4413c2b27218d7b7.Name);
		}
		return VisitorAction.Continue;
	}

	private void x334f73a0b642051d(string x121383aa64985888, string x5ff22b1908d7c421)
	{
		x9b287b671d592594.xe1410f585439c7d4.x5a3f5d78674f78e4(x121383aa64985888);
		x9b287b671d592594.xe1410f585439c7d4.x19b0790c272bbe88("text:name", x5ff22b1908d7c421);
		x9b287b671d592594.xe1410f585439c7d4.xd52401bdf5aacef6("/>");
	}

	private bool xbe3f1f8817949ab5(Node xa490ad5ef1682691)
	{
		if ((!x9b287b671d592594.x52320ec9c1034d1f || x9b287b671d592594.x1339fb7786d0cc44) && x9b287b671d592594.x05ee8ce4d7312eb5 != x14bf6f47128e4438.x3231bc142724c8b3 && !x9b287b671d592594.xb872fbc83a2cb9a6)
		{
			if (!xdb0bf9f81de4b38c.xc8d1bb1390d5266d(xa490ad5ef1682691))
			{
				return x9b287b671d592594.x68e1404b914783c1;
			}
			return false;
		}
		return true;
	}

	private static bool xb946cae2fa332a30(BookmarkStart xf602e1acaabe9019)
	{
		if (xf602e1acaabe9019.ParentNode is Paragraph && xf602e1acaabe9019.Bookmark.BookmarkEnd.ParentNode is Paragraph)
		{
			Paragraph paragraph = (Paragraph)xf602e1acaabe9019.ParentNode;
			Paragraph paragraph2 = (Paragraph)xf602e1acaabe9019.Bookmark.BookmarkEnd.ParentNode;
			if (paragraph.IsInCell && paragraph2.IsInCell)
			{
				return paragraph2.xc5464084edc8e226 == paragraph.xc5464084edc8e226;
			}
		}
		return true;
	}

	private static bool xa19f8f070cece1d2(BookmarkEnd x4413c2b27218d7b7)
	{
		if (x4413c2b27218d7b7.ParentNode is Paragraph)
		{
			Paragraph paragraph = (Paragraph)x4413c2b27218d7b7.ParentNode;
			if (paragraph.IsInCell)
			{
				return paragraph.xc5464084edc8e226.Range.Bookmarks[x4413c2b27218d7b7.Name] != null;
			}
		}
		return true;
	}

	private bool x5d55077f70a31ace(BookmarkEnd x4413c2b27218d7b7)
	{
		foreach (object item in x9b287b671d592594.x7bbab8fe28f5c2f0)
		{
			if (item is BookmarkStart && (item as BookmarkStart).Name == x4413c2b27218d7b7.Name)
			{
				return true;
			}
		}
		return false;
	}

	private bool xb1d086732c88c6fa(BookmarkStart xf602e1acaabe9019)
	{
		foreach (object item in x9b287b671d592594.x7bbab8fe28f5c2f0)
		{
			if (item is BookmarkEnd && (item as BookmarkEnd).Name == xf602e1acaabe9019.Name)
			{
				return true;
			}
		}
		return false;
	}
}
