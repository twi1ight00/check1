using Aspose.Words;

namespace x4adf554d20d941a6;

internal class x41744f5ec654abee : x78752dd11b777af5
{
	internal override x954503abc583f675 x954503abc583f675 => x954503abc583f675.x69d28a4aeef83a6f;

	internal override int xdc1bf80853046136 => xc255c495fd9232ca.xdc1bf80853046136;

	internal override int x8df91a2f90079e88 => 0;

	internal override int xc821290d7ecc08bf
	{
		get
		{
			x852fe8bb5ac31098 x852fe8bb5ac31099 = (x852fe8bb5ac31098)xc255c495fd9232ca;
			if (x852fe8bb5ac31099.x3c1c340351d94fbd.xf48cd6e82340ac70.xd9248a16053b5d85 != FootnoteLocation.BottomOfPage)
			{
				return x852fe8bb5ac31099.xbcd477821fdbd81b;
			}
			return x852fe8bb5ac31099.xb0f146032f47c24e - xb0f146032f47c24e;
		}
	}

	protected override StoryType SeparatorStoryType => StoryType.FootnoteSeparator;

	protected override StoryType ContinuationSeparatorStoryType => StoryType.FootnoteContinuationSeparator;

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x2921298d520200e7(this);
	}

	internal override x1073233de8252b3e xfaf767ebc9bc84a6()
	{
		x852fe8bb5ac31098 x852fe8bb5ac31099 = (x852fe8bb5ac31098)xc255c495fd9232ca;
		x852fe8bb5ac31099 = ((x852fe8bb5ac31099.x55b6066f30988caf || x852fe8bb5ac31099.xe202d610ff4b6eca.x69d28a4aeef83a6f != null) ? ((x852fe8bb5ac31098)x852fe8bb5ac31099.xfaf767ebc9bc84a6()) : x852fe8bb5ac31099.xe202d610ff4b6eca);
		return base.x60c79c2c8163b21e.x6160b752f2880dec(x852fe8bb5ac31099, x502d59bacbd3e16e: true);
	}

	protected override bool GetIsContinuation()
	{
		return x0400bed985889ee9.x7639fcb6e869dccc((x852fe8bb5ac31098)xc255c495fd9232ca);
	}
}
