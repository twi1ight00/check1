using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("40de6723-8070-4d21-8347-89b0923b416d")]
[ComVisible(true)]
public interface IHyperlink
{
	HyperlinkActionType ActionType { get; }

	string ExternalUrl { get; }

	ISlide TargetSlide { get; }

	string TargetFrame { get; }

	string Tooltip { get; }

	bool History { get; }

	bool HighlightClick { get; }

	bool StopSoundOnClick { get; }

	bool Equals(IHyperlink hlink);
}
