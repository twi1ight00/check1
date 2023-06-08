using System.Drawing;

namespace x1c8faa688b1f0b0c;

internal abstract class xfa6279ffd07aa4c9 : x4fdf549af9de6b97
{
	private const bool x4260481b74f4daed = true;

	internal const float xec91cd535b925c78 = 1.75f;

	private readonly string xc61ff88f1f98652d;

	private PointF x831916008bfc3ed7 = PointF.Empty;

	private bool x92229b967f4da3b9 = true;

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

	public abstract RectangleF BoundingBox { get; }

	public string x759aa16c2016a289 => xc61ff88f1f98652d;

	public bool xca1781db5d80e987
	{
		get
		{
			return x92229b967f4da3b9;
		}
		set
		{
			x92229b967f4da3b9 = value;
		}
	}

	protected xfa6279ffd07aa4c9(PointF origin, string name)
	{
		x831916008bfc3ed7 = origin;
		xc61ff88f1f98652d = name;
	}
}
