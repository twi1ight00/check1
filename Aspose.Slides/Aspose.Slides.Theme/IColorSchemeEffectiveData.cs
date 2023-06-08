using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[ComVisible(true)]
[Guid("39a80416-48aa-41d1-90b2-2dd096b516cc")]
public interface IColorSchemeEffectiveData
{
	Color this[ColorSchemeIndex index] { get; }

	Color Dark1 { get; }

	Color Light1 { get; }

	Color Dark2 { get; }

	Color Light2 { get; }

	Color Accent1 { get; }

	Color Accent2 { get; }

	Color Accent3 { get; }

	Color Accent4 { get; }

	Color Accent5 { get; }

	Color Accent6 { get; }

	Color Hyperlink { get; }

	Color FollowedHyperlink { get; }
}
