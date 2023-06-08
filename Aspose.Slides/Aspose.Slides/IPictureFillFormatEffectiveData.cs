using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("eebc709f-e3e5-4f57-b1fb-a8375e637793")]
[ComVisible(true)]
public interface IPictureFillFormatEffectiveData : IFillParamSource
{
	int Dpi { get; }

	PictureFillMode PictureFillMode { get; }

	IPictureEffectiveData Picture { get; }

	float CropLeft { get; }

	float CropTop { get; }

	float CropRight { get; }

	float CropBottom { get; }

	IFillParamSource AsIFillParamSource { get; }
}
