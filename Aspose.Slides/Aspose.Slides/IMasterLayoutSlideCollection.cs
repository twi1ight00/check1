using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("922F7D7D-8DDC-4930-A6BE-3F0799B244B5")]
public interface IMasterLayoutSlideCollection : IEnumerable<ILayoutSlide>, ICollection, IEnumerable, ILayoutSlideCollection
{
	ILayoutSlideCollection AsILayoutSlideCollection { get; }

	ILayoutSlide AddClone(ILayoutSlide sourceLayout);

	ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout);

	ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);

	ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName);

	void RemoveAt(int index);

	void Reorder(int index, ILayoutSlide layoutSlide);
}
