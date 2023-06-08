using ns57;

namespace Aspose.Slides.Animation;

public class AnimationTimeLine : IAnimationTimeLine
{
	internal SequenceCollection sequenceCollection_0;

	internal Sequence sequence_0;

	private readonly BaseSlide baseSlide_0;

	internal TextAnimationCollection textAnimationCollection_0 = new TextAnimationCollection();

	public ISequenceCollection InteractiveSequences => sequenceCollection_0;

	public ISequence MainSequence => sequence_0;

	public ITextAnimationCollection TextAnimationCollection => textAnimationCollection_0;

	internal BaseSlide Slide => baseSlide_0;

	internal AnimationTimeLine(BaseSlide slide)
	{
		baseSlide_0 = slide;
		sequenceCollection_0 = new SequenceCollection(this);
		sequence_0 = new Sequence(this);
		sequence_0.PPTXUnsupportedProps.SeqType = Enum303.const_4;
	}
}
