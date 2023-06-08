using System.Collections;
using Aspose.Words;

namespace xa2462df43988ffad;

internal class x747b118e77fb5f2c
{
	private readonly Stack x5aee52a6979425f4 = new Stack();

	private bool x07eb6006c060ec01;

	private readonly x560f0e9efcf5b9b1 x6962cbeae4129aa3;

	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	internal x747b118e77fb5f2c(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
		x6962cbeae4129aa3 = new x560f0e9efcf5b9b1(x9b287b671d592594);
		x07eb6006c060ec01 = false;
	}

	internal VisitorAction x22e173d9569cebf2(Footnote x897ec71a9f9588a0)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		if (x897ec71a9f9588a0.FootnoteType == FootnoteType.Endnote && !x9b287b671d592594.xcfbb77d2d3868462)
		{
			x9b287b671d592594.xcfbb77d2d3868462 = true;
		}
		if (x897ec71a9f9588a0.ParentParagraph.xc8d1bb1390d5266d || !x9b287b671d592594.x68e1404b914783c1)
		{
			if (x9b287b671d592594.xb872fbc83a2cb9a6)
			{
				if (!x897ec71a9f9588a0.xa72bf798a679c0aa)
				{
					x6c029523e01c4f54(x897ec71a9f9588a0);
				}
				if (!x897ec71a9f9588a0.ParentParagraph.x1a78664fa10a3755.xd007a6c2c317166c)
				{
					x6962cbeae4129aa3.xaedce5725e456ac5(x897ec71a9f9588a0);
				}
			}
			else if (x9b287b671d592594.x05ee8ce4d7312eb5 != x14bf6f47128e4438.x3231bc142724c8b3)
			{
				x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
				xe1410f585439c7d.x5a3f5d78674f78e4("text:span");
				xe1410f585439c7d.x53e7651cce580e9f("text:style-name", x6962cbeae4129aa3.xfb973fa049c32c2d());
				xe1410f585439c7d.x2307058321cdb62f("text:note");
				xe1410f585439c7d.x943f6be3acf634db("text:note-class", (x897ec71a9f9588a0.FootnoteType == FootnoteType.Endnote) ? "endnote" : "footnote");
				xe1410f585439c7d.x2307058321cdb62f("text:note-citation");
				if (!x897ec71a9f9588a0.xa72bf798a679c0aa)
				{
					xe1410f585439c7d.x943f6be3acf634db("text:label", x897ec71a9f9588a0.x715a8c5c33fdc1a6);
					xe1410f585439c7d.x3d1be38abe5723e3(x897ec71a9f9588a0.x715a8c5c33fdc1a6);
				}
				xe1410f585439c7d.x2dfde153f4ef96d0("text:note-citation");
				xe1410f585439c7d.x2307058321cdb62f("text:note-body");
			}
		}
		return VisitorAction.Continue;
	}

	internal VisitorAction xd46bfa3d7ed1b78e(Footnote x897ec71a9f9588a0)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		if ((x897ec71a9f9588a0.ParentParagraph.xc8d1bb1390d5266d || !x9b287b671d592594.x68e1404b914783c1) && !x9b287b671d592594.xb872fbc83a2cb9a6 && x9b287b671d592594.x05ee8ce4d7312eb5 != x14bf6f47128e4438.x3231bc142724c8b3)
		{
			xe1410f585439c7d.x2dfde153f4ef96d0("text:note-body");
			xe1410f585439c7d.x2dfde153f4ef96d0("text:note");
			xe1410f585439c7d.xf3cbeec41f083290("text:span");
			x18e52909a31a6d9b(x897ec71a9f9588a0);
		}
		return VisitorAction.Continue;
	}

	private void x6c029523e01c4f54(Footnote x897ec71a9f9588a0)
	{
		int num = x897ec71a9f9588a0.x715a8c5c33fdc1a6.Length;
		Run run = x897ec71a9f9588a0.FirstParagraph.x38453dde2dc1ee92;
		do
		{
			if (run.x2e39a445d52f6ea8() <= num)
			{
				Run run2 = (Run)run.NextSibling;
				x5aee52a6979425f4.Push(run);
				run.Remove();
				num -= run.x2e39a445d52f6ea8();
				run = run2;
				continue;
			}
			x07eb6006c060ec01 = true;
			x5aee52a6979425f4.Push(run.Clone(isCloneChildren: false));
			run.x4ede2f7ca43a1460(num, run.x2e39a445d52f6ea8() - num, x1e2b473fecc8c6b6: false);
			break;
		}
		while (num > 0 && run != null && run.NodeType == NodeType.Run);
	}

	private void x18e52909a31a6d9b(Footnote x897ec71a9f9588a0)
	{
		Paragraph firstParagraph = x897ec71a9f9588a0.FirstParagraph;
		if (x07eb6006c060ec01)
		{
			firstParagraph.x38453dde2dc1ee92.Remove();
			x07eb6006c060ec01 = false;
		}
		while (x5aee52a6979425f4.Count > 0)
		{
			firstParagraph.InsertBefore((Run)x5aee52a6979425f4.Pop(), firstParagraph.x38453dde2dc1ee92);
		}
	}
}
