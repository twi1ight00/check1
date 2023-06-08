using System.Drawing;
using System.Runtime.InteropServices;
using Aspose.Slides.Theme;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("6ae7da80-a80b-48d6-93a4-7c643a9a6a0e")]
public interface INotesSlide : IPresentationComponent, ISlideComponent, IThemeable, IOverrideThemeable, IBaseSlide
{
	ITextFrame NotesTextFrame { get; }

	ISlide ParentSlide { get; }

	IBaseSlide AsIBaseSlide { get; }

	IOverrideThemeable AsIOverrideThemeable { get; }

	Bitmap GetThumbnail(float scaleX, float scaleY);

	Bitmap GetThumbnail(Size imageSize);
}
