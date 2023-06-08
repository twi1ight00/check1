using System.Collections;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("7a241db4-03de-4e61-bdb6-f39380d4f898")]
public interface IRow : ICollection, IEnumerable, IPresentationComponent, ISlideComponent, ICellCollection
{
	double Height { get; }

	double MinimalHeight { get; set; }

	ICellCollection AsICellCollection { get; }
}
