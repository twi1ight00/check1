using System;
using Aspose.Words;
using x13f1efc79617a47b;
using x4adf554d20d941a6;

namespace x59d6a4fc5007b7a4;

internal class x151a606008e93e1b
{
	private readonly x41ac54db4e627dea[] x5e5f0881d80041e9 = new x41ac54db4e627dea[3] { x9a80dc14ff00b2ea, x9a80dc14ff00b2ea, x9a80dc14ff00b2ea };

	private x56410a8dd70087c5 x749f8493ad444bdb;

	private static readonly x41ac54db4e627dea x9a80dc14ff00b2ea = new x41ac54db4e627dea(21514);

	internal x151a606008e93e1b(x56410a8dd70087c5 first)
	{
		x749f8493ad444bdb = first;
		if (x749f8493ad444bdb == null)
		{
			for (int i = 0; i < x5e5f0881d80041e9.Length; i++)
			{
				x5e5f0881d80041e9[i] = null;
			}
		}
	}

	internal x41ac54db4e627dea xda0d8384ac6ee2cb(StoryType xdbbf47b5e620c262, x61ebdec02c254c25 xde1b8035b3bfcdec)
	{
		int num = x5251d7421d3a8ac1(xdbbf47b5e620c262);
		x41ac54db4e627dea x41ac54db4e627dea = x5e5f0881d80041e9[num];
		if (x41ac54db4e627dea == x9a80dc14ff00b2ea)
		{
			x41ac54db4e627dea = x721de5c630aa50a1(xdbbf47b5e620c262, xde1b8035b3bfcdec);
			x5e5f0881d80041e9[num] = x41ac54db4e627dea;
		}
		return x41ac54db4e627dea;
	}

	internal void x16e153a4334eabbe(StoryType xdbbf47b5e620c262, x41ac54db4e627dea xd9ff4dee1dba180e)
	{
		int num = x5251d7421d3a8ac1(xdbbf47b5e620c262);
		x5e5f0881d80041e9[num] = xd9ff4dee1dba180e;
	}

	private x41ac54db4e627dea x721de5c630aa50a1(StoryType xdbbf47b5e620c262, x61ebdec02c254c25 xde1b8035b3bfcdec)
	{
		x56410a8dd70087c5 xf377779f33c1c51a = xde1b8035b3bfcdec;
		if (xde1b8035b3bfcdec.x53111d6596d16a99 == null)
		{
			xac6c82c74ce247fb xac6c82c74ce247fb = x749f8493ad444bdb.x2c8c6741422a1298.xe5cdc2a3cec80364(xdbbf47b5e620c262, x5aa7d09b258e0f23: false);
			if (xac6c82c74ce247fb == null || xac6c82c74ce247fb.xb3a79d506b0e2f7f.xd44988f225497f3a <= 0)
			{
				return null;
			}
			if (x749f8493ad444bdb.xc0a853db762872fe == xdbbf47b5e620c262)
			{
				return (x41ac54db4e627dea)x749f8493ad444bdb.x897301f2e0967b6d;
			}
			xf377779f33c1c51a = x749f8493ad444bdb;
		}
		xf3f447691ab38eee xf3f447691ab38eee = x749f8493ad444bdb.x2c8c6741422a1298.x80f061859cd048ae.xb3a79d506b0e2f7f.x8b61531c8ea35b85();
		if (!xf3f447691ab38eee.xd8b11076ff837685(xf377779f33c1c51a))
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("celpnfcahgjaegabcghbegobnafchfmcgfddkfkdgebemaie", 1634663167)));
		}
		while (xf3f447691ab38eee.x355eaee82ffc1f46())
		{
			x56410a8dd70087c5 x56410a8dd70087c = (x56410a8dd70087c5)xf3f447691ab38eee.x35cfcea4890f4e7d;
			if (x56410a8dd70087c.xc0a853db762872fe == xdbbf47b5e620c262)
			{
				x56410a8dd70087c = x56410a8dd70087c.x897301f2e0967b6d;
				return (x41ac54db4e627dea)x56410a8dd70087c;
			}
		}
		return null;
	}

	private static int x5251d7421d3a8ac1(StoryType xdbbf47b5e620c262)
	{
		switch (xdbbf47b5e620c262)
		{
		case StoryType.Footnotes:
		case StoryType.Endnotes:
		case StoryType.Comments:
			return (int)(xdbbf47b5e620c262 - 2);
		default:
			throw new ArgumentOutOfRangeException("storyType");
		}
	}
}
