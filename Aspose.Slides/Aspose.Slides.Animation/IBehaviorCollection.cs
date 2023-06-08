using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[Guid("40609d07-a488-4199-864c-ae7ad7f7d45e")]
public interface IBehaviorCollection : IEnumerable, IEnumerable<IBehavior>
{
	IBehavior this[int index] { get; set; }

	int Count { get; }

	IEnumerable AsIEnumerable { get; }

	void Add(IBehavior item);

	int IndexOf(IBehavior item);

	void Insert(int index, IBehavior item);

	bool Remove(IBehavior item);

	void RemoveAt(int index);

	void Clear();

	bool Contains(IBehavior item);
}
