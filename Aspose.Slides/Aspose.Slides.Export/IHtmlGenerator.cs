using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[Guid("A5A958C2-DF4C-4C0A-A56F-64C2B8E18158")]
[ComVisible(true)]
public interface IHtmlGenerator
{
	SizeF SlideImageSize { get; }

	SvgCoordinateUnit SlideImageSizeUnit { get; }

	string SlideImageSizeUnitCode { get; }

	int PreviousSlideIndex { get; }

	int SlideIndex { get; }

	int NextSlideIndex { get; }

	void AddHtml(string html);

	void AddHtml(char[] html);

	void AddHtml(char[] html, int startIndex, int length);

	void AddText(string text);

	void AddText(char[] text);

	void AddText(char[] text, int startIndex, int length);

	void AddAttributeValue(string value);

	void AddAttributeValue(char[] value);

	void AddAttributeValue(char[] value, int startIndex, int length);
}
