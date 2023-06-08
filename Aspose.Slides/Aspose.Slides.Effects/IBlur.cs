using System.Runtime.InteropServices;

namespace Aspose.Slides.Effects;

[Guid("bf607fd0-fac8-434b-916a-cf38a6f7e66c")]
[ComVisible(true)]
public interface IBlur : IImageTransformOperation
{
	double Radius { get; set; }

	bool Grow { get; set; }

	IImageTransformOperation AsIImageTransformOperation { get; }
}
