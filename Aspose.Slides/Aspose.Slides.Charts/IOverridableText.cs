using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("93f47dee-5f12-4a64-a49c-95dbd065ab01")]
public interface IOverridableText : IPresentationComponent, ISlideComponent, IChartComponent, IFormattedTextContainer
{
	ITextFrame TextFrameForOverriding { get; }

	IFormattedTextContainer AsIFormattedTextContainer { get; }

	ITextFrame AddTextFrameForOverriding(string text);
}
