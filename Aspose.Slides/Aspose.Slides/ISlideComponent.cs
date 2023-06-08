using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("052200be-011c-4905-926e-1cbb4ba120bb")]
[ComVisible(true)]
public interface ISlideComponent : IPresentationComponent
{
	IBaseSlide Slide { get; }

	IPresentationComponent AsIPresentationComponent { get; }
}
