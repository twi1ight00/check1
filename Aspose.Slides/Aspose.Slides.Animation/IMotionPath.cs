using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[Guid("3680EF28-E027-4820-B267-1E50B9475468")]
public interface IMotionPath : IEnumerable, IEnumerable<IMotionCmdPath>
{
	int Count { get; }

	IMotionCmdPath this[int index] { get; }

	IEnumerable AsIEnumerable { get; }

	IMotionCmdPath Add(MotionCommandPathType type, PointF[] pts, MotionPathPointsType ptsType, bool bRelativeCoord);

	void Insert(int index, MotionCommandPathType type, PointF[] pts, MotionPathPointsType ptsType, bool bRelativeCoord);

	void Clear();

	void Remove(IMotionCmdPath item);

	void RemoveAt(int index);
}
