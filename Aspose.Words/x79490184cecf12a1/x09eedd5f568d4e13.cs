using Aspose.Words;
using x1495530f35d79681;

namespace x79490184cecf12a1;

internal class x09eedd5f568d4e13
{
	private x09eedd5f568d4e13()
	{
	}

	internal static void xcaea02fd4d5f83c6(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x782fcf0dc01a8e96 x782fcf0dc01a8e = new x782fcf0dc01a8e96(x3bcd232d01c);
		if (x782fcf0dc01a8e.xbd2068db29af7264)
		{
			xe134235b3526fa75.x02e97468984a6dfa[x782fcf0dc01a8e.xea1e81378298fa81] = x782fcf0dc01a8e.x759aa16c2016a289;
			BookmarkStart bookmarkStart = new BookmarkStart(xe134235b3526fa75.x2c8c6741422a1298, x782fcf0dc01a8e.x759aa16c2016a289);
			if (x782fcf0dc01a8e.x6aaf4d9b15644fca >= 0 && x782fcf0dc01a8e.x188288b446f5fc96 >= 0)
			{
				bookmarkStart.xb78c16d5f2d4f2f7 = x782fcf0dc01a8e.x6aaf4d9b15644fca;
				bookmarkStart.x279da4adfba57f2d = x782fcf0dc01a8e.x188288b446f5fc96 + 1;
			}
			xe134235b3526fa75.x8c81feb19d9adb77(bookmarkStart);
		}
	}

	internal static void x24deddd4c9b86ffd(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x782fcf0dc01a8e96 x782fcf0dc01a8e = new x782fcf0dc01a8e96(x3bcd232d01c);
		if (x782fcf0dc01a8e.xbd2068db29af7264)
		{
			string text = (string)xe134235b3526fa75.x02e97468984a6dfa[x782fcf0dc01a8e.xea1e81378298fa81];
			if (text != null)
			{
				BookmarkEnd xda5bf54deb817e = new BookmarkEnd(xe134235b3526fa75.x2c8c6741422a1298, text);
				xe134235b3526fa75.x8c81feb19d9adb77(xda5bf54deb817e);
				xe134235b3526fa75.x02e97468984a6dfa.Remove(x782fcf0dc01a8e.xea1e81378298fa81);
			}
		}
	}
}
