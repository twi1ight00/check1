using Aspose.Words;

namespace x13cd31bb39e0b7ea;

internal class x5f4b07d961619146
{
	internal BookmarkStart x724e8b0eb9767138;

	internal BookmarkEnd x1148fa1778bbfd56;

	internal StoryType xef137c3ef3308b94;

	internal bool xb19f31e8e085a518
	{
		get
		{
			if (x724e8b0eb9767138 != null)
			{
				return x1148fa1778bbfd56 == null;
			}
			return false;
		}
	}

	internal x5f4b07d961619146(BookmarkStart start, BookmarkEnd end, StoryType storyType)
	{
		x724e8b0eb9767138 = start;
		x1148fa1778bbfd56 = end;
		xef137c3ef3308b94 = storyType;
	}
}
