using System.Collections;
using System.Drawing;
using xa7850104c8d8c135;

namespace xf269d97e8a02e911;

internal class xd74e588cbf76764c
{
	private readonly ArrayList xc72926de6b6361e2;

	private readonly ArrayList xa0448e7b13ffa0ce;

	private bool x6ecd97f202ff4f3f;

	internal bool x289bf94a509dd84c
	{
		get
		{
			return x6ecd97f202ff4f3f;
		}
		set
		{
			x6ecd97f202ff4f3f = value;
		}
	}

	internal xd74e588cbf76764c()
	{
		xc72926de6b6361e2 = new ArrayList();
		xa0448e7b13ffa0ce = new ArrayList();
	}

	internal xd8228c9a2d4ea8d5[] x012f094c7b70a4db()
	{
		xd8228c9a2d4ea8d5[] array = new xd8228c9a2d4ea8d5[xa0448e7b13ffa0ce.Count];
		for (int i = 0; i < xa0448e7b13ffa0ce.Count; i++)
		{
			array[i] = (xd8228c9a2d4ea8d5)xa0448e7b13ffa0ce[i];
		}
		return array;
	}

	internal PointF[] x466c8609d8f6c6c1()
	{
		return (PointF[])xc72926de6b6361e2.ToArray(typeof(PointF));
	}

	internal void xd6b6ed77479ef68c(PointF x2f7096dac971d6ec, xd8228c9a2d4ea8d5 x8c7a9e86b3391edc)
	{
		xc72926de6b6361e2.Add(x2f7096dac971d6ec);
		xa0448e7b13ffa0ce.Add(x8c7a9e86b3391edc);
	}
}
