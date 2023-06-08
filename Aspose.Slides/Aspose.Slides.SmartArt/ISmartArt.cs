using System.Runtime.InteropServices;

namespace Aspose.Slides.SmartArt;

[Guid("59837c61-35e5-433f-a4f1-803ca00e46c4")]
[ComVisible(true)]
public interface ISmartArt : IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGraphicalObject
{
	ISmartArtNodeCollection AllNodes { get; }

	SmartArtLayoutType Layout { get; }

	SmartArtQuickStyleType QuickStyle { get; set; }

	SmartArtColorType ColorStyle { get; set; }

	IGraphicalObject AsIGraphicalObject { get; }
}
