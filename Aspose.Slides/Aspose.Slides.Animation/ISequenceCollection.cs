using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[Guid("4de7e704-c135-491f-a3cd-424c40b71c69")]
public interface ISequenceCollection : IEnumerable, IEnumerable<ISequence>
{
	int Count { get; }

	ISequence this[int index] { get; }

	IEnumerable AsIEnumerable { get; }

	ISequence Add(IShape shapeTrigger);

	void Remove(ISequence item);

	void RemoveAt(int index);

	void Clear();
}
