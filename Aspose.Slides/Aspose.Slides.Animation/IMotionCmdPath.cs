using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[Guid("8D35EC46-596F-4D71-BBD3-94C322355EBF")]
[ComVisible(true)]
public interface IMotionCmdPath
{
	PointF[] Points { get; set; }

	MotionCommandPathType CommandType { get; set; }

	bool IsRelative { get; set; }

	MotionPathPointsType PointsType { get; set; }
}
