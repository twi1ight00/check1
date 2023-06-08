using System.Collections;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("0a6d0ca5-19e1-4eec-838c-8b8363e9356e")]
[ComVisible(true)]
public interface IRowCollection : ICollection, IEnumerable
{
	IRow this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	IRow[] AddClone(IRow templ, bool withAttachedRows);

	IRow[] InsertClone(int index, IRow templ, bool withAttachedRows);

	void RemoveAt(int firstRowIndex, bool withAttachedRows);
}
