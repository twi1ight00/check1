using System;
using System.Drawing;
using Aspose.Words.Drawing;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;
using x996431aaaaf00543;

namespace x3d94286fe72124a8;

internal class x73d966e39902908a
{
	private readonly x54b98d0096d7251a xa056586c1f99e199;

	internal x73d966e39902908a(x54b98d0096d7251a warningCallback)
	{
		xa056586c1f99e199 = warningCallback;
	}

	internal x2fca56c11bd20653 xe406325e56f74b46(x7721ad963b03c6eb xa3d15e542708d37f)
	{
		DrawingML x9345853531733647 = xa3d15e542708d37f.x9345853531733647;
		if (x9345853531733647 == null)
		{
			throw new ArgumentException("DmlShape");
		}
		x3064c6a807d3a0a8 x3064c6a807d3a0a = new x3064c6a807d3a0a8(x9345853531733647.xcedd71bf2230b51f, x9345853531733647.xaf782602efcbdda1(), xa056586c1f99e199);
		xe56ce0e761e4e9ea xe56ce0e761e4e9ea = x3064c6a807d3a0a.x5b81632e5b71b64c(x9345853531733647.xb327816528e8798b, x9345853531733647.Size, x56ef2519e07fdbb4.x560cf35c28bc5a84);
		if (xe56ce0e761e4e9ea != null)
		{
			if (xa3d15e542708d37f.x2edb8efcf734419a != null)
			{
				xa3d15e542708d37f.x2edb8efcf734419a.x9bc00449bdfc1e1e(xe56ce0e761e4e9ea.xa1eafe7821eb4aab, xe56ce0e761e4e9ea.x2727839aafc09868);
			}
			xdf3c9fa4d48100a3.x757450d4e4eec6d0(xe56ce0e761e4e9ea.xa1eafe7821eb4aab);
			if (xa3d15e542708d37f.x2edb8efcf734419a != null && x9345853531733647.Document.xe4ccd3ec7bc99ea4)
			{
				xe56ce0e761e4e9ea.xa1eafe7821eb4aab.xd6b6ed77479ef68c(xa3d15e542708d37f.x2edb8efcf734419a.x83dd92921f575263);
			}
			return new x2fca56c11bd20653(xe56ce0e761e4e9ea);
		}
		return new x2fca56c11bd20653(new xb8e7e788f6d59708(), RectangleF.Empty);
	}
}
