using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("b0bc107e-49e7-4d02-868a-3ed96815f404")]
[ComVisible(true)]
public interface IVideoFrame : IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGeometryShape, IPictureFrame
{
	bool RewindVideo { get; set; }

	bool PlayLoopMode { get; set; }

	bool HideAtShowing { get; set; }

	AudioVolumeMode Volume { get; set; }

	VideoPlayModePreset PlayMode { get; set; }

	bool FullScreenMode { get; set; }

	string LinkPathLong { get; set; }

	IVideo EmbeddedVideo { get; set; }

	IPictureFrame AsIPictureFrame { get; }
}
