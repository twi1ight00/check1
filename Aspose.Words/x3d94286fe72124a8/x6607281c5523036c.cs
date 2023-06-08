using Aspose;
using x1c8faa688b1f0b0c;

namespace x3d94286fe72124a8;

internal class x6607281c5523036c : xf51865b83a7a0b3b
{
	private xab391c46ff9a0a38 xf34ef61ecae1eb73;

	private x1cab6af0a41b70e2 xb5c5edea9f40a9ab;

	[JavaConvertCheckedExceptions]
	internal xab391c46ff9a0a38 xe94da055c1b9a188(xab391c46ff9a0a38 xe125219852864557, bool x2b818897b65c872e, bool xdb73611e5c07ce94)
	{
		xf34ef61ecae1eb73 = new xab391c46ff9a0a38();
		xe125219852864557.Accept(this);
		xf34ef61ecae1eb73.x9e5d5f9128c69a8f = (x2b818897b65c872e ? xe125219852864557.x9e5d5f9128c69a8f : null);
		xf34ef61ecae1eb73.x60465f602599d327 = (xdb73611e5c07ce94 ? xe125219852864557.x60465f602599d327 : null);
		return xf34ef61ecae1eb73;
	}

	public override void VisitPathFigureStart(x1cab6af0a41b70e2 pathFigure)
	{
		xb5c5edea9f40a9ab = new x1cab6af0a41b70e2();
		xb5c5edea9f40a9ab.x5e6c52cb3256cc85 = pathFigure.x5e6c52cb3256cc85;
		xf34ef61ecae1eb73.xd6b6ed77479ef68c(xb5c5edea9f40a9ab);
	}

	public override void VisitPolyLineSegment(x60c040f35bb272aa segment)
	{
		x60c040f35bb272aa x60c040f35bb272aa = new x60c040f35bb272aa();
		x60c040f35bb272aa.x4d7474e8f1849803.AddRange(segment.x4d7474e8f1849803);
		xb5c5edea9f40a9ab.xd6b6ed77479ef68c(x60c040f35bb272aa);
	}

	public override void VisitBezierSegment(x519b1bd0625473ff segment)
	{
		x519b1bd0625473ff xda5bf54deb817e = new x519b1bd0625473ff(segment.x56b911bdb6515aed);
		xb5c5edea9f40a9ab.xd6b6ed77479ef68c(xda5bf54deb817e);
	}
}
