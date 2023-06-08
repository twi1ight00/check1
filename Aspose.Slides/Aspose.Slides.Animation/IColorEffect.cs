using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[Guid("FA35FF58-EE77-445A-B74B-26935CB87652")]
public interface IColorEffect : IBehavior
{
	IColorFormat From { get; set; }

	IColorFormat To { get; set; }

	IColorOffset By { get; set; }

	ColorSpace ColorSpace { get; set; }

	ColorDirection Direction { get; set; }

	IBehavior AsIBehavior { get; }
}
