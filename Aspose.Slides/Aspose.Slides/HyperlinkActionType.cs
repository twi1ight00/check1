using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("1CABC263-4CE4-47A0-8817-22456238FDF3")]
[ComVisible(true)]
public enum HyperlinkActionType
{
	Unknown = -1,
	NoAction,
	Hyperlink,
	JumpFirstSlide,
	JumpPreviousSlide,
	JumpNextSlide,
	JumpLastSlide,
	JumpEndShow,
	JumpLastViewedSlide,
	JumpSpecificSlide,
	StartCustomSlideShow,
	OpenFile,
	OpenPresentation,
	StartStopMedia,
	StartMacro,
	StartProgram
}
