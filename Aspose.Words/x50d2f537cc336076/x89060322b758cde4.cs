using System;
using Aspose.Words.Math;
using xe5b37aee2c2a4d4e;

namespace x50d2f537cc336076;

internal class x89060322b758cde4 : xe22a4a9a14e524d7
{
	private x57df270da83ea6de x54a536b20d907080;

	private x57df270da83ea6de xc85e307a6cea2ab5;

	internal x89060322b758cde4(OfficeMath officeMath)
		: base(officeMath, 2)
	{
		x54a536b20d907080 = new x57df270da83ea6de(officeMath);
		xc85e307a6cea2ab5 = new x57df270da83ea6de(officeMath);
		x1dfdb69b4a79e67d x1dfdb69b4a79e67d2 = new x1dfdb69b4a79e67d(this, officeMath);
		x1dfdb69b4a79e67d2.x1fa9148f6731ff24(x54a536b20d907080);
		x1dfdb69b4a79e67d2.x1fa9148f6731ff24(xc85e307a6cea2ab5);
		base.x1fa9148f6731ff24(x1dfdb69b4a79e67d2);
		base.x79e0368f9606a712 = (float)officeMath.xeedad81aaed42a76.x437e3b626c0fdd43 / 5f;
	}

	internal override void x1fa9148f6731ff24(x57df270da83ea6de x4bbc2c453c470189)
	{
		switch (x4bbc2c453c470189.xc48e358ce4f81353.x52642f91ccdeeb35.x3e68720d12325f49)
		{
		case x3e68720d12325f49.x8c55fc884c93cb9f:
			x54a536b20d907080.x1fa9148f6731ff24(x4bbc2c453c470189);
			break;
		case x3e68720d12325f49.x1745ba6c6d5efbc4:
			xc85e307a6cea2ab5.x1fa9148f6731ff24(x4bbc2c453c470189);
			break;
		default:
			throw new ArgumentException("Function element can have only function name and argument parts.");
		}
	}

	internal override void xb7ae55095fddecd9()
	{
		base.xb7ae55095fddecd9();
		base.x43a729b39a97938d = ((x57df270da83ea6de)base.xf2453c298c5de6f5[0]).x43a729b39a97938d;
	}
}
