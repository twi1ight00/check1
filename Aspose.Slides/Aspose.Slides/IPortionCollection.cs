using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("2517c566-614f-441e-8ffd-e6c6b631584c")]
[ComVisible(true)]
public interface IPortionCollection : IEnumerable, IEnumerable<IPortion>
{
	IPortion this[int index] { get; }

	int Count { get; }

	IEnumerable AsIEnumerable { get; }

	void Add(IPortion value);

	int IndexOf(IPortion item);

	void Insert(int index, IPortion value);

	void Clear();

	bool Contains(IPortion item);

	bool Remove(IPortion item);

	void RemoveAt(int index);
}
