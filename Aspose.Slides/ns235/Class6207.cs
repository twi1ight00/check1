using System.Drawing;

namespace ns235;

internal class Class6207 : Class6205
{
	private bool bool_3;

	private float float_1;

	public override RectangleF BoundingBox => new RectangleF(base.Origin, new SizeF(Size, Size));

	public bool Value
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public float Size
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public Class6207(PointF origin, string name, float size)
		: base(origin, name)
	{
		float_1 = size;
	}

	public Class6207()
	{
	}

	public override void vmethod_0(Class6176 visitor)
	{
		visitor.vmethod_15(this);
	}
}
