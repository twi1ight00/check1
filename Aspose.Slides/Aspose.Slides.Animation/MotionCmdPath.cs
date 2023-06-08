using System.Drawing;

namespace Aspose.Slides.Animation;

public class MotionCmdPath : IMotionCmdPath
{
	internal MotionCommandPathType motionCommandPathType_0;

	internal bool bool_0;

	internal PointF[] pointF_0;

	internal MotionPathPointsType motionPathPointsType_0;

	public PointF[] Points
	{
		get
		{
			return pointF_0;
		}
		set
		{
			pointF_0 = (PointF[])value.Clone();
		}
	}

	public MotionCommandPathType CommandType
	{
		get
		{
			return motionCommandPathType_0;
		}
		set
		{
			motionCommandPathType_0 = value;
		}
	}

	public bool IsRelative
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public MotionPathPointsType PointsType
	{
		get
		{
			return motionPathPointsType_0;
		}
		set
		{
			motionPathPointsType_0 = value;
		}
	}

	internal MotionCmdPath(MotionCommandPathType type, PointF[] pts, MotionPathPointsType typePts, bool bRelCoord)
	{
		bool_0 = bRelCoord;
		motionCommandPathType_0 = type;
		motionPathPointsType_0 = typePts;
		pointF_0 = null;
		if (pts != null)
		{
			pointF_0 = (PointF[])pts.Clone();
		}
	}
}
