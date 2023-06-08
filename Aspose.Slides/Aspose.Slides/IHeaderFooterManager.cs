using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("0b4609c7-1c33-465f-bbad-3ae7c74a8f05")]
[ComVisible(true)]
public interface IHeaderFooterManager
{
	bool IsFooterVisible { get; set; }

	bool IsSlideNumberVisible { get; set; }

	bool IsDateTimeVisible { get; set; }

	void SetFooterText(string text);

	void SetDateTimeText(string date);

	void SetVisibilityOnTitleSlide(bool isPlaceholdersVisible);
}
