using System.Drawing;
using Aspose.Words.Math;
using xe5b37aee2c2a4d4e;

namespace x50d2f537cc336076;

internal class x636eee6675042602 : x3a383e6be139fbaa
{
	private x57df270da83ea6de xaea7b5e4e5ee18f5;

	private x57df270da83ea6de xf442f8ad925baa34;

	internal x636eee6675042602(OfficeMath officeMath)
		: base(officeMath)
	{
		xaea7b5e4e5ee18f5 = new x57df270da83ea6de(officeMath);
		base.x1fa9148f6731ff24(xaea7b5e4e5ee18f5);
		xf442f8ad925baa34 = new x57df270da83ea6de(officeMath);
		base.x1fa9148f6731ff24(xf442f8ad925baa34);
		x38058b386e92a0ef x38058b386e92a0ef = (x38058b386e92a0ef)officeMath.x52642f91ccdeeb35;
		xaea7b5e4e5ee18f5.x1fa9148f6731ff24(new xc1e7448c64b3a897(x38058b386e92a0ef.x067d56aec20cdd99.ToString(), officeMath.xeedad81aaed42a76, isArgument: false));
	}

	internal override void x1fa9148f6731ff24(x57df270da83ea6de x4bbc2c453c470189)
	{
		xf442f8ad925baa34.x1fa9148f6731ff24(x4bbc2c453c470189);
	}

	internal override void x62084450a0785b90()
	{
		xaea7b5e4e5ee18f5.xb7ae55095fddecd9();
		xf442f8ad925baa34.xb7ae55095fddecd9();
		RectangleF rectangleF = xaea7b5e4e5ee18f5.x6ae4612a8469678e;
		xaea7b5e4e5ee18f5.x6ae4612a8469678e = new RectangleF(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height / 8f);
		base.x43a729b39a97938d = xaea7b5e4e5ee18f5.x6ae4612a8469678e.Height + xf442f8ad925baa34.x43a729b39a97938d;
		base.x62084450a0785b90();
	}
}
