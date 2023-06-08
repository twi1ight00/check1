using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

namespace Aspose.Slides;

[Guid("8cadf989-4d96-4e85-bd9e-9264c84ebe35")]
[ComVisible(true)]
public interface IParagraphCollection : IEnumerable, IPresentationComponent, ISlideComponent, IEnumerable<IParagraph>
{
	IParagraph this[int index] { get; }

	int Count { get; }

	ISlideComponent AsISlideComponent { get; }

	IEnumerable AsIEnumerable { get; }

	void Add(IParagraph value);

	int Add(IParagraphCollection value);

	void Insert(int index, IParagraph value);

	void Insert(int index, IParagraphCollection value);

	void Clear();

	void RemoveAt(int index);

	bool Remove(IParagraph item);

	void AddFromHtml(string text);

	void AddFromHtml(string text, IHtmlExternalResolver resolver, string uri);

	string ExportToHtml(int firstParagraphIndex, int paragraphsCount, ITextToHtmlConversionOptions options);
}
