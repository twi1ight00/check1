using System.Collections;
using System.Drawing;
using Aspose;
using x1c8faa688b1f0b0c;

namespace x5794c252ba25e723;

internal class x05ce44fc24c6c129 : x2f90c0cfb1f8b01a
{
	private xab391c46ff9a0a38 xe94216196e5d19b4;

	private ArrayList x96f881195fd151e8;

	private x630b5fb239bb4657 x8ef4eecf6b1d65ec;

	private Stack x458c29076aeca30a = new Stack();

	private x630b5fb239bb4657 xc81bcaf1d1c33511;

	public xab391c46ff9a0a38 x0fafce58eb0494ae
	{
		get
		{
			if (xe94216196e5d19b4 == null)
			{
				return new xab391c46ff9a0a38();
			}
			return xe94216196e5d19b4;
		}
	}

	public x05ce44fc24c6c129(x630b5fb239bb4657 projectionMatrix)
	{
		x8ef4eecf6b1d65ec = projectionMatrix;
	}

	[JavaThrows(true)]
	public override void VisitShapeStart(xc7dff27f851c3f9b shape)
	{
		xe94216196e5d19b4 = new xab391c46ff9a0a38();
		x561b05f57e5b3cc1(shape.x52dde376accdec7d);
	}

	[JavaThrows(true)]
	public override void VisitShapeEnd(xc7dff27f851c3f9b shape)
	{
		x53d51f48095083cd();
	}

	[JavaThrows(true)]
	public override void VisitFaceStart(xd2cff41fae766733 face)
	{
		x96f881195fd151e8 = new ArrayList();
		x630b5fb239bb4657 x470ecea91abfd1aa = (x630b5fb239bb4657)x458c29076aeca30a.Peek();
		xc81bcaf1d1c33511 = ((face.x52dde376accdec7d != null) ? face.x52dde376accdec7d.x8b61531c8ea35b85() : new x630b5fb239bb4657());
		xc81bcaf1d1c33511.x2262d45deed5f60d(x470ecea91abfd1aa);
		xc81bcaf1d1c33511.x2262d45deed5f60d(x8ef4eecf6b1d65ec);
	}

	[JavaThrows(true)]
	public override void VisitFaceEnd(xd2cff41fae766733 face)
	{
		xe94216196e5d19b4.xd6b6ed77479ef68c(x1cab6af0a41b70e2.xa7b580afa8756d69((PointF[])x96f881195fd151e8.ToArray(typeof(PointF)), x7a848427f2a9a3b5: true));
	}

	[JavaThrows(true)]
	public override void VisitPoint(xa010107c2168153f point)
	{
		xa010107c2168153f xa010107c2168153f2 = xc81bcaf1d1c33511.x5c785f1d561da269(point);
		x96f881195fd151e8.Add(new PointF(xa010107c2168153f2.x8df91a2f90079e88, xa010107c2168153f2.xc821290d7ecc08bf));
	}

	private void x561b05f57e5b3cc1(x630b5fb239bb4657 x4d585acc834b724a)
	{
		x630b5fb239bb4657 x630b5fb239bb4658 = null;
		if (x4d585acc834b724a != null && x458c29076aeca30a.Count > 0)
		{
			x630b5fb239bb4657 x630b5fb239bb4659 = (x630b5fb239bb4657)x458c29076aeca30a.Peek();
			if (x630b5fb239bb4659 != null)
			{
				x630b5fb239bb4658 = x630b5fb239bb4659.x8b61531c8ea35b85();
				x630b5fb239bb4658.x2262d45deed5f60d(x4d585acc834b724a);
			}
		}
		x458c29076aeca30a.Push((x630b5fb239bb4658 != null) ? x630b5fb239bb4658 : x4d585acc834b724a);
	}

	private void x53d51f48095083cd()
	{
		x458c29076aeca30a.Pop();
	}
}
