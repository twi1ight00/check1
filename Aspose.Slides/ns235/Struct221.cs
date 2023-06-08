using System.Drawing;

namespace ns235;

internal struct Struct221
{
	private PointF pointF_0;

	private PointF pointF_1;

	private PointF pointF_2;

	public PointF StartPoint
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

	public PointF ControlPoint
	{
		get
		{
			return pointF_1;
		}
		set
		{
			pointF_1 = value;
		}
	}

	public PointF EndPoint
	{
		get
		{
			return pointF_2;
		}
		set
		{
			pointF_2 = value;
		}
	}
}
