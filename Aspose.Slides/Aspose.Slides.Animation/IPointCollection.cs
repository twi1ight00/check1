using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Aspose.Slides.Animation;

[ComVisible(true)]
[Guid("540E5D77-5ED6-441D-A322-F97E507E2B9A")]
public interface IPointCollection : IEnumerable, IEnumerable<IPoint>
{
	int Count { get; }

	IPoint this[int index] { get; }

	IEnumerable AsIEnumerable { get; }
}
