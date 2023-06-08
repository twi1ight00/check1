using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("24ef6679-3ef4-472c-a43a-955ed5eda231")]
[ComVisible(true)]
public interface IMasterSlideCollection : ICollection, IEnumerable, IEnumerable<IMasterSlide>
{
	IMasterSlide this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	void Remove(IMasterSlide value);

	void RemoveAt(int index);

	void RemoveUnused(bool ignorePreserveField);

	IMasterSlide AddClone(IMasterSlide sourceMaster);

	IMasterSlide InsertClone(int index, IMasterSlide sourceMaster);
}
