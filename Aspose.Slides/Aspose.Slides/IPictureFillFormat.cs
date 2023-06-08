using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("7a2950f4-103f-43de-b978-d6bad112d916")]
public interface IPictureFillFormat : IFillParamSource
{
	int Dpi { get; set; }

	PictureFillMode PictureFillMode { get; set; }

	ISlidesPicture Picture { get; }

	float CropLeft { get; set; }

	float CropTop { get; set; }

	float CropRight { get; set; }

	float CropBottom { get; set; }

	IFillParamSource AsIFillParamSource { get; }
}
