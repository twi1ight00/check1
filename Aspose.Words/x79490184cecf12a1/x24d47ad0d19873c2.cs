using Aspose.Words;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x79490184cecf12a1;

internal class x24d47ad0d19873c2
{
	private x24d47ad0d19873c2()
	{
	}

	internal static void x06b0e25aa6ad68a9(x11e1346c12ead315 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3c85359e1389ad = xe134235b3526fa75.x1b1aeab2a2e668c4("http://schemas.openxmlformats.org/officeDocument/2006/relationships/comments");
		if (x3c85359e1389ad == null)
		{
			return;
		}
		while (x3c85359e1389ad.x152cbadbfa8061b1("comments"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3c85359e1389ad.xa66385d80d4d296f) != null && xa66385d80d4d296f == "comment")
			{
				x782fcf0dc01a8e96 x782fcf0dc01a8e = new x782fcf0dc01a8e96(x3c85359e1389ad);
				Comment comment = new Comment(xe134235b3526fa75.x2c8c6741422a1298, new xeedad81aaed42a76());
				((x8ad0c0863d1cd403)comment).x417a0a94031e7e8b = x782fcf0dc01a8e.xea1e81378298fa81;
				comment.Author = x782fcf0dc01a8e.xb063bbfcfeade526;
				comment.Initial = x782fcf0dc01a8e.xc085e830e777a251;
				comment.DateTime = x782fcf0dc01a8e.x197c47a24c81f695;
				xce4dd62ad1252b05.x06b0e25aa6ad68a9(xe134235b3526fa75, comment);
				xe134235b3526fa75.x2587cb0fe9d7f086(comment);
			}
			else
			{
				x3c85359e1389ad.IgnoreElement();
			}
		}
		xe134235b3526fa75.xc8ab4e294c74831b();
	}

	internal static void x25cfe591c81d3275(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		string text = x3bcd232d01c.xf3ea3ee1c9ee5265();
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			xe134235b3526fa75.x8c81feb19d9adb77(new CommentRangeStart(xe134235b3526fa75.x2c8c6741422a1298, xca004f56614e2431.x59884ab46dd0d856(text)));
		}
	}

	internal static void x3deb365a29df23e7(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		string text = x3bcd232d01c.xf3ea3ee1c9ee5265();
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			xe134235b3526fa75.x8c81feb19d9adb77(new CommentRangeEnd(xe134235b3526fa75.x2c8c6741422a1298, xca004f56614e2431.x59884ab46dd0d856(text)));
		}
	}
}
