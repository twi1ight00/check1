using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("105cee73-cee2-4a11-895c-346b60c03923")]
public interface ILayoutSlideCollection : IEnumerable<ILayoutSlide>, ICollection, IEnumerable
{
	ILayoutSlide this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	ILayoutSlide GetByType(SlideLayoutType type);

	void Remove(ILayoutSlide value);

	void RemoveUnused();
}
