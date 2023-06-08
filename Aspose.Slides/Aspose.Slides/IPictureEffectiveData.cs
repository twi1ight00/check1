using System.Runtime.InteropServices;
using Aspose.Slides.Effects;

namespace Aspose.Slides;

[Guid("a7f57ff1-dbb6-4960-a913-4c43d56d4277")]
[ComVisible(true)]
public interface IPictureEffectiveData
{
	IPPImage Image { get; }

	string LinkPathLong { get; }

	IImageTransformOCollectionEffectiveData ImageTransform { get; }
}
