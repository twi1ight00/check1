using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[Guid("F798C9F2-A45F-4560-8AF0-69374680EA9C")]
public interface IScaleEffect : IBehavior
{
	NullableBool ZoomContent { get; set; }

	PointF From { get; set; }

	PointF To { get; set; }

	PointF By { get; set; }

	IBehavior AsIBehavior { get; }
}
