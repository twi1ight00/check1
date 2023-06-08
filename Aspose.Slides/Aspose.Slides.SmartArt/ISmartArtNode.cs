using System.Runtime.InteropServices;

namespace Aspose.Slides.SmartArt;

[ComVisible(true)]
[Guid("2f9636c7-6e3b-465c-ba75-655b23f31aa7")]
public interface ISmartArtNode
{
	ISmartArtNodeCollection ChildNodes { get; }

	ISmartArtShapeCollection Shapes { get; }

	ITextFrame TextFrame { get; set; }

	bool IsAssistant { get; set; }

	int Level { get; }

	IFillFormat BulletFillFormat { get; }

	int Position { get; set; }

	bool Remove();
}
