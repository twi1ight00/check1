using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("48595e9a-14ce-40ec-bf66-0aa0f1617a03")]
public interface ITabCollection : ICollection, IEnumerable, IEnumerable<ITab>
{
	ITab this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	ITab Add(double position, TabAlignment align);

	int Add(ITab value);

	void Clear();

	void RemoveAt(int index);
}
