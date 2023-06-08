using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ClassInterface(ClassInterfaceType.None)]
[Guid("564D7ED4-4219-4DA7-A9EB-BED07E257CED")]
[ComVisible(true)]
public class MotionPath : IEnumerable, IEnumerable<IMotionCmdPath>, IMotionPath
{
	internal List<IMotionCmdPath> list_0 = new List<IMotionCmdPath>();

	public int Count => list_0.Count;

	public IMotionCmdPath this[int index] => list_0[index];

	IEnumerable IMotionPath.AsIEnumerable => this;

	public IMotionCmdPath Add(MotionCommandPathType type, PointF[] pts, MotionPathPointsType ptsType, bool bRelativeCoord)
	{
		IMotionCmdPath motionCmdPath = new MotionCmdPath(type, pts, ptsType, bRelativeCoord);
		list_0.Add(motionCmdPath);
		return motionCmdPath;
	}

	public void Insert(int index, MotionCommandPathType type, PointF[] pts, MotionPathPointsType ptsType, bool bRelativeCoord)
	{
		list_0.Insert(index, new MotionCmdPath(type, pts, ptsType, bRelativeCoord));
	}

	public void Clear()
	{
		list_0.Clear();
	}

	public void Remove(IMotionCmdPath item)
	{
		list_0.Remove(item);
	}

	public void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	IEnumerator<IMotionCmdPath> IEnumerable<IMotionCmdPath>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}
