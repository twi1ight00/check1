using Aspose.Words;

namespace x4adf554d20d941a6;

internal class x577d2faf9a871f11 : x61ebdec02c254c25
{
	private StoryType xdd60879a1545b649;

	private readonly Node x48154453a08515ea;

	internal override StoryType xc0a853db762872fe => xdd60879a1545b649;

	internal override int x1be93eed8950d961 => 1;

	internal override string xf9ad6fb78355fe13
	{
		get
		{
			if ((xc0a853db762872fe == StoryType.Footnotes || xc0a853db762872fe == StoryType.Endnotes) && base.x406d8cd2af514771 != null)
			{
				x16dabaa37d19a5ec x16dabaa37d19a5ec2 = (x16dabaa37d19a5ec)base.x406d8cd2af514771.x2cbc0fc707d2e1eb();
				return x16dabaa37d19a5ec2.x465c7a263669f01c.xf9ad6fb78355fe13;
			}
			return " ";
		}
	}

	internal override xfc6971c7d8314663 xfc6971c7d8314663 => xfc6971c7d8314663.xf9ad6fb78355fe13;

	internal x577d2faf9a871f11(Node node)
		: base(9217)
	{
		x48154453a08515ea = node;
		node = node.GetAncestor(typeof(InlineStory));
		if (node != null)
		{
			switch (node.NodeType)
			{
			case NodeType.Comment:
				xdd60879a1545b649 = StoryType.Comments;
				break;
			case NodeType.Footnote:
				xdd60879a1545b649 = ((((Footnote)node).FootnoteType == FootnoteType.Footnote) ? StoryType.Footnotes : StoryType.Endnotes);
				break;
			}
		}
	}

	internal override x56410a8dd70087c5 xa9d7e8f6fbdcbcfc(x56410a8dd70087c5 x7d95d971d8923f4c)
	{
		if (x7d95d971d8923f4c == null)
		{
			x7d95d971d8923f4c = new x577d2faf9a871f11(x48154453a08515ea);
		}
		return base.xa9d7e8f6fbdcbcfc(x7d95d971d8923f4c);
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.xbaa0389de569feaa(this);
	}
}
