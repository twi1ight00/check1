using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Aspose.Slides.Theme;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("f4ab4299-a727-404e-8ee6-038598460ac0")]
public interface ISlide : IPresentationComponent, ISlideComponent, IThemeable, IOverrideThemeable, IBaseSlide
{
	int SlideNumber { get; set; }

	bool Hidden { get; set; }

	ILayoutSlide LayoutSlide { get; set; }

	INotesSlide NotesSlide { get; }

	IBaseSlide AsIBaseSlide { get; }

	IOverrideThemeable AsIOverrideThemeable { get; }

	Bitmap GetThumbnail(float scaleX, float scaleY);

	Bitmap GetThumbnail();

	Bitmap GetThumbnail(Size imageSize);

	INotesSlide AddNotesSlide();

	IComment[] GetSlideComments(ICommentAuthor author);

	void WriteAsSvg(Stream stream);

	void Remove();
}
