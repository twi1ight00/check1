using System.Drawing;

namespace x1c8faa688b1f0b0c;

internal class x2e5b68a308682b82 : x4fdf549af9de6b97
{
	private PointF x831916008bfc3ed7 = PointF.Empty;

	private readonly int xaabccab0c06d038b;

	private readonly string xf7bbe199f47f234d;

	public PointF xc22eade24b085d91
	{
		get
		{
			return x831916008bfc3ed7;
		}
		set
		{
			x831916008bfc3ed7 = value;
		}
	}

	public int x504f3d4040b356d7 => xaabccab0c06d038b;

	public string x238bf167ccfdd282 => xf7bbe199f47f234d;

	public x2e5b68a308682b82(PointF origin, int level, string title)
	{
		x831916008bfc3ed7 = origin;
		xaabccab0c06d038b = level;
		xf7bbe199f47f234d = title;
	}

	public override void Accept(xf51865b83a7a0b3b visitor)
	{
		visitor.VisitOutlineItem(this);
	}
}
