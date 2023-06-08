using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[Guid("9D9FF911-CCB2-40E7-81D8-35EF9FE3DB57")]
public interface IMotionEffect : IBehavior
{
	PointF From { get; set; }

	PointF To { get; set; }

	PointF By { get; set; }

	PointF RotationCenter { get; set; }

	MotionOriginType Origin { get; set; }

	IMotionPath Path { get; set; }

	MotionPathEditMode PathEditMode { get; set; }

	float Angle { get; set; }

	IBehavior AsIBehavior { get; }
}
