using Aspose.Words;

namespace x4adf554d20d941a6;

internal class xd37fbb663b35a9f2 : x78752dd11b777af5
{
	internal override x954503abc583f675 x954503abc583f675 => x954503abc583f675.xd90ac7fcbe961761;

	internal override int x8df91a2f90079e88 => 0;

	internal override int xc821290d7ecc08bf
	{
		get
		{
			x852fe8bb5ac31098 x852fe8bb5ac31099 = (x852fe8bb5ac31098)xc255c495fd9232ca;
			if (x852fe8bb5ac31099.x69d28a4aeef83a6f != null && x852fe8bb5ac31099.x3c1c340351d94fbd.xf48cd6e82340ac70.xd9248a16053b5d85 != FootnoteLocation.BottomOfPage)
			{
				return x852fe8bb5ac31099.x69d28a4aeef83a6f.x9bcb07e204e30218;
			}
			return x852fe8bb5ac31099.xbcd477821fdbd81b;
		}
	}

	internal override int xdc1bf80853046136 => xc255c495fd9232ca.xdc1bf80853046136;

	protected override StoryType SeparatorStoryType => StoryType.EndnoteSeparator;

	protected override StoryType ContinuationSeparatorStoryType => StoryType.EndnoteContinuationSeparator;

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.xd8e34bc6cc40f5a6(this);
	}

	internal override x1073233de8252b3e xfaf767ebc9bc84a6()
	{
		x852fe8bb5ac31098 x852fe8bb5ac31099 = (x852fe8bb5ac31098)xc255c495fd9232ca;
		x852fe8bb5ac31098 x852fe8bb5ac31100 = x852fe8bb5ac31099.x4eca8015611fb7a9();
		x852fe8bb5ac31099 = ((x852fe8bb5ac31099.x4386483402206b24 || x852fe8bb5ac31100.xd90ac7fcbe961761 != null) ? ((x852fe8bb5ac31098)x852fe8bb5ac31099.xfaf767ebc9bc84a6()) : x852fe8bb5ac31100);
		return base.x60c79c2c8163b21e.x6160b752f2880dec(x852fe8bb5ac31099, x502d59bacbd3e16e: true);
	}

	protected override bool GetIsContinuation()
	{
		if (base.xeb2f651eb0d22a2c == null)
		{
			return false;
		}
		xe0e644109215bf44 xe0e644109215bf45 = xc255c495fd9232ca.x332a8eedb847940d.x2cbc0fc707d2e1eb();
		xe0e644109215bf44 xe0e644109215bf46 = base.xeb2f651eb0d22a2c.xc255c495fd9232ca.x332a8eedb847940d.x2cbc0fc707d2e1eb();
		return xe0e644109215bf45 == xe0e644109215bf46;
	}
}
