using System.Drawing;

namespace ns235;

internal class Class6211 : Class6204
{
	private PointF pointF_0 = PointF.Empty;

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

	public string Name => string_1;

	public bool IsHiddenFromOutline => string_1.StartsWith("_");

	public Class6211(PointF origin, string name)
	{
		pointF_0 = origin;
		string_1 = name;
	}

	public override void vmethod_0(Class6176 visitor)
	{
		visitor.vmethod_12(this);
	}
}
