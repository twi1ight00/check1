using System;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Web;
using Aspose.Slides.Export;
using Aspose.Slides.Theme;
using Aspose.Slides.Vba;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("35314620-7834-4794-a544-e437789339c8")]
public interface IPresentation : IDisposable, IPresentationComponent
{
	DateTime CurrentDateTime { get; set; }

	bool UpdateSlideNumberFields { get; set; }

	bool UpdateDateTimeFields { get; set; }

	IHeaderFooterManager HeaderFooterManager { get; }

	IProtectionManager ProtectionManager { get; }

	ISlideCollection Slides { get; }

	ISlideSize SlideSize { get; }

	IGlobalLayoutSlideCollection LayoutSlides { get; }

	IMasterSlideCollection Masters { get; }

	IMasterNotesSlideManager MasterNotesSlideManager { get; }

	IMasterHandoutSlideManager MasterHandoutSlideManager { get; }

	IFontsManager FontsManager { get; }

	ITextStyle DefaultTextStyle { get; }

	ICommentAuthorCollection CommentAuthors { get; }

	IDocumentProperties DocumentProperties { get; }

	IImageCollection Images { get; }

	IAudioCollection Audios { get; }

	IVideoCollection Videos { get; }

	ICustomData CustomData { get; }

	IVbaProject VbaProject { get; set; }

	SourceFormat SourceFormat { get; }

	IMasterTheme MasterTheme { get; }

	IHyperlinkQueries HyperlinkQueries { get; }

	IViewProperties ViewProperties { get; }

	IDisposable AsIDisposable { get; }

	IPresentationComponent AsIPresentationComponent { get; }

	void Save(string fname, SaveFormat format);

	void Save(Stream stream, SaveFormat format);

	void Save(string fname, SaveFormat format, ISaveOptions options);

	void Save(Stream stream, SaveFormat format, ISaveOptions options);

	void Save(string fname, int[] slides, SaveFormat format);

	void Save(string fname, int[] slides, SaveFormat format, ISaveOptions options);

	void Save(Stream stream, int[] slides, SaveFormat format);

	void Save(Stream stream, int[] slides, SaveFormat format, ISaveOptions options);

	[ComVisible(false)]
	void Save(string fname, SaveFormat format, HttpResponse response, bool showInline);

	[ComVisible(false)]
	void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline);

	void Print();

	[ComVisible(false)]
	void Print(PrinterSettings printerSettings);

	void Print(string printerName);

	[ComVisible(false)]
	void Print(PrinterSettings printerSettings, string presName);

	void JoinPortionsWithSameFormatting();
}
