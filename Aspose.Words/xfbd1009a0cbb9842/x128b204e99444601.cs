using Aspose.Words;
using Aspose.Words.Fields;
using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class x128b204e99444601 : DocumentVisitor
{
	private string xcd243a5d7178f0b0;

	private bool x03a23ef82296e65e;

	private FieldStart xba47e1f61097ef1c;

	private FieldSeparator x92bb4db558c0603a;

	private x561fa53c007d3597 x54c413cc80cb99d5;

	internal override bool x0ee6e13d00a3931f => false;

	internal x128b204e99444601()
	{
	}

	internal static x561fa53c007d3597 x0fb4c65f43184ed5(Node xda5bf54deb817e37, string x66ac3558868cc255)
	{
		x128b204e99444601 x128b204e99444602 = new x128b204e99444601();
		x128b204e99444602.xcd243a5d7178f0b0 = x66ac3558868cc255;
		xda5bf54deb817e37.Accept(x128b204e99444602);
		return x128b204e99444602.x54c413cc80cb99d5;
	}

	public override VisitorAction VisitFieldStart(FieldStart fieldStart)
	{
		x03a23ef82296e65e = fieldStart.FieldType == FieldType.FieldMergeField;
		if (x03a23ef82296e65e)
		{
			xba47e1f61097ef1c = fieldStart;
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldSeparator(FieldSeparator fieldSeparator)
	{
		if (x03a23ef82296e65e)
		{
			x92bb4db558c0603a = fieldSeparator;
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldEnd(FieldEnd fieldEnd)
	{
		if (x03a23ef82296e65e)
		{
			x561fa53c007d3597 x561fa53c007d3598 = (x561fa53c007d3597)x3759c06a3a4cf5d1.x43fef3435fba7a66(xba47e1f61097ef1c, x92bb4db558c0603a, fieldEnd);
			if (x0d299f323d241756.x90637a473b1ceaaa(x561fa53c007d3598.xae9d2e3eea32978f, xcd243a5d7178f0b0))
			{
				x54c413cc80cb99d5 = x561fa53c007d3598;
				return VisitorAction.Stop;
			}
		}
		return VisitorAction.Continue;
	}
}
