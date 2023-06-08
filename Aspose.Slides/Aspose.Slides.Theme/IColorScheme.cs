using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[Guid("ac563f5a-0cf8-43be-bb35-30ef07610d17")]
[ComVisible(true)]
public interface IColorScheme : IPresentationComponent, ISlideComponent
{
	IColorFormat this[ColorSchemeIndex index] { get; }

	IColorFormat Dark1 { get; }

	IColorFormat Light1 { get; }

	IColorFormat Dark2 { get; }

	IColorFormat Light2 { get; }

	IColorFormat Accent1 { get; }

	IColorFormat Accent2 { get; }

	IColorFormat Accent3 { get; }

	IColorFormat Accent4 { get; }

	IColorFormat Accent5 { get; }

	IColorFormat Accent6 { get; }

	IColorFormat Hyperlink { get; }

	IColorFormat FollowedHyperlink { get; }

	ISlideComponent AsISlideComponent { get; }
}
