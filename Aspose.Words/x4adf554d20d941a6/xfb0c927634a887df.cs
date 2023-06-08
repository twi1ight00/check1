using System;
using Aspose.Words;

namespace x4adf554d20d941a6;

internal class xfb0c927634a887df : x61ebdec02c254c25
{
	private x06e41c15cb47ffad x4517c2b411ea1d52;

	private xe0e644109215bf44 x5711ab82d2ac48d0;

	internal override int x1be93eed8950d961 => 0;

	internal override bool x1b4884baf08c8d62 => true;

	internal override StoryType xc0a853db762872fe => StoryType.Comments;

	internal override x6e414db5d060a816 x6e414db5d060a816 => x4517c2b411ea1d52.x8d113e0298810713(this);

	internal override xe0e644109215bf44 x4397a67a49a78a04
	{
		get
		{
			if (x5711ab82d2ac48d0 == null && base.x332a8eedb847940d != null)
			{
				x5711ab82d2ac48d0 = base.x897301f2e0967b6d.x332a8eedb847940d.x2cbc0fc707d2e1eb();
			}
			return x5711ab82d2ac48d0;
		}
		set
		{
			x5711ab82d2ac48d0 = value;
		}
	}

	internal string xc085e830e777a251 => x4517c2b411ea1d52.xc085e830e777a251;

	internal xfb0c927634a887df x9a05d8dab0f0619f => x4517c2b411ea1d52.x9a05d8dab0f0619f;

	internal xfb0c927634a887df x70ff891026cb8704 => x4517c2b411ea1d52.x70ff891026cb8704;

	internal xfb0c927634a887df x69168101f53809d2 => x4517c2b411ea1d52.x69168101f53809d2;

	internal x06e41c15cb47ffad x7d2e50686d249839
	{
		get
		{
			return x4517c2b411ea1d52;
		}
		set
		{
			x4517c2b411ea1d52 = value;
		}
	}

	internal xfb0c927634a887df()
		: base(0)
	{
	}

	internal override x56410a8dd70087c5 xa9d7e8f6fbdcbcfc(x56410a8dd70087c5 x7d95d971d8923f4c)
	{
		throw new InvalidOperationException("Deep clone SpanComment is forbidden.");
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.xee120aeffd41a02f(this);
	}
}
