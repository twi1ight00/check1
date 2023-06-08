using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns311;

internal class Class7131
{
	private float float_0;

	private float float_1;

	public virtual float StartOffset
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

	public virtual float vmethod_0(float length)
	{
		return float_0;
	}

	public Class7131(GraphicsPath path)
	{
		float_0 = 0f;
		float_1 = 0f;
	}

	public virtual float vmethod_1()
	{
		return float_0;
	}

	public virtual PointF vmethod_2(float length)
	{
		return default(PointF);
	}
}
