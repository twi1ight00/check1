using System;
using Aspose.Words;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class x41ac54db4e627dea : x56410a8dd70087c5
{
	private x2c0c9a4fb5b11521 xf95de5a195630ab1;

	private int x8cf825d90be23d37;

	private bool x23aac209972248ac;

	internal override int x5566e2d2acbd1fbe
	{
		get
		{
			if (x4adf554d20d941a6.x5566e2d2acbd1fbe.xd707791130626739(x8cf825d90be23d37) && base.x406d8cd2af514771 != null)
			{
				xe0e644109215bf44 xe0e644109215bf45 = base.x406d8cd2af514771.x2cbc0fc707d2e1eb();
				if (xe0e644109215bf45.x876bae1be4c51fa1.xf684fc5abe7ca67a && xe0e644109215bf45.x185a13a95379e46d != null && xe0e644109215bf45.x185a13a95379e46d.x705ed5f9769744e5 != null)
				{
					switch (((xacf1bb6be5092987)xe0e644109215bf45.x185a13a95379e46d.x705ed5f9769744e5).xe95664527db59e6e)
					{
					case SectionStart.Continuous:
						x8cf825d90be23d37 = 21858;
						break;
					case SectionStart.EvenPage:
						x8cf825d90be23d37 = 21860;
						break;
					case SectionStart.OddPage:
						x8cf825d90be23d37 = 21859;
						break;
					case SectionStart.NewColumn:
						x8cf825d90be23d37 = 21861;
						break;
					default:
						x8cf825d90be23d37 = 21857;
						break;
					}
				}
			}
			else if (!x23aac209972248ac && base.x00fa20d37841acd0 && 21788 == x8cf825d90be23d37)
			{
				if (x53111d6596d16a99.xf684fc5abe7ca67a && base.x772764427592d4bb <= 0 && !((x7c5d33e87d9dfc05)x53111d6596d16a99).xde015839cc88f18d.xe282e10565485d24 && (!base.x332a8eedb847940d.x55b6066f30988caf || !base.x332a8eedb847940d.x332a8eedb847940d.x55b6066f30988caf))
				{
					x56410a8dd70087c5 x56410a8dd70087c6 = xf0b374f4c0172a4c.x57b3c9e650685d36(base.x61712f0b4f5455af, base.x61712f0b4f5455af, null, xa17853d20c8c42bd: true, x4d2b4f056cf5bb8b: false);
					if (x4adf554d20d941a6.x5566e2d2acbd1fbe.x8197188ddb6f93d3(x56410a8dd70087c6.x5566e2d2acbd1fbe))
					{
						x8cf825d90be23d37 = 10528;
					}
				}
				x23aac209972248ac = true;
			}
			return x8cf825d90be23d37;
		}
	}

	internal override int x1be93eed8950d961
	{
		get
		{
			if (!base.x4e1234ca2b87020b)
			{
				return 1;
			}
			return 0;
		}
	}

	internal override string xf9ad6fb78355fe13 => x11fb62a1209fa95d(x5566e2d2acbd1fbe);

	internal override int x887b872a95caaab5
	{
		get
		{
			if (x5566e2d2acbd1fbe == 10528)
			{
				return x4574ea26106f0edb.x8d50b8a62ba1cd84(144.0);
			}
			if (x4adf554d20d941a6.x5566e2d2acbd1fbe.x80b95148e8799434(x5566e2d2acbd1fbe))
			{
				if (xc255c495fd9232ca == null || !xc255c495fd9232ca.xe5764fe5359a6d91)
				{
					return 0;
				}
				return xc255c495fd9232ca.xdc1bf80853046136 - x8df91a2f90079e88;
			}
			return base.x887b872a95caaab5;
		}
	}

	internal override x2c0c9a4fb5b11521 x2c0c9a4fb5b11521
	{
		get
		{
			if (xf95de5a195630ab1 == null && x4adf554d20d941a6.x5566e2d2acbd1fbe.x74f5d3c8c1c169b6(x5566e2d2acbd1fbe))
			{
				xf95de5a195630ab1 = new x2c0c9a4fb5b11521();
			}
			return xf95de5a195630ab1;
		}
		set
		{
			xf95de5a195630ab1 = value;
		}
	}

	internal x41ac54db4e627dea(int spanType)
	{
		x8cf825d90be23d37 = spanType;
	}

	internal override x56410a8dd70087c5 xa9d7e8f6fbdcbcfc(x56410a8dd70087c5 x7d95d971d8923f4c)
	{
		if (x7d95d971d8923f4c == null)
		{
			x7d95d971d8923f4c = new x41ac54db4e627dea(x5566e2d2acbd1fbe);
		}
		return base.xa9d7e8f6fbdcbcfc(x7d95d971d8923f4c);
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x1e43fb97a6a16567(this);
	}

	internal void xf9f24914e9799bf9(x41ac54db4e627dea xee918fe23aa431e7)
	{
		xee918fe23aa431e7.xc02a1028e62dfaf7 = base.xc02a1028e62dfaf7;
		xee918fe23aa431e7.xa70fedcedcd0e1da = base.xa70fedcedcd0e1da;
		xee918fe23aa431e7.xf95de5a195630ab1 = xf95de5a195630ab1;
		base.xc02a1028e62dfaf7 = null;
		base.xa70fedcedcd0e1da = null;
		x2c0c9a4fb5b11521 = null;
		x8cf825d90be23d37 = 21537;
		xee918fe23aa431e7.x8cf825d90be23d37 = 21639;
	}

	internal bool x53182140cf4abbfb()
	{
		if (x5566e2d2acbd1fbe != 21577)
		{
			return false;
		}
		if (x2c8c6741422a1298.xdeb77ea37ad74c56.x0524267b51e1f4ba)
		{
			return false;
		}
		if (base.x406d8cd2af514771 == null || base.x406d8cd2af514771.x332a8eedb847940d == null)
		{
			return false;
		}
		x56b4eac69b5fa65b x56b4eac69b5fa65b2 = (x56b4eac69b5fa65b)base.x406d8cd2af514771.x332a8eedb847940d;
		return x56b4eac69b5fa65b2.xdfd0c9de0b4aa96a.xb95bfd90edcd1f61;
	}

	private static string x11fb62a1209fa95d(int x5620391b595d8955)
	{
		switch (x5620391b595d8955)
		{
		case 21514:
			return "\uf038";
		case 21513:
			return "↔";
		case 21537:
		case 21639:
			return "¶";
		case 21857:
			return "Section Break (Next Page)";
		case 21858:
			return "Section Break (Continuous)";
		case 21860:
			return "Section Break (Even Page)";
		case 21859:
			return "Section Break (Odd Page)";
		case 21861:
			return "Section Break (Next Column)";
		case 21779:
			return "Column Break";
		case 10528:
		case 21788:
			return "Page Break";
		case 21577:
		case 21586:
		case 21595:
			return "¤";
		default:
			throw new InvalidOperationException();
		}
	}
}
