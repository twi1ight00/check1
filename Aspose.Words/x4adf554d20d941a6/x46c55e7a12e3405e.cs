using Aspose.Words;

namespace x4adf554d20d941a6;

internal class x46c55e7a12e3405e : x16dabaa37d19a5ec
{
	internal override xc63cc34daaa2e2d9 x8b61531c8ea35b85()
	{
		return new x46c55e7a12e3405e();
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.xf2ebab1a41126d33(this);
	}

	internal static x53cb1139c5c64ee6 x38a4dfa0549b295c(x398b3bd0acd94b61 xd7e5673853e47af4, x852fe8bb5ac31098 xe3e287548b3d01f5)
	{
		if (xd7e5673853e47af4 == null)
		{
			x852fe8bb5ac31098 x852fe8bb5ac31099 = x16dabaa37d19a5ec.x5658a0bfd852524d(xe3e287548b3d01f5, StoryType.Footnotes);
			if (x852fe8bb5ac31099 == null)
			{
				return x9d810a27684d3fc1(xe3e287548b3d01f5);
			}
			xd7e5673853e47af4 = x852fe8bb5ac31099.x69d28a4aeef83a6f.x7e2e5dd40daabc3b;
		}
		if (xd7e5673853e47af4.xbc13914359462815 != null)
		{
			return (x53cb1139c5c64ee6)xd7e5673853e47af4.xbc13914359462815;
		}
		x53cb1139c5c64ee6 x53cb1139c5c64ee7 = xd7e5673853e47af4.xf34a54c031e96d83();
		if (x53cb1139c5c64ee7 != null && x53cb1139c5c64ee7.x332a8eedb847940d.x2cbc0fc707d2e1eb() == xd7e5673853e47af4.x332a8eedb847940d.x2cbc0fc707d2e1eb())
		{
			return x53cb1139c5c64ee7;
		}
		x56410a8dd70087c5 x56410a8dd70087c6 = x16dabaa37d19a5ec.x22e642b5dff41b56(xd7e5673853e47af4);
		x852fe8bb5ac31098 x852fe8bb5ac31100 = (x852fe8bb5ac31098)x56410a8dd70087c6.xce4443deee105995(x954503abc583f675.x4c38e800e85b21ad);
		while (x852fe8bb5ac31100 != null && x852fe8bb5ac31100 != xe3e287548b3d01f5.xe202d610ff4b6eca)
		{
			x56410a8dd70087c6 = x82f666dd53fed993.x8488cb14fdb73804((x56410a8dd70087c6 == null) ? x852fe8bb5ac31100.x8b8a0a04b3aeaf3a : x56410a8dd70087c6, xfedb3635e0d89070: true, StoryType.Footnotes);
			if (x56410a8dd70087c6 != null)
			{
				if (!x852fe8bb5ac31098.x018e748365f67e41(x56410a8dd70087c6))
				{
					break;
				}
				return (x53cb1139c5c64ee6)((x16dabaa37d19a5ec)x56410a8dd70087c6.x4397a67a49a78a04).xd9bfb81dd869f843();
			}
			x852fe8bb5ac31100 = x852fe8bb5ac31100.xe202d610ff4b6eca;
		}
		return null;
	}

	private static x53cb1139c5c64ee6 x9d810a27684d3fc1(x852fe8bb5ac31098 xe3e287548b3d01f5)
	{
		if (!xe3e287548b3d01f5.x3c1c340351d94fbd.xf4ffaff1fc42f255)
		{
			return null;
		}
		for (x852fe8bb5ac31098 x852fe8bb5ac31099 = xe3e287548b3d01f5.x3c1c340351d94fbd.xb78c16d5f2d4f2f7; x852fe8bb5ac31099 != null; x852fe8bb5ac31099 = x852fe8bb5ac31099.xe202d610ff4b6eca)
		{
			x92361dccfa0347fd x92361dccfa0347fd2 = x82f666dd53fed993.x6cfb41b4bd00d940(x852fe8bb5ac31099, xfedb3635e0d89070: true, StoryType.Footnotes);
			if (x92361dccfa0347fd2 != null)
			{
				if (!x852fe8bb5ac31098.x018e748365f67e41(x92361dccfa0347fd2))
				{
					break;
				}
				return x92361dccfa0347fd2.xc7597154faf074c6();
			}
			if (x852fe8bb5ac31099 == xe3e287548b3d01f5)
			{
				break;
			}
		}
		return null;
	}
}
