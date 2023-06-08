using System.Drawing;

namespace ns235;

internal class Class6221 : Class6204
{
	private PointF pointF_0 = PointF.Empty;

	private readonly int int_0;

	private readonly string string_1;

	public PointF Origin
	{
		get
		{
			return pointF_0;
		}
		set
		{
			pointF_0 = value;
		}
	}

	public int Level => int_0;

	public string Title => string_1;

	public Class6221(PointF origin, int level, string title)
	{
		pointF_0 = origin;
		int_0 = level;
		string_1 = title;
	}

	public override void vmethod_0(Class6176 visitor)
	{
		visitor.vmethod_13(this);
	}
}
