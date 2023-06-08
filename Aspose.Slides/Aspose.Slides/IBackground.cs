using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("ede46fd7-01c9-4db5-b05e-b4b5cbc6af2d")]
[ComVisible(true)]
public interface IBackground : IPresentationComponent, ISlideComponent
{
	BackgroundType Type { get; set; }

	IFillFormat FillFormat { get; }

	IColorFormat StyleColor { get; }

	ushort StyleIndex { get; set; }

	ISlideComponent AsISlideComponent { get; }
}
