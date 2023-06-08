using System.Runtime.InteropServices;
using Aspose.Slides.Animation;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("20458136-aac5-4e8f-9652-7ba6b43e9aba")]
public interface IAnimationTimeLine
{
	ISequenceCollection InteractiveSequences { get; }

	ISequence MainSequence { get; }

	ITextAnimationCollection TextAnimationCollection { get; }
}
