using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[Guid("1E3B9AAF-7AD4-4A74-A4CA-5DC36B36FC86")]
[ComVisible(true)]
public interface IRotationEffect : IBehavior
{
	float From { get; set; }

	float To { get; set; }

	float By { get; set; }

	IBehavior AsIBehavior { get; }
}
