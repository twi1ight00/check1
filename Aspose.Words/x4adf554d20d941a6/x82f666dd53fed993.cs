using Aspose.Words;

namespace x4adf554d20d941a6;

internal class x82f666dd53fed993
{
	private x852fe8bb5ac31098 xccf74072a27d1bed;

	private x398b3bd0acd94b61 x9fb0e9c0b1bdc4b3;

	private readonly StoryType x476547a1677d89f7;

	private readonly bool x7954f588969b8289;

	internal x82f666dd53fed993(x852fe8bb5ac31098 column, StoryType storyType, bool forward)
	{
		xccf74072a27d1bed = column;
		if (xccf74072a27d1bed.x7149c962c02931b3)
		{
			xccf74072a27d1bed = null;
		}
		x476547a1677d89f7 = storyType;
		x7954f588969b8289 = forward;
	}

	internal x92361dccfa0347fd xbc13914359462815()
	{
		if (xccf74072a27d1bed == null)
		{
			return null;
		}
		if (x9fb0e9c0b1bdc4b3 == null)
		{
			x9fb0e9c0b1bdc4b3 = (x7954f588969b8289 ? xccf74072a27d1bed.x8b8a0a04b3aeaf3a : xccf74072a27d1bed.x7e2e5dd40daabc3b);
		}
		x9fb0e9c0b1bdc4b3 = x8488cb14fdb73804(x9fb0e9c0b1bdc4b3, x7954f588969b8289, x476547a1677d89f7);
		if (x9fb0e9c0b1bdc4b3 == null)
		{
			xccf74072a27d1bed = null;
		}
		return (x92361dccfa0347fd)x9fb0e9c0b1bdc4b3;
	}

	internal static x92361dccfa0347fd x6cfb41b4bd00d940(x852fe8bb5ac31098 xe3e287548b3d01f5, bool xfedb3635e0d89070, StoryType xdbbf47b5e620c262)
	{
		x398b3bd0acd94b61 xd7e5673853e47af = (xfedb3635e0d89070 ? xe3e287548b3d01f5.x8b8a0a04b3aeaf3a : xe3e287548b3d01f5.x7e2e5dd40daabc3b);
		return x8488cb14fdb73804(xd7e5673853e47af, xfedb3635e0d89070, xdbbf47b5e620c262);
	}

	internal static x92361dccfa0347fd x8488cb14fdb73804(x398b3bd0acd94b61 xd7e5673853e47af4, bool xfedb3635e0d89070, StoryType xdbbf47b5e620c262)
	{
		while (xd7e5673853e47af4 != null)
		{
			xd7e5673853e47af4 = x16a55dfc502896f1(x0ff79265d08e0ec8: false, xd7e5673853e47af4, xfedb3635e0d89070);
			if (xd7e5673853e47af4 is x56410a8dd70087c5 && ((x56410a8dd70087c5)xd7e5673853e47af4).xc0a853db762872fe == xdbbf47b5e620c262)
			{
				break;
			}
		}
		return (x92361dccfa0347fd)xd7e5673853e47af4;
	}

	private static x398b3bd0acd94b61 x16a55dfc502896f1(bool x0ff79265d08e0ec8, x398b3bd0acd94b61 xd7e5673853e47af4, bool xfedb3635e0d89070)
	{
		while (xd7e5673853e47af4 != null)
		{
			switch (xd7e5673853e47af4.x954503abc583f675)
			{
			case x954503abc583f675.x56410a8dd70087c5:
			{
				x56410a8dd70087c5 x56410a8dd70087c6 = (x56410a8dd70087c5)xd7e5673853e47af4;
				xd7e5673853e47af4 = x89c90554595162bc(xd7e5673853e47af4, xfedb3635e0d89070);
				if (xd7e5673853e47af4 != null)
				{
					return xd7e5673853e47af4;
				}
				x0ff79265d08e0ec8 = true;
				xd7e5673853e47af4 = x56410a8dd70087c6.x5a7799e1836857e3;
				break;
			}
			case x954503abc583f675.x48cc0c3eaf9f5f05:
			{
				xf6937c72cebe4ad1 xf6937c72cebe4ad2 = (xf6937c72cebe4ad1)xd7e5673853e47af4;
				if (x0ff79265d08e0ec8)
				{
					xd7e5673853e47af4 = x89c90554595162bc(xd7e5673853e47af4, xfedb3635e0d89070);
					if (xd7e5673853e47af4 != null)
					{
						return xd7e5673853e47af4;
					}
					xd7e5673853e47af4 = xf6937c72cebe4ad2.xc255c495fd9232ca;
					break;
				}
				xd7e5673853e47af4 = xf6937c72cebe4ad2.x0eafd527bd1e778e;
				return xd7e5673853e47af4;
			}
			case x954503abc583f675.x11db8fc7f469a2fc:
			{
				x86accec882b7012a x86accec882b7012a2 = (x86accec882b7012a)xd7e5673853e47af4;
				if (x0ff79265d08e0ec8 || x86accec882b7012a2.x7149c962c02931b3)
				{
					xd7e5673853e47af4 = x89c90554595162bc(xd7e5673853e47af4, xfedb3635e0d89070);
					if (xd7e5673853e47af4 != null)
					{
						return xd7e5673853e47af4;
					}
					x0ff79265d08e0ec8 = true;
					xd7e5673853e47af4 = x86accec882b7012a2.x798272c9805cc00e;
					break;
				}
				xd7e5673853e47af4 = x86accec882b7012a2.x8b8a0a04b3aeaf3a;
				return xd7e5673853e47af4;
			}
			case x954503abc583f675.xa19781cfbe8b4961:
			{
				x694f001896973fe3 x694f001896973fe4 = (x694f001896973fe3)xd7e5673853e47af4;
				if (x0ff79265d08e0ec8)
				{
					xd7e5673853e47af4 = x89c90554595162bc(xd7e5673853e47af4, xfedb3635e0d89070);
					if (xd7e5673853e47af4 != null)
					{
						return xd7e5673853e47af4;
					}
					xd7e5673853e47af4 = x694f001896973fe4.xc255c495fd9232ca;
					break;
				}
				xd7e5673853e47af4 = x694f001896973fe4.x96ac59f61797f5b9;
				return xd7e5673853e47af4;
			}
			default:
				xd7e5673853e47af4 = null;
				return xd7e5673853e47af4;
			}
		}
		return xd7e5673853e47af4;
	}

	private static x398b3bd0acd94b61 x89c90554595162bc(x398b3bd0acd94b61 xd7e5673853e47af4, bool xfedb3635e0d89070)
	{
		if (!xfedb3635e0d89070)
		{
			return xd7e5673853e47af4.x9b2bbd3d05bf558b();
		}
		return xd7e5673853e47af4.xf432ece93e450408();
	}
}
