using System.Collections;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("22897944-2303-4386-9859-d8809b1194e0")]
public interface IColumnCollection : ICollection, IEnumerable
{
	IColumn this[int index] { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }

	IColumn[] AddClone(IColumn templ, bool withAttachedColumns);

	IColumn[] InsertClone(int index, IColumn templ, bool withAttachedColumns);

	void RemoveAt(int firstColumnIndex, bool withAttachedRows);
}
