using System.Collections;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("39eff844-34b3-4aeb-b848-ab708ba1840b")]
public interface ICellCollection : ICollection, IEnumerable, IPresentationComponent, ISlideComponent
{
	ICell this[int index] { get; }

	ISlideComponent AsISlideComponent { get; }

	ICollection AsICollection { get; }

	IEnumerable AsIEnumerable { get; }
}
