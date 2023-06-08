using Aspose.Words;
using x5794c252ba25e723;
using x59d6a4fc5007b7a4;
using x6a42c37b95e9caa1;

namespace xb3b3ff3836e35ac5;

internal class x54afa1405121518f
{
	private readonly xe6a5f3ec802a6d51 x8cedcaa9a62c6e39;

	private x0e71d075aa348d2b xaf527a0785431d41;

	private x038d2057eb729fcf xd4f244e3b3c8a426;

	internal x54afa1405121518f(xe6a5f3ec802a6d51 context)
	{
		x8cedcaa9a62c6e39 = context;
	}

	private x26d9ecb4bdf0456d x60b5e6ebeec2964c(Font x26094932cf7a9139)
	{
		x26d9ecb4bdf0456d x99907b37201c7b = x26094932cf7a9139.x99907b37201c7b19;
		if (!x99907b37201c7b.x7149c962c02931b3)
		{
			return x99907b37201c7b;
		}
		return x8cedcaa9a62c6e39.xa6dfa2703204e9f0(x26094932cf7a9139.x63b1a7c31a962459);
	}

	internal void x1a432fbdc290755d(x038d2057eb729fcf x5906905c888d3d98)
	{
		xd4f244e3b3c8a426 = x5906905c888d3d98;
		if (xaf527a0785431d41 == null)
		{
			if (x5906905c888d3d98.xd4933b722e704dcd || x5906905c888d3d98.xc2d4efc42998d87b.Hidden)
			{
				xaf527a0785431d41 = new x0e71d075aa348d2b(x5906905c888d3d98, x60b5e6ebeec2964c(x5906905c888d3d98.xc2d4efc42998d87b));
			}
		}
		else
		{
			x26d9ecb4bdf0456d x26d9ecb4bdf0456d = x60b5e6ebeec2964c(x5906905c888d3d98.xc2d4efc42998d87b);
			if (xaf527a0785431d41.x823021dd17f3ec66(x5906905c888d3d98) || (!x5906905c888d3d98.xc2d4efc42998d87b.Hidden && !x5906905c888d3d98.xd4933b722e704dcd))
			{
				xaf527a0785431d41.xe406325e56f74b46(x5906905c888d3d98, xf7b442ce3fc67ee7: false, x8cedcaa9a62c6e39);
				xaf527a0785431d41 = (x5906905c888d3d98.xd4933b722e704dcd ? new x0e71d075aa348d2b(x5906905c888d3d98, x26d9ecb4bdf0456d) : null);
			}
			else if (xaf527a0785431d41.x04dee9c3c9004d60(x5906905c888d3d98, x26d9ecb4bdf0456d))
			{
				xaf527a0785431d41.x4f4ae086f5e6747b(x5906905c888d3d98, xf7b442ce3fc67ee7: false);
				xaf527a0785431d41.xf94f66c79b1b75b8(x5906905c888d3d98, x26d9ecb4bdf0456d);
			}
		}
		if (xaf527a0785431d41 != null)
		{
			xaf527a0785431d41.x794f16de9842a7a0(x5906905c888d3d98);
		}
	}

	internal void x8fff2b286601b9d6()
	{
		if (xaf527a0785431d41 != null)
		{
			xaf527a0785431d41.xe406325e56f74b46(xd4f244e3b3c8a426, xd4f244e3b3c8a426.xd4933b722e704dcd || xd4f244e3b3c8a426.xc2d4efc42998d87b.Hidden, x8cedcaa9a62c6e39);
			xaf527a0785431d41 = null;
		}
	}

	internal static bool x96da6d2dd3acd14b(Underline x5be89112f1b625bc)
	{
		if (x5be89112f1b625bc != Underline.Single)
		{
			return x5be89112f1b625bc == Underline.Words;
		}
		return true;
	}

	internal static bool x4f0ec65105795df7(Underline x5be89112f1b625bc)
	{
		if (x5be89112f1b625bc != Underline.Double)
		{
			return x5be89112f1b625bc == Underline.WavyDouble;
		}
		return true;
	}

	internal static bool x71d8c5d812438589(Underline x5be89112f1b625bc)
	{
		switch (x5be89112f1b625bc)
		{
		case Underline.Thick:
		case Underline.DottedHeavy:
		case Underline.DashHeavy:
		case Underline.DotDashHeavy:
		case Underline.DotDotDashHeavy:
		case Underline.WavyHeavy:
		case Underline.DashLongHeavy:
			return true;
		default:
			return false;
		}
	}

	internal static bool x5b7e2f4dd312775f(Underline x5be89112f1b625bc)
	{
		if (x5be89112f1b625bc == Underline.Wavy || x5be89112f1b625bc == Underline.WavyHeavy || x5be89112f1b625bc == Underline.WavyDouble)
		{
			return true;
		}
		return false;
	}
}
