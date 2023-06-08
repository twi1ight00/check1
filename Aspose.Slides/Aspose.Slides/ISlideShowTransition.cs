using System.Runtime.InteropServices;
using Aspose.Slides.SlideShow;

namespace Aspose.Slides;

[Guid("328ca6da-ad4b-4a60-8b51-78e8a30df2d8")]
[ComVisible(true)]
public interface ISlideShowTransition
{
	IAudio Sound { get; set; }

	TransitionSoundMode SoundMode { get; set; }

	bool SoundLoop { get; set; }

	bool AdvanceOnClick { get; set; }

	uint AdvanceAfterTime { get; set; }

	TransitionSpeed Speed { get; set; }

	ITransitionValueBase Value { get; }

	TransitionType Type { get; set; }

	bool SoundIsBuiltIn { get; set; }

	string SoundName { get; set; }
}
