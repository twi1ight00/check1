using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("5c27c4af-7b37-4c09-b417-5c7a67687602")]
[ComVisible(true)]
public interface IBackdrop3DScene
{
	float[] NormalVector { get; set; }

	float[] AnchorPoint { get; set; }

	float[] UpVector { get; set; }
}
