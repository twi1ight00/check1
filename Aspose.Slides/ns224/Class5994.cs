using System.Drawing;
using ns235;

namespace ns224;

internal class Class5994 : Class5992
{
	private PointF pointF_0;

	private Class6217 class6217_0;

	private PointF pointF_1;

	public Class6217 Path
	{
		get
		{
			return class6217_0;
		}
		set
		{
			class6217_0 = value;
		}
	}

	public PointF CenterPoint
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

	public PointF FocusScales
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

	public Class5994(Class6217 path, PointF centerPoint)
		: base(Enum746.const_4)
	{
		class6217_0 = path;
		pointF_0 = centerPoint;
	}
}
