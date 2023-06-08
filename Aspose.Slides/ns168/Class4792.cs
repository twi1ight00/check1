using System.Drawing;

namespace ns168;

internal abstract class Class4792
{
	private int int_0;

	public int PageOrder
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public abstract void vmethod_0(Graphics canvas, PointF topLeft);
}
