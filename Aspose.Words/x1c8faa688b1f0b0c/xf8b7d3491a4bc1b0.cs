using System.Drawing;

namespace x1c8faa688b1f0b0c;

internal class xf8b7d3491a4bc1b0 : xfa6279ffd07aa4c9
{
	private bool x4574aea041dd835f;

	private float x3b77a41bd57164d6;

	public override RectangleF BoundingBox => new RectangleF(base.xc22eade24b085d91, new SizeF(x437e3b626c0fdd43, x437e3b626c0fdd43));

	public bool xd2f68ee6f47e9dfb
	{
		get
		{
			return x4574aea041dd835f;
		}
		set
		{
			x4574aea041dd835f = value;
		}
	}

	public float x437e3b626c0fdd43
	{
		get
		{
			return x3b77a41bd57164d6;
		}
		set
		{
			x3b77a41bd57164d6 = value;
		}
	}

	public xf8b7d3491a4bc1b0(PointF origin, string name, float size)
		: base(origin, name)
	{
		x3b77a41bd57164d6 = size;
	}

	public override void Accept(xf51865b83a7a0b3b visitor)
	{
		visitor.VisitFormFieldCheckbox(this);
	}
}
