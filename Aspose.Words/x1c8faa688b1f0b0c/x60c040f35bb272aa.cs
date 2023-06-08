using System.Collections;
using System.Drawing;
using x5794c252ba25e723;

namespace x1c8faa688b1f0b0c;

internal class x60c040f35bb272aa : x4fdf549af9de6b97, x5e0582a42c97011a, x755f711e37bcb2b3
{
	private readonly ArrayList xc72926de6b6361e2 = new ArrayList();

	public ArrayList x4d7474e8f1849803 => xc72926de6b6361e2;

	public x60c040f35bb272aa()
	{
	}

	public x60c040f35bb272aa(PointF startPoint, PointF endPoint)
	{
		xc72926de6b6361e2.Add(startPoint);
		xc72926de6b6361e2.Add(endPoint);
	}

	public x60c040f35bb272aa(float[] coords)
	{
		int num = coords.Length / 2;
		for (int i = 0; i < num; i++)
		{
			xc72926de6b6361e2.Add(new PointF(coords[i * 2], coords[i * 2 + 1]));
		}
	}

	public x60c040f35bb272aa(PointF[] points)
	{
		foreach (PointF pointF in points)
		{
			xc72926de6b6361e2.Add(pointF);
		}
	}

	public override void Accept(xf51865b83a7a0b3b visitor)
	{
		visitor.VisitPolyLineSegment(this);
	}

	public void xaccac17571a8d9fa(x54366fa5f75a02f7 xa801ccff44b0c7eb)
	{
		PointF[] array = new PointF[xc72926de6b6361e2.Count];
		for (int i = 0; i < xc72926de6b6361e2.Count; i++)
		{
			ref PointF reference = ref array[i];
			reference = (PointF)xc72926de6b6361e2[i];
		}
		xa801ccff44b0c7eb.xa4b699bd47eb7372(array);
		for (int j = 0; j < array.Length; j++)
		{
			xc72926de6b6361e2[j] = array[j];
		}
	}

	public x4fdf549af9de6b97 x8b61531c8ea35b85()
	{
		x60c040f35bb272aa x60c040f35bb272aa2 = new x60c040f35bb272aa();
		for (int i = 0; i < xc72926de6b6361e2.Count; i++)
		{
			PointF pointF = (PointF)xc72926de6b6361e2[i];
			x60c040f35bb272aa2.xc72926de6b6361e2.Add(new PointF(pointF.X, pointF.Y));
		}
		return x60c040f35bb272aa2;
	}
}
