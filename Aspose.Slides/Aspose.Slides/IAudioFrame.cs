using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("f576b679-2117-4ca0-80dc-eca064be0073")]
[ComVisible(true)]
public interface IAudioFrame : IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGeometryShape, IPictureFrame
{
	int AudioCdStartTrack { get; set; }

	int AudioCdStartTrackTime { get; set; }

	int AudioCdEndTrack { get; set; }

	int AudioCdEndTrackTime { get; set; }

	AudioVolumeMode Volume { get; set; }

	AudioPlayModePreset PlayMode { get; set; }

	bool HideAtShowing { get; set; }

	bool PlayLoopMode { get; set; }

	bool Embedded { get; }

	string LinkPathLong { get; set; }

	IAudio EmbeddedAudio { get; set; }

	IPictureFrame AsIPictureFrame { get; }
}
