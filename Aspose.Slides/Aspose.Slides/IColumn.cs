using System.Collections;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("b5e43e73-512e-4ee2-bb50-9a0bdd9cce1c")]
[ComVisible(true)]
public interface IColumn : ICollection, IEnumerable, IPresentationComponent, ISlideComponent, ICellCollection
{
	double Width { get; set; }

	ICellCollection AsICellCollection { get; }
}
